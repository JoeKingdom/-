using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class _default : System.Web.UI.Page
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
        cmd.CommandText = "Select*from kehu where No=@No and Pwd=@Pwd";
        cmd.Parameters.Add("@No", SqlDbType.Char, 10).Value = txtUserName.Text.Trim();
        cmd.Parameters.Add("@Pwd", SqlDbType.Char, 10).Value = txtPassword.Text.Trim();

        sqlConnection1.Open();
        SqlDataReader dr = cmd.ExecuteReader();

        if (dr.Read())
        {
            Response.Cookies["No"].Value = txtUserName.Text.Trim();
            Response.Cookies["Pwd"].Value = txtPassword.Text.Trim();
            Response.Cookies["No"].Expires = DateTime.Now.AddDays(int.Parse(dpExpires.SelectedValue));
            Response.Cookies["Pwd"].Expires = DateTime.Now.AddDays(int.Parse(dpExpires.SelectedValue));
            Session["Name"] = dr["Name"].ToString();
            Response.Redirect("phones.aspx");
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