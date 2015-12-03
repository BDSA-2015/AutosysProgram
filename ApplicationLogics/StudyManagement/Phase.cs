// Phase.cs is a part of Autosys project in BDSA-2015. Created: 12, 11, 2015.
// Creators: Dennis Thinh Tan Nguyen, William Diedricsehn Marstrand, Thor Valentin Aakjær Olesen Nielsen, 
// Jacob Mullit Møiniche.

using System;
using System.Collections.Generic;
using ApplicationLogics.PaperManagement;
using ApplicationLogics.UserManagement;


namespace ApplicationLogics.StudyManagement
{

    /// <summary>
    /// This class details how task requests are handled and handed out. 
    /// Each phase is dependent on each other sequentially and is completed in a ﬁxed order. 
    /// </summary>
    public class Phase 
    {
        /// <summary>
        /// Still not implemented. This is a placeholder variable until we figur out how we get access to the papers from the database
      
        /// </summary>
        private List<Paper> reports { get;  set; }







        /// <summary>
        /// This list contains a list of Criterias which each report cannot contain
        /// </summary>
        public List< Criteria> ExclusionCriterias { get; protected set; }

        /// <summary>
        /// This list contains characteristics each report must contain 
        /// </summary>
        public List<Criteria> InclusionCriterias { get; protected set; }
        /// <summary>
        /// A list of pairs of Assignments and Users.
        /// </summary>
        public Dictionary<TaskRequest, List<User>> AssignedTask { get; protected set; }
        /// <summary>
        /// A dictionary over Roles. Each role holds a list of Users which fulfill 
        /// </summary>
        public Dictionary<User, Role> AssignedRole { get; protected set; } 

        /// <summary>
        /// Task which has not yet been assigned to a user yet.
        /// </summary>
        public List<TaskRequest> UnassignedTasks { get; protected set; }


        public void GetPapersWhichMatchCriterias()
        {
            BibTexFile file = new BibTexFile();
            throw new NotImplementedException();
        }
        /// <summary>
        /// Returns a booleans value which determin if this phase has reached its end.
        /// </summary>
        public bool PhaseFinished { get; protected set; }

        /// <summary>
        /// A list of Phases which this phase is dependent of. This is usually previus phases which must be completed before this phase can begin
        /// </summary>
        public List<Phase> DependentPhases { get; protected set; }


        /// <summary>
        /// Used to dertermin if a criteria has been assinged to this phase, this could either be in the InclusionList or ExclusionList
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public bool HasCriteria(Criteria criteria)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Add a exclusion criteria to this and only this pahse
        /// </summary>
        /// <param name="criteria"></param>
        public void AddExclusionCriteria(Criteria criteria)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Remove a exclussion criteria from this phase and only this phase
        /// </summary>
        /// <param name="criteriaName"></param>
        public void RemoveExclusionCriteria(string criteriaName)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Add inclusion criteria to this phase and only this phase
        /// </summary>
        /// <param name="criteria"></param>
        public void AddInclusionCriteria(Criteria criteria)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Remove Inclusion criteria to this phase and only this phase
        /// </summary>
        /// <param name="criteriaName"></param>
        public void RemoveInclusionCriteria(string criteriaName)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Add another user to the task
        /// </summary>
        /// <param name="user"></param>
        public void AddUserToTask(User user)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Remove the user from the task
        /// </summary>
        /// <param name="user"></param>
        public void RemoveUserFromTask(User user)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Add another task to not AssignedTask list 
        /// </summary>
        /// <param name="task"></param>
        public void AddTask(TaskRequest task)
        {
            throw new NotImplementedException();
        }

        public void RemoveTask(string taskName)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Update Task to a unassigned task or a task which is in progress
        /// </summary>
        /// <param name="task"></param>
        public void UpdateTask(TaskRequest task)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Return a list of tasks which has not been finished yet or started at all
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TaskRequest> GetUnfinishedTask()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Add phase dependency to this phase, this could be a phase which must be completed before this phase can be begun or finished
        /// </summary>
        /// <param name="phase"></param>
        public void AddDependency(Phase phase)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Remove a phase dependency from this and only this phase
        /// </summary>
        /// <param name="pahse"></param>
        public void RemoveDependency(Phase pahse)
        {
            throw new NotImplementedException();
        }
    }
}