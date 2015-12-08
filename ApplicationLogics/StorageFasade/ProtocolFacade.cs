using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationLogics.ProtocolManagement;
using ApplicationLogics.StorageFasade.Interface;

namespace ApplicationLogics.StorageFasade
{
    public class ProtocolFacade : IFacade<Protocol>
    {
        public int Create(Protocol item)
        {
            throw new NotImplementedException();
        }

        public Protocol Read(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Protocol> Read()
        {
            throw new NotImplementedException();
        }

        public void Update(Protocol item)
        {
            throw new NotImplementedException();
        }

        public void Delete(Protocol item)
        {
            throw new NotImplementedException();
        }
    }

}
