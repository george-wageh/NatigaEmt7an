using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NatigaEmt7an.Contracts.Requests.Student
{
    public class StudentListRequst : PageListRequest
    {
        public int? SeatNum { get; set; }
        public string? StudentName { get; set; }
        public Guid? GovernorateId { get; set; }
        public Guid? SchoolId { get; set; }
        public Guid? SchoolAdministrationId { get; set; }
    }
}
