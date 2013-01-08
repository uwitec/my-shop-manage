using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopManage.Controllers
{
    public class ShopController : Controller
    {
        //
        // GET: /Shop/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Shop()
        {
            return RedirectToAction("Index", "Main");
        }

        public ActionResult ShopEdit()
        {
            return RedirectToAction("Edit", "Main");
        }
    }
}
