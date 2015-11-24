// IConverter.cs is a part of Autosys project in BDSA-2015. Created: 17, 11, 2015.
// Creators: Dennis Thinh Tan Nguyen, William Diedricsehn Marstrand, Thor Valentin Aakjær Olesen Nielsen, 
// Jacob Mullit Møiniche.

using ApplicationLogics.ProtocolManagement;

namespace ApplicationLogics.ExportManagement
{
    /// <summary>
    ///     Interface for Converter classes used by an ExportHandler.
    /// </summary>
    public interface IConverter
    {
        IExportFile Convert(Protocol protocol);
    }
}