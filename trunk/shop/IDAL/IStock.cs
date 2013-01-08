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
    /// 库存
    /// </summary>
    public interface IStock
    {
        /// <summary>
        /// 增加库存
        /// </summary>
        /// <param name="changeStock"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        int InsertStock(StockInfo stock, SqlTransaction trans);
        /// <summary>
        /// 更新库存
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        int UpdateStock(StockInfo stock, SqlTransaction trans);
        /// <summary>
        /// 根据分类id删除库存
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        int DeleteStock(Guid stockId, SqlTransaction trans);
        /// <summary>
        /// 根据条件获取库存
        /// </summary>
        /// <param name="conditon"></param>
        /// <returns></returns>
        IList<StockInfo> GetStock(SearchCondition conditon, SqlConnection conn);
        /// <summary>
        /// 获取满足条件的库存
        /// </summary>
        /// <param name="conditon"></param>
        /// <returns></returns>
        int GetStockCount(SearchCondition conditon, SqlConnection conn);
        /// <summary>
        /// 获取指定页的库存
        /// </summary>
        /// <param name="conditon"></param>
        /// <param name="page">页数</param>
        /// <param name="pagesize">每页数量</param>
        /// <param name="conn"></param>
        /// <returns></returns>
        IList<StockInfo> GetPageStock(SearchCondition conditon, int page, int pagesize, SqlConnection conn);
    }
}
