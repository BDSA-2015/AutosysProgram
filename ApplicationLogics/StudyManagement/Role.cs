using ApplicationLogics.Repository;

namespace ApplicationLogics.StudyManagement
{
    public class Role : IEntity
    {
        public int Id { get; set; }
        public enum Type { Validator, Reviewer }
    }

}
