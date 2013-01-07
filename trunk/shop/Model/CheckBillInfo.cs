using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class CheckBillInfo:CommonInfo
    {
        public Guid id{get;set;}
        public string CheckNO{get;set;}
        public Guid Warehouse{get;set;}
        public DateTime Cdate{get;set;}
        public string User{get;set;}
        public string detail{get;set;}
        public char IsReview{get;set;}
        public string ReviewUser { get; set; }
        public IEnumerable<CheckBillBody> checkBillDetail { get; set; }
    }
}
