using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using Common;
using System.Data.SqlClient;
namespace IDAL
{
    public interface ICategory
    {
        /// <summary>
        /// 增加分类
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        int InsertCategory(CategoryInfo category,SqlConnection conn);
        /// <summary>
        /// 更新分类
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        int UpdateCategory(CategoryInfo category, SqlConnection conn);
        /// <summary>
        /// 根据分类id删除分类
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        int DeleteCategoryById(Guid categoryId, SqlConnection conn);
        /// <summary>
        /// 根据条件获取分类
        /// </summary>
        /// <param name="conditon"></param>
        /// <returns></returns>
        IList<CategoryInfo> GetCategory(SearchCondition conditon, SqlConnection conn);
        /// <summary>
        /// 获取满足条件的分类数量
        /// </summary>
        /// <param name="conditon"></param>
        /// <returns></returns>
        int GetCategoryCount(SearchCondition conditon, SqlConnection conn);
        /// <summary>
        /// 获取指定页的分类
        /// </summary>
        /// <param name="conditon"></param>
        /// <param name="page">页数</param>
        /// <param name="pagesize">每页数量</param>
        /// <param name="conn"></param>
        /// <returns></returns>
        IList<CategoryInfo> GetPageCategory(SearchCondition conditon,int page,int pagesize, SqlConnection conn);
    }
}
