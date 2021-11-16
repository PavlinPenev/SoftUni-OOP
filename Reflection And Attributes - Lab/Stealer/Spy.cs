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

        public string AnalyzeAccessModifiers(string className)                                                                     //
        {                                                                                                                          //
            StringBuilder sb = new StringBuilder();                                                                                //
            Type typeClass = Type.GetType(className);                                                                              //
            FieldInfo[] fields = typeClass.GetFields(BindingFlags.Instance |BindingFlags.Static |BindingFlags.Public);             //
            Object instanced = Activator.CreateInstance(typeClass);                                                                //
            foreach (var fieldInfo in fields)                                                                                      //
            {                                                                                                                      //
                sb.AppendLine($"{fieldInfo.Name} must be private!");                                                               //
            }                                                                                                                      //
                                                                                                                                   //
            MethodInfo[] nonPublics = typeClass.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);                        //
            MethodInfo[] publics = typeClass.GetMethods(BindingFlags.Public | BindingFlags.Instance);                              // 2. High Quality Mistakes
            foreach (var methodInfo in nonPublics.Where(m => m.Name.StartsWith("get")))                                            //
            {                                                                                                                      //
                sb.AppendLine($"{methodInfo.Name} have to be public!");                                                            //
            }                                                                                                                      //
                                                                                                                                   //
            foreach (var methodInfo in publics.Where(m => m.Name.StartsWith("set")))                                               //
            {                                                                                                                      //
                sb.AppendLine($"{methodInfo.Name} have to be private!");                                                           //
            }                                                                                                                      //
                                                                                                                                   //
            return sb.ToString().TrimEnd();                                                                                        //
        }                                                                                                                          //
    }
}
