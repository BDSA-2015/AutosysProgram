using System;
using System.Collections.Generic;

namespace ApplicationLogics.StudyManagement
{
    class StudyManager
    {
        public Phase currentPhase { get; protected set; }

        //The key is the user's ID and the values are his roles in the current phase
        public  Dictionary<int, Role> RolesInPhase { get; protected set; }

        //A map of tasks in the current phase, each task can have multiple 
        public Dictionary<Task, List<int>> TasksInPhase { get; protected set; }


        public void AddRole(int UserId, Role role = null)
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

        public void AddTask(Task task, List<int> participant = null)
        {
            throw new NotImplementedException();
        }

        public void RemoveMemberFromTask(int UserId)
        {
            throw new NotImplementedException();
        }

        public void RemoveTask(Task task)
        {
            throw new NotImplementedException();
        }

    }
}
