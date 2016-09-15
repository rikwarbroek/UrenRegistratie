using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Threading.Tasks;

namespace WpfApplication5
{
    /// <summary>
    /// Logic for DatabaseManager
    /// </summary>
    public class DatabaseManager
    {
        /// <summary>
        /// Gets or sets the DatabaseConnection
        /// </summary>
        public DatabaseConnection DatabaseConnection { get; private set; }

        /// <summary>
        /// Initializes a new instance of DatabaseManager
        /// </summary> 
        public DatabaseManager(DatabaseConnection connection)
        {
            // Set the DatabaseConnection
            DatabaseConnection = connection;
        }

        public void SaveProject(Project project)
        {

            if (DatabaseConnection.OpenConnection())
            {
                string query = $"INSERT INTO [dbo].[ProjectTable] ([Project]) VALUES ('{project.ProjectName}')";

                try
                {
                    SqlCommand Command = new SqlCommand(query, DatabaseConnection.Connection);
                    Command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                    Debug.WriteLine(e.Source);
                    // Something went wrong 
                }
                finally
                {
                    try { DatabaseConnection.CloseConnection(); } catch { }
                }

                // Returns if succeeded
                return;

            }

            // DUS HIER KOMT IE NIET ALS HET GOED GEGAAN IS
            throw new Exception("Something went wrong while opening the connection for adding a new project.");

        }
    }
}
