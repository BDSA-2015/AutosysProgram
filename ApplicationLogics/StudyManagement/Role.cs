﻿// Role.cs is a part of Autosys project in BDSA-2015. Created: 17, 11, 2015.
// Creators: Dennis Thinh Tan Nguyen, William Diedricsehn Marstrand, Thor Valentin Aakjær Olesen Nielsen, 
// Jacob Mullit Møiniche.

using ApplicationLogics.Repository;

namespace ApplicationLogics.StudyManagement
{
    public class Role : IEntity
    {
        public enum Type
        {
            Validator,
            Reviewer
        }

        public int Id { get; set; }
    }
}