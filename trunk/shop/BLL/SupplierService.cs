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
    public class SupplierService : ISupplierService
    {
        private ISupplier DAL = DALFactory.DataAccess.CreateSupplier();
        public int GetSupplierCount(IEnumerable<SearchCondition> condition)
        {
            SqlConnection conn;
            int count=0;
            using (conn = SqlHelper.CreateConntion())
            {
                conn.Open();
                count=DAL.GetSupplierCount(condition,conn);
                conn.Close();
            }
            return count;
        }
        public int DeleteSupplier(Guid supplierId)
        {
            SqlConnection conn;
            int count = 0;
            using (conn = SqlHelper.CreateConntion())
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();
                try
                {
                    count = DAL.DeleteSupplier(supplierId, trans);
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

        public int UpdateSupplier(SupplierInfo supplier)
        {
            SqlConnection conn;
            int count = 0;
            using (conn = SqlHelper.CreateConntion())
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();
                try
                {
                    count = DAL.UpdateSupplier(supplier, trans);
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

        public int InsertSupplier(SupplierInfo supplier)
        {
            SqlConnection conn;
            int count = 0;
            using (conn = SqlHelper.CreateConntion())
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();
                try
                {
                    count = DAL.InsertSupplier(supplier, trans);
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

        public SupplierInfo GetSupplierById(Guid supplierId)
        {
            SqlConnection conn;
            IList<SupplierInfo> l;
            SearchCondition[] condition = new SearchCondition[] { 
                new SearchCondition { con = "id=@id", param = "@id", value = supplierId.ToString() } 
            };
            using (conn = SqlHelper.CreateConntion())
            {
                conn.Open();
                l = DAL.GetSupplier(condition, conn);
                if(l.Count>0)
                {
                    return l[0];
                }
                conn.Close();
                return null;
            }
        }

        public IList<SupplierInfo> GetPageSupplier(IEnumerable<SearchCondition> condition, int page, int pagesize)
        {
            SqlConnection conn;
            IList<SupplierInfo> l;
            using (conn = SqlHelper.CreateConntion())
            {
                conn.Open();
                l = DAL.GetPageSupplier(condition,page,pagesize,conn);
                conn.Close();
                return l ;
            }
        }

    }
}
