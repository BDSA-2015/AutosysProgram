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
        public void CreateRoleMapping()
        {
            Mapper.CreateMap<DatabaseTask, TaskRequest, TaskRequest>();
        }
    }
}