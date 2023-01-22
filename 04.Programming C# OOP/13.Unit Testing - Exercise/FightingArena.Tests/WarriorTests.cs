namespace FightingArena.Tests
{
    using Newtonsoft.Json.Linq;
    using NUnit.Framework;
    using System;
    using System.Xml.Linq;

    [TestFixture]
    public class WarriorTests
    {
        private Warrior warrior;

        [SetUp]
        public void SetUp()
        {
            warrior = new Warrior("Jack", 25, 100);
        }

        [Test]
        public void ConstructorInitializeWarriorName()
        {
            string expected = "Jack";
            string actual = warrior.Name;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ConstructorInitializeWarriorDamage()
        {
            int expected = 25;
            int actual = warrior.Damage;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ConstructorInitializeWarriorHP()
        {
            int expected = 100;
            int actual = warrior.HP;
            Assert.AreEqual(expected, actual);
        }

        [TestCase(null)]
        [TestCase("")]
        public void NameSetterShouldThrowExceptionWithInvalidName(string name)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior(name, 25, 100);
            });
        }

        [TestCase(-10)]
        [TestCase(-1)]
        [TestCase(0)]
        public void DamageSetterShouldThrowExceptionWithNonPositiveValue(int value)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior("Jack", value, 100);
            });
        }

        [TestCase(-10)]
        [TestCase(-1)]
        public void HPSetterShouldThrowExceptionWithNegativeValue(int value)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior("Jack", 25, value);
            });
        }

        [Test]
        public void AttackMethodUpdatesWarriorValue()
        {
            Warrior second = new Warrior("John", 25, 100);
            int expected = warrior.HP - second.Damage;
            warrior.Attack(second);
            int actual = warrior.HP;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void AttackMethodUpdatesEnemyHPNoKill()
        {
            Warrior second = new Warrior("John", 25, 100);
            int expected = second.HP - warrior.Damage;
            warrior.Attack(second);
            int actual = second.HP;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void AttackMethodUpdatesEnemyHPWhenKilled()
        {
            Warrior second = new Warrior("John", 250, 100);
            int expected = 0;
            second.Attack(warrior);
            int actual = warrior.HP;
            Assert.AreEqual(expected, actual);
        }

        [TestCase(10)]
        [TestCase(20)]
        [TestCase(30)]
        public void AttackMethodShouldThrowExceptionWhenAttackingWithLowHP(int lowHP)
        {
            Warrior second = new Warrior("John", 25, lowHP);
            Assert.Throws<InvalidOperationException>(() =>
            {
                second.Attack(warrior);
            });
        }

        [TestCase(10)]
        [TestCase(20)]
        [TestCase(30)]
        public void AttackMethodShouldThrowExceptionWhenAttackingLowHPWarrior(int lowHP)
        {
            Warrior second = new Warrior("John", 25, lowHP);
            Assert.Throws<InvalidOperationException>(() =>
            {
                warrior.Attack(second);
            });
        }

        [TestCase(101)]
        [TestCase(201)]
        [TestCase(301)]
        public void AttackMethodShouldThrowExceptionWhenAttackingTooStrongEnemy(int tooStrongEnemy)
        {
            Warrior second = new Warrior("John", tooStrongEnemy, 100);
            Assert.Throws<InvalidOperationException>(() =>
            {
                warrior.Attack(second);
            });
        }
    }
}