using System.Data.Entity;
using ApplicationLogics.ExportManagement;
using ApplicationLogics.PaperManagement.Bibtex;
using ApplicationLogics.PaperManagement;
using ApplicationLogics.ProtocolManagement;
using ApplicationLogics.StudyManagement;
using ApplicationLogics.UserManagement;
using TaskRequest = ApplicationLogics.StudyManagement.TaskRequest;

namespace Storage.Persistence
{

    /// <summary>
    /// This class is used to reflect changes made to entities in the system and apply these changes in the database. 
    /// </summary>
    public class LocalContext : DbContext
    {
        // Study entities 
        DbSet<Criteria> Criterias { get; set; }
        DbSet<Phase> Phases { get; set; }
        DbSet<Role> Roles { get; set; }
        DbSet<TaskRequest> Tasks { get; set; }

        // User entities
        DbSet<Team> Teams { get; set; }
        DbSet<User> Users { get; set; }

        // Protocol entities
        DbSet<Protocol> Protocols { get; set; }

        // Paper entities 
        DbSet<Paper> Papers { get; set; }
    }
    
}
