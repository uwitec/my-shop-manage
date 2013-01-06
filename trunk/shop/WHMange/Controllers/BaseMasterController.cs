using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WHMange.Models.VEntity;

namespace WHMange.Controllers
{
    public class BaseMasterController : Controller
    {
        //
        // GET: /BaseMaster/
        /// <summary>
        /// 仓库列表
        /// </summary>
        /// <returns></returns>
        public ActionResult WHList()
        {
            return View();
        }

        /// <summary>
        /// 点击追加 转到追加页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult WHAdd()
        {
            return View();
        }
        /// <summary>
        /// 向数据库总添加仓库
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult WHAdd(VWareHouse wh)
        {
            //添加成功后跳转到仓库列表页面
            return RedirectToAction("WHList");

            //添加不成功跳转到错误页面
            //return View("Error");
        }
        /// <summary>
        /// 点击编辑 转到编辑页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult WHEdit(int whid)
        {
            return View();
        }
        /// <summary>
        /// 向数据库添加仓库
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult WHEdit(VWareHouse wh)
        {
            //添加成功后跳转到仓库列表页面
            return RedirectToAction("WHList");

            //添加不成功跳转到错误页面
            //return View("Error");
        }

        /// <summary>
        /// 显示单位列表
        /// </summary>
        /// <returns></returns>
        public ActionResult UnitList()
        {
            return View();
        }
        /// <summary>
        /// 单位添加页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult UnitAdd()
        {
            return View();
        }
        /// <summary>
        /// 单位追加
        /// </summary>
        /// <param name="unit"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UnitAdd(VUnits unit)
        {
            //添加成功后跳转到仓库列表页面
            return RedirectToAction("UnitList");

            //添加不成功跳转到错误页面
            //return View("Error");
        }
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult UnitEdit(int id)
        {
            return View();            
        }
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="unit"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UnitEdit(VUnits unit)
        {
            //保存成功后跳转到仓库列表页面
            return RedirectToAction("UnitList");

            //保存不成功跳转到错误页面
            //return View("Error");
        }
        /// <summary>
        /// 删除单位
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UnitDel(int id)
        {
            //删除成功后跳转到仓库列表页面
            return RedirectToAction("UnitList");

            //删除不成功跳转到错误页面
            //return View("Error");
        }

        /// <summary>
        /// 型号管理
        /// </summary>
        /// <returns></returns>
        public ActionResult TypeList()
        {
            return View();
        }

        /// <summary>
        /// 添加型号页面
        /// </summary>
        /// <returns></returns>
        public ActionResult TypeAdd()
        {
            return View();
        }
        /// <summary>
        /// 将型号持久化
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public ActionResult TypeAdd(VType type)
        {
            //添加成功后跳转到仓库列表页面
            return RedirectToAction("TypeList");

            //添加不成功跳转到错误页面
            //return View("Error");
        }
        /// <summary>
        /// 编辑页面
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult TypeEdit(int id)
        {
            return View();
        }
        /// <summary>
        /// 保存型号数据
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public ActionResult TypeEdit(VType type)
        {
            //编辑成功后跳转到仓库列表页面
            return RedirectToAction("TypeList");

            //编辑不成功跳转到错误页面
            //return View("Error");
        }
        /// <summary>
        /// 颜色列表
        /// </summary>
        /// <returns></returns>
        public ActionResult ColorList()
        {
            return View();
        }
        /// <summary>
        /// 添加页面
        /// </summary>
        /// <returns></returns>
        public ActionResult ColorAdd()
        {
            return View();
        }
        /// <summary>
        /// 颜色持久化
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public ActionResult ColorAdd(VColor color)
        {
            //添加成功后跳转到仓库列表页面
            return RedirectToAction("ColorList");

            //添加不成功跳转到错误页面
            //return View("Error");
        }
        /// <summary>
        /// 编辑页面
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult ColorEdit(int id)
        {
            return View();
        }
        /// <summary>
        /// 保存编辑的数据
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ColorEdit(VColor color)
        {
            //编辑成功后跳转到仓库列表页面
            return RedirectToAction("ColorList");

            //编辑不成功跳转到错误页面
            //return View("Error");
        }
        /// <summary>
        /// 调货方式管理页面
        /// </summary>
        /// <returns></returns>
        public ActionResult ChangeType()
        {
            return View();
        }
        /// <summary>
        /// 添加页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ChangeTypeAdd()
        {
            return View();
        }
        /// <summary>
        /// 调货方式持久化
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ChangeTypeAdd(VChangeType changeType)
        {
            //添加成功后跳转到仓库列表页面
            return RedirectToAction("ChangeTypeList");

            //添加不成功跳转到错误页面
            //return View("Error");
            
        }
        /// <summary>
        /// 编辑页面
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult ChangeTypeEdit(int id)
        {
            return View();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="changeType"></param>
        /// <returns></returns>
        public ActionResult ChangeTypeEdit(VChangeType changeType)
        {
            //编辑成功后跳转到列表页面
            return RedirectToAction("ChangeType");

            //编辑不成功跳转到错误页面
            //return View("Error");
        }
        /// <summary>
        /// 商品分类管理
        /// </summary>
        /// <returns></returns>
        public ActionResult Category()
        {
            return View();
        }
        /// <summary>
        /// 商品分类添加页面
        /// </summary>
        /// <returns></returns>
        public ActionResult CategoryAdd()
        {
            return View();
        }
        /// <summary>
        /// 商品分类持久化
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult CategoryAdd(VCategory category)
        {
            //添加成功后跳转到列表页面
            return RedirectToAction("Category");

            //添加不成功跳转到错误页面
            //return View("Error");
        }
        /// <summary>
        /// 编辑页面
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult CategoryEdit(int id)
        {
            return View();
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult CategoryEdit(VCategory category)
        {
            //编辑成功后跳转到列表页面
            return RedirectToAction("Category");

            //编辑不成功跳转到错误页面
            //return View("Error");
        }
        /// <summary>
        /// 商品列表
        /// </summary>
        /// <returns></returns>
        public ActionResult Product()
        {
            ViewBag.category = new List<SelectListItem>
            {
                new SelectListItem{Text="上衣",Value="1"},
                new SelectListItem{Text="长裤",Value="2"},
                new SelectListItem{Text="鞋子",Value="3"}
            };
            return View();
        }
        /// <summary>
        /// 添加页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ProductAdd()
        {
            ViewBag.CategoryID = new List<SelectListItem> { 
                new SelectListItem{Text="a",Value="1"},
                new SelectListItem{Text="b",Value="2"}
            };
            ViewBag.TypeID = new List<SelectListItem> { 
                new SelectListItem{Text="a",Value="1"},
                new SelectListItem{Text="b",Value="2"}
            };
            ViewBag.UnitID = new List<SelectListItem> { 
                new SelectListItem{Text="a",Value="1"},
                new SelectListItem{Text="b",Value="2"}
            };
            ViewBag.ColorID = new List<SelectListItem> { 
                new SelectListItem{Text="a",Value="1"},
                new SelectListItem{Text="b",Value="2"}
            };
            return View();
        }
        /// <summary>
        /// 追加
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ProductAdd(VProduct product)
        {
            
            //添加成功后跳转到列表页面
            return RedirectToAction("ProductAdd");

            //添加不成功跳转到错误页面
            //return View("Error");
        }
        /// <summary>
        /// 跳转到编辑页面
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult ProductEdit(int id)
        {
            ViewBag.CategoryID = new List<SelectListItem> { 
                new SelectListItem{Text="a",Value="1"},
                new SelectListItem{Text="b",Value="2"}
            };
            ViewBag.TypeID = new List<SelectListItem> { 
                new SelectListItem{Text="a",Value="1"},
                new SelectListItem{Text="b",Value="2"}
            };
            ViewBag.UnitID = new List<SelectListItem> { 
                new SelectListItem{Text="a",Value="1"},
                new SelectListItem{Text="b",Value="2"}
            };
            ViewBag.ColorID = new List<SelectListItem> { 
                new SelectListItem{Text="a",Value="1"},
                new SelectListItem{Text="b",Value="2"}
            };
            return View();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ProductEdit(VProduct product)
        {
            //保存成功后跳转到列表页面
            return RedirectToAction("ProductAdd");

            //保存不成功跳转到错误页面
            //return View("Error");
        }

    }
}
