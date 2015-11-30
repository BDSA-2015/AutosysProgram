using System;
using System.IO;
using ApplicationLogics.PaperManagement.Bibtex;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApplicationLogicTests.PaperManagement.Bibtex
{
    [TestClass()]
    public class BibtexParserTests
    {
        [TestMethod()]
        public void ParseDefaultValidatorValidInputTest()
        {
            //Arrange
            var file = Properties.Resources.valid;
            var fileString = System.Text.Encoding.Default.GetString(file);
            var parser = new BibtexParser(new PaperValidator());
            //var bibtexInput = "@phdthesis{1234, "+
            //                            "author={Oren Patashnik}, "+
            //                            "title={BIBTEXing}, "+
            //                            "year={1988},}"+
            //                            "@article{5678, " +
            //                            "author={Morgan Testing}, " +
            //                            "title={Sharp testing}, " +
            //                            "year={2000},}";
            //Act
            var papers = parser.Parse(fileString);

            //Assert
            var validPaper = papers[0];
            Assert.AreEqual(EnumEntry.Article, validPaper.Type);
            Assert.AreEqual("William, Funstuff", validPaper.Fields[EnumField.Author]);
            Assert.AreEqual("ITU student anno 2015", validPaper.Fields[EnumField.Booktitle]);
            Assert.AreEqual("A student's thoughts on programming", validPaper.Fields[EnumField.Title]);
            Assert.AreEqual("2015", validPaper.Fields[EnumField.Year]);
            Assert.AreEqual("Aug", validPaper.Fields[EnumField.Month]);
            Assert.AreEqual("1", validPaper.Fields[EnumField.Volume]);
        }

        [TestMethod()]
        [ExpectedException(typeof(InvalidDataException))]
        public void ParseDefaultValidatorMissingAuthorTypeInputTest()
        {
            //Arrange
            var parser = new BibtexParser(new PaperValidator());
            var bibtexInput = Properties.Resources.missingAuthor;
            var invalidFile = System.Text.Encoding.Default.GetString(bibtexInput);
            //Act
            var papers = parser.Parse(invalidFile);
        }

        [TestMethod()]
        [ExpectedException(typeof(InvalidDataException))]
        public void ParseDefaultValidatorMissingStartInputTest()
        {
            //Arrange
            var parser = new BibtexParser(new PaperValidator());
            var bibtexInput = Properties.Resources.missingStartTag;
            var invalidFile = System.Text.Encoding.Default.GetString(bibtexInput);
            var papers = parser.Parse(invalidFile);
        }

        [TestMethod()]
        [ExpectedException(typeof(InvalidDataException))]
        public void ParseDefaultValidatorMissingBracketTypeInputTest()
        {
            //Arrange
            var parser = new BibtexParser(new PaperValidator());
            var bibtexInput = Properties.Resources.missingBrackets;
            var invalidFile = System.Text.Encoding.Default.GetString(bibtexInput);
            //Act
            var papers = parser.Parse(invalidFile);
        }
    }
}