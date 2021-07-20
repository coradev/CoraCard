using EFDataAccess.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccess.DAL
{
    public class CategoryDAO
    {
        CoraCardDBContext db = null;
        public CategoryDAO()
        {
            db = new CoraCardDBContext();
        }

        public DbSet<Category> GetAllCategory()
        {
            return db.Categories;
        }

        public int AddNewCategory(Category entity)
        {
            db.Categories.Add(entity);
            db.SaveChanges();
            return entity.CATEGORYID;
        }
    }
}
