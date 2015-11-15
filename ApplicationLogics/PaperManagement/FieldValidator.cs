using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLogics.PaperManagement
{
    public class FieldValidator
    {
        readonly Dictionary<Field, IFieldChecker> _checkers;
        readonly IFieldChecker _defaultChecker = new FieldChecker();

        public FieldValidator(Dictionary<Field, IFieldChecker> checkers = null)
        {
            throw new NotImplementedException();
        }

        public bool IsFieldValid(string field, Field type)
        {
            throw new NotImplementedException();
        }
    }
}
