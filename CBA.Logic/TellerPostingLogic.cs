using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CBA.Core;
using CBA.Data;

namespace CBA.Logic
{
    public class TellerPostingLogic:BaseLogic
    {
        
        public void Post(TellerPosting tellerPosting)
        {
            TellerPostingDAO tellerPostingDao = new TellerPostingDAO();
            tellerPostingDao.Insert(tellerPosting);
        }
        public List<TellerPosting> GetTellerPostings()
        {
            TellerPostingDAO tellerPostingDao = new TellerPostingDAO();
            List<TellerPosting> tellerPostings = tellerPostingDao.GetAll();
            return tellerPostings;
        }
    }
}
