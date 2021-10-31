using System;
using System.Collections.Generic;
using System.Linq;

namespace Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] phoneNumbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] urls = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            foreach (var phoneNumber in phoneNumbers)
            {
                if (!phoneNumber.All(c => char.IsDigit(c)))
                {
                    Console.WriteLine("Invalid number!");
                    continue;
                }
                ICallable currPhone = null;
                if (phoneNumber.Length == 7)
                {
                    currPhone = new StationaryPhone();
                }
                else if (phoneNumber.Length == 10)
                {
                    currPhone = new Smartphone();
                }
                currPhone.Call(phoneNumber);
            }
            foreach (var url in urls)
            {
                if (url.Any(c => char.IsDigit(c)))
                {
                    Console.WriteLine("Invalid URL!");
                    continue;
                }
                Smartphone currSmartphone = new Smartphone();
                currSmartphone.Browse(url);
            }
        }
    }
}
