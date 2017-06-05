using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CBA.Core;
using CBA.Data;

namespace CBA.Logic
{
    public class TerminalConfigLogic
    {
        public TerminalConfig GetOnUsConfig()
        {
            TerminalConfigDAO terminalConfigDao = new TerminalConfigDAO();
            TerminalConfig terminalConfig = terminalConfigDao.GetConfig(1);
            return terminalConfig;
        }
        public TerminalConfig GetFeeConfig()
        {
            TerminalConfigDAO terminalConfigDao = new TerminalConfigDAO();
            TerminalConfig terminalConfig = terminalConfigDao.GetConfig(4);
            return terminalConfig;
        }
        public TerminalConfig GetRemoteOnUsConfig()
        {
            TerminalConfigDAO terminalConfigDao = new TerminalConfigDAO();
            TerminalConfig terminalConfig = terminalConfigDao.GetConfig(2);
            return terminalConfig;
        }
        public TerminalConfig GetTSSConfig()
        {
            TerminalConfigDAO terminalConfigDao = new TerminalConfigDAO();
            TerminalConfig terminalConfig = terminalConfigDao.GetConfig(3);
            return terminalConfig;
        }
    }
}
