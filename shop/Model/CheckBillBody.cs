using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class CheckBillBody
    {
        public Guid HeadId{get;set;}
        public Guid ProductID{get;set;}
        public string ProductName{get;set;}
        public Guid CategoryID{get;set;}
        public decimal Price{get;set;}
        public string Place{get;set;}
        public int NowNum {get;set;}
        public int RealNum { get; set; }
    }
}
