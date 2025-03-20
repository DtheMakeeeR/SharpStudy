using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace issuesWithNoGenericCollections
{
    internal class Program
    {
        static void Main(string[] args)
        {

        }
        static void SimpleBoxUnboxOperation()
        {
            // Создать переменную ValueType (int).
            int mylnt = 25;
            // Упаковать int в ссылку на object,
            object boxedlnt = mylnt;
            // Распаковать ссылку обратно в int.
            int unboxedlnt = (int)boxedlnt;
        }
        static void WorkWithArrayList()
        {
            // Типы значений автоматически упаковываются,
            // когда передаются члену, принимающему object.
            ArrayList mylnts = new ArrayList();
            mylnts.Add(10);
            mylnts.Add(20);
            mylnts.Add(35);
            ///Распаковка происходит, когда объект преобразуется
            //обратно в данные, расположенные в стеке.
            int i = (int)mylnts[0];
            // Теперь значение вновь упаковывается, т.к.
            // метод WriteLine () требует типа object!
            Console.WriteLine("Value of your int: {0}", i);
        }
    }
}
