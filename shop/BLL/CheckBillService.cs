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

        public int UpdateCheckBill(CheckBillInfo checkbill, bool changebody)
        {
            SqlConnection conn;
            int count = 0;
            using (conn = SqlHelper.CreateConntion())
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();
                try
                {
                    count = DAL.UpdateCheckBill(checkbill, changebody, trans);
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

        public CheckBillInfo GetCheckBillById(Guid id)
        {
            SqlConnection conn;
            IList<CheckBillInfo> l;
            SearchCondition[] condition = new SearchCondition[] { new SearchCondition{con="id=@id",param="@id",value=categoryId.ToString()}};
            using (conn = SqlHelper.CreateConntion())
            {
                conn.Open();
                l = DAL.GetCheckBill(condition, conn);
                if(l.Count>0)
                {
                    return l[0];
                }
                conn.Close();
                return null;
            }
        }

        public IList<CheckBillInfo> GetPageCheckBill(IEnumerable<SearchCondition> condition, int page, int pagesize)
        {
            SqlConnection conn;
            IList<CheckBillInfo> l;
            using (conn = SqlHelper.CreateConntion())
            {
                conn.Open();
                l = DAL.GetPageCheckBill(condition,page,pagesize,conn);
                conn.Close();
                return l ;
            }
        }

    }
}
