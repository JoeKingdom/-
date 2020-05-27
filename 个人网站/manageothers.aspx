<%@ Page Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="manageothers.aspx.cs" Inherits="manageothers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">

        .auto-style1 {
            width: 100%;
            height: 450px;
        }
        .auto-style2 {
            height: 40px;
        }
        .auto-style3 {
            height: 340px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="width: 100%; height: 450px">
        <table class="auto-style1">
            <tr>
                <td class="auto-style2" style="font-size: 28px; text-align: center">配件</td>
            </tr>
            <tr>
                <td class="auto-style3" style="text-align: center">
                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" Height="250px" Width="100%" DataKeyNames="No">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="No" HeaderText="No" SortExpression="No" ReadOnly="True" />
                            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                            <asp:BoundField DataField="Color" HeaderText="Color" SortExpression="Color" />
                            <asp:BoundField DataField="Quality" HeaderText="Quality" SortExpression="Quality" />
                            <asp:BoundField DataField="Number" HeaderText="Number" SortExpression="Number" />
                            <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />
                        </Columns>
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:mywebsiteConnectionString6 %>" SelectCommand="SELECT [No], [Name], [Color], [Quality], [Number], [Price] FROM [peijian]" UpdateCommand="UPDATE peijian SET Name = @Name, Color = @Color, Quality = @Quality, Number = @Number, Price = @Price WHERE (No = @No)">
                        <UpdateParameters>
                            <asp:Parameter Name="Name" />
                            <asp:Parameter Name="Color" />
                            <asp:Parameter Name="Quality" />
                            <asp:Parameter Name="Number" />
                            <asp:Parameter Name="Price" />
                            <asp:Parameter Name="No" />
                        </UpdateParameters>
                    </asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td style="text-align: center">
                    <asp:Label ID="Label1" runat="server" Text="编号："></asp:Label>
                    <asp:TextBox ID="TextBox1" runat="server" Width="6%"></asp:TextBox>
&nbsp;<asp:Label ID="Label2" runat="server" Text="名称："></asp:Label>
                    <asp:TextBox ID="TextBox2" runat="server" Width="6%"></asp:TextBox>
&nbsp;<asp:Label ID="Label3" runat="server" Text="颜色："></asp:Label>
                    <asp:TextBox ID="TextBox3" runat="server" Width="6%"></asp:TextBox>
&nbsp;<asp:Label ID="Label4" runat="server" Text="质量："></asp:Label>
                    <asp:TextBox ID="TextBox4" runat="server" Width="6%"></asp:TextBox>
&nbsp;
                    <asp:Label ID="Label6" runat="server" Text="库存："></asp:Label>
                    <asp:TextBox ID="TextBox6" runat="server" Width="6%"></asp:TextBox>
&nbsp;<asp:Label ID="Label7" runat="server" Text="价格："></asp:Label>
                    <asp:TextBox ID="TextBox7" runat="server" Width="6%"></asp:TextBox>
&nbsp;
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="添加" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
