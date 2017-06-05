using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CBA.Core;
using CBA.Data;

namespace CBA.Logic
{
    public class ATMTerminalLogic
    {
        public void Insert(ATMTerminal atmTerminal)
        {
            ATMTerminalDAO atmTerminalDao = new ATMTerminalDAO();
            atmTerminalDao.Insert(atmTerminal);
        }

        public List<ATMTerminal> GetTerminals()
        {
            List<ATMTerminal> myTerminals = new List<ATMTerminal>();
            ATMTerminalDAO atmTerminalDao = new ATMTerminalDAO();
            myTerminals = atmTerminalDao.GetAll();
            return myTerminals;
        }

        public bool VerifyTerminal(string terminalID, ref ATMTerminal atmTerminal)
        {
            ATMTerminalDAO myAtmTerminalDao = new ATMTerminalDAO();
            bool verify = myAtmTerminalDao.VerifyTerminal(terminalID,ref atmTerminal);
            if (verify)
            {
                return true;
            }
            return false;
        }
    }
}
