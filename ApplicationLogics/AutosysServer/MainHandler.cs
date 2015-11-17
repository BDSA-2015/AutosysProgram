using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Threading.Tasks;
using ApplicationLogics.Repository;
using ApplicationLogics.UserManagement;
using Microsoft.SqlServer.Server;

namespace ApplicationLogics.AutosysServer
{

    public class MainHandler
    {

        //private UserHandler _userHandler;
        //private ProtocolHandler _protocolHandler;
        //private PaperHandler _paperHandler;
        //private ExportHandler _exportHandler;
        //private StudyHandler _studyHandler;
        //private IStorage<IEntity> _Storage;
        //private RequestHandler _requestHandler;

        public MainHandler()
        {
            throw new NotImplementedException();
        }

        private void HandleRequest()
        {
            throw new NotImplementedException();//TODO Consider what parameters and how request are coming.
        }

        private bool ValidateUser(int userId)
        {
            throw new NotImplementedException();
        }

        //TODO CONSIDER REFACTOR THESE METHODS INTO NEW CLASSES: EG CONTROLLERS (METHODS GIVEN BY STEVEN)
        #region Code given by steven. Just extend the folding to see them.
        public void CreateTeam(string teamName)
        {
            throw new NotImplementedException();
        }

        public void AddUserToTeam(int userId, int teamId)
        {
            throw new NotImplementedException();
        }

        public Team GetTeam(int teamId)
        {
            throw new NotImplementedException();
        }

        public void CreateUser(string name)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(int userId)
        {
            throw new NotImplementedException();
        }


        public List<Study> GetStudies(int userId)
        {
            throw new NotImplementedException();
        }

        public void GetTasks(int studyId, int userId, int count, StudyManagement.Task.TaskType Type)
        {
            throw new NotImplementedException();
        } //TODO TASK TYPE IS AN ENUM?

        /// <summary>
        /// reports the different stages in the study, and per stage, for each user the amount of tasks done, out of all the known tasks to be done
        /// </summary>
        /// <param name="userId"></param>
        public List<Task> GetStudyOverview(int userId)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// deliver a finished task, including the resulting modified fields. 
        /// This should return whether or not the task was delivered
        /// (e.g., can still be delivered) successfully).
        /// This can be called several times for the same task, 
        /// in which case the latest value is used(if the task is still editable, which is decided by the server).
        /// </summary>
        /// <param name="studyId"></param>
        /// <param name="userId"></param>
        /// <param name="taskId"></param>
        /// <param name="modifiedField"></param>
        /// <returns></returns>
        public Task DeliverTask(int studyId, int userId, int taskId, string modifiedField)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// retrieves a specified resource (e.g., PDF file).
        /// </summary>
        /// <param name="resourceId"></param>
        /// <returns></returns>
        public Resource GetResource(int resourceId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// retrieves all task IDs of tasks which have already been delivered, and can still be edited.
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="studyID"></param>
        /// <returns></returns>
        public List<int> GetReviewableTaskIDs(int userID, int studyID)
        {
            throw new NotImplementedException();
        }

        public List<Task> GetReviewableTasks(int userID, int studyID)
        {
            throw new NotImplementedException();
        } 
        #endregion

    }
}

