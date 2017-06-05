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
    public class GLAccountDAO:BaseDAO<GLAccount>
    {
        public void UpdateBalance(GLAccount glAccount)
        {
            Database database = new Database();
            SqlConnection connection = database.connection;

            String query = string.Format("UPDATE [GLAccount] SET Balance = @Balance WHERE AccountCode={0}", glAccount.AccountCode);

            SqlCommand myCommand = new SqlCommand(query, connection);
            myCommand.Parameters.AddWithValue("Balance", glAccount.Balance);
            myCommand.ExecuteNonQuery();
            database.connection.Close();
        }

        public List<GLAccount> GetAssets()
        {
            Type type = typeof(GLAccount);
            List<GLAccount> list = new List<GLAccount>();
            Database database = new Database();
            SqlConnection connection = database.connection;

            String query = "Select\tt1.* from\tdbo.GLAccount t1 LEFT JOIN dbo.GLCategory t2 ON t1.GLCategory = t2.ID where\tt2.AccountCategory = \'Asset\';";
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
                        list.Add((GLAccount)item);
                    }
                }
                else
                {
                    return null;
                }
                return list;
            }

        }

        public List<GLAccount> GetIncomes()
        {
            Type type = typeof(GLAccount);
            List<GLAccount> list = new List<GLAccount>();
            Database database = new Database();
            SqlConnection connection = database.connection;

            String query = "Select\tt1.* from\tdbo.GLAccount t1 LEFT JOIN dbo.GLCategory t2 ON t1.GLCategory = t2.ID where\tt2.AccountCategory = \'Income\';";
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
                        list.Add((GLAccount)item);
                    }
                }
                else
                {
                    return null;
                }
                return list;
            }

        }

        public List<GLAccount> GetExpenses()
        {
            Type type = typeof(GLAccount);
            List<GLAccount> list = new List<GLAccount>();
            Database database = new Database();
            SqlConnection connection = database.connection;

            String query = "Select\tt1.* from\tdbo.GLAccount t1 LEFT JOIN dbo.GLCategory t2 ON t1.GLCategory = t2.ID where\tt2.AccountCategory = \'Expense\';";
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
                        list.Add((GLAccount)item);
                    }
                }
                else
                {
                    return null;
                }
                return list;
            }

        }
        
        
        public List<GLAccount> GetLiabilities()
        {
            Type type = typeof(GLAccount);
            List<GLAccount> list = new List<GLAccount>();
            Database database = new Database();
            SqlConnection connection = database.connection;

            String query = "Select\tt1.* from\tdbo.GLAccount t1 LEFT JOIN dbo.GLCategory t2 ON t1.GLCategory = t2.ID where\tt2.AccountCategory = \'Liability\';";
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
                        list.Add((GLAccount)item);
                    }
                }
                else
                {
                    return null;
                }
                return list;
            }

        }
        public List<GLAccount> GetCapital()
        {
            Type type = typeof(GLAccount);
            List<GLAccount> list = new List<GLAccount>();
            Database database = new Database();
            SqlConnection connection = database.connection;

            String query = "Select\tt1.* from\tdbo.GLAccount t1 LEFT JOIN dbo.GLCategory t2 ON t1.GLCategory = t2.ID where\tt2.AccountCategory = \'Capital\';";
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
                        list.Add((GLAccount)item);
                    }
                }
                else
                {
                    return null;
                }
                return list;
            }

        }

        public List<GLAccount> GetUnAssignedGls()
        {
            Type type = typeof(GLAccount);
            List<GLAccount> list = new List<GLAccount>();
            Database database = new Database();
            SqlConnection connection = database.connection;

            String query = "Select t1.* from dbo.GLAccount t1 LEFT JOIN dbo.TillAssign t2 ON t1.ID = t2.Till where t2.Till is null;";
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
                        list.Add((GLAccount)item);
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
