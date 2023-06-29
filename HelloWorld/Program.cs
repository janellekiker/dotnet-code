// See https://aka.ms/new-console-template for more information

using System;
using System.Data;
using Dapper;
using HelloWorld.Models;
using Microsoft.Data.SqlClient;

namespace HelloWorld
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Connect to Database
            string connectionString = "Server=localhost;Database=DotNetCourseDatabase;TrustServerCertificate=true;Trusted_Connection=false;User Id=SA;Password=SQLConnect1;";

            IDbConnection dbConnection = new SqlConnection(connectionString);
            string sqlCommand = "SELECT GETDATE()";

            DateTime rightNow = dbConnection.QuerySingle<DateTime>(sqlCommand);

            Console.WriteLine(rightNow.ToString());

            // // Declare an instance
            Computer myComputer = new Computer()
            {
                Motherboard = "Z690",
                HasWifi = true,
                hasLTE = false,
                ReleaseDate = DateTime.Now,
                Price = 954.87m,
                VideoCard = "TRX 2060"
            };

            // Insert to database
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

            Console.WriteLine(sql);

            int result = dbConnection.Execute(sql);
            Console.WriteLine(result);

            // Select from Database
            string sqlSelect = @"
            SELECT
                Motherboard,
                HasWifi,
                hasLTE,
                ReleaseDate,
                Price ,
                VideoCard
            FROM TutorialAppSchema.Computer";

            // Print each row in the database
            IEnumerable<Computer> computers = dbConnection.Query<Computer>(sqlSelect);

            Console.WriteLine("'Motherboard', 'HasWifi', 'hasLTE', 'ReleaseDate', 'Price', 'VideoCard'");
            foreach(Computer singleComputer in computers)
            {
                Console.WriteLine("'" + myComputer.Motherboard
                + "','" + myComputer.HasWifi
                + "','" + myComputer.hasLTE
                + "','" + myComputer.ReleaseDate
                + "','" + myComputer.Price
                + "','" + myComputer.VideoCard
            + "'");
            }


            // myComputer.HasWifi = false;
            // Console.WriteLine(myComputer.Motherboard);
            // Console.WriteLine(myComputer.HasWifi);
            // Console.WriteLine(myComputer.ReleaseDate);
            // Console.WriteLine(myComputer.VideoCard);

        }
    }
}
