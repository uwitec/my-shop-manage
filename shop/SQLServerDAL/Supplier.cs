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
    public class Supplier:ISupplier
    {
        public int InsertSupplier(SupplierInfo supplier, SqlTransaction trans)
        {
            string sql = @"INSERT INTO [Supplier]
                                   ([SupplierNO]
                                   ,[Name]
                                   ,[ZipCode]
                                   ,[Address]
                                   ,[Tel]
                                   ,[Fax]
                                   ,[StaffName]
                                   ,[Email]
                                   ,[InsertDateTime]
                                   ,[InsertUser])
                             VALUES
                                   (@SupplierNO
                                   ,@Name
                                   ,@ZipCode
                                   ,@Address
                                   ,@Tel
                                   ,@Fax
                                   ,@StaffName
                                   ,@Email
                                   ,@InsertDateTime
                                   ,@InsertUser)";
            SqlParameter[] spvalues = DBTool.GetSqlPm(supplier);
            return SqlHelper.ExecuteNonQuery(trans, System.Data.CommandType.Text, sql, spvalues);
        }

        public int UpdateSupplier(SupplierInfo stuff, SqlTransaction trans)
        {
            string sql = @"UPDATE [Supplier]
                               SET [id] = @id
                                  ,[SupplierNO] = @SupplierNO
                                  ,[Name] = @Name
                                  ,[ZipCode] = @ZipCode
                                  ,[Address] = @Address
                                  ,[Tel] = @Tel
                                  ,[Fax] = @Fax
                                  ,[StaffName] = @StaffName
                                  ,[Email] = @Email
                                  ,[UpdateDateTime] = @UpdateDateTime
                                  ,[UpdateUser] = @UpdateUser
                             WHERE id=@id";
            SqlParameter[] spvalues = DBTool.GetSqlPm(stuff);
            return SqlHelper.ExecuteNonQuery(trans, System.Data.CommandType.Text, sql, spvalues);
        }

        public int DeleteSupplier(Guid stuffId, SqlTransaction trans)
        {
            string sql = "DELETE FROM [Supplier] WHERE id=@id";
            SqlParameter val = new SqlParameter("@id", stuffId);
            return SqlHelper.ExecuteNonQuery(trans, System.Data.CommandType.Text, sql, val);
        }

        public IList<SupplierInfo> GetSupplier(IEnumerable<SearchCondition> conditon, SqlConnection conn)
        {
            IList<SupplierInfo> l = new List<SupplierInfo>();
            string sql = @"SELECT [id]
                                  ,[SupplierNO]
                                  ,[Name]
                                  ,[ZipCode]
                                  ,[Address]
                                  ,[Tel]
                                  ,[Fax]
                                  ,[StaffName]
                                  ,[Email]
                                  ,[InsertDateTime]
                                  ,[InsertUser]
                                  ,[UpdateDateTime]
                                  ,[UpdateUser]
                              FROM [Supplier]";
            if (conditon.Count() > 0)
            {
                string con = DBTool.GetSqlcon(conditon);
                sql += " where " + con;
            }
            SqlParameter[] spvalues = DBTool.GetSqlParam(conditon);
            DataTable dt = SqlHelper.Squery(sql, conn, spvalues);
            l = DBTool.GetListFromDatatable<SupplierInfo>(dt);
            return l;
        }

        public int GetSupplierCount(IEnumerable<SearchCondition> conditon, SqlConnection conn)
        {
            string sql = @"SELECT count(*) as count FROM [Supplier]";
            if (conditon.Count() > 0)
            {
                string con = DBTool.GetSqlcon(conditon);
                sql += " where " + con;
            }
            SqlParameter[] spvalues = DBTool.GetSqlParam(conditon);
            int count = (int)SqlHelper.ExecuteScalar(conn, CommandType.Text, sql, spvalues);
            return count;
        }

        public IList<SupplierInfo> GetPageSupplier(IEnumerable<SearchCondition> conditon, int page, int pagesize, SqlConnection conn)
        {
            IList<SupplierInfo> l = new List<SupplierInfo>();
            string sql = @"SELECT [id]
                                  ,[SupplierNO]
                                  ,[Name]
                                  ,[ZipCode]
                                  ,[Address]
                                  ,[Tel]
                                  ,[Fax]
                                  ,[StaffName]
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
            l = DBTool.GetListFromDatatable<SupplierInfo>(dt);
            return l;
        }
    }
}
