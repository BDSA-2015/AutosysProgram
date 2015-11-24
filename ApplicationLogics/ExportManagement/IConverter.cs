using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLogics.ExportManagement
{
    /// <summary>
    /// Interface for Converter classes used by an ExportHandler.
    /// </summary>
    public interface IConverter
    {
        string Convert(Protocol protocol);
    }
}
