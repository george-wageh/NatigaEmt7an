using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NatigaEmt7an.LoadData.ExtractModels
{
    public class GovernorateExtractModel
    {
        public string Name { get; set; }

        public List<SchoolAdministrationExtractModel> Administrations { get; set; }
    }
}
