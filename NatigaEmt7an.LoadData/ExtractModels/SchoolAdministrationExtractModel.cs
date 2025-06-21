using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NatigaEmt7an.LoadData.ExtractModels
{
    public class SchoolAdministrationExtractModel
    {
        public string Name { get; set; }

        public List<SchoolExtractModel> Schools { get; set; }
    }
}
