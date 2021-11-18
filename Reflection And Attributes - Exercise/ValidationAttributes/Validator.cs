using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;

namespace ValidationAttributes
{
    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            PropertyInfo[] properties = obj.GetType().GetProperties();
            foreach (PropertyInfo property in properties)
            {
                var attributes = property.GetCustomAttributes().Where(a => a.GetType().IsSubclassOf(typeof(MyValidationAttribute))).Cast<MyValidationAttribute>().ToArray();
                foreach (var attribute in attributes)
                {
                    bool isValid = attribute.IsValid(property.GetValue(obj));
                    if (!isValid)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
