using System;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Threading.Tasks;

namespace WpfApplication5
{
    /// <summary>
    /// Logic for DatabaseConnection
    /// </summary>
    public class DatabaseConnection
    {

        /// <summary>
        /// Gets or sets the Connection
        /// </summary>
        public SqlConnection Connection { get; private set; }

        /// <summary>
        /// Initializes a new instance of DatabaseConnection
        /// </summary>
        public DatabaseConnection()
        {
            try
            {
                // Create the connection
                Connection = new SqlConnection();

                // Set the connection string
                Connection.ConnectionString = @"Data Source=Rikslaptop;Initial Catalog=UrenRegistratie;Integrated Security=True";

                // Check if we can connect
                Connection.Open();

                // Check if we can close the connection
                Connection.Close();
                return;
            }
            catch (Exception e)
            {
                // Log the error
                Debug.WriteLine($"Failed to load the database {e}");

                // Close the connection if there is any
                if (Connection.State != 0)
                {
                    Connection.Close();
                } 
            }
        }

        /// <summary>
        /// Opens the SQL Connection
        /// </summary> 
        public bool OpenConnection()
        {
            try
            {
                ConnectAsync();
                return true;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine($"Failed to open the SQL connection (SQL ERROR {ex.Number}): {ex.Message}");
                return false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Failed to open the SQL connection: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Closes the connection and returns a System.Boolean value wether the function has succeeded
        /// </summary> 
        public bool CloseConnection()
        {
            try
            {
                DisconnectAsync();
                return true;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine($"Failed to close the SQL connection (SQL ERROR {ex.Number}): {ex.Message}");
                return false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Failed to close the SQL connection: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Opens the SQL connection async
        /// </summary>
        private void ConnectAsync()
        {
            Connection.Open();
        }

        /// <summary>
        /// Closes the SQL connection async
        /// </summary>
        private void DisconnectAsync()
        {
            Connection.Close();
        }
    }
}
