using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class StockInInfo:CommonInfo
    {
        public Guid id{get;set;}
        public string StockInNO{get;set;}
        public Guid Warehouse{get;set;}
        public string StockInTP{get;set;}
        public DateTime StockInDate{get;set;}
        public string StockInReason{get;set;}
        public Guid SupplierID { get; set; }
        public IEnumerable<StockInBody> stockInDetail { get; set; }
    }
}
