using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using Common;

namespace IBLL
{
    public interface IStockInService
    {
        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        int InsertStockIn(StockInInfo stockIn);
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        int DeleteStockIn(Guid stockInId);
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        int UpdateStockIn(StockInInfo stockIn,bool body);
        /// <summary>
        /// 根据ID获取
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        StockInInfo GetStockInById(Guid stockInId);
        /// <summary>
        /// 根据条件获取
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="page"></param>
        /// <param name="pagesize"></param>
        /// <returns></returns>
        IList<StockInInfo> GetPageStockIn(IEnumerable<SearchCondition> condition, int page, int pagesize);
        /// <summary>
        /// 获取满足条件的记录数量
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        int GetStockInCount(IEnumerable<SearchCondition> condition);
    }
}
