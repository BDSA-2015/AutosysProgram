using System;
using System.Collections;
using System.Collections.Generic;
using ApplicationLogics.PaperManagement.Bibtex;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

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
        [TestCase("T")]
        [TestCase("Testing")]
        [TestCase("Testing Space")]
        [TestCase("Testing Numbers 123")]
        [TestCase("Testing Symbols !@#$%^&*()_+?|>\\/,.;':\"][}{")]
        [TestCase("Something\n")]
        [TestMethod()]
        public void ValidateValidInputTest(string field)
        {
            //Arrange
            DefaultFieldChecker checker = new DefaultFieldChecker();

            //Assert
            Assert.IsTrue(checker.Validate(field));
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
            DefaultFieldChecker checker = new DefaultFieldChecker();
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
            DefaultFieldChecker checker = new DefaultFieldChecker();
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
            DefaultFieldChecker checker = new DefaultFieldChecker();

            //Act
            checker.Validate(null);
        }
    }
}