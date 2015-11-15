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
        //For converting to different files types for exporting
        private IConverter _converter;

        public ExportHandler(IConverter converter)
        {
            _converter = converter;
        }

        public ExportType Export(Protocol protocol)
        {
            throw new NotImplementedException();
        }
    }
}
