<%@ page language="VB" masterpagefile="~/MasterPageSinPermisos.master" autoeventwireup="false" inherits="ErroresPagina, App_Web_cyyqwboa" title="COBAEV - Nómina - Errores" stylesheettheme="SkinFile" maintainScrollPositionOnPostBack="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 100%">
        <tr>
            <td style="vertical-align: top; text-align: left">
    <table style="width: 100%" align="left">
        <tr>
            <td style="text-align: left; width: 42px;">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/Symbol-Stop.png" Width="100px" /></td>
            <td style="vertical-align: middle; ">
                <asp:Label ID="Label1" runat="server" SkinID="SkinLblMsjErrores"
                    Text="Errores producidos al intentar accesar a la página:"></asp:Label><br />
                <br />
                <asp:GridView ID="gvErroresPagina" runat="server" SkinID="SkinGridView" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="IdError" HeaderText="No. Error" />
                        <asp:BoundField DataField="Descripcion" HeaderText="Descripci&#243;n del error" />
                    </Columns>
                </asp:GridView>
                <br />
                <asp:LinkButton ID="lbContinuar" runat="server" PostBackUrl="~/MenuPrincipal.aspx"
                    SkinID="SkinLinkButton">Continuar</asp:LinkButton></td>
        </tr>
    </table>
            </td>
        </tr>
    </table>
</asp:Content>

