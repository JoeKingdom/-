using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class managecomputers : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null)
        {//未登录
            Response.Redirect("AdminLogin.aspx");
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string ConnectionString = "server=localhost\\sqlexpress;User Id=sa;pwd=123456;Database=mywebsite";
        SqlConnection sqlConnection1 = new SqlConnection(ConnectionString);
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = sqlConnection1;
        cmd.CommandText = " INSERT INTO computer" + " ([No],[Name],[Color],[Cpu],[runMenory],[hardMenory],[Number],[Price])" + " VALUES(@No,@Name,@Color,@Cpu,@runMenory,@hardMenory,@Number,@Price)";
        cmd.Parameters.AddWithValue("@No", TextBox1.Text);
        cmd.Parameters.AddWithValue("@Name", TextBox2.Text);
        cmd.Parameters.AddWithValue("@Color", TextBox3.Text);
        cmd.Parameters.AddWithValue("@Cpu", TextBox8.Text);
        cmd.Parameters.AddWithValue("@runMenory", TextBox4.Text);
        cmd.Parameters.AddWithValue("@hardMenory", TextBox5.Text);
        cmd.Parameters.AddWithValue("@Number", TextBox6.Text);
        cmd.Parameters.AddWithValue("@Price", TextBox7.Text);
        sqlConnection1.Open();
        int r = cmd.ExecuteNonQuery();
        sqlConnection1.Close();
        string msg;
        if (r > 0)
            msg = "<script>alert('添加成功')</script>";
        else
            msg = "<script>alert('添加失败')</script>";
        Literal lit = new Literal();
        lit.Text = msg;
        Page.Controls.Add(lit);
    }
}