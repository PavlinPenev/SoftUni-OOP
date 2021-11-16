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

        public string RevealPrivateMethods(string className)                                                                                    //
        {                                                                                                                                       //
            Type typeClass = Type.GetType(className);                                                                                           //
            MethodInfo[] methods = typeClass.GetMethods(BindingFlags.NonPublic |BindingFlags.Instance | BindingFlags.Static);                   //
            StringBuilder sb = new StringBuilder();                                                                                             //
            sb.AppendLine($"All Private Methods Of Class: {typeClass.FullName}");                                                               //
            sb.AppendLine($"Base Class: {typeClass.BaseType.Name}");                                                                            //
            foreach (var method in methods)                                                                                                     // 3. Mission Private Impossible
            {                                                                                                                                   //
                sb.AppendLine(method.Name);                                                                                                     //
            }                                                                                                                                   //
                                                                                                                                                //
            return sb.ToString().TrimEnd();                                                                                                     //
        }                                                                                                                                       //

        public string CollectGettersAndSetters(string className)                                                        //
        {                                                                                                               //
            StringBuilder sb = new StringBuilder();                                                                     //
            Type typeClass = Type.GetType(className);                                                                   //
            MethodInfo[] allMethods = typeClass.GetMethods(BindingFlags.Static | BindingFlags.NonPublic |               //
                                                        BindingFlags.Instance | BindingFlags.Public);                   //
            foreach (var method in allMethods.Where(m => m.Name.StartsWith("get")))                                     //
            {                                                                                                           //
                sb.AppendLine($"{method.Name} will return {method.ReturnType}");                                        // 4. Collector
            }                                                                                                           //
                                                                                                                        //
            foreach (var method in allMethods.Where(m => m.Name.StartsWith("set")))                                     //
            {                                                                                                           //
                sb.AppendLine($"{method.Name} will set field of {method.GetParameters().First().ParameterType}");       //
            }                                                                                                           //
                                                                                                                        //
            return sb.ToString().TrimEnd();                                                                             //
        }
    }
}
