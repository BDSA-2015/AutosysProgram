using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationLogics.ExportManagement;

namespace ApplicationLogics
{
    /// <summary>
    /// Class for exporting research protocols to the clients in different formats.
    /// </summary>
    public class ExportHandler
    {
        private IConverter _converter;

        public CsvFile ExportCsvFile(Protocol protocol)
        {
            _converter = new CsvConverter();
            return _converter.Convert(protocol) as CsvFile;
        }

        public PdfFile ExportPdfFile(Protocol protocol)
        {
            _converter = new PDFConverter();
            return _converter.Convert(protocol) as PdfFile;
        }
    }
}
