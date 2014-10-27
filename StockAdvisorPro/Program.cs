using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Data.SqlClient;
using System.Text;

namespace StockAdvisorPro
{
    static class Program
    {
        /// <summary>
        /// This holds the name of the sql instance 
        /// </summary>
        private static string sql_instance;

        /// <summary>
        /// This holds the connection string so it can be accessed from 
        /// elsewhere in the program (cDatabaseManager)
        /// </summary>
        private static string con_str;
        public static string ConnectionString
        {
            get 
            { 
                return con_str; 
            }
            private set
            {
                con_str = value;
            }
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //check for sql server installation
            bool database_exist = false;
            bool database_ready = false;
            database_exist = CheckForSQLServer();
            if (database_exist)
            {
                SqlConnection con = new SqlConnection(ConnectionString);
                database_ready = CreateDatabaseIfNotExists(con);
                //change connection string to include 'stock_advisor' database
                ConnectionString = "server=(local)\\" + sql_instance + "; Initial Catalog=stock_advisor; Trusted_Connection=yes";
            }

            //execute program normally
            if (database_ready)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                fLogin login_form = new fLogin();
                if (login_form.ShowDialog() == DialogResult.OK)
                {
                    Application.Run(new fPrimary());
                }
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Database not found! Shutting down", "Stock Advisor Pro");
            }
        }

        /// <summary>
        /// This function checks for a sql server installation
        /// on the user's machine. If found, a connection string
        /// is saved and returns true.
        /// </summary>
        /// <returns>True if sql server is installed</returns>
        private static bool CheckForSQLServer()
        {
            bool SQL_exists = false;

            RegistryView registryView = Environment.Is64BitOperatingSystem ? RegistryView.Registry64 : RegistryView.Registry32;
            using (RegistryKey hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, registryView))
            {
                RegistryKey instanceKey = hklm.OpenSubKey(@"SOFTWARE\Microsoft\Microsoft SQL Server\Instance Names\SQL", false);
                if (instanceKey != null)
                {
                    foreach (var instanceName in instanceKey.GetValueNames())
                    {
                        //sql server found on local machine
                        sql_instance = instanceName;
                        //Console.WriteLine(Environment.MachineName + @"\" + instanceName);

                        ConnectionString = "server=(local)\\" + sql_instance + ";Trusted_Connection=yes;";
                        SQL_exists = true;
                        break; //in case there are multiple instances of sql server installed for some reason
                    }
                }
            }

            return SQL_exists;
        }

        /// <summary>
        /// This function creates the 'stock_advisor' database from
        /// the .dbml file included in the project if the database
        /// does not already exist on the User's pc.
        /// </summary>
        /// <param name="con">SqlConnection to server on local pc</param>
        /// <returns>Returns true if database already exists or is 
        /// created successfully.</returns>
        private static bool CreateDatabaseIfNotExists(SqlConnection con)
        {
            bool result = false;

            try
            {
                string sqlCreateDBQuery = "SELECT database_id FROM sys.databases WHERE Name = 'stock_advisor'";

                using (SqlCommand sqlCmd = new SqlCommand(sqlCreateDBQuery, con))
                {
                    //check for database already exist
                    con.Open();
                    object databaseID = sqlCmd.ExecuteScalar();
                    if ((databaseID == null) || (databaseID == DBNull.Value))
                        databaseID = -1;
                    con.Close();

                    result = ((int)databaseID > 0); //check for more than 0 DB's of this name (stock_advisor)

                    if (result == false)
                    {
                        DialogResult dialogResult = MessageBox.Show("No database found! Create one?", "Stock Advisor Pro", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            //create database from .dbml file to ensure correct creation
                            stock_advisorDataContext context = new stock_advisorDataContext(con);
                            context.CreateDatabase();

                            result = true;
                            MessageBox.Show("Database is Created Successfully", "Stock Advisor Pro", MessageBoxButtons.OK);
                        }
                        else //user selected cancel on create database dialog  
                            result = false;
                    }
                }
            } 
            catch (Exception ex)
            {
                MessageBox.Show("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                result = false;
            }

            return result;
        }
    }
}
