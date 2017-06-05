using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBA.Core
{
    public class GLAccount
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public GLCategory GLCategory { get; set; }
        public double Balance { get; set; }
        public Branch Branch { get; set; }
        public string AccountCode { get; set; }
        
        public GLAccount()
        {
            Balance = 0.00;
        }
    }
}
