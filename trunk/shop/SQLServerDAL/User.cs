using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IDAL;
using Model;
using System.Data.SqlClient;
using DBUtility;
using System.Data;

namespace SQLServerDAL
{
    public class User:IUser
    {
        //void addUser(SqlConnection sconn, UserInfo userinfo);
        //void updateUser(SqlConnection sconn, UserInfo userinfo);
        //UserInfo getUser(SqlConnection sconn, string userid, string password);
        //UserInfo getUserById(SqlConnection sconn, int id);
        //void deleteUser(SqlConnection sconn, int id);
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="sconn">数据库连接</param>
        /// <param name="userinfo">用户信息</param>
        public void addUser(SqlConnection sconn, UserInfo userinfo)
        {
            try
            {
                string sql = @"insert into user(
                                                UserID,
                                                Password,
                                                CampanyName,
                                                UserName,
                                                Email,
                                                InsertDateTime
                                            ) values(
                                                @UserID,
                                                @Password,
                                                @CampanyName,
                                                @UserName,
                                                @Email,
                                                @InsertDateTime
                                            )";
                SqlParameter[] spvalues = DBTool.GetSqlPm(userinfo);
                SqlHelper.ExecuteNonQuery(sconn, CommandType.Text, sql, spvalues);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void updateUser(SqlConnection sconn, UserInfo userinfo)
        {
            string sql = @"UPDATE [ShopManage].[dbo].[User]
                            SET [UserID] = @UserID
                               ,[Password] = @Password
                               ,[UserName] = @UserName
                               ,[CampanyName] = @CampanyName
                               ,[Email] = @Email
                               ,[UpdateDateTime] = @UpdateDateTime
                               ,[UpdatetUser] = @UpdatetUser
                            WHERE id=@id";
            try
            {
                SqlParameter[] spvalues = DBTool.GetSqlPm(userinfo);
                SqlHelper.ExecuteNonQuery(sconn, CommandType.Text, sql, spvalues);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
