using NatigaEmt7an.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NatigaEmt7an.Contracts.Responses.Student
{
    public class StudentListResponse
    {
        public Guid Id { get; set; }
        public int SeatNumber { get; set; }
        public string Name { get; set; }
        public StudentStatus Status { get; set; }
        public StudentCategory Category { get; set; }
        public decimal TotalGrades { get; set; }
    }
}
