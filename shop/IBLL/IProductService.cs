using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using Common;

namespace IBLL
{
    public interface IProductService
    {
        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        int InsertProduct(ProductInfo product);
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        int DeleteProduct(Guid productId);
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        int UpdateProduct(ProductInfo product);
        /// <summary>
        /// 根据ID获取
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        ProductInfo GetProductById(Guid productId);
        /// <summary>
        /// 根据条件获取
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="page"></param>
        /// <param name="pagesize"></param>
        /// <returns></returns>
        IList<ProductInfo> GetPageProduct(IEnumerable<SearchCondition> condition, int page, int pagesize);
        /// <summary>
        /// 获取满足条件的记录数量
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        int GetProductCount(IEnumerable<SearchCondition> condition);
    }
}
