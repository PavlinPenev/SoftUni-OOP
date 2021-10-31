using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input;
            List<ICelebratable> detainedTypes = new List<ICelebratable>();
            while ((input = Console.ReadLine()) != "End")
            {
                string[] borderControlInfo = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string type = borderControlInfo[0];
                string name = borderControlInfo[1];
                switch (type)
                {
                    case "Citizen":
                        int age = int.Parse(borderControlInfo[2]);
                        string id = borderControlInfo[3];
                        string birthdate = borderControlInfo[4];
                        Citizen currCitizen = new Citizen(name, age, id, birthdate);
                        detainedTypes.Add(currCitizen);
                        break;
                    case "Pet":
                        birthdate = borderControlInfo[2];
                        Pet currPet = new Pet(name, birthdate);
                        detainedTypes.Add(currPet);
                        break;
                }
            }

            string specificYearEndingNumber = Console.ReadLine();
            foreach (var celebratable in detainedTypes)
            {
                if (celebratable.Birthdate.EndsWith(specificYearEndingNumber))
                {
                    Console.WriteLine(celebratable.Birthdate);
                }
            }
            /* string input;
            List<IIdentifiable> detainedIDs = new List<IIdentifiable>();                                 ||
            while ((input = Console.ReadLine()) != "End")                                                ||
            {                                                                                            ||
                string[] borderControlInfo = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);    ||
                string name = borderControlInfo[0];                                                      ||
                switch (borderControlInfo.Length)                                                        ||
                {                                                                                        ||
                    case 3:                                                                              ||
                        int age = int.Parse(borderControlInfo[1]);                                       ||
                        string id = borderControlInfo[2];                                                ||
                        Citizen currCitizen = new Citizen(name, age, id);                                ||
                        detainedIDs.Add(currCitizen);                                                    || 4. Border Control StartUp
                        break;                                                                           ||
                    case 2:                                                                              ||
                        id = borderControlInfo[1];                                                       ||
                        Robot currRobot = new Robot(name, id);                                           ||
                        detainedIDs.Add(currRobot);                                                      ||
                        break;                                                                           ||
                }                                                                                        ||
            }                                                                                            ||
                                                                                                         ||
            string fakeIDEndingNumber = Console.ReadLine();                                              ||
            detainedIDs = detainedIDs.Where(c => c.Id.EndsWith(fakeIDEndingNumber)).ToList();            ||
            Console.WriteLine(string.Join(Environment.NewLine, detainedIDs.Select(i => i.Id)));          ||*/
        }
    }
}
