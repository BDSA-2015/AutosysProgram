namespace ApplicationLogics.ExportManagement
{
    /// <summary>
    /// Class for creating a PdfFile to export.
    /// </summary>
    public class PdfFile : IExportFile
    {
        public int Id { get; set; }
        public int Origin { get; set; }
        public string Description { get; set; }
        public byte[] Bytes { get; set; }
    }
}
