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

        //Reading the json file and store it in a object(Database object)
        public MockProductRepository()
        {
            //getting json file datá path
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Data\products.json");

            //reading the json file
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();

                //convert the string data to Products object
                _productList = JsonConvert.DeserializeObject<List<Products>>(json);
            }

            _productList.OrderBy(x => x.color);

        }

        /// <summary>
        /// Get the product by its id
        /// </summary>
        /// <returns></returns>
        
        public Products GetProductById(Guid productid)
        {
            Products product = null;

            if (_productList.Any(x => x.id == productid))
            {
                product = _productList.Where(x => x.id == productid)
                   .Select(x => new Products()
                   {
                       id = x.id,
                       color = x.color,
                       description = x.description,
                       productName = x.productName
                   })
                   .FirstOrDefault();
            }

            return product;
        }

        /// <summary>
        /// Getting all the distinct color present in the dataobject
        /// </summary>
        /// <returns></returns>
        
        public List<string> GetProductsColor()
        {
            List<string> output = new List<string>();

            output = _productList.Select(x => x.color).Distinct().ToList();

            return output;
        }

        

        //1.Gettin all products if no parameter is passed
        //2.Paginate the products based on give page and pagesize
        //3.filter the products based on one or more colors
        public List<Products> ProductFilter(int? page, int? pageSize, params string[] color)
        {

            List<Products> result = new List<Products>();
            List<Products> ListOfEverycolor = new List<Products>();

            //page size and page is passed into the parameter. So paginate product based on given value
            if ((page != null) && (pageSize != null) && (color.Length == 0))
            {
                return _productList.Skip(((int)page - 1) * (int)pageSize).Take((int)pageSize).ToList();
            }

            //page, pagesize and color is passed into the parameter. So filter the products based on passed in color
            //and then paginate the products
            if ((page != null) && (pageSize != null) && (color.Length > 0))
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
                    ListOfEverycolor.AddRange(result);
                }

                return ListOfEverycolor.Skip(((int)page - 1) * (int)pageSize).Take((int)pageSize).ToList();
            }

            //if no parameter is passed so return all products
            return _productList;

        }
    }
}
