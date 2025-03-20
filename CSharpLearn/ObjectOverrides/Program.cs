using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOverrides
{
    internal class Program
    {
        //object.equals сравнивает состояние
        //object.referenceequals сравнивает ссылки
        static void Main(string[] args)
        {
            
            Console.WriteLine("***** Fun with System.Object *****\n");
            Person p1 = new Person() ;
            // Использовать унаследованные члены System.Object.
            Console.WriteLine("ToString: {0}", p1.ToString());
            Console.WriteLine("Hash code: {0}", p1.GetHashCode());
            Console.WriteLine("Type: {0}", p1.GetType());
            // Создать другие ссылки на p1.
            Person р2 = p1;
            object о = р2;
            // Указывают ли ссылки на один и тот же объект в памяти?
            if (о.Equals(p1) && р2.Equals(о))
            {
                Console.WriteLine("Same instance! ");
            }
            Console.WriteLine("///////////////////////////////");

            // ПРИМЕЧАНИЕ: эти объекты идентичны и предназначены
            // для тестирования методов Equals () и GetHashCode() .
            Person p3 = new Person("Homer", "Simpson", 50);
            Person p4 = new Person("Homer", "Simpson", 50);
            // Получить строковые версии объектов.
            Console.WriteLine("p3.ToString() = {0}", p3.ToString());
            Console.WriteLine("p4.ToString() = {0}", p4.ToString());
            // Протестировать переопределенный метод Equals().
            Console.WriteLine("p3 = p4?: {0}", p3.Equals(p4));
            Console.WriteLine("Same hash codes?: {0}", 
                                                p3.GetHashCode() == p4.GetHashCode());
            Console.WriteLine("****CHANGE AGE****");
            p4.Age = 35;
            Console.WriteLine("p3.ToString() = {0}", p3.ToString());
            Console.WriteLine("p4.ToString() = {0}", p4.ToString());
            Console.WriteLine("p3 = p4?: {0}", p3.Equals(p4));
            Console.WriteLine("Same hash codes?: {0}",
                                                p3.GetHashCode() == p4.GetHashCode());
            Console.ReadLine();

        }
    }
}
