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
    /// 盘点单
    /// </summary>
    public interface ICheckBill
    {
        /// <summary>
        /// 增加盘点单
        /// </summary>
        /// <param name="changeStock"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        int InsertCheckBill(CheckBillInfo checkBill, SqlTransaction trans);
        /// <summary>
        /// 更新盘点单
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        int UpdateCheckBill(CheckBillInfo checkBill,bool changebody, SqlTransaction trans);
        /// <summary>
        /// 根据分类id删除盘点单
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        int DeleteCheckBill(Guid checkBillId, SqlTransaction trans);
        /// <summary>
        /// 根据条件获取盘点单
        /// </summary>
        /// <param name="conditon"></param>
        /// <returns></returns>
        IList<CheckBillInfo> GetCheckBill(IEnumerable<SearchCondition> conditon, SqlConnection conn);
        /// <summary>
        /// 获取满足条件的盘点单数量
        /// </summary>
        /// <param name="conditon"></param>
        /// <returns></returns>
        int GetCheckBillCount(IEnumerable<SearchCondition> conditon, SqlConnection conn);
        /// <summary>
        /// 获取指定页的盘点单
        /// </summary>
        /// <param name="conditon"></param>
        /// <param name="page">页数</param>
        /// <param name="pagesize">每页数量</param>
        /// <param name="conn"></param>
        /// <returns></returns>
        IList<CheckBillInfo> GetPageCheckBill(IEnumerable<SearchCondition> conditon, int page, int pagesize, SqlConnection conn);
    }
}
