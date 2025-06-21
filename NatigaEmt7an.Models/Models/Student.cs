using NatigaEmt7an.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace NatigaEmt7an.Models.Models
{
    public class Student : EntityBase
    {
        public int SeatNumber { get; set; }
        public string Name { get; set; }
        public StudentStatus Status { get; set; }
        public StudentCategory Category { get; set; }
        public decimal TotalGrades { get; set; }

        public Guid GovernorateId { get; set; }
        [ForeignKey(nameof(GovernorateId))]
        public Governorate Governorate { get; set; }

        public Guid SchoolAdministrationId { get; set; }
        [ForeignKey(nameof(SchoolAdministrationId))]
        public SchoolAdministration SchoolAdministration { get; set; }

        public Guid SchoolId { get; set; }
        [ForeignKey(nameof(SchoolId))]
        public School School { get; set; }

        [InverseProperty("Student")]
        public StudentGrade StudentGrade { get; set; }
    }
}
