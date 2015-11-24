// PDFConverter.cs is a part of Autosys project in BDSA-2015. Created: 17, 11, 2015.
// Creators: Dennis Thinh Tan Nguyen, William Diedricsehn Marstrand, Thor Valentin Aakjær Olesen Nielsen, 
// Jacob Mullit Møiniche.

using System.Collections.Generic;
using System.Linq;
using ApplicationLogics.ExportManagement.Interfaces;
using ApplicationLogics.ProtocolManagement;
using ApplicationLogics.StudyManagement;

namespace ApplicationLogics.ExportManagement
{
    /// <summary>
    /// Class for converting export files to the PDF format.
    /// </summary>
    //Class is under construction
    public class PdfConverter : IConverter
    {
        /// <summary>
        /// Serializes the given Protocol and returns it as a JSON string
        /// </summary>
        /// <param name="protocol">
        /// The Protocol to be exported
        /// </param>
        /// <returns>
        /// A Protocol serialized to a JSON string
        /// </returns>
        public IExportFile Convert(Protocol protocol)
        {
            var exportFile = new PdfFile();
            exportFile.Description = protocol.Description;
            exportFile.Origin = protocol.Id;
            exportFile.Bytes = System.Convert.FromBase64String(ConvertInclusionData(protocol));
            return exportFile;
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