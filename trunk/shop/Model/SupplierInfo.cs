using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class SupplierInfo : CommonInfo
    {
        public Guid id{get;set;}
        public string SupplierNO{get;set;}
        public string Name{get;set;}
        public string ZipCode{get;set;}
        public string Address{get;set;}
        public string Tel{get;set;}
        public string Fax{get;set;}
        public string StaffName{get;set;}
        public string Email { get; set; }
    }
}
