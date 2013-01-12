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
    /// 仓库
    /// </summary>
    public interface IWareHouse
    {
        /// <summary>
        /// 增加仓库
        /// </summary>
        /// <param name="changeStock"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        int InsertWareHouse(WareHouseInfo wareHouse, SqlTransaction trans);
        /// <summary>
        /// 更新仓库
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        int UpdateWareHouse(WareHouseInfo wareHouse, SqlTransaction trans);
        /// <summary>
        /// 根据id删除仓库
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        int DeleteWareHouse(Guid wareHouseId, SqlTransaction trans);
        /// <summary>
        /// 根据条件获取仓库
        /// </summary>
        /// <param name="conditon"></param>
        /// <returns></returns>
        IList<WareHouseInfo> GetWareHouse(IEnumerable<SearchCondition> conditon, SqlConnection conn);
        /// <summary>
        /// 获取满足条件的仓库
        /// </summary>
        /// <param name="conditon"></param>
        /// <returns></returns>
        int GetWareHouseCount(IEnumerable<SearchCondition> conditon, SqlConnection conn);
        /// <summary>
        /// 获取指定页的仓库
        /// </summary>
        /// <param name="conditon"></param>
        /// <param name="page">页数</param>
        /// <param name="pagesize">每页数量</param>
        /// <param name="conn"></param>
        /// <returns></returns>
        IList<WareHouseInfo> GetPageWareHouse(IEnumerable<SearchCondition> conditon, int page, int pagesize, SqlConnection conn);
    }
}
