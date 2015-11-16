using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationLogics.UserManagement;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationLogics.Repository;

namespace ApplicationLogics.PaperManagement
{
    public class ItemTag : IEntity
    {
        public int Id { get; set; }

        /// <summary>
        /// This is a Bibtex property holder. Year, Auther. etc, but is not the value to the property
        /// </summary>
        public string TagName { get; set; }
    }
}
