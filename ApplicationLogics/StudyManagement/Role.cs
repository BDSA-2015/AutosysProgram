using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationLogics.Repository;

namespace ApplicationLogics.StudyManagement
{
    public class Role : IEntity
    {
        public int Id { get; set; }
        public enum Type { Validator, Reviewer }
    }

}
