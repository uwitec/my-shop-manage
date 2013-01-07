using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class ChangeStockInfo:CommonInfo
    {
        public Guid  id{get;set;}
        public string ChangeNO{get;set;}
        public DateTime ChangeDate{get;set;}
        public string ChangeUser{get;set;}
        public Guid OutWareHouse{get;set;}
        public Guid InWareHouse{get;set;}
        public char IsReview{get;set;}
        public string ReviewUser{get;set;}
        public string Detail{get;set;}
        public string Define1{get;set;}
        public string Define2{get;set;}
        public string Define3 { get; set; }
        public IEnumerable<ChangeStockBody> changeStockDetail { get; set; }
    }
}
