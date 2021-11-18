using System;
using System.Collections.Generic;
using System.Text;
using CommandPattern.Core.Contracts;

namespace CommandPattern.Core
{
    public class HelloCommand : ICommand
    {
        public string Execute(string[] args)
            => $"Hello, {args[0]}";
    }
}
