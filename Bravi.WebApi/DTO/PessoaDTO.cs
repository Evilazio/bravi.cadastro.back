

using Bravi.WebApi.DTO.Base;
using System.Text.Json.Serialization;

namespace Bravi.WebApi.DTO
{
    public class PessoaDTO : EntityBaseDTO
    {
        public string Nome { get; set; } = string.Empty;
    }
}
