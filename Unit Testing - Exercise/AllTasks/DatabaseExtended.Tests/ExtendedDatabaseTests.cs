using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;


namespace DatabaseExtended.Tests
{
    public class ExtendedDatabaseTests
    {
        private const int MaxCapacity = 16;

        private ExtendedDatabase _people;

        private Person[] arrayPeople =
        {
            new Person(1, "Rosi"),
            new Person(2, "Pavlin"),
            new Person(3, "Veronica"),
            new Person(4, "Emre"),
            new Person(5, "Valentin"),
            new Person(6, "Diqna"),
            new Person(7, "Viktoriq"),
            new Person(8, "Aneliya"),
            new Person(9, "Danail"),
            new Person(10, "Margarita"),
            new Person(11, "Valeri"),
            new Person(12, "Ivaylo"),
            new Person(13, "Neli"),
            new Person(14, "Viki"),
            new Person(15, "Vanessa")
        };

        [Test]
        public void ConstructorShouldWorkCorrectly()
        {
            // Assert.DoesNotThrow(() => new ExtendedDatabase(arrayPeople));
            Person[] people = new Person[15];

            for (int i = 0; i < people.Length; i++)
            {
                people[i] = new Person(1 + i, "name" + i);
            }

            ExtendedDatabase db = new ExtendedDatabase(people);
            Assert.AreEqual(15, db.Count);
        }

        [Test]
        public void ConstructorShouldThrowExceptionWithMoreThan16Elements()
        {
            //List<Person> testPeople = arrayPeople.ToList();
            //testPeople.Add(new Person(16, "Gosho"));
            //testPeople.Add(new Person(17, "Pesho"));
            //Assert.Throws<ArgumentException>(() => _people = new ExtendedDatabase(testPeople.ToArray()));
            Person[] people = new Person[17];

            for (int i = 0; i < 17; i++)
            {
                people[i] = new Person(1 + i, "name" + i);
            }
            Assert.Throws<ArgumentException>(() => new ExtendedDatabase(people));
        }

        [Test]
        public void AddMethodShouldAddElementToTheCollection()
        {
            //_people = new ExtendedDatabase(arrayPeople);
            //Assert.DoesNotThrow(() => _people.Add(new Person(16, "Gosho")));
            Person[] people = new Person[15];

            for (int i = 0; i < 15; i++)
            {
                people[i] = new Person(1 + i, "name" + i);
            }

            ExtendedDatabase db = new ExtendedDatabase(people);
            Person toAdd = new Person(33474743, "Stamat");
            db.Add(toAdd);

            Assert.AreEqual(15 + 1, db.Count);
        }

        [Test]
        public void AddMethodShouldNotAddIfCollectionIsFull()
        {
            Person[] people = new Person[16];

            for (int i = 0; i < 16; i++)
            {
                people[i] = new Person(1 + i, "name" + i);
            }

            ExtendedDatabase db = new ExtendedDatabase(people);
            Assert.Throws<InvalidOperationException>(() => db.Add(new Person(17, "Pesho")), "Collection is full");
        }

        [Test]
        public void AddMethodShouldCheckForUsernameUniqueness()
        {
            _people = new ExtendedDatabase(arrayPeople);
            Assert.Throws<InvalidOperationException>(() => _people.Add(new Person(16, "Rosi")));
        }

        [Test]
        public void AddMethodShouldCheckForIdUniqueness()
        {
            _people = new ExtendedDatabase(arrayPeople);
            Assert.Throws<InvalidOperationException>(() => _people.Add(new Person(5, "Gosho")));
        }

        [Test]
        public void RemoveMethodShouldRemoveElementFromTheCollection()
        {
            int initCount = _people.Count - 1;
            _people.Remove();
            Assert.AreEqual(initCount, _people.Count);
        }

        [Test]
        public void RemoveMethodShouldNotExecuteWhenCollectionIsEmpty()
        {
            ExtendedDatabase emptyDatabase = new ExtendedDatabase();
            Assert.Throws<InvalidOperationException>(emptyDatabase.Remove);
        }

        [Test]
        [TestCase("Vanessa")]
        public void FindByUsernameShouldFindPersonByUsername(string name)
        {
            Person result = _people.FindByUsername(name);
            Assert.AreEqual(name, result.UserName);
        }

        [Test]
        public void FindByUsernameShouldThrowInvalidOperationExceptionIfUsernameDoesNotExist()
        {
            string testUsername = "SluchainoIme";
            Assert.Throws<InvalidOperationException>(() => _people.FindByUsername(testUsername));
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void FindByUsernameShouldThrowArgumentNullExceptionIfUsernameIsNullOrEmpty(string testUsername)
        {
            Assert.Throws<ArgumentNullException>(() => _people.FindByUsername(testUsername));
        }

        [Test]
        [TestCase(15)]
        public void FindByIdShouldReturnPersonById(long id)
        {
            Person result = _people.FindById(id);
            Assert.AreEqual(id, result.Id);
        }

        [Test]
        public void FindByIdShouldThrowInvalidOperationExceptionIfIdDoesNotExist()
        {
            Assert.Throws<InvalidOperationException>(() => _people.FindById(20));
        }

        [Test]
        public void FindByIdShouldThrowArgumentOutOfRangeExceptionForNegativeValues()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _people.FindById(-23451343513));
        }
    }
}