using System.ComponentModel.DataAnnotations;

namespace Bravi.Data.Database.Models.Base
{
    public abstract class EntityBase 
    {
        [Key]
        public virtual int Id { get; set; }
    }
}
