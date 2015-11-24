﻿// ItemTag.cs is a part of Autosys project in BDSA-2015. Created: 17, 11, 2015.
// Creators: Dennis Thinh Tan Nguyen, William Diedricsehn Marstrand, Thor Valentin Aakjær Olesen Nielsen, 
// Jacob Mullit Møiniche.

using ApplicationLogics.Repository;

namespace ApplicationLogics.PaperManagement
{
    public class ItemTag : IEntity
    {
        /// <summary>
        ///     This is a Bibtex property holder. Year, Auther. etc, but is not the value to the property
        /// </summary>
        public string TagName { get; set; }

        public int Id { get; set; }
    }
}