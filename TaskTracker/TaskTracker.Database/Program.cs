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
            /* 
            When running things in DEBUG (mostly on my Dev machine), the following should happen: 
            - Always drop all tables so DBUp always executes all scripts from scratch
            - Run all the regular Release scripts
            - Run developments scripts such as adding test data
            */
            using (SqlConnection connection = new SqlConnection(
                       connectionString))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("DEBUG - Dropping all tables");
                Console.ResetColor();

                //Dropping all tables
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
                    .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly(), (string s) => s.StartsWith("TaskTracker.Database.Scripts.Script")) //Regular release scripts
                    .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly(), (string s) => s.StartsWith("TaskTracker.Database.Scripts.Development.Dev")) //Dev-Only scripts like adding test data
                    .LogToConsole()
                    .Build();

#else
            /* 
            When running things in RELEASE DBUp should normally attempt to upgrade the database
            */
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("DEBUG - Running Release scripts");
            Console.ResetColor();
            var upgrader =
                DeployChanges.To
                    .SqlDatabase(connectionString)
                    .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly(), (string s) => s.StartsWith("TaskTracker.Database.Scripts.Script")) //Only running regular scripts
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