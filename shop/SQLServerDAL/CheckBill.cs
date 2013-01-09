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
    public class CheckBill:ICheckBill
    {
        private void insertCheckDetail(CheckBillBody ckbody, SqlTransaction trans)
        {
            string sql = @"INSERT INTO [CheckBillBody]
                                   ([HeadId]
                                   ,[ProductID]
                                   ,[ProductName]
                                   ,[CategoryID]
                                   ,[Price]
                                   ,[Place]
                                   ,[NowNum]
                                   ,[RealNum])
                             VALUES
                                   (@HeadId
                                   ,@ProductID
                                   ,@ProductName
                                   ,@CategoryID
                                   ,@Price
                                   ,@Place
                                   ,@NowNum
                                   ,@RealNum)";
            SqlParameter[] spvalues = DBTool.GetSqlPm(ckbody);
            SqlHelper.ExecuteNonQuery(trans, CommandType.Text, sql, spvalues);
        }


        /// <summary>
        /// 增加盘点单
        /// </summary>
        /// <param name="changeStock"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        public int InsertCheckBill(CheckBillInfo checkBill, SqlTransaction trans)
        {
            Guid g = Guid.NewGuid();
            checkBill.id = g;
            string sql = @"INSERT INTO [CheckBillHead]
                               ([id]
                               ,[CheckNO]
                               ,[WarehouseID]
                               ,[Cdate]
                               ,[Cuser]
                               ,[detail]
                               ,[IsReview]
                               ,[ReviewUser]
                               ,[InsertDateTime]
                               ,[InsertUser])
                         VALUES
                               (@id
                               ,@CheckNO
                               ,@WarehouseID
                               ,@Cdate
                               ,@Cuser
                               ,@detail
                               ,@IsReview
                               ,@ReviewUser
                               ,@InsertDateTime
                               ,@InsertUser)";
            SqlParameter[] spvalues = DBTool.GetSqlPm(checkBill);
            int res = SqlHelper.ExecuteNonQuery(trans, CommandType.Text, sql, spvalues);
            foreach (CheckBillBody ckb in checkBill.checkBillDetail)
            {
                ckb.HeadId = g;
                insertCheckDetail(ckb, trans);
            }
            return res;
        }
        /// <summary>
        /// 更新盘点单
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public int UpdateCheckBill(CheckBillInfo checkBill,bool changebody, SqlTransaction trans)
        {
            string sql = @"UPDATE [CheckBillHead]
                               SET [CheckNO] = @CheckNO
                                  ,[WarehouseID] = @WarehouseID
                                  ,[Cdate] = @Cdate
                                  ,[Cuser] = @Cuser
                                  ,[detail] = @detail
                                  ,[IsReview] = @IsReview
                                  ,[ReviewUser] = @ReviewUser
                                  ,[UpdateDateTime] = @UpdateDateTime
                                  ,[UpdateUser] = @UpdateUser
                             WHERE id=@id";
            SqlParameter[] spvalues = DBTool.GetSqlPm(checkBill);
            int res = SqlHelper.ExecuteNonQuery(trans, CommandType.Text, sql, spvalues);
            if (changebody)
            {
                DeleteDetail(checkBill.id, trans);
                foreach (CheckBillBody ckb in checkBill.checkBillDetail)
                {
                    insertCheckDetail(ckb, trans);
                }
            }
            return res;
        }
        private void DeleteDetail(Guid headId, SqlTransaction trans)
        {
            string sql = @"DELETE FROM [CheckBillBody] WHERE HeadId=@HeadId";
            SqlParameter sp = new SqlParameter("@HeadId", headId);
            SqlHelper.ExecuteNonQuery(trans, CommandType.Text, sql, sp);
        }

        /// <summary>
        /// 根据分类id删除盘点单
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public int DeleteCheckBill(Guid checkBillId, SqlTransaction trans)
        {
            DeleteDetail(checkBillId, trans);
            string sql = @"DELETE FROM [CheckBillHead] WHERE id=@id";
            SqlParameter sp = new SqlParameter("@id", checkBillId);
            return SqlHelper.ExecuteNonQuery(trans, CommandType.Text, sql, sp);
        }
        /// <summary>
        /// 根据条件获取盘点单
        /// </summary>
        /// <param name="conditon"></param>
        /// <returns></returns>
        public IList<CheckBillInfo> GetCheckBill(IEnumerable<SearchCondition> conditon, SqlConnection conn)
        {
            IList<CheckBillInfo> l = new List<CheckBillInfo>();
            string sql = @"SELECT [id]
                                  ,[CheckNO]
                                  ,[WarehouseID]
                                  ,[Cdate]
                                  ,[Cuser]
                                  ,[detail]
                                  ,[IsReview]
                                  ,[ReviewUser]
                                  ,[InsertDateTime]
                                  ,[InsertUser]
                                  ,[UpdateDateTime]
                                  ,[UpdateUser]
                              FROM [CheckBillHead]";
            if (conditon.Count() > 0)
            {
                string con = DBTool.GetSqlcon(conditon);
                sql += " where " + con;
            }
            SqlParameter[] spvalues = DBTool.GetSqlParam(conditon);
            DataTable dt = SqlHelper.Squery(sql, conn, spvalues);
            l = DBTool.GetListFromDatatable<CheckBillInfo>(dt);
            foreach (CheckBillInfo csi in l)
            {
                csi.checkBillDetail = GetDetail(csi.id, conn);
            }
            return l;
        }

        private IEnumerable<CheckBillBody> GetDetail(Guid headId, SqlConnection conn)
        {
            IList<CheckBillBody> lckbody = new List<CheckBillBody>();
            string sql = @"SELECT 
                              ,[ProductID]
                              ,[ProductName]
                              ,[CategoryID]
                              ,[Price]
                              ,[Place]
                              ,[NowNum]
                              ,[RealNum]
                          FROM [CheckBillBody] where HeadId=@HeadId";
            SqlParameter sp = new SqlParameter("@HeadId", headId);
            DataTable dt = SqlHelper.Squery(sql, conn, sp);
            lckbody = DBTool.GetListFromDatatable<CheckBillBody>(dt);
            return lckbody;
        }
        /// <summary>
        /// 获取满足条件的盘点单数量
        /// </summary>
        /// <param name="conditon"></param>
        /// <returns></returns>
        public int GetCheckBillCount(IEnumerable<SearchCondition> conditon, SqlConnection conn)
        {
            string sql = @"SELECT count(*) as count FROM [CheckBillHead]";
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
        /// 获取指定页的盘点单
        /// </summary>
        /// <param name="conditon"></param>
        /// <param name="page">页数</param>
        /// <param name="pagesize">每页数量</param>
        /// <param name="conn"></param>
        /// <returns></returns>
        public IList<CheckBillInfo> GetPageCheckBill(IEnumerable<SearchCondition> conditon, int page, int pagesize, SqlConnection conn)
        {
            IList<CheckBillInfo> l = new List<CheckBillInfo>();
            string sql = @"SELECT [id]
                                  ,[CheckNO]
                                  ,[WarehouseID]
                                  ,[Cdate]
                                  ,[Cuser]
                                  ,[detail]
                                  ,[IsReview]
                                  ,[ReviewUser]
                                  ,[InsertDateTime]
                                  ,[InsertUser]
                                  ,[UpdateDateTime]
                                  ,[UpdateUser]
                                  ,ROW_NUMBER() over(order by InsertDateTime) as row
                          FROM [CheckBillHead] ";
            if (conditon.Count() > 0)
            {
                string con = DBTool.GetSqlcon(conditon);
                sql += " where " + con;
            }
            sql = "select * from (" + sql + ") as a where row>" + (page - 1) * pagesize + " and row<=" + page * pagesize;
            SqlParameter[] spvalues = DBTool.GetSqlParam(conditon);
            DataTable dt = SqlHelper.Squery(sql, conn, spvalues);
            l = DBTool.GetListFromDatatable<CheckBillInfo>(dt);
            foreach (CheckBillInfo csi in l)
            {
                csi.checkBillDetail = GetDetail(csi.id, conn);
            }
            return l;
        }
    }
}
