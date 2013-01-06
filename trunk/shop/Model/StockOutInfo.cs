using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class StockOutInfo : CommonInfo
    {
        public int id{get;set;}
        public string StockInNO{get;set;}
        public int Warehouse{get;set;}
        public string StockOutTP{get;set;}
        public DateTime StockOutDate{get;set;}
        public string StockOutReason { get; set; }
        public IList<StockOutBody> stockOutDetail { get; set; }
    }
}
