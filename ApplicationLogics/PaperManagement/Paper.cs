// Paper.cs is a part of Autosys project in BDSA-2015. Created: 17, 11, 2015.
// Creators: Dennis Thinh Tan Nguyen, William Diedricsehn Marstrand, Thor Valentin Aakjær Olesen Nielsen, 
// Jacob Mullit Møiniche.

using System;
using System.Collections.Generic;
using ApplicationLogics.PaperManagement.Interfaces;

namespace ApplicationLogics.PaperManagement
{
    public class Paper 
    {
        /// <summary>
        /// Creates an empty paper with no values.
        /// </summary>
        public Paper()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Creates a Paper based on existing information.
        /// </summary>
        /// <param name="paperInformation"></param>
        public Paper(Dictionary<ITag, List<string>> paperInformation)
        {
            throw new NotImplementedException();
        }

        public Dictionary<ITag, List<string>> PaperInformation { get; protected set; }

        /// <summary>
        /// Update information on paper or add addtional information on the Paper.
        /// </summary>
        /// <param name="itemTag"></param>
        /// <param name="information"></param>
        public void AddInformation(ITag itemTag, string information)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Remove information about a paper. This will remove all information about the specified Tag
        /// (even if multiple information was stored under this Tag).
        /// </summary>
        public void RemoveInformation()
        {
            throw new NotImplementedException();
        }
    }
}