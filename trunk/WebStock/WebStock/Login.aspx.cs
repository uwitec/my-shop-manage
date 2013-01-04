using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebStock
{
    public partial class Login : System.Web.UI.Page
    {
        public string LogType
        {
            get
            {
                var logtype = Request.QueryString["type"];
                if (logtype != null)
                    return logtype.ToString();
                return "";
            }
        }
        //WebStock.BLL.Manager bllManager = new WebStock.BLL.Manager();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (LogType.ToLower().Trim() == "exit")
                Session["LoginUser"] = null;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (UserNameTextBox.Text.Trim() != string.Empty && PassWordTextBox.Text.Trim() != string.Empty)
            {
                //var manager = bllManager.GetModel(UserNameTextBox.Text.Trim(), PassWordTextBox.Text.Trim());
                //if (manager != null)
                //{
                    Session["LoginUser"] = UserNameTextBox.Text;
                    Response.Redirect("SysInfo.aspx");
                //}
                //else
                //{
                //    ClientScript.RegisterStartupScript(this.GetType(), "Fail", "alert('登陆失败，用户或密码错误，请重新登陆。');", true);
                //}
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Empty", "alert('请输入用户名及密码！');", true);
            }
        }

    }
}