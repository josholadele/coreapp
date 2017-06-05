using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CBA.Core;

namespace CBA.Data
{
    public class GLCategoryDAO : BaseDAO<GLCategory>
    {
        public void InsertGLCategory(GLCategory glCategory)
        {
            Insert(glCategory);
        }

        public GLCategory GetCategoryByName(string name)
        {
            GLCategory glCategory = new GLCategory();
            glCategory = GetByName(name);
            return glCategory;
        }
    }
}
