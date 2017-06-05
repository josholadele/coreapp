using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBA.Core
{
    public class GLCategory
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public AccountCategory AccountCategory { get; set; }
        public string Description { get; set; }
    }
}
