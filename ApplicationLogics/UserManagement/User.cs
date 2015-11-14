using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationLogics.Repository;
using ApplicationLogics.StudyManagement;

namespace ApplicationLogics.UserManagement
{
    public class User : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Role Role { get; set; }
    }

}
