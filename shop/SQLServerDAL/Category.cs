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
    public class Category:ICategory
    {
        public int InsertCategory(CategoryInfo category, SqlConnection conn)
        {
            string sql = @"INSERT INTO [Category]
                               ([categoryName]
                               ,[parentID]
                               ,[InsertDateTime]
                               ,[InsertUser])
                         VALUES
                               (@categoryName
                               ,@parentID
                               ,@InsertDateTime
                               ,@InsertUser)";
            SqlParameter[] spvalues = DBTool.GetSqlPm(category);
            return SqlHelper.ExecuteNonQuery(conn, System.Data.CommandType.Text, sql, spvalues);
        }

        public int UpdateCategory(CategoryInfo category, SqlConnection conn)
        {
            string sql = @"UPDATE [Category]
                               SET [categoryName] = @categoryName
                                  ,[parentID] = @parentID
                                  ,[UpdateDateTime] = @UpdateDateTime
                                  ,[UpdateUser] = @UpdateUser
                             WHERE id=@id";
            SqlParameter[] spvalues = DBTool.GetSqlPm(category);
            return SqlHelper.ExecuteNonQuery(conn, System.Data.CommandType.Text, sql, spvalues);
        }

        public int DeleteCategoryById(Guid categoryId, SqlConnection conn)
        {
            string sql = "DELETE FROM [Category] WHERE id=@id";
            SqlParameter val = new SqlParameter("@id", categoryId);
            return SqlHelper.ExecuteNonQuery(conn, System.Data.CommandType.Text, sql, val);
        }

        public IList<CategoryInfo> GetCategory(IEnumerable<SearchCondition> conditon, SqlConnection conn)
        {
            IList<CategoryInfo> lcategory=new List<CategoryInfo>();
            string sql = @"SELECT [id]
                              ,[categoryName]
                              ,[parentID]
                              ,[InsertDateTime]
                              ,[InsertUser]
                              ,[UpdateDateTime]
                              ,[UpdateUser]
                          FROM [Category]";
            if (conditon.Count() > 0)
            {
                string con = DBTool.GetSqlcon(conditon);
                sql += " where " + con;
            }
            SqlParameter[] spvalues = DBTool.GetSqlParam(conditon);
            DataTable dt= SqlHelper.Squery(sql, conn, spvalues);
            lcategory = DBTool.GetListFromDatatable<CategoryInfo>(dt);
            return lcategory;
        }

        public int GetCategoryCount(IEnumerable<SearchCondition> conditon, SqlConnection conn)
        {
            string sql = @"SELECT count(*) as count FROM [Category]";
            if (conditon.Count() > 0)
            {
                string con = DBTool.GetSqlcon(conditon);
                sql += " where " + con;
            }
            SqlParameter[] spvalues = DBTool.GetSqlParam(conditon);
            int count = (int)SqlHelper.ExecuteScalar(conn, CommandType.Text, sql, spvalues);
            return count;
        }

        public IList<CategoryInfo> GetPageCategory(IEnumerable<SearchCondition> conditon, int page, int pagesize, SqlConnection conn)
        {
            IList<CategoryInfo> lcategory = new List<CategoryInfo>();
            string sql = @"SELECT [id]
                              ,[categoryName]
                              ,[parentID]
                              ,[InsertDateTime]
                              ,[InsertUser]
                              ,[UpdateDateTime]
                              ,[UpdateUser]
                              ,ROW_NUMBER() over(order by InsertDateTime) as row
                          FROM [Category] ";
            if (conditon.Count() > 0)
            {
                string con = DBTool.GetSqlcon(conditon);
                sql += " where " + con;
            }
            sql = "select * from (" + sql + ") as a where row>" + (page - 1) * pagesize + " and row<=" + page * pagesize;
            SqlParameter[] spvalues = DBTool.GetSqlParam(conditon);
            DataTable dt = SqlHelper.Squery(sql, conn, spvalues);
            lcategory = DBTool.GetListFromDatatable<CategoryInfo>(dt);
            return lcategory;
        }

    }
}
