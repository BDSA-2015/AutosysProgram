using System;
using ApplicationLogics.StudyManagement;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApplicationLogicTests.StudyManagement
{
    [TestClass]
    public class CriteriaFactoryTest
    {
        private CriteriaFactory criteriaFactory;
        private Criteria criteria;

        [TestInitialize]
        public void TestInitializer()
        {
            criteriaFactory = new CriteriaFactory();
            
        }
        


        [TestMethod]
        public void CriteriaFactory_SetSearchCriteria_ContainsString_AreObjectChangedCorrectly()
        {
            // Arrange 
            Criteria criteria = new Criteria
            {
                Value = "Computer science",
                ComparisonType = Criteria.Operation.Contains,
                Name = "Summary-Contians-Computer science",
                Tag = "Summary",
                Description = "Used to find usage of the word 'Computer science'"
            };

            //Act
            criteria = criteriaFactory.CreateEmptyCriteria("Summary-Contians-Computer science", "Used to find usage of the word 'Computer science'");
            criteriaFactory.SetSearchCriteria_ContainsString(criteria, "Summary", "Computer Science");
            
            //Test

            Assert.IsTrue(criteria.Equals(criteria));
        }


        [TestMethod]
        public void CriteriaFactory_SetSearchCriteria_GreaterThan_AreObjectChangedCorrectly()
        {
            // Arrange
            Criteria expectedState = new Criteria
            {

                Value = "1990",
                ComparisonType = Criteria.Operation.Greater,
                Name = "Year-isGreaterThan-1990",
                Description = "Used to find books released after 1990",
                Tag = "ReleaseYear",
            };

            // Act
            criteria = criteriaFactory.CreateEmptyCriteria("Year-isGreaterThan-1990", "Used to find books released after 1990");
            criteriaFactory.SetSearchCriteria_GreaterThan(criteria, "ReleaseYear", 1990);

            // Test
            Assert.IsTrue(criteria.Equals(expectedState));
        }

        [TestMethod]
        public void CriteriaFactory_SetSearchCriteria_LessThan_AreObjectChangedCorrectly()
        {
            Criteria expectedState = new Criteria
            {
                Value = "1990",
                ComparisonType = Criteria.Operation.Less,
                Name = "Year-isLessThan-1990",
                Description = "Used to find books released before 1990",
                Tag = "ReleaseYear",
            };
            
            //Act
            criteria = criteriaFactory.CreateEmptyCriteria("Year-isLessThan-1990", "Used to find books released before 1990");
            criteriaFactory.SetSearchCriteria_LessThan(criteria, "ReleaseYear", 1990);

            //Test
            Assert.IsTrue(criteria.Equals(expectedState));
        }

        [TestMethod]
        public void CriteriaFactory_SetSearchCriteria_Equals_AreObjectChangedCorrectly()
        {
            Criteria expectedState = new Criteria
            {
                Value = "1990",
                ComparisonType = Criteria.Operation.Equals,
                Name = "Year-Equals-1990",
                Description = "Used to find books released in 1990",
                Tag = "ReleaseYear",
            };

            //Act
            criteria = criteriaFactory.CreateEmptyCriteria("Year-Equals-1990", "Used to find books released in 1990");
            criteriaFactory.SetSearchCriteria_Equals(criteria, "ReleaseYear", 1990);

            //Test
            Assert.IsTrue(criteria.Equals(expectedState));
        }

        [TestMethod]
        public void CriteriaFactory_SetSearchCriteria_Equals_AreObjectChangedCorrectly_TestedWithAStringInsteadOfInt()
        {
            Criteria expectedState = new Criteria
            {
                Value = "1990", 
                ComparisonType = Criteria.Operation.Equals,
                Name = "Year-Equals-1990",
                Description = "Used to find books released in 1990",
                Tag = "ReleaseYear"
            }; 

            //Act
            criteria = criteriaFactory.CreateEmptyCriteria("Year-Equals-1990", "Used to find books released in 1990");
            criteriaFactory.SetSearchCriteria_Equals(criteria, "ReleaseYear", "1990");

            //Test
            Assert.IsTrue(criteria.Equals(expectedState));
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CriteriaFactory_CreateEmptyCriteria_EmptyStringIntputAtNameVariable()
        {
            //Setup
            Criteria expectedState = new Criteria();

            //Act
            criteria = criteriaFactory.CreateEmptyCriteria("","Used get Books which is written by a Auther which starts with 'A'");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CriteriaFactory_CreateEmptyCriteria_EmptyStringIntputAtDescriptionVariable()
        {
            //Setup
            Criteria expectedState = new Criteria();
        
            //Act
            criteria = criteriaFactory.CreateEmptyCriteria("Books-Auther-Names A", "");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CriteriaFactory_SetSearchCriteria_GreaterThan_EmptyStringinputAtBibtexTag()
        {
            //Setup
            criteria = criteriaFactory.CreateEmptyCriteria("someName","SomeDescription");

            criteriaFactory.SetSearchCriteria_GreaterThan(criteria, "", 3);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CriteriaFactory_SetSearchCriteria_LessThan_EmptyStringinputAtBibtexTag()
        {
            //Setup
            criteria = criteriaFactory.CreateEmptyCriteria("someName", "SomeDescription");

            criteriaFactory.SetSearchCriteria_LessThan(criteria, "", 3);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CriteriaFactory_SetSearchCriteria_equals_EmptyStringinputAtBibtexTag()
        {
            //Setup
            criteria = criteriaFactory.CreateEmptyCriteria("someName", "SomeDescription");

            criteriaFactory.SetSearchCriteria_Equals(criteria,"",4);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CriteriaFactory_SetSearchCriteria_equals_EmptyStringinputAtValue()
        {
            //Setup
            criteria = criteriaFactory.CreateEmptyCriteria("someName", "SomeDescription");

            criteriaFactory.SetSearchCriteria_Equals(criteria, "Auther", "");
        }
    }
}
