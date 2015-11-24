// FieldTag.cs is a part of Autosys project in BDSA-2015. Created: 17, 11, 2015.
// Creators: Dennis Thinh Tan Nguyen, William Diedricsehn Marstrand, Thor Valentin Aakjær Olesen Nielsen, 
// Jacob Mullit Møiniche.

using ApplicationLogics.PaperManagement.Interfaces;

namespace ApplicationLogics.PaperManagement
{
    internal class FieldTag : ITag
    {
        /// <summary>
        /// This is a Bibtex property holder (e.g. Year or Author) but not the actual value. 
        /// </summary>
        public string TagName { get; set; }
    }
}