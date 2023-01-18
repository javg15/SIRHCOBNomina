<%@ control language="VB" autoeventwireup="false" inherits="WebControls_wucAnioQnas, App_Web_vfc141dy" %>
<asp:Panel ID="pnlQuincenas" runat="server" Font-Size="X-Small" Font-Names="Verdana"
    GroupingText="Consulta de quincenas ordinarias pagadas por año">
    <br />
    <asp:Label ID="Label7" runat="server" SkinID="SkinLblNormal" Text="Seleccione año"></asp:Label>&nbsp;<asp:DropDownList
        ID="ddlAños" runat="server" SkinID="SkinDropDownList" AutoPostBack="True" OnSelectedIndexChanged="ddlAños_SelectedIndexChanged">
    </asp:DropDownList>
    <br />
    <br />
    <asp:Label ID="Label3" runat="server" SkinID="SkinLblNormal" Text="Seleccione quincena"></asp:Label>&nbsp;<asp:DropDownList
        ID="ddlQnasPagadas" runat="server" SkinID="SkinDropDownList">
    </asp:DropDownList>
    <br />
    <br />
</asp:Panel>
