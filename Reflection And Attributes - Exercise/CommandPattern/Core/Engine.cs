using System;
using CommandPattern.Core.Contracts;

namespace CommandPattern.Core
{
    public  class Engine : IEngine
    {
        private readonly ICommandInterpreter _command;
        public Engine(ICommandInterpreter command)
        {
            _command = command;
        }

        public void Run()
        {
            string engineCondition;
            while (true)
            {
               engineCondition = _command.Read(Console.ReadLine());
               if (engineCondition == null)
                   break;
               Console.WriteLine(engineCondition);
            }
        }
    }
}
