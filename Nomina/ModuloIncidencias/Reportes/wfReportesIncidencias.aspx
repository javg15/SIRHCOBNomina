<%@ Page Language="VB" EnableEventValidation="false" MasterPageFile="~/MasterPageSesionIniciada.master"
    AutoEventWireup="false" CodeFile="wfReportesIncidencias.aspx.vb" Inherits="ReportesIncidencias"
    Title="COBAEV - Nómina - Incidencias, impresión de reportes"
    StylesheetTheme="SkinFile" %>

<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress"
    TagPrefix="TP_wucUpdateProgress" %>
<%@ Register src="../../WebControls/wucSearchEmps.ascx" tagname="wucsearchemps" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
<asp:UpdatePanel ID="UPMain" runat="server">
    <ContentTemplate>
    <table style="width: 100%; vertical-align: top;" align="center">
        <tr>
            <td style="vertical-align: top; text-align: right">
                <h2>
                    Sistema de nómina: Incidencias, impresión de reportes
                </h2>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top; text-align: left">
                <asp:Panel ID="pnlAños" runat="server"  Font-Names="Verdana"
                    Font-Size="X-Small" GroupingText="Seleccione año">
                    <br />
                    <asp:DropDownList ID="ddlAños" runat="server" SkinID="SkinDropDownList" 
                        AutoPostBack="True">
                    </asp:DropDownList>
                    <br />
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td style="text-align: left">
                        <asp:Panel ID="pnlTipoDeNomina" runat="server" Font-Names="Verdana" 
                            Font-Size="X-Small" GroupingText="Seleccione tipo de nómina" 
                            Visible="False">
                            <br />
                            <asp:DropDownList ID="ddlTipoDeNomina" runat="server" SkinID="SkinDropDownList" 
                                AutoPostBack="True" 
                                OnSelectedIndexChanged="ddlTipoDeNomina_SelectedIndexChanged">
                            </asp:DropDownList>
                            <br />
                            <br />
                        </asp:Panel>
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
                                <td>
                                    <asp:GridView ID="gvReportes" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gvReportes_SelectedIndexChanged"
                                        SkinID="SkinGridViewEmpty">
                                        <Columns>
                                            <asp:TemplateField HeaderText="IdReporte" Visible="False">
                                                <EditItemTemplate>
                                                    &nbsp;
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblIdReporte" runat="server" Text='<%# Bind("IdReporte") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="ImplicaMeses" Visible="False">
                                                <EditItemTemplate>
                                                    &nbsp;
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblImplicaMeses" runat="server" Text='<%# Bind("ImplicaMeses") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="ExportarAExcel" Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblExportarAExcel" runat="server" Text='<%# Bind("ExportarAExcel") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="ImplicaFondoPresup" Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblImplicaFondoPresup" runat="server" Text='<%# Bind("ImplicaFondoPresup") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="ImplicaQuincenas" Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblImplicaQuincenas" runat="server" Text='<%# Bind("ImplicaQuincenas") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="ImplicaPlantel" Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblImplicaPlantel" runat="server" Text='<%# Bind("ImplicaPlantel") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="DescParaUsuario" HeaderText="Reporte" />
                                            <asp:TemplateField HeaderText="ExportarAPDF" Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblExportarAPDF" runat="server" Text='<%# Bind("ExportarAPDF") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="PorEmpleado" Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPorEmpleado" runat="server" Text='<%# Bind("PorEmpleado") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:CommandField ShowSelectButton="True" />
                                        </Columns>
                                    </asp:GridView>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:CheckBox ID="chbxRptParaEmp" runat="server" AutoPostBack="True" Enabled="False" SkinID="SkinCheckBox" Text="Imprimir reporte para un empleado específico" />
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    
                                    <asp:Panel ID="pnlEmp" runat="server" Visible="False">
                                        <uc1:wucSearchEmps ID="wucSearchEmps1" runat="server" Visible="False" />
                                    </asp:Panel>
                                    
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:ImageButton ID="ibExportPDF" runat="server" 
                                        ImageUrl="~/Imagenes/PDFExport.jpg" ToolTip="Mostrar reporte en PDF" />
                                    <asp:ImageButton ID="ibExportarExcel" runat="server" 
                                        ImageUrl="~/Imagenes/ExcelExport.jpg" ToolTip="Mostrar reporte en Excel" />
                                </td>
                                <td>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="gvReportes" EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
