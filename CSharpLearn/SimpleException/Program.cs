using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
namespace SimpleException
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*****Simple Exception Example *****");
            Console.WriteLine("=> Creating a car and stepping on it!");
            Car myCar = new Car("Zippy", 20);
            myCar.CrankMusic(true);
            try
            {
                for (int i = 0; i < 10; i++)
                    myCar.Accelerate(10);
            }
            catch (Exception ex)
            {

                Console.WriteLine("\n*** Error' ***"); // ошибка
                Console.WriteLine("Method: {0}" , ex.TargetSite); // метод
                Console.WriteLine("Class defining member: {0}", ex.TargetSite.DeclaringType);
                Console.WriteLine("Class member type: {0}", ex.TargetSite.MemberType);
                Console.WriteLine("Message: {0} ", ex.Message); // сообщение
                Console.WriteLine("Source: {0}" , ex.Source); // источник
                Console.WriteLine("Stack: {0}", ex.StackTrace);
                Console.WriteLine("Help link: {0}", ex.HelpLink);
                Console.WriteLine("\n->Custom Data: ");
                foreach (DictionaryEntry de in ex.Data)
                {
                    Console.WriteLine("->{0}: {1}", de.Key, de.Value);
                }
            }
            Console.WriteLine("\n***** Out of exception logic *****");
            Console.ReadLine();

        }
    }
}
