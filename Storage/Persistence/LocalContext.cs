using System.Data.Entity;
using ApplicationLogics.PaperManagement;
using ApplicationLogics.ProtocolManagement;
using ApplicationLogics.StudyManagement;
using ApplicationLogics.UserManagement;
using Task = ApplicationLogics.StudyManagement.Task;

namespace Storage.Persistence
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
