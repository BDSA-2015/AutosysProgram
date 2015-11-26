﻿// Phase.cs is a part of Autosys project in BDSA-2015. Created: 12, 11, 2015.
// Creators: Dennis Thinh Tan Nguyen, William Diedricsehn Marstrand, Thor Valentin Aakjær Olesen Nielsen, 
// Jacob Mullit Møiniche.

using System;
using System.Collections.Generic;
using ApplicationLogics.UserManagement;

namespace ApplicationLogics.StudyManagement
{
    public class Phase 
    {
        public List<Criteria> Criterias { get; protected set; }
        public Dictionary<TaskRequest, List<User>> AssignedTask { get; protected set; }

        public List<TaskRequest> UnAssignedTasks { get; protected set; }

        public bool PhaseFinished { get; protected set; }

        public List<Phase> DependentPhases { get; protected set; }

        public bool HasCriteria(Criteria criteria)
        {
            throw new NotImplementedException();
        }

        public void AddCriteria(Criteria criteria)
        {
            throw new NotImplementedException();
        }

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