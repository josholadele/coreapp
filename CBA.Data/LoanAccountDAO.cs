using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CBA.Core;

namespace CBA.Data
{
    public class LoanAccountDAO:BaseDAO<LoanAccount>
    {
        public void UpdateBalance(LoanAccount loanAccount)
        {
            Database database = new Database();
            SqlConnection connection = database.connection;

            String query = string.Format("UPDATE [LoanAccount] SET Balance = @Balance WHERE AccountNumber={0}", loanAccount.AccountNumber);
            //String query1 = "update [GLAccount] set Balance=(SELECT SUM(Balance) FROM LoanAccount) where Name='Loan Accounts'";

            SqlCommand myCommand = new SqlCommand(query, connection);
            //SqlCommand myCommand1 = new SqlCommand(query1, connection);
            myCommand.Parameters.AddWithValue("Balance", loanAccount.Balance);
            myCommand.ExecuteNonQuery();

            //myCommand1.ExecuteScalar();
            database.connection.Close();
        }

    }
}
