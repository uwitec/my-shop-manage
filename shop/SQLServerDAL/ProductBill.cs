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
    public class ProductBill:IProductBill
    {
        private void InsertDetail(ProductBillBody ckbody, SqlTransaction trans)
        {
            string sql = @"INSERT INTO [ProductBillBody]
                                   ([HeadId]
                                   ,[ProductID]
                                   ,[BuyPrice]
                                   ,[Num])
                             VALUES
                                   (@HeadId
                                   ,@ProductID
                                   ,@BuyPrice
                                   ,@Num)";
            SqlParameter[] spvalues = DBTool.GetSqlPm(ckbody);
            SqlHelper.ExecuteNonQuery(trans, CommandType.Text, sql, spvalues);
        }


        /// <summary>
        /// 增加采购单
        /// </summary>
        /// <param name="changeStock"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        public int InsertProductBill(ProductBillInfo productBill, SqlTransaction trans)
        {
            Guid g = Guid.NewGuid();
            productBill.id = g;
            string sql = @"INSERT INTO [ProductBillHead]
                                   ([id]
                                   ,[BuyNO]
                                   ,[BatchNO]
                                   ,[BuyDate]
                                   ,[SupplyID]
                                   ,[IsReview]
                                   ,[ReviewUser]
                                   ,[WareHouseID]
                                   ,[Detail]
                                   ,[Define1]
                                   ,[Define2]
                                   ,[Define3]
                                   ,[InsertDateTime]
                                   ,[InsertUser])
                             VALUES
                                   (@id
                                   ,@BuyNO
                                   ,@BatchNO
                                   ,@BuyDate
                                   ,@SupplyID
                                   ,@IsReview
                                   ,@ReviewUser
                                   ,@WareHouseID
                                   ,@Detail
                                   ,@Define1
                                   ,@Define2
                                   ,@Define3
                                   ,@InsertDateTime
                                   ,@InsertUser)";
            SqlParameter[] spvalues = DBTool.GetSqlPm(productBill);
            int res = SqlHelper.ExecuteNonQuery(trans, CommandType.Text, sql, spvalues);
            foreach (ProductBillBody ckb in productBill.BillDetail)
            {
                ckb.HeadId = g;
                InsertDetail(ckb, trans);
            }
            return res;
        }
        /// <summary>
        /// 更新采购单
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public int UpdateProductBill(ProductBillInfo productBill, bool changebody, SqlTransaction trans)
        {
            string sql = @"UPDATE [ProductBillHead]
                           SET [BuyNO] = @BuyNO
                              ,[BatchNO] = @BatchNO
                              ,[BuyDate] = @BuyDate
                              ,[SupplyID] = @SupplyID
                              ,[IsReview] = @IsReview
                              ,[ReviewUser] = @ReviewUser
                              ,[WareHouseID] = @WareHouseID
                              ,[Detail] = @Detail
                              ,[Define1] = @Define1
                              ,[Define2] = @Define2
                              ,[Define3] = @Define3
                              ,[UpdateDateTime] = @UpdateDateTime
                              ,[UpdateUser] = @UpdateUser
                         WHERE id=@id";
            SqlParameter[] spvalues = DBTool.GetSqlPm(productBill);
            int res = SqlHelper.ExecuteNonQuery(trans, CommandType.Text, sql, spvalues);
            if (changebody)
            {
                DeleteDetail(productBill.id, trans);
                foreach (ProductBillBody ckb in productBill.BillDetail)
                {
                    InsertDetail(ckb, trans);
                }
            }
            return res;
        }
        private void DeleteDetail(Guid headId, SqlTransaction trans)
        {
            string sql = @"DELETE FROM [ProductBillBody] WHERE HeadId=@HeadId";
            SqlParameter sp = new SqlParameter("@HeadId", headId);
            SqlHelper.ExecuteNonQuery(trans, CommandType.Text, sql, sp);
        }

        /// <summary>
        /// 根据分类id删除采购单
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public int DeleteProductBill(Guid productId, SqlTransaction trans)
        {
            DeleteDetail(productId, trans);
            string sql = @"DELETE FROM [ProductBillHead] WHERE id=@id";
            SqlParameter sp = new SqlParameter("@id", productId);
            return SqlHelper.ExecuteNonQuery(trans, CommandType.Text, sql, sp);
        }
        /// <summary>
        /// 根据条件获取采购单
        /// </summary>
        /// <param name="conditon"></param>
        /// <returns></returns>
        public IList<ProductBillInfo> GetProductBill(IEnumerable<SearchCondition> conditon, SqlConnection conn)
        {
            IList<ProductBillInfo> l = new List<ProductBillInfo>();
            string sql = @"SELECT [id]
                                  ,[BuyNO]
                                  ,[BatchNO]
                                  ,[BuyDate]
                                  ,[SupplyID]
                                  ,[IsReview]
                                  ,[ReviewUser]
                                  ,[WareHouseID]
                                  ,[Detail]
                                  ,[Define1]
                                  ,[Define2]
                                  ,[Define3]
                                  ,[InsertDateTime]
                                  ,[InsertUser]
                                  ,[UpdateDateTime]
                                  ,[UpdateUser]
                              FROM [ProductBillHead]";
            if (conditon.Count() > 0)
            {
                string con = DBTool.GetSqlcon(conditon);
                sql += " where " + con;
            }
            SqlParameter[] spvalues = DBTool.GetSqlParam(conditon);
            DataTable dt = SqlHelper.Squery(sql, conn, spvalues);
            l = DBTool.GetListFromDatatable<ProductBillInfo>(dt);
            foreach (ProductBillInfo csi in l)
            {
                csi.BillDetail = GetDetail(csi.id, conn);
            }
            return l;
        }

        private IEnumerable<ProductBillBody> GetDetail(Guid headId, SqlConnection conn)
        {
            IList<ProductBillBody> lckbody = new List<ProductBillBody>();
            string sql = @"SELECT [HeadId]
                                  ,[ProductID]
                                  ,[BuyPrice]
                                  ,[Num]
                              FROM [ProductBillBody] where HeadId=@HeadId";
            SqlParameter sp = new SqlParameter("@HeadId", headId);
            DataTable dt = SqlHelper.Squery(sql, conn, sp);
            lckbody = DBTool.GetListFromDatatable<ProductBillBody>(dt);
            return lckbody;
        }
        /// <summary>
        /// 获取满足条件的采购单数量
        /// </summary>
        /// <param name="conditon"></param>
        /// <returns></returns>
        public int GetProductBillCount(IEnumerable<SearchCondition> conditon, SqlConnection conn)
        {
            string sql = @"SELECT count(*) as count FROM [ProductBillHead]";
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
        /// 获取指定页的采购单
        /// </summary>
        /// <param name="conditon"></param>
        /// <param name="page">页数</param>
        /// <param name="pagesize">每页数量</param>
        /// <param name="conn"></param>
        /// <returns></returns>
        public IList<ProductBillInfo> GetPageProductBill(IEnumerable<SearchCondition> conditon, int page, int pagesize, SqlConnection conn)
        {
            IList<ProductBillInfo> l = new List<ProductBillInfo>();
            string sql = @"SELECT [id]
                                  ,[BuyNO]
                                  ,[BatchNO]
                                  ,[BuyDate]
                                  ,[SupplyID]
                                  ,[IsReview]
                                  ,[ReviewUser]
                                  ,[WareHouseID]
                                  ,[Detail]
                                  ,[Define1]
                                  ,[Define2]
                                  ,[Define3]
                                  ,[InsertDateTime]
                                  ,[InsertUser]
                                  ,[UpdateDateTime]
                                  ,[UpdateUser]
                                  ,ROW_NUMBER() over(order by InsertDateTime) as row
                          FROM [ProductBillHead] ";
            if (conditon.Count() > 0)
            {
                string con = DBTool.GetSqlcon(conditon);
                sql += " where " + con;
            }
            sql = "select * from (" + sql + ") as a where row>" + (page - 1) * pagesize + " and row<=" + page * pagesize;
            SqlParameter[] spvalues = DBTool.GetSqlParam(conditon);
            DataTable dt = SqlHelper.Squery(sql, conn, spvalues);
            l = DBTool.GetListFromDatatable<ProductBillInfo>(dt);
            foreach (ProductBillInfo csi in l)
            {
                csi.BillDetail = GetDetail(csi.id, conn);
            }
            return l;
        }
    }
}
