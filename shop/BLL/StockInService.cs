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
    public class StockInService : IStockInService
    {
        private IStockIn DAL = DALFactory.DataAccess.CreateStockIn();
        public int GetStockInCount(IEnumerable<SearchCondition> condition)
        {
            SqlConnection conn;
            int count=0;
            using (conn = SqlHelper.CreateConntion())
            {
                conn.Open();
                count=DAL.GetStockInCount(condition,conn);
                conn.Close();
            }
            return count;
        }
        public int DeleteStockIn(Guid stockInId)
        {
            SqlConnection conn;
            int count = 0;
            using (conn = SqlHelper.CreateConntion())
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();
                try
                {
                    count = DAL.DeleteStockIn(stockInId, trans);
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

        public int UpdateStockIn(StockInInfo stockIn, bool body)
        {
            SqlConnection conn;
            int count = 0;
            using (conn = SqlHelper.CreateConntion())
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();
                try
                {
                    count = DAL.UpdateStockIn(stockIn, body, trans);
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

        public int InsertStockIn(StockInInfo stockIn)
        {
            SqlConnection conn;
            int count = 0;
            using (conn = SqlHelper.CreateConntion())
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();
                try
                {
                    count = DAL.InsertStockIn(stockIn, trans);
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

        public StockInInfo GetStockInById(Guid stockInId)
        {
            SqlConnection conn;
            IList<StockInInfo> l;
            SearchCondition[] condition = new SearchCondition[] { new SearchCondition { con = "id=@id", param = "@id", value = stockInId.ToString() } };
            using (conn = SqlHelper.CreateConntion())
            {
                conn.Open();
                l = DAL.GetStockIn(condition, conn);
                if(l.Count>0)
                {
                    return l[0];
                }
                conn.Close();
                return null;
            }
        }

        public IList<StockInInfo> GetPageStockIn(IEnumerable<SearchCondition> condition, int page, int pagesize)
        {
            SqlConnection conn;
            IList<StockInInfo> l;
            using (conn = SqlHelper.CreateConntion())
            {
                conn.Open();
                l = DAL.GetPageStockIn(condition,page,pagesize,conn);
                conn.Close();
                return l ;
            }
        }

    }
}
