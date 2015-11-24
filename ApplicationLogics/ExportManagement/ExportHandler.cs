using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationLogics.ExportManagement;
using Newtonsoft.Json;

namespace ApplicationLogics
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
            _converter = new PDFConverter();
            return JsonConvert.SerializeObject(_converter.Convert(protocol));
        }
    }
}
