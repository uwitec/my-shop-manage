using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class StuffInfo:CommonInfo
    {
        public int id{get;set;}
        public int WareHouse{get;set;}
        public string StuffNO{get;set;}
        public string Name{get;set;}
        public char Sex{get;set;}
        public string Tel{get;set;}
        public string Email{get;set;}
        public DateTime Birthday{get;set;}
        public string address{get;set;}
        public char IsOn{get;set;}
        public string detail { get; set; }
    }
}
