﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.Models
{
    /// <summary>
    /// Each user has a list of tasks. 
    /// Entity ramework does not support storing of dictionaries. A phase can have the same task (key) delegated tu multiple users (value).
    /// This class is used to store each key/value pair from a dictionary as a record in the table with a foreign key to the principal entity (Phase, previously contained dictionary).
    /// </summary>
    public class PhaseTask
    {

        public virtual IDictionary<StoredTaskRequest, List<StoredUser>> Tasks { get; set; }
        

        public int Id { get; set; } // unique autogenerated database key

        public int UserId { get; set; }

        public virtual StoredUser User { get; set; } // Dictionary key 

        public virtual ICollection<StoredTaskRequest> Value { get; set; } // Dictionary value 

        public virtual StoredPhase Phase { get; set; }

        public int PhaseId { get; set; } // FK to principal entity

    }

}
