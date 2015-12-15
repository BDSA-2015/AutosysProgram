using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationLogics.PaperManagement;
using ApplicationLogics.StorageAdapter;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Storage.Models;
using Storage.Repository.Interface;

namespace ApplicationLogicTests.StorageAdapter
{
    [TestClass]
    public class PaperFacadeTests
    {
        private PaperAdapter _adapter;
        private Mock<IRepository<StoredPaper>> _mockRepo;

        [TestInitialize]
        public void Initialize()
        {
            Mapper.CreateMap<Paper, StoredPaper>();
            Mapper.CreateMap<StoredPaper, Paper>();
            _mockRepo = new Mock<IRepository<StoredPaper>>();
            _adapter = new PaperAdapter(_mockRepo.Object);
        }

        /// <summary>
        ///     Test the creation of a single paper, by checking the paperId
        /// </summary>
        [TestMethod]
        public void CreatePaperTest()
        {
            //Arrange
            var storedPaper = new StoredPaper {Id = 0, Type = "article"};
            _mockRepo.Setup(r => r.Create(storedPaper)).Returns(Task.FromResult(storedPaper.Id));
            var fieldTypes = new List<string>();
            fieldTypes.Add("author");
            fieldTypes.Add("title");
            fieldTypes.Add("year");
            var fieldValues = new List<string>();
            fieldValues.Add("Will BeGood");
            fieldValues.Add("Life's Questions");
            fieldValues.Add("1905");

            var paper = new Paper("article", fieldTypes, fieldValues);

            //Act
            var paperId = _adapter.Create(paper);

            //Assert
            Assert.IsTrue(paperId.Result == 0);
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentNullException))]
        public void CreatePaperNullTest()
        {
            //Arrange
            var storedPaper = new StoredPaper {Id = 0, Type = "article"};
            _mockRepo.Setup(r => r.Create(storedPaper)).Returns(Task.FromResult(storedPaper.Id));

            //Act
            var paperId = _adapter.Create(null);
        }

        [TestMethod]
        public async Task DeleteObjectNotNullTest()
        {
            //Arrange
            _mockRepo.Setup(r => r.DeleteIfExists(It.IsAny<StoredPaper>().Id));

            //Act
            await _adapter.DeleteIfExists(0);

            //Assert
            _mockRepo.Verify(r => r.DeleteIfExists(0), Times.Once);
        }

        [TestMethod]
        public async Task DeleteObjectCorrectStateTest()
        {
            //Arrange
            var fieldTypes = new List<string>();
            fieldTypes.Add("author");
            fieldTypes.Add("title");
            fieldTypes.Add("year");
            var fieldValues = new List<string>();
            fieldValues.Add("Will BeGood");
            fieldValues.Add("Life's Questions");
            fieldValues.Add("1905");
            var paper = new Paper("article", fieldTypes, fieldValues);

            StoredPaper callBackPaper = null;
            _mockRepo.Setup(r => r.DeleteIfExists(It.IsAny<StoredPaper>().Id)).Callback<StoredPaper>(o => callBackPaper = o);

            //Act
            await _adapter.DeleteIfExists(0);

            //Assert
            //TODO Make NUnit TestCase() work and reduce method to a single Assert
            Assert.IsTrue(callBackPaper.Id == 0);
            Assert.IsTrue(callBackPaper.Type == "article");
            Assert.IsTrue(callBackPaper.FieldTypes.Count == 3);
            Assert.IsTrue(callBackPaper.FieldValues.Count == 3);
            Assert.IsTrue(callBackPaper.FieldTypes.ElementAt(0) == "author");
            Assert.IsTrue(callBackPaper.FieldTypes.ElementAt(1) == "title");
            Assert.IsTrue(callBackPaper.FieldTypes.ElementAt(2) == "year");
            Assert.IsTrue(callBackPaper.FieldValues.ElementAt(0) == "Will BeGood");
            Assert.IsTrue(callBackPaper.FieldValues.ElementAt(1) == "Life's Questions");
            Assert.IsTrue(callBackPaper.FieldValues.ElementAt(2) == "1905");
        }

        [TestMethod]
        public void ReadAllObjectsTypeTest()
        {
            //Arrange
            var fieldTypes = new List<string>();
            fieldTypes.Add("author");
            fieldTypes.Add("title");
            fieldTypes.Add("year");
            var fieldValues = new List<string>();
            fieldValues.Add("Will BeGood");
            fieldValues.Add("Life's Questions");
            fieldValues.Add("1905");
            var paper1 = new Paper("article", fieldTypes, fieldValues);
            var paper2 = new Paper("phdthesis", fieldTypes, fieldValues);
            var paper3 = new Paper("book", fieldTypes, fieldValues);
            var paper4 = new Paper("notebook", fieldTypes, fieldValues);
            var paper5 = new Paper("ebook", fieldTypes, fieldValues);

            var paperCollection = new List<StoredPaper>();
            paperCollection.Add(Mapper.Map<StoredPaper>(paper1));
            paperCollection.Add(Mapper.Map<StoredPaper>(paper2));
            paperCollection.Add(Mapper.Map<StoredPaper>(paper3));
            paperCollection.Add(Mapper.Map<StoredPaper>(paper4));
            paperCollection.Add(Mapper.Map<StoredPaper>(paper5));

            _mockRepo.Setup(r => r.Read()).Returns(paperCollection.AsQueryable());

            //Act
            var papers = _adapter.Read();

            //Assert
            for (var i = 0; i < papers.Count(); i++)
            {
                Assert.IsTrue(papers.ElementAt(i).Type == paperCollection.ElementAt(i).Type);
            }
        }

        [TestMethod]
        public async Task ReadObjectTest()
        {
            //Arrange
            var callBackPaperId = -1;
            _mockRepo.Setup(r => r.Read(It.IsAny<int>())).Callback<int>(o => callBackPaperId = o);

            //Act
            await _adapter.Read(5);

            //Assert
            //TODO Make NUnit TestCase() work and reduce method to a single Assert
            Assert.IsTrue(callBackPaperId == 5);
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentOutOfRangeException))]
        public async Task ReadObjectNegativeIdTest()
        {
            //Arrange

            //Act
            await _adapter.Read(-1);

            //Assert
        }

        [TestMethod]
        public async Task UpdateObjectNotNullTest()
        {
            //Arrange
            var fieldTypes = new List<string>();
            fieldTypes.Add("author");
            fieldTypes.Add("title");
            fieldTypes.Add("year");
            var fieldValues = new List<string>();
            fieldValues.Add("Will BeGood");
            fieldValues.Add("Life's Questions");
            fieldValues.Add("1905");
            var paper = new Paper("article", fieldTypes, fieldValues);

            StoredPaper callBackPaper = null;
            _mockRepo.Setup(r => r.UpdateIfExists(It.IsAny<StoredPaper>())).Callback<StoredPaper>(o => callBackPaper = o);

            //Act
            await _adapter.UpdateIfExists(paper);

            //Assert
            Assert.IsNotNull(callBackPaper);
        }

        [TestMethod]
        public async Task UpdateObjectCorrectStateTest()
        {
            //Arrange
            var fieldTypes = new List<string>();
            fieldTypes.Add("author");
            fieldTypes.Add("title");
            fieldTypes.Add("year");
            var fieldValues = new List<string>();
            fieldValues.Add("Will BeGood");
            fieldValues.Add("Life's Questions");
            fieldValues.Add("1905");
            var paper = new Paper("article", fieldTypes, fieldValues);

            StoredPaper callBackPaper = null;
            _mockRepo.Setup(r => r.UpdateIfExists(It.IsAny<StoredPaper>())).Callback<StoredPaper>(o => callBackPaper = o);

            //Act
            await _adapter.UpdateIfExists(paper);

            //Assert
            //TODO Make NUnit TestCase() work and reduce method to a single Assert
            Assert.IsTrue(callBackPaper.Id == 0);
            Assert.IsTrue(callBackPaper.Type == "article");
            Assert.IsTrue(callBackPaper.FieldTypes.Count == 3);
            Assert.IsTrue(callBackPaper.FieldValues.Count == 3);
            Assert.IsTrue(callBackPaper.FieldTypes.ElementAt(0) == "author");
            Assert.IsTrue(callBackPaper.FieldTypes.ElementAt(1) == "title");
            Assert.IsTrue(callBackPaper.FieldTypes.ElementAt(2) == "year");
            Assert.IsTrue(callBackPaper.FieldValues.ElementAt(0) == "Will BeGood");
            Assert.IsTrue(callBackPaper.FieldValues.ElementAt(1) == "Life's Questions");
            Assert.IsTrue(callBackPaper.FieldValues.ElementAt(2) == "1905");
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentNullException))]
        public void UpdateNullTest()
        {
            throw new NotImplementedException();
            //Arrange

            //Act
            //_adapter.UpdateIfExists(null);

            //Assert
        }
    }
}