﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationLogics.Repository;

namespace Storage.Entities
{
    public class StoredUser : IEntity
    {
        public int Id { get; set; }
    }

}
