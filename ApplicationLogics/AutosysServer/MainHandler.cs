// MainHandler.cs is a part of Autosys project in BDSA-2015. Created: 17, 11, 2015.
// Creators: Dennis Thinh Tan Nguyen, William Diedricsehn Marstrand, Thor Valentin Aakjær Olesen Nielsen, 
// Jacob Mullit Møiniche.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationLogics.ExportManagement;
using ApplicationLogics.PaperManagement;
using ApplicationLogics.ProtocolManagement;
using ApplicationLogics.StudyManagement;
using ApplicationLogics.UserManagement;
using ApplicationLogics.UserManagement.Entities;

namespace ApplicationLogics.AutosysServer
{
    public class MainHandler
    {
        //private IFasade<> _Storage; TODO WHAT TO GIVE MAINHANDLER AS OBJECT? ==> Check Dependency Injection Container that has been created.
        private ExportHandler _exportHandler;
        private FileHandler _fileHandler;
        private ProtocolHandler _protocolHandler;
        private StudyHandler _studyHandler;
        private UserHandler _userHandler;

        public MainHandler()
        {
            var injector = new AdapterInjectionContainer();
            InitializeHandlers(injector);
        }

        /// <summary>
        ///     Initialize Facades buy utilzing a dependency injection container
        /// </summary>
        /// <param name="injector"></param>
        private void InitializeHandlers(AdapterInjectionContainer injector)
        {
            _userHandler = new UserHandler(injector.GetUserAdapter());
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

        public void GetTasks(int studyId, int userId, int count, TaskRequest type)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Reports the different stages in a study and shows completed tasks per stage for each user.
        /// </summary>
        /// <param name="userId">
        ///     If of user related to a given study.
        /// </param>
        public List<Task> GetStudyOverview(int userId)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        ///     Deliver a finished task including a result with modified fields.
        ///     This should return whether or not the task was delivered (e.g., can still be delivered) successfully).
        ///     Can be called several times for the same task in which case the latest value is used (if the task is still
        ///     editable, which is decided by the server).
        /// </summary>
        /// <param name="studyId">
        ///     Study holding task.
        /// </param>
        /// <param name="userId">
        ///     User assigned to task.
        /// </param>
        /// <param name="taskId">
        ///     Id of the task.
        /// </param>
        /// <param name="modifiedField">
        ///     Datafields that have been changed in the task.
        /// </param>
        /// <returns>
        ///     A task request with results.
        /// </returns>
        public TaskRequest DeliverTask(int studyId, int userId, int taskId, string modifiedField)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        ///     Retrieves all ids of task requests which have already been delivered and can still be edited.
        /// </summary>
        /// <param name="userId">
        /// </param>
        /// <param name="studyId"></param>
        /// <returns></returns>
        public List<int> GetReviewableTaskIDs(int userId, int studyId)
        {
            throw new NotImplementedException();
        }

        public List<Task> GetReviewableTasks(int userId, int studyId)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}