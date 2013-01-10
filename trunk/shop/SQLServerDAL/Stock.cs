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
    public class Stock:IStock
    {
        public int InsertStock(StockInfo stock, SqlTransaction trans)
        {
            string sql = @"INSERT INTO [Stock]
                                   ([WarehouseID]
                                   ,[ProductID]
                                   ,[StockInTP]
                                   ,[StockInDate]
                                   ,[StockInReason]
                                   ,[StockOutTP]
                                   ,[StockOutDate]
                                   ,[StockOutReason]
                                   ,[Num]
                                   ,[InsertDateTime]
                                   ,[InsertUser])
                             VALUES
                                   (@WarehouseID
                                   ,@ProductID
                                   ,@StockInTP
                                   ,@StockInDate
                                   ,@StockInReason
                                   ,@StockOutTP
                                   ,@StockOutDate
                                   ,@StockOutReason
                                   ,@Num
                                   ,@InsertDateTime
                                   ,@InsertUser)";
            SqlParameter[] spvalues = DBTool.GetSqlPm(stock);
            return SqlHelper.ExecuteNonQuery(trans, System.Data.CommandType.Text, sql, spvalues);
        }

        public int UpdateStock(StockInfo stock, SqlTransaction trans)
        {
            string sql = @"UPDATE [Stock]
                               SET [WarehouseID] = @WarehouseID
                                  ,[ProductID] = @ProductID
                                  ,[StockInTP] = @StockInTP
                                  ,[StockInDate] = @StockInDate
                                  ,[StockInReason] = @StockInReason
                                  ,[StockOutTP] = @StockOutTP
                                  ,[StockOutDate] = @StockOutDate
                                  ,[StockOutReason] = @StockOutReason
                                  ,[Num] = @Num
                                  ,[UpdateDateTime] = @UpdateDateTime
                                  ,[UpdateUser] = @UpdateUser
                             WHERE id=@id";
            SqlParameter[] spvalues = DBTool.GetSqlPm(stock);
            return SqlHelper.ExecuteNonQuery(trans, System.Data.CommandType.Text, sql, spvalues);
        }

        public int DeleteStock(Guid stockId, SqlTransaction trans)
        {
            string sql = "DELETE FROM [Stock] WHERE id=@id";
            SqlParameter val = new SqlParameter("@id", stockId);
            return SqlHelper.ExecuteNonQuery(trans, System.Data.CommandType.Text, sql, val);
        }

        public IList<StockInfo> GetStock(IEnumerable<SearchCondition> conditon, SqlConnection conn)
        {
            IList<StockInfo> l = new List<StockInfo>();
            string sql = @"SELECT [id]
                                  ,[WarehouseID]
                                  ,[ProductID]
                                  ,[StockInTP]
                                  ,[StockInDate]
                                  ,[StockInReason]
                                  ,[StockOutTP]
                                  ,[StockOutDate]
                                  ,[StockOutReason]
                                  ,[Num]
                                  ,[InsertDateTime]
                                  ,[InsertUser]
                                  ,[UpdateDateTime]
                                  ,[UpdateUser]
                              FROM [Stock]";
            if (conditon.Count() > 0)
            {
                string con = DBTool.GetSqlcon(conditon);
                sql += " where " + con;
            }
            SqlParameter[] spvalues = DBTool.GetSqlParam(conditon);
            DataTable dt = SqlHelper.Squery(sql, conn, spvalues);
            l = DBTool.GetListFromDatatable<StockInfo>(dt);
            return l;
        }

        public int GetStockCount(IEnumerable<SearchCondition> conditon, SqlConnection conn)
        {
            string sql = @"SELECT count(*) as count FROM [Stock]";
            if (conditon.Count() > 0)
            {
                string con = DBTool.GetSqlcon(conditon);
                sql += " where " + con;
            }
            SqlParameter[] spvalues = DBTool.GetSqlParam(conditon);
            int count = (int)SqlHelper.ExecuteScalar(conn, CommandType.Text, sql, spvalues);
            return count;
        }

        public IList<StockInfo> GetPageStock(IEnumerable<SearchCondition> conditon, int page, int pagesize, SqlConnection conn)
        {
            IList<StockInfo> l = new List<StockInfo>();
            string sql = @"SELECT [id]
                                  ,[WarehouseID]
                                  ,[ProductID]
                                  ,[StockInTP]
                                  ,[StockInDate]
                                  ,[StockInReason]
                                  ,[StockOutTP]
                                  ,[StockOutDate]
                                  ,[StockOutReason]
                                  ,[Num]
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
            l = DBTool.GetListFromDatatable<StockInfo>(dt);
            return l;
        }
    }
}
