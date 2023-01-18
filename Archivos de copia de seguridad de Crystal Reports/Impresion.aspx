<%@ Page Language="VB" EnableEventValidation="false" MasterPageFile="~/MasterPageSesionIniciada.master"
    AutoEventWireup="false" CodeFile="Impresion.aspx.vb" Inherits="ImpresionDeQuincenas"
    Title="COBAEV - Nómina - Impresión de nóminas" StylesheetTheme="SkinFile" %>

<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress"
    TagPrefix="TP_wucUpdateProgress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
    <table style="width: 100%; vertical-align: top;" align="center">
        <tr>
            <td style="vertical-align: top; text-align: right">
                <h2>
                    Sistema de nómina: Impresión de documentos relacionados con nóminas quincenales
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
                    <asp:Button ID="btnConsultarQuincenas" runat="server" SkinID="SkinBoton" Text="Consultar"
                        ToolTip="Consultar información relacionada con el año seleccionado" OnClick="btnConsultarQuincenas_Click" /><br />
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top; text-align: left">
                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="pnlMeses" runat="server" Font-Names="Verdana" Font-Size="X-Small"
                            GroupingText="Meses pagados durante el año">
                            <br />
                            <asp:DropDownList ID="ddlMeses" runat="server" SkinID="SkinDropDownList" AutoPostBack="True">
                            </asp:DropDownList>
                        </asp:Panel>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="gvReportes" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="btnConsultarQuincenas" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td style="text-align: left; vertical-align: top;">
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
                        <asp:AsyncPostBackTrigger ControlID="gvReportes" EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
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
                                <asp:ListItem Value="0">General</asp:ListItem>
                                <asp:ListItem Value="1" Selected="True">Plantel</asp:ListItem>
                                <asp:ListItem Value="2">Zona geogr&#225;fica</asp:ListItem>
                            </asp:DropDownList>
                            <br />
                            <br />
                        </asp:Panel>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="gvReportes" EventName="SelectedIndexChanged" />
                    </Triggers>
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
                            <asp:DropDownList ID="ddlPlantelesPensionAlimenticia" runat="server" SkinID="SkinDropDownList"
                                AutoPostBack="True" OnSelectedIndexChanged="ddlPlanteles_ZonasGeo_SelectedIndexChanged"
                                Visible="False">
                            </asp:DropDownList>
                            <br />
                            <br />
                        </asp:Panel>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlTiposDeImpresion" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="gvReportes" EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td style="text-align: left">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="pnlTipoDeNomina" runat="server" Font-Names="Verdana" Font-Size="X-Small"
                            GroupingText="Seleccione tipo de nómina">
                            <br />
                            <asp:DropDownList ID="ddlTipoDeNomina" runat="server" SkinID="SkinDropDownList" AutoPostBack="True"
                                OnSelectedIndexChanged="ddlTipoDeNomina_SelectedIndexChanged">
                            </asp:DropDownList>
                            <br />
                            <br />
                        </asp:Panel>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlTipoDeNomina" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="gvReportes" EventName="SelectedIndexChanged" />
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
                                            <asp:CommandField ShowSelectButton="True" />
                                        </Columns>
                                    </asp:GridView>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:ImageButton ID="ibImprimir" runat="server" ImageUrl="~/Imagenes/PDFExport.jpg"
                                        ToolTip="Mostrar reporteen PDF" ValidationGroup="Grp1" />
                                    <asp:ImageButton ID="ibExportarExcel" runat="server" ImageUrl="~/Imagenes/ExcelExport.jpg"
                                        ToolTip="Mostrar reporte en Excel" />
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
                                    </asp:Panel>
                                </td>
                                <td>
                                    &nbsp;</td>
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
                        <asp:AsyncPostBackTrigger ControlID="ddlTipoDeNomina" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="gvReportes" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="ddlMeses" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="ddlPlantelesPensionAlimenticia" EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>
