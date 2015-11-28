using ApplicationLogics.StorageFasade;
using Storage.Entities;
using Storage.Persistence;

namespace ApplicationLogics.AutosysServer
{
    /// <summary>
    /// This class is a dependency injection container that returns various facades that are
    /// to be used.
    /// </summary>
    class FacadeInjectionContainer
    {

        /// <summary>
        /// Returns a UserFacde that are used by userHandlers
        /// It creates a userFacade with specfied repository
        /// </summary>
        /// <returns></returns>
        public UserFasade GetUserFasade()
        {
            var repository = new DbRepository<StoredUser>();
            return new UserFasade(repository);
        }

        //TODO Add your facades and how they are initialzied here
    }
}
