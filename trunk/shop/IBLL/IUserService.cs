using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using Common;

namespace IBLL
{
    public interface IUserService
    {
        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        int InsertUser(UserInfo user);
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        int DeleteUser(Guid userId);
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        int UpdateUser(UserInfo user);
        /// <summary>
        /// 根据ID获取
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        UserInfo GetUserById(Guid userId);
        /// <summary>
        /// 根据条件获取
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="page"></param>
        /// <param name="pagesize"></param>
        /// <returns></returns>
        IList<UserInfo> GetPageUser(IEnumerable<SearchCondition> condition, int page, int pagesize);
        /// <summary>
        /// 获取满足条件的记录数量
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        int GetUserCount(IEnumerable<SearchCondition> condition);
    }
}
