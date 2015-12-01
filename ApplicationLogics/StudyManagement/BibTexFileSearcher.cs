using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationLogics.StudyManagement.BibTex;

namespace ApplicationLogics.StudyManagement
{
    public class BibTexFileSearcher
    {


        

        public BibTexFileSearcher()
        {
            
        }


        public bool SatisfyCriteria( Dictionary<Item, List<string>> file , Criteria criteria)
        {

            criteria.
            //Iterates over the hashmap
            foreach (var tag in file)
            {
                //Iterates over the list of strings found in each value in the hashmap
                foreach (var informations in tag.Value)
                {
                    
                }
            }

            throw new NotImplementedException();
        }
    }
}
