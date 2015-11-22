using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationLogics.Repository;

namespace ApplicationLogics.ExportManagement
{
    public interface IExportFile : IEntity
    {
        ExportType Type { get; set; }
    }
}
