using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Reflection;
using DbUp;

namespace TaskTracker.Database
{
    class Program
    {
        static int Main(string[] args)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["TaskTracker"].ToString();



#if DEBUG
            using (SqlConnection connection = new SqlConnection(
                       connectionString))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("DEBUG - Dropping all tables");
                Console.ResetColor();
                SqlCommand command = new SqlCommand("EXEC sp_MSforeachtable @command1 = 'DROP TABLE ?'", connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("DEBUG - Running Release + Dev scripts");
            Console.ResetColor();
            var upgrader =
                DeployChanges.To
                    .SqlDatabase(connectionString)
                    .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly(), (string s) => s.StartsWith("TaskTracker.Database.Scripts.Script"))
                    .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly(), (string s) => s.StartsWith("TaskTracker.Database.Scripts.Development.Dev"))
                    .LogToConsole()
                    .Build();

#else
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("DEBUG - Running Release scripts");
            Console.ResetColor();
            var upgrader =
                DeployChanges.To
                    .SqlDatabase(connectionString)
                    .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly(), (string s) => s.StartsWith("TaskTracker.Database.Scripts.Script"))
                    .LogToConsole()
                    .Build();
#endif

            var result = upgrader.PerformUpgrade();
            if (!result.Successful)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(result.Error);
                Console.ResetColor();

                Console.ReadLine();

                return -1;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Success!");
            Console.ResetColor();
            return 0;
        }
    }
}