using Bravi.Data.Database.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace Bravi.Data.Database.Models
{
    public class Pessoa : EntityBase
    {
        [MinLength(3)]
        public string Nome { get; set; } = string.Empty;
        public List<Contato> Contatos { get; set; }
    }
}
