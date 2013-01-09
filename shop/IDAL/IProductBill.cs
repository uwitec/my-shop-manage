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
    /// 采购单
    /// </summary>
    public interface IProductBill
    {
        /// <summary>
        /// 增加采购单
        /// </summary>
        /// <param name="changeStock"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        int InsertProductBill(ProductBillInfo productBill, SqlTransaction trans);
        /// <summary>
        /// 更新采购单
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        int UpdateProductBill(ProductBillInfo productBill,bool changebody, SqlTransaction trans);
        /// <summary>
        /// 根据分类id删除采购单
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        int DeleteProductBill(Guid productId, SqlTransaction trans);
        /// <summary>
        /// 根据条件获取采购单
        /// </summary>
        /// <param name="conditon"></param>
        /// <returns></returns>
        IList<ProductBillInfo> GetProductBill(IEnumerable<SearchCondition> conditon, SqlConnection conn);
        /// <summary>
        /// 获取满足条件的采购单数量
        /// </summary>
        /// <param name="conditon"></param>
        /// <returns></returns>
        int GetProductBillCount(IEnumerable<SearchCondition> conditon, SqlConnection conn);
        /// <summary>
        /// 获取指定页的采购单
        /// </summary>
        /// <param name="conditon"></param>
        /// <param name="page">页数</param>
        /// <param name="pagesize">每页数量</param>
        /// <param name="conn"></param>
        /// <returns></returns>
        IList<ProductBillInfo> GetPageProductBill(IEnumerable<SearchCondition> conditon, int page, int pagesize, SqlConnection conn);
    }
}
