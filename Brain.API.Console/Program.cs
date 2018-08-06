using System;
using System.Configuration;
using ServiceStack;

namespace Brain.API.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            string localHost = ConfigurationManager.AppSettings["LocalHost"];

            string listeningOnPort = args.Length == 0 ? localHost : args[0];

            var appHost = new AppHost()
                .Init()
                .Start(listeningOnPort);

            System.Console.WriteLine("AppHost created at {0}, listening on {1}", DateTime.Now, listeningOnPort);
            System.Console.ReadKey();
        }
    }
}
