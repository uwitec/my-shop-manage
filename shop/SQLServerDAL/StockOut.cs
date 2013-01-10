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
    public class StockOut:IStockOut
    {
        private void InsertDetail(StockOutBody ckbody, SqlTransaction trans)
        {
            string sql = @"INSERT INTO [StockOutBody]
                                   ([HeadId]
                                   ,[ProductID]
                                   ,[ProductName]
                                   ,[CategoryID]
                                   ,[Price]
                                   ,[Place]
                                   ,[Num])
                             VALUES
                                   (@HeadId
                                   ,@ProductID
                                   ,@ProductName
                                   ,@CategoryID
                                   ,@Price
                                   ,@Place
                                   ,@Num)";
            SqlParameter[] spvalues = DBTool.GetSqlPm(ckbody);
            SqlHelper.ExecuteNonQuery(trans, CommandType.Text, sql, spvalues);
        }


        /// <summary>
        /// 增加出库单
        /// </summary>
        /// <param name="changeStock"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        public int InsertStockOut(StockOutInfo stockOut, SqlTransaction trans)
        {
            Guid g = Guid.NewGuid();
            stockOut.id = g;
            string sql = @"INSERT INTO [StockOutHead]
                                   ([id]
                                   ,[StockInNO]
                                   ,[WarehouseID]
                                   ,[StockOutTP]
                                   ,[StockOutDate]
                                   ,[StockOutReason]
                                   ,[InsertDateTime]
                                   ,[InsertUser])
                             VALUES
                                   (@id
                                   ,@StockInNO
                                   ,@WarehouseID
                                   ,@StockOutTP
                                   ,@StockOutDate
                                   ,@StockOutReason
                                   ,@InsertDateTime
                                   ,@InsertUser)";
            SqlParameter[] spvalues = DBTool.GetSqlPm(stockOut);
            int res = SqlHelper.ExecuteNonQuery(trans, CommandType.Text, sql, spvalues);
            foreach (StockOutBody ckb in stockOut.stockOutDetail)
            {
                ckb.HeadId = g;
                InsertDetail(ckb, trans);
            }
            return res;
        }
        /// <summary>
        /// 更新出库单
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public int UpdateStockOut(StockOutInfo stockOut, bool changebody, SqlTransaction trans)
        {
            string sql = @"UPDATE [StockOutHead]
                           SET [StockInNO] = @StockInNO
                              ,[WarehouseID] = @WarehouseID
                              ,[StockOutTP] = @StockOutTP
                              ,[StockOutDate] = @StockOutDate
                              ,[StockOutReason] = @StockOutReason
                              ,[InsertDateTime] = @InsertDateTime
                              ,[InsertUser] = @InsertUser
                              ,[UpdateDateTime] = @UpdateDateTime
                              ,[UpdateUser] = @UpdateUser
                         WHERE id=@id";
            SqlParameter[] spvalues = DBTool.GetSqlPm(stockOut);
            int res = SqlHelper.ExecuteNonQuery(trans, CommandType.Text, sql, spvalues);
            if (changebody)
            {
                DeleteDetail(stockOut.id, trans);
                foreach (StockOutBody ckb in stockOut.stockOutDetail)
                {
                    InsertDetail(ckb, trans);
                }
            }
            return res;
        }
        private void DeleteDetail(Guid headId, SqlTransaction trans)
        {
            string sql = @"DELETE FROM [StockOutBody] WHERE HeadId=@HeadId";
            SqlParameter sp = new SqlParameter("@HeadId", headId);
            SqlHelper.ExecuteNonQuery(trans, CommandType.Text, sql, sp);
        }

        /// <summary>
        /// 根据id删除出库单
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public int DeleteStockOut(Guid stockOutId, SqlTransaction trans)
        {
            DeleteDetail(stockOutId, trans);
            string sql = @"DELETE FROM [StockOutHead] WHERE id=@id";
            SqlParameter sp = new SqlParameter("@id", stockOutId);
            return SqlHelper.ExecuteNonQuery(trans, CommandType.Text, sql, sp);
        }
        /// <summary>
        /// 根据条件获取出库单
        /// </summary>
        /// <param name="conditon"></param>
        /// <returns></returns>
        public IList<StockOutInfo> GetStockOut(IEnumerable<SearchCondition> conditon, SqlConnection conn)
        {
            IList<StockOutInfo> l = new List<StockOutInfo>();
            string sql = @"SELECT [id]
                                  ,[StockOutNO]
                                  ,[WarehouseID]
                                  ,[StockOutTP]
                                  ,[StockOutDate]
                                  ,[StockOutReason]
                                  ,[InsertDateTime]
                                  ,[InsertUser]
                                  ,[UpdateDateTime]
                                  ,[UpdateUser]
                              FROM [StockOutHead]";
            if (conditon.Count() > 0)
            {
                string con = DBTool.GetSqlcon(conditon);
                sql += " where " + con;
            }
            SqlParameter[] spvalues = DBTool.GetSqlParam(conditon);
            DataTable dt = SqlHelper.Squery(sql, conn, spvalues);
            l = DBTool.GetListFromDatatable<StockOutInfo>(dt);
            foreach (StockOutInfo csi in l)
            {
                csi.stockOutDetail = GetDetail(csi.id, conn);
            }
            return l;
        }

        private IEnumerable<StockOutBody> GetDetail(Guid headId, SqlConnection conn)
        {
            IList<StockOutBody> lckbody = new List<StockOutBody>();
            string sql = @"SELECT [HeadId]
                                  ,[ProductID]
                                  ,[ProductName]
                                  ,[CategoryID]
                                  ,[Price]
                                  ,[Place]
                                  ,[Num]
                              FROM [StockOutBody] where HeadId=@HeadId";
            SqlParameter sp = new SqlParameter("@HeadId", headId);
            DataTable dt = SqlHelper.Squery(sql, conn, sp);
            lckbody = DBTool.GetListFromDatatable<StockOutBody>(dt);
            return lckbody;
        }
        /// <summary>
        /// 获取满足条件的出库单数量
        /// </summary>
        /// <param name="conditon"></param>
        /// <returns></returns>
        public int GetStockOutCount(IEnumerable<SearchCondition> conditon, SqlConnection conn)
        {
            string sql = @"SELECT count(*) as count FROM [StockOutHead]";
            if (conditon.Count() > 0)
            {
                string con = DBTool.GetSqlcon(conditon);
                sql += " where " + con;
            }
            SqlParameter[] spvalues = DBTool.GetSqlParam(conditon);
            int count = (int)SqlHelper.ExecuteScalar(conn, CommandType.Text, sql, spvalues);
            return count;
        }
        /// <summary>
        /// 获取指定页的出库单
        /// </summary>
        /// <param name="conditon"></param>
        /// <param name="page">页数</param>
        /// <param name="pagesize">每页数量</param>
        /// <param name="conn"></param>
        /// <returns></returns>
        public IList<StockOutInfo> GetPageStockOut(IEnumerable<SearchCondition> conditon, int page, int pagesize, SqlConnection conn)
        {
            IList<StockOutInfo> l = new List<StockOutInfo>();
            string sql = @"SELECT [id]
                                  ,[StockOutNO]
                                  ,[WarehouseID]
                                  ,[StockOutTP]
                                  ,[StockOutDate]
                                  ,[StockOutReason]
                                  ,[InsertDateTime]
                                  ,[InsertUser]
                                  ,[UpdateDateTime]
                                  ,[UpdateUser]
                                  ,ROW_NUMBER() over(order by InsertDateTime) as row
                          FROM [StockInHead] ";
            if (conditon.Count() > 0)
            {
                string con = DBTool.GetSqlcon(conditon);
                sql += " where " + con;
            }
            sql = "select * from (" + sql + ") as a where row>" + (page - 1) * pagesize + " and row<=" + page * pagesize;
            SqlParameter[] spvalues = DBTool.GetSqlParam(conditon);
            DataTable dt = SqlHelper.Squery(sql, conn, spvalues);
            l = DBTool.GetListFromDatatable<StockOutInfo>(dt);
            foreach (StockOutInfo csi in l)
            {
                csi.stockOutDetail = GetDetail(csi.id, conn);
            }
            return l;
        }
    }
}
