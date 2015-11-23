using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationLogics.ExportManagement;

namespace ApplicationLogics
{
    public class ExportHandler
    {
        private IConverter _converter;
        //For converting to different files types for exporting

        public CsvFile ExportCsvFile(Protocol protocol)
        {
            _converter = new CSVConverter();
            return _converter.Convert(protocol) as CsvFile;
        }

        public PdfFile ExportPdfFile(Protocol protocol)
        {
            _converter = new PDFConverter();
            return _converter.Convert(protocol) as PdfFile;
        }
    }
}
