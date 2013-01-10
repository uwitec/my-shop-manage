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
    public class Product:IProduct
    {
        public int InsertProduct(ProductInfo product, SqlTransaction trans)
        {
            string sql = @"INSERT INTO [Product]
                                   ([ProductNO]
                                   ,[ProductName]
                                   ,[CategoryID]
                                   ,[ProductSKU]
                                   ,[ProductDetail]
                                   ,[Price]
                                   ,[SailPrice]
                                   ,[Place]
                                   ,[SaveTime]
                                   ,[Define1]
                                   ,[Define2]
                                   ,[Define3]
                                   ,[InsertDateTime]
                                   ,[InsertUser])
                             VALUES
                                   (@ProductNO
                                   ,@ProductName
                                   ,@CategoryID
                                   ,@ProductSKU
                                   ,@ProductDetail
                                   ,@Price
                                   ,@SailPrice
                                   ,@Place
                                   ,@SaveTime
                                   ,@Define1
                                   ,@Define2
                                   ,@Define3
                                   ,@InsertDateTime
                                   ,@InsertUser)";
            SqlParameter[] spvalues = DBTool.GetSqlPm(product);
            return SqlHelper.ExecuteNonQuery(trans, System.Data.CommandType.Text, sql, spvalues);
        }

        public int UpdateProduct(ProductInfo product, SqlTransaction trans)
        {
            string sql = @"UPDATE [Product]
                               SET [ProductNO] = @ProductNO
                                  ,[ProductName] = @ProductName
                                  ,[CategoryID] = @CategoryID
                                  ,[ProductSKU] = @ProductSKU
                                  ,[ProductDetail] = @ProductDetail
                                  ,[Price] = @Price
                                  ,[SailPrice] = @SailPrice
                                  ,[Place] = @Place
                                  ,[SaveTime] = @SaveTime
                                  ,[Define1] = @Define1
                                  ,[Define2] = @Define2
                                  ,[Define3] = @Define3
                                  ,[UpdateDateTime] = @UpdateDateTime
                                  ,[UpdateUser] = @UpdateUser
                             WHERE id=@id";
            SqlParameter[] spvalues = DBTool.GetSqlPm(product);
            return SqlHelper.ExecuteNonQuery(trans, System.Data.CommandType.Text, sql, spvalues);
        }

        public int DeleteProduct(Guid productId, SqlTransaction trans)
        {
            string sql = "DELETE FROM [Product] WHERE id=@id";
            SqlParameter val = new SqlParameter("@id", productId);
            return SqlHelper.ExecuteNonQuery(trans, System.Data.CommandType.Text, sql, val);
        }

        public IList<ProductInfo> GetProduct(IEnumerable<SearchCondition> conditon, SqlConnection conn)
        {
            IList<ProductInfo> l = new List<ProductInfo>();
            string sql = @"SELECT [id]
                                  ,[ProductNO]
                                  ,[ProductName]
                                  ,[CategoryID]
                                  ,[ProductSKU]
                                  ,[ProductDetail]
                                  ,[Price]
                                  ,[SailPrice]
                                  ,[Place]
                                  ,[SaveTime]
                                  ,[Define1]
                                  ,[Define2]
                                  ,[Define3]
                                  ,[InsertDateTime]
                                  ,[InsertUser]
                                  ,[UpdateDateTime]
                                  ,[UpdateUser]
                              FROM [Product]";
            if (conditon.Count() > 0)
            {
                string con = DBTool.GetSqlcon(conditon);
                sql += " where " + con;
            }
            SqlParameter[] spvalues = DBTool.GetSqlParam(conditon);
            DataTable dt = SqlHelper.Squery(sql, conn, spvalues);
            l = DBTool.GetListFromDatatable<ProductInfo>(dt);
            return l;
        }

        public int GetProductCount(IEnumerable<SearchCondition> conditon, SqlConnection conn)
        {
            string sql = @"SELECT count(*) as count FROM [Product]";
            if (conditon.Count() > 0)
            {
                string con = DBTool.GetSqlcon(conditon);
                sql += " where " + con;
            }
            SqlParameter[] spvalues = DBTool.GetSqlParam(conditon);
            int count = (int)SqlHelper.ExecuteScalar(conn, CommandType.Text, sql, spvalues);
            return count;
        }

        public IList<ProductInfo> GetPageProduct(IEnumerable<SearchCondition> conditon, int page, int pagesize, SqlConnection conn)
        {
            IList<ProductInfo> l = new List<ProductInfo>();
            string sql = @"SELECT [id]
                                  ,[ProductNO]
                                  ,[ProductName]
                                  ,[CategoryID]
                                  ,[ProductSKU]
                                  ,[ProductDetail]
                                  ,[Price]
                                  ,[SailPrice]
                                  ,[Place]
                                  ,[SaveTime]
                                  ,[Define1]
                                  ,[Define2]
                                  ,[Define3]
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
            l = DBTool.GetListFromDatatable<ProductInfo>(dt);
            return l;
        }
    }
}
