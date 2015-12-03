using System;
using ApplicationLogics.StudyManagement;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApplicationLogicTests.StudyManagement
{
    [TestClass]
    public class CriteriaHandlerTest
    {
        private CriteriaHandler handler;
        private Criteria criteria;

        [TestInitialize]
        public void TestInitializer()
        {
            handler = new CriteriaHandler();
            
        }
        


        [TestMethod]
        public void CriteriaHandler_SetSearchCriteria_ContainsString_AreObjectChangedCorrectly()
        {
            criteria = handler.CreateCriteria("Summary-Contians-Computer science", "Used to find usage of the word 'Computer science'");
            handler.SetSearchCriteria_ContainsString(criteria,"Summary","Computer Science");

            Criteria expectedState = new Criteria();
            CriteriaRelation expectedRelation = new CriteriaRelation();

            expectedRelation.Criteria = "Summary";
            expectedRelation.ComparionsonType = Criteria.CriteriaOperation.Contains;


            expectedState.Name = "Summary-Contians-Computer science";
            expectedState.CriteriaTarget = "Summary";
            expectedState.Description = "Used to find usage of the word 'Computer science'";
            


            Assert.AreEqual(Criteria.CriteriaOperation.Contains, criteria.Requirement.ComparionsonType);
            Assert.AreEqual("Computer Science", criteria.Requirement.Criteria);
            Assert.AreEqual("Computer Science", criteria.Requirement.Criteria);
            
            Assert.AreEqual("Summary-Contians-Computer science",criteria.Name);
            Assert.AreEqual("Used to find usage of the word 'Computer science'",criteria.Description);

            
        }


    }
}
