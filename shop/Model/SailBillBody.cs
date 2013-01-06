using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class SailBillBody
    {
        public int HeadId{get;set;}
        public int ProductID{get;set;}
        public decimal SailPrice{get;set;}
        public int Num { get; set; }
        public Product product { get; set; }
    }
}
