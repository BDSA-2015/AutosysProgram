// StudyManager.cs is a part of Autosys project in BDSA-2015. Created: 17, 11, 2015.
// Creators: Dennis Thinh Tan Nguyen, William Diedricsehn Marstrand, Thor Valentin Aakjær Olesen Nielsen, 
// Jacob Mullit Møiniche.

using System;
using System.Collections.Generic;

namespace ApplicationLogics.StudyManagement
{
    internal class StudyManager // TODO Why internal? 
    {
        public Phase CurrentPhase { get; protected set; }

        // Key is user id and values consist of the roles assigned to a user in current phase
        public Dictionary<int, Role> RolesInPhase { get; protected set; }

        // A map of tasks in the current phase, each task can have multiple users 
        public Dictionary<TaskRequest, List<int>> TasksInPhase { get; protected set; }


        public void AddRole(int userId, Role role = null)
        {
            throw new NotImplementedException();
        }

        public void RemoveRole(int userId, Role role = null)
        {
            throw new NotImplementedException();
        }

        public void RemoveAllRoles(int userId)
        {
            throw new NotImplementedException();
        }

        public void AddTask(TaskRequest task, List<int> participant = null)
        {
            throw new NotImplementedException();
        }

        public void RemoveMemberFromTask(int userId)
        {
            throw new NotImplementedException();
        }

        public void RemoveTask(TaskRequest task)
        {
            throw new NotImplementedException();
        }
    }
}