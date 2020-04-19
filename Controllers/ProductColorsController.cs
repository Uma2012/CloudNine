using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CloudNine.Praktik.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CloudNine.Praktik.Controllers
{
    // GET: api/productcolors
    [Route("api/[controller]")]
    [ApiController]
    public class ProductColorsController : ControllerBase
    {
        private readonly ProductDataLogic _productDataLogic;
        public ProductColorsController(ProductDataLogic productDataLogic)
        {
            this._productDataLogic = productDataLogic;
        }
        [HttpGet]
        public async Task<List<string>> AllProductcolor()
        {
            List<string> colorlist = new List<string>();
             colorlist=await  _productDataLogic.ProductColor();
            return colorlist;
        }
    }
}