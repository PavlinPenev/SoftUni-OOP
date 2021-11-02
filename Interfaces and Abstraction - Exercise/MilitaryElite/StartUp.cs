using System;
using System.Collections.Generic;
using System.Linq;

namespace MilitaryElite
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input;
            List<Soldier> soldiers = new List<Soldier>();
            while ((input = Console.ReadLine()) != "End")
            {
                string[] cmdArgs = input.Split();
                string id = cmdArgs[1];
                string firstName = cmdArgs[2];
                string lastName = cmdArgs[3];
                string soldierType = cmdArgs[0];
                switch (soldierType)
                {
                    case "Private":
                        decimal salary = decimal.Parse(cmdArgs[4]);
                        Private currPrivate = new Private(id, firstName, lastName, salary);
                        soldiers.Add(currPrivate);
                        break;
                    case "LieutenantGeneral":
                        salary = decimal.Parse(cmdArgs[4]);
                        List<string> privates = cmdArgs.Skip(5).ToList();
                        LieutenantGeneral currLieutenant = new LieutenantGeneral(id, firstName, lastName, salary);
                        while (privates.Any())
                        {
                            Private currentPrivate = (Private)soldiers.FirstOrDefault(s => s.Id == privates[0]);
                            if (currentPrivate != null)
                            {
                                currLieutenant.PrivatesUnderCommand.Add(currentPrivate);
                            }
                            privates.RemoveAt(0);
                        }
                        soldiers.Add(currLieutenant);
                        break;
                    case "Engineer":
                        salary = decimal.Parse(cmdArgs[4]);
                        string corps = cmdArgs[5];
                        try
                        {
                            Engineer currEngineer = new Engineer(id, firstName, lastName, salary, corps);
                            List<string> repairs = cmdArgs.Skip(6).ToList();
                            while (repairs.Any())
                            {
                                string repairName = repairs[0];
                                int repairTime = int.Parse(repairs[1]);
                                Repair currentRepair = new Repair(repairName, repairTime);
                                currEngineer.Repairs.Add(currentRepair);
                                repairs.RemoveRange(0, 2);
                            }
                            soldiers.Add(currEngineer);
                        }
                        catch (ArgumentException e)
                        {
                        }
                        break;
                    case "Commando":
                        salary = decimal.Parse(cmdArgs[4]);
                        corps = cmdArgs[5];
                        List<string> missions = cmdArgs.Skip(6).ToList();
                        Commando currCommando = new Commando(id, firstName, lastName, salary, corps);
                        while (missions.Any())
                        {
                            try
                            {
                                string missionCodeName = missions[0];
                                string missionState = missions[1];
                                Mission currMission = new Mission(missionState, missionCodeName);
                                currCommando.Missions.Add(currMission);
                            }
                            catch (ArgumentException ex)
                            {
                            }
                            missions.RemoveRange(0, 2);
                        }
                        soldiers.Add(currCommando);
                        break;
                    case "Spy":
                        int codeNumber = int.Parse(cmdArgs[4]);
                        Spy currSpy = new Spy(id, firstName, lastName, codeNumber);
                        soldiers.Add(currSpy);
                        break;
                }
            }

            foreach (var soldier in soldiers)
            {
                Console.WriteLine(soldier);
            }
        }
    }
}
