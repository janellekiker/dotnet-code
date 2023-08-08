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
            DataContextEF entityFramework = new DataContextEF();

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

            // Command to insert the data to the database
            bool result = dapper.ExecuteSql(sql);
            Console.WriteLine(result);

            // Select from Database
            string sqlSelect = @"
            SELECT
                Computer.ComputerId,
                Computer.Motherboard,
                Computer.HasWifi,
                Computer.hasLTE,
                Computer.ReleaseDate,
                Computer.Price ,
                Computer.VideoCard
            FROM TutorialAppSchema.Computer";

            // Print each row in the database
            IEnumerable<Computer> computers = dapper.LoadData<Computer>(sqlSelect);

            Console.WriteLine("'ComputerId', 'Motherboard', 'HasWifi', 'hasLTE', 'ReleaseDate', 'Price', 'VideoCard'");
            foreach(Computer singleComputer in computers)
            {
                Console.WriteLine("'" + singleComputer.ComputerId
                + "','" + singleComputer.Motherboard
                + "','" + singleComputer.HasWifi
                + "','" + singleComputer.hasLTE
                + "','" + singleComputer.ReleaseDate
                + "','" + singleComputer.Price
                + "','" + singleComputer.VideoCard
            + "'");
            }

            // Entity Framework
            IEnumerable<Computer>? computersEf = entityFramework.Computer?.ToList<Computer>();

            if(computersEf != null)
            {
                Console.WriteLine("'ComputerId', 'Motherboard', 'HasWifi', 'hasLTE', 'ReleaseDate', 'Price', 'VideoCard'");
                foreach(Computer singleComputer in computersEf)
                {
                    Console.WriteLine("'" + singleComputer.ComputerId
                    + "','" + singleComputer.Motherboard
                    + "','" + singleComputer.HasWifi
                    + "','" + singleComputer.hasLTE
                    + "','" + singleComputer.ReleaseDate
                    + "','" + singleComputer.Price
                    + "','" + singleComputer.VideoCard
                + "'");
                }
            }

        }
    }
}
