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

        /// <summary>
        ///     Returns an adapter used to convert user entities to the storage layer in the UserHandler.
        ///     Creates an adapter with its corresponding repository. 
        /// </summary>
        /// <returns></returns>
        public UserAdapter GetUserAdapter()
        {
            var userRepository = new UserRepository();
            return new UserAdapter(userRepository);
        }

        public TeamAdapter GetTeamAdapter()
        {
            var teamRepository = new TeamRepository();
            return new TeamAdapter(teamRepository);
        }

        public StudyAdapter GetStudyAdapter()
        {
            var studyRepository = new StudyRepository();
            return new StudyAdapter(studyRepository);
        }

        public PhaseAdapter GetPhaseAdapter()
        {
            return new PhaseAdapter(); // Only used in StudyHandler to convert phases that are stored 
        }

    }

}