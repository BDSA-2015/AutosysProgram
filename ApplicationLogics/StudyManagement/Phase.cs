using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLogics.StudyManagement
{
    public class Phase
    {
        public List<Criteria> Criterias { get; protected set; }


        public bool HasCriteria()
        {
         throw new NotImplementedException();   
        }

        public void AddCriteria()
        {
            throw new NotImplementedException();
        }

        public void RemoveCriteria()
        {
            throw new NotImplementedException();
        }
    }
}
