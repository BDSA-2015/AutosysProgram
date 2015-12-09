using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationLogics.PaperManagement;
using ApplicationLogics.StorageFasade.Interface;
using Storage.Models;
using Storage.Repository;
using Storage.Repository.Interface;

namespace ApplicationLogics.StorageFasade
{
    public class PaperFacade : IFacade<Paper>
    {
        //TODO Write purpose of class
        private IRepository<StoredPaper> _papers;

        public PaperFacade(IRepository<StoredPaper> papers)
        {
            _papers = papers;
        }

        public int Create(Paper item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("The given Paper cannot be null");
            }
            var storedPaper = AutoMapper.Mapper.Map<StoredPaper>(item);
            return _papers.CreateOrUpdate(storedPaper);
        }

        public void Delete(Paper item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("The given Paper cannot be null");
            }
            var storedPaper = AutoMapper.Mapper.Map<StoredPaper>(item);
            _papers.DeleteIfExists(storedPaper);
        }

        public IEnumerable<Paper> Read()
        {
            foreach (var storedPaper in _papers.Read())
            {
                yield return AutoMapper.Mapper.Map<Paper>(storedPaper);
            }
        }

        public Paper Read(int id)
        {
            if (id < 0)
            {
                throw new ArgumentOutOfRangeException("The given id must be 0 or greater");
            }

            return AutoMapper.Mapper.Map<Paper>(_papers.Read(id));
        }

        public void Update(Paper item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("The given Paper cannot be null");
            }

            _papers.UpdateIfExists(AutoMapper.Mapper.Map<StoredPaper>(item));
        }
    }

}
