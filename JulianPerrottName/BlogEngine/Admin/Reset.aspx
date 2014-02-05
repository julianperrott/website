<%@ Page Language="C#" %>
<script runat=server>
protected void btnReset_Click(object sender, EventArgs e)
{
    try
    {
        //BlogEngine.Core.Post.Reload();
        //HttpRuntime.Close();
        //lblResult.Text = "Reload successful!";
    }
    catch
    {
        lblResult.Text = "Not successful!";
    }
}
</script>
<html>
<body>
    <form id="form2" runat="server">
        <div>
            <asp:Button ID="btnReset" runat="server" Text="Reset" OnClick="btnReset_Click"/>
            <asp:Label ID="lblResult" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
