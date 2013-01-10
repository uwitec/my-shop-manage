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
    /// 出库
    /// </summary>
    public interface IStockOut
    {
        /// <summary>
        /// 增加出库
        /// </summary>
        /// <param name="changeStock"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        int InsertStockOut(StockOutInfo stockOut, SqlTransaction trans);
        /// <summary>
        /// 更新出库
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        int UpdateStockOut(StockOutInfo stockOut, bool changebody, SqlTransaction trans);
        /// <summary>
        /// 根据id删除出库
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        int DeleteStockOut(Guid stockOutId, SqlTransaction trans);
        /// <summary>
        /// 根据条件获取出库
        /// </summary>
        /// <param name="conditon"></param>
        /// <returns></returns>
        IList<StockOutInfo> GetStockOut(IEnumerable<SearchCondition> conditon, SqlConnection conn);
        /// <summary>
        /// 获取满足条件的出库
        /// </summary>
        /// <param name="conditon"></param>
        /// <returns></returns>
        int GetStockOutCount(IEnumerable<SearchCondition> conditon, SqlConnection conn);
        /// <summary>
        /// 获取指定页的出库
        /// </summary>
        /// <param name="conditon"></param>
        /// <param name="page">页数</param>
        /// <param name="pagesize">每页数量</param>
        /// <param name="conn"></param>
        /// <returns></returns>
        IList<StockOutInfo> GetPageStockOut(IEnumerable<SearchCondition> conditon, int page, int pagesize, SqlConnection conn);
    }
}
