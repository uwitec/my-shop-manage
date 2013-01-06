﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WHMange.Models.VEntity
{
    public class VProduct
    {
        public int id { get; set; }
        public string ProductNO { get; set; }
        public string ProductName { get; set; }
        public int CategoryID { get; set; }
        public int TypeID { get; set; }
        public string ProductSKU { get; set; }
        public int UnitID { get; set; }
        public decimal Price { get; set; }
        public decimal SailPrice { get; set; }
        public int ColorID { get; set; }
        public string Place { get; set; }
        public string ProductDetail { get; set; }
    }
}