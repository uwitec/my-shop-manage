using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using Common;

namespace IBLL
{
    public interface IChangeStockService
    {
        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="changeStock"></param>
        /// <returns></returns>
        int InsertChangeStock(ChangeStockInfo changeStock);
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int DeleteChangeStock(Guid id);
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="changeStock"></param>
        /// <returns></returns>
        int UpdateChangeStock(ChangeStockInfo changeStock,bool body);
        /// <summary>
        /// 根据ID获取
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ChangeStockInfo GetChangeStockById(Guid id);
        /// <summary>
        /// 根据条件获取一页
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="page"></param>
        /// <param name="pagesize"></param>
        /// <returns></returns>
        IList<ChangeStockInfo> GetPageChangeStock(IEnumerable<SearchCondition> condition,int page,int pagesize);
        /// <summary>
        /// 获取满足条件的数量
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        int GetChangeStockCount(IEnumerable<SearchCondition> condition);
    }
}
