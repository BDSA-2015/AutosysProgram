﻿//// CSVConverterTests.cs is a part of Autosys project in BDSA-2015. Created: 24, 11, 2015.
//// Creaters: Dennis Thinh Tan Nguyen, William Diedricsehn Marstrand, Thor Valentin Aakjær Olesen Nielsen, 
//// Jacob Mullit Møiniche.

using ApplicationLogics.ExportManagement.Converter;
using ApplicationLogicTests.ExportManagement.Mock;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApplicationLogicTests.ExportManagement
{
    /// <summary>
    ///     Class for testing the conversion of Protocol Objects to strings following the European CSV format
    ///     using a ; as separator as described at https://en.wikipedia.org/wiki/Comma-separated_values
    /// </summary>
    [TestClass]
    public class CsvConverterTests
    {
        /// <summary>
        ///     Tests the conversion to a CSV formatted string of a Protocol
        /// </summary>
        [TestMethod]
        public void ConvertMultipleExAndInCriteriaProtocolTest()
        {
            //Arrange
            var protocol = ProtocolMock.CreateProtocolMock();

            //Act
            var csvFile = CsvConverter.Convert(protocol);

            //Assert
            Assert.IsTrue(csvFile == ProtocolMock.OutPut());
        }
    }
}