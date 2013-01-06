using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WHMange.Models.VEntity
{
    public class VProductBill
    {
        public int id { get; set; }
        public string BuyNO { get; set; }
        public string BatchNO { get; set; }
        public DateTime BuyDate { get; set; }
        public int SupplyID { get; set; }
        public char IsReview { get; set; }
        public string ReviewUser { get; set; }
        public int WareHouseID { get; set; }
        public string Detail { get; set; }
        public string JsonProduct { get; set; }
    }
}