using ApplicationLogics.Repository;

namespace ApplicationLogics.UserManagement
{
    public class Team : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int[] UserIDs { get; set; }
        public string Metadata { get; set; }
    }
}
