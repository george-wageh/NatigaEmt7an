using System.ComponentModel.DataAnnotations.Schema;

namespace NatigaEmt7an.Models.Models
{
    public class StudentGrade : EntityBase
    {
        public decimal Ar { get; set; }
        public decimal Foreign1 { get; set; }
        public decimal Foreign2 { get; set; }
        public decimal Math1 { get; set; }
        public decimal Math2 { get; set; }
        public decimal History { get; set; }
        public decimal Geography { get; set; }
        public decimal Philosophy { get; set; }
        public decimal Psychology { get; set; }
        public decimal Chemistry { get; set; }
        public decimal Biology { get; set; }
        public decimal Geology { get; set; }
        public decimal Physics { get; set; }

        public Guid StudentId { get; set; }
        [ForeignKey(nameof(StudentId))]
        public Student Student { get; set; }

        public Guid OutCoursesId { get; set; }
        [ForeignKey(nameof(OutCoursesId))]
        public OutCourses OutCourses { get; set; }
    }

    public class OutCourses : EntityBase
    {
        public decimal ReligionEdu { get; set; }
        public decimal NationalEdu { get; set; }
        public decimal EconomicsStatistics { get; set; }
    }
}
