using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationLogics.StorageFasade.Interface;
using ApplicationLogics.StudyManagement;

namespace ApplicationLogics.StorageFasade
{
    public class TaskRequestFacade : IFacade<TaskRequest>
    {
        public int Create(TaskRequest item)
        {
            throw new NotImplementedException();
        }

        public TaskRequest Read(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TaskRequest> Read()
        {
            throw new NotImplementedException();
        }

        public void Update(TaskRequest item)
        {
            throw new NotImplementedException();
        }

        public void Delete(TaskRequest item)
        {
            throw new NotImplementedException();
        }
    }

}
