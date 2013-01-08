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
            return 0;
        }

    }
}
