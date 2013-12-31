namespace Barclays.Treasury.ChangeSet.TestApp
{
    using System;

    using Barclays.Treasury.Entitys;

    class Program
    {
        static void Main(string[] args)
        {
            var a = new TestClass();

            a.BString = "Hello";

            Console.WriteLine(a.BString);

            var chgSet = a.ChangeSet;
            var b = new TestClass(chgSet);

            //a.RemoveChange(chg);

            Console.WriteLine(b.BString);

            while (Console.ReadLine() != "q")
            {
                
            }
        }
    }
}
