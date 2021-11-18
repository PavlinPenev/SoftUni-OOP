using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using CommandPattern.Core.Contracts;

namespace CommandPattern.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] cmdArgs = args.Split();
            string result = string.Empty;
            string commandType = cmdArgs[0] + "Command";
            Type typeOfCommand = Assembly.GetCallingAssembly().GetTypes().Where(t => t.Name == commandType).FirstOrDefault();
            ICommand executable = (Activator.CreateInstance(typeOfCommand)) as ICommand;
            result = executable.Execute(cmdArgs.Skip(1).ToArray());
            return result;
        }
    }
}
