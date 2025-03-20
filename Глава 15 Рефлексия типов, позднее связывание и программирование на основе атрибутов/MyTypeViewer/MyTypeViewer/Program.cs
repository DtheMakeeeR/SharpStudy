using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace MyTypeViewer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Welcome to MyTypeViewer *****");
            string typeName = "";
            do
            {
                Console.WriteLine("Enter TypeName");
                Console.Write("Type Q to stop\n");
                typeName = Console.ReadLine();
                if (typeName.Equals("Q", StringComparison.OrdinalIgnoreCase)) break;
                try
                {
                    Type t = Type.GetType(typeName);
                    Console.WriteLine("");
                    ListVariousStats(t);
                    ListMethods(t);
                    ListProps(t);
                    ListFields(t);
                    ListInterfaces(t);
                }
                catch
                {
                    Console.WriteLine("Sorry, cant find type");
                }
            } while (true);

        }

        static public void ListMethods(Type t)
        {
            Console.WriteLine("**** ListMethods ****");
            MethodInfo[] mi = t.GetMethods();
            foreach (MethodInfo mi2 in mi)
            {
                string retVal = mi2.ReturnType.FullName;
                string param = "(";
                foreach (ParameterInfo p in mi2.GetParameters())
                {
                    param += String.Format("{0} {1}", p.ParameterType, p.Name);
                }
                param += ")";
                Console.WriteLine("{0}, {1}, {2}", retVal, mi2.Name, param);
            }
            Console.WriteLine();
        }
        static public void ListFields(Type t)
        {
            Console.WriteLine("**** ListFields ****");
            FieldInfo[] fi = t.GetFields();
            foreach (FieldInfo fi2 in fi)
            {
                Console.WriteLine(fi2.Name);
            }
            Console.WriteLine();
        }
        static public void ListProps(Type t)
        {
            Console.WriteLine("**** ListProps ****");
            var pi = from p in t.GetProperties() select p;
            foreach(PropertyInfo pi2 in pi)
            {
                Console.WriteLine(pi2.Name);
            }
            Console.WriteLine();
        }
        static public void ListInterfaces(Type t)
        {
            Console.WriteLine("**** ListInterfaces ****");
            var ifaces = from face in t.GetInterfaces() select face;
            foreach (Type name in ifaces)
            {
                Console.WriteLine(name.Name);
            }
            Console.WriteLine();
        }
        static public void ListVariousStats(Type t)
        {
            Console.WriteLine("**** ListVariousStats ****");
            Console.WriteLine("Base class is {0}", t.BaseType);
            Console.WriteLine("Is abstract?: {0}", t.IsAbstract);
            Console.WriteLine("Is sealed?: {0}", t.IsSealed);
            Console.WriteLine("Is genreic?: {0}", t.IsGenericTypeDefinition);
            Console.WriteLine("Is type a class type: {0}", t.IsClass);
        }
    }
}
