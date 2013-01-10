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
    public class StockIn:IStockIn
    {
        private void InsertDetail(StockInBody ckbody, SqlTransaction trans)
        {
            string sql = @"INSERT INTO [StockInBody]
                                   ([HeadId]
                                   ,[ProductID]
                                   ,[ProductName]
                                   ,[CategoryID]
                                   ,[Price]
                                   ,[Num])
                             VALUES
                                   (@HeadId
                                   ,@ProductID
                                   ,@ProductName
                                   ,@CategoryID
                                   ,@Price
                                   ,@Num)";
            SqlParameter[] spvalues = DBTool.GetSqlPm(ckbody);
            SqlHelper.ExecuteNonQuery(trans, CommandType.Text, sql, spvalues);
        }


        /// <summary>
        /// 增加入库单
        /// </summary>
        /// <param name="changeStock"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        public int InsertStockIn(StockInInfo stockIn, SqlTransaction trans)
        {
            Guid g = Guid.NewGuid();
            stockIn.id = g;
            string sql = @"INSERT INTO [StockInHead]
                                   ([StockInNO]
                                   ,[WarehouseID]
                                   ,[StockInTP]
                                   ,[StockInDate]
                                   ,[StockInReason]
                                   ,[SupplierID]
                                   ,[InsertDateTime]
                                   ,[InsertUser])
                             VALUES
                                   (@StockInNO
                                   ,@WarehouseID
                                   ,@StockInTP
                                   ,@StockInDate
                                   ,@StockInReason
                                   ,@SupplierID
                                   ,@InsertDateTime
                                   ,@InsertUser)";
            SqlParameter[] spvalues = DBTool.GetSqlPm(stockIn);
            int res = SqlHelper.ExecuteNonQuery(trans, CommandType.Text, sql, spvalues);
            foreach (StockInBody ckb in stockIn.stockInDetail)
            {
                ckb.HeadId = g;
                InsertDetail(ckb, trans);
            }
            return res;
        }
        /// <summary>
        /// 更新入库单
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public int UpdateStockIn(StockInInfo stockIn, bool changebody, SqlTransaction trans)
        {
            string sql = @"UPDATE [StockInHead]
                           SET [StockInNO] = @StockInNO
                              ,[WarehouseID] = @WarehouseID
                              ,[StockInTP] = @StockInTP
                              ,[StockInDate] = @StockInDate
                              ,[StockInReason] = @StockInReason
                              ,[SupplierID] = @SupplierID
                              ,[InsertDateTime] = @InsertDateTime
                              ,[InsertUser] = @InsertUser
                              ,[UpdateDateTime] = @UpdateDateTime
                              ,[UpdateUser] = @UpdateUser
                         WHERE id=@id";
            SqlParameter[] spvalues = DBTool.GetSqlPm(stockIn);
            int res = SqlHelper.ExecuteNonQuery(trans, CommandType.Text, sql, spvalues);
            if (changebody)
            {
                DeleteDetail(stockIn.id, trans);
                foreach (StockInBody ckb in stockIn.stockInDetail)
                {
                    InsertDetail(ckb, trans);
                }
            }
            return res;
        }
        private void DeleteDetail(Guid headId, SqlTransaction trans)
        {
            string sql = @"DELETE FROM [StockInBody] WHERE HeadId=@HeadId";
            SqlParameter sp = new SqlParameter("@HeadId", headId);
            SqlHelper.ExecuteNonQuery(trans, CommandType.Text, sql, sp);
        }

        /// <summary>
        /// 根据id删除入库单
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public int DeleteStockIn(Guid stockInId, SqlTransaction trans)
        {
            DeleteDetail(stockInId, trans);
            string sql = @"DELETE FROM [StockInHead] WHERE id=@id";
            SqlParameter sp = new SqlParameter("@id", stockInId);
            return SqlHelper.ExecuteNonQuery(trans, CommandType.Text, sql, sp);
        }
        /// <summary>
        /// 根据条件获取入库单
        /// </summary>
        /// <param name="conditon"></param>
        /// <returns></returns>
        public IList<StockInInfo> GetStockIn(IEnumerable<SearchCondition> conditon, SqlConnection conn)
        {
            IList<StockInInfo> l = new List<StockInInfo>();
            string sql = @"SELECT [id]
                                  ,[StockInNO]
                                  ,[WarehouseID]
                                  ,[StockInTP]
                                  ,[StockInDate]
                                  ,[StockInReason]
                                  ,[SupplierID]
                                  ,[InsertDateTime]
                                  ,[InsertUser]
                                  ,[UpdateDateTime]
                                  ,[UpdateUser]
                              FROM [StockInHead]";
            if (conditon.Count() > 0)
            {
                string con = DBTool.GetSqlcon(conditon);
                sql += " where " + con;
            }
            SqlParameter[] spvalues = DBTool.GetSqlParam(conditon);
            DataTable dt = SqlHelper.Squery(sql, conn, spvalues);
            l = DBTool.GetListFromDatatable<StockInInfo>(dt);
            foreach (StockInInfo csi in l)
            {
                csi.stockInDetail = GetDetail(csi.id, conn);
            }
            return l;
        }

        private IEnumerable<StockInBody> GetDetail(Guid headId, SqlConnection conn)
        {
            IList<StockInBody> lckbody = new List<StockInBody>();
            string sql = @"SELECT [HeadId]
                                  ,[ProductID]
                                  ,[ProductName]
                                  ,[CategoryID]
                                  ,[Price]
                                  ,[Num]
                              FROM [StockInBody] where HeadId=@HeadId";
            SqlParameter sp = new SqlParameter("@HeadId", headId);
            DataTable dt = SqlHelper.Squery(sql, conn, sp);
            lckbody = DBTool.GetListFromDatatable<StockInBody>(dt);
            return lckbody;
        }
        /// <summary>
        /// 获取满足条件的入库单数量
        /// </summary>
        /// <param name="conditon"></param>
        /// <returns></returns>
        public int GetStockInCount(IEnumerable<SearchCondition> conditon, SqlConnection conn)
        {
            string sql = @"SELECT count(*) as count FROM [StockInHead]";
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
        /// 获取指定页的入库单
        /// </summary>
        /// <param name="conditon"></param>
        /// <param name="page">页数</param>
        /// <param name="pagesize">每页数量</param>
        /// <param name="conn"></param>
        /// <returns></returns>
        public IList<StockInInfo> GetPageStockIn(IEnumerable<SearchCondition> conditon, int page, int pagesize, SqlConnection conn)
        {
            IList<StockInInfo> l = new List<StockInInfo>();
            string sql = @"SELECT [id]
                                  ,[StockInNO]
                                  ,[WarehouseID]
                                  ,[StockInTP]
                                  ,[StockInDate]
                                  ,[StockInReason]
                                  ,[SupplierID]
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
            l = DBTool.GetListFromDatatable<StockInInfo>(dt);
            foreach (StockInInfo csi in l)
            {
                csi.stockInDetail = GetDetail(csi.id, conn);
            }
            return l;
        }
    }
}
