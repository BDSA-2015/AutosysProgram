using Microsoft.VisualStudio.TestTools.UnitTesting;
using ApplicationLogics.StorageFasade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationLogics.PaperManagement.Bibtex;
using Moq;
using Storage.Models;
using Storage.Repository;

namespace ApplicationLogics.StorageFasade.Tests
{
    [TestClass()]
    public class PaperFacadeTests
    {
        private Mock<IRepository<StoredPaper>> mockRepo;
        private PaperFacade _facade;

        [TestInitialize()]
        public void Initialize()
        {
            mockRepo = new Mock<IRepository<StoredPaper>>();
            _facade = new PaperFacade(mockRepo.Object);
        }

        /// <summary>
        /// Test the creation of a single paper, by mocking the database which should store the paper
        /// </summary>
        [TestMethod()]
        public void CreatePaperTest()
        {
            //Arrange
            var storedPaper = new StoredPaper() {Id = 0, Type = "article"};
            mockRepo.Setup(r => r.Create(storedPaper)).Returns(storedPaper.Id);
            var fields = new Dictionary<string, string>()
            {
                {"author", "Will Nance" },
                {"year", "1905" },
                {"title", "My book" }
            };
            var paper = new Paper("article", fields);

            //Act
            var paperId = _facade.Create(paper);

            //Assert
            Assert.IsTrue(paperId == 0);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreatePaperNullTest()
        {
            //Arrange
            var storedPaper = new StoredPaper() { Id = 0, Type = "article" };
            mockRepo.Setup(r => r.Create(storedPaper)).Returns(storedPaper.Id);

            //Act
            var paperId = _facade.Create(null);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void ReadTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void ReadTest1()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void UpdateTest()
        {
            throw new NotImplementedException();
        }
    }
}