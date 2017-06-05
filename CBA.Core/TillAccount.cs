using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBA.Core
{
    public class TillAccount
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool IsAssigned { get; set; }
        public double Balance { get; set; }

        public TillAccount()
        {
            IsAssigned = false;
            Balance = 0.00;
        }
    }
}
