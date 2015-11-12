﻿using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLogics.StudyManagement
{
    public class Phase
    {
        public List<Criteria> Criterias { get; protected set; }
        public Dictionary<User,Task> AssignedTask { get; protected set; }

        public List<Task> UnAssignedTasks { get; protected set; }

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


        public void AddTask(Task task)
        {
            throw new NotImplementedException();
        }

        public void RemoveTask(string taskName)
        {
            throw new NotImplementedException();
        }

        public void UpdateTask(Task task)
        {
            throw new NotImplementedException();
        }

        

        public IEnumerable<Task> GetUnfinishedTask()
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
