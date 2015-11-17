using ApplicationLogics.Repository;

namespace ApplicationLogics.PaperManagement
{
    public class ItemTag : IEntity
    {
        public int Id { get; set; }

        /// <summary>
        /// This is a Bibtex property holder. Year, Auther. etc, but is not the value to the property
        /// </summary>
        public string TagName { get; set; }
    }
}
