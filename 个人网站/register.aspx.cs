using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string ConnectionString = "Data Source=localhost\\sqlexpress.;Database=mywebsite;User ID=sa;pwd=123456";
        SqlConnection sqlConnection1 = new SqlConnection(ConnectionString);

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = sqlConnection1;
        cmd.CommandText = " INSERT INTO kehu" + " ([No],[Pwd],[Name],[Email],[Tel])" + " VALUES(@No,@Pwd,@Name,@Email,@Tel)";
        cmd.Parameters.AddWithValue("@No", txtNo.Text);
        cmd.Parameters.AddWithValue("@Pwd", txtPwd.Text);
        cmd.Parameters.AddWithValue("@Name", txtName.Text);
        cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
        cmd.Parameters.AddWithValue("@Tel", txtTelephone.Text);

        sqlConnection1.Open();
        int r = cmd.ExecuteNonQuery();
        sqlConnection1.Close();


        string msg;
        if (r > 0)
        {
            msg = "<script>alert('注册成功')</script>";
            Response.Redirect("Default2.aspx");
        }
        else
            msg = "<script>alert('注册失败')</script>";
        Literal lit = new Literal();
        lit.Text = msg;
        Page.Controls.Add(lit);
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        this.txtNo.Text = " ";
        this.txtPwd.Text = " ";
        this.txtConfirm.Text = " ";
        this.txtName.Text = " ";
        this.txtEmail.Text = " ";
        this.txtTelephone.Text = " ";
    }
}