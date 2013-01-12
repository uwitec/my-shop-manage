using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using Common;

namespace IBLL
{
    public interface IWareHouseService
    {
        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        int InsertWareHouse(WareHouseInfo wareHouse);
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        int DeleteWareHouse(Guid wareHouseId);
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        int UpdateWareHouse(WareHouseInfo wareHouse);
        /// <summary>
        /// 根据ID获取
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        WareHouseInfo GetWareHouseById(Guid wareHouseId);
        /// <summary>
        /// 根据条件获取
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="page"></param>
        /// <param name="pagesize"></param>
        /// <returns></returns>
        IList<WareHouseInfo> GetPageWareHouse(IEnumerable<SearchCondition> condition, int page, int pagesize);
        /// <summary>
        /// 获取满足条件的记录数量
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        int GetWareHouseCount(IEnumerable<SearchCondition> condition);
    }
}
