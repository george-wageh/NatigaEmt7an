using System.ComponentModel.DataAnnotations;

namespace NatigaEmt7an.Models.Models
{
    public class EntityBase
    {
        [Key]
        public Guid Id { get; set; }
    }
}
