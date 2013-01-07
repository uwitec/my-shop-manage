using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class StockOutInfo : CommonInfo
    {
        public Guid id{get;set;}
        public string StockInNO{get;set;}
        public Guid Warehouse{get;set;}
        public string StockOutTP{get;set;}
        public DateTime StockOutDate{get;set;}
        public string StockOutReason { get; set; }
        public IEnumerable<StockOutBody> stockOutDetail { get; set; }
    }
}
