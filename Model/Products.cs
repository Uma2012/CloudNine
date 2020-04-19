using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudNine.Praktik.Model
{
    public class Products
    {
        public string productName { get; set; }
        public Guid id { get; set; }
        public string description { get; set; }
        public string color { get; set; }
        public DateTime publishDate { get; set; }
    }
}
