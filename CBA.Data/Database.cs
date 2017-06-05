using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;


namespace CBA.Data
{
   public class Database
    {
         
        public SqlConnection connection { get; set; }

        public Database()
        {

            string serverConn = "Server=mssql5.gear.host;Initial Catalog=master;Database=cbadata;Encrypt=False;user=cbadata;password=#sudo123;";
            string server = "localhost";
            string database = "cba_data";

            string connectionString = "Server=" + server + ";Database=" + database
                + ";Trusted_Connection=True;";
            //string connectionString = "DATA SOURCE=" + server + ";" + "INITIAL CATALOG=" + database + ";" + "USER ID=" + username + ";" + "PASSWORD='" + password + "';"; ;


            //string connectionString = ConfigurationManager.ConnectionStrings["connection"].ConnectionString ;

            try
            {
                connection = new SqlConnection(serverConn);
                connection.Open();
               // Console.WriteLine("Connection established");
            }
            catch(Exception e)
            {
                string errorMessage = e.Message;
                Console.WriteLine("Error:,{0}", errorMessage);
                Console.WriteLine("ConnetionString:{0}", connectionString);
            }
        }
    }
}
