using System;
using NUnit.Framework;

namespace Tests
{
    public class WarriorTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ConstructorShouldWorkCorrectly()
        {
            Warrior warrior = new Warrior("test", 25, 50);
            var expectedName = "test";
            var expectedDmg = 25;
            var expectedHp = 50;
            Assert.AreEqual(expectedName, warrior.Name);
            Assert.AreEqual(expectedDmg, warrior.Damage);
            Assert.AreEqual(expectedHp, warrior.HP);
        }
 
        [Test]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("  ")]
        [TestCase("   ")]
        [TestCase(null)]
        public void WarriorShouldThrowExceptionIfNameIsNullEmptyOrWhiteSpace(string name)
        {
            Assert.Throws<ArgumentException>
                (() => new Warrior(name, 6, 6));
        }
 
        [Test]
        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(-11)]
        [TestCase(-22)]
        public void WarriorShouldThrowExceptionIfDamageZeroOrNegative(int damage)
        {
            Assert.Throws<ArgumentException>
                (() => new Warrior("Pesho", damage, 6));
        }
 
        [Test]
        [TestCase(-1)]
        [TestCase(-2)]
        [TestCase(-11)]
        [TestCase(-22)]
        public void WarriorShouldThrowExceptionIfHpNegative(int hp)
        {
            Assert.Throws<ArgumentException>
                (() => new Warrior("Gosho", 11, hp));
        }
 
        [Test]
        [TestCase(28)]
        [TestCase(29)]
        [TestCase(20)]
        [TestCase(10)]
        [TestCase(30)]
        public void WarriorShouldThrowExceptionIfWarriorCantAttackWithLessThan30Hp(int hp)
        {
            Warrior attacker = new Warrior("Bai Gosho", 10, hp);
            Warrior defender = new Warrior("Bai Pesho", 10, 40);
 
            Assert.Throws<InvalidOperationException>
                (() => attacker.Attack(defender));
 
            Assert.Throws<InvalidOperationException>
                (() => attacker.Attack(defender));
        }
 
        [Test]
        [TestCase(28)]
        [TestCase(29)]
        [TestCase(20)]
        [TestCase(10)]
        [TestCase(30)]
        public void WarriorShouldThrowExceptionIfWarriorCantBeAttackedWhenLessThan30Hp(int hp)
        {
            Warrior attacker = new Warrior("Bai Gosho", 10, 40);
            Warrior defender = new Warrior("Bai Pesho", 10, hp);
 
            Assert.Throws<InvalidOperationException>
                (() => attacker.Attack(defender));
        }
 
        [Test]
        [TestCase(58)]
        [TestCase(59)]
        [TestCase(50)]
        [TestCase(41)]
        public void WarriorShouldThrowExceptionIfAtackingStrongerOpponent(int dmg)
        {
            Warrior attacker = new Warrior("Bai Gosho", 10, 40);
            Warrior defender = new Warrior("Bai Pesho", dmg, 40);
 
            Assert.Throws<InvalidOperationException>
                (() => attacker.Attack(defender));
        }
 
        [Test]
        [TestCase(22, 40)]
        [TestCase(49, 40)]
        [TestCase(50, 40)]
        public void AttackMethodWorksCorrectly(int dmg, int hp)
        {
            Warrior attacker = new Warrior("Gosho", dmg, hp);
            Warrior defender = new Warrior("Pesho", 20, 50);
 
            attacker.Attack(defender);
 
            int expected = 50 - dmg;
            int actual = defender.HP;
 
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        [TestCase(51, 40)]
        [TestCase(52, 40)]
        [TestCase(120, 40)]
        public void AtackMethodWorksCorrectlyWhenAttackingWithMoreDamage(int dmg, int hp)
        {
            Warrior attacker = new Warrior("Gosho", dmg, hp);
            Warrior defender = new Warrior("Pesho", 20, 50);
 
            attacker.Attack(defender);
 
            int expected = 0;
            int actual = defender.HP;
 
            Assert.AreEqual(expected, actual);
        }
    }
}