namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;

    [TestFixture]
    public class ArenaTests
    {
        private Arena arena;

        [SetUp]
        public void SetUp()
        {
            arena = new Arena();
        }

        [Test]
        public void ConstructorInitializeCollection()
        {
            Assert.IsNotNull(arena.Warriors);
        }

        [Test]
        public void CountReturnsProperValue()
        {
            int expected = 3;
            for (int i = 0; i < expected; i++)
            {
                arena.Enroll(new Warrior
                (
                    "name" + i.ToString(),
                    i + 20,
                    i + 100
                ));
            }
            int actual = arena.Count;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void EnrollMethodAddsProperlyWarriorIfDoesntExist()
        {
            Warrior warrior = new Warrior("Jack", 25, 100);
            arena.Enroll(warrior);
            Assert.IsTrue(arena.Warriors.Contains(warrior));
        }

        [Test]
        public void EnrollMethodShouldThrowExceptionWhenAddingExistingWarrior()
        {
            Warrior warrior = new Warrior("Jack", 25, 100);
            arena.Enroll(warrior);
            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Enroll(warrior);
            });
        }

        [TestCase("Peter")]
        [TestCase("Kurt")]
        public void FightMethodShouldThrowExceptionWithNoNExistingWarrior(string name)
        {
            arena.Enroll(new Warrior("Jack", 25, 100));
            arena.Enroll(new Warrior("John", 25, 100));
            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Fight(name, "Jack");
            });
            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Fight("Jack", name);
            });
        }

        [Test]
        public void FightMethodWorksProperly()
        {
            Warrior warrior = new Warrior("Jack", 25, 100);
            Warrior warrior2 = new Warrior("John", 25, 100);
            arena.Enroll(warrior);
            arena.Enroll(warrior2);

            int expectedWarrior2HP = warrior2.HP - warrior.Damage;
            arena.Fight("Jack", "John");
            int actualWarrior2HP = warrior2.HP;
            Assert.AreEqual(expectedWarrior2HP,actualWarrior2HP);
        }
    }
}
