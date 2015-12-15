// PaperManagementStorageProfile.cs is a part of Autosys project in BDSA-2015. Created: 03, 12, 2015.
// Creators: Dennis Thinh Tan Nguyen, William Diedricsehn Marstrand, Thor Valentin Aakjær Olesen Nielsen, 
// Jacob Mullit Møiniche.

using ApplicationLogics.PaperManagement;
using ApplicationLogics.PaperManagement.Bibtex;
using AutoMapper;
using Storage.Models;

namespace ApplicationLogics.AutosysServer.Mapping.Profiles
{
    /// <summary>
    ///     This class will create mappings on application logic entities in
    ///     PaperManagement subsystem and StoredPaper entities.
    /// </summary>
    public class PaperManagementStorageProfile : Profile
    {
        protected override void Configure()
        {
            CreatePaperMappings();
        }


        private void CreatePaperMappings()
        {
            //Paper to StoredPaper
            Mapper.CreateMap<Paper, StoredPaper>();

            //StoredPaper to Paper
            Mapper.CreateMap<StoredPaper, Paper>();
        }
    }
}