using Bravi.Data.Database.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace Bravi.Data.Database.Models
{
    public class ContatoTipo : EntityBase
    {
        [Required]
        [MinLength(3)]
        public string Nome { get; set; } = string.Empty;
    }
}