using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Web.Providers.Entities;
using CBA.Data;
using User = CBA.Core.User;

namespace CBA.Logic
{
    public class UserLogic
    {
      
        public void AddUser(User user)
        {
            UserDAO myUserDao = new UserDAO();
            myUserDao.InsertUser(user);
        }

        public bool VerifyLogin(ref User user)
        {
            UserDAO myUserDao = new UserDAO();
            bool verify = myUserDao.VerifyLogin(ref user);
            if (verify)
            {
                return true;
            }
            else return false;
        }

        public List<User> GetUsers()
        {
            UserDAO myUserDao = new UserDAO();
            List<User> myUsers = myUserDao.GetAll();
            return myUsers;
        }
        
        public void UpdateUser(User user)
        {
            UserDAO myUserDao = new UserDAO();
            myUserDao.UpdateUser(user);
            //if (myUserDao.UpdateUser(user))
            //{
            //    string success = "";
            //    Session[success] = String.Format("User" + user.Username + "edited succesfully");
            //}

        }
        public void SetTeller(User user)
        {
            UserDAO myUserDao = new UserDAO();
            myUserDao.SetTeller(user);
            //if (myUserDao.UpdateUser(user))
            //{
            //    string success = "";
            //    Session[success] = String.Format("User" + user.Username + "edited succesfully");
            //}

        }

        public string EncryptPassword(string pass)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(pass));
            byte[] result = md5.Hash;
            StringBuilder str = new StringBuilder();
            for (int i = 1; i < result.Length; i++)
            {
                str.Append(result[i].ToString("x2"));
            }
            return str.ToString();
        }

        public User GetByID(int userID)
        {
            UserDAO userDao = new UserDAO();
            User user = userDao.GetByID(userID);
            return user;
        }

        public User GetByName(string name)
        {
            UserDAO myUserDao = new UserDAO();

            User myUser = myUserDao.GetByName(name);
            return myUser;
        }

        public bool UpdatePassword(User user)
        {
            UserDAO userDao = new UserDAO();
            try
            {
                userDao.UpdatePassword(user);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
         
        }
        public void SendMail(User user)
        {
            MailMessage msg = new MailMessage();
            msg.From = new MailAddress("josholadele@gmail.com");
            msg.To.Add(user.Email);
            msg.Body = String.Format("Hello {0}, here are your login details: \n Username: {1} \n Password: {2} ", user.FirstName, user.Username, user.Password);
            msg.IsBodyHtml = true;
            msg.Subject = "Bank Of Oladele Log in Details!";
            SmtpClient smt = new SmtpClient();
            smt.Send(msg);
        }  
        //public void SendMail(User user)
        //{

        //    System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();
        //    message.To.Add(user.Email); //"luckyperson@online.microsoft.com");
        //    message.Subject = "Bank Of Oladele Log in Details!";
        //    message.From = new System.Net.Mail.MailAddress("josholadele@gmail.com");
        //    message.Body = String.Format("Hello {0}, here are your login details: \n Username: {1} \n Password: {2} \n Regards.", user.FirstName, user.Username, user.Password);
        //    System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587);
        //    smtp.Send(message);

        //}

    }
}
