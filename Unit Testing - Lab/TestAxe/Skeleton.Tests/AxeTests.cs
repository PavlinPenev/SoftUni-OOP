using System;
using NUnit.Framework;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        private const int AxeAttack = 1;
        private const int AxeDurability = 10;
        private const int BrokenAxeDurability = 0;
        private const int DummyHP = 30;
        private const int DummyXP = 50;

        private Axe testAxe;
        private Dummy testDummy;
        private Axe brokenTestAxe;

        [SetUp]
        public void TestInitialize()
        {
            testAxe = new Axe(AxeAttack, AxeDurability);
            brokenTestAxe = new Axe(AxeAttack,BrokenAxeDurability);
            testDummy = new Dummy(DummyHP, DummyXP);
        }

        [Test]
        public void AxeShouldLoseDurabilityAfterAttack()
        {
            int axeDurabilityPointsInit = testAxe.DurabilityPoints;
            testAxe.Attack(testDummy);
            Assert.AreEqual(axeDurabilityPointsInit - AxeAttack, testAxe.DurabilityPoints, "Axe durability doesn't change after attack");
        }

        [Test]
        public void AxeShouldNotBeAbleToAttackWhileBeingBroken()
        {
            Assert.That(() => brokenTestAxe.Attack(testDummy), Throws.InvalidOperationException, "Axe shouldn't be able to attack while being broken");
        }
    }
}