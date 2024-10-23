
using System.Collections.Generic;

namespace CollectionHierarchy.Models
{
    using System.Linq;
    using Interfaces;
    public class MyList : IUsed
    {
        private List<string> _items;

        public MyList()
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
            string item = _items.First();
            _items = _items.Skip(1).ToList();
            return item;
        }

        public int Count()
        {
            return _items.Count;
        }
    }
}
