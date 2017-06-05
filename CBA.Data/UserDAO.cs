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
    public class UserDAO : BaseDAO<User>
    {
        public void InsertUser(User user)
        {
            Insert(user);
        }

        public bool VerifyLogin(ref User user)
        {

            Database database = new Database();
            SqlConnection connection = database.connection;
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            String query = "SELECT * FROM [User] WHERE Username= @Username AND Password = @Password";

            SqlCommand myCommand = new SqlCommand(query, connection);
            myCommand.Parameters.AddWithValue("UserName", user.Username);
            myCommand.Parameters.AddWithValue("Password", user.Password);

            using (SqlDataReader reader = myCommand.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        user = new User();
                        user.Username = reader["UserName"].ToString();
                        user.Password = reader["Password"].ToString();
                        user.FirstName = reader["FirstName"].ToString();
                        user.LastName = reader["LastName"].ToString();
                        user.Email = reader["Email"].ToString();
                        user.PhoneNumber = reader["PhoneNumber"].ToString();
                        user.Gender = reader["Gender"].ToString();
                        user.UserRole = reader["UserRole"].ToString();
                        user.IsTeller = Boolean.Parse(reader["IsTeller"].ToString());
                        user.ID = Int16.Parse(reader["ID"].ToString());
                       
                    }
                    return true;
                }
                return false;

            }
        }

        public User GetByUserName(string username)
        {
            User user = null;
            Database database = new Database();
            SqlConnection connection = database.connection;
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            string query = string.Format("SELECT * FROM dbo.Users WHERE Username = '{0}' ", username);
            SqlCommand myCommand = new SqlCommand(query, connection);

            using (SqlDataReader reader = myCommand.ExecuteReader())
            {
                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        user = new User();
                        user.ID = Int32.Parse(reader["ID"].ToString());
                        user.FirstName = reader["FirstName"].ToString();
                        user.LastName = reader["LastName"].ToString();
                        user.Username = reader["Username"].ToString();
                        //user.Branch = new Branch();
                        // user.UserBranch.ID = Int32.Parse(reader["BranchId"].ToString());
                        user.Email = reader["EmailAddress"].ToString();
                        //user.Pass = reader["Pass"].ToString();
                        user.PhoneNumber = reader["PhoneNumber"].ToString();

                    }
                }

                database.connection.Close();
                return user;
            }
        }

        //public User GetByID(int userID)
        //{
        //    User user = null;
        //    Database database = new Database();
        //    SqlConnection connection = database.connection;

        //    string query = string.Format("SELECT * FROM dbo.[User] WHERE ID = '{0}' ", userID);
        //    SqlCommand myCommand = new SqlCommand(query, connection);

        //    using (SqlDataReader reader = myCommand.ExecuteReader())
        //    {
        //        if (reader.HasRows)
        //        {

        //            while (reader.Read())
        //            {
        //                user = new User();
        //                user.ID = Int32.Parse(reader["ID"].ToString());
        //                user.FirstName = reader["FirstName"].ToString();
        //                user.LastName = reader["LastName"].ToString();
        //                user.Username = reader["Username"].ToString();
        //                user.Branch = reader["Username"].ToString();
        //                //user.Branch = new Branch();
        //                //user.UserBranch.ID = Int32.Parse(reader["BranchId"].ToString());
        //                user.Email = reader["Email"].ToString();
        //                user.PhoneNumber = reader["PhoneNumber"].ToString();

        //            }
        //        }

        //        database.connection.Close();
        //        return user;
        //    }

        //}

        public List<User> GetUsers()
        {
            List<User> myUsers = GetAll();
            return myUsers;
        }

        public void UpdateUser(User user)
        {
            Database database = new Database();
            SqlConnection connection = database.connection;
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            

           // String query ="INSERT INTO dbo.course_detail (UserName, CourseCode, CourseUnit, Grade, Year, Semester) VALUES (@Username, @CourseCode, @CourseUnit, @Grade, @Year, @Semester);";
            String query = String.Format("UPDATE dbo.[User] SET FirstName=@FirstName, LastName=@LastName,Email=@Email,PhoneNumber=@PhoneNumber, Branch=@Branch, IsTeller=@IsTeller WHERE ID={0};", user.ID);

            SqlCommand myCommand = new SqlCommand(query, connection);

            myCommand.Parameters.AddWithValue("FirstName", user.FirstName);
            myCommand.Parameters.AddWithValue("LastName", user.LastName);
            myCommand.Parameters.AddWithValue("Email", user.Email);
            myCommand.Parameters.AddWithValue("PhoneNumber", user.PhoneNumber);
            myCommand.Parameters.AddWithValue("Branch", user.Branch.ID);
            myCommand.Parameters.AddWithValue("IsTeller", user.IsTeller);

            
            myCommand.ExecuteNonQuery();
        
        }


        public void UpdatePassword(User user)

        {
            Database database = new Database();
            SqlConnection connection = database.connection;
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            // String query = "SELECT * FROM [User] WHERE Username= @Username AND Password = @Password";
            String query = "UPDATE [User] SET Password = @Password WHERE Username= @Username";

            SqlCommand myCommand = new SqlCommand(query, connection);
            myCommand.Parameters.AddWithValue("Password", user.Password);
            myCommand.Parameters.AddWithValue("Username", user.Username);
            myCommand.ExecuteNonQuery();
            database.connection.Close();

     
         }

        public void SetTeller(User user)
        {
             Database database = new Database();
            SqlConnection connection = database.connection;
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            

           // String query ="INSERT INTO dbo.course_detail (UserName, CourseCode, CourseUnit, Grade, Year, Semester) VALUES (@Username, @CourseCode, @CourseUnit, @Grade, @Year, @Semester);";
            String query = String.Format("UPDATE dbo.[User] SET IsTeller=@IsTeller WHERE ID={0};", user.ID);

            SqlCommand myCommand = new SqlCommand(query, connection);

           myCommand.Parameters.AddWithValue("IsTeller", user.IsTeller);


            myCommand.ExecuteNonQuery();
        }
    }
}