using System.Reflection;
using ApplicationLogics.StudyManagement;
using AutoMapper;
using Storage.Entities;
using Storage.Models;

namespace ApplicationLogics.AutosysServer.Mapping.Profiles
{
    internal class StudyManagementStorageProfile : Profile
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
        ///     Creates a mapping between the the database representation of the Criteria and the Criteira in the model
        /// </summary>
        private void CreateCriteriaMappings()
        {
            Mapper.CreateMap<StoredCriteria, Criteria>();

            Mapper.CreateMap<Criteria, StoredCriteria>();
        }

        /// <summary>
        ///     Creates a mapping between the the database representation of the Phase and the Phase in the model
        /// </summary>
        private void CreatePhaseMappings()
        {
            //StoredUser to User
            Mapper.CreateMap<StoredPhase, Phase>();

            //User to StoredUser
            Mapper.CreateMap<Phase, StoredPhase>();
        }

        /// <summary>
        ///     Creates a mapping between the the database representation of the Datafield and the Datafield in the model
        /// </summary>
        private void CreateDatafieldMapping()
        {
            Mapper.CreateMap<DataField, StoredDataField>();
            Mapper.CreateMap<StoredDataField, DataField>();
        }

        /// <summary>
        ///     Creates a mapping between the the database representation of the Role and the Role in the model
        /// </summary>
        private void CreateRoleMapping()
        {
            Mapper.CreateMap<Role, StoredRole>().ForMember(storedRole => storedRole.Id, 
                                                            opt => opt.Ignore());

            Mapper.CreateMap<StoredRole, Role>();
        }

        /// <summary>
        ///     Creates a mapping between the the database representation of the Study and the Study in the model
        /// </summary>
        private void CreateStudyMapping()
        {
            Mapper.CreateMap<Study, StoredStudy>()
                .ForMember(source => source.Id, 
                            opt => opt.MapFrom(target => target.Id));
           
            Mapper.CreateMap<StoredStudy, Study>()
                .ForMember(source => source.Id,
                            opt => opt.MapFrom(target => target.Id)); ;
        }

        /// <summary>
        ///     Creates a mapping between the the database representation of the Task and the Task in the model
        /// </summary>
        private void CreateTaskRequestMapping()
        {
            Mapper.CreateMap<TaskRequest, StoredTaskRequest>();
            Mapper.CreateMap<StoredTaskRequest, TaskRequest>();
        }
    }
}