using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CBA.Core;
using CBA.Data;

namespace CBA.Logic
{
    public class GLCategoryLogic
    {
        public void AddGLCategory(GLCategory glCategory)
        {
            GLCategoryDAO glCategoryDao = new GLCategoryDAO();
            glCategoryDao.InsertGLCategory(glCategory);
        }

        public List<GLCategory> GetGLCategories()
        {
            GLCategoryDAO glCategoryDao = new GLCategoryDAO();
            List<GLCategory> glCategories = glCategoryDao.GetAll();
            return glCategories;
        }

        public GLCategory GetByName(string name)
        {
           GLCategoryDAO glCategoryDao = new GLCategoryDAO();
           
           GLCategory glCategory = glCategoryDao.GetCategoryByName(name);
           return glCategory;
        }

        public GLCategory GetByID(int id)
        {
            GLCategoryDAO glCategoryDao = new GLCategoryDAO();
            GLCategory glCategory = glCategoryDao.GetByID(id);
            return glCategory;
        }
    }
}
