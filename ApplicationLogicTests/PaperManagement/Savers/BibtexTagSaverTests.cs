﻿using System;
using System.Threading.Tasks;
using ApplicationLogics.PaperManagement;
using ApplicationLogics.PaperManagement.Savers;
using ApplicationLogics.StorageAdapter;
using ApplicationLogics.StorageAdapter.Interface;
using BibtexLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Storage.Repository;

namespace ApplicationLogicTests.PaperManagement.Savers
{
    /// <summary>
    ///     Class for testing the implementation of a BibtexSaver which is used to
    ///     save new bibtex tags in the database from an imported bibtex file
    /// </summary>
    [TestClass()]
    public class BibtexTagSaverTests
    {
        private BibtexTagSaver _saver;
        private IParser<BibtexFile> _parser;
        private Mock<IAdapter<BibtexTag>> _mockAdapter;

        [TestInitialize()]
        public void Initialize()
        {
            _mockAdapter = new Mock<IAdapter<BibtexTag>>();
            _mockAdapter.Setup(r => r.Create(It.IsAny<BibtexTag>()));

            _saver = new BibtexTagSaver(_mockAdapter.Object);
            _parser = new BibtexParser();
        }

        /// <summary>
        ///     Test method for testing the saving of tags (e.g. article, author, book, year...) from a BibtexFile
        /// </summary>
        [TestMethod()]
        public void Save_ValidInput_CreateIsCalled()
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
            var parsedFile = _parser.ParseToFile(file);
            _saver.Save(parsedFile);

            //Assert
            _mockAdapter.Verify(r => r.Create(It.IsAny<BibtexTag>()), Times.Exactly(4));
        }

        [TestMethod(), ExpectedException(typeof(ArgumentNullException))]
        public void Save_EmptyFile_CreateIsNotCalled()
        {
            //Arrange
            var file = "";

            //Act
            var parsedFile = _parser.ParseToFile(file);
            _saver.Save(parsedFile);

            //Assert
            _mockAdapter.Verify(r => r.Create(It.IsAny<BibtexTag>()), Times.Never);
        }
    }
}