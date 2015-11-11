using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication1.ApplicationLogic.PaperManagement;

namespace ConsoleApplication1.Repository
{
    class DBContext : DbContext
    {
        public DbSet<Paper> Papers { get; set; }
    }
}
