// Phase.cs is a part of Autosys project in BDSA-2015. Created: 12, 11, 2015.
// Creators: Dennis Thinh Tan Nguyen, William Diedricsehn Marstrand, Thor Valentin Aakjær Olesen Nielsen, 
// Jacob Mullit Møiniche.

using System;
using System.Collections.Generic;
using ApplicationLogics.PaperManagement;
using ApplicationLogics.Repository;
using ApplicationLogics.UserManagement;
using BibliographyParser;
using ApplicationLogics.StudyManagement.BibTex;

namespace ApplicationLogics.StudyManagement
{
    public class Phase : IEntity
    {
        /// <summary>
        /// This is a magical list which contains all Bibtexfiles stored in the system. The reason we haven't extracted them more elegantly from the database is becasue we intend for furture implementation to be able to search with more advanced filters which are not provided by a simple database.
        /// It should also be noted, I have no #!#&@ idea how to get this list right now, but I'll pray for a miracle.
        /// </summary>
        private List<Item> reports { get;  set; } 





        

        /// <summary>
        /// This list contains characteristics each report canot contain 
        /// </summary>
        public List< Criteria> ExclusionCriterias { get; protected set; }

        /// <summary>
        /// This list contains characteristics each report must contain 
        /// </summary>
        public List<Criteria> InclusionCriterias { get; protected set; }
        public Dictionary<TaskRequest, List<User>> AssignedTask { get; protected set; }

        public List<TaskRequest> UnAssignedTasks { get; protected set; }


        public void GetPapersWhichMatchCriterias()
        {
            BibTexFile file = new BibTexFile();
            file.
        }

        public bool PhaseFinished { get; protected set; }

        public List<Phase> DependentPhases { get; protected set; }
        public int Id { get; set; }



        public bool HasCriteria(Criteria criteria)
        {
            throw new NotImplementedException();
        }

        public void AddExclusionCriteria(Criteria criteria)
        {
            throw new NotImplementedException();
        }

        public void RemoveExclusionCriteria(string criteriaName)
        {
            throw new NotImplementedException();
        }

        public void AddInclusionCriteria(Criteria criteria)
        {
            throw new NotImplementedException();
        }

        public void RemoveInclusionCriteria(string criteriaName)
        {
            throw new NotImplementedException();
        }

        public void AddUserToTask(User user)
        {
            throw new NotImplementedException();
        }

        public void RemoveUserFromTask(User user)
        {
            throw new NotImplementedException();
        }

        public void AddTask(TaskRequest task)
        {
            throw new NotImplementedException();
        }

        public void RemoveTask(string taskName)
        {
            throw new NotImplementedException();
        }

        public void UpdateTask(TaskRequest task)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TaskRequest> GetUnfinishedTask()
        {
            throw new NotImplementedException();
        }

        public void AddDependency(Phase phase)
        {
            throw new NotImplementedException();
        }

        public void RemoveDependency(Phase pahse)
        {
        }
    }
}