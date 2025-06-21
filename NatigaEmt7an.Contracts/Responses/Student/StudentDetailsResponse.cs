using NatigaEmt7an.Models.Enums;
using NatigaEmt7an.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NatigaEmt7an.Contracts.Responses.Student
{
    public class StudentDetailsResponse
    {
        public Guid Id { get; set; }
        public int SeatNumber { get; set; }
        public string Name { get; set; }

        public string AdministrationName { get; set; }
        public string SchoolName { get; set; }

        public StudentStatus Status { get; set; }
        public StudentCategory Category { get; set; }
        public decimal TotalGrades { get; set; }
        public GradesResponse Grades { get; set; }
        public OutCourses OutGrades { get; set; }

    }
    public class GradesResponse
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
    }

    public class OutCourses
    {
        public decimal ReligionEdu { get; set; }
        public decimal NationalEdu { get; set; }
        public decimal EconomicsStatistics { get; set; }
    }
}
