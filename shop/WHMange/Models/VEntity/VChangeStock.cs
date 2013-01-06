using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WHMange.Models.VEntity
{
    public class VChangeStock
    {
        public int id { get; set; }
        public string ChangeNO { get; set; }
        public DateTime ChangeDate { get; set; }
        public string ChangeUser { get; set; }
        public int OutWareHouse { get; set; }
        public int InWareHouse { get; set; }
        public char IsReview { get; set; }
        public string ReviewUser { get; set; }
        public string JsonDetail { get; set; }
    }
}