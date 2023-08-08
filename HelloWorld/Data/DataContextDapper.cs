using System.Data;
using Microsoft.Data.SqlClient;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace HelloWorld.Data

{
    public class DataContextDapper
    {

            // Connect to Database
            private string _connectionString = "Server=localhost;Database=DotNetCourseDatabase;TrustServerCertificate=true;Trusted_Connection=false;User Id=SA;Password=SQLConnect1;";
            public DataContextDapper(IConfiguration config)
            {
                _connectionString = config.GetConnectionString("DefaultConnection");
            }


            // Method to get all data from database
            public IEnumerable<T> LoadData<T>(string sql)
            {
                IDbConnection dbConnection = new SqlConnection(_connectionString);
                return dbConnection.Query<T>(sql);
            }
            // Method to get a single instance from database
            public T LoadDataSingle<T>(string sql)
            {
                IDbConnection dbConnection = new SqlConnection(_connectionString);
                return dbConnection.QuerySingle<T>(sql);
            }
            // Method to check if data was added
            public bool ExecuteSql(string sql)
            {
                IDbConnection dbConnection = new SqlConnection(_connectionString);
                return (dbConnection.Execute(sql) > 0);
            }
            // Method to check how many rows were affected
            public int ExecuteSqlWithRowCount(string sql)
            {
                IDbConnection dbConnection = new SqlConnection(_connectionString);
                return dbConnection.Execute(sql);
            }


    }
}
