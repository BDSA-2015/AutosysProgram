using ApplicationLogics.ProtocolManagement;
using Newtonsoft.Json;

namespace ApplicationLogics.ExportManagement
{
    /// <summary>
    /// Class for exporting research protocols to the clients in different formats.
    /// </summary>
    public class ExportHandler
    {
        private IConverter _converter;

        public string ExportCsvFile(Protocol protocol)
        {
            _converter = new CsvConverter();
            return JsonConvert.SerializeObject(_converter.Convert(protocol));
        }

        public string ExportPdfFile(Protocol protocol)
        {
            _converter = new PdfConverter();
            return JsonConvert.SerializeObject(_converter.Convert(protocol));
        }
    }
}
