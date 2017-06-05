using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CBA.Core;
using CBA.Data;

namespace CBA.Logic
{
    public class TillAssignLogic
    {
        public void AddTill(TillAssign till)
        {
            TillAssignDAO myTillAssignDao = new TillAssignDAO();
            myTillAssignDao.InsertTill(till);
        }

        public List<TillAssign> GetTillAccounts()
        {
            TillAssignDAO myTillAssignDao = new TillAssignDAO();
            List<TillAssign> tillAssigns = myTillAssignDao.GetAll();
            return tillAssigns;
        }

        public bool CheckIfTellerExists(int ID)
        {
            TillAssignDAO myTillAssignDao = new TillAssignDAO();
            bool check = myTillAssignDao.CheckIfTellerExists(ID);
            return check;
        }
        public bool CheckIfTillExists(int ID)
        {
            TillAssignDAO myTillAssignDao = new TillAssignDAO();
            bool check = myTillAssignDao.CheckIfTillExists(ID);
            return check;
        }

        public TillAssign GetTillByName(string username)
        {
            TillAssignDAO tillAssignDao = new TillAssignDAO();
            TillAssign tillAssign = tillAssignDao.GetByName(username);
            return tillAssign;
        }
        public TillAssign GetTillByTellerID(int id)
        {
            TillAssignDAO tillAssignDao = new TillAssignDAO();
            TillAssign tillAssign = tillAssignDao.GetByID(id);
            return tillAssign;
        }
    }
}
