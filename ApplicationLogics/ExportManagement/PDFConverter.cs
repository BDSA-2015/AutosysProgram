using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationLogics.StudyManagement;
using Newtonsoft.Json;

namespace ApplicationLogics.ExportManagement
{
    /// <summary>
    /// Class for converting export files to the PDF format.
    /// </summary>
    //Class is under construction
    public class PDFConverter : IConverter
    {
        /// <summary>
        /// Serializes the given Protocol and returns it as a JSON string
        /// </summary>
        /// <param name="protocol">The Protocol to be exported</param>
        /// <returns>A Protocol serialized to a JSON string</returns>
        public string Convert(Protocol protocol)
        {
            var exportFile = new PdfFile();
            exportFile.Type = ExportType.PDF;
            exportFile.Description = protocol.Description;
            exportFile.Origin = protocol.Id;
            exportFile.Bytes = System.Convert.FromBase64String(ConvertInclusionData(protocol));
            return JsonConvert.SerializeObject(exportFile);
        }

        private string ConvertInclusionData(Protocol protocol)
        {
            var myList = new List<Criteria>();
            myList.AddRange(protocol.InclusionCriteria);

            return string.Join(" ", myList.Select(x => x.Name.ToArray()));
        }

        private string ConvertExclusionData(Protocol protocol)
        {
            var myList = new List<Criteria>();
            myList.AddRange(protocol.ExclusionCriteria);

            return string.Join(" ", myList.Select(x => x.Name.ToArray()));
        }
    }
}
