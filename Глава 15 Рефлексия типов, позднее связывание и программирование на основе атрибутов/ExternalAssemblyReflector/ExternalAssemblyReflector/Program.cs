using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;

namespace ExternalAssemblyReflector
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** External Assembly Viewer *****");
            string asmName = "";
            Assembly asm = null;
            do
            {
                Console.WriteLine("Input assembly name");
                Console.WriteLine("or type q if wanna exit: ");
                asmName = Console.ReadLine();
                if (asmName.Equals("Q", StringComparison.OrdinalIgnoreCase)) { break; }
                try
                {
                    asm = Assembly.Load(asmName);
                    DisplayTypesInAsm(asm);
                }
                catch
                {
                    Console.WriteLine("Sorry, cant find assembly");
                }
            } while (true);
        }
        public static void DisplayTypesInAsm(Assembly assembly)
        {
            Console.WriteLine("\n***** Types in Assembly *****");
            Console.WriteLine("-> {0}",assembly.FullName);
            Type[] types = assembly.GetTypes();
            foreach (Type t in types)
            {
                Console.WriteLine("Type: {0}", t);
            }
            Console.WriteLine("");
        }
    }
}
