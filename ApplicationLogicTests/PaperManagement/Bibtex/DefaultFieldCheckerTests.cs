using System;
using ApplicationLogics.PaperManagement.Bibtex;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApplicationLogicTests.PaperManagement.Bibtex
{
    [TestClass()]
    public class DefaultFieldCheckerTests
    {
        [TestMethod()]
        public void ValidateValidInputTest()
        {
            //Arrange
            DefaultFieldChecker checker = new DefaultFieldChecker();
            var bibtexInput1 = "T";
            var bibtexInput2 = "Testing";
            var bibtexInput3 = "Testing Space";
            var bibtexInput4 = "Testing Numbers 123";
            var bibtexInput5 = "Testing Symbols !@#$%^&*()_+?|>\\/,.;':\"][}{";
            var bibtexInput6 = "Something\n";

            //Assert
            Assert.IsTrue(checker.Validate(bibtexInput1));
            Assert.IsTrue(checker.Validate(bibtexInput2));
            Assert.IsTrue(checker.Validate(bibtexInput3));
            Assert.IsTrue(checker.Validate(bibtexInput4));
            Assert.IsTrue(checker.Validate(bibtexInput5));
            Assert.IsTrue(checker.Validate(bibtexInput6));
        }

        [TestMethod()]
        public void ValidateNewLineInputTest()
        {
            //Arrange
            DefaultFieldChecker checker = new DefaultFieldChecker();
            var bibtexInput1 = "\nTest";
            var bibtexInput2 = "Something\n more";

            //Assert
            Assert.IsFalse(checker.Validate(bibtexInput1));
            Assert.IsFalse(checker.Validate(bibtexInput2));
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ValidateEmptyInputTest()
        {
            //Arrange
            DefaultFieldChecker checker = new DefaultFieldChecker();
            var bibtexInput1 = "";
            
            //Assert
            Assert.IsFalse(checker.Validate(bibtexInput1));
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ValidateNullInputTest()
        {
            //Arrange
            DefaultFieldChecker checker = new DefaultFieldChecker();

            //Act
            checker.Validate(null);
        }
    }
}