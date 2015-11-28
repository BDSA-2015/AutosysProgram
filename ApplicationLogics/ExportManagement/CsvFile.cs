// CsvFile.cs is a part of Autosys project in BDSA-2015. Created: 24, 11, 2015.
// Creators: Dennis Thinh Tan Nguyen, William Diedricsehn Marstrand, Thor Valentin Aakjær Olesen Nielsen, 
// Jacob Mullit Møiniche.

using ApplicationLogics.ExportManagement.Interfaces;

namespace ApplicationLogics.ExportManagement
{
    public class CsvFile : IExportFile
    {
        public string InclusionCriteria { get; set; }
        public string ExclusionCriteria { get; set; }
        public int Origin { get; set; }
        public string Description { get; set; }
    }
}