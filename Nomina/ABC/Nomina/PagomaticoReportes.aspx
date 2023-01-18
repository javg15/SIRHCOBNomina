<%@ Page Language="VB" EnableEventValidation="false" MasterPageFile="~/MasterPageSesionIniciada.master"
    AutoEventWireup="false" CodeFile="PagomaticoReportes.aspx.vb" Inherits="PagomaticoReportes"
    Title="COBAEV - Nómina - Reportes de pagomático" StylesheetTheme="SkinFile" %>
<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress" TagPrefix="TP_wucUpdateProgress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />   
    <table style="width: 100%; vertical-align: top;" align="center">
        <tr>
            <td style="vertical-align: top; text-align: right">
                <h2>
                    Sistema de nómina: Reportes (Archivos de texto para transferencia electrónica bancaria)
                </h2>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top; text-align: left">
                <asp:Panel ID="pnlAños" runat="server" DefaultButton="btnConsultarQuincenas" Font-Names="Verdana"
                    Font-Size="X-Small" GroupingText="Seleccione año">
                    <br />
                    <asp:DropDownList ID="ddlAños" runat="server" SkinID="SkinDropDownList">
                    </asp:DropDownList>
                    <asp:Button ID="btnConsultarQuincenas" runat="server" SkinID="SkinBoton" Text="Ver quincenas"
                        ToolTip="Consultar quincenas para el año seleccionado" OnClick="btnConsultarQuincenas_Click" /><br />
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
                            Width="100%" EmptyDataText="No existen quincenas calculadas para el año especificado."
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
                        <asp:Panel ID="pnlOpcDeImpresion" runat="server" Font-Names="Verdana" Font-Size="X-Small"
                            GroupingText="Seleccione banco">
                            <br />
                            <asp:DropDownList ID="ddlBancos" runat="server" SkinID="SkinDropDownList" AutoPostBack="True"
                                OnSelectedIndexChanged="ddlBancos_SelectedIndexChanged">
                            </asp:DropDownList>
                            <br />
                        </asp:Panel>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlBancos" EventName="SelectedIndexChanged" />
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
                                        <asp:ListItem Value="0">REPORTE POR BANCO</asp:ListItem>
                                        <asp:ListItem Value="6">REPORTE POR BANCO (SOLO RESUMEN)</asp:ListItem>
                                        <asp:ListItem Value="8">REPORTE POR BANCO (CLABE)</asp:ListItem>
                                        <asp:ListItem Value="7">REPORTE POR BANCO (SOLO RESUMEN CLABE)</asp:ListItem>
                                        <asp:ListItem Value="4">REPORTE POR BANCO (PENSIÓN ALIMENTICIA)</asp:ListItem>
                                        <asp:ListItem Value="1">REPORTE POR BANCO DESGLOSADO POR PLANTEL</asp:ListItem>
                                        <asp:ListItem Value="2">REPORTE POR PLANTEL</asp:ListItem>
                                        <asp:ListItem Value="3">REPORTE DE TODOS LOS PLANTELES</asp:ListItem>
                                        <asp:ListItem Value="5">POR BANCO (PENSIÓN ALIMENTICIA CLABE)</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td style="height: 21px">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblPlanteles" runat="server" SkinID="SkinLblNormal" Visible="False">Seleccione plantel</asp:Label>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:DropDownList ID="ddlPlanteles" runat="server" SkinID="SkinDropDownList" AutoPostBack="True"
                                        OnSelectedIndexChanged="ddlReportes_SelectedIndexChanged" Visible="False">
                                        <asp:ListItem Value="0">Reporte por banco</asp:ListItem>
                                        <asp:ListItem Value="1">Reporte por banco desglosado por plantel</asp:ListItem>
                                        <asp:ListItem Value="2">Reporte por plantel</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Panel ID="pnlFchImpRpt" runat="server" Visible="False">
                                        <asp:Label ID="lblFechaImp" runat="server" SkinID="SkinLblNormal" 
                                            Text="Fecha de impresión"></asp:Label>
                                        <br />
                                        <asp:TextBox ID="txtbxFchImpRpt" runat="server" MaxLength="10" 
                                            SkinID="SkinTextBox" AutoPostBack="True"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender ID="txtbxFchImpRpt_CE" runat="server" 
                                            Enabled="True" TargetControlID="txtbxFchImpRpt">
                                        </ajaxToolkit:CalendarExtender>
                                    </asp:Panel>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" style="text-align: left">
                                    <asp:ImageButton ID="ibImprimir" runat="server" ImageUrl="~/Imagenes/Printer1.jpg"
                                        ToolTip="Mostrar reporte para impresión" />
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlReportes" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="ddlPlanteles" EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>
