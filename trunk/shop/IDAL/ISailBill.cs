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
    /// 销售单
    /// </summary>
    public interface ISailBill
    {
        /// <summary>
        /// 增加销售单
        /// </summary>
        /// <param name="changeStock"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        int InsertSailBill(SaleBillInfo saleBill, SqlTransaction trans);
        /// <summary>
        /// 更新销售单
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        int UpdateSailBill(SaleBillInfo saleBill, SqlTransaction trans);
        /// <summary>
        /// 根据分类id删除销售单
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        int DeleteSailBill(Guid saleBillId, SqlTransaction trans);
        /// <summary>
        /// 根据条件获取销售单
        /// </summary>
        /// <param name="conditon"></param>
        /// <returns></returns>
        IList<SaleBillInfo> GetSailBill(SearchCondition conditon, SqlConnection conn);
        /// <summary>
        /// 获取满足条件的销售单数量
        /// </summary>
        /// <param name="conditon"></param>
        /// <returns></returns>
        int GetSailBillCount(SearchCondition conditon, SqlConnection conn);
        /// <summary>
        /// 获取指定页的销售单
        /// </summary>
        /// <param name="conditon"></param>
        /// <param name="page">页数</param>
        /// <param name="pagesize">每页数量</param>
        /// <param name="conn"></param>
        /// <returns></returns>
        IList<SaleBillInfo> GetPageSailBill(SearchCondition conditon, int page, int pagesize, SqlConnection conn);
    }
}
