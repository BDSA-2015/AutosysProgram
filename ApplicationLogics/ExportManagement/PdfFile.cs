using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLogics.ExportManagement
{
    public class PdfFile : IExportFile
    {
        public int Id { get; set; }
        public ExportType Type { get; set; }
        public byte[] Bytes { get; set; }
    }
}
