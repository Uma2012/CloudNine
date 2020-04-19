using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudNine.Praktik.Model
{
    public interface IProductRepository
    {
      //  List<Products> GetAllProducts();
        Products GetProductById(Guid productid);
        List<string> GetProductsColor();
        List<Products> ProductFilter(int? page, int? pageSize, string color);
       // List<Products> ProductFilter(int? page, int? pageSize, params string[] color);
    }
}
