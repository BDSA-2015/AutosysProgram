// PdfFile.cs is a part of Autosys project in BDSA-2015. Created: 24, 11, 2015.
// Creators: Dennis Thinh Tan Nguyen, William Diedricsehn Marstrand, Thor Valentin Aakjær Olesen Nielsen, 
// Jacob Mullit Møiniche.

namespace ApplicationLogics.ExportManagement
{
    /// <summary>
    ///     Class for creating a PdfFile to export.
    /// </summary>
    public class PdfFile : IExportFile
    {
        public byte[] Bytes { get; set; }
        public int Id { get; set; }
        public int Origin { get; set; }
        public string Description { get; set; }
    }
}