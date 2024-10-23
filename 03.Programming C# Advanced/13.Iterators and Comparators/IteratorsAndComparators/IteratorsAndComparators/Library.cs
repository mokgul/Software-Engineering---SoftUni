using System.Collections;

namespace IteratorsAndComparators;

public class Library : IEnumerable<Book>
{
    private List<Book> _books;

    public Library(params Book[] books)
    {
        _books = books.ToList();
    }

    public IEnumerator<Book> GetEnumerator()
    {
        return new LibraryIterator(_books);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }


    private class LibraryIterator : IEnumerator<Book>
    {
        private readonly List<Book> _books;
        private int _index;

        public LibraryIterator(List<Book> books)
        {
            this.Reset();
            _books = books.ToList();
            this._books.Sort(new BookComparator());

            _index = -1;
        }

        public bool MoveNext() => ++_index < _books.Count;

        public void Reset() => _index = -1;

        public Book Current => _books[_index];

        object IEnumerator.Current => Current;

        public void Dispose()
        {
        }
    }
}