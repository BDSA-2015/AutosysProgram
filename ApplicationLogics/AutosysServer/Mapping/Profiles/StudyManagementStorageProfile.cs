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
            CreateRoleMapping();
            CreateStudyMapping();
            CreateTaskRequestMapping();
        }

        /// <summary>
        /// Creates a mapping between the the database representation of the Criteria and the Criteira in the model
        /// </summary>
        private void CreateCriteriaMappings()
        {
            Mapper.CreateMap<StoredCriteria, Criteria>();

            Mapper.CreateMap<Criteria, StoredCriteria>();
        }

        /// <summary>
        /// Creates a mapping between the the database representation of the Phase and the Phase in the model
        /// </summary>
        private void CreatePhaseMappings()
        {
            //StoredUser to User
            Mapper.CreateMap<StoredPhase, Phase>();

            //User to StoredUser
            Mapper.CreateMap<Phase, StoredPhase>();
        }
        /// <summary>
        /// Creates a mapping between the the database representation of the Datafield and the Datafield in the model
        /// </summary>
        private void CreateDatafieldMapping()
        {
            Mapper.CreateMap<DataField, StoredDataField>();
            Mapper.CreateMap<StoredDataField, DataField>();
        }
        /// <summary>
        /// Creates a mapping between the the database representation of the Role and the Role in the model
        /// </summary>
        private void CreateRoleMapping()
        {
            Mapper.CreateMap<Role,StoredRole>();
            Mapper.CreateMap<StoredRole, Role>();
        }
        /// <summary>
        /// Creates a mapping between the the database representation of the Study and the Study in the model
        /// </summary>
        private void CreateStudyMapping()
        {
            Mapper.CreateMap<Study, StoredStudy>();
            Mapper.CreateMap<StoredStudy, Study>();
        }
        /// <summary>
        /// Creates a mapping between the the database representation of the Task and the Task in the model
        /// </summary>
        private void CreateTaskRequestMapping()
        {
            Mapper.CreateMap<TaskRequest,StoredTaskRequest>();
            Mapper.CreateMap<StoredTaskRequest, TaskRequest>();
        }
    }
}
