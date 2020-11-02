using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace bookkeepingAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}


// using System;
// using Microsoft.Data.Sqlite;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Hosting;
// using Microsoft.Extensions.Configuration;
// using Microsoft.Extensions.Hosting;
// using Microsoft.Extensions.Logging;

// namespace bookkeepingAPI
// {
//     class Program
//     {
//         static void Main(string[] args)
//         {
//             var connectionStringBuilder = new SqliteConnectionStringBuilder();

//             //Use DB in project directory.  If it does not exist, create it:
//             connectionStringBuilder.DataSource = "./SqliteDB.db";

//             using (var connection = new SqliteConnection(connectionStringBuilder.ConnectionString))
//             {
//                 connection.Open();

//                 //Create a table (drop if already exists first):
                
//                 var delTableCmd = connection.CreateCommand();
//                 delTableCmd.CommandText = "DROP TABLE IF EXISTS favorite_beers";
//                 delTableCmd.ExecuteNonQuery();

//                 var createTableCmd = connection.CreateCommand();
//                 createTableCmd.CommandText = "CREATE TABLE favorite_beers(name VARCHAR(50))";
//                 createTableCmd.ExecuteNonQuery();

//                 //Seed some data:
//                 using (var transaction = connection.BeginTransaction())
//                 {
//                     var insertCmd = connection.CreateCommand();

//                     insertCmd.CommandText = "INSERT INTO favorite_beers VALUES('LAGUNITAS IPA')";
//                     insertCmd.ExecuteNonQuery();

//                     insertCmd.CommandText = "INSERT INTO favorite_beers VALUES('JAI ALAI IPA')";
//                     insertCmd.ExecuteNonQuery();

//                     insertCmd.CommandText = "INSERT INTO favorite_beers VALUES('RANGER IPA')";
//                     insertCmd.ExecuteNonQuery();

//                     transaction.Commit();
//                 }

//                 //Read the newly inserted data:
//                 var selectCmd = connection.CreateCommand();
//                 selectCmd.CommandText = "SELECT name FROM favorite_beers";

//                 using (var reader = selectCmd.ExecuteReader())
//                 {
//                     while (reader.Read())
//                     {
//                         var message = reader.GetString(0);
//                         Console.WriteLine(message);
//                     }
//                 }


//             }
//         }
//     }
// }