using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDelegate
{
    internal class Program
    {
        delegate int BinaryOp(int x, int y);
        public class Math
        {
            public static int Add(int x, int y) => x + y;
            public static int Sub(int x, int y) => x - y;
        }
        static public void DelInfo(Delegate delObj)
        {
            foreach (Delegate d in delObj.GetInvocationList())
            {
                Console.WriteLine("Method name: {0}", d.Method);
                Console.WriteLine("Type name: {0}", d.Target);
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("*****Simple Delegate Example * ****\n");
            BinaryOp b = new BinaryOp(Math.Add);
            Console.WriteLine("10 + 5 = {0}", b(10,5));
            DelInfo(b);
            Console.ReadKey();
        }
    }
}
