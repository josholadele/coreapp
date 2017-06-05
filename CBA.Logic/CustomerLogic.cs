using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CBA.Core;
using CBA.Data;

namespace CBA.Logic
{
    public class CustomerLogic
    {
        public void CreateCustomer(Customer customer)
        {
            CustomerDAO myCustomerDao = new CustomerDAO();
            myCustomerDao.InsertCustomer(customer);
        }
        public List<Customer> ViewCustomers(Customer customer)
        {
            CustomerDAO myCustomerDao = new CustomerDAO();
            List<Customer> customerList = myCustomerDao.GetAll();
            return customerList;
        }

        

        public List<Customer> GetCustomers()
        {
            CustomerDAO myCustomerDao = new CustomerDAO();
            List<Customer> myCustomers = myCustomerDao.GetAll();
            return myCustomers;
        }

        public Customer GetByID(int customerID)
        {
            CustomerDAO customerDao = new CustomerDAO();
            Customer customer = customerDao.GetByID(customerID);
            return customer;
        }

        public Customer GetByName(string customerName)
        {
            CustomerDAO customerDao = new CustomerDAO();
            Customer customer = customerDao.GetByName(customerName);
            return customer;
        }

        public string GenerateID()
        {
            Random rng = new Random();
            StringBuilder CustomerIDbuilder = new StringBuilder();
            for (int i = 0; i < 4; i++)
            {
              CustomerIDbuilder.Append(rng.Next(10));
            }
            String CustomerID = CustomerIDbuilder.ToString();
            return CustomerID;
        }

        public void SendConfirmationMail(Customer customer)
        {

        }

        public void UpdateCustomer(Customer customer)
        {
            CustomerDAO myCustomerDao = new CustomerDAO();
            myCustomerDao.UpdateCustomer(customer);
        }
    }
}
