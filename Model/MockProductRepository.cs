using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CloudNine.Praktik.Model
{
    public class MockProductRepository : IProductRepository
    {
        private List<Products> _productList;
        public MockProductRepository()
        {
           string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Data\products.json");
          
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                _productList = JsonConvert.DeserializeObject<List<Products>>(json);
            }           

            _productList.OrderBy(x => x.color);
           
        }
       
        public Products GetProductById(Guid productid)
        {            //if contains
           bool isContains= _productList.Any(x => x.id == productid);
            //if (isContains)
            //{
                var product = _productList.Where(x => x.id == productid)
                    .Select(x => new Products()
                    {
                        id = x.id,
                        color = x.color,
                        description = x.description,
                        productName = x.productName
                    })
                    .FirstOrDefault();

                return product;
            //}
           // return NotFound();
        }

        public List<string> GetProductsColor()
        {
            List<string> output = new List<string>();

            foreach (var item in _productList)
            {
                output.Add(item.color);

            }

            return output;
        }

        public List<Products> ProductFilter(int? page, int? pageSize, params string[] color)
        {

            List<Products> result = new List<Products>();
            List<Products> ListOfEvérycolor = new List<Products>();        


            if ((page != null) && (pageSize != null) && (color.Length==0))
            {
                return _productList.Skip(((int)page - 1) * (int)pageSize).Take((int)pageSize).ToList();
            }
            if ((page != null) && (pageSize != null) && (color.Length>0))
            {
                for (int i = 0; i < color.Length; i++)
                {                    
                    result = _productList.Where(x => x.color.ToLower() == color[i].ToLower())
                .Select(x => new Products()
                {
                    id = x.id,
                    color = x.color,
                    description = x.description,
                    productName = x.productName
                })
                .ToList();
                    ListOfEvérycolor.AddRange(result);
                }
                return ListOfEvérycolor.Skip(((int)page - 1) * (int)pageSize).Take((int)pageSize).ToList();
               
            }

            return _productList;







            //if ((page != null) && (pageSize != null) && (String.IsNullOrEmpty(color)))
            //{
            //    return _productList.Skip(((int)page - 1) * (int)pageSize).Take((int)pageSize).ToList();
            //}
            //if ((page != null) && (pageSize != null) && (!String.IsNullOrEmpty(color)))
            //{
            //    var result = _productList.Where(x => x.color.ToLower() == color.ToLower())
            //    .Select(x => new Products()
            //    {
            //        id = x.id,
            //        color = x.color,
            //        description = x.description,
            //        productName = x.productName
            //    })
            //    .ToList();
            //    return result.Skip(((int)page - 1) * (int)pageSize).Take((int)pageSize).ToList();
            //}

        }
    }
}
