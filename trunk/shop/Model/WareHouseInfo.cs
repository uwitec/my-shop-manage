using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class WareHouseInfo:CommonInfo
    {
        public int id{get;set;}
        public string Name{get;set;}
        public string No{get;set;}
        public string Address{get;set;}
        public string Tel{get;set;}
        public string detail { get; set; }
    }
}
