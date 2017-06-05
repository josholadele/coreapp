using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CBA.Core;

namespace CBA.Data
{
    public class AccountConfigDAO:BaseDAO<AccountConfig>
    {
        public AccountConfig GetByID(int number)
        {

            AccountConfig accountConfig = new AccountConfig();
            Type type = typeof (AccountConfig);
            Database database = new Database();
            SqlConnection connection = database.connection;
            string accountType = accountConfig.AccountType.ToString();

            String query = null;
            if (number == 1)
            {
                query = string.Format("SELECT [CrInterestRate], [MinimumBalance], [InterestExpenseGL], [MainGL] FROM [AccountConfig] where ID = '{0}'",
                        number);
            }
            else if (number == 2)
            {
                query = string.Format("SELECT [CrInterestRate], [MinimumBalance], [InterestExpenseGL],[COT],[COTIncomeGL],[MainGL] FROM [AccountConfig] where ID = '{0}'",
                        number);

            }
            else if (number == 3)
            {
                query = string.Format("SELECT [DrInterestRate], [InterestIncomeGL],[MainGL] FROM [AccountConfig] where ID = '{0}'",
                        number);
            }

            SqlCommand myCommand = new SqlCommand(query, connection);

            using (SqlDataReader reader = myCommand.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        if (number ==1)
                        {

                            GLAccount glAccount = new GLAccount(),glAccount1 = new GLAccount();
                            glAccount = SetInnerObjectProperty(glAccount, Convert.ToInt32(reader["InterestExpenseGL"]));
                            glAccount1 = SetInnerObjectProperty(glAccount1, Convert.ToInt32(reader["MainGL"]));


                            accountConfig.CrInterestRate = double.Parse(reader["CrInterestRate"].ToString());
                            accountConfig.MinimumBalance = double.Parse(reader["MinimumBalance"].ToString());
                            accountConfig.InterestExpenseGL = glAccount;
                            accountConfig.MainGL = glAccount1;
                        }

                        else if (number==2)
                        {

                            GLAccount glAccount = new GLAccount(), glAccount1 = new GLAccount(), glAccount2 = new GLAccount();
                            glAccount = SetInnerObjectProperty(glAccount, Convert.ToInt32(reader["InterestExpenseGL"]));

                            glAccount1 = SetInnerObjectProperty(glAccount1, Convert.ToInt32(reader["COTIncomeGL"]));
                            glAccount2 = SetInnerObjectProperty(glAccount2, Convert.ToInt32(reader["MainGL"]));


                            accountConfig.CrInterestRate = double.Parse(reader["CrInterestRate"].ToString());
                            accountConfig.MinimumBalance = double.Parse(reader["MinimumBalance"].ToString());
                            accountConfig.COT = double.Parse(reader["COT"].ToString());
                            accountConfig.InterestExpenseGL = glAccount;
                            accountConfig.COTIncomeGL = glAccount1;
                            accountConfig.MainGL = glAccount2;
                        }

                        else if (number == 3)
                        {

                            GLAccount glAccount = new GLAccount(), glAccount1 = new GLAccount();
                            glAccount = SetInnerObjectProperty(glAccount, Convert.ToInt32(reader["InterestIncomeGL"]));
                            glAccount1 = SetInnerObjectProperty(glAccount1, Convert.ToInt32(reader["MainGL"]));


                            accountConfig.DrInterestRate = double.Parse(reader["DrInterestRate"].ToString());
                            accountConfig.InterestIncomeGL = glAccount;
                            accountConfig.MainGL = glAccount1;
                        }

                    }
                    
                }

            }
            return accountConfig;
        }


        public AccountConfig GetByAccountType(string name)
        {
            Database database = new Database();
            SqlConnection connection = database.connection;
            AccountConfig accountConfig = new AccountConfig();
            //string accountType = accountConfig.AccountType.ToString();
            String query=string.Format("Select * from [AccountConfig] where AccountType='{0}'",name);


           SqlCommand myCommand = new SqlCommand(query, connection);

            using (SqlDataReader reader = myCommand.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        if (name =="Savings")
                        {

                            GLAccount glAccount = new GLAccount(),glAccount1 = new GLAccount();
                            glAccount = SetInnerObjectProperty(glAccount, Convert.ToInt32(reader["InterestExpenseGL"]));
                            glAccount1 = SetInnerObjectProperty(glAccount1, Convert.ToInt32(reader["MainGL"]));


                            accountConfig.CrInterestRate = double.Parse(reader["CrInterestRate"].ToString());
                            accountConfig.MinimumBalance = double.Parse(reader["MinimumBalance"].ToString());
                            accountConfig.InterestExpenseGL = glAccount;
                            accountConfig.MainGL = glAccount1;
                        }

                        else if (name =="Current")
                        {

                            GLAccount glAccount = new GLAccount(), glAccount1 = new GLAccount(), glAccount2 = new GLAccount();
                            glAccount = SetInnerObjectProperty(glAccount, Convert.ToInt32(reader["InterestExpenseGL"]));

                            glAccount1 = SetInnerObjectProperty(glAccount1, Convert.ToInt32(reader["COTIncomeGL"]));
                            glAccount2 = SetInnerObjectProperty(glAccount2, Convert.ToInt32(reader["MainGL"]));


                            accountConfig.CrInterestRate = double.Parse(reader["CrInterestRate"].ToString());
                            accountConfig.MinimumBalance = double.Parse(reader["MinimumBalance"].ToString());
                            accountConfig.COT = double.Parse(reader["COT"].ToString());
                            accountConfig.InterestExpenseGL = glAccount;
                            accountConfig.COTIncomeGL = glAccount1;
                            accountConfig.MainGL = glAccount2;
                        }

                        else if (name =="Loan")
                        {

                            GLAccount glAccount = new GLAccount(), glAccount1 = new GLAccount();
                            glAccount = SetInnerObjectProperty(glAccount, Convert.ToInt32(reader["InterestIncomeGL"]));
                            glAccount1 = SetInnerObjectProperty(glAccount1, Convert.ToInt32(reader["MainGL"]));


                            accountConfig.DrInterestRate = double.Parse(reader["DrInterestRate"].ToString());
                            accountConfig.InterestIncomeGL = glAccount;
                            accountConfig.MainGL = glAccount1;
                        }

                    }
                    
                }

            }
            return accountConfig;
        }

        public void SaveConfigUpdate(AccountConfig accountConfig)
        {
            Database database = new Database();

            Type type = typeof(AccountConfig);

            SqlConnection connection = database.connection;
            PropertyInfo[] propertyInfo = type.GetProperties();
            //String query = string.Format("INSERT INTO dbo.[AccountConfig] ({1}) VALUES ({2}) ", type.Name, columnNames,parameterNames);
            //SqlCommand myCommand = new SqlCommand(query, connection);
            //myCommand.Parameters.AddRange(sqlParameters.ToArray());
            //myCommand.ExecuteNonQuery();
            database.connection.Close();
        }

        public void UpdateConfig(AccountConfig accountConfig)
        {
            Database database = new Database();
            SqlConnection connection = database.connection;
            string accountType = accountConfig.AccountType.ToString();
            String query=string.Empty;

            SqlCommand myCommand;

            if (accountType == "Savings")
            {
                //accountConfig.
                query = string.Format("UPDATE dbo.[AccountConfig] SET CrInterestRate=@CrInterestRate, MinimumBalance=@MinimumBalance, InterestExpenseGL=@InterestExpenseGL WHERE AccountType='{0}';", accountType);//InterestExpenseGL=@InterestExpenseGL
                myCommand = new SqlCommand(query, connection);
                myCommand.Parameters.AddWithValue("CrInterestRate", accountConfig.CrInterestRate);
                myCommand.Parameters.AddWithValue("MinimumBalance", accountConfig.MinimumBalance);
                myCommand.Parameters.AddWithValue("InterestExpenseGL", accountConfig.InterestExpenseGL.ID);

            }
            else if (accountType == "Current")
            {
                query =
                    string.Format(
                        "UPDATE dbo.[AccountConfig] SET CrInterestRate=@CrInterestRate, MinimumBalance=@MinimumBalance, InterestExpenseGL=@InterestExpenseGL, COT=@COT, COTIncomeGL=@COTIncomeGL WHERE AccountType='{0}';",
                        accountType); //InterestExpenseGL=@InterestExpenseGL
                myCommand = new SqlCommand(query, connection);

                myCommand.Parameters.AddWithValue("CrInterestRate", accountConfig.CrInterestRate);
                myCommand.Parameters.AddWithValue("MinimumBalance", accountConfig.MinimumBalance);
                myCommand.Parameters.AddWithValue("InterestExpenseGL", accountConfig.InterestExpenseGL.ID);
                myCommand.Parameters.AddWithValue("COT", accountConfig.COT);
                myCommand.Parameters.AddWithValue("COTIncomeGL", accountConfig.COTIncomeGL.ID);
            }
            else
            {
                query = string.Format("UPDATE dbo.[AccountConfig] SET DrInterestRate=@DrInterestRate, InterestIncomeGL=@InterestIncomeGL WHERE AccountType='{0}';", accountType);
                myCommand = new SqlCommand(query, connection);

                myCommand.Parameters.AddWithValue("DrInterestRate", accountConfig.DrInterestRate);
                myCommand.Parameters.AddWithValue("InterestIncomeGL", accountConfig.InterestIncomeGL.ID);
            }

                myCommand.ExecuteNonQuery();

        }
    }
}
