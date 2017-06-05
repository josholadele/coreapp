using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBA.Core
{
    public class EOD
    {
        public bool BusinessIsOpen { get; set; }
        public DateTime FinancialDate { get; set; }

        public EOD()
        {
            BusinessIsOpen = true;
        }
    }

}
