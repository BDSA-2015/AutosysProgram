using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using SystematicStudyService.Models;
using WebApi.Controllers;
using WebApi.Models;
using TaskRequest = WebApi.Models.TaskRequest;
using ApplicationLogics.AutosysServer;

using ApplicationLogics.StudyManagement;
using DatabaseTask = ApplicationLogics.StudyManagement.TaskRequest;
using DatabaseUser = ApplicationLogics.UserManagement.Entities.User;
using System.Collections.Concurrent;

namespace WebApi.Adapter
{
    public class StudyControllerAdaptorcs : IStudyControllerAdapter
    {

        private readonly MainHandler _facade;

        public StudyControllerAdaptorcs(MainHandler facade)
        {
            _facade = facade;
        }


        public StudyOverview GetOverview(int id)
        {
            var study =_facade.GetStudy(id);
            var studyOverview = new StudyOverview(); // The intended return value of this function

            var stageOverview = new StageOverview(); //Temp value used to avoid creating variables in a loop
            var stages = new List<StageOverview>(); // Storing adopted stages
            var completedTasks = new ConcurrentDictionary<int, int>(); // A map of users completed tasks, spanding all stages
            var incompleteTasksTasks = new ConcurrentDictionary<int, int>(); //A map of users incomplete tasks, spanding all stages


            foreach (Phase phase in study.Phases)//For each phase
            {
                foreach(KeyValuePair<DatabaseUser,List<DatabaseTask>> usersTasks in phase.Tasks) //Foreach user in the phase // In the future, the foreach could be replaced with just examing the latest phase
                {
                    
                    foreach(DatabaseTask task in usersTasks.Value)//Account for the users completed and incomplete tasks
                    {
                        if (DatabaseTask.Filter.Done == task.Progress)
                            completedTasks.AddOrUpdate(usersTasks.Key.Id, 1, (userId, finishedWork) => finishedWork + 1);
                        else
                            incompleteTasksTasks.AddOrUpdate(usersTasks.Key.Id, 1, (userId, unfinishedWork) => unfinishedWork + 1);
                    }
                }
                //Convert enriched dictionaries back into a normal dictioaries
                stageOverview.CompletedTasks = completedTasks.ToDictionary(entry=> entry.Key, entry => entry.Value); 
                stageOverview.IncompleteTasks = incompleteTasksTasks.ToDictionary(entry => entry.Key, entry => entry.Value); ;
                stageOverview.Name = phase.Name;
                stages.Add(stageOverview);

            }

            studyOverview.Name = study.Name;
            study.UserId.CopyTo(studyOverview.UserIds);
            stages.CopyTo(studyOverview.Stages);

            return studyOverview;
        }

        public IHttpActionResult GetResource(int id, int resourceId)
        {
            throw new NotImplementedException();
        }

        public Models.TaskRequest GetTask(int id, int taskId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<int> GetTaskIDs(int id, int userId, Models.TaskRequest.Filter filter = Models.TaskRequest.Filter.Editable, Models.TaskRequest.Type type = Models.TaskRequest.Type.Both)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Models.TaskRequest> GetTasks(int id, int userId, int count = 1, Models.TaskRequest.Filter filter = TaskRequest.Filter.Remaining, TaskRequest.Type type = TaskRequest.Type.Both)
        {
            throw new NotImplementedException();
            

            var taskRequestFilter = TaskRequestFilterTranslator(filter);
            var taskRequestType = TaskRequestTypeTranslator(type);

            var DatabaseTasks =  _facade.GetTasks(id, userId, count, taskRequestFilter, taskRequestType);
            var tasks = new List<TaskRequest>();
            TaskRequest newTask; 
            foreach (DatabaseTask task in DatabaseTasks)
            {
                newTask = new TaskRequest();
                newTask.ConflictingData = task.ConflictingData;
                newTask.Id = null;
                newTask.IsDeliverable = null;
                newTask.RequestedFields = null;
                newTask.TaskType = null;
                newTask.VisibleFields  = null
                
            }



        }

        public IHttpActionResult PostTask(int id, int taskId, [FromBody] TaskSubmission task)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// /// Converts APi representation of the enity TaskRequest.Filter to the ApplicationLogics Representation of the entity
        /// </summary>
        /// <param name="filterType"></param>
        /// <returns></returns>
        private DatabaseTask.Filter TaskRequestFilterTranslator(TaskRequest.Filter filterType)
        {

            if (filterType == TaskRequest.Filter.Done)
                return DatabaseTask.Filter.Done;
            else if (filterType == TaskRequest.Filter.Editable)
                return DatabaseTask.Filter.Editable;
            else if (filterType == TaskRequest.Filter.Remaining)
                return DatabaseTask.Filter.Remaining;
            else throw new NotImplementedException();//This code does not reflect all of the possible Filters. Extend this method if this statement is reached
        }

        /// <summary>
        /// Converts APi representation of the enity TaskRequest.Type to the ApplicationLogics Representation of the entity
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private DatabaseTask.Type TaskRequestTypeTranslator(TaskRequest.Type type)
        {
            throw new NotImplementedException();

            if (type == TaskRequest.Type.Both)
                return DatabaseTask.Type.Both;
            else if (type == TaskRequest.Type.Conflict)
                return DatabaseTask.Type.HandleConflictingDatafields;
            else if (type == TaskRequest.Type.Review)
                return DatabaseTask.Type.FillOutDataFields;
            else throw new NotImplementedException(); //This code does not reflect all of the possible Types. Extend this method if this statement is reached
        }

        private TaskRequest TaskRequest
    }
}