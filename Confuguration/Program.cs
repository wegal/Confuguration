using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using System.IO;
namespace Confuguration
{
    class Program
    {
        static void Main(string[] args)
        {
            SetupConfiguration(args);
            ReadConfiguration();
        }

        private static void ReadConfiguration()

        {

            string setting1 = Configuration.GetSection("MyConfig")["Setting1"];

            Console.WriteLine(setting1);





            string defaultConnection = Configuration.GetConnectionString("Wartezeit");

            Console.WriteLine(defaultConnection);



            MyTypedSetings setting = new MyTypedSetings();

            Configuration.GetSection("MyTypedSetting").Bind(setting);

            Console.WriteLine($"{setting.Title} {setting.TopLeft.X} {setting.TopLeft.Y}");



            //string secret = Configuration["secret1"];

            //Console.WriteLine($"this is a secret: {secret}");

        }


        static void SetupConfiguration(string[] args)
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("apsettings.json")

                .AddJsonFile("alternative.json", optional: true)

                //.AddEnvironmentVariables()

                .AddCommandLine(args);



            Configuration = builder.Build();



        }


        public static IConfigurationRoot Configuration { get; private set; }

    }
}
