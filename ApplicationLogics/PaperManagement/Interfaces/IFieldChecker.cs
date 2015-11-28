using ApplicationLogics.PaperManagement.Bibtex;

namespace ApplicationLogics.PaperManagement.Interfaces
{
    public interface IFieldChecker
    {
        bool Validate(string field);
    }
}
