<%@ Page Language="VB" EnableEventValidation="false" MasterPageFile="~/MasterPageSesionIniciada.master"
    AutoEventWireup="false" CodeFile="CompensacionesArchivosTXT.aspx.vb" Inherits="CompensacionesArchivosTXT"
    Title="COBAEV - Nómina - Compensaciones (Archivos TXT)" StylesheetTheme="SkinFile" %>

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
                    Sistema de nómina: Compensaciones mensuales (Archivos TXT)
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
            <td style="text-align: left">
                <ajaxToolkit:CollapsiblePanelExtender ID="CPETxts" runat="server" CollapseControlID="TitlePanelTxts"
                    Collapsed="False" CollapsedImage="~/Imagenes/expand_blue.jpg" CollapsedText="(Mostrar detalles...)"
                    ExpandControlID="TitlePanelTxts" ExpandedImage="~/Imagenes/collapse_blue.jpg"
                    ExpandedText="(Ocultar detalles...)" ImageControlID="Image3" SuppressPostBack="true"
                    TargetControlID="ContentPanelTxts" TextLabelID="Label4">
                </ajaxToolkit:CollapsiblePanelExtender>
                <asp:Panel ID="TitlePanelTxts" runat="server" BorderColor="White" BorderStyle="Solid"
                    BorderWidth="1px" CssClass="collapsePanelHeader" Width="100%">
                    <asp:Image ID="Image3" runat="server" ImageUrl="~/Imagenes/expand_blue.jpg" />
                    Archivos TXT
                    <asp:Label ID="Label4" runat="server">(Mostrar detalles...)</asp:Label>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td style="text-align: left">
                <asp:Panel ID="ContentPanelTxts" runat="server" CssClass="collapsePanel" Width="100%">
                    <table style="width:100%;">
                        <tr>
                            <td style="vertical-align: top;">
                                        <asp:Panel ID="pnlOpcDeImpresion" runat="server" Font-Names="Verdana" Font-Size="X-Small"
                                            GroupingText="Seleccione banco">
                                            <br />
                                            <asp:DropDownList ID="ddlBancos" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlBancos_SelectedIndexChanged"
                                                SkinID="SkinDropDownList">
                                            </asp:DropDownList>
                                            <asp:DropDownList ID="ddlBancosInfComp" runat="server" 
                                                SkinID="SkinDropDownList">
                                                <asp:ListItem Selected="True" Value="B">BLOQUE SELECCIONADO</asp:ListItem>
                                                <asp:ListItem Value="G">GENERAL</asp:ListItem>
                                            </asp:DropDownList>
                                            <br />
                                        </asp:Panel>
                            </td>
                        </tr>
                        <tr>
                        <td style="vertical-align: top">
                            <asp:Panel ID="pnlDatosComp" runat="server" Font-Names="Verdana" Font-Size="X-Small"
                            GroupingText="Datos complementarios para generar el archivo" HorizontalAlign="Left">
                            <table>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblCons" runat="server" Text="Consecutivo:" SkinID="SkinLbl9pt"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlCons" runat="server" SkinID="SkinDropDownList">
                                            <asp:ListItem Value="01" Text="01"></asp:ListItem>
                                            <asp:ListItem Value="02" Text="02"></asp:ListItem>
                                            <asp:ListItem Value="03" Text="03"></asp:ListItem>
                                            <asp:ListItem Value="04" Text="04"></asp:ListItem>
                                            <asp:ListItem Value="05" Text="05"></asp:ListItem>
                                            <asp:ListItem Value="06" Text="06"></asp:ListItem>
                                            <asp:ListItem Value="07" Text="07"></asp:ListItem>
                                            <asp:ListItem Value="08" Text="08"></asp:ListItem>
                                            <asp:ListItem Value="09" Text="09"></asp:ListItem>
                                            <asp:ListItem Value="10" Text="10"></asp:ListItem>
                                            <asp:ListItem Value="11" Text="11"></asp:ListItem>
                                            <asp:ListItem Value="12" Text="12"></asp:ListItem>
                                            <asp:ListItem Value="13" Text="13"></asp:ListItem>
                                            <asp:ListItem Value="14" Text="14"></asp:ListItem>
                                            <asp:ListItem Value="15" Text="15"></asp:ListItem>
                                            <asp:ListItem Value="16" Text="16"></asp:ListItem>
                                            <asp:ListItem Value="17" Text="17"></asp:ListItem>
                                            <asp:ListItem Value="18" Text="18"></asp:ListItem>
                                            <asp:ListItem Value="19" Text="19"></asp:ListItem>
                                            <asp:ListItem Value="20" Text="20"></asp:ListItem>
                                            <asp:ListItem Value="21" Text="21"></asp:ListItem>
                                            <asp:ListItem Value="22" Text="22"></asp:ListItem>
                                            <asp:ListItem Value="23" Text="23"></asp:ListItem>
                                            <asp:ListItem Value="24" Text="24"></asp:ListItem>
                                            <asp:ListItem Value="25" Text="25"></asp:ListItem>
                                            <asp:ListItem Value="26" Text="26"></asp:ListItem>
                                            <asp:ListItem Value="27" Text="27"></asp:ListItem>
                                            <asp:ListItem Value="28" Text="28"></asp:ListItem>
                                            <asp:ListItem Value="29" Text="29"></asp:ListItem>
                                            <asp:ListItem Value="30" Text="30"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblFecha" runat="server" Text="Fecha de pago:" 
                                            SkinID="SkinLbl9pt"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtbxFecha" runat="server" SkinID="skinTxtBx9pt"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender ID="txtbxFecha_CE" runat="server" Enabled="True" 
                                            TargetControlID="txtbxFecha">
                                        </ajaxToolkit:CalendarExtender>
                                        <asp:CompareValidator ID="txtbxFechaCV" runat="server" 
                                            ControlToValidate="txtbxFecha" Display="Dynamic" 
                                            ErrorMessage="Fecha no válida." Operator="DataTypeCheck" Type="Date">Fecha no válida.</asp:CompareValidator>
                                    </td>
                                </tr>
                            </table>
                           </asp:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td style="vertical-align: top">
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:ImageButton ID="ibGenerarTXT" runat="server" Height="50px" ImageUrl="~/Imagenes/GenerateAndDonwnload.png"
                                                        ToolTip="Generar archivo y Descargar" Width="50px" OnClick="ibGenerarTXT_Click" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblMsj3" runat="server" SkinID="SkinLblDatos">Generar archivo y Descargar</asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                        <ajaxToolkit:ConfirmButtonExtender ID="CBEGenerarTXT" runat="server" ConfirmText="¿Está seguro de querer generar el archivo?"
                                            TargetControlID="ibGenerarTXT">
                                        </ajaxToolkit:ConfirmButtonExtender>
                            </td>
                            <td style="vertical-align: top">
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:ImageButton ID="ibDescargar" runat="server" ImageUrl="~/Imagenes/Download.jpg"
                                                        ToolTip="Descargar archivo" OnClick="ibDescargar_Click" Visible="False" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblMsjDescargar" runat="server" SkinID="SkinLblDatos" 
                                                        Visible="False">Descargar archivo</asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                        <ajaxToolkit:ConfirmButtonExtender ID="CBEDescargarTXT" runat="server" ConfirmText="¿Está seguro de querer descargar el archivo?"
                                            TargetControlID="ibDescargar">
                                        </ajaxToolkit:ConfirmButtonExtender>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
    </table>
</ContentTemplate>
<Triggers>
    <asp:PostBackTrigger ControlID="ibGenerarTXT" />
</Triggers>
</asp:UpdatePanel>
</asp:Content>
