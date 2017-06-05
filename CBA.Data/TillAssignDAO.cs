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
    public class TillAssignDAO : BaseDAO<TillAssign>
    {
        public void InsertTill(TillAssign till)
        {
            Insert(till);
        }

        public bool CheckIfTellerExists(int ID)
        {
           Database database = new Database();
            SqlConnection connection = database.connection;
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            TillAssign tillAssign = new TillAssign();
            //string accountType = accountConfig.AccountType.ToString();
            String query = string.Format("Select * from [TillAssign] where Teller={0}", ID);


           SqlCommand myCommand = new SqlCommand(query, connection);

            using (SqlDataReader reader = myCommand.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                            User teller = new User();
                            GLAccount glAccount = new GLAccount();
                            teller = SetInnerObjectProperty(teller, Convert.ToInt32(reader["Teller"]));
                            glAccount = SetInnerObjectProperty(glAccount, Convert.ToInt32(reader["Till"]));

                            tillAssign.Teller = teller;
                            tillAssign.Till = glAccount;
                            tillAssign.IsAssigned = Boolean.Parse(reader["IsAssigned"].ToString());
                            
                    }
                    return true;
                }

                else
                {
                    tillAssign = null;
                    return false;
                }

            }
           
        }

        public bool CheckIfTillExists(int ID)
        {
            Database database = new Database();
            SqlConnection connection = database.connection;
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            TillAssign tillAssign = new TillAssign();
            //string accountType = accountConfig.AccountType.ToString();
            String query = string.Format("Select * from [TillAssign] where Till={0}", ID);


            SqlCommand myCommand = new SqlCommand(query, connection);

            using (SqlDataReader reader = myCommand.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        User teller = new User();
                        GLAccount glAccount = new GLAccount();
                        teller = SetInnerObjectProperty(teller, Convert.ToInt32(reader["Teller"]));
                        glAccount = SetInnerObjectProperty(glAccount, Convert.ToInt32(reader["Till"]));

                        tillAssign.Teller = teller;
                        tillAssign.Till = glAccount;
                        tillAssign.IsAssigned = Boolean.Parse(reader["IsAssigned"].ToString());

                    }
                    return true;
                }

                else
                {
                    tillAssign = null;
                    return false;
                }

            }

        }
        
        public void GetTills(TillAssign till)
        {

        }
    }
}
