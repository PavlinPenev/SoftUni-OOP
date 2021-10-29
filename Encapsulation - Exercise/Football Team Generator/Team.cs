using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeamGenerator
{
    public class Team
    {
        private string name;
        private IList<Player> players;

        public Team(string name)
        {
            Name = name;
            players = new List<Player>();
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }

                name = value;
            }
        }

        private IList<Player> Players
        {
            get { return players; }
            set { players = value; }
        }

        public int Rating
        {
            get { return CalculateTeamRating(); }
        }

        private int CalculateTeamRating()
        {
            if (players.Any())
            {
                return (int)Math.Round(players.Average(p => p.Stats));
            }
            else
            {
                return 0;
            }
        }

        public void AddPlayer(Player player)
        {
            players.Add(player);
        }

        public void RemovePlayer(string player)
        {
            if (!players.Any(p => p.Name == player))
            {
                throw new ArgumentException($"Player {player} is not in {Name} team. ");
            }

            Player pl = players.FirstOrDefault(p => p.Name == player);
            players.Remove(pl);
        }

        public override string ToString()
        {
            return $"{name} - {Rating}";
        }
    }
}