using System;
using ApplicationLogics.PaperManagement.Bibtex;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApplicationLogicTests.PaperManagement.Bibtex
{
    /// <summary>
    /// Class for testing the checking of bibtex fields using the field checker 
    /// predefined in the system
    /// </summary>
    [TestClass()]
    public class DefaultFieldCheckerTests
    {
        /// <summary>
        /// Tests bibtex field syntaxes which should be valid
        /// </summary>
        [TestMethod()]
        public void ValidateValidInputTest()
        {
            //Arrange
            FieldChecker checker = new FieldChecker();
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

        /// <summary>
        /// Tests bibtex fields containing new lines
        /// Bibtex files with new lines in the beginning or middle of text
        /// should be invalid
        /// </summary>
        [TestMethod()]
        public void ValidateNewLineInputTest()
        {
            //Arrange
            FieldChecker checker = new FieldChecker();
            var bibtexInput1 = "\nTest";
            var bibtexInput2 = "Something\n more";

            //Assert
            Assert.IsFalse(checker.Validate(bibtexInput1));
            Assert.IsFalse(checker.Validate(bibtexInput2));
        }

        /// <summary>
        /// Tests empty string bibtex fields which should be invalid
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ValidateEmptyInputTest()
        {
            //Arrange
            FieldChecker checker = new FieldChecker();
            var bibtexInput1 = "";
            
            //Assert
            Assert.IsFalse(checker.Validate(bibtexInput1));
        }

        /// <summary>
        /// Tests null input which should be invalid
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ValidateNullInputTest()
        {
            //Arrange
            FieldChecker checker = new FieldChecker();

            //Act
            checker.Validate(null);
        }
    }
}