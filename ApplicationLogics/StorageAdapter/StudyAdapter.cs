using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    public class StudyAdapter : IAdapter<Study, StoredStudy>
    {

        private readonly IRepository<StoredStudy> _studyRepository;

        public StudyAdapter(IRepository<StoredStudy> studyRepository)
        {
            _studyRepository = studyRepository;
        }

        public async Task<int> Create(Study study)
        {
            return await _studyRepository.Create(Map(study));
        }

        public async Task<Study> Read(int id)
        {
            return await Task.FromResult(Map(_studyRepository.Read(id).Result));
        }

        public IEnumerable<Study> Read()
        {
            foreach (var study in _studyRepository.Read())
            {
                yield return Map(study);

            }
        }

        public async Task<bool> UpdateIfExists(Study user)
        {
            return await _studyRepository.UpdateIfExists(Map(user));
        }

        public async Task<bool> DeleteIfExists(int id)
        {
            return await _studyRepository.DeleteIfExists(id);
        }


        //Mapping methods
        public StoredStudy Map(Study item)
        {
            return Mapper.Map<StoredStudy>(item);
        }

        public Study Map(StoredStudy item)
        {
            return Mapper.Map<Study>(item);
        }


        public void Dispose()
        {
            _studyRepository.Dispose();
        }

    }

}