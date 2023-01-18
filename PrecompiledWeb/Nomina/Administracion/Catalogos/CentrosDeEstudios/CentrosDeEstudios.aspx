<%@ page language="VB" masterpagefile="~/MasterPageSesionIniciada.master" autoeventwireup="false" inherits="Admon_Catalogos_CentrosDeEstudios, App_Web_3mnwzpss" title="COBAEV - Nómina - Administración de Centros de estudios" stylesheettheme="SkinFile" maintainScrollPositionOnPostBack="true" %>
<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress" TagPrefix="TP_wucUpdateProgress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
     <table style="width: 100%; vertical-align: top; text-align: center;" align="center">
        <tr>
            <td style="vertical-align: top; text-align: right">
                <h2>Sistema de nómina: Administración de catálogo de CARRERAS</h2>
            </td>
        </tr>
        <tr>
            <td style="text-align: left">

                <asp:Label ID="Label1" runat="server" SkinID="SkinLblNormal" 
                    Text="Tipo de Centro de Estudios"></asp:Label>

            </td>
        </tr>
        <tr>
            <td style="text-align: left">
                <asp:DropDownList ID="ddlTipoCentro" runat="server" SkinID="SkinDropDownList">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="text-align: left">

                &nbsp;</td>
        </tr>
        <tr>
            <td style="text-align: left">

                <asp:Label ID="Label2" runat="server" SkinID="SkinLblNormal" 
                    Text="Listado de Centro de Estudios"></asp:Label>

            </td>
        </tr>
        <tr>
            <td style="text-align: left">

                <asp:ListBox ID="lbCentrosDeEstudios" runat="server"></asp:ListBox>

            </td>
        </tr>
    </table>
</asp:Content>

