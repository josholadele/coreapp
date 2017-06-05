using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CBA.Core;

namespace CBA.Data
{
    public class CustomerDAO:BaseDAO<Customer>
    {
        public void InsertCustomer(Customer customer)
        {
            Insert(customer);
        }

        public Customer GetByID(int customerID)
        {
            Customer customer = null;
            Database database = new Database();
            SqlConnection connection = database.connection;

            string query = string.Format("SELECT * FROM dbo.[Customer] WHERE ID = '{0}' ", customerID);
            SqlCommand myCommand = new SqlCommand(query, connection);

            using (SqlDataReader reader = myCommand.ExecuteReader())
            {
                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        customer = new Customer();
                        customer.ID = Int32.Parse(reader["ID"].ToString());
                        customer.Name = reader["Name"].ToString();
                        customer.Address = reader["Address"].ToString();
                        customer.CustomerID = reader["CustomerID"].ToString();
                        //customer.Branch = reader["Username"].ToString();
                        //user.Branch = new Branch();
                        //user.UserBranch.ID = Int32.Parse(reader["BranchId"].ToString());
                        customer.Email = reader["Email"].ToString();
                        customer.PhoneNumber = reader["PhoneNumber"].ToString();

                    }
                }

                database.connection.Close();
                return customer;
            }

        }

        public Customer GetByName(string customerName)
        {
            Customer customer = null;
            Database database = new Database();
            SqlConnection connection = database.connection;

            string query = string.Format("SELECT * FROM dbo.[Customer] WHERE Name = '{0}' ", customerName);
            SqlCommand myCommand = new SqlCommand(query, connection);

            using (SqlDataReader reader = myCommand.ExecuteReader())
            {
                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        customer = new Customer();
                        customer.ID = Int32.Parse(reader["ID"].ToString());
                        customer.Name = reader["Name"].ToString();
                        customer.Address = reader["Address"].ToString();
                        customer.CustomerID = reader["CustomerID"].ToString();
                        //user.Branch = new Branch();
                        //user.UserBranch.ID = Int32.Parse(reader["BranchId"].ToString());
                        customer.Email = reader["Email"].ToString();
                        customer.PhoneNumber = reader["PhoneNumber"].ToString();

                    }
                }

                database.connection.Close();
                return customer;
            }
        }

        public List<Customer> GetCustomers()
        {
            List<Customer> myCustomers = GetAll();
            return myCustomers;
        }

        public void UpdateCustomer(Customer customer)
        {
            Database database = new Database();
            SqlConnection connection = database.connection;
            

           // String query ="INSERT INTO dbo.course_detail (UserName, CourseCode, CourseUnit, Grade, Year, Semester) VALUES (@Username, @CourseCode, @CourseUnit, @Grade, @Year, @Semester);";
            String query = String.Format("UPDATE dbo.[Customer] SET CustomerID=@CustomerID, Name=@Name, Address=@Address,Email=@Email,PhoneNumber=@PhoneNumber, Gender=@Gender WHERE ID={0};", customer.ID);

            SqlCommand myCommand = new SqlCommand(query, connection);

            myCommand.Parameters.AddWithValue("CustomerID", customer.CustomerID);
            myCommand.Parameters.AddWithValue("Name", customer.Name);
            myCommand.Parameters.AddWithValue("Address", customer.Address);
            myCommand.Parameters.AddWithValue("Email", customer.Email);
            myCommand.Parameters.AddWithValue("PhoneNumber", customer.PhoneNumber);
            myCommand.Parameters.AddWithValue("Gender", customer.Gender);
            
            myCommand.ExecuteNonQuery();
        
        }
        
    }
}
