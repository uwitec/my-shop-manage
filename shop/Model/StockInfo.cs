using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class StockInfo:CommonInfo
    {
        public Guid id{get;set;}
        public Guid Warehouse{get;set;}
        public Guid ProductID{get;set;}
        public string StockInTP{get;set;}
        public DateTime StockInDate{get;set;}
        public string StockInReason{get;set;}
        public string StockOutTP { get; set; }
        public DateTime StockOutDate{get;set;}
        public string StockOutReason{get;set;}
        public int Num{get;set;}
        public ProductInfo product { get; set; }
        public WareHouseInfo warehouse { get; set; }
    }
}
