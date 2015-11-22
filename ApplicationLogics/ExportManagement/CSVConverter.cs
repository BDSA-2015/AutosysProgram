using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationLogics.StudyManagement;

namespace ApplicationLogics.ExportManagement
{
    public class CSVConverter : IConverter
    {
        public IExportFile Convert(Protocol protocol)
        {
            var exportFile = new CsvFile();
            exportFile.Type = ExportType.CSV;
            exportFile.InclusionData = ConvertInclusionData(protocol);
            exportFile.ExclusionData = ConvertExclusionData(protocol);
            return exportFile;
        }

        private string ConvertInclusionData(Protocol protocol)
        {
            var myList = new List<Criteria>();
            myList.AddRange(protocol.InclusionCriteria);

            return string.Join(",", myList.Select(x => x.Name.ToArray()));
        }

        private string ConvertExclusionData(Protocol protocol)
        {
            var myList = new List<Criteria>();
            myList.AddRange(protocol.ExclusionCriteria);

            return string.Join(",", myList.Select(x => x.Name.ToArray()));
        }
    }
}
