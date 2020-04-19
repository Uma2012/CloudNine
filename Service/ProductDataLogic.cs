using CloudNine.Praktik.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CloudNine.Praktik.Service
{
    public class ProductDataLogic
    {
        public async Task<List<Products>> GetAll()
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Data\products.json");
            //string[] files = File.ReadAllLines(path);
            List<Products> products;
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                products = JsonConvert.DeserializeObject<List<Products>>(json);
            }
            //List<Products> products = new List<Products>();
         
            products.OrderBy(x => x.color);
            return products;

        }
        public async Task<Products> ProductByID(Guid productid)
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Data\products.json");
            //string[] files = File.ReadAllLines(path);
            List<Products> products;
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                products = JsonConvert.DeserializeObject<List<Products>>(json);
            }
            List<Products> output = new List<Products>();
            var iscontains =  products.Where(x => x.id == productid)
                .Select(x=>new Products()
                { id=x.id,
                  color=x.color,
                  description=x.description,
                  productName=x.productName
                })
                .FirstOrDefault();

            //List<string> selectedproduct = new List<string>();
            //foreach (var item in iscontains)
            //{
            //    selectedproduct.Add(item.id);

            //}

            return iscontains;


        }
        public async Task<List<string>> ProductColor()
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Data\products.json");
            //string[] files = File.ReadAllLines(path);
            List<Products> products;
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                products =JsonConvert.DeserializeObject<List<Products>>(json);
            }
            List<string> output = new List<string>();


            foreach (var item in products)
            {
                output.Add(item.color);

            }

            return output;

        }
    }
}
