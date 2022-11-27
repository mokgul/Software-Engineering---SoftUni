
namespace CollectionHierarchy.Models
{
    using System.Collections.Generic;

    using Interfaces;
    public class AddCollection : IAdd
    {
        private List<string> _items;
        private int _index = -1;

        public AddCollection()
        {
            _items = new List<string>();
        }
        public int Add(string value)
        {
            _index++;
            _items.Add(value);
            return _index;
        }
    }
}
