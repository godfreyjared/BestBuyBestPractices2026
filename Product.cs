using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestBuyBestPractices2026
{
    public class Product
    {
        public int productID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int CategoryID { get; set; }
        public bool OnSale { get; set; }
        public int StockLevel { get; set; }

    }
}
