using Microsoft.Owin.Hosting;
using System;

namespace TTF.Web
{
    class Program
    {
        static void Main(string[] args)
        {
            var baseAddress = "http://+:8000/";

            // Start OWIN host 
            using (WebApp.Start<Startup>(baseAddress))
            {
                Console.WriteLine("Server started. Press Enter to Exit");
                Console.ReadLine();
            }
        }
    }
}
