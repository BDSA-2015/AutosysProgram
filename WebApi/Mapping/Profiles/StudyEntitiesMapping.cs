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

        public void CreateTaskRequest_ProgressMapping()
        {
            AutoMapper.Mapper.CreateMap<DatabaseTask.Filter, TaskRequest.Filter>().ConstructUsing(value =>
            {
                switch(value)
                {
                    case DatabaseTask.Filter.Done:
                        return TaskRequest.Filter.Done;
                    case DatabaseTask.Filter.Editable:
                        return TaskRequest.Filter.Editable;
                    default:
                        return TaskRequest.Filter.Remaining;
                }
            }
            
            
            );

        }
        
        public void CreateRoleMapping()
        {
            Mapper.CreateMap<DatabaseTask, TaskRequest>()
            .ForMember(dest => dest.TaskFilter, opts => opts.MapFrom(src => src.Progress))
            

            ;
                
            
        }


    }
}