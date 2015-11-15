using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLogics.StudyManagement
{
    class Study
    {
        public string Name { get; set; }
        public string Classification { get; set; }
        public string description { get; set; }
        public List<Phase> phases { get;  set; }

        
    }
}
