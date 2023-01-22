using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football_Team_Generator
{
    public class ExceptionMessages
    {
        public static string INVALID_NAME = "A name should not be empty.";
        public static string INVALID_STATS_RANGE = "{0} should be between 0 and 100.";
        public static string PLAYER_NOT_IN_TEAM = "Player {0} is not in {1} team.";
        public static string TEAM_DOES_NOT_EXIST = "Team {0} does not exist.";
    }
}
