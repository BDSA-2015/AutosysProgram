using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using SystematicStudyService.Models;
using WebApi.Controllers;
using WebApi.Models;
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
                foreach(KeyValuePair<DatabaseUser,List<DatabaseTask>> usersTasks in phase.Tasks) //Foreach user in the phase
                {
                    
                    foreach(DatabaseTask task in usersTasks.Value)//Account for the users completed and incomplete tasks
                    {
                        if (DatabaseTask.Filter.Done == task.TaskType)
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
           _facade
        }

        public Models.TaskRequest GetTask(int id, int taskId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<int> GetTaskIDs(int id, int userId, Models.TaskRequest.Filter filter = Models.TaskRequest.Filter.Editable, Models.TaskRequest.Type type = Models.TaskRequest.Type.Both)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Models.TaskRequest> GetTasks(int id, int userId, int count = 1, Models.TaskRequest.Filter filter = Models.TaskRequest.Filter.Remaining, Models.TaskRequest.Type type = Models.TaskRequest.Type.Both)
        {
            throw new NotImplementedException();
        }

        public IHttpActionResult PostTask(int id, int taskId, [FromBody] TaskSubmission task)
        {
            throw new NotImplementedException();
        }
    }
}