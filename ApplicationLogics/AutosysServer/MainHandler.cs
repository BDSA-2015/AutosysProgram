// MainHandler.cs is a part of Autosys project in BDSA-2015. Created: 17, 11, 2015.
// Creators: Dennis Thinh Tan Nguyen, William Diedricsehn Marstrand, Thor Valentin Aakjær Olesen Nielsen, 
// Jacob Mullit Møiniche.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using ApplicationLogics.ExportManagement;
using ApplicationLogics.PaperManagement;
using ApplicationLogics.StudyManagement;
using ApplicationLogics.UserManagement;
using ApplicationLogics.UserManagement.Entities;
using BibtexParser = ApplicationLogics.PaperManagement.Bibtex.BibtexParser;


namespace ApplicationLogics.AutosysServer
{
    public class MainHandler
    {
        private TaskHandler _taskHandler;
        private ExportHandler _exportHandler;
        private FileHandler _fileHandler;
        private StudyHandler _studyHandler;
        private UserHandler _userHandler;
        private TeamHandler _teamHandler;

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

            _studyHandler = new StudyHandler(injector.GetStudyAdapter());
            _fileHandler = new FileHandler(new BibtexParser());
            _exportHandler = new ExportHandler();
            _teamHandler = new TeamHandler(injector.GetTeamAdapter());
            _taskHandler = new TaskHandler(injector.GetTaskAdapter());
        }

        #region User Operation

        /// <summary>
        ///     Retrieves a user with the requested id from the database if any exists
        /// </summary>
        /// <param name="userId">
        ///     Id of the requested user
        /// </param>
        /// <returns>
        ///     A Tuple containing a user with an id property matching the given id or null if no match were found
        ///     and a response message matching the result of the request
        /// </returns>
        public Tuple<User, HttpResponseMessage> GetUser(int userId)
        {
            var user = _userHandler.Read(userId).Result;
            return user.Equals(null) ?
                new Tuple<User, HttpResponseMessage>(user, CreateResponse(HttpStatusCode.NoContent)) :
                new Tuple<User, HttpResponseMessage>(user, CreateResponse(HttpStatusCode.OK));
        }

        /// <summary>
        ///     Retrieves all Users with a Name property matching the given string
        /// </summary>
        /// <param name="name">
        ///     The given string to match user names against
        /// </param>
        /// <returns>
        ///     A Tuple containing a collection of all users with a name property matching the given string or null if no matches were found
        ///     and a response message matching the result of the request
        /// </returns>
        public Tuple<IEnumerable<User>, HttpResponseMessage> GetUsers(string name)
        {
            var query = from user in _userHandler.GetAll()
                        where user.Name.Equals(name)
                        select user;

            return !query.Any() ?
                new Tuple<IEnumerable<User>, HttpResponseMessage>(null, CreateResponse(HttpStatusCode.NoContent)) :
                new Tuple<IEnumerable<User>, HttpResponseMessage>(query, CreateResponse(HttpStatusCode.OK));
        }

        /// <summary>
        ///     Method for creating a user with a state matching the given User object's
        /// </summary>
        /// <param name="user">
        ///     The given user to be created in the database
        /// </param>
        /// <returns>
        ///     A response message indicating the result of the request
        /// </returns>
        public HttpResponseMessage CreateUser(User user)
        {
            try
            {
                var userId = _userHandler.Create(user).Result;

                return CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception exception)
            {
                return CreateResponse(HttpStatusCode.BadRequest, exception.Message);
            }

        }

        /// <summary>
        ///     Tries to update the state of a user in the database with the given id to the state of the given user object.
        ///     The update returns true if the update is complete, false otherwise
        /// </summary>
        /// <param name="id">
        ///     The id of the user requested for update
        /// </param>
        /// <param name="user">
        ///     The user object with the state which the chosen User should be updated to
        /// </param>
        /// <returns>
        ///     A response message indicating the result of the request
        /// </returns>
        public HttpResponseMessage UpdateUser(int id, User user)
        {
            try
            {
                var result = _userHandler.Update(id, user).Result;

                return CreateResponse(result ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            }
            catch (Exception exception)
            {

                return CreateResponse(HttpStatusCode.BadRequest, exception.Message);
            }

        }

        /// <summary>
        ///     Deletes a user with the given id in the database, if non i found the delete method returns false otherwise true.
        /// </summary>
        /// <param name="id">
        ///     The id for the user which is requested for deletion
        /// </param>
        /// <returns>
        ///     A response message indicating the result of the request
        /// </returns>
        public HttpResponseMessage DeleteUser(int id)
        {
            try
            {
                var result = _userHandler.Delete(id).Result;

                return CreateResponse(result ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            }
            catch (Exception exception)
            {

                return CreateResponse(HttpStatusCode.BadRequest, exception.Message);
            }
        }

        #endregion

        #region Team Operation
        /// <summary>
        ///     Retrieves a team from the database if any matches the given id
        /// </summary>
        /// <param name="id">
        ///     The given id to be matched against the teams in the database
        /// </param>
        /// <returns>
        ///     A Tuple, T1 is the requested Team, null if no match is found, 
        ///     T2 is the HttpResponseMessage indicating the result of the request
        /// </returns>
        public Tuple<Team, HttpResponseMessage> GetTeam(int id)
        {
            try
            {
                var team = _teamHandler.Read(id).Result;
                return team == null
                    ? new Tuple<Team, HttpResponseMessage>(null,
                        CreateResponse(HttpStatusCode.NoContent, "The file was not found"))
                    : new Tuple<Team, HttpResponseMessage>(team, CreateResponse(HttpStatusCode.OK));
            }
            catch (Exception)
            {
                return new Tuple<Team, HttpResponseMessage>(null, CreateResponse(HttpStatusCode.BadRequest));
            }
        }

        /// <summary>
        ///     Retrieves a collection of teams from the database consisting of teams with a name matching the given string
        /// </summary>
        /// <param name="name">
        ///     The given string to be matched against the names of the teams in the database
        /// </param>
        /// <returns>
        ///     A Tuple, T1 is the requested collection of Team, null if no match is found, 
        ///     T2 is the HttpResponseMessage indicating the result of the request
        /// </returns>
        public Tuple<IEnumerable<Team>, HttpResponseMessage> GetTeams(string name)
        {
            try
            {
                var query = from team in _teamHandler.GetAll()
                            where team.Name.Equals(name)
                            select team;

                return query.Count() < 0
                    ? new Tuple<IEnumerable<Team>, HttpResponseMessage>(null, CreateResponse(HttpStatusCode.NoContent, "The file was not found"))
                    : new Tuple<IEnumerable<Team>, HttpResponseMessage>(query, CreateResponse(HttpStatusCode.OK));
            }
            catch (Exception)
            {

                return new Tuple<IEnumerable<Team>, HttpResponseMessage>(null, CreateResponse(HttpStatusCode.BadRequest));
            }
        }

        /// <summary>
        ///     Method for creating a team with a state matching the given team object's state
        /// </summary>
        /// <param name="team">
        ///     The given team to be created in the database
        /// </param>
        /// <returns>
        ///     A response message indicating the result of the request
        /// </returns>
        public HttpResponseMessage CreateTeam(Team team)
        {
            try
            {
                var id = _teamHandler.Create(team).Result;

                return CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception exception)
            {

                return CreateResponse(HttpStatusCode.BadRequest, exception.Message);
            }
        }

        /// <summary>
        ///     Tries to update the state of a team in the database with the given id to the state of the given team object.
        ///     The update returns true if the update is complete, false otherwise
        /// </summary>
        /// <param name="id">
        ///     The id of the team requested for update
        /// </param>
        /// <param name="team">
        ///     The team object with the state which the chosen team should be updated to
        /// </param>
        /// <returns>
        ///     A response message indicating the result of the request
        /// </returns>
        public HttpResponseMessage UpdateTeam(int id, Team team)
        {
            try
            {
                var result = _teamHandler.Update(id, team).Result;

                return result
                    ? CreateResponse(HttpStatusCode.OK)
                    : CreateResponse(HttpStatusCode.NoContent);
            }
            catch (Exception exception)
            {

                return CreateResponse(HttpStatusCode.BadRequest, exception.Message);
            }
        }

        /// <summary>
        ///     Deletes a team with the given id in the database, if non i found the delete method returns false otherwise true.
        /// </summary>
        /// <param name="id">
        ///     The id for the team which is requested for deletion
        /// </param>
        /// <returns>
        ///     A response message indicating the result of the request
        /// </returns>
        public HttpResponseMessage DeleteTeam(int id)
        {
            try
            {
                var result = _teamHandler.Delete(id).Result;

                return CreateResponse(result ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            }
            catch (Exception exception)
            {

                return CreateResponse(HttpStatusCode.BadRequest, exception.Message);
            }
        }

        #endregion

        #region Study Operation

        /// <summary>
        ///     Retrieves a study with the requested id from the database if any exists
        /// </summary>
        /// <param name="studyId">
        ///     Id of the requested study
        /// </param>
        /// <returns>
        ///     A Tuple containing a study with an id property matching the given id or null if no match were found
        ///     and a response message matching the result of the request
        /// </returns>
        public Tuple<Study, HttpResponseMessage> GetStudy(int studyId)
        {
            var study = _studyHandler.Read(studyId).Result;
            return study.Equals(null) ?
                new Tuple<Study, HttpResponseMessage>(study, CreateResponse(HttpStatusCode.NoContent)) :
                new Tuple<Study, HttpResponseMessage>(study, CreateResponse(HttpStatusCode.OK));
        }

        /// <summary>
        ///     Retrieves all Studies with a Name property matching the given string
        /// </summary>
        /// <returns>
        ///     A Tuple containing a collection of all studies in the database
        ///     and a response message matching the result of the request
        /// </returns>
        public Tuple<IEnumerable<Study>, HttpResponseMessage> GetAllStudies()
        {
            var studies = _studyHandler.Read();
            return !studies.Any()?
                new Tuple<IEnumerable<Study>, HttpResponseMessage>(null, CreateResponse(HttpStatusCode.NoContent)) :
                new Tuple<IEnumerable<Study>, HttpResponseMessage>(studies, CreateResponse(HttpStatusCode.OK));
        }

        /// <summary>
        ///     Method for creating a study with a state matching the given study object's state
        /// </summary>
        /// <param name="study">
        ///     The given study to be created in the database
        /// </param>
        /// <returns>
        ///     A response message indicating the result of the request
        /// </returns>
        public HttpResponseMessage CreateStudy(Study study)
        {
            try
            {
                var userId = _studyHandler.Create(study).Result;

                return CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception exception)
            {
                return CreateResponse(HttpStatusCode.BadRequest, exception.Message);
            }

        }

        /// <summary>
        ///     Tries to update the state of a study in the database with the given id to the state of the given study object.
        ///     The update returns true if the update is complete, false otherwise
        /// </summary>
        /// <param name="id">
        ///     The id of the study requested for update
        /// </param>
        /// <param name="study">
        ///     The study object with the state which the chosen study should be updated to
        /// </param>
        /// <returns>
        ///     A response message indicating the result of the request
        /// </returns>
        public HttpResponseMessage UpdateTask(Study study)
        {
            try
            {
                var result = _studyHandler.Update(study).Result;

                return CreateResponse(result ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            }
            catch (Exception exception)
            {

                return CreateResponse(HttpStatusCode.BadRequest, exception.Message);
            }

        }

        /// <summary>
        ///     Deletes a study with the given id in the database, if non is found the delete method returns false otherwise true.
        /// </summary>
        /// <param name="id">
        ///     The id for the study which is requested for deletion
        /// </param>
        /// <returns>
        ///     A response message indicating the result of the request
        /// </returns>
        public HttpResponseMessage DeleteTask(int id)
        {
            try
            {
                var result = _studyHandler.Delete(id).Result;

                return CreateResponse(result ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            }
            catch (Exception exception)
            {

                return CreateResponse(HttpStatusCode.BadRequest, exception.Message);
            }
        }

        #endregion

        #region Task Operation

        /// <summary>
        ///     Retrieves a task with the requested id from the database if any exists
        /// </summary>
        /// <param name="taskId">
        ///     Id of the requested task
        /// </param>
        /// <returns>
        ///     A Tuple containing a task with an id property matching the given id or null if no match were found
        ///     and a response message matching the result of the request
        /// </returns>
        public Tuple<TaskRequest, HttpResponseMessage> GetTask(int taskId)
        {
            var task = _taskHandler.Read(taskId).Result;
            return task.Equals(null) ?
                new Tuple<TaskRequest, HttpResponseMessage>(task, CreateResponse(HttpStatusCode.NoContent)) :
                new Tuple<TaskRequest, HttpResponseMessage>(task, CreateResponse(HttpStatusCode.OK));
        }

        /// <summary>
        ///     Method for creating a task with a state matching the given task object's state
        /// </summary>
        /// <param name="task">
        ///     The given task to be created in the database
        /// </param>
        /// <returns>
        ///     A response message indicating the result of the request
        /// </returns>
        public HttpResponseMessage CreateTask(TaskRequest task)
        {
            try
            {
                var taskId = _taskHandler.Create(task).Result;

                return CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception exception)
            {
                return CreateResponse(HttpStatusCode.BadRequest, exception.Message);
            }

        }

        #endregion

        #region BibtexParser

        /// <summary>
        ///     Method for extracting the tags from a given bibtex file (includes bibtex entries and field types)
        /// </summary>
        /// <param name="file">
        ///     The given file to extract the bibtex tags from
        /// </param>
        /// <returns>
        ///     A tuple, T1 is a string array containing the extracted bibtex tags, T2 is the HttpActionResult of the request
        /// </returns>
        public Tuple<string[], HttpResponseMessage> ExtractBibtexTags(string file)
        {
            try
            {
                return new Tuple<string[], HttpResponseMessage>(_fileHandler.ParseTags(file), CreateResponse(HttpStatusCode.OK));
            }
            catch (ArgumentNullException exception)
            {
                return new Tuple<string[], HttpResponseMessage>(null, CreateResponse(HttpStatusCode.BadRequest, exception.Message));
            }
        }

        /// <summary>
        ///     Creates the HttpActionResult used to identify the result of a action invoked by the WebApi
        /// </summary>
        /// <param name="statusCode">
        ///     The HttpStatusCode identifying the type of result
        /// </param>
        /// <param name="message">
        ///     If given, a message describing the details about the Response given e.g. why an error occurred
        /// </param>
        /// <returns>
        ///     A HttpActionResult associated with the requested action
        /// </returns>
        private HttpResponseMessage CreateResponse(HttpStatusCode statusCode, string message = null)
        {
            return new HttpResponseMessage(statusCode) { ReasonPhrase = message };
        }

        #endregion
    }
}