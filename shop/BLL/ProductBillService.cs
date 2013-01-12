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
    public class ProductBillService : IProductBillService
    {
        private IProductBill DAL = DALFactory.DataAccess.CreateProductBill();
        public int GetProductBillCount(IEnumerable<SearchCondition> condition)
        {
            SqlConnection conn;
            int count=0;
            using (conn = SqlHelper.CreateConntion())
            {
                conn.Open();
                count=DAL.GetProductBillCount(condition,conn);
                conn.Close();
            }
            return count;
        }
        public int DeleteProductBill(Guid productBillId)
        {
            SqlConnection conn;
            int count = 0;
            using (conn = SqlHelper.CreateConntion())
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();
                try
                {
                    count = DAL.DeleteProductBill(productBillId, trans);
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

        public int UpdateProductBill(ProductBillInfo productBill, bool body)
        {
            SqlConnection conn;
            int count = 0;
            using (conn = SqlHelper.CreateConntion())
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();
                try
                {
                    count = DAL.UpdateProductBill(productBill, body, trans);
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

        public int InsertProductBill(ProductBillInfo productBill)
        {
            SqlConnection conn;
            int count = 0;
            using (conn = SqlHelper.CreateConntion())
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();
                try
                {
                    count = DAL.InsertProductBill(productBill, trans);
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

        public ProductBillInfo GetProductBillById(Guid productBillId)
        {
            SqlConnection conn;
            IList<ProductBillInfo> l;
            SearchCondition[] condition = new SearchCondition[] { new SearchCondition { con = "id=@id", param = "@id", value = productBillId.ToString() } };
            using (conn = SqlHelper.CreateConntion())
            {
                conn.Open();
                l = DAL.GetProductBill(condition, conn);
                if(l.Count>0)
                {
                    return l[0];
                }
                conn.Close();
                return null;
            }
        }

        public IList<ProductBillInfo> GetPageProductBill(IEnumerable<SearchCondition> condition, int page, int pagesize)
        {
            SqlConnection conn;
            IList<ProductBillInfo> l;
            using (conn = SqlHelper.CreateConntion())
            {
                conn.Open();
                l = DAL.GetPageProductBill(condition,page,pagesize,conn);
                conn.Close();
                return l ;
            }
        }

    }
}
