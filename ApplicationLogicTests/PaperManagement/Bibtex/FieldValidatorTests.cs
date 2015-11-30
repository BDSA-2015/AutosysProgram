using ApplicationLogics.PaperManagement.Bibtex;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApplicationLogicTests.PaperManagement.Bibtex
{
    [TestClass()]
    public class FieldValidatorTests
    {
        [TestMethod()]
        public void IsFieldValidDefaultTest()
        {
            //Arrange
            FieldValidator validator = new FieldValidator();
            var field1 = "Rued Langgaards Vej 102";
            var field2 = "My Name";

            //Assert
            Assert.IsTrue(validator.IsFieldValid(field1, EnumField.Address));
            Assert.IsTrue(validator.IsFieldValid(field2, EnumField.Author));

        }
    }
}