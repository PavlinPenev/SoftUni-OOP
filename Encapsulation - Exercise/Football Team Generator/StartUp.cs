using System;
using System.Collections.Generic;
using System.Linq;
using FootballTeamGenerator;


public class StartUp
{
    public static void Main()
    {
        List<Team> teams = new List<Team>();

        string input;

        while ((input = Console.ReadLine()) != "END")
        {
            string[] tokens = input.Split(';', StringSplitOptions.RemoveEmptyEntries);
            string command = tokens[0];
            try
            {
                switch (command)
                {
                    case "Team":
                        teams.Add(new Team(tokens[1]));
                        break;

                    case "Add":
                        if (!teams.Any(t => t.Name == tokens[1]))
                        {
                            throw new ArgumentException($"Team {tokens[1]} does not exist.");
                        }
                        else
                        {
                            Team currentTeam = teams.First(t => t.Name == tokens[1]);
                            currentTeam.AddPlayer(new Player(tokens[2], int.Parse(tokens[3]), int.Parse(tokens[4]), int.Parse(tokens[5]), int.Parse(tokens[6]), int.Parse(tokens[7])));
                        }
                        break;

                    case "Remove":
                        Team teamToRemove = teams.First(t => t.Name == tokens[1]);
                        teamToRemove.RemovePlayer(tokens[2]);
                        break;

                    case "Rating":
                        if (!teams.Any(t => t.Name == tokens[1]))
                        {
                            throw new ArgumentException($"Team {tokens[1]} does not exist.");
                        }
                        else
                        {
                            Console.WriteLine(teams.First(t => t.Name == tokens[1]).ToString());
                        }
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}