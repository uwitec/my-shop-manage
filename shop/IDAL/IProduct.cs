using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Model;
using Common;
namespace IDAL
{
    /// <summary>
    /// 商品
    /// </summary>
    public interface IProduct
    {
        /// <summary>
        /// 增加盘点单
        /// </summary>
        /// <param name="changeStock"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        int InsertProduct(ProductInfo product, SqlTransaction trans);
        /// <summary>
        /// 更新盘点单
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        int UpdateProduct(ProductInfo product, SqlTransaction trans);
        /// <summary>
        /// 根据分类id删除盘点单
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        int DeleteProduct(Guid productId, SqlTransaction trans);
        /// <summary>
        /// 根据条件获取盘点单
        /// </summary>
        /// <param name="conditon"></param>
        /// <returns></returns>
        IList<ProductInfo> GetProduct(IEnumerable<SearchCondition> conditon, SqlConnection conn);
        /// <summary>
        /// 获取满足条件的盘点单数量
        /// </summary>
        /// <param name="conditon"></param>
        /// <returns></returns>
        int GetProductCount(IEnumerable<SearchCondition> conditon, SqlConnection conn);
        /// <summary>
        /// 获取指定页的盘点单
        /// </summary>
        /// <param name="conditon"></param>
        /// <param name="page">页数</param>
        /// <param name="pagesize">每页数量</param>
        /// <param name="conn"></param>
        /// <returns></returns>
        IList<ProductInfo> GetPageProduct(IEnumerable<SearchCondition> conditon, int page, int pagesize, SqlConnection conn);
    }
}
