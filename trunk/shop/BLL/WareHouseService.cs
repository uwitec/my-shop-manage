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
    public class WareHouseService : IWareHouseService
    {
        private IWareHouse DAL = DALFactory.DataAccess.CreateWareHouse();
        public int GetWareHouseCount(IEnumerable<SearchCondition> condition)
        {
            SqlConnection conn;
            int count=0;
            using (conn = SqlHelper.CreateConntion())
            {
                conn.Open();
                count=DAL.GetWareHouseCount(condition,conn);
                conn.Close();
            }
            return count;
        }
        public int DeleteWareHouse(Guid wareHouseId)
        {
            SqlConnection conn;
            int count = 0;
            using (conn = SqlHelper.CreateConntion())
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();
                try
                {
                    count = DAL.DeleteWareHouse(wareHouseId, trans);
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

        public int UpdateWareHouse(WareHouseInfo wareHouse)
        {
            SqlConnection conn;
            int count = 0;
            using (conn = SqlHelper.CreateConntion())
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();
                try
                {
                    count = DAL.UpdateWareHouse(wareHouse, trans);
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

        public int InsertWareHouse(WareHouseInfo wareHouse)
        {
            SqlConnection conn;
            int count = 0;
            using (conn = SqlHelper.CreateConntion())
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();
                try
                {
                    count = DAL.InsertWareHouse(wareHouse, trans);
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

        public WareHouseInfo GetWareHouseById(Guid wareHouseId)
        {
            SqlConnection conn;
            IList<WareHouseInfo> l;
            SearchCondition[] condition = new SearchCondition[] { 
                new SearchCondition { con = "id=@id", param = "@id", value = wareHouseId.ToString() } 
            };
            using (conn = SqlHelper.CreateConntion())
            {
                conn.Open();
                l = DAL.GetWareHouse(condition, conn);
                if(l.Count>0)
                {
                    return l[0];
                }
                conn.Close();
                return null;
            }
        }

        public IList<WareHouseInfo> GetPageWareHouse(IEnumerable<SearchCondition> condition, int page, int pagesize)
        {
            SqlConnection conn;
            IList<WareHouseInfo> l;
            using (conn = SqlHelper.CreateConntion())
            {
                conn.Open();
                l = DAL.GetPageWareHouse(condition,page,pagesize,conn);
                conn.Close();
                return l ;
            }
        }

    }
}
