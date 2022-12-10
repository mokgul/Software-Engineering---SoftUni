using System;
using NUnit.Framework;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        private Axe axe;
        private Dummy dummy;
        private Dummy dead;
        private int health;
        private int experience = 15;

        [SetUp]
        public void Setup()
        {
            health = 100;
            dummy = new Dummy(health, experience);
            dead = new Dummy(health, experience);
            dead.TakeAttack(health*2);
            axe = new Axe(10, 50);
        }

        [Test]
        public void Test_Dummy_Constructor_WorkingProperly()
        {
            Assert.AreEqual(health,dummy.Health);
        }

        [Test]
        public void Test_TakeAttack_ThrowsException_WhenDummyHealth_IsZero()
        {
            dummy.TakeAttack(health);
            Assert.Throws<InvalidOperationException>(() =>
            {
                dummy.TakeAttack(1);
            });
        }

        [Test]
        public void Test_TakeAttack_ThrowsException_WhenDummy_IsDead()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                dead.TakeAttack(axe.AttackPoints);
            });
        }

        [Test]
        public void Test_TakeAttack_WorksProperly()
        {
            dummy.TakeAttack(axe.AttackPoints);
            Assert.AreEqual(health - axe.AttackPoints,dummy.Health);
        }

        [Test]
        public void Test_GiveExp_ThrowsException_WhenDummy_IsAlive()
        {
            Assert.Throws<InvalidOperationException>((() =>
            {
                dummy.GiveExperience();
            }));
        }

        [Test]
        public void Test_GiveExp_WhenDummy_IsDead()
        {
            Assert.AreEqual(experience,dead.GiveExperience());
        }

        [Test]
        public void Test_Dummy_IsDead_Health_IsZero()
        {
            dummy.TakeAttack(health);
            Assert.IsTrue(0 == dummy.Health);
            
        }

        [Test]
        public void Test_Dummy_IsDead_Health_IsNegative()
        {
            dummy.TakeAttack(health * 2);
            Assert.IsTrue( 0 > dummy.Health);
        }
    }
}