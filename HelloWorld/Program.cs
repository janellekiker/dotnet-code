// See https://aka.ms/new-console-template for more information

using HelloWorld.Models;
using HelloWorld.Data;

namespace HelloWorld
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Now we have access to our dapper class and all it's methods
            DataContextDapper dapper = new DataContextDapper();


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

            // Command to insert the data to the database
            bool result = dapper.ExecuteSql(sql);
            Console.WriteLine(result);

            // Select from Database
            string sqlSelect = @"
            SELECT
                Computer.Motherboard,
                Computer.HasWifi,
                Computer.hasLTE,
                Computer.ReleaseDate,
                Computer.Price ,
                Computer.VideoCard
            FROM TutorialAppSchema.Computer";

            // Print each row in the database
            IEnumerable<Computer> computers = dapper.LoadData<Computer>(sqlSelect);

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

        }
    }
}
