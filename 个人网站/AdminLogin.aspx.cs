using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string ConnectionString = "server=localhost\\sqlexpress;User Id=sa;pwd=123456;Database=mywebsite";
        SqlConnection sqlConnection1 = new SqlConnection(ConnectionString);
        
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = sqlConnection1;
        cmd.CommandText = "Select*from [user] where UserNo=@UserNo and UserPwd=@UserPwd";
        cmd.Parameters.Add("@UserNo", SqlDbType.Char, 8).Value = txtUserName.Text.Trim();
        cmd.Parameters.Add("@UserPwd", SqlDbType.Char, 8).Value = txtPassword.Text.Trim();

        sqlConnection1.Open();
        SqlDataReader dr = cmd.ExecuteReader();

        if (dr.Read())
        {
            Response.Cookies["UserNo"].Value = txtUserName.Text.Trim();
            Response.Cookies["UserPwd"].Value = txtPassword.Text.Trim();
            Response.Cookies["UserNo"].Expires = DateTime.Now.AddDays(int.Parse(dpExpires.SelectedValue));
            Response.Cookies["UserPwd"].Expires = DateTime.Now.AddDays(int.Parse(dpExpires.SelectedValue));
            Session["UserName"] = dr["UserName"].ToString();
            Response.Redirect("managephones.aspx");
        }
        else
        {
            Literal lit = new Literal();
            lit.Text = "<script>alert('用户名或密码错误!')</script>";
            Page.Controls.Add(lit);
        }
        sqlConnection1.Close();
    }
}