<%@ Page Language="VB" MasterPageFile="~/MasterPageBlanca.master" AutoEventWireup="false" CodeFile="VisualzadorDeFotos.aspx.vb" Inherits="Consultas_Empleados_VisualzadorDeFotos" title="COBAEV - Nómina - Visualizador de fotos" Theme="SkinFile" %>
<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress" TagPrefix="TP_wucUpdateProgress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
    <table style="width: 100%; height: 100%">
        <tr>
            <td style="vertical-align: top; text-align: right">
                <h2>
                    Sistema de nómina: Empleados (Fotografía)
                </h2>
            </td>
        </tr>
        <tr>
            <td style="text-align: center">
    <asp:Image ID="imgFoto" runat="server" AlternateText="Sin foto" Width="400px" Height="450px" /></td>
        </tr>
        <tr>
            <td style="text-align: center">
    <asp:LinkButton ID="lbCerrar" runat="server" SkinID="SkinLinkButton">Cerrar ventana</asp:LinkButton></td>
        </tr>
    </table>
</asp:Content>

