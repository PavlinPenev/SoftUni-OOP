using System;

namespace ConvertToDouble
{
    class ConvertToDouble
    {
        static void Main(string[] args)
        {
            string[] valuesToConvert = { "5.34","16.85","1.ash","asfs","-8.64", "4","780000000"};
            foreach (var VARIABLE in valuesToConvert)       
            {
                try
                {
                    double forced = Math.Pow(Convert.ToDouble(VARIABLE), 35);
                    if (double.IsNegativeInfinity(forced) || double.IsPositiveInfinity(forced))
                    {
                        throw new OverflowException("Value is greater than max value or lower than min value"); 
                        //all the overflow double cases were always converted to "Infinity"(at least those I tried) so I manually throw OverFlowException :D
                    }
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (OverflowException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
 