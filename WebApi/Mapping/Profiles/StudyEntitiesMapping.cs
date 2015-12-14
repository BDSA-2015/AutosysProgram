using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DatabaseTask = ApplicationLogics.StudyManagement.TaskRequest;
using TaskRequest = WebApi.Models.TaskRequest;


namespace WebApi.Mapping
{
    public class StudyEntitiesMapping : Profile
    {

        public void CreateEnumMapping_TaskRequest_Filter()
        {
            Mapper.CreateMap<DatabaseTask.Filter, TaskRequest.Filter>();
        }
        
        public void CreateRoleMapping()
        {
            var d = new DatabaseTask();
            var t = new TaskRequest();

            Mapper.CreateMap<DatabaseTask.Filter, TaskRequest.Filter>();

            Mapper.CreateMap<DatabaseTask, TaskRequest>()
            .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Id))
            .ForMember(dest => dest.TaskFilter, opts => opts.MapFrom(src => src.Progress))
            .ForMember(dest => dest.RequestedFields, opts=> opts.MapFrom(src => src.))

                
            
        }


    }
}