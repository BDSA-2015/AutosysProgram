// AdapterInjectionContainer.cs is a part of Autosys project in BDSA-2015. Created: 03, 12, 2015.
// Creators: Dennis Thinh Tan Nguyen, William Diedricsehn Marstrand, Thor Valentin Aakjær Olesen Nielsen, 
// Jacob Mullit Møiniche.

using ApplicationLogics.StorageAdapter;
using Storage.Repository;

namespace ApplicationLogics.AutosysServer
{
    /// <summary>
    ///     This class is a dependency injection container that returns various adapters based on which repository is to be used in the Storage layer by each Adapter.
    ///     By way of example, the TeamAdapter repository should be injected with a TeamRepository from the Storage Layer. 
    /// </summary>
    internal class AdapterInjectionContainer
    {
        // TODO insert new async repository and make facade take this instead
        /// <summary>
        ///     Returns a UserFacde that are used by userHandlers
        ///     It creates a userFacade with specified repository
        /// </summary>
        /// <returns></returns>
        public UserAdapter GetUserFasade()
        {
            var userRepository = new UserRepository();
            return new UserAdapter(userRepository);
            //var repository = new UserRepository<StoredUser>();
            //return new UserAdapter(repository);
        }

        public TeamAdapter GetTeamFasade()
        {
            var teamRepository = new TeamRepository();
            return new TeamAdapter(teamRepository);
        }

        public StudyAdapter GetStudyAdapter()
        {
            var studyRepository = new StudyRepository();
            return new StudyAdapter(studyRepository);
        }
    }

}