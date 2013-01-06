using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    public sealed class SearchCondition
    {
        /// <summary>
        /// 字段
        /// </summary>
        public string field { get; set; }
        /// <summary>
        /// 操作
        /// </summary>
        public string operate { get; set; }
        /// <summary>
        /// 值
        /// </summary>
        public string value { get; set; }
    }
}
