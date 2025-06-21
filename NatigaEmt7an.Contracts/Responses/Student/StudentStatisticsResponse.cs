using NatigaEmt7an.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NatigaEmt7an.Contracts.Responses.Student
{
    public class GradeClassification
    {
        public StudentCategory? Category { get; set; }
        public int G_410_369 { get; set; }
        public int G_369_349 { get; set; }
        public int G_349_308 { get; set; }
        public int G_308_246 { get; set; }
        public int G_246_205 { get; set; }
        public int G_205_0 { get; set; }
    }
    public class StatusCategory {
        public StudentCategory? Category { get; set; }
        public int FailedCount { get; set; }
        public int SecondRoundCount { get; set; }
        public int PassedCount { get; set; }
    }
    public class StudentStatisticsResponse { 
        public List<GradeClassification> GradeClassifications { get; set; }
        public List<StatusCategory> StatusClassifications { get; set; }
    }
}
