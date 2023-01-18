<%@ page language="VB" enableeventvalidation="false" masterpagefile="~/MasterPageSesionIniciada.master" autoeventwireup="false" inherits="CompensacionesReportes, App_Web_ns2nwdvl" title="COBAEV - Nómina - Compensaciones (Reportes)" stylesheettheme="SkinFile" maintainScrollPositionOnPostBack="true" %>

<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress"
    TagPrefix="TP_wucUpdateProgress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UPMain" runat="server">
    <ContentTemplate>
    <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
   <table style="width: 100%; vertical-align: top;" align="center">
        <tr>
            <td style="vertical-align: top; text-align: right">
                <h2>
                    Sistema de nómina: gratificaciones extraordinarias mensuales (Reportes)
                </h2>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top; text-align: left;">
                        <asp:Panel ID="pnlAños" runat="server" DefaultButton="btnConsultar" Font-Names="Verdana"
                            Font-Size="X-Small" GroupingText="Seleccione año">
                            <asp:DropDownList ID="ddlAños" runat="server" SkinID="SkinDropDownList" AutoPostBack="True">
                            </asp:DropDownList>
                        </asp:Panel>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top; text-align: left">
                        <asp:Panel ID="pnlMeses" runat="server" Font-Size="X-Small" Font-Names="Verdana"
                            GroupingText="Meses pagados durante el año">
                            <asp:DropDownList ID="ddlMeses" runat="server" AutoPostBack="True" 
                                SkinID="SkinDropDownList">
                            </asp:DropDownList>
                        </asp:Panel>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top; text-align: left">
                        <asp:Button ID="btnConsultar" runat="server" SkinID="SkinBoton" Text="Consultar"
                            ToolTip="Consultar información relacionada con el año y mes seleccionados" />
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top; text-align: left">
                <ajaxToolkit:CollapsiblePanelExtender ID="CPEResumenCompe" runat="server" CollapseControlID="TitlePanelResumenCompe"
                    Collapsed="true" CollapsedImage="~/Imagenes/expand_blue.jpg" CollapsedText="(Mostrar detalles...)"
                    ExpandControlID="TitlePanelResumenCompe" ExpandedImage="~/Imagenes/collapse_blue.jpg"
                    ExpandedText="(Ocultar detalles...)" ImageControlID="Image2" SuppressPostBack="true"
                    TargetControlID="ContentPanelResumenCompe" TextLabelID="Label3">
                </ajaxToolkit:CollapsiblePanelExtender>
                <asp:Panel ID="TitlePanelResumenCompe" runat="server" BorderColor="White" BorderStyle="Solid"
                    BorderWidth="1px" CssClass="collapsePanelHeader" Width="100%">
                    <asp:Image ID="Image2" runat="server" ImageUrl="~/Imagenes/expand_blue.jpg" />
                    Resúmen
                    <asp:Label ID="Label3" runat="server">(Mostrar detalles...)</asp:Label>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top; text-align: left">
                <asp:Panel ID="ContentPanelResumenCompe" runat="server" CssClass="collapsePanel"
                    Width="100%">
                            <asp:Label ID="lblMsj2" runat="server" SkinID="SkinLblDatos"></asp:Label><br />
                            <asp:GridView ID="gvResumen" runat="server" Width="100%" SkinID="SkinGridView" EmptyDataText="Sin resúmen."
                                CellPadding="1" ShowFooter="True">
                                <Columns>
                                    <asp:BoundField DataField="FormaDePago" HeaderText="Forma de pago" FooterText="Totales">
                                        <FooterStyle HorizontalAlign="Center"></FooterStyle>
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Importe">
                                        <FooterTemplate>
                                            <asp:Label ID="lblImporteTotal" runat="server" Text='<%# Bind("Importe", "{0:c}") %>'></asp:Label>
                                        </FooterTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblImporte" runat="server" Text='<%# Bind("Importe", "{0:c}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterStyle HorizontalAlign="Right"></FooterStyle>
                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Total empleados">
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalEmpsTotal" runat="server" Text='<%# Bind("TotalEmps") %>'></asp:Label>
                                        </FooterTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblTotalEmps" runat="server" Text='<%# Bind("TotalEmps") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterStyle HorizontalAlign="Center"></FooterStyle>
                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <br />
                            <asp:Label ID="lblMsj4" runat="server" SkinID="SkinLblDatos"></asp:Label>
                            <asp:GridView ID="gvResumen2" runat="server" CellPadding="1" 
                                EmptyDataText="Sin resúmen." ShowFooter="True" SkinID="SkinGridView" 
                                Width="100%">
                                <Columns>
                                    <asp:BoundField DataField="TipoEmp" FooterText="Totales" 
                                        HeaderText="Tipo empleado">
                                    <FooterStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Importe">
                                        <FooterTemplate>
                                            <asp:Label ID="lblImporteTotal" runat="server" 
                                                Text='<%# Bind("Importe", "{0:c}") %>'></asp:Label>
                                        </FooterTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblImporte" runat="server" 
                                                Text='<%# Bind("Importe", "{0:c}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterStyle HorizontalAlign="Right" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Total empleados">
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalEmpsTotal" runat="server" 
                                                Text='<%# Bind("TotalEmps") %>'></asp:Label>
                                        </FooterTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblTotalEmps" runat="server" Text='<%# Bind("TotalEmps") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterStyle HorizontalAlign="Center" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td style="text-align: left;">
                <ajaxToolkit:CollapsiblePanelExtender ID="CPEReportes" runat="server" CollapseControlID="TitlePanelReportes"
                    Collapsed="False" CollapsedImage="~/Imagenes/expand_blue.jpg" CollapsedText="(Mostrar detalles...)"
                    ExpandControlID="TitlePanelReportes" ExpandedImage="~/Imagenes/collapse_blue.jpg"
                    ExpandedText="(Ocultar detalles...)" ImageControlID="Img1PnlRep" SuppressPostBack="true"
                    TargetControlID="ContentPanelReportes" TextLabelID="Lbl1PnlRep">
                </ajaxToolkit:CollapsiblePanelExtender>
                <asp:Panel ID="TitlePanelReportes" runat="server" BorderColor="White" BorderStyle="Solid"
                    BorderWidth="1px" CssClass="collapsePanelHeader" Width="100%">
                    <asp:Image ID="Img1PnlRep" runat="server" ImageUrl="~/Imagenes/expand_blue.jpg" />
                    Reportes
                    <asp:Label ID="Lbl1PnlRep" runat="server">(Mostrar detalles...)</asp:Label>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td style="text-align: left">
                <asp:Panel ID="ContentPanelReportes" runat="server" CssClass="collapsePanel" 
                    Width="100%" HorizontalAlign="Left">
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
                                            ToolTip="Mostrar reporteen PDF" />
                                        <asp:ImageButton ID="ibExportarExcel" runat="server" ImageUrl="~/Imagenes/ExcelExport.jpg"
                                            ToolTip="Mostrar reporte en Excel" />
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Panel ID="pnlFchImpRpt" runat="server" Visible="False">
                                            <asp:Label ID="Label5" runat="server" SkinID="SkinLblNormal" 
                                                Text="Fecha de impresión"></asp:Label>
                                            <br />
                                            <asp:TextBox ID="txtbxFchImpRpt" runat="server" AutoPostBack="True" 
                                                MaxLength="10" SkinID="SkinTextBox"></asp:TextBox>
                                        </asp:Panel>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                            </table>
                </asp:Panel>
            </td>
        </tr>
    </table>
</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>
