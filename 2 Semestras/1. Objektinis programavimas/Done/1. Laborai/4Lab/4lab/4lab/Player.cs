using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _4lab
{
    public class Player: IComparable<Player>, IEquatable<Player>
    {
        public string Team { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public int MinutesPlayed { get; set; }
        public int PointsGained { get; set; }
        public int MistakesMade { get; set; }
        public string Position { get; set; }

        /// <summary>
        /// Player object constructor
        /// </summary>
        /// <param name="team"></param>
        /// <param name="lastName"></param>
        /// <param name="name"></param>
        /// <param name="minutesPlayed"></param>
        /// <param name="pointsGained"></param>
        /// <param name="mistakesMade"></param>
        public Player(string team, string lastName, string name, int minutesPlayed, int pointsGained, int mistakesMade)
        {
            Team = team;
            LastName = lastName;
            Name = name;
            MinutesPlayed = minutesPlayed;
            PointsGained = pointsGained;
            MistakesMade = mistakesMade;
        }
        /// <summary>
        /// playr object constructor
        /// </summary>
        /// <param name="team"></param>
        /// <param name="lastName"></param>
        /// <param name="name"></param>
        /// <param name="position"></param>
        public Player(string team, string lastName, string name, string position)
        {
            Team = team;
            LastName = lastName;
            Name = name;
            Position = position;
        }
        /// <summary>
        /// sets the postion from playerinfo file
        /// </summary>
        /// <param name="position"></param>
        public void SetPosition(string position)
        {
            Position = position;
        }
        /// <summary>
        /// compares players by points, minutes played and mistakes made
        /// </summary>
        /// <param name="other">other player</param>
        /// <returns>integer</returns>
        public int CompareTo(Player other)
        {
            if (this == null)
                return 0;
            if (other == null)
                return 1;
            if(PointsGained == other.PointsGained)
            {
                if (MinutesPlayed == other.MinutesPlayed)
                    return other.MistakesMade.CompareTo(MistakesMade);
                return other.MinutesPlayed.CompareTo(MinutesPlayed);
            }
            return this.PointsGained.CompareTo(other.PointsGained);
        }
        /// <summary>
        /// compares two players
        /// </summary>
        /// <param name="other">otehr player</param>
        /// <returns>true or false</returns>
        public bool Equals(Player other)
        {
            if (other == null)
                return false;
            if (LastName == other.LastName && Name == other.Name && Team == other.Team)
                return true;
            return false;
        }
        /// <summary>
        /// Prinst out player information in a fromated string 
        /// </summary>
        /// <returns>formated string </returns>
        public override string ToString()
        {
            return String.Format("{0, 15} | {1, 15} | {2, 15} | {3, 15} | {4, 15} | {5, 15} | {6, 15} |", Team, LastName, Name, Position, PointsGained, MinutesPlayed, MistakesMade);
        }
        /// <summary>
        /// prints the header of a table for the player object
        /// </summary>
        /// <returns>formated header</returns>
        public string Header()
        {
            return String.Format("{0, 15} | {1, 15} | {2, 15} | {3, 15} | {4, 15} | {5, 15} | {6, 15} |", "Team", "LastName", "Name", "Position", "PointsGained", "MinutesPlayed", "MistakesMade");
        }
    }
}