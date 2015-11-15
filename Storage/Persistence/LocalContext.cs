using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using ApplicationLogics.ExportManagement;
using ApplicationLogics.PaperManagement;
using Threading = System.Threading.Tasks;
using ApplicationLogics.StudyManagement;
using ApplicationLogics.UserManagement;

namespace Storage.Repository
{
    public class LocalContext : DbContext
    {
        // Study entities 
        DbSet<Criteria> Criterias { get; set; }
        DbSet<Phase> Phases { get; set; }
        DbSet<Role> Roles { get; set; }
        DbSet<Task> Tasks { get; set; }

        // User entities
        DbSet<Team> Teams { get; set; }
        DbSet<User> Users { get; set; }

        // Protocol entities
        DbSet<Protocol> Protocols { get; set; }

        // Paper entities 
        DbSet<Paper> Papers { get; set; }
    }
    
}
