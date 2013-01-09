using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using Common;
using System.Data.SqlClient;

namespace IDAL
{
    /// <summary>
    /// 调拨单
    /// </summary>
    public interface IChangeStock
    {
        /// <summary>
        /// 增加调拨单
        /// </summary>
        /// <param name="changeStock"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        int InsertChangeStock(ChangeStockInfo changeStock,SqlTransaction trans);
        /// <summary>
        /// 更新调拨单
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        int UpdateChangeStock(ChangeStockInfo changeStock,bool changebody, SqlTransaction trans);
        /// <summary>
        /// 根据分类id删除调拨单
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        int DeleteChangeStock(Guid changeStockId, SqlTransaction trans);
        /// <summary>
        /// 根据条件获取调拨单
        /// </summary>
        /// <param name="conditon"></param>
        /// <returns></returns>
        IList<ChangeStockInfo> GetChangeStock(IEnumerable<SearchCondition> conditon, SqlConnection conn);
        /// <summary>
        /// 获取满足条件的调拨单数量
        /// </summary>
        /// <param name="conditon"></param>
        /// <returns></returns>
        int GetChangeStockCount(IEnumerable<SearchCondition> conditon, SqlConnection conn);
        /// <summary>
        /// 获取指定页的调拨单
        /// </summary>
        /// <param name="conditon"></param>
        /// <param name="page">页数</param>
        /// <param name="pagesize">每页数量</param>
        /// <param name="conn"></param>
        /// <returns></returns>
        IList<ChangeStockInfo> GetPageChangeStock(IEnumerable<SearchCondition> conditon, int page, int pagesize, SqlConnection conn);
    }
}
