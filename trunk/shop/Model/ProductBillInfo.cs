using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class ProductBillInfo:CommonInfo
    {
        public Guid id{get;set;}
        public string BuyNO{get;set;}
        public string  BatchNO{get;set;}
        public DateTime BuyDate { get; set; }
        public Guid SupplyID{get;set;}
        public char IsReview{get;set;}
        public string  ReviewUser{get;set;}
        public Guid WareHouseID{get;set;}
        public string Detail{get;set;}
        public string Define1{get;set;}
        public string Define2{get;set;}
        public string Define3{get;set;}
        public IList<ProductBillBody> BillDetail { get; set; }
    }
}
