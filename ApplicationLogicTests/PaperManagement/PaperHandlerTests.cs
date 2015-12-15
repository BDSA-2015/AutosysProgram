using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationLogics.PaperManagement;
using ApplicationLogics.PaperManagement.Savers;
using ApplicationLogics.StorageAdapter;
using ApplicationLogics.StorageAdapter.Interface;
using AutoMapper;
using BibtexLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;
using Storage.Models;
using Storage.Repository.Interface;

namespace ApplicationLogicTests.PaperManagement
{
    /// <summary>
    ///     Class for testing the PaperHandler which handles import of papers
    /// </summary>
    [TestClass]
    public class PaperHandlerTests
    {
        private Mock<IAdapter<Paper>> _mockAdapter;
        private Mock<ISaver<BibtexFile>> _mockBibtexTagSaver;
        private PaperHandler _paperHandler;

        [TestInitialize]
        public void Initialize()
        {
            _mockAdapter = new Mock<IAdapter<Paper>>();
            _mockAdapter.Setup(r => r.Create(It.IsAny<Paper>()));

            _mockBibtexTagSaver = new Mock<ISaver<BibtexFile>>();
            _mockBibtexTagSaver.Setup(r => r.Save(It.IsAny<BibtexFile>()));

            _paperHandler = new PaperHandler(new BibtexParser(), _mockAdapter.Object);
        }

    #region ImportPaper
            /// <summary>
            ///     Tests the import of a single bibtex file as a Paper
            /// </summary>
            [TestMethod]
            public void ImportSinglePaperTest()
            {
                //Arrange
                var file = "@book{839269," +
                           "author = {Will Newman}," +
                           "title = {My book}," +
                           "year = {1905}}";

                //Act
                _paperHandler.ParseFile(file);

                //Assert
                _mockAdapter.Verify(r => r.Create(It.IsAny<Paper>()), Times.Once);
            }

            /// <summary>
            ///     Tests the import of multiple papers
            /// </summary>
            [TestMethod]
            public void ImportMultiplePapers()
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
                _paperHandler.ParseFile(file);

                //Assert
                _mockAdapter.Verify(r => r.Create(It.IsAny<Paper>()), Times.Exactly(3));
            }

            /// <summary>
            ///     Tests the import of a bibtex file which is null
            /// </summary>
            [TestMethod]
            [ExpectedException(typeof (ArgumentNullException))]
            public void ImportNullBibtex()
            {
                //Act
                _paperHandler.ParseFile(null);
            }

            /// <summary>
            ///     Tests the import of a bibtex file which is empty
            /// </summary>
            [TestMethod]
            [ExpectedException(typeof (ArgumentNullException))]
            public void ImportEmptyBibtex()
            {
                //Act
                _paperHandler.ParseFile("");
            }
        #endregion
    }
}