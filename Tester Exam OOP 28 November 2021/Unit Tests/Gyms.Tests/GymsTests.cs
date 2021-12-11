using System;
using NUnit.Framework;

namespace Gyms.Tests
{
    public class GymsTests
    {
        private Athlete _testAthlete;

        private Gym _testGym;
        // Implemtn unit tests here
        [SetUp]
        public void Setup()
        {
            _testAthlete = new Athlete("Pavlin");
            _testGym = new Gym("MyGym", 1);
        }
        //test constructors
        [Test]
        public void TestAthleteConstructor()
        {
            Assert.AreEqual("Pavlin", _testAthlete.FullName);
            Assert.AreEqual(false, _testAthlete.IsInjured);
        }

        [Test]
        public void TestGymConstructor()
        {
            Assert.AreEqual("MyGym", _testGym.Name);
            Assert.AreEqual(1, _testGym.Capacity);
            _testGym.AddAthlete(_testAthlete);
            Assert.That(_testGym.Count > 0);
        }

        //test properties
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void TestGymNameSetter(string testName)
        {
            Assert.Throws<ArgumentNullException>(() => new Gym(testName, 10));
        }

        [Test]
        [TestCase(-10)]
        [TestCase(-6)]
        public void TestCapacitySetter(int testCap)
        {
            Assert.Throws<ArgumentException>(() => new Gym("MyGym", testCap));
        }

        //test methods
        [Test]
        public void TestAddAthleteMethodShouldThrowExceptionIfGymIsFull()
        {
            _testGym.AddAthlete(_testAthlete);
            Assert.Throws<InvalidOperationException>(() => _testGym.AddAthlete(new Athlete("Viki")));
        }

        [Test]
        public void TestRemoveMethodWorkingCorrectly()
        {
            _testGym.AddAthlete(_testAthlete);
            _testGym.RemoveAthlete("Pavlin");
            Assert.AreEqual(0, _testGym.Count);
        }

        [Test]
        public void TestRemoveMethodShouldThrowExceptionIfAthleteNotFound()
        {
            _testGym.AddAthlete(_testAthlete);
            Assert.Throws<InvalidOperationException>(() => _testGym.RemoveAthlete("Viki"));
        }

        [Test]
        public void TestInjureAthleteWorkingCorrectly()
        {
            _testGym.AddAthlete(_testAthlete);
            _testGym.InjureAthlete("Pavlin");
            Assert.AreEqual(true, _testAthlete.IsInjured);
            Assert.AreEqual(_testAthlete, _testGym.InjureAthlete("Pavlin"));
        }

        [Test]
        public void TestInjureAthleteShouldThrowExceptionIfAthleteNotFound()
        {
            _testGym.AddAthlete(_testAthlete);
            Assert.Throws<InvalidOperationException>(() => _testGym.InjureAthlete("Viki"));
        }

        [Test]
        public void TestReport()
        {
            Gym newTestGym = new Gym("MyGym", 2);
            newTestGym.AddAthlete(_testAthlete);
            newTestGym.AddAthlete(new Athlete("Viki"));
            Assert.AreEqual("Active athletes at MyGym: Pavlin, Viki", newTestGym.Report());
        }
    }
}
