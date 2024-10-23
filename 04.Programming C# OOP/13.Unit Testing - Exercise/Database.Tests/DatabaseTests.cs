namespace Database.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;

    [TestFixture]
    public class DatabaseTests
    {
        private Database _database;

        [SetUp]
        public void SetUp()
        {
            this._database = new Database();
        }

        [TestCase(new int[] { })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void ConstructorShouldReturnCorrectCount(int[] data)
        {
            Database db = new Database(data);
            int expectedCount = data.Length;
            int actualCount = db.Count;
            Assert.AreEqual(expectedCount, actualCount);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 })]
        public void ConstructorShouldThrowExceptionIfMoreThan16(int[] data)
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                Database db = new Database(data);
            }
            );
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 })]
        public void ConstructorAddsCorrectData(int[] data)
        {
            Database db = new Database(data);
            int[] expected = data;
            int[] actual = db.Fetch();
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void MethodCountReturnsCorrectValue(int[] data)
        {
            Database db = new Database(data);
            int expectedCount = data.Length;
            int actualCount = db.Count;
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void AddMethodShouldAddCorrectData()
        {
            int[] data = { 1, 2, 3, 4, 5 };
            for (int i = 0; i < data.Length; i++)
            {
                _database.Add(data[i]);
            }
            int[] expected = data;
            int[] actual = _database.Fetch();
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void AddMethodShouldThrowExceptionWhenAddingMoreThan16Elements(int[] data)
        {
            Database db = new Database(data);
            Assert.Throws<InvalidOperationException>(()=>
            {
                db.Add(1);
            });
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 })]
        public void CountIsCorrectAfterRemoveMethod(int[] data)
        {
            int removeCount = 3 ;
            Database db = new Database(data);
            for(int i = 0; i < removeCount; i++)
                db.Remove();
            int expected = data.Length - removeCount;
            int actual = db.Count;
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void DataShouldBeCorrectAfterRemoveMethod(int[] data)
        {
            int removeCount = 3 ;
            Database db = new Database(data);
            for(int i = 0; i < removeCount; i++)
                db.Remove();
            int[] expected = data.SkipLast(removeCount).ToArray();
            int[] actual = db.Fetch();
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void RemoveShouldThrowExceptinoWhenCollectionEmpty()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                _database.Remove();
            });
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void FetchShouldReturnCorrectData(int[] data)
        {
            Database db = new Database(data);
            int[] expected = data;
            int[] actual = db.Fetch();
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
