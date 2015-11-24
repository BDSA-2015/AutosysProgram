// IExportFile.cs is a part of Autosys project in BDSA-2015. Created: 24, 11, 2015.
// Creators: Dennis Thinh Tan Nguyen, William Diedricsehn Marstrand, Thor Valentin Aakjær Olesen Nielsen, 
// Jacob Mullit Møiniche.

using ApplicationLogics.Repository;

namespace ApplicationLogics.ExportManagement
{
    /// <summary>
    ///     Interface for ExportFiles generated from an existing Protocol.
    /// </summary>
    public interface IExportFile : IEntity
    {
        int Origin { get; set; }
        string Description { get; set; }
    }
}