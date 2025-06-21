using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NatigaEmt7an.LoadData.Models
{
    public class StudentRoot
    {
        public StudentInfo StudentInfo { get; set; }
        public Courses Courses { get; set; }
        public OutCourses OutCourses { get; set; }
    }
}
