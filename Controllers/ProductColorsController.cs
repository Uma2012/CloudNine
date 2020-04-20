using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CloudNine.Praktik.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CloudNine.Praktik.Controllers
{
    // GET: api/productcolors
    [Route("api/[controller]")]
    [ApiController]
    public class ProductColorsController : ControllerBase
    {
        

        private readonly IProductRepository productRepository;
        public ProductColorsController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
       
        [HttpGet]
        public  List<string> AllProductcolor()
        {         

            List<string> colorlist = productRepository.GetProductsColor();
          
            return colorlist;
        }
    }
}