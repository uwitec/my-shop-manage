using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WHMange.Models.VEntity;

namespace WHMange.Controllers
{
    public class ChangeStockController : Controller
    {
        //
        // GET: /ChangeStock/

        public ActionResult Index()
        {
            ViewBag.IsReview = new List<SelectListItem> { 
                new SelectListItem{Text="是",Value="0"},
                new SelectListItem{Text="否",Value="1"}
            };
            ViewBag.OutWareHouse = new List<SelectListItem> { 
                new SelectListItem{Text="是",Value="0"},
                new SelectListItem{Text="否",Value="1"}
            };
            ViewBag.InWareHouse = new List<SelectListItem> { 
                new SelectListItem{Text="是",Value="0"},
                new SelectListItem{Text="否",Value="1"}
            };
            return View();
        }
        /// <summary>
        /// 添加页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Add()
        {
            ViewBag.OutWareHouse = new List<SelectListItem> { 
                new SelectListItem{Text="是",Value="0"},
                new SelectListItem{Text="否",Value="1"}
            };
            ViewBag.InWareHouse = new List<SelectListItem> { 
                new SelectListItem{Text="是",Value="0"},
                new SelectListItem{Text="否",Value="1"}
            };
            return View();
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="changeStock"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Add(VChangeStock changeStock)
        {
            return RedirectToAction("Index");
        }
        /// <summary>
        /// 编辑页面
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View();
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="changeStock"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(VChangeStock changeStock)
        {
            return RedirectToAction("Index");
        }

    }
}
