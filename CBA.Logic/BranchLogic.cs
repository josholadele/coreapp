using System.Collections.Generic;
using CBA.Core;
using CBA.Data;

namespace CBA.Logic
{
    public class BranchLogic
    {
      
        public void AddBranch(Branch branch)
        {
            BranchDAO myBranchDao = new BranchDAO();
            myBranchDao.InsertBranch(branch);
        }

       public List<Branch> GetBranch()
        {
            BranchDAO myBranchDao = new BranchDAO();
            List<Branch> myBranch = myBranchDao.GetAll();
            return myBranch;
        }

       public Branch GetByName(string name)
       {
           BranchDAO myBranchDao = new BranchDAO();

           Branch myBranch = myBranchDao.GetByName(name);
           return myBranch;
       }
    }
}