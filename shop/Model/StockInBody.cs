using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class StockInBody
    {
        public Guid HeadId{get;set;}
        public Guid ProductID{get;set;}
        public string ProductName{get;set;}
        public Guid CategoryID{get;set;}
        public decimal Price{get;set;}
        public int Num { get; set; }
        public ProductInfo product { get; set; }
    }
}
