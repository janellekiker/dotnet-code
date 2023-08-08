// See https://aka.ms/new-console-template for more information

using HelloWorld.Models;
using HelloWorld.Data;
using Microsoft.Extensions.Configuration;

namespace HelloWorld
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            // Now we have access to our dapper class and all it's methods
            DataContextDapper dapper = new DataContextDapper(config);
            DataContextEF entityFramework = new DataContextEF(config);

            DateTime rightNow = dapper.LoadDataSingle<DateTime>("SELECT GETDATE()");
            Console.WriteLine(rightNow.ToString());

            // Declare an instance
            Computer myComputer = new Computer()
            {
                Motherboard = "Z692",
                HasWifi = true,
                hasLTE = true,
                ReleaseDate = DateTime.Now,
                Price = 999.87m,
                VideoCard = "TRX 2060"
            };

            entityFramework.Add(myComputer);
            entityFramework.SaveChanges();

            // Data to insert to database
            string sql = @"INSERT INTO TutorialAppSchema.Computer (
                Motherboard,
                HasWifi,
                hasLTE,
                ReleaseDate,
                Price ,
                VideoCard
            ) VALUES ('" + myComputer.Motherboard
                + "','" + myComputer.HasWifi
                + "','" + myComputer.hasLTE
                + "','" + myComputer.ReleaseDate
                + "','" + myComputer.Price
                + "','" + myComputer.VideoCard
            + "')";

        }
    }
}
