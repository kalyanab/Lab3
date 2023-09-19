namespace MyPractice4
{
    using System;
    class VarDynamic
    {
        static void Main()
        {
            var i = 100;
            Console.WriteLine(i.GetType());
            var c = 'A';
            Console.WriteLine(c.GetType());
            var f = 45.67f;
            Console.WriteLine(f.GetType());
            var b = true;
            Console.WriteLine(b.GetType());
            var s = "Hello";
            Console.WriteLine(s.GetType());
           //Console.WriteLine("----------------------------------------------------------------------------------------------------------");

           // dynamic d;
           // d = 100;
           // Console.WriteLine(d.GetType());
           // d = 'Z';
           // Console.WriteLine(d.GetType());
           // d = 34.56;
           // Console.WriteLine(d.GetType());
           // d = false;
           // Console.WriteLine(d.GetType());
           // d = "Hello";
           // Console.WriteLine(d.GetType());
        }
    }
}