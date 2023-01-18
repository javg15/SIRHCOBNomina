<%@ Page Language="VB" EnableEventValidation="false" MasterPageFile="~/MasterPageSesionIniciada.master"
    AutoEventWireup="false" CodeFile="ImpresionPlantillas.aspx.vb" Inherits="ImpresionPlantillas"
    Title="COBAEV - Nómina - Reportes por plantel" StylesheetTheme="SkinFile" %>
<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress" TagPrefix="TP_wucUpdateProgress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
    <table style="width: 100%; vertical-align: top; text-align: center;" align="center">
        <tr>
            <td style="vertical-align: top; text-align: right">
                <h2>
                    Sistema de nómina: Reportes (Información de planteles)
                </h2>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top; text-align: left">
                &nbsp;<asp:Panel ID="pnlAños" runat="server" DefaultButton="btnConsultarQuincenas"
                    Font-Names="Verdana" Font-Size="X-Small" GroupingText="Seleccione año">
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
                            Width="100%" EmptyDataText="No existen quincenas calculadas para el año especificado.">
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
                            GroupingText="Seleccione tipo de impresión">
                            <br />
                            <asp:DropDownList ID="ddlTiposDeImpresion" runat="server" SkinID="SkinDropDownList"
                                AutoPostBack="True" OnSelectedIndexChanged="ddlTiposDeImpresion_SelectedIndexChanged">
                                <asp:ListItem Value="0" Enabled="False">General</asp:ListItem>
                                <asp:ListItem Value="1" Selected="True">Plantel</asp:ListItem>
                                <asp:ListItem Value="2" Enabled="False">Zona geogr&#225;fica</asp:ListItem>
                            </asp:DropDownList>
                            <br />
                            <br />
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td style="text-align: left">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="pnlPlanteles_ZonasGeo" runat="server" Font-Names="Verdana" Font-Size="X-Small">
                            <br />
                            <asp:DropDownList ID="ddlPlanteles_ZonasGeo" runat="server" SkinID="SkinDropDownList"
                                AutoPostBack="True" OnSelectedIndexChanged="ddlPlanteles_ZonasGeo_SelectedIndexChanged">
                            </asp:DropDownList>
                            <br />
                            <br />
                        </asp:Panel>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlTiposDeImpresion" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="ddlTiposDeImpresion" EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td style="text-align: left">
                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                    <ContentTemplate>
                        <table align="left">
                            <tr>
                                <td>
                                    <asp:Label ID="Label2" runat="server" SkinID="SkinLblNormal">Seleccione reporte</asp:Label>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:DropDownList ID="ddlReportes" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlReportes_SelectedIndexChanged"
                                        SkinID="SkinDropDownList">
                                        <asp:ListItem Value="16">PLANTILLAS</asp:ListItem>
                                        <asp:ListItem Value="103">PLANTILLAS (REVISIÓN)</asp:ListItem>
                                        <asp:ListItem Value="92" Enabled="false">CONSTANCIA SISTEMA NACIONAL DE BACHILLERATO</asp:ListItem>
                                        <asp:ListItem Value="CR01" Enabled="false">CONSTANCIA LABORAL</asp:ListItem>
                                        <asp:ListItem Value="CR02" Enabled="false">CONSTANCIA LABORAL CON INGRESOS</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:ImageButton ID="ibImprimir" runat="server" ImageUrl="~/Imagenes/PDFExport.jpg"
                                        ToolTip="Mostrar reporte para impresión" />&nbsp;<asp:ImageButton ID="ibImprimirWord"
                                            runat="server" ImageUrl="~/Imagenes/WordExport.jpg" ToolTip="Mostrar en formato Word  reporte para impresión" />
                                    &nbsp;<asp:ImageButton ID="ibImprimirExcel" runat="server" 
                                        ImageUrl="~/Imagenes/ExcelExport.jpg" 
                                        ToolTip="Mostrar en formato Excel  reporte para impresión" Visible="False" />
                                </td>
                                <td>
                                </td>
                            </tr>
                        </table>
                        &nbsp;
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnConsultarQuincenas" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="gvQuincenas" EventName="RowCommand" />
                        <asp:AsyncPostBackTrigger ControlID="gvQuincenas" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="ddlTiposDeImpresion" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="ddlPlanteles_ZonasGeo" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="ddlReportes" EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>
