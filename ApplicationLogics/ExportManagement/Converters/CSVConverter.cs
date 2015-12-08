// CSVConverter.cs is a part of Autosys project in BDSA-2015. Created: 17, 11, 2015.
// Creators: Dennis Thinh Tan Nguyen, William Diedricsehn Marstrand, Thor Valentin Aakjær Olesen Nielsen, 
// Jacob Mullit Møiniche.

using System;
using ApplicationLogics.ExportManagement.Interfaces;
using ApplicationLogics.ProtocolManagement;

namespace ApplicationLogics.ExportManagement.Converters
{
    /// <summary>
    /// Class for converting Protocols to the CSV format to be used in the CSVExporter class.
    /// The CSV format followed is the European version using ; as separator as described at https://en.wikipedia.org/wiki/Comma-separated_values
    /// </summary>
    public class CsvConverter : IConverter
    {
        /// <summary>
        /// Converts the given Protocol to a commmaseparated string which can be exported by a CSVExporter
        /// </summary>
        /// <param name="protocol">The Protocol which is to be exported</param>
        /// <returns>a commasperated string containing the given Protocol information</returns>
        public string Convert(Protocol protocol)
        {
            throw new NotImplementedException();
        }

    }
}