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
    /// 员工
    /// </summary>
    public interface IStuff
    {
        /// <summary>
        /// 增加员工
        /// </summary>
        /// <param name="changeStock"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        int InsertStuff(StuffInfo stuff, SqlTransaction trans);
        /// <summary>
        /// 更新员工
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        int UpdateStuff(StuffInfo stuff, SqlTransaction trans);
        /// <summary>
        /// 根据员工id删除员工
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        int DeleteStuff(Guid stuffId, SqlTransaction trans);
        /// <summary>
        /// 根据条件获取员工
        /// </summary>
        /// <param name="conditon"></param>
        /// <returns></returns>
        IList<StuffInfo> GetStuff(SearchCondition conditon, SqlConnection conn);
        /// <summary>
        /// 获取满足条件的员工
        /// </summary>
        /// <param name="conditon"></param>
        /// <returns></returns>
        int GetStuffCount(SearchCondition conditon, SqlConnection conn);
        /// <summary>
        /// 获取指定页的员工
        /// </summary>
        /// <param name="conditon"></param>
        /// <param name="page">页数</param>
        /// <param name="pagesize">每页数量</param>
        /// <param name="conn"></param>
        /// <returns></returns>
        IList<StuffInfo> GetPageStuff(SearchCondition conditon, int page, int pagesize, SqlConnection conn);
    }
}
