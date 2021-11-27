using System;
using System.Linq;
using NUnit.Framework;

namespace Database.Tests
{
    [TestFixture]
    public class DatabaseTests
    {
        private const int MaxCapacity = 16;
        private Database _database;


        [SetUp]
        public void Setup()
        {
            int[] toPopulateDB = Enumerable.Range(1, 16).ToArray();
            _database = new Database(toPopulateDB);
        }

        [Test]
        [TestCase(1, 17)]
        public void TestConstructor(int start, int count)
        {
            int[] newPopulate = Enumerable.Range(start, count).ToArray();
            Assert.That(() => _database = new Database(newPopulate), Throws.InvalidOperationException,
                "Constructor with more than 16 elements doesn't throw exception");
        }

        [Test]
        public void TestDBMaxCapacity()
        {
            Assert.That(MaxCapacity == _database.Count, "Populating isn't working correctly");
        }

        [Test]
        public void AddMethodShouldNotAddIfCollectionIsFull()
        {
            Assert.Throws<InvalidOperationException>(() => _database.Add(1), "Collection is full");
        }

        [Test]
        public void RemoveMethodShouldRemoveElementFromTheCollection()
        {
            int initCount = _database.Count - 1;
            _database.Remove();
            Assert.AreEqual(initCount, _database.Count, "Remove Method isn't working correctly");
        }

        [Test]
        public void RemoveMethodShouldNotExecuteWhenCollectionIsEmpty()
        {
            Database emptyDatabase = new Database();
            Assert.Throws<InvalidOperationException>(emptyDatabase.Remove,
                "Remove method tries to remove element even when collection is empty");
        }

        [Test]
        public void FetchShouldReturnArrayCopyOfTheDatabase()
        {
            int[] expectedArray = _database.Fetch();
            Assert.AreEqual(expectedArray.Length, _database.Count, "Fetch Method isn't working correctly");
        }
    }
}