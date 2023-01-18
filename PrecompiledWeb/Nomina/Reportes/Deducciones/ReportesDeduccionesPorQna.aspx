<%@ page language="VB" enableeventvalidation="false" masterpagefile="~/MasterPageSesionIniciada.master" autoeventwireup="false" inherits="ReportesDeduccionesPorQna, App_Web_cchcgmxa" title="COBAEV - N�mina - Reportes sobre terceros institucionales" stylesheettheme="SkinFile" maintainScrollPositionOnPostBack="true" %>

<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress"
    TagPrefix="TP_wucUpdateProgress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
    <table style="width: 100%; vertical-align: top;" align="center">
        <tr>
            <td style="vertical-align: top; text-align: right">
                <h2>
                    Sistema de n�mina: Terceros institucionales (Reportes)
                </h2>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top; text-align: left">
                <asp:Panel ID="pnlA�os" runat="server" DefaultButton="btnConsultarQuincenas" Font-Names="Verdana"
                    Font-Size="X-Small" GroupingText="Seleccione a�o">
                    <br />
                    <asp:DropDownList ID="ddlA�os" runat="server" SkinID="SkinDropDownList">
                    </asp:DropDownList>
                    <asp:Button ID="btnConsultarQuincenas" runat="server" SkinID="SkinBoton" Text="Ver quincenas"
                        ToolTip="Consultar quincenas para el a�o seleccionado" OnClick="btnConsultarQuincenas_Click" /><br />
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td style="text-align: left; vertical-align: top;">
                <br />
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblMsj" runat="server" SkinID="SkinLblNormal"></asp:Label><br />
                        <asp:GridView ID="gvQuincenas" runat="server" CellPadding="1" SkinID="SkinGridView"
                            Width="100%" EmptyDataText="No existen quincenas calculadas para el a�o especificado."
                            OnSelectedIndexChanged="gvQuincenas_SelectedIndexChanged">
                            <Columns>
                                <asp:TemplateField HeaderText="IdQuincena" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIdQuincena" runat="server" Text='<%# Bind("IdQuincena") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Quincena">
                                    <ItemTemplate>
                                        <asp:Label ID="lblQuincena" runat="server" Text='<%# Bind("Quincena") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="Observaciones" HeaderText="Observaciones">
                                    <ItemStyle Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="FechaDePago" DataFormatString="{0:d}" HeaderText="Fecha de pago">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:CommandField ShowSelectButton="True">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:CommandField>
                            </Columns>
                        </asp:GridView>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnConsultarQuincenas" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
                <br />
            </td>
        </tr>
        <tr>
            <td style="text-align: left">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="pnlDeducciones" runat="server" Font-Names="Verdana" Font-Size="X-Small"
                            GroupingText="Seleccione deducci�n">
                            <br />
                            <asp:DropDownList ID="ddlDeducciones" runat="server" AutoPostBack="True" SkinID="SkinDropDownList">
                            </asp:DropDownList>
                            <br />
                            <br />
                        </asp:Panel>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="gvQuincenas" EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td style="text-align: left">
                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                    <ContentTemplate>
                        <table>
                            <tr>
                                <td>
                                    <asp:Label ID="Label2" runat="server" SkinID="SkinLblNormal">Seleccione reporte</asp:Label>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 21px">
                                    <asp:DropDownList ID="ddlReportes" runat="server" SkinID="SkinDropDownList" AutoPostBack="True"
                                        OnSelectedIndexChanged="ddlReportes_SelectedIndexChanged">
                                        <asp:ListItem Value="17">DESCUENTOS APLICADOS POR QUINCENA</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td style="height: 21px">
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" style="text-align: left">
                                    <br />
                                    <asp:ImageButton ID="ibImprimir" runat="server" ImageUrl="~/Imagenes/PDFExport.jpg"
                                        ToolTip="Exportar reporte a PDF para impresi�n" />
                                    <asp:ImageButton ID="ibImprimirExcel" runat="server" ImageUrl="~/Imagenes/ExcelExport.jpg"
                                        ToolTip="Exportar reporte a Excel" />
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlReportes" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="ddlDeducciones" EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>
