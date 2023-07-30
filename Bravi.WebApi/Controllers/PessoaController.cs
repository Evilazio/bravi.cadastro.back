using AutoMapper;
using Bravi.Data.Database.Models;
using Bravi.WebApi.Controllers.Base;
using Bravi.WebApi.DTO;
using Bravi.WebApi.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;

namespace Bravi.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class PessoaController : GenericCrudController<PessoaController, Pessoa, PessoaDTO>
{
    private readonly ILogger<PessoaController> Logger;
    private readonly PessoaService PessoaService;
    private readonly IMapper Mapper;

    public PessoaController(
        ILogger<PessoaController> logger,
        PessoaService PessoaService,
        IMapper mapper
    ) : base(logger, PessoaService, mapper)
    {
        Logger = logger;
        this.PessoaService = PessoaService;
        this.Mapper = mapper;
    }



    [HttpGet("{id:int}/Contatos")]
    public virtual ActionResult<List<ContatoDTO>> Get(int id)
    {
        var result = Mapper.Map<List<ContatoDTO>>(PessoaService.Get(x => x.Id == id, navigationPropertyPath: x => x.Contatos).FirstOrDefault()?.Contatos);
        if (result == null) return NoContent();
        return Ok(result);
    }


}
