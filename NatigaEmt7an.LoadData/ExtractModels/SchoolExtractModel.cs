using NatigaEmt7an.LoadData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NatigaEmt7an.LoadData.ExtractModels
{
    public class SchoolExtractModel
    {
        public string Name { get; set; }
        public List<StudentRoot> Students { get; set; }
    }
}
