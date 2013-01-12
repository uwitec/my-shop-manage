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
    public class CheckBillService : ICheckBillService
    {
        private ICheckBill DAL = DALFactory.DataAccess.CreateCheckBill();
        public int GetChangeStockCount(IEnumerable<SearchCondition> condition)
        {
            SqlConnection conn;
            int count=0;
            using (conn = SqlHelper.CreateConntion())
            {
                conn.Open();
                count=DAL.GetChangeStockCount(condition,conn);
                conn.Close();
            }
            return count;
        }
        public int DeleteCheckBill(Guid id)
        {
            SqlConnection conn;
            int count = 0;
            using (conn = SqlHelper.CreateConntion())
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();
                try
                {
                    count = DAL.DeleteCheckBill(id,trans);
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

        public int UpdateCheckBill(check changeStock, bool changebody)
        {
            SqlConnection conn;
            int count = 0;
            using (conn = SqlHelper.CreateConntion())
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();
                try
                {
                    count = DAL.UpdateChangeStock(changeStock,changebody,trans);
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

        public int InsertCheckBill(CheckBillInfo checkBill)
        {
            SqlConnection conn;
            int count = 0;
            using (conn = SqlHelper.CreateConntion())
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();
                try
                {
                    count = DAL.InsertCheckBill(checkBill, trans);
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

        public ChangeStockInfo GetChangeStockById(Guid id)
        {
            SqlConnection conn;
            IList<ChangeStockInfo> l;
            SearchCondition[] condition = new SearchCondition[] { new SearchCondition{con="id=@id",param="@id",value=categoryId.ToString()}};
            using (conn = SqlHelper.CreateConntion())
            {
                conn.Open();
                l = DAL.GetChangeStock(condition, conn);
                if(l.Count>0)
                {
                    return l[0];
                }
                conn.Close();
                return null;
            }
        }

        public IList<ChangeStockInfo> GetPageChangeStock(IEnumerable<SearchCondition> condition, int page, int pagesize)
        {
            SqlConnection conn;
            IList<ChangeStockInfo> l;
            using (conn = SqlHelper.CreateConntion())
            {
                conn.Open();
                l = DAL.GetPageChangeStock(condition,page,pagesize,conn);
                conn.Close();
                return l ;
            }
        }

    }
}
