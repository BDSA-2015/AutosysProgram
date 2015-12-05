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

            var fieldTypes = new List<string>();
            fieldTypes.Add("author");
            fieldTypes.Add("title");
            fieldTypes.Add("year");
            var fieldValues = new List<string>();
            fieldValues.Add("Will Newman");
            fieldValues.Add("My book");
            fieldValues.Add("1905");

            var paper = new Paper("article", fieldTypes, fieldValues);

            AutoMapper.Mapper.CreateMap<Paper, StoredPaper>();
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

            var fieldTypes1 = new List<string>();
            fieldTypes1.Add("author");
            fieldTypes1.Add("title");
            fieldTypes1.Add("year");
            var fieldValues1 = new List<string>();
            fieldValues1.Add("Xavier D ecoret");
            fieldValues1.Add("PyBiTex");
            fieldValues1.Add("2003");
            var fieldTypes2 = new List<string>();
            fieldTypes2.Add("author");
            fieldTypes2.Add("title");
            fieldTypes2.Add("year");
            var fieldValues2 = new List<string>();
            fieldValues2.Add("Xavier D ecoret");
            fieldValues2.Add("A {bunch {of} braces {in}} title");
            fieldValues2.Add("1700");
            var fieldTypes3 = new List<string>();
            fieldTypes3.Add("author");
            fieldTypes3.Add("title");
            fieldTypes3.Add("year");
            var fieldValues3 = new List<string>();
            fieldValues3.Add("Simon the saint Templar");
            fieldValues3.Add("Something nice");
            fieldValues3.Add("700");
            
            //Testing papers
            var paper1 = new Paper("article", fieldTypes1, fieldValues1);
            var paper2 = new Paper("article", fieldTypes2, fieldValues2);
            var paper3 = new Paper("article", fieldTypes3, fieldValues3);

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
        [ExpectedException(typeof(ArgumentNullException))]
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