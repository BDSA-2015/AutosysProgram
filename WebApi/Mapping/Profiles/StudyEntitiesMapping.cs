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


        public StudyEntitiesMapping()
        {
            CreateConflictingDataMapping();
            CreateDataFieldMapping();
            CreatePhaseMapping();
            CreateRoleMapping();
            CreateStudyMapping();
            CreateTaskRequestMapping();
        }

       public void CreateConflictingDataMapping()
        {
            throw new  NotImplementedException();

        }

        public void CreateDataFieldMapping()
        {
            throw new NotImplementedException();
        }

        public void CreatePhaseMapping()
        {
            throw new NotImplementedException();
        }

        public void CreateRoleMapping()
        {
            throw new NotImplementedException();
        }

        public void CreateStudyMapping()
        {
            throw new NotImplementedException();
        }
       
        public void CreateStudyManagerMapping()
        {
            throw new NotImplementedException();
        }

        public void CreateTaskRequestMapping()
        {
            throw new NotImplementedException();
        }

    }
}