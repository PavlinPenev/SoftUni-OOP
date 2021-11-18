using System;
using System.Collections.Generic;
using System.Text;
using CommandPattern.Core.Contracts;

namespace CommandPattern.Core
{
    public class ExitCommand : ICommand
    {
        public string Execute(string[] args)
            => null;
    }
}
