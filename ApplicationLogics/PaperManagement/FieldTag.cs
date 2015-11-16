using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLogics.PaperManagement
{
    class FieldTag : ITag
    {
        /// <summary>
        /// This is a Bibtex property holder. Year, Auther. etc, but is not the value to the property
        /// </summary>
        public string TagName { get; set; }
    }
}
