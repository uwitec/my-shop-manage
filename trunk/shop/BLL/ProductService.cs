using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBLL;
using Common;
using IDAL;
using System.Data.SqlClient;
using DBUtility;
using Model;

namespace BLL
{
    public class ProductService : IProductService
    {
        private IProduct DAL = DALFactory.DataAccess.CreateProduct();
        public int GetProductCount(IEnumerable<SearchCondition> condition)
        {
            SqlConnection conn;
            int count=0;
            using (conn = SqlHelper.CreateConntion())
            {
                conn.Open();
                count=DAL.GetProductCount(condition,conn);
                conn.Close();
            }
            return count;
        }
        public int DeleteProduct(Guid productId)
        {
            SqlConnection conn;
            int count = 0;
            using (conn = SqlHelper.CreateConntion())
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();
                try
                {
                    count = DAL.DeleteProduct(productId, trans);
                    trans.Commit();
                }
                catch(Exception)
                {
                    trans.Rollback();
                }
                conn.Close();
            }
            return count;
        }

        public int UpdateProduct(ProductInfo product)
        {
            SqlConnection conn;
            int count = 0;
            using (conn = SqlHelper.CreateConntion())
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();
                try
                {
                    count = DAL.UpdateProduct(product, trans);
                    trans.Commit();
                }
                catch (Exception)
                {
                    trans.Rollback();
                }
                conn.Close();
            }
            return count;
        }

        public int InsertProduct(ProductInfo product)
        {
            SqlConnection conn;
            int count = 0;
            using (conn = SqlHelper.CreateConntion())
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();
                try
                {
                    count = DAL.InsertProduct(product, trans);
                    trans.Commit();
                }
                catch (Exception)
                {
                    trans.Rollback();
                }
                conn.Close();
            }
            return count;
        }

        public ProductInfo GetProductById(Guid productId)
        {
            SqlConnection conn;
            IList<ProductInfo> l;
            SearchCondition[] condition = new SearchCondition[] { new SearchCondition { con = "id=@id", param = "@id", value = productBillId.ToString() } };
            using (conn = SqlHelper.CreateConntion())
            {
                conn.Open();
                l = DAL.GetProduct(condition, conn);
                if(l.Count>0)
                {
                    return l[0];
                }
                conn.Close();
                return null;
            }
        }

        public IList<ProductInfo> GetPageProduct(IEnumerable<SearchCondition> condition, int page, int pagesize)
        {
            SqlConnection conn;
            IList<ProductInfo> l;
            using (conn = SqlHelper.CreateConntion())
            {
                conn.Open();
                l = DAL.GetPageProduct(condition,page,pagesize,conn);
                conn.Close();
                return l ;
            }
        }

    }
}
