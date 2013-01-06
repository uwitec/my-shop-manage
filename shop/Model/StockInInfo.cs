using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class StockInInfo:CommonInfo
    {
        public int id{get;set;}
        public string StockInNO{get;set;}
        public int Warehouse{get;set;}
        public string StockInTP{get;set;}
        public DateTime StockInDate{get;set;}
        public string StockInReason{get;set;}
        public int SupplierID { get; set; }
        public IList<StockInBody> stockInDetail { get; set; }
    }
}
