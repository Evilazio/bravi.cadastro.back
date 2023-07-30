using Bravi.Data.Database.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace Bravi.Data.Database.Models
{
    public class Contato : EntityBase
    {
        [Required]
        public string Valor { get; set; } = string.Empty;
        [Required]
        public int ContatoTipoId { get; set; }
        [Required]
        public int PessoaId { get; set; }



        public ContatoTipo ContatoTipo { get; set; }
        public Pessoa Pessoa { get; set; }
    }
}
