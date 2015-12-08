using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Storage.Models;
using ApplicationLogics.UserManagement;
using ApplicationLogics.StudyManagement;
using Storage.Entities;

namespace ApplicationLogics.AutosysServer.Mapping.Profiles.ApplicationLogicProfiles
{
    class StudyManagementStorageProfile : Profile
    {
        
        protected override void Configure()
        {
            CreateCriteriaMappings();
            CreatePhaseMappings();
            CreateDatafieldMapping();
        }

        /// <summary>
        /// Creates mappings between user and storedUser
        /// </summary>
        private void CreateCriteriaMappings()
        {
            //StoredUser to User
            Mapper.CreateMap<StoredCriteria, Criteria>();

            //User to StoredUser
            Mapper.CreateMap<Criteria, StoredCriteria>();
        }

        /// <summary>
        /// Creates mappings between team and storedTeam
        /// </summary>
        private void CreatePhaseMappings()
        {
            //StoredUser to User
            Mapper.CreateMap<StoredPhase, Phase>();

            //User to StoredUser
            Mapper.CreateMap<Phase, StoredPhase>();
        }

        private void CreateDatafieldMapping()
        {
            Mapper.CreateMap<DataField, StoredDataField>();
            Mapper.CreateMap<StoredDataField, DataField>();
        }

        private void CreateRoleMapping()
        {
            Mapper.CreateMap<Role,StoredRole>();
            Mapper.CreateMap<StoredRole, Role>();
        }

        private void CreateStudyMapping()
        {
            Mapper.CreateMap<Study, StoredStudy>();
            Mapper.CreateMap<StoredStudy, Study>();
        }

        private void CreateTaskRequestMapping()
        {
            Mapper.CreateMap<TaskRequest,StoredTaskRequest>();
            Mapper.CreateMap<StoredTaskRequest, TaskRequest>();
        }
    }
}
