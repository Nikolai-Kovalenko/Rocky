using Microsoft.EntityFrameworkCore.ChangeTracking;
using Rocky_DatAccess.Repository.IRepository;
using Rocky_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rocky_DatAccess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly AppDbContext _db;

        public CategoryRepository(AppDbContext db): base(db)
        {
            _db = db;       
        }
        public void Update(Category obj)
        {
            /*var objFromDb = _db.Category.FirstOrDefault(u => u.Id == obj.Id);*/
            var objFromDb = base.FirstOrDefault(u => u.Id == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.Name = obj.Name;
                objFromDb.DisplayOrder = obj.DisplayOrder;

            }
        }
    }
}
