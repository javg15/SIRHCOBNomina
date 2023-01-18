<%@ page language="VB" masterpagefile="~/MasterPageBlanca.master" autoeventwireup="false" inherits="ObservacionesSobrePlazas, App_Web_flakjmxh" title="COBAEV - Nómina - Observaciones sobre plazas" theme="SkinFile" stylesheettheme="SkinFile" maintainScrollPositionOnPostBack="true" %>
<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress" TagPrefix="TP_wucUpdateProgress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
    <table style="width: 100%; height: 100%" align="center">
        <tr>
            <td style="vertical-align: top; text-align: right">
                <h2>
                    Sistema de nómina: Inconsistencias encontradas tomando como base sus plazas
                </h2>
            </td>
        </tr>
        <tr>
            <td style="text-align: center">
                <table>
                    <tr>
                        <td style="vertical-align: top; text-align: left">
                            <asp:GridView ID="gvObservaciones" runat="server" AutoGenerateColumns="False"
                                SkinID="SkinGridView">
                                <Columns>
                                    <asp:BoundField DataField="IdObserv">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Observacion" HeaderText="Observación">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                                </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top; text-align: center">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="text-align: center">
    <asp:LinkButton ID="lbCerrar" runat="server" SkinID="SkinLinkButton">Cerrar ventana</asp:LinkButton></td>
        </tr>
    </table>
</asp:Content>

