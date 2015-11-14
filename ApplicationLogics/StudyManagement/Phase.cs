using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationLogics.Repository;

namespace ApplicationLogics.StudyManagement
{
    public class Phase : IEntity
    {
        public int Id { get; set; }

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
