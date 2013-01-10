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
    public class Stuff:IStuff
    {
        public int InsertStuff(StuffInfo stuff, SqlTransaction trans)
        {
            string sql = @"INSERT INTO [Stuff]
                                   ([WareHouseID]
                                   ,[StuffNO]
                                   ,[Name]
                                   ,[Sex]
                                   ,[Tel]
                                   ,[Email]
                                   ,[Birthday]
                                   ,[address]
                                   ,[IsOn]
                                   ,[detail]
                                   ,[InsertDateTime]
                                   ,[InsertUser])
                             VALUES
                                   (@WareHouseID
                                   ,@StuffNO
                                   ,@Name
                                   ,@Sex
                                   ,@Tel
                                   ,@Email
                                   ,@Birthday
                                   ,@address
                                   ,@IsOn
                                   ,@detail
                                   ,@InsertDateTime
                                   ,@InsertUser)";
            SqlParameter[] spvalues = DBTool.GetSqlPm(stuff);
            return SqlHelper.ExecuteNonQuery(trans, System.Data.CommandType.Text, sql, spvalues);
        }

        public int UpdateStuff(StuffInfo stuff, SqlTransaction trans)
        {
            string sql = @"UPDATE [Stuff]
                           SET [WareHouseID] = @WareHouseID
                              ,[StuffNO] = @StuffNO
                              ,[Name] = @Name
                              ,[Sex] = @Sex
                              ,[Tel] = @Tel
                              ,[Email] = @Email
                              ,[Birthday] = @Birthday
                              ,[address] = @address
                              ,[IsOn] = @IsOn
                              ,[detail] = @detail
                              ,[UpdateDateTime] = @UpdateDateTime
                              ,[UpdateUser] = @UpdateUser
                             WHERE id=@id";
            SqlParameter[] spvalues = DBTool.GetSqlPm(stuff);
            return SqlHelper.ExecuteNonQuery(trans, System.Data.CommandType.Text, sql, spvalues);
        }

        public int DeleteStuff(Guid stuffId, SqlTransaction trans)
        {
            string sql = "DELETE FROM [Stuff] WHERE id=@id";
            SqlParameter val = new SqlParameter("@id", stuffId);
            return SqlHelper.ExecuteNonQuery(trans, System.Data.CommandType.Text, sql, val);
        }

        public IList<StuffInfo> GetStuff(IEnumerable<SearchCondition> conditon, SqlConnection conn)
        {
            IList<StuffInfo> l = new List<StuffInfo>();
            string sql = @"SELECT [id]
                                  ,[WareHouseID]
                                  ,[StuffNO]
                                  ,[Name]
                                  ,[Sex]
                                  ,[Tel]
                                  ,[Email]
                                  ,[Birthday]
                                  ,[address]
                                  ,[IsOn]
                                  ,[detail]
                                  ,[InsertDateTime]
                                  ,[InsertUser]
                                  ,[UpdateDateTime]
                                  ,[UpdateUser]
                              FROM [Stuff]";
            if (conditon.Count() > 0)
            {
                string con = DBTool.GetSqlcon(conditon);
                sql += " where " + con;
            }
            SqlParameter[] spvalues = DBTool.GetSqlParam(conditon);
            DataTable dt = SqlHelper.Squery(sql, conn, spvalues);
            l = DBTool.GetListFromDatatable<StuffInfo>(dt);
            return l;
        }

        public int GetStuffCount(IEnumerable<SearchCondition> conditon, SqlConnection conn)
        {
            string sql = @"SELECT count(*) as count FROM [Stuff]";
            if (conditon.Count() > 0)
            {
                string con = DBTool.GetSqlcon(conditon);
                sql += " where " + con;
            }
            SqlParameter[] spvalues = DBTool.GetSqlParam(conditon);
            int count = (int)SqlHelper.ExecuteScalar(conn, CommandType.Text, sql, spvalues);
            return count;
        }

        public IList<StuffInfo> GetPageStuff(IEnumerable<SearchCondition> conditon, int page, int pagesize, SqlConnection conn)
        {
            IList<StuffInfo> l = new List<StuffInfo>();
            string sql = @"SELECT [id]
                                  ,[WareHouseID]
                                  ,[StuffNO]
                                  ,[Name]
                                  ,[Sex]
                                  ,[Tel]
                                  ,[Email]
                                  ,[Birthday]
                                  ,[address]
                                  ,[IsOn]
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
            l = DBTool.GetListFromDatatable<StuffInfo>(dt);
            return l;
        }
    }
}
