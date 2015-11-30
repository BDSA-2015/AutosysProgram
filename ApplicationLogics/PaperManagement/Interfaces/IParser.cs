using System.Collections.Generic;
using ApplicationLogics.PaperManagement.Bibtex;

namespace ApplicationLogics.PaperManagement.Interfaces
{
    public interface IParser
    {
        List<Paper> Parse(string data);
    }
}
