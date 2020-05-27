using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class deliver : System.Web.UI.Page
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
        cmd.CommandText = " DELETE FROM yuding WHERE kehuName =@kehuName ";
        cmd.Parameters.Add("@kehuName", SqlDbType.VarChar, 20).Value = DropDownList1.SelectedValue;
        sqlConnection1.Open();
        int r = cmd.ExecuteNonQuery();
        sqlConnection1.Close();


        string msg;
        if (r > 0)
        {
            msg = "<script>alert('删除成功')</script>";
            Response.Redirect("useryuding.aspx");
        }
        else
            msg = "<script>alert('删除失败')</script>";
        Literal lit = new Literal();
        lit.Text = msg;
        Page.Controls.Add(lit);
    }
}