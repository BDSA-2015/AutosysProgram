// MainHandler.cs is a part of Autosys project in BDSA-2015. Created: 17, 11, 2015.
// Creators: Dennis Thinh Tan Nguyen, William Diedricsehn Marstrand, Thor Valentin Aakjær Olesen Nielsen, 
// Jacob Mullit Møiniche.

using System;
using System.Collections.Generic;
using ApplicationLogics.ExportManagement;
using ApplicationLogics.PaperManagement;
using ApplicationLogics.ProtocolManagement;
using ApplicationLogics.Repository;
using ApplicationLogics.StudyManagement;
using ApplicationLogics.UserManagement;

namespace ApplicationLogics.AutosysServer
{
    public class MainHandler
    {
        private ExportHandler _exportHandler;
        private PaperHandler _paperHandler;
        private ProtocolHandler _protocolHandler;
        private RequestHandler _requestHandler;
        private IRepository<IEntity> _Storage;
        private StudyHandler _studyHandler;

        private UserHandler _userHandler;

        public MainHandler()
        {
            throw new NotImplementedException();
        }

        private void HandleRequest()
        {
            throw new NotImplementedException(); //TODO Consider what parameters and how request are coming.
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

        public void GetTasks(int studyId, int userId, int count, Task.TaskType Type)
        {
            throw new NotImplementedException();
        } //TODO TASK TYPE IS AN ENUM?

        /// <summary>
        ///     reports the different stages in the study, and per stage, for each user the amount of tasks done, out of all the
        ///     known tasks to be done
        /// </summary>
        /// <param name="userId"></param>
        public List<System.Threading.Tasks.Task> GetStudyOverview(int userId)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        ///     deliver a finished task, including the resulting modified fields.
        ///     This should return whether or not the task was delivered
        ///     (e.g., can still be delivered) successfully).
        ///     This can be called several times for the same task,
        ///     in which case the latest value is used(if the task is still editable, which is decided by the server).
        /// </summary>
        /// <param name="studyId"></param>
        /// <param name="userId"></param>
        /// <param name="taskId"></param>
        /// <param name="modifiedField"></param>
        /// <returns></returns>
        public System.Threading.Tasks.Task DeliverTask(int studyId, int userId, int taskId, string modifiedField)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        ///     retrieves all task IDs of tasks which have already been delivered, and can still be edited.
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="studyID"></param>
        /// <returns></returns>
        public List<int> GetReviewableTaskIDs(int userID, int studyID)
        {
            throw new NotImplementedException();
        }

        public List<System.Threading.Tasks.Task> GetReviewableTasks(int userID, int studyID)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}