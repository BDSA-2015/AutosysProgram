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
