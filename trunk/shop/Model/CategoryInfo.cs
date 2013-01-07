using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class CategoryInfo:CommonInfo
    {
        public Guid id { get; set; }
        public string categoryName { get; set; }
        public Guid parentID { get; set; }
        public CategoryInfo parentInfo { get; set; }
    }
}
