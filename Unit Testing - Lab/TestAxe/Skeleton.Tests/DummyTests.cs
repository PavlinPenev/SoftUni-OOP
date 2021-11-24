using NUnit.Framework;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        private const int TakeAttack = 1;
        private const int AliveDummyHP = 100;
        private const int DummyXP = 30;
        private const int DeadDummyHP = 0;

        private Dummy testDeadDummy;
        private Dummy testAliveDummy;

        [SetUp]
        public void TestInitialize()
        {
            testDeadDummy = new Dummy(DeadDummyHP, DummyXP);
            testAliveDummy = new Dummy(AliveDummyHP, DummyXP);
        }

        [Test]
        public void DummyShouldLoseHPWhenAttacked()
        {
            int initDummyHP = AliveDummyHP;
            testAliveDummy.TakeAttack(TakeAttack);
            Assert.AreEqual(initDummyHP - TakeAttack, testAliveDummy.Health, "Dummy doesn't lose HP when attacked");
        }

        [Test]
        public void DeadDummyShouldThrowExceptionWhenAttacked()
        {
            Assert.That(() => testDeadDummy.TakeAttack(TakeAttack),Throws.InvalidOperationException, "Dead dummy can't be attacked");
        }

        [Test]
        public void DeadDummyShouldGiveXP()
        {
            Assert.That(() => testDeadDummy.GiveExperience(), Is.EqualTo(DummyXP),"Dead dummy doesn't give xp");
        }

        [Test]
        public void AliveDummyShouldNotGiveXP()
        {
            Assert.That(() => testAliveDummy.GiveExperience(), Throws.InvalidOperationException, "Alive dummy gives xp");
        }
    }
}