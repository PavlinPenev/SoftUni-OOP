using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AuthorProblem
{
    public class Tracker // 6. Code Tracker
    {
        public void PrintMethodsByAuthor()
        {
            Type type = typeof(StartUp);
            StringBuilder stringBuilder = new StringBuilder();
            MethodInfo[] methods = type.GetMethods(BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
            foreach (MethodInfo method in methods)
            {
                if (method.CustomAttributes.Any(a => a.AttributeType == typeof(AuthorAttribute)))
                {
                    var attributes = method.GetCustomAttributes(false);
                    foreach (var attribute in attributes)    
                    {
                        stringBuilder.AppendLine($"{method.Name} is written by {(attribute as AuthorAttribute).Name}");
                    }
                }
            }

            Console.WriteLine(stringBuilder.ToString().TrimEnd());
        }
    }
}
