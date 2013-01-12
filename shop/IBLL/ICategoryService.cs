using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using Common;

namespace IBLL
{
    public interface ICategoryService
    {
        /// <summary>
        /// 增加分类
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        int InsertCategory(CategoryInfo category);
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        int DeleteCategory(Guid categoryId);
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        int UpdateCategory(CategoryInfo category);
        /// <summary>
        /// 根据ID获取
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        CategoryInfo GetCategoryById(Guid categoryId);
        /// <summary>
        /// 根据条件获取
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="page"></param>
        /// <param name="pagesize"></param>
        /// <returns></returns>
        IList<CategoryInfo> GetPageCategory(IEnumerable<SearchCondition> condition,int page,int pagesize);
        /// <summary>
        /// 获取满足条件的记录数量
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        int GetCategoryCount(IEnumerable<SearchCondition> condition);
    }
}
