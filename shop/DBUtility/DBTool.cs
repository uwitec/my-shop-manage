using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Reflection;
using System.Data;
using Common;

namespace DBUtility
{
    public class DBTool
    {
        /// <summary>
        /// 将datatable转化成对应的对象列表 shr 2012/02/28
        /// </summary>
        /// <typeparam name="T">列表类型</typeparam>
        /// <param name="dt">数据</param>
        /// <returns></returns>
        public static List<T> GetListFromDatatable<T>(DataTable dt)
        {
            //创建对象列表
            List<T> lobj = new List<T>();
            //获取属性
            PropertyInfo[] pifarr = typeof(T).GetProperties();
            //赋值
            foreach (DataRow dr in dt.Rows)
            {
                T ct = (T)(typeof(T).Assembly.CreateInstance(typeof(T).FullName));
                foreach (PropertyInfo pi in pifarr)
                {
                    if (dt.Columns.Contains(pi.Name))
                    {
                        //判断是否可写
                        if (pi.CanWrite)
                        {
                            //pi.SetValue(ct, dr[pi.Name], null);
                            pi.SetValue(ct, Convert.ChangeType(dr[pi.Name] == null ? "" : dr[pi.Name].ToString().Trim(), pi.PropertyType), null);
                        }
                    }
                }
                lobj.Add(ct);
            }
            return lobj;
        }
        /// <summary>
        /// 根据传入的类型，生成sql语句里面的条件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public static SqlParameter[] GetSqlPm<T>(T it)
        {
            //获取对象的所有属性数组
            PropertyInfo[] pinfo = typeof(T).GetProperties();
            SqlParameter[] sparr = new SqlParameter[pinfo.Length];
            for (int i = 0; i < pinfo.Length; i++)
            {
                SqlParameter sp = new SqlParameter();
                sp.ParameterName = "@" + pinfo[i].Name;
                sp.Value = SqlNull(pinfo[i].GetValue(it, null));
                sparr[i] = sp;
            }
            return sparr;
        }

        public static object SqlNull(object obj)
        {
            if (obj == null)
                return DBNull.Value;
            return obj;
        }


        /// <summary>
        /// 获取sql条件字符串
        /// </summary>
        /// <param name="lcon">条件列表</param>
        /// <returns>sql条件字符串</returns>
        public static string GetSqlcon(IEnumerable<SearchCondition> lcon)
        {
            try
            {
                string sqlcon = "";
                foreach (SearchCondition sc in lcon)
                {
                    sqlcon += " " + sc.con;
                }
                return sqlcon;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 获取参数
        /// </summary>
        /// <param name="?"></param>
        /// <returns></returns>
        public static SqlParameter[] GetSqlParam(IEnumerable<SearchCondition> lcon)
        {
            try
            {
                SqlParameter[] sqlarr = new SqlParameter[lcon.ToArray().Length];
                int i = 0;
                foreach (SearchCondition sc in lcon)
                {
                    sqlarr[i] = new SqlParameter(sc.param, SqlNull(sc.value));
                    i++;
                }
                return sqlarr;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}