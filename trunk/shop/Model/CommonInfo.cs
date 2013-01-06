using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class CommonInfo
    {
        /// <summary>
        /// 生成时间
        /// </summary>
        public DateTime InsertDateTime { get;set;}
        /// <summary>
        /// 生成用户
        /// </summary>
        public string InsertUser { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime UpdateDateTime{get;set;}
        /// <summary>
        /// 更新用户
        /// </summary>
        public string UpdatetUser{get;set;}

    }
}
