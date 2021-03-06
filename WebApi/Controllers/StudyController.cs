﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ApplicationLogics.AutosysServer;
using Microsoft.Ajax.Utilities;
using WebApi.Models;

namespace WebApi.Controllers
{
    /// <summary>
    ///     Controller to access information about a study.
    /// </summary>
    [RoutePrefix("api/Study")]
    public class StudyController : ApiController
    {
        /*
        private IDisposable _facade;
         
        public UserController(IDisposable facade)
        {
            _facade = facade;
        }
        */

        private readonly MainHandler _facade;

        // Injecting a facade with IDisposable 
        public StudyController(MainHandler facade)
        {
            //_facade = facade;
            //var handler = new MainHandler();
            //handler.ExtractBibtexTags("").Item2.IfNotNull();
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Retrieve an overview of the specified study.
        /// </summary>
        /// <param name="id">The ID of the study for which to retrieve an overview.</param>
        [Route("{id}/Overview")]
        public StudyOverview GetOverview(int id)
        {
            // GET: api/Study/5/Overview
            //ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, "You must provide a valid User"));
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Get requested tasks for a specific user of a given study. By default, the first remaining (still to be completed)
        ///     task is retrieved.
        ///     Optionally, the amount of tasks to retrieve, and the type of tasks to retrieve are specified.
        /// </summary>
        /// <param name="id">The ID of the study to get tasks for.</param>
        /// <param name="userId">The ID of the user to get tasks for.</param>
        /// <param name="count">The amount of tasks to retrieve.</param>
        /// <param name="filter">Defines whether to get remaining tasks, delivered (but still editable) tasks, or completed tasks.</param>
        /// <param name="type">The type of tasks to retrieve.</param>
        [Route("{id}/Task")]
        public IEnumerable<TaskRequest> GetTasks(int id, int userId, int count = 1,
            TaskRequest.Filter filter = TaskRequest.Filter.Remaining, TaskRequest.Type type = TaskRequest.Type.Both)
        {
            // GET: api/Study/4/Task?userId=5&count=1&filter=Remaining&type=Review
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Get requested task IDs for a specific user of a given study. By default, delivered but still editable task IDs are
        ///     returned.
        ///     Optionally, the type of task IDs to retrieve are specified.
        /// </summary>
        /// <param name="id">The ID of the study to get tasks for.</param>
        /// <param name="userId">The ID of the user to get tasks for.</param>
        /// <param name="filter">Defines whether to get remaining tasks, delivered (but still editable) tasks, or completed tasks.</param>
        /// <param name="type">The type of tasks to retrieve.</param>
        [Route("{id}/TaskIDs")]
        public IEnumerable<int> GetTaskIDs(int id, int userId, TaskRequest.Filter filter = TaskRequest.Filter.Editable,
            TaskRequest.Type type = TaskRequest.Type.Both)
        {
            // GET: api/Study/4/TaskIDs?userId=5&filter=Editable
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Get a requested task with a specific ID.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="taskId"></param>
        /// <returns></returns>
        [Route("{id}/Task/{taskId}")]
        public TaskRequest GetTask(int id, int taskId)
        {
            // GET: api/Study/4/Task/5
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Deliver a finished task.
        ///     A task can be redelivered as long as it is editable.
        ///     Which tasks are editable can be found by calling <see cref="GetTaskIDs" /> with filter set to
        ///     <see cref="TaskRequest.Filter.Editable" />.
        ///     An error is returned in case the task can no longer be delivered.
        /// </summary>
        /// <param name="id">The ID of the study the task is part of.</param>
        /// <param name="taskId">The ID of the task.</param>
        /// <param name="task">The completed task.</param>
        [Route("{id}/Task/{taskId}")]
        public IHttpActionResult PostTask(int id, int taskId, [FromBody] TaskSubmission task)
        {
            // POST: api/Study/4/Task/5
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Returns the resource with the specified ID.
        ///     The resource is returned as StreamContent.
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
        ///     Clean up, allows to release resources per request when using underlying logic to access database.
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            // _facade.Dispose(); TODO make all interfaces down to db implement IDisposable 
            base.Dispose(disposing);
        }
    }
}