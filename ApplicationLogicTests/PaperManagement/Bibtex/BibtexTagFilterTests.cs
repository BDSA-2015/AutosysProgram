using System;
using System.IO;
using System.Linq;
using ApplicationLogics.PaperManagement.Bibtex;
using BibtexLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApplicationLogicTests.PaperManagement.Bibtex
{
    /// <summary>
    ///     Class for testing the implementation of a BibtexTagChecker which is used to
    ///     filter the entry and field types from an imported bibtex file
    /// </summary>
    [TestClass()]
    public class BibtexTagFilterTests
    {
        private ITagFilter<BibtexFile> _tagFilter;

        [TestInitialize()]
        public void Initialize()
        {
            _tagFilter = new BibtexTagFilter();
        }

        /// <summary>
        ///     Test method for testing the saving of tags (e.g. article, author, book, year...) from a BibtexFile
        /// </summary>
        [TestMethod()]
        public void Check_ValidInput_NumberOfTagsIs4()
        {
            //Arrange
            var file = "@Article{py03," +
                       "author = {Xavier D ecoret}," +
                       "title = {PyBiTex}," +
                       "year = {2003}}" +
                       "@Article{key03," +
                       "author = {Xavier D ecoret}," +
                       "title = {A {bunch {of} braces {in}} title}," +
                       "year = {2003}}" +
                       "@Article{key01," +
                       "author = {Simon the saint Templar}," +
                       "title = {Something nice}," +
                       "year = {700}}";
            //Act
            var bibtexFile = BibtexImporter.FromString(file);
            var tags = _tagFilter.Check(bibtexFile);
            
            //Assert
            Assert.IsTrue(tags.Count() == 4);
        }

        /// <summary>
        ///     Test method for testing that a BibtexFile with no entries is handled probably
        ///     No attempt to save tags to the database should be done, if the file contains no entries
        /// </summary>
        [TestMethod(), ExpectedException(typeof(InvalidDataException))]
        public void Save_EmptyFile_ExceptionThrown()
        {
            //Arrange
            var file = new BibtexFile();

            //Act
            _tagFilter.Check(file);
        }

        /// <summary>
        ///     Test method to check if a null input for the saver is handled probably
        /// </summary>
        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void Save_NullInput_ExceptionIsThrown()
        {
            //Act
            BibtexFile file = null;

            _tagFilter.Check(file);
        }
    }
}