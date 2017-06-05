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
    public class GLPostingDAO : BaseDAO<GLPosting>
    {
        public List<int> GetPostingIDsByODE(string ODE)
        {
            List<int> glPostingIDs = new List<int>();
            Database database = new Database();
            SqlConnection connection = database.connection;

            string query = string.Format("SELECT ID FROM [GLPosting] where Narration LIKE '%{0}%' and IsReversible = 'True'", ODE);

            SqlCommand myCommand = new SqlCommand(query, connection);

            using (SqlDataReader reader = myCommand.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        glPostingIDs.Add(Convert.ToInt32(reader["ID"]));
                    }
                }
            }
            connection.Close();

            return glPostingIDs;
        }

        public List<GLPosting> GetPostingsByODE(string ODE)
        {
            List<GLPosting> glPostings = new List<GLPosting>();
            GLPosting glPosting;

            Database database = new Database();
            SqlConnection connection = database.connection;

            string query = string.Format("SELECT * FROM [GLPosting] where Narration LIKE '%{0}%' and IsReversible = 'True'", ODE);

            SqlCommand myCommand = new SqlCommand(query, connection);

            using (SqlDataReader reader = myCommand.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    
                    while (reader.Read())
                    {
                        glPosting = new GLPosting();
                        GLAccount glAccount = new GLAccount(), glAccount1 = new GLAccount();
                        glAccount = SetInnerObjectProperty(glAccount, Convert.ToInt32(reader["AccountToDebit"]));
                        glAccount1 = SetInnerObjectProperty(glAccount1, Convert.ToInt32(reader["AccountToCredit"]));

                        glPosting.ID = Convert.ToInt32(reader["ID"].ToString());
                        glPosting.AccountToDebit = glAccount;
                        glPosting.AccountToCredit = glAccount1;
                        glPosting.Amount = double.Parse(reader["Amount"].ToString());
                        glPosting.Narration = reader["Narration"].ToString();
                        glPosting.TransactionDate = DateTime.Parse(reader["TransactionDate"].ToString());
                        glPosting.IsReversible = bool.Parse(reader["IsReversible"].ToString());
                        glPostings.Add(glPosting);
                    }
                    
                }
            }
            connection.Close();

            return glPostings;

        }

        public void UpdateIsReversible(int id)
        {
            Database database = new Database();
            SqlConnection connection = database.connection;
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            // String query = "SELECT * FROM [User] WHERE Username= @Username AND Password = @Password";
            String query = String.Format("UPDATE [GLPosting] SET IsReversible = 'False' WHERE ID='{0}'",id);

            SqlCommand myCommand = new SqlCommand(query, connection);
            myCommand.Parameters.AddWithValue("ID", id);
            myCommand.ExecuteNonQuery();
            database.connection.Close();
        }
    }
}
