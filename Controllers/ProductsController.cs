﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using CloudNine.Praktik.Model;

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
        private readonly IProductRepository productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }


        // GET: api/products
        [HttpGet]
        public  List<Products> GetAsync(int? page, int? pageSize, [FromQuery(Name = "color")]params string[] color)
        {            
            List<Products> allproducts = productRepository.ProductFilter(page, pageSize, color);            

            return allproducts;
        }


        // GET: api/products/95e87976-88e3-415d-b139-219538e948c1
        [HttpGet("{id}")]
       public  Products GetProductByIDAsync(Guid id)
        {
            Products product = productRepository.GetProductById(id);
          
            return product;
         }

      




    }
}
