using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string nameOfClass, params string[] namesOfFields)
        {
            Type typeClass = Type.GetType(nameOfClass);
            FieldInfo[] fields = typeClass.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);
            StringBuilder sb = new StringBuilder();
            Object instanced = Activator.CreateInstance(typeClass);
            sb.AppendLine($"Class under investigation: {nameOfClass}");
            foreach (FieldInfo field in fields.Where(f => namesOfFields.Contains(f.Name)))
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(instanced)}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
