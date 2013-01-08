using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopManage.Controllers
{
    public class ChangeTypeController : Controller
    {
        //
        // GET: /ChangeType/

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult ChangeType()
        {
            return RedirectToAction("Index", "Main");
        }
    }
}
