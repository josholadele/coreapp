using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CBA.Core;

namespace CBA.Data
{
    public class ATMTerminalDAO:BaseDAO<ATMTerminal>
    {
        public bool VerifyTerminal(string terminalID, ref ATMTerminal atmTerminal)
        {

            Database database = new Database();
            SqlConnection connection = database.connection;
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            String query = "SELECT * FROM [ATMTerminal] WHERE TerminalID= @TerminalID";

            SqlCommand myCommand = new SqlCommand(query, connection);
            myCommand.Parameters.AddWithValue("TerminalID", terminalID);

            using (SqlDataReader reader = myCommand.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        atmTerminal = new ATMTerminal();
                        atmTerminal.Name = reader["Name"].ToString();
                        atmTerminal.TerminalID = reader["TerminalID"].ToString();
                        atmTerminal.Location = reader["Location"].ToString();
                       

                    }
                    return true;
                }
                return false;

            }
        }

    }
}
