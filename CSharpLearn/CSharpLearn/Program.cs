

namespace CSharpLearn
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            //  add(out int a);
            // int a;
            string[] a = {"one", "two"};
            Console.WriteLine("Array's values: {0}, {1}", a[0], a[1]);
            ref string i = ref SampleRefReturn(a, 1);
            i = "new";
            Console.WriteLine("Array's values: {0}, {1}", a[0], a[1]);
            int[] b = new int[5];
            Console.WriteLine(b.GetType());
            int? c = null;
            if (c.HasValue) { Console.WriteLine("C HAS VALUE"); }
            else Console.WriteLine("C HASNT VALUSE");
        }
        static ref string SampleRefReturn(string[] array, int index)
        {
            return ref array[index];
        }
    }
}
