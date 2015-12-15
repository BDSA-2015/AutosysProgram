// Phase.cs is a part of Autosys project in BDSA-2015. Created: 12, 11, 2015.
// Creators: Dennis Thinh Tan Nguyen, William Diedricsehn Marstrand, Thor Valentin Aakjær Olesen Nielsen, 
// Jacob Mullit Møiniche.

using System;
using System.Collections.Generic;
using ApplicationLogics.PaperManagement;
using ApplicationLogics.UserManagement.Entities;

namespace ApplicationLogics.StudyManagement
{
    /// <summary>
    ///     A Phase is a given set of tasks.
    ///     Each Phase is dependent on each other sequentially and is completed in a ﬁxed order.
    ///     The class details how task requests are handled and handed out.
    /// </summary>
    public class Phase 
    {
        public string Name { get; set; }
     
        public string Description { get; set; }

        /// <summary>
        ///     Used to give similar tasks to multiple users, e.g. a review task.
        /// </summary>
        public Dictionary<User, List<TaskRequest>> Tasks { get; set; }
        
        /// <summary>
        ///     A dictionary over Roles. Each role holds a list of Users with the assigned Role.
        /// </summary>
        public Dictionary<Role, List<User>> AssignedRole { get; set; } 

        /// <summary>
        ///     The data fields which needs to be filled out for the phase to be completed
        /// </summary>
        public IReadOnlyCollection<DataField> RequestedDataFields { get; set; } 

        /// <summary>
        ///     Returns a Boolean value which determines if this Phase has reached its end.
        /// </summary>
        public bool IsFinished { get; set; }
    
        /// <summary>
        ///     Used to determine if a criteria has been assigned in a Phase.
        ///     Either occurs in the InclusionList or ExclusionList
        /// </summary>
        /// <param name="criteria">
        ///     The criteria looked for in a given Phase.
        /// </param>
        /// <returns>
        ///     Returns true if the requested criteria is used in a given Phase.
        /// </returns>
        public bool HasCriteria(Criteria criteria)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///   Add an exclusion criteria to the Phase
        /// </summary>
        /// <param name="criteria">
        ///     The given criteria to be add to the phase
        /// </param>
        public void AddCriteria(Criteria criteria)
        {
            if (criteria.CriteriaType == Criteria.Type.Exclusion) 
                throw new NotImplementedException(); // Create exclusion criteria

            if (criteria.CriteriaType == Criteria.Type.Inclusion)
                throw new NotImplementedException(); // Create inclusion criteria 

            throw new NotImplementedException();
        }

        /// <summary>
        ///     Remove a criteria from this Phase.
        /// </summary>
        /// <param name="criteriaName">
        ///     Name of the criteria to delete.
        /// </param>
        public void RemoveCriteria(string criteriaName)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Add another task to unassigned tasks.
        /// </summary>
        /// <param name="task">
        ///     Task to add to list of unassigned tasks.
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
        ///     Updates a task to an unassigned task or a task in progress.
        /// </summary>
        /// <param name="task"></param>
        public void UpdateTaskStatus(TaskRequest task)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Return a list of tasks, which has not been finished yet or started at all.
        /// </summary>
        /// <returns>
        ///     List of unfinished tasks.
        /// </returns>
        public IEnumerable<TaskRequest> GetUnfinishedTasks()
        {
            throw new NotImplementedException();
        }
    }
}