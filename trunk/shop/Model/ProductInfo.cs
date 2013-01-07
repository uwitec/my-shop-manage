using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class ProductInfo:CommonInfo
    {
        public Guid  id{get;set;}
        public string ProductNO{get;set;}
        public string ProductName{get;set;}
        public Guid CategoryID{get;set;}
        public string ProductSKU{get;set;}
        public string ProductDetail{get;set;}
        public decimal Price{get;set;}
        public decimal SailPrice{get;set;}
        public string Place{get;set;}
        public DateTime SaveTime { get; set; }
        public string Define1{get;set;}
        public string Define2{get;set;}
        public string Define3{get;set;}
    }
}
