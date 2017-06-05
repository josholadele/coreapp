using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CBA.Core;

namespace CBA.Data
{
    public class FinancialReportDAO:BaseDAO<FinancialReport>
    {
       public void GetBalanceSheet()
       {
           FinancialReport fr = new FinancialReport();
           //fr.Report=GetAll();
       }

       public List<GLPosting> GetDrGLPostingsByDate(int accountID,DateTime from, DateTime to)
        {
            Type type = typeof(GLPosting);
            List<GLPosting> list = new List<GLPosting>();
            Database database = new Database();
            SqlConnection connection = database.connection;
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            //string query1 = String.Format("select * from [GLPosting] where  AccountToDebit = {1}, DatePosted >= {0} and DatePosted <= {2}", from, accountID, to);
            string query = String.Format("select distinct t1.* from [GLPosting] t1 left join [GLAccount] t2 ON t1.AccountToDebit = t2.ID where t1.AccountToDebit={0} and (t1.TransactionDate >= '{1}' and t1.TransactionDate <= '{2}')", accountID, from, to);
 
           SqlCommand myCommand = new SqlCommand(query, connection);

            using (SqlDataReader reader = myCommand.ExecuteReader())
            {
                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        // ReSharper disable once PossibleNullReferenceException
                        var item = type.GetConstructor(new Type[] { }).Invoke(new object[] { });    //instatiating a class generically
                        PropertyInfo[] propertyInfo = type.GetProperties();
                        foreach (var property in propertyInfo)
                        {
                            Type propertyType = property.PropertyType;

                            if (propertyType.IsClass && !propertyType.Name.Equals("String"))
                            {
                                Type innerEntity = propertyType.GetTypeInfo();
                                object item2 = innerEntity.GetConstructor(new Type[] { }).Invoke(new object[] { });
                                //PropertyInfo innerId = propertyType.GetProperty("ID");

                                PropertyInfo innerId = propertyType.GetProperty("ID");

                                item2 = SetInnerObjectProperty(item2, Convert.ToInt32(reader[property.Name]));
                                property.SetValue(item, item2);
                            }
                            else if (propertyType.IsEnum)
                            {
                                string val = Convert.ToString(reader[property.Name]);
                                if (val != string.Empty)
                                {
                                    property.SetValue(item, Enum.Parse(propertyType, val));
                                }
                                else
                                {
                                    continue;
                                }
                            }
                            else if (property.PropertyType == typeof(Int64))
                            {
                                property.SetValue(item, Convert.ToInt64(reader[property.Name]));
                            }
                            else if (property.PropertyType == typeof(Int32))
                            {
                                property.SetValue(item, Convert.ToInt32(reader[property.Name]));
                            }
                            else
                            {
                                property.SetValue(item, reader[property.Name]);
                            }
                        }
                        list.Add((GLPosting)item);
                    }
                }
                else
                {
                    return null;
                }
                return list;
            }

        }

       public List<GLPosting> GetCrGLPostingsByDate(int accountID, DateTime from, DateTime to)
       {
           Type type = typeof(GLPosting);
           List<GLPosting> list = new List<GLPosting>();
           Database database = new Database();
           SqlConnection connection = database.connection;
           
           if (connection.State == ConnectionState.Closed)
           {
               connection.Open();
           }

           string query1 = String.Format("select * from [GLPosting] where  AccountToCredit = {1} and TransactionDate >= '{0}' and TransactionDate <= '{2}'", from, accountID, to);
           string query = String.Format("select distinct t1.* from [GLPosting] t1 left join [GLAccount] t2 ON t1.AccountToCredit = t2.ID where t1.AccountToCredit={0} and (t1.TransactionDate >= '{1}' and t1.TransactionDate <= '{2}')", accountID, from, to);

           SqlCommand myCommand = new SqlCommand(query, connection);

           using (SqlDataReader reader = myCommand.ExecuteReader())
           {
               if (reader.HasRows)
               {

                   while (reader.Read())
                   {
                       // ReSharper disable once PossibleNullReferenceException
                       var item = type.GetConstructor(new Type[] { }).Invoke(new object[] { });    //instatiating a class generically
                       PropertyInfo[] propertyInfo = type.GetProperties();
                       foreach (var property in propertyInfo)
                       {
                           Type propertyType = property.PropertyType;

                           if (propertyType.IsClass && !propertyType.Name.Equals("String"))
                           {
                               Type innerEntity = propertyType.GetTypeInfo();
                               object item2 = innerEntity.GetConstructor(new Type[] { }).Invoke(new object[] { });
                               //PropertyInfo innerId = propertyType.GetProperty("ID");

                               PropertyInfo innerId = propertyType.GetProperty("ID");

                               item2 = SetInnerObjectProperty(item2, Convert.ToInt32(reader[property.Name]));
                               property.SetValue(item, item2);
                           }
                           else if (propertyType.IsEnum)
                           {
                               string val = Convert.ToString(reader[property.Name]);
                               if (val != string.Empty)
                               {
                                   property.SetValue(item, Enum.Parse(propertyType, val));
                               }
                               else
                               {
                                   continue;
                               }
                           }
                           else if (property.PropertyType == typeof(Int64))
                           {
                               property.SetValue(item, Convert.ToInt64(reader[property.Name]));
                           }
                           else if (property.PropertyType == typeof(Int32))
                           {
                               property.SetValue(item, Convert.ToInt32(reader[property.Name]));
                           }
                           else
                           {
                               property.SetValue(item, reader[property.Name]);
                           }
                       }
                       list.Add((GLPosting)item);
                   }
               }
               else
               {
                   return null;
               }
               return list;
           }

       }
       
       public void GetProfitAndLoss()
        {

        }
       
       public void GetTrialBalance()
        {

        }

        public List<GLPosting> GetDrGLPostings(int accountID)
        {
            Type type = typeof(GLPosting);
            List<GLPosting> list = new List<GLPosting>();
            Database database = new Database();
            SqlConnection connection = database.connection;

            //string query1 = String.Format("select * from [GLPosting] where  AccountToDebit = {1}, DatePosted >= {0} and DatePosted <= {2}", from, accountID, to);
           string query = String.Format("select distinct t1.* from [GLPosting] t1 left join [GLAccount] t2 ON t1.AccountToDebit = t2.ID where t1.AccountToDebit={0}",accountID);
 
           SqlCommand myCommand = new SqlCommand(query, connection);

            using (SqlDataReader reader = myCommand.ExecuteReader())
            {
                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        // ReSharper disable once PossibleNullReferenceException
                        var item = type.GetConstructor(new Type[] { }).Invoke(new object[] { });    //instatiating a class generically
                        PropertyInfo[] propertyInfo = type.GetProperties();
                        foreach (var property in propertyInfo)
                        {
                            Type propertyType = property.PropertyType;

                            if (propertyType.IsClass && !propertyType.Name.Equals("String"))
                            {
                                Type innerEntity = propertyType.GetTypeInfo();
                                object item2 = innerEntity.GetConstructor(new Type[] { }).Invoke(new object[] { });
                                //PropertyInfo innerId = propertyType.GetProperty("ID");

                                PropertyInfo innerId = propertyType.GetProperty("ID");

                                item2 = SetInnerObjectProperty(item2, Convert.ToInt32(reader[property.Name]));
                                property.SetValue(item, item2);
                            }
                            else if (propertyType.IsEnum)
                            {
                                string val = Convert.ToString(reader[property.Name]);
                                if (val != string.Empty)
                                {
                                    property.SetValue(item, Enum.Parse(propertyType, val));
                                }
                                else
                                {
                                    continue;
                                }
                            }
                            else if (property.PropertyType == typeof(Int64))
                            {
                                property.SetValue(item, Convert.ToInt64(reader[property.Name]));
                            }
                            else if (property.PropertyType == typeof(Int32))
                            {
                                property.SetValue(item, Convert.ToInt32(reader[property.Name]));
                            }
                            else
                            {
                                property.SetValue(item, reader[property.Name]);
                            }
                        }
                        list.Add((GLPosting)item);
                    }
                }
                else
                {
                    return null;
                }
                return list;
            }

        


        }
        public List<GLPosting> GetCrGLPostings(int accountID)
        {
           
            Type type = typeof(GLPosting);
            List<GLPosting> list = new List<GLPosting>();
            Database database = new Database();
            SqlConnection connection = database.connection;

           string query = String.Format("select distinct t1.* from [GLPosting] t1 left join [GLAccount] t2 ON t1.AccountToCrebit = t2.ID where t1.AccountToDebit={0}",accountID);
 
           SqlCommand myCommand = new SqlCommand(query, connection);

            using (SqlDataReader reader = myCommand.ExecuteReader())
            {
                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        // ReSharper disable once PossibleNullReferenceException
                        var item = type.GetConstructor(new Type[] { }).Invoke(new object[] { });    //instatiating a class generically
                        PropertyInfo[] propertyInfo = type.GetProperties();
                        foreach (var property in propertyInfo)
                        {
                            Type propertyType = property.PropertyType;

                            if (propertyType.IsClass && !propertyType.Name.Equals("String"))
                            {
                                Type innerEntity = propertyType.GetTypeInfo();
                                object item2 = innerEntity.GetConstructor(new Type[] { }).Invoke(new object[] { });
                                //PropertyInfo innerId = propertyType.GetProperty("ID");

                                PropertyInfo innerId = propertyType.GetProperty("ID");

                                item2 = SetInnerObjectProperty(item2, Convert.ToInt32(reader[property.Name]));
                                property.SetValue(item, item2);
                            }
                            else if (propertyType.IsEnum)
                            {
                                string val = Convert.ToString(reader[property.Name]);
                                if (val != string.Empty)
                                {
                                    property.SetValue(item, Enum.Parse(propertyType, val));
                                }
                                else
                                {
                                    continue;
                                }
                            }
                            else if (property.PropertyType == typeof(Int64))
                            {
                                property.SetValue(item, Convert.ToInt64(reader[property.Name]));
                            }
                            else if (property.PropertyType == typeof(Int32))
                            {
                                property.SetValue(item, Convert.ToInt32(reader[property.Name]));
                            }
                            else
                            {
                                property.SetValue(item, reader[property.Name]);
                            }
                        }
                        list.Add((GLPosting)item);
                    }
                }
                else
                {
                    return null;
                }
                return list;
            }

       }
    }
}
