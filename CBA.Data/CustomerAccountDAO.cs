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
    public class CustomerAccountDAO:BaseDAO<CustomerAccount>
    {
        public void AddAccount(CustomerAccount customerAccount)
        {
            Insert(customerAccount);
        }
        public void UpdateBalance(CustomerAccount customerAccount)
        {
            Database database = new Database();
            SqlConnection connection = database.connection;

            String query = string.Format("UPDATE [CustomerAccount] SET Balance =@Balance WHERE AccountNumber='{0}'", customerAccount.AccountNumber);
            //String query1 = string.Empty;
            //    if (customerAccount.AccountNumber.StartsWith("1"))
            //    {
            //        query1 = "update [GLAccount] set Balance=(SELECT SUM(Balance) FROM CustomerAccount where AccountType='Savings') where Name='Customer Savings Accounts'";
            //    }
            //    else if (customerAccount.AccountNumber.StartsWith("2"))
            //    {
            //        query1 = "update [GLAccount] set Balance=(SELECT SUM(Balance) FROM CustomerAccount where AccountType='Current') where Name='Customer Current Accounts'";
            //    }

            SqlCommand myCommand = new SqlCommand(query, connection);
            myCommand.Parameters.AddWithValue("Balance", customerAccount.Balance);
            myCommand.ExecuteNonQuery();
           // SqlCommand myCommand1 = new SqlCommand(query1, connection);
            //myCommand1.Parameters.AddWithValue("Balance", customerAccount.Balance);
            //myCommand1.ExecuteScalar();
            database.connection.Close();
        }

        public void UpdateCOTCharge(CustomerAccount customerAccount)
        {
            Database database = new Database();
            SqlConnection connection = database.connection;
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            String query = string.Format("UPDATE [CustomerAccount] SET COTCharge =@COTCharge WHERE AccountNumber={0}", customerAccount.AccountNumber);
          
            SqlCommand myCommand = new SqlCommand(query, connection);
            myCommand.Parameters.AddWithValue("COTCharge", customerAccount.COTCharge);
            myCommand.ExecuteNonQuery();
            
            connection.Close();
        }
    }
}
