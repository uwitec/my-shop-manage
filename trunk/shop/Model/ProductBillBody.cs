using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class ProductBillBody
    {
        public Guid HeadId{get;set;}
        public Guid ProductID { get; set; }
        public decimal BuyPrice{get;set;}
        public int Num { get; set; }
        public ProductInfo product { get; set; }
    }
}
