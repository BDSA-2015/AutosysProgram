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

        public Dictionary<Item, List<String>> PaperInformation { get; protected set; }


        public Paper()
        {
            throw  new NotImplementedException();
        }

        public Paper(Dictionary<Item, List<String>> PaperInformation)
        {
            throw new NotImplementedException();
        }

        public void AddInformation(Item itemTag, string information)
        {
            throw new NotImplementedException();
        }

        public void RemoveInformation()
        {
            throw new NotImplementedException();
        }
    }

}
