using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicKeyword
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //PrintThreeStnngs();
            ChangeDynamicDataType();
        }
        static void PrintThreeStnngs()
        {
            var s1 = "word1";
            object s2 = "word2";
            dynamic s3 = "word3";
            Console.WriteLine("s1 is of Type: {0}", s1.GetType());
            Console.WriteLine("s2 is of Type: {0}", s2.GetType());
            Console.WriteLine("s3 is of Type: {0}", s3.GetType());
        }
        static void ChangeDynamicDataType()
        {
            // Объявить одиночный динамический элемент данных по имени t.
            dynamic t = "Hello!";
            Console.WriteLine("t is of type: {0}", t.GetType());
            t = false;
            Console.WriteLine("t is of type: {0}", t.GetType());
            t = new List<int>();
            Console.WriteLine("t is of type: {0}", t.GetType());
        }
        //до исполнения нет проверки на наличие членов
        static void InvokeMembersOnDynamicData()
        {
            dynamic textDatal = "Hello";
            Console.WriteLine(textDatal.ToUpper());
            // Здесь можно было бы ожидать ошибки на этапе компиляции!
            // Однако все компилируется нормально.
            Console.WriteLine(textDatal.toupper());
            Console.WriteLine(textDatal.Foo(10, "ее", DateTime.Now));
        }
    }
}
