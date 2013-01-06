using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class SaleBillInfo:CommonInfo
    {
        public int id{get;set;}
        public int WareHouseID { get; set; }
        public string SailNO{get;set;}
        public DateTime SailDate{get;set;}
        public char IsReview{get;set;}
        public string ReviewUser{get;set;}
        public int StuffID{get;set;}
        public string Detail{get;set;}
        public string Define1{get;set;}
        public string Define2{get;set;}
        public string Define3 { get; set; }
    }
}
