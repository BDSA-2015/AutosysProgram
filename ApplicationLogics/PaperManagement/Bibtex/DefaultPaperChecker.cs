using System;
using System.ComponentModel;
using System.Linq;
using ApplicationLogics.PaperManagement.Interfaces;

namespace ApplicationLogics.PaperManagement.Bibtex
{
    /// <summary>
    /// The default Paper checker which is chosen, when no custom validator is specified.
    /// All fields of the Paper need to be valid for the Paper to be valid.
    /// </summary>
    public class DefaultPaperChecker : IPaperChecker
    {
        readonly FieldValidator _validator = new FieldValidator();
        public bool Validate(Paper paper)
        {
            if (paper == null)
            {
                throw new ArgumentNullException("The given Paper cannot be null");
            }
            if (paper.DefaultFields.ContainsKey(DefaultEnumField.Author) && paper.DefaultFields.ContainsKey(DefaultEnumField.Year) && 
                (paper.DefaultFields.ContainsKey(DefaultEnumField.Title) || paper.DefaultFields.ContainsKey(DefaultEnumField.Booktitle)))
            {
                return paper.DefaultFields.All(field => _validator.IsFieldValid(field.Value, field.Key));
            }
            else
            {
                return false;
            }
        }
    }
}
