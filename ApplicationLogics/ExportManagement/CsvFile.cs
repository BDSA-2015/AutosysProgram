using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationLogics.StudyManagement;

namespace ApplicationLogics.ExportManagement
{
    public class CsvFile : IExportFile
    {
        public int Id { get; set; }
        public ExportType Type { get; set; }
        public string InclusionCriteria { get; set; }
        public string ExclusionCriteria { get; set; }
        public int Origin { get; set; }
        public string Description { get; set; }
    }
}
