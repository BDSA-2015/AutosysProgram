using ApplicationLogics.ProtocolManagement;

namespace ApplicationLogics.ExportManagement
{
    /// <summary>
    /// Interface for Converter classes used by an ExportHandler.
    /// </summary>
    public interface IConverter
    {
        IExportFile Convert(Protocol protocol);
    }
}
