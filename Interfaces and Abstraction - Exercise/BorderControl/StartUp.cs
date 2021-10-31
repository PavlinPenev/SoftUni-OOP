using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());                                                                            //
            List<Citizen> citizenBuyers = new List<Citizen>();                                                                //
            List<Rebel> rebelBuyers = new List<Rebel>();                                                                      //
            for (int i = 0; i < n; i++)                                                                                       //
            {                                                                                                                 //
                string[] iBuyableInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);                 //
                string name = iBuyableInfo[0];                                                                                //
                int age = int.Parse(iBuyableInfo[1]);                                                                         //
                switch (iBuyableInfo.Length)                                                                                  //
                {                                                                                                             //
                    case 4:                                                                                                   //
                        string id = iBuyableInfo[2];                                                                          //
                        string birthdate = iBuyableInfo[3];                                                                   //
                        Citizen currCitizen = new Citizen(name, age, id, birthdate);                                          //
                        citizenBuyers.Add(currCitizen);                                                                       //
                        break;                                                                                                //
                    case 3:                                                                                                   //
                        string group = iBuyableInfo[2];                                                                       //
                        Rebel currRebel = new Rebel(name, age, group);                                                        //
                        rebelBuyers.Add(currRebel);                                                                           //    6. Food Shortage
                        break;                                                                                                //
                }                                                                                                             //
            }                                                                                                                 //
                                                                                                                              //
            string input;                                                                                                     //
            while ((input = Console.ReadLine()) != "End")                                                                     //
            {                                                                                                                 //
                Citizen currCitizen = citizenBuyers.FirstOrDefault(b => b.Name == input);                                     //
                Rebel currRebel = rebelBuyers.FirstOrDefault(r => r.Name == input);                                           //
                if (currCitizen != null)                                                                                      //
                {                                                                                                             //
                    currCitizen.BuyFood();                                                                                    //
                }                                                                                                             //
                else if (currRebel != null)                                                                                   //
                {                                                                                                             //
                    currRebel.BuyFood();                                                                                      //
                }                                                                                                             //
            }                                                                                                                 //
                                                                                                                              //
            Console.WriteLine(citizenBuyers.Sum(f => f.Food) + rebelBuyers.Sum(f => f.Food));                                 //
            /* string input;
             List<ICelebratable> detainedTypes = new List<ICelebratable>();                               ||
             while ((input = Console.ReadLine()) != "End")                                                ||
             {                                                                                            ||
                 string[] borderControlInfo = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);    ||
                 string type = borderControlInfo[0];                                                      ||
                 string name = borderControlInfo[1];                                                      ||
                 switch (type)                                                                            ||
                 {                                                                                        ||
                     case "Citizen":                                                                      ||
                         int age = int.Parse(borderControlInfo[2]);                                       ||
                         string id = borderControlInfo[3];                                                ||
                         string birthdate = borderControlInfo[4];                                         ||
                         Citizen currCitizen = new Citizen(name, age, id, birthdate);                     ||
                         detainedTypes.Add(currCitizen);                                                  ||
                         break;                                                                           || 5. Birthday Celebrations
                     case "Pet":                                                                          ||
                         birthdate = borderControlInfo[2];                                                ||
                         Pet currPet = new Pet(name, birthdate);                                          ||
                         detainedTypes.Add(currPet);                                                      ||
                         break;                                                                           ||
                 }                                                                                        ||
             }                                                                                            ||
                                                                                                          ||
             string specificYearEndingNumber = Console.ReadLine();                                        ||
             foreach (var celebratable in detainedTypes)                                                  ||
             {                                                                                            ||
                 if (celebratable.Birthdate.EndsWith(specificYearEndingNumber))                           ||
                 {                                                                                        ||
                     Console.WriteLine(celebratable.Birthdate);                                           ||
                 }                                                                                        ||
             }                                                                                            ||
 
             =====================================================================
             =====================================================================
 
              string input;
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
