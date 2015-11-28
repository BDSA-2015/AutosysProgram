using System.Collections.Generic;

namespace ApplicationLogics.StudyManagement.BibTex
{
    /// <summary>
    /// Parses text containing bibliographic data into a collection of bibliography <see cref="Item"/> objects.
    /// </summary>
    public interface IBibliographyParser
    {
        List<Item> Parse(string data);
    }
}
