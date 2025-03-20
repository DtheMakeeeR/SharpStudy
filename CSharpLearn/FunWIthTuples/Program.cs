namespace FunWIthTuples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            (string, int, string) tuple1 = ("a", 5, "c");
            var tuple2 = ("a", 5, "c");
            (string first, int, int, string last) tuple3 = ("a", 4, 5, "c");
            var tuple4 = (first:"a", 4, second:5, "c");
            Console.WriteLine(tuple3.last);
            Console.WriteLine(tuple4.second);
            Console.WriteLine(tuple4.Item3);
            var foo = new { Prop1 = "first", Prop2 = "second" };
            var bar = (foo.Prop1, foo.Prop2);
            Console.WriteLine($"{bar.Prop1};{bar.Prop2}");
            int c = 4;
            string b = "bad";
            var t = (c, b);
            Console.WriteLine($"{t.c},{t.b}");
        }
    }
}
