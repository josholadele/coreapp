using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBA.Core
{
    public class User
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Branch Branch { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string Username { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsTeller { get; set; }
        public string Password { get; set; }
        public string UserRole { get; set; }

        public User()
        {
            IsTeller = false;
        }
    }
}
