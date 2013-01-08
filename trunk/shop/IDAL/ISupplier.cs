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
    /// 供应商
    /// </summary>
    public interface ISupplier
    {
        /// <summary>
        /// 增加供应商
        /// </summary>
        /// <param name="changeStock"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        int InsertSupplier(SupplierInfo supplier, SqlTransaction trans);
        /// <summary>
        /// 更新供应商
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        int UpdateSupplier(SupplierInfo stuff, SqlTransaction trans);
        /// <summary>
        /// 根据id删除供应商
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        int DeleteSupplier(Guid stuffId, SqlTransaction trans);
        /// <summary>
        /// 根据条件获取供应商
        /// </summary>
        /// <param name="conditon"></param>
        /// <returns></returns>
        IList<SupplierInfo> GetSupplier(SearchCondition conditon, SqlConnection conn);
        /// <summary>
        /// 获取满足条件的供应商
        /// </summary>
        /// <param name="conditon"></param>
        /// <returns></returns>
        int GetSupplierCount(SearchCondition conditon, SqlConnection conn);
        /// <summary>
        /// 获取指定页的供应商
        /// </summary>
        /// <param name="conditon"></param>
        /// <param name="page">页数</param>
        /// <param name="pagesize">每页数量</param>
        /// <param name="conn"></param>
        /// <returns></returns>
        IList<SupplierInfo> GetPageSupplier(SearchCondition conditon, int page, int pagesize, SqlConnection conn);
    }
}
