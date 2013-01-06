using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WHMange.Models.VEntity
{
    public class VProductSearch
    {
        /// <summary>
        /// 类别
        /// </summary>
        public int category { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 编码
        /// </summary>
        public string ProductNO { get; set; }
    }
}