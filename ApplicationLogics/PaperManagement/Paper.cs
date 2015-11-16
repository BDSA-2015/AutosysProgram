using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using ApplicationLogics.Repository;

namespace ApplicationLogics.PaperManagement
{
    public class Paper : IEntity
    {
        public int Id { get; set; }

        public Dictionary<ITag, List<String>> PaperInformation { get; protected set; }

        /// <summary>
        /// Create a empty paper with no values.
        /// </summary>
        public Paper()
        {
            throw  new NotImplementedException();
        }
        /// <summary>
        /// Create a Paper based existing information
        /// </summary>
        /// <param name="PaperInformation"></param>
        public Paper(Dictionary<ITag, List<String>> PaperInformation)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Update information on paper or add a information on the Paper
        /// </summary>
        /// <param name="itemTag"></param>
        /// <param name="information"></param>
        public void AddInformation(ITag itemTag, string information)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Remove a information about the paper. This will remove all information about the specified Tag, even if multiple information was stored under this Tag
        /// </summary>
        public void RemoveInformation()
        {
            throw new NotImplementedException();
        }
    }

}
