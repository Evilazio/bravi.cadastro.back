using Bravi.Data;
using Bravi.Data.Database.Context;
using Bravi.Data.Database.Models;
using Bravi.Tests.Helper;
using Bravi.WebApi.Services;
using Microsoft.EntityFrameworkCore;

namespace bravi.cadastro.tests;

public class RepositoryTest
{
    public RepositoryTest()
    {
        _dbContext = new DataContext(DataContextConnection.GetConnection());
        if (_dbContext != null)
        {
            _dbContext.Database.EnsureDeleted();
            _dbContext.Database.EnsureCreated();
        }
    }

    private DataContext _dbContext;

    [Fact]
    public void Validar_DbContextEstaSendoCriado_DeveSerTrue()
    {

        Assert.NotNull(_dbContext);
    }

    [Fact]
    public void Validar_ServicesGenericoEstaFazendoCrud_GetDeveSerTrue()
    {
        var PessoaService = new PessoaService(_dbContext);
        var ContatoService = new ContatoService(_dbContext);
        var ContatoTipoService = new ContatoTipoService(_dbContext);

        Assert.NotNull(PessoaService);
        Assert.NotNull(ContatoService);
        Assert.NotNull(ContatoTipoService);

        // Criar pessoa
        var Pessoa = PessoaService.Insert(new Pessoa() { Nome = "Evilazio" });
        PessoaService.SaveChanges();
        Pessoa = PessoaService.GetByID(Pessoa.Id);
        Assert.NotNull(Pessoa);

        // Alterar pessoa buscada
        Pessoa.Nome = "Ricarte";
        PessoaService.Update(Pessoa);
        PessoaService.SaveChanges();

        // Adicionar Contato Tipo
        var ContatoTipo = ContatoTipoService.Insert(new ContatoTipo { Nome = "Whatsapp" });
        Assert.NotNull(ContatoTipo);
        ContatoTipoService.SaveChanges();

        // Adicionar Contato vinculado a Pessoa
        var Contato = ContatoService.Insert(new Contato { ContatoTipoId = ContatoTipo.Id, PessoaId = Pessoa.Id });
        Assert.NotNull(Contato);
        Contato.Valor = "11 9 5446";
        ContatoService.SaveChanges();

        // Verificar relação
        var Relacao = PessoaService.Get(x => x.Id == Pessoa.Id, navigationPropertyPath: x => x.Contatos).First();
        Assert.NotEmpty(Relacao.Contatos);

        // Buscar pessoa alterada
        Pessoa = PessoaService.GetByID(Pessoa.Id);
        Assert.True(Pessoa.Nome == "Ricarte");

        // Remover pessoa buscada
        PessoaService.Delete(Pessoa.Id);
        PessoaService.SaveChanges();
        Pessoa = PessoaService.GetByID(Pessoa.Id);
        Assert.Null(Pessoa);

        // A lista de contatos desse usuário deve ser deletada junta
        var Contatos = ContatoService.Get();
        Assert.Empty(Contatos);
    }


}