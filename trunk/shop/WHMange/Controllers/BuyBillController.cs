using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WHMange.Models.VEntity;

namespace WHMange.Controllers
{
    public class BuyBillController : Controller
    {
        //
        // GET: /BuyBill/
        /// <summary>
        /// 采购单列表
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            ViewBag.SupplyID = new List<SelectListItem> { 
                new SelectListItem{Text="a",Value="1"},
                new SelectListItem{Text="b",Value="2"}
            };
            ViewBag.IsReview = new List<SelectListItem> { 
                new SelectListItem{Text="是",Value="0"},
                new SelectListItem{Text="否",Value="1"}
            };
            return View();
        }
        /// <summary>
        /// 采购单添加页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ProductBillAdd()
        {
            ViewBag.SupplyID = new List<SelectListItem> { 
                new SelectListItem{Text="a",Value="1"},
                new SelectListItem{Text="b",Value="2"}
            };
            ViewBag.WareHouseID = new List<SelectListItem> { 
                new SelectListItem{Text="a",Value="1"},
                new SelectListItem{Text="b",Value="2"}
            };
            return View();
            //return RedirectToAction("Index");
        }
        /// <summary>
        /// 添加采购单
        /// </summary>
        /// <param name="productBill"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ProductBillAdd(VProductBill productBill)
        {
            //return View("Error");
            return RedirectToAction("Index");
        }
        /// <summary>
        /// 编辑页面
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ProductBillEdit(int id)
        {
            ViewBag.SupplyID = new List<SelectListItem> { 
                new SelectListItem{Text="a",Value="1"},
                new SelectListItem{Text="b",Value="2"}
            };
            ViewBag.WareHouseID = new List<SelectListItem> { 
                new SelectListItem{Text="a",Value="1"},
                new SelectListItem{Text="b",Value="2"}
            };
            return View();
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="productBill"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ProductBillEdit(VProductBill productBill)
        {
            return RedirectToAction("Index");
        }


    }
}
