using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;

namespace BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input;
            List<IIdentifiable> detainedIDs = new List<IIdentifiable>();
            while ((input = Console.ReadLine()) != "End")
            {
                string[] borderControlInfo = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = borderControlInfo[0];
                switch (borderControlInfo.Length)
                {
                    case 3:
                        int age = int.Parse(borderControlInfo[1]);
                        string id = borderControlInfo[2];
                        Citizen currCitizen = new Citizen(name, age, id);
                        detainedIDs.Add(currCitizen);
                        break;
                    case 2:
                        id = borderControlInfo[1];
                        Robot currRobot = new Robot(name, id);
                        detainedIDs.Add(currRobot);
                        break;
                }
            }

            string fakeIDEndingNumber = Console.ReadLine();
            detainedIDs = detainedIDs.Where(c => c.Id.EndsWith(fakeIDEndingNumber)).ToList();
            Console.WriteLine(string.Join(Environment.NewLine, detainedIDs.Select(i => i.Id)));
        }
    }
}
