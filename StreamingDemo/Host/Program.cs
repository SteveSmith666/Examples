namespace StreamingDemo.Host
{
    using System;
    using System.ServiceModel;

    class Program
    {
        static void Main(string[] args)
        {
            using (var host = new ServiceHost(typeof(DataDemoService.DataDemoService)))
            {
                host.Open();

                Console.WriteLine();
                Console.WriteLine("Press <ENTER> to terminate Host");
                Console.ReadLine();
            }
        }
    }
}
