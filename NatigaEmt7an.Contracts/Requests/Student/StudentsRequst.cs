using NatigaEmt7an.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NatigaEmt7an.Contracts.Requests.Student
{
    public class StudentsRequst
    {
        public Guid? GovernorateId { get; set; }
        public Guid? SchoolId { get; set; }
        public Guid? SchoolAdministrationId { get; set; }
        public StudentCategory? Category { get; set; }
    }
}
