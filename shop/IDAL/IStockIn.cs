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
    /// 入库
    /// </summary>
    public interface IStockIn
    {
        /// <summary>
        /// 增加入库
        /// </summary>
        /// <param name="changeStock"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        int InsertStockIn(StockInInfo stockIn, SqlTransaction trans);
        /// <summary>
        /// 更新入库
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        int UpdateStockIn(StockInInfo stockIn, SqlTransaction trans);
        /// <summary>
        /// 根据分类id删除入库
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        int DeleteStockIn(Guid stockInId, SqlTransaction trans);
        /// <summary>
        /// 根据条件获取入库
        /// </summary>
        /// <param name="conditon"></param>
        /// <returns></returns>
        IList<StockInInfo> GetStockIn(SearchCondition conditon, SqlConnection conn);
        /// <summary>
        /// 获取满足条件的入库
        /// </summary>
        /// <param name="conditon"></param>
        /// <returns></returns>
        int GetStockInCount(SearchCondition conditon, SqlConnection conn);
        /// <summary>
        /// 获取指定页的入库
        /// </summary>
        /// <param name="conditon"></param>
        /// <param name="page">页数</param>
        /// <param name="pagesize">每页数量</param>
        /// <param name="conn"></param>
        /// <returns></returns>
        IList<StockInInfo> GetPageStockIn(SearchCondition conditon, int page, int pagesize, SqlConnection conn);
    }
}
