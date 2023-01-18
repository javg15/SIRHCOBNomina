<%@ Page Language="VB" EnableEventValidation="false" MasterPageFile="~/MasterPageSesionIniciada.master"
    AutoEventWireup="false" CodeFile="ResumenDePagoPorPeriodosDesglosado.aspx.vb"
    Inherits="Consultas_Nomina_ResumenDePagoPorPeriodosDesglosado" Title="COBAEV - Nómina - Resúmen de pagos por periodo"
    StylesheetTheme="SkinFile" %>

<%@ Register Src="~/WebControls/wucSearchEmps.ascx" TagName="wucBuscaEmpleados" TagPrefix="uc1" %>
<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress" TagPrefix="TP_wucUpdateProgress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
    <table style="width: 100%; height: 300px;" align="center">
        <tr>
            <td style="vertical-align: top; text-align: right">
                <h2>
                    Sistema de nómina: Empleados (Resúmen de pagos desglosado por periodo)
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
                                    <ajaxToolkit:CollapsiblePanelExtender ID="CPEPercDeducNomina" runat="Server" CollapseControlID="TitlePnlPercDeducNomina"
                                        Collapsed="False" CollapsedImage="~/Imagenes/expand_blue.jpg" CollapsedText="(Mostrar detalles...)"
                                        ExpandControlID="TitlePnlPercDeducNomina" ExpandedImage="~/Imagenes/collapse_blue.jpg"
                                        ExpandedText="(Ocultar detalles...)" ImageControlID="ImgNomina" SuppressPostBack="true"
                                        TargetControlID="ContentPnlPercDeducNomina" TextLabelID="LblNomina">
                                    </ajaxToolkit:CollapsiblePanelExtender>
                                    <ajaxToolkit:CollapsiblePanelExtender ID="CPETotalesNomina" runat="Server" CollapseControlID="TitlePnlTotalesNomina"
                                        Collapsed="False" CollapsedImage="~/Imagenes/expand_blue.jpg" CollapsedText="(Mostrar detalles...)"
                                        ExpandControlID="TitlePnlTotalesNomina" ExpandedImage="~/Imagenes/collapse_blue.jpg"
                                        ExpandedText="(Ocultar detalles...)" ImageControlID="ImgNomina2" SuppressPostBack="true"
                                        TargetControlID="ContentPnlTotalesNomina" TextLabelID="LblNomina2">
                                    </ajaxToolkit:CollapsiblePanelExtender>
                                    <ajaxToolkit:CollapsiblePanelExtender ID="CPEPercDeducRecibos" runat="Server" CollapseControlID="TitlePnlPercDeducRecibos"
                                        Collapsed="False" CollapsedImage="~/Imagenes/expand_blue.jpg" CollapsedText="(Mostrar detalles...)"
                                        ExpandControlID="TitlePnlPercDeducRecibos" ExpandedImage="~/Imagenes/collapse_blue.jpg"
                                        ExpandedText="(Ocultar detalles...)" ImageControlID="ImgRecibos" SuppressPostBack="true"
                                        TargetControlID="ContentPnlPercDeducRecibos" TextLabelID="LblRecibos">
                                    </ajaxToolkit:CollapsiblePanelExtender>
                                    <ajaxToolkit:CollapsiblePanelExtender ID="CPETotalesRecibos" runat="Server" CollapseControlID="TitlePnlTotalesRecibos"
                                        Collapsed="False" CollapsedImage="~/Imagenes/expand_blue.jpg" CollapsedText="(Mostrar detalles...)"
                                        ExpandControlID="TitlePnlTotalesRecibos" ExpandedImage="~/Imagenes/collapse_blue.jpg"
                                        ExpandedText="(Ocultar detalles...)" ImageControlID="ImgRecibos2" SuppressPostBack="true"
                                        TargetControlID="ContentPnlTotalesRecibos" TextLabelID="LblRecibos2">
                                    </ajaxToolkit:CollapsiblePanelExtender>
                                    <ajaxToolkit:CollapsiblePanelExtender ID="CPEPercDeducDevols" runat="Server" CollapseControlID="TitlePnlPercDeducDevols"
                                        Collapsed="False" CollapsedImage="~/Imagenes/expand_blue.jpg" CollapsedText="(Mostrar detalles...)"
                                        ExpandControlID="TitlePnlPercDeducDevols" ExpandedImage="~/Imagenes/collapse_blue.jpg"
                                        ExpandedText="(Ocultar detalles...)" ImageControlID="ImgDevols" SuppressPostBack="true"
                                        TargetControlID="ContentPnlPercDeducDevols" TextLabelID="LblDevols">
                                    </ajaxToolkit:CollapsiblePanelExtender>
                                    <ajaxToolkit:CollapsiblePanelExtender ID="CPETotalesDevols" runat="Server" CollapseControlID="TitlePnlTotalesDevols"
                                        Collapsed="False" CollapsedImage="~/Imagenes/expand_blue.jpg" CollapsedText="(Mostrar detalles...)"
                                        ExpandControlID="TitlePnlTotalesDevols" ExpandedImage="~/Imagenes/collapse_blue.jpg"
                                        ExpandedText="(Ocultar detalles...)" ImageControlID="ImgDevols2" SuppressPostBack="true"
                                        TargetControlID="ContentPnlTotalesDevols" TextLabelID="LblDevols2">
                                    </ajaxToolkit:CollapsiblePanelExtender>
                                    <ajaxToolkit:CollapsiblePanelExtender ID="CPEPercDeduc" runat="Server" CollapseControlID="TitlePnlPercDeduc"
                                        Collapsed="False" CollapsedImage="~/Imagenes/expand_blue.jpg" CollapsedText="(Mostrar detalles...)"
                                        ExpandControlID="TitlePnlPercDeduc" ExpandedImage="~/Imagenes/collapse_blue.jpg"
                                        ExpandedText="(Ocultar detalles...)" ImageControlID="ImgTotales" SuppressPostBack="true"
                                        TargetControlID="ContentPnlPercDeduc" TextLabelID="LblTotales">
                                    </ajaxToolkit:CollapsiblePanelExtender>
                                    <ajaxToolkit:CollapsiblePanelExtender ID="CPETotales" runat="Server" CollapseControlID="TitlePnlTotales"
                                        Collapsed="False" CollapsedImage="~/Imagenes/expand_blue.jpg" CollapsedText="(Mostrar detalles...)"
                                        ExpandControlID="TitlePnlTotales" ExpandedImage="~/Imagenes/collapse_blue.jpg"
                                        ExpandedText="(Ocultar detalles...)" ImageControlID="ImgTotales2" SuppressPostBack="true"
                                        TargetControlID="ContentPnlTotales" TextLabelID="LblTotales2">
                                    </ajaxToolkit:CollapsiblePanelExtender>
                                    <table style="width: 100%" cellspacing="0" cellpadding="0">
                                        <tbody>
                                            <tr>
                                                <td colspan="2" style="vertical-align: top; width: 100%; text-align: left">
                                                    <asp:Label ID="LblInfDeQna" runat="server" Font-Strikeout="False" Font-Underline="True"
                                                        SkinID="SkinLblDatos" Visible="False"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="vertical-align: top; width: 100%; height: 16px; text-align: left">
                                                    <asp:LinkButton ID="lbVistaNormal" runat="server" PostBackUrl="~/Consultas/Nomina/ResumenDePagoPorPeriodos.aspx"
                                                        SkinID="SkinLinkButton" Visible="False">Cambiar a  vista normal</asp:LinkButton>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="vertical-align: top; width: 100%; text-align: left" colspan="2">
                                                    <asp:Panel ID="TitlePnlPercDeducNomina" runat="server" Width="100%" BorderWidth="1px"
                                                        BorderStyle="Solid" BorderColor="White" CssClass="collapsePanelHeader">
                                                        <asp:Image ID="ImgNomina" runat="server" ImageUrl="~/Imagenes/expand_blue.jpg" />
                                                        Nómina: Percepciones/Deducciones acumuladas por periodo
                                                        <asp:Label ID="LblNomina" runat="server">(Mostrar detalles...)</asp:Label>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="vertical-align: top; width: 100%; text-align: left" colspan="2">
                                                    <asp:Panel ID="ContentPnlPercDeducNomina" runat="server" Width="100%" CssClass="collapsePanel">
                                                        <table style="width: 100%" cellspacing="0" cellpadding="0">
                                                            <tbody>
                                                                <tr>
                                                                    <td style="vertical-align: top; width: 50%; text-align: left">
                                                                        <asp:GridView ID="gvPercsNomina" runat="server" Width="100%" SkinID="SkinGridView"
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
                                                                        <asp:GridView ID="gvDeducsNomina" runat="server" Width="100%" SkinID="SkinGridView"
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
                                                    <asp:Panel ID="TitlePnlTotalesNomina" runat="server" Width="100%" BorderWidth="1px"
                                                        BorderStyle="Solid" BorderColor="White" CssClass="collapsePanelHeader">
                                                        <asp:Image ID="ImgNomina2" runat="server" ImageUrl="~/Imagenes/expand_blue.jpg" />
                                                        Nómina: Totales acumulados por periodo
                                                        <asp:Label ID="LblNomina2" runat="server">(Mostrar detalles...)</asp:Label>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="vertical-align: top; width: 100%; text-align: left" colspan="2">
                                                    <asp:Panel ID="ContentPnlTotalesNomina" runat="server" Width="100%" CssClass="collapsePanel">
                                                        <table style="width: 100%" cellspacing="0" cellpadding="0">
                                                            <tbody>
                                                                <tr>
                                                                    <td style="vertical-align: top; width: 50%; text-align: left">
                                                                        <asp:DetailsView ID="dvTotalPercsNomina" runat="server" Width="100%" SkinID="SkinDetailsView"
                                                                            EmptyDataText="No existen percepciones a sumar" AutoGenerateRows="False" Height="100%">
                                                                            <Fields>
                                                                                <asp:BoundField DataField="TotalPercepcionesNomina" DataFormatString="{0:c}" HeaderText="Total percepciones">
                                                                                    <HeaderStyle Width="50%"></HeaderStyle>
                                                                                    <ItemStyle HorizontalAlign="Right" Width="50%"></ItemStyle>
                                                                                </asp:BoundField>
                                                                            </Fields>
                                                                        </asp:DetailsView>
                                                                    </td>
                                                                    <td style="vertical-align: top; width: 50%; text-align: left">
                                                                        <asp:DetailsView ID="dvTotalDeducsNomina" runat="server" Width="100%" SkinID="SkinDetailsView"
                                                                            EmptyDataText="No existen deducciones a sumar" AutoGenerateRows="False" Height="100%">
                                                                            <Fields>
                                                                                <asp:BoundField DataField="TotalDeduccionesNomina" DataFormatString="{0:c}" HeaderText="Total deducciones">
                                                                                    <HeaderStyle Width="50%"></HeaderStyle>
                                                                                    <ItemStyle HorizontalAlign="Right" Width="50%"></ItemStyle>
                                                                                </asp:BoundField>
                                                                            </Fields>
                                                                        </asp:DetailsView>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="vertical-align: top; width: 50%; height: 37px; text-align: center">
                                                                    </td>
                                                                    <td style="vertical-align: top; width: 50%; height: 37px; text-align: left">
                                                                        <asp:DetailsView ID="dvImporteNetoNomina" runat="server" Width="100%" SkinID="SkinDetailsView"
                                                                            EmptyDataText="Sin información de pago" AutoGenerateRows="False" Height="100%">
                                                                            <Fields>
                                                                                <asp:BoundField DataField="ImporteNetoNomina" DataFormatString="{0:c}" HeaderText="Importe neto">
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
                                            <!--Fin-->
                                            <tr>
                                                <td style="vertical-align: top; width: 100%; text-align: left" colspan="2">
                                                    <asp:Panel ID="TitlePnlPercDeducRecibos" runat="server" Width="100%" BorderWidth="1px"
                                                        BorderStyle="Solid" BorderColor="White" CssClass="collapsePanelHeader">
                                                        <asp:Image ID="ImgRecibos" runat="server" ImageUrl="~/Imagenes/expand_blue.jpg" />
                                                        Recibos: Percepciones/Deducciones acumuladas por periodo
                                                        <asp:Label ID="LblRecibos" runat="server">(Mostrar detalles...)</asp:Label>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="vertical-align: top; width: 100%; text-align: left" colspan="2">
                                                    <asp:Panel ID="ContentPnlPercDeducRecibos" runat="server" Width="100%" CssClass="collapsePanel">
                                                        <table style="width: 100%" cellspacing="0" cellpadding="0">
                                                            <tbody>
                                                                <tr>
                                                                    <td style="vertical-align: top; width: 50%; text-align: left">
                                                                        <asp:GridView ID="gvPercsRecibos" runat="server" Width="100%" SkinID="SkinGridView"
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
                                                                        <asp:GridView ID="gvDeducsRecibos" runat="server" Width="100%" SkinID="SkinGridView"
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
                                                    <asp:Panel ID="TitlePnlTotalesRecibos" runat="server" Width="100%" BorderWidth="1px"
                                                        BorderStyle="Solid" BorderColor="White" CssClass="collapsePanelHeader">
                                                        <asp:Image ID="ImgRecibos2" runat="server" ImageUrl="~/Imagenes/expand_blue.jpg" />
                                                        Recibos: Totales acumulados por periodo
                                                        <asp:Label ID="LblRecibos2" runat="server">(Mostrar detalles...)</asp:Label>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="vertical-align: top; width: 100%; text-align: left" colspan="2">
                                                    <asp:Panel ID="ContentPnlTotalesRecibos" runat="server" Width="100%" CssClass="collapsePanel">
                                                        <table style="width: 100%" cellspacing="0" cellpadding="0">
                                                            <tbody>
                                                                <tr>
                                                                    <td style="vertical-align: top; width: 50%; text-align: left">
                                                                        <asp:DetailsView ID="dvTotalPercsRecibos" runat="server" Width="100%" SkinID="SkinDetailsView"
                                                                            EmptyDataText="No existen percepciones a sumar" AutoGenerateRows="False" Height="100%">
                                                                            <Fields>
                                                                                <asp:BoundField DataField="TotalPercepcionesRecibos" DataFormatString="{0:c}" HeaderText="Total percepciones">
                                                                                    <HeaderStyle Width="50%"></HeaderStyle>
                                                                                    <ItemStyle HorizontalAlign="Right" Width="50%"></ItemStyle>
                                                                                </asp:BoundField>
                                                                            </Fields>
                                                                        </asp:DetailsView>
                                                                    </td>
                                                                    <td style="vertical-align: top; width: 50%; text-align: left">
                                                                        <asp:DetailsView ID="dvTotalDeducsRecibos" runat="server" Width="100%" SkinID="SkinDetailsView"
                                                                            EmptyDataText="No existen deducciones a sumar" AutoGenerateRows="False" Height="100%">
                                                                            <Fields>
                                                                                <asp:BoundField DataField="TotalDeduccionesRecibos" DataFormatString="{0:c}" HeaderText="Total deducciones">
                                                                                    <HeaderStyle Width="50%"></HeaderStyle>
                                                                                    <ItemStyle HorizontalAlign="Right" Width="50%"></ItemStyle>
                                                                                </asp:BoundField>
                                                                            </Fields>
                                                                        </asp:DetailsView>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="vertical-align: top; width: 50%; height: 37px; text-align: center">
                                                                    </td>
                                                                    <td style="vertical-align: top; width: 50%; height: 37px; text-align: left">
                                                                        <asp:DetailsView ID="dvImporteNetoRecibos" runat="server" Width="100%" SkinID="SkinDetailsView"
                                                                            EmptyDataText="Sin información de pago" AutoGenerateRows="False" Height="100%">
                                                                            <Fields>
                                                                                <asp:BoundField DataField="ImporteNetoRecibos" DataFormatString="{0:c}" HeaderText="Importe neto">
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
                                            <!--Fin-->
                                            <tr>
                                                <td style="vertical-align: top; width: 100%; text-align: left" colspan="2">
                                                    <asp:Panel ID="TitlePnlPercDeducDevols" runat="server" Width="100%" BorderWidth="1px"
                                                        BorderStyle="Solid" BorderColor="White" CssClass="collapsePanelHeader">
                                                        <asp:Image ID="ImgDevols" runat="server" ImageUrl="~/Imagenes/expand_blue.jpg" />
                                                        Devoluciones: Percepciones/Deducciones acumuladas por periodo
                                                        <asp:Label ID="LblDevols" runat="server">(Mostrar detalles...)</asp:Label>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="vertical-align: top; width: 100%; text-align: left" colspan="2">
                                                    <asp:Panel ID="ContentPnlPercDeducDevols" runat="server" Width="100%" CssClass="collapsePanel">
                                                        <table style="width: 100%" cellspacing="0" cellpadding="0">
                                                            <tbody>
                                                                <tr>
                                                                    <td style="vertical-align: top; width: 50%; text-align: left">
                                                                        <asp:GridView ID="gvPercsDevols" runat="server" Width="100%" SkinID="SkinGridView"
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
                                                                        <asp:GridView ID="gvDeducsDevols" runat="server" Width="100%" SkinID="SkinGridView"
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
                                                    <asp:Panel ID="TitlePnlTotalesDevols" runat="server" Width="100%" BorderWidth="1px"
                                                        BorderStyle="Solid" BorderColor="White" CssClass="collapsePanelHeader">
                                                        <asp:Image ID="ImgDevols2" runat="server" ImageUrl="~/Imagenes/expand_blue.jpg" />
                                                        Devoluciones: Totales acumulados por periodo
                                                        <asp:Label ID="LblDevols2" runat="server">(Mostrar detalles...)</asp:Label>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="vertical-align: top; width: 100%; text-align: left" colspan="2">
                                                    <asp:Panel ID="ContentPnlTotalesDevols" runat="server" Width="100%" CssClass="collapsePanel">
                                                        <table style="width: 100%" cellspacing="0" cellpadding="0">
                                                            <tbody>
                                                                <tr>
                                                                    <td style="vertical-align: top; width: 50%; text-align: left">
                                                                        <asp:DetailsView ID="dvTotalPercsDevols" runat="server" Width="100%" SkinID="SkinDetailsView"
                                                                            EmptyDataText="No existen percepciones a sumar" AutoGenerateRows="False" Height="100%">
                                                                            <Fields>
                                                                                <asp:BoundField DataField="TotalPercepcionesDevols" DataFormatString="{0:c}" HeaderText="Total percepciones">
                                                                                    <HeaderStyle Width="50%"></HeaderStyle>
                                                                                    <ItemStyle HorizontalAlign="Right" Width="50%"></ItemStyle>
                                                                                </asp:BoundField>
                                                                            </Fields>
                                                                        </asp:DetailsView>
                                                                    </td>
                                                                    <td style="vertical-align: top; width: 50%; text-align: left">
                                                                        <asp:DetailsView ID="dvTotalDeducsDevols" runat="server" Width="100%" SkinID="SkinDetailsView"
                                                                            EmptyDataText="No existen deducciones a sumar" AutoGenerateRows="False" Height="100%">
                                                                            <Fields>
                                                                                <asp:BoundField DataField="TotalDeduccionesDevols" DataFormatString="{0:c}" HeaderText="Total deducciones">
                                                                                    <HeaderStyle Width="50%"></HeaderStyle>
                                                                                    <ItemStyle HorizontalAlign="Right" Width="50%"></ItemStyle>
                                                                                </asp:BoundField>
                                                                            </Fields>
                                                                        </asp:DetailsView>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="vertical-align: top; width: 50%; height: 37px; text-align: center">
                                                                    </td>
                                                                    <td style="vertical-align: top; width: 50%; height: 37px; text-align: left">
                                                                        <asp:DetailsView ID="dvImporteNetoDevols" runat="server" Width="100%" SkinID="SkinDetailsView"
                                                                            EmptyDataText="Sin información de pago" AutoGenerateRows="False" Height="100%">
                                                                            <Fields>
                                                                                <asp:BoundField DataField="ImporteNetoDevols" DataFormatString="{0:c}" HeaderText="Importe neto">
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
                                            <tr>
                                                <td style="vertical-align: top; width: 100%; text-align: left" colspan="2">
                                                    <asp:Panel ID="TitlePnlPercDeduc" runat="server" Width="100%" BorderWidth="1px" BorderStyle="Solid"
                                                        BorderColor="White" CssClass="collapsePanelHeader">
                                                        <asp:Image ID="ImgTotales" runat="server" ImageUrl="~/Imagenes/expand_blue.jpg" />
                                                        Resúmen: Percepciones/Deducciones acumuladas por periodo
                                                        <asp:Label ID="LblTotales" runat="server">(Mostrar detalles...)</asp:Label>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="vertical-align: top; width: 100%; text-align: left" colspan="2">
                                                    <asp:Panel ID="ContentPnlPercDeduc" runat="server" Width="100%" CssClass="collapsePanel">
                                                        <table style="width: 100%" cellspacing="0" cellpadding="0">
                                                            <tbody>
                                                                <tr>
                                                                    <td style="vertical-align: top; width: 50%; text-align: left">
                                                                        <asp:GridView ID="gvPercs" runat="server" Width="100%" SkinID="SkinGridView" AutoGenerateColumns="False"
                                                                            EmptyDataText="Sin información de percepciones">
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
                                                                        <asp:GridView ID="gvDeducs" runat="server" Width="100%" SkinID="SkinGridView" AutoGenerateColumns="False"
                                                                            EmptyDataText="Sin información de deducciones">
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
                                                    <asp:Panel ID="TitlePnlTotales" runat="server" Width="100%" BorderWidth="1px" BorderStyle="Solid"
                                                        BorderColor="White" CssClass="collapsePanelHeader">
                                                        <asp:Image ID="ImgTotales2" runat="server" ImageUrl="~/Imagenes/expand_blue.jpg" />
                                                        Resúmen: Totales acumulados por periodo
                                                        <asp:Label ID="LblTotales2" runat="server">(Mostrar detalles...)</asp:Label>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="vertical-align: top; width: 100%; text-align: left" colspan="2">
                                                    <asp:Panel ID="ContentPnlTotales" runat="server" Width="100%" CssClass="collapsePanel">
                                                        <table style="width: 100%" cellspacing="0" cellpadding="0">
                                                            <tbody>
                                                                <tr>
                                                                    <td style="vertical-align: top; width: 50%; text-align: left">
                                                                        <asp:DetailsView ID="dvTotalesPercs" runat="server" Width="100%" SkinID="SkinDetailsView"
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
                                                                        <asp:DetailsView ID="dvTotalesDeducs" runat="server" Width="100%" SkinID="SkinDetailsView"
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
                                                                    </td>
                                                                    <td style="vertical-align: top; width: 50%; height: 37px; text-align: left">
                                                                        <asp:DetailsView ID="dvTotales" runat="server" Width="100%" SkinID="SkinDetailsView"
                                                                            EmptyDataText="Sin información de pago" AutoGenerateRows="False" Height="100%">
                                                                            <Fields>
                                                                                <asp:BoundField DataField="ImporteNeto" DataFormatString="{0:c}" HeaderText="Importe neto">
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
