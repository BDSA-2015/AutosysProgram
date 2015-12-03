// PaperManagementStorageProfile.cs is a part of Autosys project in BDSA-2015. Created: 03, 12, 2015.
// Creators: Dennis Thinh Tan Nguyen, William Diedricsehn Marstrand, Thor Valentin Aakjær Olesen Nielsen, 
// Jacob Mullit Møiniche.

using AutoMapper;

namespace ApplicationLogics.AutosysServer.Mapping.Profiles.ApplicationLogicProfiles
{
    /// <summary>
    /// This class will create mappings on application logic entities in 
    /// PaperManagement subsystem and StoredPaper entities.
    /// </summary>
    public class PaperManagementStorageProfile : Profile
    {

        protected override void Configure()
        {
           CreatePaperMappings();
        }


        private void CreatePaperMappings()
        {
            //AutoMapper.Mapper.CreateMap<StoredPaper, Paper>(); TODO DEFINE YOUR OWN specialized paper.
        }
         
    }
}