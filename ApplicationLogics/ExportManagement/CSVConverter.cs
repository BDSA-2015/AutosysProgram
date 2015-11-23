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
            if (protocol == null)
            {
                throw new ArgumentNullException("The given Protocol cannot be null");
            }

            var exportFile = new CsvFile();
            exportFile.Type = ExportType.CSV;
            exportFile.InclusionData = ConvertInclusionData(protocol);
            exportFile.ExclusionData = ConvertExclusionData(protocol);
            return exportFile;
        }

        private string ConvertInclusionData(Protocol protocol)
        {
            
            return string.Join(",", protocol.InclusionCriteria.Select(x =>
            {
                if (x == null)
                {
                    throw new ArgumentNullException("The Inclusion Criteria cannot be null");
                }
                if (string.IsNullOrEmpty(x.Name))
                {
                    throw new ArgumentException("Cannot convert null or empty criteria name");
                }
                return x.Name;
            }));
        }

        private string ConvertExclusionData(Protocol protocol)
        {
            return string.Join(",", protocol.ExclusionCriteria.Select(x =>
            {
                if (x == null)
                {
                    throw new ArgumentNullException("The Exclusion Criteria cannot be null");
                }
                if (string.IsNullOrEmpty(x.Name))
                {
                    throw new ArgumentNullException("Cannot convert null or empty criteria name");
                }
                return x.Name;
            }));
        }
    }
}
