// FacadeInjectionContainer.cs is a part of Autosys project in BDSA-2015. Created: 03, 12, 2015.
// Creators: Dennis Thinh Tan Nguyen, William Diedricsehn Marstrand, Thor Valentin Aakjær Olesen Nielsen, 
// Jacob Mullit Møiniche.

using ApplicationLogics.StorageFasade;
using Storage.Models;
using Storage.Repository;

namespace ApplicationLogics.AutosysServer
{
    /// <summary>
    /// This class is a dependency injection container that returns various facades that are
    /// to be used.
    /// </summary>
    internal class FacadeInjectionContainer
    {
        /// <summary>
        /// Returns a UserFacde that are used by userHandlers
        /// It creates a userFacade with specified repository
        /// </summary>
        /// <returns></returns>
        public UserFacade GetUserFasade()
        {
            var repository = new DbRepository<StoredUser>();
            return new UserFacade(repository);
        }

        //TODO Add your facades and how they are initialzied here
    }
}