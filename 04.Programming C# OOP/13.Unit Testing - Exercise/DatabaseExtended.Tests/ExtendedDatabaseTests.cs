namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private Database _database;

        [SetUp]
        public void SetUp()
        {
            this._database = new Database(new Person[]
            {
                 new Person(123131, "Peter"),
                 new Person(123555, "John")
            });
        }

        [Test]
        public void CanCreateDatabase()
        {
            Assert.IsInstanceOf<Database>(_database);
        }

        [Test]
        public void CountIsCorrectAfterConstructor()
        {
            int expectedCount = 2;
            int actualCount = _database.Count;
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void CountReturnsProperValue()
        {
            Person[] range = new Person[]
            {
                 new Person(123131, "Peter"),
                 new Person(123555, "John")
            };
            Database db = new Database(range);

            int expectedCount = range.Length;
            int actualCount = _database.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void AddRangeShouldThrowExceptionWhenArrayIsMoreThan16()
        {
            Person[] invalid = new Person[17];
            Assert.Throws<ArgumentException>(() =>
            {
                Database db = new Database(invalid);
            });
        }

        [Test]
        public void AddMethodWorksProperly()
        {
            Person person = new Person(123123, "Jake");
            int expectedCount = _database.Count + 1;
            _database.Add(person);
            int actualCount = _database.Count;

            Assert.AreEqual(expectedCount, actualCount);

        }

        [Test]
        public void AddMethodShouldThrowExceptionWhenCapacityIsMoreThan16()
        {
            for (int i = 2; i < 16; i++)
            {
                _database.Add(new Person(1234 + i, "123" + i.ToString()));
            }
            Assert.Throws<InvalidOperationException>(() =>
            {
                _database.Add(new Person(111111, "11111"));
            });
        }

        [Test]
        public void AddMethodThrowsExceptionWhenAddingExistingUsername()
        {
            Person person = new Person(1231231, "Peter");
            Assert.Throws<InvalidOperationException>(() =>
            {
                _database.Add(person);
            });
        }

        [Test]
        public void AddMethodThrowsExceptionWhenAddingExistingID()
        {
            Person person = new Person(123131, "Jake");
            Assert.Throws<InvalidOperationException>(() =>
            {
                _database.Add(person);
            });
        }

        [Test]
        public void RemoveMethodWorksCorrectly()
        {
            int expectedCount = _database.Count - 1;
            _database.Remove();
            int actualCount = _database.Count;
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void RemoveMethodShouldThrowExceptionWhenCollectionIsEmpty()
        {
            _database.Remove();
            _database.Remove();
            Assert.Throws<InvalidOperationException>(() => { _database.Remove(); });
        }

        [Test]
        public void FindUserByNameMethodWorksCorrectly()
        {
            Person person = new Person(123555, "John");
            Person expected = person;
            Person actual = _database.FindByUsername("John");
            Assert.AreEqual(expected.UserName, actual.UserName);
            Assert.AreEqual(expected.Id, actual.Id);
        }

        [Test]
        public void FindUserByNameShouldThrowExceptionWithNullParameter()
        {
            Assert.Throws<ArgumentNullException>(() => _database.FindByUsername(null));
        }

        [Test]
        public void FindUserByNameShouldThrowExceptionWhenUserDoesntExist()
        {
            Assert.Throws<InvalidOperationException>(() => _database.FindByUsername("non existing user"));
        }

        [Test]
        public void FindUserByIDMethodWorksCorrectly()
        {
            Person person = new Person(123555, "John");
            Person expected = person;
            Person actual = _database.FindById(123555);
            Assert.AreEqual(expected.UserName, actual.UserName);
            Assert.AreEqual(expected.Id, actual.Id);
        }

        [Test]
        public void FindUserByIdShouldThrowExceptionWithNegativeParameter()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                _database.FindById(-200);
            });
        }

        [Test]
        public void FindUserByIdShouldThrowExceptionWhenUserDoesntExist()
        {
            Assert.Throws<InvalidOperationException>(() => _database.FindById(20000));
        }
    }
}