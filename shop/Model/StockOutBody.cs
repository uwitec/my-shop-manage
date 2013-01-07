using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class StockOutBody
    {
        public Guid HeadId{get;set;}
        public Guid ProductID{get;set;}
        public string ProductName{get;set;}
        public int CategoryID{get;set;}
        public decimal Price {get;set;}
        public string Place{get;set;}
        public int Num { get; set; }
    }
}
