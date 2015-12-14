using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationLogics.StorageAdapter.Interface;
using ApplicationLogics.StudyManagement;
using AutoMapper;
using Storage.Models;
using Storage.Repository.Interface;

namespace ApplicationLogics.StorageAdapter
{

    /// <summary>
    ///     This class is responsible for the communication between application logic layer and storage layer.
    ///     This class will handle studies and convert them the the appropriate object that are to be propagated.
    /// </summary>
    public class StudyAdapter : IAdapter<Study>
    {

        private readonly IRepository<StoredStudy> _studyRepository;

        public StudyAdapter(IRepository<StoredStudy> studyRepository)
        {
            _studyRepository = studyRepository;
        }

        public async Task<int> Create(Study study)
        {

            var storedStudy = Mapper.Map<StoredStudy>(study);
            return await _studyRepository.Create(storedStudy);
        }

        public Task<Study> Read(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Study> Read()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateIfExists(Study user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteIfExists(int id)
        {
            throw new NotImplementedException();
        }

        public Study Map(Study item)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _studyRepository.Dispose();
        }

    }

}