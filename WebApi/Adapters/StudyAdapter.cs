﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using SystematicStudyService.Models;
using ApplicationLo

namespace WebApi.Adapters
{
    public class StudyAdapter
    {
        
        public StudyOverview GetOverview(int id)
        {
            var database = new MainHandler();
            throw new NotImplementedException();
        }
        
        public IEnumerable<TaskRequest> GetTasks(int id, int userId, int count = 1, TaskRequest.Filter filter = TaskRequest.Filter.Remaining, TaskRequest.Type type = TaskRequest.Type.Both)
        {
            // GET: api/Study/4/Task?userId=5&count=1&filter=Remaining&type=Review
            throw new NotImplementedException();
        }

        
        public IEnumerable<int> GetTaskIDs(int id, int userId, TaskRequest.Filter filter = TaskRequest.Filter.Editable, TaskRequest.Type type = TaskRequest.Type.Both)
        {
            // GET: api/Study/4/TaskIDs?userId=5&filter=Editable
            throw new NotImplementedException();
        }

        
        public TaskRequest GetTask(int id, int taskId)
        {
            // GET: api/Study/4/Task/5
            throw new NotImplementedException();
        }
        
        public IHttpActionResult PostTask(int id, int taskId, [FromBody]TaskSubmission task)
        {
            // POST: api/Study/4/Task/5
            throw new NotImplementedException();
        }
        
        public IHttpActionResult GetResource(int id, int resourceId)
        {
            // GET: api/Study/4/Resource/5
            throw new NotImplementedException();
        }
    }
}