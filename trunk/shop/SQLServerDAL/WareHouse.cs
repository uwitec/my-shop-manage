using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IDAL;
using Model;
using DBUtility;
using System.Data.SqlClient;
using Common;
using System.Data;

namespace SQLServerDAL
{
    public class WareHouse:IWareHouse
    {
        public int InsertWareHouse(WareHouseInfo wareHouse, SqlTransaction trans)
        {
            string sql = @"INSERT INTO [WareHouse]
                                   ([Name]
                                   ,[No]
                                   ,[Address]
                                   ,[Tel]
                                   ,[detail]
                                   ,[InsertDateTime]
                                   ,[InsertUser])
                             VALUES
                                   (@Name
                                   ,@No
                                   ,@Address
                                   ,@Tel
                                   ,@detail
                                   ,@InsertDateTime
                                   ,@InsertUser)";
            SqlParameter[] spvalues = DBTool.GetSqlPm(wareHouse);
            return SqlHelper.ExecuteNonQuery(trans, System.Data.CommandType.Text, sql, spvalues);
        }

        public int UpdateWareHouse(WareHouseInfo wareHouse, SqlTransaction trans)
        {
            string sql = @"UPDATE [WareHouse]
                               SET [id] = @id
                                  ,[Name] = @Name
                                  ,[No] = @No
                                  ,[Address] = @Address
                                  ,[Tel] = @Tel
                                  ,[detail] = @detail
                                  ,[InsertDateTime] = @InsertDateTime
                                  ,[InsertUser] = @InsertUser
                             WHERE id=@id";
            SqlParameter[] spvalues = DBTool.GetSqlPm(wareHouse);
            return SqlHelper.ExecuteNonQuery(trans, System.Data.CommandType.Text, sql, spvalues);
        }

        public int DeleteWareHouse(Guid wareHouseId, SqlTransaction trans)
        {
            string sql = "DELETE FROM [WareHouse] WHERE id=@id";
            SqlParameter val = new SqlParameter("@id", wareHouseId);
            return SqlHelper.ExecuteNonQuery(trans, System.Data.CommandType.Text, sql, val);
        }

        public IList<WareHouseInfo> GetWareHouse(IEnumerable<SearchCondition> conditon, SqlConnection conn)
        {
            IList<WareHouseInfo> l = new List<WareHouseInfo>();
            string sql = @"SELECT [id]
                                  ,[Name]
                                  ,[No]
                                  ,[Address]
                                  ,[Tel]
                                  ,[detail]
                                  ,[InsertDateTime]
                                  ,[InsertUser]
                                  ,[UpdateDateTime]
                                  ,[UpdateUser]
                              FROM [WareHouse]";
            if (conditon.Count() > 0)
            {
                string con = DBTool.GetSqlcon(conditon);
                sql += " where " + con;
            }
            SqlParameter[] spvalues = DBTool.GetSqlParam(conditon);
            DataTable dt = SqlHelper.Squery(sql, conn, spvalues);
            l = DBTool.GetListFromDatatable<WareHouseInfo>(dt);
            return l;
        }

        public int GetWareHouseCount(IEnumerable<SearchCondition> conditon, SqlConnection conn)
        {
            string sql = @"SELECT count(*) as count FROM [WareHouse]";
            if (conditon.Count() > 0)
            {
                string con = DBTool.GetSqlcon(conditon);
                sql += " where " + con;
            }
            SqlParameter[] spvalues = DBTool.GetSqlParam(conditon);
            int count = (int)SqlHelper.ExecuteScalar(conn, CommandType.Text, sql, spvalues);
            return count;
        }

        public IList<WareHouseInfo> GetWareHouse(IEnumerable<SearchCondition> conditon, int page, int pagesize, SqlConnection conn)
        {
            IList<WareHouseInfo> l = new List<WareHouseInfo>();
            string sql = @"SELECT [id]
                                  ,[Name]
                                  ,[No]
                                  ,[Address]
                                  ,[Tel]
                                  ,[detail]
                                  ,[InsertDateTime]
                                  ,[InsertUser]
                                  ,[UpdateDateTime]
                                  ,[UpdateUser]
                                  ,ROW_NUMBER() over(order by InsertDateTime) as row
                          FROM [Product] ";
            if (conditon.Count() > 0)
            {
                string con = DBTool.GetSqlcon(conditon);
                sql += " where " + con;
            }
            sql = "select * from (" + sql + ") as a where row>" + (page - 1) * pagesize + " and row<=" + page * pagesize;
            SqlParameter[] spvalues = DBTool.GetSqlParam(conditon);
            DataTable dt = SqlHelper.Squery(sql, conn, spvalues);
            l = DBTool.GetListFromDatatable<WareHouseInfo>(dt);
            return l;
        }
    }
}
