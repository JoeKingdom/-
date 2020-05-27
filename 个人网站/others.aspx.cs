using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


public partial class others : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Name"] == null)
        {//未登录
            Response.Redirect("default.aspx");
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string ConnectionString = "server=localhost\\sqlexpress;User Id=sa;pwd=123456;Database=mywebsite";
        SqlConnection sqlConnection1 = new SqlConnection(ConnectionString);
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = sqlConnection1;
        cmd.CommandText = " INSERT INTO yuding" + " ([No],[Number],[kehuName],[kehuPhone])" + " VALUES(@No,@Number,@kehuName,@kehuPhone)";
        cmd.Parameters.Add("@No", SqlDbType.Char, 10).Value = ddlNo.SelectedValue;
        cmd.Parameters.AddWithValue("@Number", txtNumber.Text);
        cmd.Parameters.AddWithValue("@kehuName", txtkehuName.Text);
        cmd.Parameters.AddWithValue("@kehuPhone", txtkehuPhone.Text);
        sqlConnection1.Open();
        int r = cmd.ExecuteNonQuery();
        sqlConnection1.Close();
        string msg;
        if (r > 0)
            msg = "<script>alert('订购成功')</script>";
        else
            msg = "<script>alert('订购失败')</script>";
        Literal lit = new Literal();
        lit.Text = msg;
        Page.Controls.Add(lit);
    }
}