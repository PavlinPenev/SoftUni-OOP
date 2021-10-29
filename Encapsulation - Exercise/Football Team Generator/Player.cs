using System;

namespace FootballTeamGenerator
{
    public class Player
{
    private int dribble;
    private int endurance;
    private string name;
    private int passing;
    private int shooting;
    private int sprint;

    public string Name
    {
        get { return name; }
        private set
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException($"A name should not be empty.");
            }

            name = value;
        }
    }

    public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
    {
        Name = name;
        Endurance = endurance;
        Sprint = sprint;
        Dribble = dribble;
        Passing = passing;
        Shooting = shooting;
    }

    public int Stats { get { return CalculateAverageStats(); } }

    private int Dribble
    {
        get { return dribble; }
        set
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException($"Dribble should be between 0 and 100.");
            }

            dribble = value;
        }
    }

    private int Endurance
    {
        get { return endurance; }
        set
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException($"Endurance should be between 0 and 100.");
            }

            endurance = value;
        }
    }

    private int Passing
    {
        get { return passing; }
        set
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException($"Passing should be between 0 and 100.");
            }

            passing = value;
        }
    }

    private int Shooting
    {
        get { return shooting; }
        set
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException($"Shooting should be between 0 and 100.");
            }

            shooting = value;
        }
    }

    private int Sprint
    {
        get { return sprint; }
        set
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException($"Sprint should be between 0 and 100.");
            }

            sprint = value;
        }
    }

    private int CalculateAverageStats()
    {
        return (int)Math.Round((Dribble + Endurance + Passing + Shooting + Sprint) / (double)5);
    }
}
}
