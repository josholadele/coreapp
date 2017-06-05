using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CBA.Core;
using CBA.Data;

namespace CBA.Logic
{
    public class TerminalPostingLogic:BaseLogic
    {
        public void Insert(TerminalPosting terminalPosting)
        {
            TerminalPostingDAO terminalPostingDao = new TerminalPostingDAO();
            terminalPostingDao.Insert(terminalPosting);
        }
        public string GetPostingAccountNumber(string ODE)
        {
            TerminalPostingDAO terminalPostingDao = new TerminalPostingDAO();
            TerminalPosting terminalPosting = terminalPostingDao.GetByName(ODE);
            return terminalPosting.AccountNumber;
        }
    }
}
