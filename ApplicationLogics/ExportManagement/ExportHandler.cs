// ExportHandler.cs is a part of Autosys project in BDSA-2015. Created: 17, 11, 2015.
// Creators: Dennis Thinh Tan Nguyen, William Diedricsehn Marstrand, Thor Valentin Aakjær Olesen Nielsen, 
// Jacob Mullit Møiniche.

using System;
using System.IO;
using System.Web.Http;
using ApplicationLogics.ExportManagement.Converter;
using ApplicationLogics.ExportManagement.Interfaces;
using ApplicationLogics.ProtocolManagement;
using CsvHelper;
using Newtonsoft.Json;

namespace ApplicationLogics.ExportManagement
{
    /// <summary>
    /// Class for exporting research protocols to the clients in different formats.
    /// </summary>
    public class ExportHandler
    {
        /// <summary>
        /// Method for converting a Protocol to CSV and exporting it as JSON
        /// </summary>
        /// <param name="protocol">The Protocol to be converted and exported</param>
        /// <returns></returns>
        public string ExportCsvFile(Protocol protocol)
        {
            if (protocol == null)
            {
                throw new ArgumentNullException(nameof(protocol));
            }

            return JsonConvert.SerializeObject(CsvConverter.Convert(protocol));
        }
    }
}