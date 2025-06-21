using System.ComponentModel.DataAnnotations.Schema;

namespace NatigaEmt7an.Models.Models
{
    public class School : EntityBase
    {
        public string Name { get; set; }

        public Guid SchoolAdministrationId { get; set; }
        [ForeignKey(nameof(SchoolAdministrationId))]
        public SchoolAdministration SchoolAdministration { get; set; }

        public Guid GovernorateId { get; set; }
        [ForeignKey(nameof(GovernorateId))]
        public Governorate Governorate { get; set; }

        public List<Student> Students { get; set; }
    }
}
