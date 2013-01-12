using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using Common;

namespace IBLL
{
    public interface IStockService
    {
        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        int InsertStock(StockInfo stock);
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        int DeleteStock(Guid stockId);
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        int UpdateStock(StockInfo stock);
        /// <summary>
        /// 根据ID获取
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        StockInfo GetStockById(Guid stockId);
        /// <summary>
        /// 根据条件获取
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="page"></param>
        /// <param name="pagesize"></param>
        /// <returns></returns>
        IList<StockInfo> GetPageStock(IEnumerable<SearchCondition> condition, int page, int pagesize);
        /// <summary>
        /// 获取满足条件的记录数量
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        int GetStockCount(IEnumerable<SearchCondition> condition);
    }
}
