using System;
using System.Collections.Generic;
using System.Web.Http;

using ApplicationLogics.AutosysServer;
using WebApi.Models;

using DConflictingData = ApplicationLogics.StudyManagement.ConflictingData;
using AConflictingData = WebApi.Models.ConflictingData;
using DCriteria = ApplicationLogics.StudyManagement.Criteria;
using DDataField = ApplicationLogics.StudyManagement.DataField;
using ADataField = WebApi.Models.DataField;
using AStage = WebApi.Models.StageOverview;
using DStage = ApplicationLogics.StudyManagement.Phase;
using DTask = ApplicationLogics.StudyManagement.TaskRequest;
using ATask = WebApi.Models.TaskRequest;
using DUser = ApplicationLogics.UserManagement.Entities.User;
using DTeam = ApplicationLogics.UserManagement.Entities.Team;
using AUser = WebApi.Models.User;
using ATeam = WebApi.Models.Team;
using AStudy = WebApi.Models.StudyOverview;
using DStudy = ApplicationLogics.StudyManagement.Study;
using ATaskFilter = WebApi.Models.TaskRequest.Filter;
using ATaskType = WebApi.Models.TaskRequest.Type;
using DTaskType = ApplicationLogics.StudyManagement.TaskRequest.Type;


using System.Net.Http;
using AutoMapper;

namespace WebApi.Controllers
{
    /// <summary>
    /// Controller to access information about a study.
    /// </summary>
    [RoutePrefix("api/Study")]
    public class StudyController : ApiController, IStudyControllerAdapter
    {


        private readonly MainHandler _facade;





        // Injecting a facade with IDisposable 
        public StudyController()
        {
            _facade = new MainHandler();
        }

        /// <summary>
        /// Retrieve an overview of the specified study.
        /// </summary>
        /// <param name="id">The ID of the study for which to retrieve an overview.</param>
        [Route("{id}/Overview")]
        public StudyOverview GetOverview(int id)
        {
            // GET: api/Study/5/Overview
            Tuple<DStage, HttpResponseMessage> databaseResponse = _facade.GetStudyOverview(int);
            if (databaseResponse.Item2.IsSuccessStatusCode)
            {
                return Mapper.Map<AStudy>(databaseResponse.Item1);
            }

            else return null;
        }

        /// <summary>
        /// Get requested tasks for a specific user of a given study. By default, the first remaining (still to be completed) task is retrieved.
        /// Optionally, the amount of tasks to retrieve, and the type of tasks to retrieve are specified.
        /// </summary>
        /// <param name="id">The ID of the study to get tasks for.</param>
        /// <param name="userId">The ID of the user to get tasks for.</param>
        /// <param name="count">The amount of tasks to retrieve.</param>
        /// <param name="filter">Defines whether to get remaining tasks, delivered (but still editable) tasks, or completed tasks.</param>
        /// <param name="type">The type of tasks to retrieve.</param>
        [Route("{id}/Task")]
        public IEnumerable<TaskRequest> GetTasks(int id, int userId, int count = 1, TaskRequest.Filter filter = TaskRequest.Filter.Remaining, TaskRequest.Type type = TaskRequest.Type.Both)
        {
            // GET: api/Study/4/Task?userId=5&count=1&filter=Remaining&type=Review

            Tuple<DUser, HttpResponseMessage> databaseResponse_User = _facade.GetUser(userId);
            //If User exist, then continue
            if (databaseResponse_User.Item2.IsSuccessStatusCode)
            {
                Tuple<DStudy, HttpResponseMessage> databaseResponse_study = _facade.GetStudy();
                //If Study Exist, then continue
                if (databaseResponse_study.Item2.IsSuccessStatusCode)
                {
                    //For each Stage
                    foreach (DStage stage in databaseResponse_study.Item1.Phases)
                    {
                        var usersTasks = stage.Tasks[databaseResponse_User.Item1];
                        //For each Task in the Stage, Continue as long as there are more tasks and the users specified maximum of returned Task haven't been reached
                        for (int i = 0; i < usersTasks.Count && count == 0; i++)
                        {
                            var currentTask = usersTasks[i];
                            if (TaskMatchesFilter(currentTask, type )&& TaskMatchesProgress(currentTask, filter))
                                yield return Mapper.Map<ATask>(currentTask);
                            count--;
                        }
                    }

                }
                yield break; //Break if the study does not exist
            }

            yield break; //Break if the user does not exist
        }
        /// <summary>
        /// Compares a DTask and a ATask. If they share the same value for AFilter, then return true
        /// </summary>
        /// <param name="task"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        private bool TaskMatchesFilter(DTask task, ATaskType type)
        {
            if (task.TaskType == DTaskType.Both && type == ATaskType.Both)
                return true;
            else if (task.TaskType == DTaskType.Conflict && type == ATaskType.Conflict)
                return true;
            else if (task.TaskType == DTaskType.Review && type == ATaskType.Review)
                return true;
            else return false;
        }
        /// <summary>
        /// Compares a DTask to a ATask. If they share the same level of progress, then return true
        /// </summary>
        /// <param name="task"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        private bool TaskMatchesProgress(DTask task, ATaskFilter filter)
        {
            if (filter == ATaskFilter.Done && task.IsFinished)
                return true;
            else if (filter == ATaskFilter.Editable && task.IsFinished || task.ConflictingData.Length > 0)//If any tasks still conflict and the task is not finished, then it is still editable
                return true;
            else if (filter == ATaskFilter.Remaining && !task.IsFinished) //If the task isn't finished, then it is not done
                return true;
            else return false;
        }

        private bool TaskMatches
        /// <summary>
        /// Get requested task IDs for a specific user of a given study. By default, delivered but still editable task IDs are returned.
        /// Optionally, the type of task IDs to retrieve are specified.
        /// </summary>
        /// <param name="id">The ID of the study to get tasks for.</param>
        /// <param name="userId">The ID of the user to get tasks for.</param>
        /// <param name="filter">Defines whether to get remaining tasks, delivered (but still editable) tasks, or completed tasks.</param>
        /// <param name="type">The type of tasks to retrieve.</param>
        [Route("{id}/TaskIDs")]
        public IEnumerable<int> GetTaskIDs(int id, int userId, TaskRequest.Filter filter = TaskRequest.Filter.Editable, TaskRequest.Type type = TaskRequest.Type.Both)
        {
            // GET: api/Study/4/Task?userId=5&count=1&filter=Remaining&type=Review

            Tuple<DUser, HttpResponseMessage> databaseResponse_User = _facade.GetUser(userId);
            //If User exist, then continue
            if (databaseResponse_User.Item2.IsSuccessStatusCode)
            {
                Tuple<DStudy, HttpResponseMessage> databaseResponse_study = _facade.GetStudy();
                //If Study Exist, then continue
                if (databaseResponse_study.Item2.IsSuccessStatusCode)
                {
                    //For each Stage
                    foreach (DStage stage in databaseResponse_study.Item1.Phases)
                    {
                        var usersTasks = stage.Tasks[databaseResponse_User.Item1];
                        //For each Task in the Stage, Continue as long as there are more tasks and yield the to the test 
                        for (int i = 0; i < usersTasks.Count;  i++)
                        {
                            var currentTask = usersTasks[i];
                            if (TaskMatchesFilter(currentTask, type) && TaskMatchesProgress(currentTask, filter))
                                yield return currentTask.Id;
                            
                        }
                    }

                }
                yield break; //Break if the study does not exist
            }

            yield break; //Break if the user does not exist
        }

        /// <summary>
        /// Get a requested task with a specific ID.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="taskId"></param>
        /// <returns></returns>
        [Route("{id}/Task/{taskId}")]
        public TaskRequest GetTask(int id, int taskId)
        {
            // GET: api/Study/4/Task/5
            Tuple<DTask, HttpResponseMessage> databaseResponse = _facade.GetTask(id);
            if (databaseResponse.Item2.IsSuccessStatusCode)
            {
                return Mapper.Map<ATask>(databaseResponse.Item1);
            }
            else return null;
        }

        /// <summary>
        /// Deliver a finished task.
        /// A task can be redelivered as long as it is editable.
        /// Which tasks are editable can be found by calling <see cref="GetTaskIDs" /> with filter set to <see cref="TaskRequest.Filter.Editable" />.
        /// An error is returned in case the task can no longer be delivered.
        /// </summary>
        /// <param name="id">The ID of the study the task is part of.</param>
        /// <param name="taskId">The ID of the task.</param>
        /// <param name="task">The completed task.</param>
        [Route("{id}/Task/{taskId}")]
        public IHttpActionResult PostTask(int id, int taskId, [FromBody]TaskSubmission task)
        {
            // POST: api/Study/4/Task/5
            
            Tuple<DStudy, HttpResponseMessage> databaseResponse = _facade.GetStudy(id);
            if(databaseResponse.Item2.IsSuccessStatusCode)
            {
             
            }
            return ResponseMessage(Request.CreateResponse(databaseResponse.Item2.StatusCode, databaseResponse.Item2.ReasonPhrase));
            
        }

        /// <summary>
        /// Returns the resource with the specified ID.
        /// The resource is returned as StreamContent.
        /// </summary>
        /// <param name="id">The ID of the study this resource is part of.</param>
        /// <param name="resourceId">The ID of the requested resource.</param>
        [Route("{id}/Resource/{resourceId}")]
        public IHttpActionResult GetResource(int id, int resourceId)
        {
            // GET: api/Study/4/Resource/5
            throw new NotImplementedException();
        }

        /// <summary>
        /// Clean up, allows to release resources per request when using underlying logic to access database. 
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            // _facade.Dispose(); TODO make all interfaces down to db implement IDisposable 
            base.Dispose(disposing);
        }
    }
}
