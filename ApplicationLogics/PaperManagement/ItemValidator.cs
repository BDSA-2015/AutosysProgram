using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLogics.PaperManagement
{
    public class ItemValidator
    {
        readonly Dictionary<Item, IItemChecker> _checkers;
        readonly ItemChecker _defaultChecker = new ItemChecker();

        public ItemValidator(Dictionary<Item, IItemChecker> checkers = null)
        {
        }

        public bool IsItemValid(Item item)
        {
            throw new NotImplementedException();
        }
    }
}
