using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationLogics.Repository;

namespace ApplicationLogics.ExportManagement
{
    /// <summary>
    /// This class represents the Research Protocol used to configure a given study.
    /// </summary>
    public class Protocol : IEntity
    {
        // Which other attributes does a protocol contain?
        public int Id { get; set; }
    }
}
