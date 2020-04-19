using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using CloudNine.Praktik.Model;
using CloudNine.Praktik.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using PagedList;
using PagedList.Mvc;

namespace CloudNine.Praktik.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductDataLogic _productDataLogic;
        public ProductsController(ProductDataLogic productDataLogic)
        {
            this._productDataLogic = productDataLogic;
        }
        // GET: api/products
        [HttpGet]
        public async Task<List<Products>> GetAsync(int? page, int? pageSize,string color=null)
        {
            // TODO: Returnera alla produkter, ta hänsyn till pagineringsparametrar om sådana skickats in.

            List<Products> allproducts = new List<Products>();

            allproducts = await _productDataLogic.GetAll();


            if ((page != null) && (pageSize != null) && (String.IsNullOrEmpty(color)))
            {
                return allproducts.Skip(((int)page - 1) * (int)pageSize).Take((int)pageSize).ToList();
            }
            if ((page != null) && (pageSize != null) && (!String.IsNullOrEmpty(color)))
            {
                var result = allproducts.Where(x => x.color == color)
                .Select(x => new Products()
                {
                    id = x.id,
                    color = x.color,
                    description = x.description,
                    productName = x.productName
                })
                .ToList();
                return result.Skip(((int)page - 1) * (int)pageSize).Take((int)pageSize).ToList();
            }


            return allproducts;
        }


        // GET: api/products/5

        [HttpGet("{id}")]
        public async Task<Products> GetProductByIDAsync(Guid id)
        {

            var product = await _productDataLogic.ProductByID(id);
            return product;
        }

      




    }
}
