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
    public class User:IUser
    {
        public int InsertUser(UserInfo user, SqlTransaction trans)
        {
            string sql = @"INSERT INTO [User]
                                   ([UserID]
                                   ,[Password]
                                   ,[UserName]
                                   ,[Email]
                                   ,[InsertDateTime]
                                   ,[InsertUser])
                             VALUES
                                   (@UserID
                                   ,@Password
                                   ,@UserName
                                   ,@Email
                                   ,@InsertDateTime
                                   ,@InsertUser)";
            SqlParameter[] spvalues = DBTool.GetSqlPm(user);
            return SqlHelper.ExecuteNonQuery(trans, System.Data.CommandType.Text, sql, spvalues);
        }

        public int UpdateUser(UserInfo user, SqlTransaction trans)
        {
            string sql = @"UPDATE [User]
                               SET [UserID] = @UserID
                                  ,[Password] = @Password
                                  ,[UserName] = @UserName
                                  ,[Email] = @Email
                                  ,[InsertDateTime] = @InsertDateTime
                                  ,[InsertUser] = @InsertUser
                                  ,[UpdateDateTime] = @UpdateDateTime
                                  ,[UpdateUser] = @UpdateUser
                             WHERE id=@id";
            SqlParameter[] spvalues = DBTool.GetSqlPm(user);
            return SqlHelper.ExecuteNonQuery(trans, System.Data.CommandType.Text, sql, spvalues);
        }

        public int DeleteUser(Guid userId, SqlTransaction trans)
        {
            string sql = "DELETE FROM [User] WHERE id=@id";
            SqlParameter val = new SqlParameter("@id", userId);
            return SqlHelper.ExecuteNonQuery(trans, System.Data.CommandType.Text, sql, val);
        }

        public IList<UserInfo> GetUser(IEnumerable<SearchCondition> conditon, SqlConnection conn)
        {
            IList<UserInfo> l = new List<UserInfo>();
            string sql = @"SELECT [id]
                                  ,[UserID]
                                  ,[Password]
                                  ,[UserName]
                                  ,[Email]
                                  ,[InsertDateTime]
                                  ,[InsertUser]
                                  ,[UpdateDateTime]
                                  ,[UpdateUser]
                              FROM [User]";
            if (conditon.Count() > 0)
            {
                string con = DBTool.GetSqlcon(conditon);
                sql += " where " + con;
            }
            SqlParameter[] spvalues = DBTool.GetSqlParam(conditon);
            DataTable dt = SqlHelper.Squery(sql, conn, spvalues);
            l = DBTool.GetListFromDatatable<UserInfo>(dt);
            return l;
        }

        public int GetUserCount(IEnumerable<SearchCondition> conditon, SqlConnection conn)
        {
            string sql = @"SELECT count(*) as count FROM [User]";
            if (conditon.Count() > 0)
            {
                string con = DBTool.GetSqlcon(conditon);
                sql += " where " + con;
            }
            SqlParameter[] spvalues = DBTool.GetSqlParam(conditon);
            int count = (int)SqlHelper.ExecuteScalar(conn, CommandType.Text, sql, spvalues);
            return count;
        }

        public IList<UserInfo> GetPageUser(IEnumerable<SearchCondition> conditon, int page, int pagesize, SqlConnection conn)
        {
            IList<UserInfo> l = new List<UserInfo>();
            string sql = @"SELECT [id]
                                  ,[UserID]
                                  ,[Password]
                                  ,[UserName]
                                  ,[Email]
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
            l = DBTool.GetListFromDatatable<UserInfo>(dt);
            return l;
        }

    }
}
