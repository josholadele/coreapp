using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace CBA.Data
{
    public class BaseDAO<T> where T : class, new()
    {

        public void Insert(T item)
        {

            Type type = typeof(T);

            PropertyInfo[] propertyInfo = type.GetProperties();
            string columnNames = string.Empty;
            string parameterNames = string.Empty;
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            foreach (var property in propertyInfo)
            {
                Type propertyType = property.PropertyType;
                if (propertyType.IsClass && !propertyType.Name.Equals("String"))
                {
                    object innerEntity = property.GetValue(item);
                    PropertyInfo innerPropertyInfo = propertyType.GetProperty("ID");
                   // value = innerPropertyInfo.GetValue(innerEntity);
                    columnNames += "," + property.Name;
                    parameterNames += ",@" + property.Name;

                    SqlParameter sqlParameter1 = new SqlParameter(property.Name, innerPropertyInfo.GetValue(innerEntity));
                    sqlParameters.Add(sqlParameter1);
                    continue;

                }
                if (propertyType.IsEnum)
                {
                    columnNames += "," + property.Name;
                    parameterNames += ",@" + property.Name;
                    var value = property.GetValue(item).ToString();

                    SqlParameter sqlParameter = new SqlParameter(property.Name, value);
                    sqlParameters.Add(sqlParameter);
                    continue;
                }

                if (property.Name == "ID")
                {
                    continue;
                }
                else
                {
                    columnNames += "," + property.Name;
                    parameterNames += ",@" + property.Name;
                    SqlParameter sqlParameter = new SqlParameter(property.Name, property.GetValue(item));
                    sqlParameters.Add(sqlParameter);
                }
            }
            columnNames = columnNames.Remove(0, 1);
            parameterNames = parameterNames.Remove(0, 1);
            Database database = new Database();

            SqlConnection connection = database.connection;
            if(connection.State == ConnectionState.Closed)
            { 
            connection.Open();
            }
            String query = string.Format("INSERT INTO dbo.[{0}] ({1}) VALUES ({2}) ", type.Name, columnNames, parameterNames);

            SqlCommand myCommand = new SqlCommand(query, connection);
            myCommand.Parameters.AddRange(sqlParameters.ToArray());
            myCommand.ExecuteNonQuery();
            connection.Close();
        }

        protected U SetInnerObjectProperty<U>(U innerObject, string name) where U : class, new()
        {

            Type type = innerObject.GetType();
            U entity = new U();
            //Get DB connection
            Database database = new Database();
            SqlConnection connection = database.connection;
            connection.Open();
            //Get properties of the class
            PropertyInfo[] propertyInfo = type.GetProperties();

            String query = string.Format("SELECT * FROM [{0}] where Name = '{1}'", type.Name, name);
            SqlCommand myCommand = new SqlCommand(query, connection);

            using (SqlDataReader reader = myCommand.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        object item = type.GetConstructor(new Type[] { }).Invoke(new object[] { });
                        foreach (var property in propertyInfo)
                        {
                            Type propertyType = property.PropertyType;

                            if (propertyType.IsClass && !propertyType.Name.Equals("String"))
                            {
                                Type innerEntity = propertyType.GetTypeInfo();
                                object item2 = innerEntity.GetConstructor(new Type[] { }).Invoke(new object[] { });
                                PropertyInfo innerPropertyInfo = propertyType.GetProperty("Name");

                                innerPropertyInfo.SetValue(item2, Convert.ToInt32(reader[innerPropertyInfo.Name]));
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
                        entity = (U)item;
                    }
                }



            }
            connection.Close();
            return entity;
        }

        protected U SetInnerObjectProperty<U>(U innerObject, int id) where U : class, new()
        {

            Type type = innerObject.GetType();
            U entity = new U();
            //Get DB connection
            Database database = new Database();

            SqlConnection connection = database.connection;
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            //Get properties of the class
            PropertyInfo[] propertyInfo = type.GetProperties();

            String query = string.Format("SELECT * FROM [{0}] where ID = {1}", type.Name, id);
            SqlCommand myCommand = new SqlCommand(query, connection);

            using (SqlDataReader reader = myCommand.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        object item = type.GetConstructor(new Type[] { }).Invoke(new object[] { });
                        foreach (var property in propertyInfo)
                        {
                            Type propertyType = property.PropertyType;

                            if (propertyType.IsClass && !propertyType.Name.Equals("String"))
                            {
                                Type innerEntity = propertyType.GetTypeInfo();
                                object item2 = innerEntity.GetConstructor(new Type[] { }).Invoke(new object[] { });
                                PropertyInfo innerPropertyInfo = propertyType.GetProperty("ID");

                                innerPropertyInfo.SetValue(item2, Convert.ToInt32(reader[property.Name]));
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
                        entity = (U)item;
                    }
                }



            }
            connection.Close();
            return entity;
        }
        

        public List<T> GetAll()
        {
            Type type = typeof(T);
            List<T> list = new List<T>();
            Database database = new Database();
            SqlConnection connection = database.connection;
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            String query = string.Format("SELECT * FROM [{0}] ", type.Name);
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
                        list.Add((T)item);
                    }
                }
                else
                {
                    return null;
                }
                connection.Close();
                return list;
            }

        }

        public List<T> GetAll2()
        {
            Type type = typeof(T);
            List<T> list = new List<T>();
            Database database = new Database();
            SqlConnection connection = database.connection;
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            String query = string.Format("SELECT * FROM [{0}] ", type.Name);
            SqlCommand myCommand = new SqlCommand(query, connection);

            using (SqlDataReader reader = myCommand.ExecuteReader())
            {
                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
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

                                item2 = SetInnerObjectProperty(item2, Convert.ToString(reader[property.Name]));
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
                        list.Add((T)item);
                    }
                }
                else
                {
                    return null;
                }
                connection.Close();
                return list;
            }

        }

        public T GetByName(string name)
       
        {
            Type type = typeof(T);
            T entity = new T();
            //Get DB connection
            Database database = new Database();
            SqlConnection connection = database.connection;
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            String query = String.Empty;
            if (type.Name=="CustomerAccount")
            {
                 query = string.Format("SELECT * FROM [{0}] where AccountNumber = '{1}'", type.Name, name);
            }
            else if (type.Name == "GLPosting")
            {
                query = string.Format("SELECT * FROM [{0}] where Narration LIKE '%{1}%' and IsReversible = 'True'", type.Name, name);
            }
            else if (type.Name == "TerminalPosting")
            {
                query = string.Format("SELECT * FROM [{0}] where ODE = {1}", type.Name, name);
            }
            else if (type.Name == "User")
            {
                query = string.Format("SELECT * FROM [{0}] where Username = '{1}'", type.Name, name);
            }
            else if (type.Name == "AccountConfig")
            {
                query = string.Format("SELECT * FROM [{0}] where AccountType = '{1}'", type.Name, name);
            }
            else
            {
                 query = string.Format("SELECT * FROM [{0}] where Name = '{1}'", type.Name, name);

            }
            SqlCommand myCommand = new SqlCommand(query, connection);

            using (SqlDataReader reader = myCommand.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        //Create instance and properties of the class
                        object item = type.GetConstructor(new Type[] { }).Invoke(new object[] { });
                        PropertyInfo[] propertyInfo = type.GetProperties();
                        foreach (var property in propertyInfo)
                        {
                            Type propertyType = property.PropertyType;

                            if (propertyType.IsClass && !propertyType.Name.Equals("String"))
                            {
                                //Create an instance of the inner class parameter
                                Type innerEntity = propertyType.GetTypeInfo();
                                object item2 = innerEntity.GetConstructor(new Type[] { }).Invoke(new object[] { });
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


                        entity = (T)item;
                    }

                }

            }
            connection.Close();
            return entity;
        }

        public T GetByIDg(int number)
        {
            Type type = typeof(T);
            T entity = new T();
            //Get DB connection
            Database database = new Database();
            SqlConnection connection = database.connection;
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            String query = string.Format("SELECT * FROM [{0}] where ID = '{1}'", type.Name, number);
            SqlCommand myCommand = new SqlCommand(query, connection);

            using (SqlDataReader reader = myCommand.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        //Create instance and properties of the class
                        object item = type.GetConstructor(new Type[] { }).Invoke(new object[] { });
                        PropertyInfo[] propertyInfo = type.GetProperties();
                        foreach (var property in propertyInfo)
                        {
                            Type propertyType = property.PropertyType;

                            if (propertyType.IsClass && !propertyType.Name.Equals("String"))
                            {
                                //Create an instance of the inner class parameter
                                Type innerEntity = propertyType.GetTypeInfo();
                                object item2 = innerEntity.GetConstructor(new Type[] { }).Invoke(new object[] { });
                                PropertyInfo innerId = propertyType.GetProperty("ID");


                                item2 = SetInnerObjectProperty(item2, Convert.ToString(reader[innerEntity.Name]));
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


                        entity = (T)item;
                    }

                }

            }
            connection.Close();
            return entity;
        }

        public T GetByID(int number)
        {
            Type type = typeof(T);
            T entity = new T();
            //Get DB connection
            Database database = new Database();
            SqlConnection connection = database.connection;
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            String query = "";
            if (type.Name == "TillAssign")
            {
                query = string.Format("SELECT * FROM [{0}] where Teller = '{1}'", type.Name, number);
            }
            else
            {
            
                query = string.Format("SELECT * FROM [{0}] where ID = '{1}'", type.Name, number);
            }
            SqlCommand myCommand = new SqlCommand(query, connection);

            using (SqlDataReader reader = myCommand.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        //Create instance and properties of the class
                        object item = type.GetConstructor(new Type[] { }).Invoke(new object[] { });
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


                        entity = (T)item;
                    }

                }

            }
            connection.Close();
            return entity;
        }

        public bool Update(T item)
        {
            Type type = typeof(T);

            PropertyInfo[] propertyInfo = type.GetProperties();

            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            var id = type.GetProperty("ID").GetValue(item);
            string endOfQuery = "";
            object value = new object();


            foreach (var property in propertyInfo)
            {

                Type propertyType = property.PropertyType;

                if (propertyType.IsClass && !propertyType.Name.Equals("String"))
                {
                    object innerEntity = property.GetValue(item);


                    PropertyInfo innerPropertyInfo = propertyType.GetProperty("ID");
                    if (!innerPropertyInfo.GetValue(innerEntity).Equals(null))
                    {
                        value = innerPropertyInfo.GetValue(innerEntity);

                        endOfQuery += propertyType.Name + "ID =@" + propertyType.Name + ",";

                        SqlParameter sqlParameter1 = new SqlParameter(propertyType.Name, value);
                        sqlParameters.Add(sqlParameter1);
                        continue;
                    }
                    else if (propertyType.IsEnum)
                    {

                        endOfQuery += property.Name + "=@" + property.Name + ",";
                        value = (int)property.GetValue(item);

                        SqlParameter sqlParameter = new SqlParameter(property.Name, value);
                        sqlParameters.Add(sqlParameter);
                        continue;
                    }

                }

                if (property.Name == "ID")
                {
                    continue;
                }
                else
                {
                    if (property.GetValue(item) != null)
                    {
                        endOfQuery += property.Name + "=@" + property.Name + ",";
                        value = property.GetValue(item);

                        SqlParameter sqlParameter = new SqlParameter(property.Name, value);
                        sqlParameters.Add(sqlParameter);
                        value = new object();
                    }
                }

            }

            Database database = new Database();
            endOfQuery = endOfQuery.Remove(endOfQuery.Length - 1, 1);
            SqlConnection connection = database.connection;
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            String query = string.Format("UPDATE dbo.[{0}] SET {1} WHERE ID = {2} ", type.Name, endOfQuery, id);
            SqlCommand myCommand = new SqlCommand(query, connection);
            myCommand.Parameters.AddRange(sqlParameters.ToArray());
            int result = myCommand.ExecuteNonQuery();
            if (result > 0)
            {
                return true;

            }
            connection.Close();


            return false;
        }

    }

    
}

