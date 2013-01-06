using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WHMange.Controllers
{
    public class SailBillController : Controller
    {
        //
        // GET: /SailBill/

        public ActionResult Index()
        {
            ViewBag.WareHouseID = new List<SelectListItem> { 
                new SelectListItem{Text="a",Value="1"},
                new SelectListItem{Text="b",Value="2"}
            };
            ViewBag.IsReview = new List<SelectListItem> { 
                new SelectListItem{Text="是",Value="0"},
                new SelectListItem{Text="否",Value="1"}
            };
            ViewBag.StuffID = new List<SelectListItem> { 
                new SelectListItem{Text="是",Value="0"},
                new SelectListItem{Text="否",Value="1"}
            };
            return View();
        }

    }
}
