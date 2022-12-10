
using System;

namespace Skeleton.Tests
{
    using NUnit.Framework;
    [TestFixture]
    public class AxeTests
    {
        private int attackPoints;
        private int durabilityPoints;
        private Axe axe;
        private Dummy dummy;

        [SetUp]
        public void Setup()
        {
            attackPoints = 10;
            durabilityPoints = 10;
            axe = new Axe(attackPoints, durabilityPoints);
            dummy = new Dummy(200, 30);
        }
        [Test]
        public void Test_AxeConstructor_WorkingProperly()
        {
            Assert.AreEqual(attackPoints,axe.AttackPoints);
            Assert.AreEqual(durabilityPoints, axe.DurabilityPoints);
        }

        [Test]
        public void Test_DurabilityPoints_WorkingProperly()
        {
            int attacks = 5;
            for (int i = 1; i <= attacks; i++)
            {
                axe.Attack(dummy);
            }
            Assert.AreEqual(durabilityPoints - attacks,axe.DurabilityPoints);
        }

        [Test]
        public void Test_ThrowException_When_Axe_GetsBroken_WhenDurability_IsZero()
        {
            axe = new Axe(10, 0);
            Assert.Throws<InvalidOperationException>(() =>
            {
                axe.Attack(dummy);
            });
        }
        [Test]
        public void Test_ThrowException_When_Axe_GetsBroken_WhenDurability_IsNegative()
        {
            axe = new Axe(10, -5);
            Assert.Throws<InvalidOperationException>(() =>
            {
                axe.Attack(dummy);
            });
        }
    }
}