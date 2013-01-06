using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WHMange.Models.VEntity
{
    public class VCategory
    {
        public int id { get; set; }
        public string categoryName { get; set; }
        public int parentID { get; set; }
        public string parentName { get; set; }
    }
}