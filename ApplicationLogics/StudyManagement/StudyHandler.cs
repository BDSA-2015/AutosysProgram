﻿// StudyHandler.cs is a part of Autosys project in BDSA-2015. Created: 17, 11, 2015.
// Creators: Dennis Thinh Tan Nguyen, William Diedricsehn Marstrand, Thor Valentin Aakjær Olesen Nielsen, 
// Jacob Mullit Møiniche.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationLogics.StorageAdapter.Interface;
using Storage.Models;

namespace ApplicationLogics.StudyManagement
{
    public class StudyHandler
    {

        private readonly IAdapter<Study, StoredStudy> _studyAdapter;

        public StudyHandler(IAdapter<Study, StoredStudy> adapter)
        {
            _studyAdapter = adapter;
        }

        public async Task<int> Create(Study study)
        {
            return await _studyAdapter.Create(study);
        }

        public async Task<Study> Read(int studyId)
        {
            return await _studyAdapter.Read(studyId);
        }

        public IEnumerable<Study> Read()
        {
            return _studyAdapter.Read();
        } 

        public async Task<bool> Update(Study study)
        {
            return await _studyAdapter.UpdateIfExists(study);
        }

        public async Task<bool> Delete(int id)
        {
            return await _studyAdapter.DeleteIfExists(id);
        }
    }
}