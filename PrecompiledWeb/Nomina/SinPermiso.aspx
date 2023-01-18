<%@ page language="VB" masterpagefile="~/MasterPageSesionNoIniciada.master" autoeventwireup="false" inherits="SinPermiso, App_Web_cyyqwboa" title="COBAEV - Nómina - Acceso denegado" stylesheettheme="SkinFile" maintainScrollPositionOnPostBack="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 70%">
        <tr>
            <td style="vertical-align: top; text-align: left">
    <table style="width: 100%">
        <tr>
            <td style="text-align: left; width: 42px;">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/Symbol-Stop.png" Width="100px" /></td>
            <td style="vertical-align: middle; text-align: left">
                <asp:Label ID="Label1" runat="server" SkinID="SkinLblMsjErrores"
                    Text="Permiso denegado para realizar la operación solicitada."></asp:Label>
                <br />
                <asp:LinkButton ID="lbContinuar" runat="server" PostBackUrl="~/MenuPrincipal.aspx"
                    SkinID="SkinLinkButton" Visible="False">Continuar</asp:LinkButton></td>
        </tr>
    </table>
            </td>
        </tr>
    </table>
</asp:Content>

