using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.ComponentModel;

namespace Rocky.Models.ViewModels
{
    public class ProductUserVM
    {
        public ProductUserVM()
        {
            ProductList = new List<Product>();
        }

        public List<Product> ProductList { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
