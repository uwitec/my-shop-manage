using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data.SqlClient;
namespace IDAL
{
    public interface IUser
    {
        void addUser(SqlConnection sconn,UserInfo userinfo);
        void updateUser(SqlConnection sconn, UserInfo userinfo);
        UserInfo getUser(SqlConnection sconn, string userid, string password);
        UserInfo getUserById(SqlConnection sconn, int id);
        void deleteUser(SqlConnection sconn,int id);
    }
}
