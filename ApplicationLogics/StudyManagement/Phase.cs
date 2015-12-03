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
    /// A dependentPhase is a given set of review tasks. 
    /// Each dependentPhase is dependent on each other sequentially and is completed in a ﬁxed order.
    /// The class details how task requests are handled and handed out. 
    /// </summary>
    public class Phase 
    {
       
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
        /// Returns a booleans value which determines if this dependentPhase has reached its end.
        /// </summary>
        public bool IsFinished { get; set; }

        /// <summary>
        /// A dependentPhase cannot begin prior to the completion of these Phases.
        /// </summary>
        public List<Phase> DependentPhases { get; set; }
    
        /// <summary>
        /// Used to dertermine if a criteria has been assinged in a dependentPhase.
        /// Either occurs in the InclusionList or ExclusionList
        /// </summary>
        /// <param name="criteria">
        /// The criteria looked for in a given dependentPhase.
        /// </param>
        /// <returns>
        /// Returns true if the criteria is used in a given dependentPhase.
        /// </returns>
        public bool HasCriteria(Criteria criteria)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Add an exclusion criteria to the dependentPhase.
        /// </summary>
        /// <param name="criteria"></param>
        public void AddCriteria(Criteria criteria, Criteria.Type type)
        {
            if (type == Criteria.Type.Exclusion) 
                throw new NotImplementedException(); // Create exclusion criteria

            else if (type == Criteria.Type.Inclusion)
                throw new NotImplementedException(); // Create inclusion criteria 

            throw new NotImplementedException();
        }
        /// <summary>
        /// Remove a criteria from this dependentPhase. 
        /// </summary>
        /// <param name="criteriaName">
        /// Name of the criteria to delete. 
        /// </param>
        public void RemoveCriteria(string criteriaName)
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
        /// <summary>
        /// Add another task to unassigned tasks.  
        /// </summary>
        /// <param name="task">
        /// Task to add to list of unassigned tasks.
        /// </param>
        public void AddTask(TaskRequest task)
        {
            throw new NotImplementedException();
        }

        public void RemoveTask(string taskName)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Updates a task to an unassigned task or a task in progress.
        /// </summary>
        /// <param name="task"></param>
        public void UpdateTaskStatus(TaskRequest task)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Return a list of tasks, which has not been finished yet or started at all.
        /// </summary>
        /// <returns>
        /// List of unfinished tasks. 
        /// </returns>
        public IEnumerable<TaskRequest> GetUnfinishedTasks()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Add a dependentPhase that needs to be completed prior to a given dependentPhase has begun or finished. 
        /// </summary>
        /// <param name="dependentPhase">
        /// Phase to be completed prior to this phase. 
        /// </param>
        public void AddDependingPhase(Phase dependentPhase)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Remove a phase that this phase depends on itself. 
        /// </summary>
        /// <param name="dependentPhase">
        /// Phase to be completed prior to this phase. 
        /// </param>
        public void RemoveDependentPhase(Phase dependentPhase)
        {
            throw new NotImplementedException();
        }
    }
}