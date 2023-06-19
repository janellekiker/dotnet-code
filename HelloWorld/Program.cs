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

            Console.WriteLine(rightNow);

            // // Declare an instance
            // Computer myComputer = new Computer()
            // {
            //     Motherboard = "Z690",
            //     HasWifi = true,
            //     hasLTE = false,
            //     ReleaseDate = DateTime.Now,
            //     Price = 954.87m,
            //     VideoCard = "TRX 2060"
            // };
            // myComputer.HasWifi = false;
            // Console.WriteLine(myComputer.Motherboard);
            // Console.WriteLine(myComputer.HasWifi);
            // Console.WriteLine(myComputer.ReleaseDate);
            // Console.WriteLine(myComputer.VideoCard);

        }
    }
}
