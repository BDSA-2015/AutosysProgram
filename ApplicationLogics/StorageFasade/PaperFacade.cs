using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationLogics.PaperManagement;
using ApplicationLogics.PaperManagement.Bibtex;
using ApplicationLogics.StorageFasade.Interface;
using Storage.Models;
using Storage.Repository;

namespace ApplicationLogics.StorageFasade
{
    public class PaperFacade : IFacade<Paper>
    {
        private IRepository<StoredPaper> _papers;

        public PaperFacade(IRepository<StoredPaper> papers)
        {
            _papers = papers;
        }

        public int Create(Paper item)
        {
            throw new NotImplementedException();
        }

        public void Delete(Paper item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Paper> Read()
        {
            throw new NotImplementedException();
        }

        public Paper Read(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Paper item)
        {
            throw new NotImplementedException();
        }
    }

}
