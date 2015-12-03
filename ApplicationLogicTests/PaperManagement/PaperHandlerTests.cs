using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ApplicationLogics.PaperManagement;
using ApplicationLogics.PaperManagement.Bibtex;
using ApplicationLogics.PaperManagement.Interfaces;
using ApplicationLogics.StorageFasade;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ApplicationLogicTests.PaperManagement
{
    [TestClass()]
    public class PaperHandlerTests
    {
        [TestMethod()]
        public void CreatePaperTest()
        {
            //Arrange
            var validator = new PaperValidator();
            var parser = new BibtexParser(validator);
            var paperHandler = new PaperHandler(parser, new PaperFasade());
            var file = Properties.Resources.valid;
            var stringFile = System.Text.Encoding.Default.GetString(file);

            //Act
            paperHandler.ImportPaper(stringFile);

            //Assert
        }

        [TestMethod()]
        public void ImportPaperTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void GeneratePaperTest()
        {
            throw new NotImplementedException();
        }
    }
}