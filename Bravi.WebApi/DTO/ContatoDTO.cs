using Bravi.WebApi.DTO.Base;

namespace Bravi.WebApi.DTO
{
    public class ContatoDTO : EntityBaseDTO
    {
        public int ContatoTipoId { get; set; }
        public string Valor { get; set; } = string.Empty;
        public int PessoaId { get; set; }
    }
}
