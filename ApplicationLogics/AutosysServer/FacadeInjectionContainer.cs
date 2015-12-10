// FacadeInjectionContainer.cs is a part of Autosys project in BDSA-2015. Created: 03, 12, 2015.
// Creators: Dennis Thinh Tan Nguyen, William Diedricsehn Marstrand, Thor Valentin Aakjær Olesen Nielsen, 
// Jacob Mullit Møiniche.

using ApplicationLogics.StorageAdapter;

namespace ApplicationLogics.AutosysServer
{
    /// <summary>
    ///     This class is a dependency injection container that returns various facades that are
    ///     to be used.
    /// </summary>
    internal class FacadeInjectionContainer
    {
        // TODO insert new async repository and make facade take this instead
        /// <summary>
        ///     Returns a UserFacde that are used by userHandlers
        ///     It creates a userFacade with specified repository
        /// </summary>
        /// <returns></returns>
        public UserAdapter GetUserFasade()
        {
            //var repository = new UserRepository<StoredUser>();
            //return new UserAdapter(repository);
            return null;
        }

        //TODO Add your facades and how they are initialzied here
    }
}