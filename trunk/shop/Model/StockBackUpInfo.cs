using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class StockBackUpInfo:CommonInfo
    {
        public int id { get; set; }
        public int StockInID { get; set; }
        public int StockOutID { get; set; }
        public int StockID { get; set; }
        public int Warehouse { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int CategoryID { get; set; }
        public string ProductDetail { get; set; }
        public int UnitID { get; set; }
        public string UnitName { get; set; }
        public decimal Price { get; set; }
        public int ColorID { get; set; }
        public string Place { get; set; }
        public DateTime SaveTime { get; set; }
        public string StockInTP { get; set; }
        public DateTime StockInDate { get; set; }
        public string StockInReason { get; set; }
        public string StockOutTP { get; set; }
        public DateTime StockOutDate { get; set; }
        public string StockOutReason { get; set; }
        public int Num { get; set; }
    }
}
