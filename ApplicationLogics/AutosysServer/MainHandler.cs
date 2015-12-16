// MainHandler.cs is a part of Autosys project in BDSA-2015. Created: 17, 11, 2015.
// Creators: Dennis Thinh Tan Nguyen, William Diedricsehn Marstrand, Thor Valentin Aakjær Olesen Nielsen, 
// Jacob Mullit Møiniche.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using ApplicationLogics.ExportManagement;
using ApplicationLogics.PaperManagement;
using ApplicationLogics.PaperManagement.Bibtex;
using ApplicationLogics.ProtocolManagement;
using ApplicationLogics.StudyManagement;
using ApplicationLogics.UserManagement;
using ApplicationLogics.UserManagement.Entities;
using BibtexLibrary.Parser;
using BibtexParser = ApplicationLogics.PaperManagement.Bibtex.BibtexParser;


namespace ApplicationLogics.AutosysServer
{
    public class MainHandler
    {
        private ExportHandler _exportHandler;
        private FileHandler _fileHandler;
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
            _studyHandler = new StudyHandler(injector.GetStudyAdapter());
            _fileHandler = new FileHandler(new BibtexParser());
            _exportHandler = new ExportHandler();
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


        #endregion

        #region Task Operation



        #endregion

        #region Study Operation

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