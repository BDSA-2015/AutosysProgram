using System;
using ApplicationLogics.PaperManagement.Bibtex;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApplicationLogicTests.PaperManagement.Bibtex
{
    [TestClass()]
    public class CostumFieldCheckerTests
    {
        [TestMethod()]
        public void ValidateValidAddressTest()
        {
            //Arrange
            CustomFieldChecker checker1 = new CustomFieldChecker(@"^\w*$");
            var myAddress1 = "ABC";
            CustomFieldChecker checker2 = new CustomFieldChecker(@"^\d*$");
            var myAddress2 = "123";
            CustomFieldChecker checker3 = new CustomFieldChecker(@"^[A-Z]{1}[a-z]*[ ]{1}\d*$");
            var myAddress3 = "Spacyway 1002";

            //Assert
            Assert.IsTrue(checker1.Validate(myAddress1));
            Assert.IsTrue(checker2.Validate(myAddress2));
            Assert.IsTrue(checker3.Validate(myAddress3));
        }

        [TestMethod()]
        public void ValidateInvalidvalidAddressTest()
        {
            //Arrange
            CustomFieldChecker checker1 = new CustomFieldChecker(@"^\w*$");
            var myAddress1 = "ABC why did you use ¤";
            CustomFieldChecker checker2 = new CustomFieldChecker(@"^\d*$");
            var myAddress2 = "123 noletters allowed";
            CustomFieldChecker checker3 = new CustomFieldChecker(@"^[A-Z]{1}[a-z]*[ ]{1}\d*$");
            var myAddress3 = "Spacyway 1002 False";

            //Assert
            Assert.IsFalse(checker1.Validate(myAddress1));
            Assert.IsFalse(checker2.Validate(myAddress2));
            Assert.IsFalse(checker3.Validate(myAddress3));
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ValidateNullAddressTest()
        {
            //Arrange
            CustomFieldChecker checker1 = new CustomFieldChecker(@"^\w*$");
            
            //Act
            checker1.Validate(null);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ValidateEmptyAddressTest()
        {
            //Arrange
            CustomFieldChecker checker1 = new CustomFieldChecker(@"^\w*$");

            //Act
            checker1.Validate("");
        }
    }
}