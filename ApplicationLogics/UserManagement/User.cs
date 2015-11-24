using ApplicationLogics.Repository;

namespace ApplicationLogics.UserManagement
{
    public class User : IEntity
    {
        public int Id { get; set; }

        public string Name { get; internal set; }

        public string Metadata { get; set; }
    }

}
