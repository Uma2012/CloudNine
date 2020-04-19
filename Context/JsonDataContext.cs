using CloudNine.Praktik.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CloudNine.Praktik.Context
{
    public class JsonDataContext
    {
        public JsonDataContext()
        {

        }
        public async Task<List<Products>> FileRead()
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Data\products.json");
           
            List<Products> products;
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                products = JsonConvert.DeserializeObject<List<Products>>(json);
            }
         

            products.OrderBy(x => x.color);
            return products;

        }
    }
}
