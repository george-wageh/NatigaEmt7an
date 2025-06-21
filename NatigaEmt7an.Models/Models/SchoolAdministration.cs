using System.ComponentModel.DataAnnotations.Schema;

namespace NatigaEmt7an.Models.Models
{
    public class SchoolAdministration : EntityBase
    {
        public string Name { get; set; }

        public Guid GovernorateId { get; set; }
        [ForeignKey(nameof(GovernorateId))]
        public Governorate Governorate { get; set; }

        public List<School> Schools { get; set; }

        public List<Student> Students { get; set; }

    }
}
