﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationLogics.PaperManagement;
using ApplicationLogics.StorageFasade.Interface;

namespace ApplicationLogics.StorageFasade
{
    public class PaperFacade : IFacade<Paper>
    {
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