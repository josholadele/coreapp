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
    public class TerminalConfigDAO:BaseDAO<TerminalConfig>
    {
        public TerminalConfig GetConfig(int ID)
        {
            TerminalConfig terminalConfig = null;
            Database database = new Database();
            SqlConnection connection = database.connection;
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            String query = "SELECT * FROM [TerminalConfig] WHERE ID= @ID";

            SqlCommand myCommand = new SqlCommand(query, connection);
            myCommand.Parameters.AddWithValue("ID", ID);

            using (SqlDataReader reader = myCommand.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        terminalConfig = new TerminalConfig();
                        terminalConfig.Name = reader["Name"].ToString();
                        GLAccount glAccount = new GLAccount();
                        glAccount = SetInnerObjectProperty(glAccount, Convert.ToInt32(reader["GLAccount"]));

                        terminalConfig.GLAccount = glAccount;


                    }
                }
             }
            return terminalConfig;
        }

    }
}
