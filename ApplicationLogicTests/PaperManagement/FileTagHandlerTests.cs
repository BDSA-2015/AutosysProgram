using System;
using ApplicationLogics.PaperManagement;
using ApplicationLogics.PaperManagement.Savers;
using ApplicationLogics.StorageAdapter.Interface;
using BibtexLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ApplicationLogicTests.PaperManagement
{
    [TestClass()]
    public class FileTagHandlerTests
    {
        private Mock<IAdapter<Paper>> _mockAdapter;
        private Mock<ISaver<BibtexFile>> _mockBibtexTagSaver;
        private FileTagHandler _fileTagHandler;

        [TestInitialize]
        public void Initialize()
        {
            _mockAdapter = new Mock<IAdapter<Paper>>();
            _mockAdapter.Setup(r => r.Create(It.IsAny<Paper>()));

            _mockBibtexTagSaver = new Mock<ISaver<BibtexFile>>();
            _mockBibtexTagSaver.Setup(r => r.Save(It.IsAny<BibtexFile>()));

            _fileTagHandler = new FileTagHandler(new BibtexParser(), _mockBibtexTagSaver.Object);
        }

        #region SaveTags
        /// <summary>
        ///     Tests that a 
        /// </summary>
        [TestMethod()]
        public void SaveTagsTest()
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
            _fileTagHandler.SaveTags(file);

            //Assert
            _mockBibtexTagSaver.Verify(r => r.Save(It.IsAny<BibtexFile>()), Times.Once);

        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void SaveNullInputTest()
        {
            //Act
            _fileTagHandler.SaveTags(null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void SaveEmptyStringInputTest()
        {
            //Act
            _fileTagHandler.SaveTags("");
        }

        #endregion
    }
}