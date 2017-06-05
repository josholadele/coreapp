using System.Collections.Generic;
using CBA.Core;

namespace CBA.Data
{
    public class BranchDAO:BaseDAO<Branch>
    {
        public void InsertBranch(Branch branch)
        {
            Insert(branch);
        }

        public List<Branch> GetBranch()
        {
            List<Branch> myBranch = GetAll();
            return myBranch;
        }

       
    }
}
