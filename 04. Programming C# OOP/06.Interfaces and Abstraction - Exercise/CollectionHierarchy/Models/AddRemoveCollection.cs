
namespace CollectionHierarchy.Models
{
    using System.Linq;
    using System.Collections.Generic;

    using Interfaces;
    public class AddRemoveCollection : IRemove
    {
        private List<string> _items;

        public AddRemoveCollection()
        {
            _items = new List<string>();
        }
        public int Add(string value)
        {
            _items.Insert(0, value);
            return 0;
        }

        public string Remove()
        {
            string item = _items.Last();
            _items = _items.SkipLast(1).ToList();
            return item;
        }
    }
}
