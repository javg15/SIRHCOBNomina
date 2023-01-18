<%@ Page Language="VB" EnableEventValidation="false" MasterPageFile="~/MasterPageSesionIniciada.master"
    AutoEventWireup="false" CodeFile="ResumenDePagoPorPeriodos.aspx.vb" Inherits="Consultas_Nomina_ResumenDePagoPorPeriodos"
    Title="COBAEV - Nómina - Resúmen de pagos por periodo" StylesheetTheme="SkinFile" %>

<%@ Register Src="~/WebControls/wucSearchEmps.ascx" TagName="wucBuscaEmpleados" TagPrefix="uc1" %>
<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress" TagPrefix="TP_wucUpdateProgress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
    <table style="width: 100%; height: 300px;" align="center">
        <tr>
            <td style="vertical-align: top; text-align: right">
                <h2>
                    Sistema de nómina: Empleados (Resúmen de pagos por periodo)
                </h2>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top; width: 100%; height: 100%; text-align: left">
                <table style="width: 100%">
                    <tr>
                        <td style="width: 100%">
                            <table style="width: 100%;">
                                <tr>
                                    <td style="vertical-align: top; text-align: left;">
                                        <uc1:wucBuscaEmpleados ID="WucBuscaEmpleados1" runat="server" EnableViewState="true">
                                        </uc1:wucBuscaEmpleados>
                                    </td>
                                    <td style="vertical-align: top; text-align: right;">
                                        <asp:ImageButton ID="ibActualizar" runat="server" ImageUrl="~/Imagenes/Refresh.jpg"
                                            ToolTip="Actualizar información" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100%">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:Panel ID="pnl1" runat="server">
                                        <table style="width: 100%">
                                            <tr>
                                                <td style="width: 100%">
                                                    <asp:Panel ID="pnlOpcionesDeConsulta" runat="server" DefaultButton="btnConsultar"
                                                        Font-Names="Verdana" Font-Size="X-Small" GroupingText="Consulta de pagos acumulados por periodo">
                                                        <br />
                                                        <table>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="LblSelAño" runat="server" SkinID="SkinLblNormal" Text="Seleccione año"></asp:Label>
                                                                </td>
                                                                <td>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlAnios" runat="server" SkinID="SkinDropDownList" AutoPostBack="True"
                                                                        OnSelectedIndexChanged="ddlAnios_SelectedIndexChanged">
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="LblSelPeriodo" runat="server" SkinID="SkinLblNormal" Text="Seleccione periodo"></asp:Label>
                                                                </td>
                                                                <td>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:DropDownList ID="ddlQnaIni" runat="server" SkinID="SkinDropDownList" AutoPostBack="True"
                                                                                OnSelectedIndexChanged="ddlQnaIni_SelectedIndexChanged">
                                                                            </asp:DropDownList>
                                                                        </ContentTemplate>
                                                                        <Triggers>
                                                                            <asp:AsyncPostBackTrigger ControlID="ddlAnios" EventName="SelectedIndexChanged" />
                                                                        </Triggers>
                                                                    </asp:UpdatePanel>
                                                                </td>
                                                                <td>
                                                                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:DropDownList ID="ddlQnaFin" runat="server" SkinID="SkinDropDownList">
                                                                            </asp:DropDownList>
                                                                        </ContentTemplate>
                                                                        <Triggers>
                                                                            <asp:AsyncPostBackTrigger ControlID="ddlAnios" EventName="SelectedIndexChanged" />
                                                                            <asp:AsyncPostBackTrigger ControlID="ddlQnaIni" EventName="SelectedIndexChanged" />
                                                                        </Triggers>
                                                                    </asp:UpdatePanel>
                                                                </td>
                                                                <td>
                                                                    <asp:Button ID="btnConsultar" runat="server" OnClick="btnConsultar_Click" SkinID="SkinBoton"
                                                                        Text="Consultar" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <br />
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ibActualizar" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="WucBuscaEmpleados1" EventName="PreRender" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100%">
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                    <asp:Panel ID="pnl2" runat="server">
                                    <ajaxToolkit:CollapsiblePanelExtender ID="CPEPercDeduc" runat="Server" CollapseControlID="TitlePanelPercDeduc"
                                        Collapsed="False" CollapsedImage="~/Imagenes/expand_blue.jpg" CollapsedText="(Mostrar detalles...)"
                                        ExpandControlID="TitlePanelPercDeduc" ExpandedImage="~/Imagenes/collapse_blue.jpg"
                                        ExpandedText="(Ocultar detalles...)" ImageControlID="Image2" SuppressPostBack="true"
                                        TargetControlID="ContentPanelPercDeduc" TextLabelID="Label2">
                                    </ajaxToolkit:CollapsiblePanelExtender>
                                    <ajaxToolkit:CollapsiblePanelExtender ID="CPETotales" runat="Server" CollapseControlID="TitlePanelTotales"
                                        Collapsed="False" CollapsedImage="~/Imagenes/expand_blue.jpg" CollapsedText="(Mostrar detalles...)"
                                        ExpandControlID="TitlePanelTotales" ExpandedImage="~/Imagenes/collapse_blue.jpg"
                                        ExpandedText="(Ocultar detalles...)" ImageControlID="Image3" SuppressPostBack="true"
                                        TargetControlID="ContentPanelTotales" TextLabelID="Label4">
                                    </ajaxToolkit:CollapsiblePanelExtender>
                                    <table style="width: 100%" cellspacing="0" cellpadding="0">
                                        <tbody>
                                            <tr>
                                                <td colspan="2" style="vertical-align: top; width: 100%; text-align: left; height: 12px;">
                                                    <asp:Label ID="LblInfDeQna" runat="server" Font-Strikeout="False" Font-Underline="True"
                                                        SkinID="SkinLblDatos" Visible="False"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="vertical-align: top; width: 100%; height: 12px; text-align: left">
                                                    <asp:LinkButton ID="lbVistaDesglosada" runat="server" PostBackUrl="~/Consultas/Nomina/ResumenDePagoPorPeriodosDesglosado.aspx"
                                                        SkinID="SkinLinkButton" Visible="False">Cambiar a vista desglosada</asp:LinkButton>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="vertical-align: top; width: 100%; text-align: left" colspan="2">
                                                    <asp:Panel ID="TitlePanelPercDeduc" runat="server" Width="100%" BorderWidth="1px"
                                                        BorderStyle="Solid" BorderColor="White" CssClass="collapsePanelHeader">
                                                        <asp:Image ID="Image2" runat="server" ImageUrl="~/Imagenes/expand_blue.jpg" />
                                                        Percepciones - Deducciones acumuladas por periodo
                                                        <asp:Label ID="Label2" runat="server">(Mostrar detalles...)</asp:Label>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="vertical-align: top; width: 100%; text-align: left" colspan="2">
                                                    <asp:Panel ID="ContentPanelPercDeduc" runat="server" Width="100%" CssClass="collapsePanel">
                                                        <table style="width: 100%" cellspacing="0" cellpadding="0">
                                                            <tbody>
                                                                <tr>
                                                                    <td style="vertical-align: top; width: 50%; text-align: left">
                                                                        <asp:GridView ID="gvPercepciones" runat="server" Width="100%" SkinID="SkinGridView"
                                                                            AutoGenerateColumns="False" EmptyDataText="Sin información de percepciones">
                                                                            <Columns>
                                                                                <asp:BoundField DataField="IdPercepcion" HeaderText="IdPercepcion" Visible="False" />
                                                                                <asp:BoundField DataField="ClavePercepcion" HeaderText="Clave"></asp:BoundField>
                                                                                <asp:BoundField DataField="NombrePercepcion" HeaderText="Percepci&#243;n"></asp:BoundField>
                                                                                <asp:BoundField DataField="Importe" DataFormatString="{0:c}" HeaderText="Importe">
                                                                                    <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                                                                </asp:BoundField>
                                                                            </Columns>
                                                                        </asp:GridView>
                                                                    </td>
                                                                    <td style="vertical-align: top; width: 50%; text-align: left">
                                                                        <asp:GridView ID="gvDeducciones" runat="server" Width="100%" SkinID="SkinGridView"
                                                                            AutoGenerateColumns="False" EmptyDataText="Sin información de deducciones">
                                                                            <Columns>
                                                                                <asp:BoundField DataField="IdDeduccion" HeaderText="IdDeduccion" Visible="False" />
                                                                                <asp:BoundField DataField="ClaveDeduccion" HeaderText="Clave"></asp:BoundField>
                                                                                <asp:BoundField DataField="NombreDeduccion" HeaderText="Deducci&#243;n"></asp:BoundField>
                                                                                <asp:BoundField DataField="Importe" DataFormatString="{0:c}" HeaderText="Importe">
                                                                                    <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                                                                </asp:BoundField>
                                                                            </Columns>
                                                                        </asp:GridView>
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="vertical-align: top; width: 100%; text-align: left" colspan="2">
                                                    <asp:Panel ID="TitlePanelTotales" runat="server" Width="100%" BorderWidth="1px" BorderStyle="Solid"
                                                        BorderColor="White" CssClass="collapsePanelHeader">
                                                        <asp:Image ID="Image3" runat="server" ImageUrl="~/Imagenes/expand_blue.jpg" />
                                                        Totales acumulados por periodo
                                                        <asp:Label ID="Label4" runat="server">(Mostrar detalles...)</asp:Label>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="vertical-align: top; width: 100%; text-align: left" colspan="2">
                                                    <asp:Panel ID="ContentPanelTotales" runat="server" Width="100%" CssClass="collapsePanel">
                                                        <table style="width: 100%" cellspacing="0" cellpadding="0">
                                                            <tbody>
                                                                <tr>
                                                                    <td style="vertical-align: top; width: 50%; text-align: left">
                                                                        <asp:DetailsView ID="dvTotalPerc" runat="server" Width="100%" SkinID="SkinDetailsView"
                                                                            EmptyDataText="No existen percepciones a sumar" AutoGenerateRows="False" Height="100%">
                                                                            <Fields>
                                                                                <asp:BoundField DataField="TotalPercepciones" DataFormatString="{0:c}" HeaderText="Total percepciones">
                                                                                    <HeaderStyle Width="50%"></HeaderStyle>
                                                                                    <ItemStyle HorizontalAlign="Right" Width="50%"></ItemStyle>
                                                                                </asp:BoundField>
                                                                            </Fields>
                                                                        </asp:DetailsView>
                                                                    </td>
                                                                    <td style="vertical-align: top; width: 50%; text-align: left">
                                                                        <asp:DetailsView ID="dvTotalDeduc" runat="server" Width="100%" SkinID="SkinDetailsView"
                                                                            EmptyDataText="No existen deducciones a sumar" AutoGenerateRows="False" Height="100%">
                                                                            <Fields>
                                                                                <asp:BoundField DataField="TotalDeducciones" DataFormatString="{0:c}" HeaderText="Total deducciones">
                                                                                    <HeaderStyle Width="50%"></HeaderStyle>
                                                                                    <ItemStyle HorizontalAlign="Right" Width="50%"></ItemStyle>
                                                                                </asp:BoundField>
                                                                            </Fields>
                                                                        </asp:DetailsView>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="vertical-align: top; width: 50%; height: 37px; text-align: center">
                                                                        <asp:LinkButton ID="lbDetallePago" runat="server" Font-Size="X-Small" Font-Names="Verdana"
                                                                            ToolTip="Ver detalle del pago" Visible="False" Text="Detalle" SkinID="SkinLinkButton"></asp:LinkButton>
                                                                    </td>
                                                                    <td style="vertical-align: top; width: 50%; height: 37px; text-align: left">
                                                                        <asp:DetailsView ID="dvNetoPagar" runat="server" Width="100%" SkinID="SkinDetailsView"
                                                                            EmptyDataText="Sin información de pago" AutoGenerateRows="False" Height="100%">
                                                                            <Fields>
                                                                                <asp:BoundField DataField="ImporteNeto" DataFormatString="{0:c}" HeaderText="Neto a pagar">
                                                                                    <HeaderStyle Width="50%"></HeaderStyle>
                                                                                    <ItemStyle HorizontalAlign="Right" Width="50%"></ItemStyle>
                                                                                </asp:BoundField>
                                                                            </Fields>
                                                                        </asp:DetailsView>
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                    </asp:Panel>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="btnConsultar" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="WucBuscaEmpleados1" EventName="PreRender" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
