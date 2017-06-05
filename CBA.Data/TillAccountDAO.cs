using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CBA.Core;

namespace CBA.Data
{
    public class TillAccountDAO:BaseDAO<TillAccount>
    {
        public void InsertTill(TillAccount till)
        {
            Insert(till);
        }
        public void GetTills(TillAccount till)
        {
            
        }

    }
}
