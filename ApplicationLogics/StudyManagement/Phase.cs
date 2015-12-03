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
    /// A phase is a given set of review tasks. 
    /// Each phase is dependent on each other sequentially and is completed in a ﬁxed order.
    /// The class details how task requests are handled and handed out. 
    /// </summary>
    public class Phase 
    {
        /// <summary>
        /// Used to determine whether the criteria should include or exclude data.
        /// </summary>
        public enum CriteriaType
        {
            Inclusion,
            Exclusion
        }

        private List<Paper> Reports { get;  set; }

        /// <summary>
        /// This list contains Criteria, which each report cannot contain.
        /// </summary>
        public List<Criteria> ExclusionCriteria { get; set; }

        /// <summary>
        /// This list contains Criteria, which each report must contain.
        /// </summary>
        public List<Criteria> InclusionCriteria { get; set; }
        
        /// <summary>
        /// Used to give similar tasks to multiple users, e.g. a review task. 
        /// </summary>
        public Dictionary<TaskRequest, List<User>> AssignedTask { get; set; }
        
        /// <summary>
        /// A dictionary over Roles. Each role holds a list of Users with the assigned Role. 
        /// </summary>
        public Dictionary<Role, List<User>> AssignedRole { get; set; } 

        /// <summary>
        /// Task which has not yet been assigned.
        /// </summary>
        public List<TaskRequest> UnassignedTasks { get; set; }

        /// <summary>
        /// Returns a booleans value which determines if this phase has reached its end.
        /// </summary>
        public bool IsFinished { get; set; }

        /// <summary>
        /// A phase cannot begin prior to the completion of these Phases.
        /// </summary>
        public List<Phase> DependentPhases { get; set; }
    
        /// <summary>
        /// Used to dertermine if a criteria has been assinged in a phase.
        /// Either occurs in the InclusionList or ExclusionList
        /// </summary>
        /// <param name="criteria">
        /// The criteria looked for in a given phase.
        /// </param>
        /// <returns>
        /// Returns true if the criteria is used in a given phase.
        /// </returns>
        public bool HasCriteria(Criteria criteria)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Add an exclusion criteria to the phase.
        /// </summary>
        /// <param name="criteria"></param>
        public void AddCriteria(Criteria criteria, CriteriaType type)
        {
            if (type == CriteriaType.Exclusion) 
                throw new NotImplementedException(); // Create exclusion criteria

            else if (type == CriteriaType.Inclusion)
                throw new NotImplementedException(); // Create inclusion criteria 

            throw new NotImplementedException();
        }
        /// <summary>
        /// Remove a criteria from this phase. 
        /// </summary>
        /// <param name="criteriaName">
        /// Name of the criteria to delete. 
        /// </param>
        public void RemoveCriteria(string criteriaName)
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