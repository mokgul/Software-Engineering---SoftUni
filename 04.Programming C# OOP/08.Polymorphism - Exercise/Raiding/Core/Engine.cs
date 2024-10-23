
using System;
using System.Linq;

namespace Raiding.Core
{
    using System.Collections.Generic;

    using Interfaces;
    using IO.Interfaces;
    using Factories;
    using Factories.Interfaces;
    using Models.Interfaces;
    public class Engine : IEngine
    {
        private readonly IReader _reader;
        private readonly IWriter _writer;

        private readonly ICollection<IBaseHero> _raid;
        private readonly IBaseHeroFactory _heroFactory;

        private Engine()
        {
            _raid = new List<IBaseHero>();
            _heroFactory = new BaseHeroFactory();
        }
        public Engine(IReader reader, IWriter writer) : this()
        {
            _reader = reader;
            _writer = writer;
        }
        public void Run()
        {
            int n = int.Parse(_reader.ReadLine());
            while (_raid.Count < n)
            {
                try
                {
                    _raid.Add(CreateBaseHeroFactory());
                }
                catch (Exception ith)
                {
                    Console.WriteLine(ith.Message);
                }
            }
            int bossPower = int.Parse(_reader.ReadLine());
            _writer.WriteLine(CastAbilities(bossPower));
        }

        private string CastAbilities(int bossPower)
        {
            int totalPower = _raid.Sum(hero => hero.Power);

            foreach (var hero in _raid)
                _writer.WriteLine(hero.CastAbility());

            return (totalPower >= bossPower) ? "Victory!" : "Defeat...";
        }

        private IBaseHero CreateBaseHeroFactory()
        {
            string name = _reader.ReadLine();
            string type = _reader.ReadLine();
            IBaseHero hero = _heroFactory.CreateHero(type, name);
            return hero;
        }
    }
}
