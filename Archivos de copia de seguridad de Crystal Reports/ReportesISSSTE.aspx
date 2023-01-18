<%@ Page Language="VB" EnableEventValidation="false" MasterPageFile="~/MasterPageSesionIniciada.master"
    AutoEventWireup="false" CodeFile="ReportesISSSTE.aspx.vb" Inherits="ReportesISSSTE"
    Title="COBAEV - Nómina - Reportes ISSSTE" StylesheetTheme="SkinFile" %>

<%@ Register Src="~/WebControls/wucSearchEmps.ascx" TagName="wucSearchEmps" TagPrefix="uc1" %>
<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress" TagPrefix="TP_wucUpdateProgress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
    <table style="width: 100%; vertical-align: top;" align="center">
        <tr>
            <td style="vertical-align: top; text-align: right">
                <h2>
                    Sistema de nómina: Reportes con información para ISSSTE
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
            <td style="vertical-align: top; text-align: left">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="pnlRegPenISSSTE" runat="server">
                            <asp:Label ID="lblRegPenISSSTE" runat="server" SkinID="SkinLblNormal" Text="Seleccione régimen pensionario ISSSTE"></asp:Label><br />
                            <asp:DropDownList ID="ddlRegimenPensISSSTE" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlRegimenPensISSSTE_SelectedIndexChanged"
                                SkinID="SkinDropDownList" Width="230px">
                            </asp:DropDownList>
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <br />
            </td>
        </tr>
        <tr>
            <td style="text-align: left">
                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                    <ContentTemplate>
                        <table>
                            <tr>
                                <td>
                                    <asp:Label ID="Label1" runat="server" SkinID="SkinLblNormal">Seleccione reporte</asp:Label>
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
                                            <asp:TemplateField HeaderText="ExportarAPDF" Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblExportarAPDF" runat="server" Text='<%# Bind("ExportarAPDF") %>'></asp:Label>
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
                                            <asp:TemplateField HeaderText="ImplicaRegPenISSSTE" Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblImplicaRegPenISSSTE" runat="server" Text='<%# Bind("ImplicaRegPenISSSTE") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="PorEmpleado" Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPorEmpleado" runat="server" Text='<%# Bind("PorEmpleado") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="DescParaUsuario" HeaderText="Reporte" />
                                            <asp:CommandField ShowSelectButton="True" />
                                        </Columns>
                                    </asp:GridView>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:CheckBox ID="chbxRptParaEmp" runat="server" AutoPostBack="True" 
                                        SkinID="SkinCheckBox" Text="Imprimir reporte para un empleado específico" 
                                        Enabled="False" />
                                </td>
                                <td>
                                 </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Panel ID="pnlEmp" runat="server" Visible="False">
                                        <uc1:wucSearchEmps ID="wucSearchEmps1" runat="server" Visible="False" />
                                    </asp:Panel>
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
                                    <asp:TextBox ID="txtbxFchImpRpt" runat="server" AutoPostBack="True" 
                                        MaxLength="10" SkinID="SkinTextBox" 
                                            ValidationGroup="grpValidaFecha"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="txtbxFchImpRpt_CE" runat="server" 
                                         TargetControlID="txtbxFchImpRpt">
                                    </ajaxToolkit:CalendarExtender>
                                    </asp:Panel>
                                </td>
                                <td>
                                </td>
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
                        <asp:AsyncPostBackTrigger ControlID="ddlRegimenPensISSSTE" EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>
