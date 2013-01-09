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
    public class ChangeStock:IChangeStock
    {
        /// <summary>
        /// 添加调拨单
        /// </summary>
        /// <param name="changeStock"></param>
        /// <param name="trans"></param>
        /// <returns></returns>
        public int InsertChangeStock(ChangeStockInfo changeStock, SqlTransaction trans)
        {
            Guid g = Guid.NewGuid();
            changeStock.id = g;
            string sql = @"INSERT INTO [ChangeStockHead]
                               ([id]
                               ,[ChangeNO]
                               ,[ChangeDate]
                               ,[ChangeUser]
                               ,[OutWareHouse]
                               ,[InWareHouse]
                               ,[IsReview]
                               ,[ReviewUser]
                               ,[Detail]
                               ,[Define1]
                               ,[Define2]
                               ,[Define3]
                               ,[InsertDateTime]
                               ,[InsertUser])
                         VALUES
                               (@id
                               ,@ChangeNO
                               ,@ChangeDate
                               ,@ChangeUser
                               ,@OutWareHouse
                               ,@InWareHouse
                               ,@IsReview
                               ,@ReviewUser
                               ,@Detail
                               ,@Define1
                               ,@Define2
                               ,@Define3
                               ,@InsertDateTime
                               ,@InsertUser)";
            SqlParameter[] spvalues = DBTool.GetSqlPm(changeStock);
            int res = SqlHelper.ExecuteNonQuery(trans, CommandType.Text, sql, spvalues);
            foreach (ChangeStockBody ckb in changeStock.changeStockDetail)
            {
                ckb.HeadId = g;
                insertChangeStockDetail(ckb,trans);
            }
            return res;
        }

        private void insertChangeStockDetail(ChangeStockBody ckbody, SqlTransaction trans)
        {
            string sql = @"INSERT INTO [ChangeStockBody]
                                   ([HeadId]
                                   ,[ProductID]
                                   ,[Num])
                             VALUES
                                   (@HeadId
                                   ,@ProductID
                                   ,@Num)";
            SqlParameter[] spvalues = DBTool.GetSqlPm(ckbody);
            SqlHelper.ExecuteNonQuery(trans, CommandType.Text, sql, spvalues);
        }

        /// <summary>
        /// 只修改表头
        /// </summary>
        /// <param name="changeStock"></param>
        /// <param name="trans"></param>
        /// <param name="changebody">是否修改表体</param>
        /// <returns></returns>
        public int UpdateChangeStock(ChangeStockInfo changeStock, bool changebody,SqlTransaction trans)
        {
            string sql = @"UPDATE [ChangeStockHead]
                           SET [ChangeNO] = @ChangeNO
                              ,[ChangeDate] = @ChangeDate
                              ,[ChangeUser] = @ChangeUser
                              ,[OutWareHouse] = @OutWareHouse
                              ,[InWareHouse] = @InWareHouse
                              ,[IsReview] = @IsReview
                              ,[ReviewUser] = @ReviewUser
                              ,[Detail] = @Detail
                              ,[Define1] = @Define1
                              ,[Define2] = @Define2
                              ,[Define3] = @Define3
                              ,[UpdateDateTime] = @UpdateDateTime
                              ,[UpdateUser] = @UpdateUser
                         WHERE id=@id";
            SqlParameter[] spvalues = DBTool.GetSqlPm(changeStock);
            int res= SqlHelper.ExecuteNonQuery(trans, CommandType.Text, sql, spvalues);
            if (changebody)
            {
                DeleteChangeStockDetail(changeStock.id, trans);
                foreach (ChangeStockBody ckb in changeStock.changeStockDetail)
                {
                    insertChangeStockDetail(ckb, trans);
                }
            }
            return res;
        }
        /// <summary>
        /// 删除调拨单对应的表体
        /// </summary>
        /// <param name="headId"></param>
        private void DeleteChangeStockDetail(Guid headId,SqlTransaction trans)
        {
            string sql = @"DELETE FROM [ChangeStockBody] WHERE HeadId=@HeadId";
            SqlParameter sp = new SqlParameter("@HeadId",headId);
            SqlHelper.ExecuteNonQuery(trans, CommandType.Text, sql, sp);
        }

        public int DeleteChangeStock(Guid changeStockId, SqlTransaction trans)
        {
            DeleteChangeStockDetail(changeStockId, trans);
            string sql = @"DELETE FROM [ChangeStockHead] WHERE id=@id";
            SqlParameter sp = new SqlParameter("@id",changeStockId);
            return SqlHelper.ExecuteNonQuery(trans, CommandType.Text, sql, sp);
        }

        public IList<ChangeStockInfo> GetChangeStock(IEnumerable<SearchCondition> conditon, SqlConnection conn)
        {
            IList<ChangeStockInfo> lchangestock = new List<ChangeStockInfo>();
            string sql = @"SELECT [id]
                                  ,[ChangeNO]
                                  ,[ChangeDate]
                                  ,[ChangeUser]
                                  ,[OutWareHouse]
                                  ,[InWareHouse]
                                  ,[IsReview]
                                  ,[ReviewUser]
                                  ,[Detail]
                                  ,[Define1]
                                  ,[Define2]
                                  ,[Define3]
                                  ,[InsertDateTime]
                                  ,[InsertUser]
                                  ,[UpdateDateTime]
                                  ,[UpdateUser]
                              FROM [ChangeStockHead]";
            if (conditon.Count() > 0)
            {
                string con = DBTool.GetSqlcon(conditon);
                sql += " where " + con;
            }
            SqlParameter[] spvalues = DBTool.GetSqlParam(conditon);
            DataTable dt = SqlHelper.Squery(sql, conn, spvalues);
            lchangestock = DBTool.GetListFromDatatable<ChangeStockInfo>(dt);
            foreach (ChangeStockInfo csi in lchangestock)
            {
                csi.changeStockDetail = GetChangeStockDetail(csi.id, conn);
            }
            return lchangestock;
        }
        private IEnumerable<ChangeStockBody> GetChangeStockDetail(Guid headId,SqlConnection conn)
        {
            IList<ChangeStockBody> lckbody=new List<ChangeStockBody>();
            string sql = @"SELECT [HeadId]
                                  ,[ProductID]
                                  ,[Num]
                              FROM [ChangeStockBody] where HeadId=@HeadId";
            SqlParameter sp = new SqlParameter("@HeadId",headId);
            DataTable dt = SqlHelper.Squery(sql, conn, sp);
            lckbody = DBTool.GetListFromDatatable<ChangeStockBody>(dt);
            return lckbody;
        }
        public IList<ChangeStockInfo> GetPageChangeStock(IEnumerable<SearchCondition> conditon, int page, int pagesize, SqlConnection conn)
        {
            IList<ChangeStockInfo> lchangestock = new List<ChangeStockInfo>();
            string sql = @"SELECT [id]
                                  ,[ChangeNO]
                                  ,[ChangeDate]
                                  ,[ChangeUser]
                                  ,[OutWareHouse]
                                  ,[InWareHouse]
                                  ,[IsReview]
                                  ,[ReviewUser]
                                  ,[Detail]
                                  ,[Define1]
                                  ,[Define2]
                                  ,[Define3]
                                  ,[InsertDateTime]
                                  ,[InsertUser]
                                  ,[UpdateDateTime]
                                  ,[UpdateUser]
                              ,ROW_NUMBER() over(order by InsertDateTime) as row
                          FROM [ChangeStockHead] ";
            if (conditon.Count() > 0)
            {
                string con = DBTool.GetSqlcon(conditon);
                sql += " where " + con;
            }
            sql = "select * from (" + sql + ") as a where row>" + (page - 1) * pagesize + " and row<=" + page * pagesize;
            SqlParameter[] spvalues = DBTool.GetSqlParam(conditon);
            DataTable dt = SqlHelper.Squery(sql, conn, spvalues);
            lchangestock = DBTool.GetListFromDatatable<ChangeStockInfo>(dt);
            foreach (ChangeStockInfo csi in lchangestock)
            {
                csi.changeStockDetail = GetChangeStockDetail(csi.id, conn);
            }
            return lchangestock;
        }

        public int GetChangeStockCount(IEnumerable<SearchCondition> conditon, SqlConnection conn)
        {
            string sql = @"SELECT count(*) as count FROM [ChangeStockHead]";
            if (conditon.Count() > 0)
            {
                string con = DBTool.GetSqlcon(conditon);
                sql += " where " + con;
            }
            SqlParameter[] spvalues = DBTool.GetSqlParam(conditon);
            int count = (int)SqlHelper.ExecuteScalar(conn, CommandType.Text, sql, spvalues);
            return count;
        }

    }
}
