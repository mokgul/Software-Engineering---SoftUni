namespace Football_Team_Generator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Team
    {
        public Team(string name)
        {
            Name = name;
            _players = new List<Player>();
        }

        private double _rating;
        private string _name;
        private List<Player> _players;

        public string Name
        {
            get => _name;
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(ExceptionMessages.INVALID_NAME);
                _name = value;
            }
        }

        private double Rating()
        {
            if (_players.Count <= 0) return 0;
         return (int)Math.Round(_players.Average(s => s.SkillLevel));
        }

        public void AddPlayer(string teamName, Player player) => _players.Add(player);

        public void RemovePlayer(string teamName, string player)
        {
            Player current = _players.FirstOrDefault(p => p.Name == player);
            if(teamName != Name) return;
            if(_players.Count <= 0) return;
            if(current == null)
                throw new ArgumentException(string.Format(ExceptionMessages.PLAYER_NOT_IN_TEAM,player,Name));
            _players.Remove(current);
        }

        public override string ToString()
            => $"{Name} - {Rating()}";
    }
}
