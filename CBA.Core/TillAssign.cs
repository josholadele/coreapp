using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBA.Core
{
    public class TillAssign
    {
        public int ID { get; set; }
        public User Teller { get; set; }
        public GLAccount Till { get; set; }
        public bool IsAssigned { get; set; }

        public TillAssign()
        {
            IsAssigned = false;
        }
    }
}
