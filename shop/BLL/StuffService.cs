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
    public class StuffService : IStuffService
    {
        private IStuff DAL = DALFactory.DataAccess.CreateStuff();
        public int GetStuffCount(IEnumerable<SearchCondition> condition)
        {
            SqlConnection conn;
            int count=0;
            using (conn = SqlHelper.CreateConntion())
            {
                conn.Open();
                count=DAL.GetStuffCount(condition,conn);
                conn.Close();
            }
            return count;
        }
        public int DeleteStuff(Guid stuffId)
        {
            SqlConnection conn;
            int count = 0;
            using (conn = SqlHelper.CreateConntion())
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();
                try
                {
                    count = DAL.DeleteStuff(stuffId, trans);
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

        public int UpdateStuff(StuffInfo stuff)
        {
            SqlConnection conn;
            int count = 0;
            using (conn = SqlHelper.CreateConntion())
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();
                try
                {
                    count = DAL.UpdateStuff(stuff, trans);
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

        public int InsertStuff(StuffInfo stuff)
        {
            SqlConnection conn;
            int count = 0;
            using (conn = SqlHelper.CreateConntion())
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();
                try
                {
                    count = DAL.InsertStuff(stuff, trans);
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

        public StuffInfo GetStuffById(Guid stuffId)
        {
            SqlConnection conn;
            IList<StuffInfo> l;
            SearchCondition[] condition = new SearchCondition[] { 
                new SearchCondition { con = "id=@id", param = "@id", value = stuffId.ToString() } 
            };
            using (conn = SqlHelper.CreateConntion())
            {
                conn.Open();
                l = DAL.GetStuff(condition, conn);
                if(l.Count>0)
                {
                    return l[0];
                }
                conn.Close();
                return null;
            }
        }

        public IList<StuffInfo> GetPageStuff(IEnumerable<SearchCondition> condition, int page, int pagesize)
        {
            SqlConnection conn;
            IList<StuffInfo> l;
            using (conn = SqlHelper.CreateConntion())
            {
                conn.Open();
                l = DAL.GetPageStuff(condition,page,pagesize,conn);
                conn.Close();
                return l ;
            }
        }

    }
}
