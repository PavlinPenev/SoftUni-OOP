using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Tests
{
    public class ArenaTests
    {
        private Arena _arena;
        [SetUp]
        public void Setup()
        {
            _arena = new Arena();
            Warrior testWarrior = new Warrior("Pesho", 10, 100);
            _arena.Enroll(testWarrior);
        }

        [Test] //Test Constructors
        public void ConstructorShouldWorkCorrectlyAndReturnAnInitializedEmptyWarriorCollection()
        {
            Arena newArena = new Arena();
            List<Warrior> list = new List<Warrior>();
            CollectionAssert.AreEqual(list, newArena.Warriors);
        }

        [Test] //Test Properties(getters and setters)
        public void CountShouldReturnTheWarriorCollectionCount()
        {
            Assert.AreEqual(1, _arena.Count);
        }

        [Test]
        public void WarriorsShouldReturnListOfEnrolledWarriors()
        {
            List<Warrior> testWarriors = _arena.Warriors.ToList();
            CollectionAssert.AreEqual(testWarriors, _arena.Warriors);
        }

        [Test] //Test Methods and Validations
        public void EnrollMethodShouldEnrollWarriorsInTheArenaCollection()
        {
            _arena.Enroll(new Warrior("Gosho", 5, 50));
            Assert.AreEqual(2, _arena.Warriors.Count);
        }

        [Test]
        public void EnrollMethodReturnListValues()
        {
            _arena.Enroll(new Warrior("Gosho", 5, 50));
            List<Warrior> warriors = new List<Warrior>();
            foreach (var arenaWarrior in _arena.Warriors)
            {
                warriors.Add(arenaWarrior);
            }
            CollectionAssert.AreEqual(warriors, _arena.Warriors);
        }

        [Test]
        public void EnrollMethodShouldThrowExceptionIfThereIsEnrolledWarriorWithTheSameName()
        {
            Assert.Throws<InvalidOperationException>(() => _arena.Enroll(new Warrior("Pesho", 14, 95)));
        }

        [Test]
        public void FightShouldWorkCorrectly()
        {
            _arena.Enroll(new Warrior("Gosho", 5, 50));
            _arena.Fight("Gosho", "Pesho");
            Warrior peshoWarrior = _arena.Warriors.First(w => w.Name == "Pesho");
            Warrior goshoWarrior = _arena.Warriors.First(w => w.Name == "Gosho");
            Assert.AreEqual(95, peshoWarrior.HP);
            Assert.AreEqual(40, goshoWarrior.HP);
        }

        [Test]
        public void FightShouldThrowExceptionWhenADefenderIsMissingFromTheCollection()
        {
            Assert.Throws<InvalidOperationException>(() => _arena.Fight("Pesho", "RandomFloorClothPerson"));
        }

        [Test]
        public void FightShouldThrowExceptionWhenAnAttackerIsMissingFromTheCollection()
        {
            Assert.Throws<InvalidOperationException>(() => _arena.Fight("RandomFloorClothPerson", "Pesho"));
        }

        [Test]
        public void FightShouldThrowExceptionWhenBothWarriorsAreMissingFromTheCollection()
        {
            Assert.Throws<InvalidOperationException>(() => _arena.Fight("RandomFloorClothPerson", "SecondFloorClothPerson"));
        }
    }
}
