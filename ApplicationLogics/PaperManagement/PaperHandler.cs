using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.WebPages;
using ApplicationLogics.StorageFasade;
using ApplicationLogics.StorageFasade.Interface;
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
        private IFacade<Paper> _paperFacade; 

        public PaperHandler(IParser parser, IFacade<Paper> paperFacade)
        {
            _parser = parser;
            _paperFacade = paperFacade;
        }

        /// <summary>
        /// Creates a List of Paper based on an imported BibTex file which is parsed to the program.
        /// </summary>
        /// <param name="file">The bibtex file which is parsed to the program</param>
        /// <returns>A List of Papers which was valid for parsing</returns>
        public void ImportBibtex(string file)
        {
            if (file.IsEmpty() || file == null)
            {
                throw new ArgumentNullException("The given bibtex file cannot be null nor empty");
            }

            foreach (var paper in _parser.Parse(file))
            {
                _paperFacade.Create(paper);
            }
        }
    }
}
