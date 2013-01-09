using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data.SqlClient;
using Common;

namespace IDAL
{
    /// <summary>
    /// 用户
    /// </summary>
    public interface IUser
    {
        /// <summary>
        /// 增加供用户
        /// </summary>
        /// <param name="changeStock"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        int InsertUser(UserInfo user, SqlTransaction trans);
        /// <summary>
        /// 更新用户
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        int UpdateUser(UserInfo user, SqlTransaction trans);
        /// <summary>
        /// 根据id删除用户
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        int DeleteUser(Guid userId, SqlTransaction trans);
        /// <summary>
        /// 根据条件获取用户
        /// </summary>
        /// <param name="conditon"></param>
        /// <returns></returns>
        IList<UserInfo> GetUser(IEnumerable<SearchCondition> conditon, SqlConnection conn);
        /// <summary>
        /// 获取满足条件的用户
        /// </summary>
        /// <param name="conditon"></param>
        /// <returns></returns>
        int GetUserCount(IEnumerable<SearchCondition> conditon, SqlConnection conn);
        /// <summary>
        /// 获取指定页的用户
        /// </summary>
        /// <param name="conditon"></param>
        /// <param name="page">页数</param>
        /// <param name="pagesize">每页数量</param>
        /// <param name="conn"></param>
        /// <returns></returns>
        IList<UserInfo> GetPageUser(IEnumerable<SearchCondition> conditon, int page, int pagesize, SqlConnection conn);
    }
}
