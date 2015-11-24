using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationLogics.Repository;

namespace ApplicationLogics.ExportManagement
{
    /// <summary>
    /// Interface for ExportFiles generated from an existing Protocol.
    /// </summary>
    public interface IExportFile : IEntity
    {
        int Origin { get; set; }
        string Description { get; set; }
    }
}
