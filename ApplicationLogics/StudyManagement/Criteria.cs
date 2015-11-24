using ApplicationLogics.Repository;

namespace ApplicationLogics.StudyManagement
{
    public class Criteria : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
        public DataField DataField { get; set; }
    }

}
