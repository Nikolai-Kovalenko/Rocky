using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Rocky_DatAccess.Repository.IRepository;
using Rocky_Models;
using Rocky_Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rocky_DatAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly AppDbContext _db;

        public ProductRepository(AppDbContext db): base(db)
        {
            _db = db;       
        }

        public IEnumerable<SelectListItem> GetAllDropdownList(string obj)
        {
            if(obj == WC.CategotyName)
            {
                return _db.Category.Select(i => new SelectListItem
                {
                    Text = i.Name,  
                    Value = i.Id.ToString()
                });
            }
            if(obj == WC.ApplicationTypeName)
            {
                return _db.ApplicationType.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                });
            }
            return null;
        }   

        public void Update(Product obj)
        {
            _db.Product.Update(obj);
        }
    }
}
