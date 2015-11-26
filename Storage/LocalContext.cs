using System.Data.Entity;
using ApplicationLogics.PaperManagement;
using ApplicationLogics.ProtocolManagement;
using ApplicationLogics.StudyManagement;
using ApplicationLogics.UserManagement;
using Storage.Entities;
using TaskRequest = ApplicationLogics.StudyManagement.TaskRequest;

namespace Storage
{

    /// <summary>
    /// This class is used to represents tables reflecting changes made to stored entities in the system and apply these changes in the database. 
    /// </summary>
    public class LocalContext : DbContext
    {
        // Study entities 
        DbSet<StoredCriteria> Criterias { get; set; }
        DbSet<StoredPhase> Phases { get; set; }
        DbSet<StoredRole> Roles { get; set; }
        DbSet<StoredTaskRequest> Tasks { get; set; }
        DbSet<StoredDatafield> Datafields { get; set; }
        DbSet<StoredStudy> Studies { get; set; }

        // User entities
        DbSet<StoredTeam> Teams { get; set; }
        DbSet<StoredUser> Users { get; set; }

        // Protocol entities
        DbSet<StoredProtocol> Protocols { get; set; }

        // Paper entities 
        DbSet<StoredPaper> Papers { get; set; }
    }
    
}
