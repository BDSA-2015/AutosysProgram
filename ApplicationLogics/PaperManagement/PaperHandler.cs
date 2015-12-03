using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationLogics.PaperManagement.Bibtex;
using ApplicationLogics.PaperManagement.Interfaces;
using ApplicationLogics.StorageFasade;
using NUnit.Framework.Constraints;

namespace ApplicationLogics.PaperManagement
{
    /// <summary>
    /// Class for handling all functionality associated with creating and importing Papers into the program
    /// </summary>
    public class PaperHandler
    {
        //Used to generate Bibtex files, which later is stored as Papers in the database
        private IParser _parser;
        private PaperFacade _paperFacade; 

        public PaperHandler(IParser parser, PaperFacade paperFacade)
        {
            _parser = parser;
            _paperFacade = paperFacade;
        }

        /// <summary>
        /// Creates a List of Paper based on an imported BibTex file which is parsed to the program.
        /// </summary>
        /// <param name="file">The bibtex file which is parsed to the program</param>
        /// <returns>A List of Papers which was valid for parsing</returns>
        public List<int> ImportPaper(string file)
        {
            if (string.IsNullOrEmpty(file))
            {
                throw new ArgumentNullException("The given bibtex file cannot be null nor empty");
            }

            var paperIds = new List<int>();

            foreach (var paper in _parser.Parse(file))
            {
                paperIds.Add(_paperFacade.Create(paper));
            }

            return paperIds;
        }
       
    }
}
