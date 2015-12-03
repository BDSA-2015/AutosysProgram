using System;
using System.Collections.Generic;
using System.Linq;
using ApplicationLogics.PaperManagement;
using ApplicationLogics.PaperManagement.Bibtex;
using ApplicationLogics.StorageFasade;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Storage.Models;
using Storage.Repository;

namespace ApplicationLogicTests.PaperManagement
{
    [TestClass()]
    public class PaperHandlerTests
    {
        private Mock<IRepository<StoredPaper>> mockRepo;

        [TestInitialize()]
        public void Initialize()
        {
            mockRepo = new Mock<IRepository<StoredPaper>>();
        }

        /// <summary>
        /// Tests the import of a single paper using a papervalidator with a default field checker
        /// </summary>
        [TestMethod()]
        public void DefaultImportSinglePaperTest()
        {
            //Arrange
            var validator = new PaperValidator();
            var parser = new BibtexParser(validator);

            var fields = new Dictionary<string, string>()
            {
                {"author", "Will Nance" },
                {"year", "1905" },
                {"title", "My book" }
            };
            var paper = new Paper("article", fields);

            var mapperPaper = AutoMapper.Mapper.Map<StoredPaper>(paper);
            mockRepo.Setup(r => r.Create(mapperPaper)).Returns(mapperPaper.Id);

            var paperHandler = new PaperHandler(parser, new PaperFacade(mockRepo.Object));
            var file = Properties.Resources._3bibtex;
            var stringFile = System.Text.Encoding.Default.GetString(file);

            //Act
            var paperIds = paperHandler.ImportPaper(stringFile);

            //Assert
            Assert.IsTrue(paperIds.Count == 1 && paperIds.First() == 0);

        }

        /// <summary>
        /// Tests the import of multiple papers using a papervalidator with a default field checker
        /// </summary>
        [TestMethod()]
        public void DefaultImportPapers()
        {
            //Arrange
            var validator = new PaperValidator();
            var parser = new BibtexParser(validator);

            var fields1 = new Dictionary<string, string>()
            {
                {"author", "Xavier D ecoret"},
                {"title", "PyBiTex"},
                {"year", "2003"},
            };
            var fields2 = new Dictionary<string, string>()
            {
                {"author", "Xavier D ecoret"},
                {"title", "A {bunch {of} braces {in}} title"},
                {"year", "2003"}
            };
            var fields3 = new Dictionary<string, string>()
            {
                {"author", "Simon the saint Templar"},
                {"title", "Something nice"},
                {"year", "2012"}
            };

            //Testing papers
            var paper1 = new Paper("article", fields1);
            var paper2 = new Paper("article", fields2);
            var paper3 = new Paper("article", fields3);

            //paper1 mock setup
            var mapperPaper1 = AutoMapper.Mapper.Map<StoredPaper>(paper1);
            mockRepo.Setup(r => r.Create(mapperPaper1)).Returns(mapperPaper1.Id);

            //paper2 mock setup
            var mapperPaper2 = AutoMapper.Mapper.Map<StoredPaper>(paper2);
            mockRepo.Setup(r => r.Create(mapperPaper2)).Returns(mapperPaper2.Id);

            //paper3 mock setup
            var mapperPaper3 = AutoMapper.Mapper.Map<StoredPaper>(paper3);
            mockRepo.Setup(r => r.Create(mapperPaper3)).Returns(mapperPaper3.Id);

            var paperHandler = new PaperHandler(parser, new PaperFacade(mockRepo.Object));
            var file = Properties.Resources._3bibtex;
            var stringFile = System.Text.Encoding.Default.GetString(file);

            //Act
            var paperIDs = paperHandler.ImportPaper(stringFile);

            //Assert
            var checkList = new List<int>() {0, 1, 2};
            Assert.IsTrue(paperIDs.Equals(checkList));
        }

        /// <summary>
        /// Tests the import of an empty bibtex file using a papervalidator with a default field checker
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void DefaultImportEmptyTypeBibtex()
        {
            //Arrange
            var validator = new PaperValidator();
            var parser = new BibtexParser(validator);

            var paperHandler = new PaperHandler(parser, new PaperFacade(mockRepo.Object));
            var file = Properties.Resources.emptybibtex;
            var stringFile = System.Text.Encoding.Default.GetString(file);

            //Act
            paperHandler.ImportPaper(stringFile);
        }

        /// <summary>
        /// Tests the import of a bibtex file which is null using a papervalidator with a default field checker
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DefaultImportNullBibtex()
        {
            //Arrange
            var validator = new PaperValidator();
            var parser = new BibtexParser(validator);

            var paperHandler = new PaperHandler(parser, new PaperFacade(mockRepo.Object));

            //Act
            paperHandler.ImportPaper(null);
        }
    }
}