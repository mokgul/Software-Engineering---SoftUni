namespace Football_Team_Generator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Player
    {
        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            Name = name;
            Endurance = endurance;
            Sprint = sprint;
            Dribble = dribble;
            Passing = passing;
            Shooting = shooting;
        }
        private string _name;
        private int _endurance;
        private int _sprint;
        private int _dribble;
        private int _passing;
        private int _shooting;

        public string Name 
        {
            get => _name;
            private set
            {
                if (String.IsNullOrEmpty(value) || String.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(ExceptionMessages.INVALID_NAME);
                _name = value;
            }
        }

        public int Endurance
        {
            get => _endurance;
            private set
            {
                if (!ValidStatValue(value))
                    throw new ArgumentException(string.Format(ExceptionMessages.INVALID_STATS_RANGE, "Endurance"));
                _endurance = value;
            }
        }

        public int Sprint
        {
            get => _sprint; 
            private set
            {
                if (!ValidStatValue(value))
                    throw new ArgumentException(string.Format(ExceptionMessages.INVALID_STATS_RANGE, "Sprint"));
                _sprint = value;
            }
        }

        public int Dribble
        {
            get => _dribble; 
            private set
            {
                if (!ValidStatValue(value))
                    throw new ArgumentException(string.Format(ExceptionMessages.INVALID_STATS_RANGE, "Dribble"));
                _dribble = value;
            }
        }

        public int Passing
        {
            get => _passing; 
            private set
            {
                if (!ValidStatValue(value))
                    throw new ArgumentException(string.Format(ExceptionMessages.INVALID_STATS_RANGE, "Passing"));
                _passing = value;
            }
        }

        public int Shooting
        {
            get => _shooting;
            private set
            {
                if (!ValidStatValue(value))
                    throw new ArgumentException(string.Format(ExceptionMessages.INVALID_STATS_RANGE, "Shooting"));
                _shooting = value;
            }
        }

        public int SkillLevel => (int)Math.Round(new List<int> { Endurance, Sprint, Dribble, Passing, Shooting }.Average(s => s));
        private static bool ValidStatValue(int stat) => stat >= 0 && stat <= 100;
    }
}
