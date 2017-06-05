using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CBA.Core;
using CBA.Data;

namespace CBA.Logic
{
    public class GLPostingLogic:BaseLogic
    {
        public void Post(GLPosting glPosting)
        {
            GLPostingDAO glPostingDao = new GLPostingDAO();
            glPostingDao.Insert( glPosting);
        }

        public List<GLPosting> GetGLPostings()
        {
            GLPostingDAO glPostingDao = new GLPostingDAO();
            List<GLPosting> glPostings = glPostingDao.GetAll();
            return glPostings;
        }
        public List<int> GetPostingIDsByODE(string ODE)
        {
            List<int> postingIds = new List<int>();
            GLPostingDAO glPostingDao = new GLPostingDAO();
            postingIds = glPostingDao.GetPostingIDsByODE(ODE);
            return postingIds;
        }

        public List<GLPosting> GetPostingsByODE(string ODE)
        {
            List<GLPosting> postings = new List<GLPosting>();
            GLPostingDAO glPostingDao = new GLPostingDAO();
            postings = glPostingDao.GetPostingsByODE(ODE);
            return postings;
        }
        public GLPosting GetById(int Id)
        {
            GLPosting glPosting = new GLPosting();
            GLPostingDAO glPostingDao = new GLPostingDAO();
            glPosting = glPostingDao.GetByID(Id);
            return glPosting;
        }

        public void UpdateIsReversible(int id)
        {
            GLPostingDAO glPostingDao = new GLPostingDAO();
            glPostingDao.UpdateIsReversible(id);
        }
    }
}
