using System;

namespace MilitaryElite
{
    public class Mission
    {
        private string state;

        public Mission(string state, string codeName)
        {
            State = state;
            CodeName = codeName;
        }

        public string CodeName { get; set; }

        public string State
        {
            get => state;
            set
            {
                if (value != "Finished" && value != "inProgress")
                {
                    throw new ArgumentException("Invalid mission state");
                }

                state = value;
            }
        }

        public override string ToString()
            => $"  Code Name: {CodeName} State: {State}";
    }
}
