using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class CheckBillBody
    {
        public int HeadId{get;set;}
        public int ProductID{get;set;}
        public string ProductName{get;set;}
        public int CategoryID{get;set;}
        public string ProductDetail{get;set;}
        public int UnitID{get;set;}
        public string UnitName{get;set;}
        public decimal Price{get;set;}
        public int ColorID{get;set;}
        public string Place{get;set;}
        public int SaveTime{get;set;}
        public int NowNum {get;set;}
        public int RealNum { get; set; }
    }
}
