using System;
using System.Linq;
using ApplicationLogics.ProtocolManagement;

namespace ApplicationLogics.ExportManagement
{
    /// <summary>
    /// Class for converting export files to the CSV format.
    /// </summary>
    public class CsvConverter : IConverter
    {
        /// <summary>
        /// Converts the given Protocol to an IExportFile which can be exported by an ExportHandler
        /// </summary>
        /// <param name="protocol">The Protocol which is to be exported</param>
        /// <returns></returns>
        public IExportFile Convert(Protocol protocol)
        {
            if (protocol == null)
            {
                throw new ArgumentNullException("The given Protocol cannot be null");
            }

            var exportFile = new CsvFile();
            exportFile.InclusionCriteria = ConvertInclusionData(protocol);
            exportFile.ExclusionCriteria = ConvertExclusionData(protocol);
            exportFile.Description = protocol.Description;
            exportFile.Origin = protocol.Id;
            return exportFile;
        }

        /// <summary>
        /// Converts the data in a Protocol's InclusionCriteria to a CSV format
        /// </summary>
        /// <param name="protocol">The Protocol to be converted</param>
        /// <returns>The Protocol's Inclusion Criteria as a CSV string</returns>
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

        /// <summary>
        /// Converts the data in a Protocol's ExclusionCriteria to a CSV format
        /// </summary>
        /// <param name="protocol">The Protocol to be converted</param>
        /// <returns>The Protocol's Exclusion Criteria as a CSV string</returns>
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
