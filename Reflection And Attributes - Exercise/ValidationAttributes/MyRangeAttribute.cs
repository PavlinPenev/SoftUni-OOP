using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationAttributes
{
    public class MyRangeAttribute : MyValidationAttribute
    {
        private int minValue;
        private int maxValue;
        public MyRangeAttribute(int minValue, int maxValue)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
        }

        public override bool IsValid(object obj)
        {
            int validationInt = 0;
            if (int.TryParse(obj.ToString(), out validationInt))
            {
                if (validationInt >= this.minValue && validationInt <= maxValue)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
