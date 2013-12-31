using System;
using System.Collections.Generic;

namespace InMemoryObjectCache
{
    using System.Globalization;

    using ObjectCache;

    class Program
    {
        private static void Main(string[] args)
        {
            InMemory myNewCache = new InMemory();
            Random _r = new Random();

            string strFilePath = System.IO.Path.Combine(Environment.CurrentDirectory, "../../XmlFiles/ListOfUsers.xml");
            var lstFiles = new List<string>();
            lstFiles.Add(strFilePath);

            //for (int i = 1; i <= 100; i++)
            //{
            //    string cacheItem1 = "Steve Smith-" + i;
            //    myNewCache.AddToMyCache(i.ToString(CultureInfo.InvariantCulture), cacheItem1, MyCachePriority.NotRemovable, lstFiles);
            //}
            int counter = 1;
            int counter1 = 1;
            
            Console.WriteLine(DateTime.Now.ToString(CultureInfo.InvariantCulture));
            for (int i = 1; i <= 5000000; i++)
            {
                var car = new Car("Blue" + i, i);
                myNewCache.AddToMyCache(
                    i.ToString(CultureInfo.InvariantCulture), car, MyCachePriority.NotRemovable, lstFiles);
                
                if (counter == 10000)
                {
                    Console.Write(".");
                    counter = 0;
                }
                if (counter1 == 1000000)
                {
                    Console.Write("x");
                    counter1 = 0;
                }
                counter++;
                counter1++;
            }

            var myItem10 = myNewCache.GetMyCachedItem("10") as Car;
            Console.WriteLine(myItem10.Colour);
            var myItem100 = myNewCache.GetMyCachedItem("100") as Car;
            Console.WriteLine(myItem100.Colour);
            var myItem1000 = myNewCache.GetMyCachedItem("1000") as Car;
            Console.WriteLine(myItem1000.Colour);
            var myItem10000 = myNewCache.GetMyCachedItem("10000") as Car;
            Console.WriteLine(myItem10000.Colour);
            var myItem100000 = myNewCache.GetMyCachedItem("100000") as Car;
            Console.WriteLine(myItem100000.Colour);
            var myItem150000 = myNewCache.GetMyCachedItem("150000") as Car;
            Console.WriteLine(myItem150000.Colour);
            var myItem200000 = myNewCache.GetMyCachedItem("200000") as Car;
            Console.WriteLine(myItem200000.Colour);
            var myItem250000 = myNewCache.GetMyCachedItem("250000") as Car;
            Console.WriteLine(myItem250000.Colour);
            
            Console.WriteLine(DateTime.Now.ToString(CultureInfo.InvariantCulture) + " (" + myNewCache.Count() + ")");
            while (Console.ReadLine() != "quit")
            {
                if(Console.ReadLine() == "n")
                {
                    var r = myNewCache.GetMyCachedItem(_r.Next(5000000).ToString()) as Car;
                    Console.WriteLine(r.Colour);
                }
            }
        }
    }
}
