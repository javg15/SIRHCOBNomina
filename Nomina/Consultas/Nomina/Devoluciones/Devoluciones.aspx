<%@ Page Language="VB" EnableEventValidation="false" MasterPageFile="~/MasterPageSesionIniciada.master"
    AutoEventWireup="false" CodeFile="Devoluciones.aspx.vb" Inherits="Consultas_Nomina_Devoluciones"
    Title="COBAEV - Nómina - Devoluciones" StylesheetTheme="SkinFile" %>

<%@ Register Src="~/WebControls/wucBuscaEmpleados.ascx" TagName="wucBuscaEmpleados"
    TagPrefix="uc1" %>
<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress"
    TagPrefix="TP_wucUpdateProgress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
    <table style="width: 100%; height: 300px" align="center">
        <tr>
            <td style="vertical-align: top; text-align: right">
                <h2>
                    Sistema de nómina: Empleados (Devoluciones de nómina quincenales)
                </h2>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top; width: 100%; height: 100%; text-align: left">
                <table style="width: 100%">
                    <tr>
                        <td style="width: 100%">
                            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                <ContentTemplate>
                                    <table style="width: 100%">
                                        <tr>
                                            <td style="width: 100%">
                                                <asp:Panel ID="pnlOpcionesDeConsulta" runat="server" Font-Size="X-Small" Font-Names="Verdana"
                                                    DefaultButton="btnConsultar" GroupingText="Consulta de devoluciones">
                                                    <br />
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label3" runat="server" SkinID="SkinLblNormal" Text="Seleccione año"></asp:Label>
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
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label2" runat="server" SkinID="SkinLblNormal" Text="Seleccione quincena"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:DropDownList ID="ddlQuincenas" runat="server" SkinID="SkinDropDownList">
                                                                        </asp:DropDownList>
                                                                    </ContentTemplate>
                                                                    <Triggers>
                                                                        <asp:AsyncPostBackTrigger ControlID="ddlAnios" EventName="SelectedIndexChanged" />
                                                                    </Triggers>
                                                                </asp:UpdatePanel>
                                                            </td>
                                                            <td>
                                                                <asp:Button ID="btnConsultar" OnClick="btnConsultar_Click" runat="server" SkinID="SkinBoton"
                                                                    Text="Consultar"></asp:Button>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                            </td>
                                            <td style="width: 100px; vertical-align: top;">
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100%">
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                    <ajaxToolkit:CollapsiblePanelExtender ID="CPEDevs" runat="Server" TextLabelID="Label1"
                                        TargetControlID="ContentPanelDevs" SuppressPostBack="true" ImageControlID="Image1"
                                        ExpandedText="(Ocultar detalles...)" ExpandedImage="~/Imagenes/collapse_blue.jpg"
                                        ExpandControlID="TitlePanelDevs" CollapsedText="(Mostrar detalles...)" CollapsedImage="~/Imagenes/expand_blue.jpg"
                                        Collapsed="False" CollapseControlID="TitlePanelDevs">
                                    </ajaxToolkit:CollapsiblePanelExtender>
                                    <table style="width: 100%" cellspacing="0" cellpadding="0">
                                        <tbody>
                                            <tr>
                                                <td style="vertical-align: top; width: 100%; text-align: left" colspan="2">
                                                    <asp:Panel ID="TitlePanelDevs" runat="server" Width="100%" BorderWidth="1px" BorderStyle="Solid"
                                                        BorderColor="White" CssClass="collapsePanelHeader">
                                                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/expand_blue.jpg"></asp:Image>
                                                        Devoluciones realizadas por año/quincena
                                                        <asp:Label ID="Label1" runat="server">
        (Mostrar detalles...)</asp:Label>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="vertical-align: top; width: 100%; text-align: left" colspan="2">
                                                    <asp:Panel ID="ContentPanelDevs" runat="server" Width="100%" CssClass="collapsePanel">
                                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                            <ContentTemplate>
                                                                <asp:GridView ID="gvDevs" runat="server" Width="100%" SkinID="SkinGridView" EmptyDataText="No existen recibos capturados"
                                                                    AutoGenerateColumns="False" OnRowDataBound="gvDevs_RowDataBound" AllowPaging="True"
                                                                    PageSize="20" OnPageIndexChanging="gvDevs_PageIndexChanging">
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="IdEmp" Visible="False">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="LblIdEmp" runat="server" Text='<%# Bind("IdEmp") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="R.F.C.">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lbRFCEmp" runat="server" CommandName="CmdRFC" Text='<%# Bind("RFCEmp") %>'></asp:LinkButton>
                                                                                <ajaxToolkit:ConfirmButtonExtender ID="CBEEmpSel" runat="server" ConfirmText="¿Seleccionar empleado para consultas posteriores?"
                                                                                    TargetControlID="lbRFCEmp">
                                                                                </ajaxToolkit:ConfirmButtonExtender>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:BoundField DataField="Empleado" HeaderText="Empleado" />
                                                                        <asp:BoundField DataField="QnaAplic" HeaderText="Quincena pago">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="Anio" HeaderText="A&#241;o">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="QnaDev" HeaderText="Quincena devoluci&#243;n">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="ImporteDevuelto" HeaderText="Importe devuelto" 
                                                                            DataFormatString="{0:c}">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                        </asp:BoundField>
                                                                    </Columns>
                                                                    <EmptyDataRowStyle Font-Italic="True" />
                                                                    <PagerSettings Mode="NumericFirstLast" Position="TopAndBottom" />
                                                                </asp:GridView>
                                                            </ContentTemplate>
                                                            <Triggers>
                                                                <asp:AsyncPostBackTrigger ControlID="gvDevs" EventName="PageIndexChanging" />
                                                            </Triggers>
                                                        </asp:UpdatePanel>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="vertical-align: top; width: 100%; text-align: left" colspan="2">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="vertical-align: top; width: 100%; text-align: left" colspan="2">
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="btnConsultar" EventName="Click"></asp:AsyncPostBackTrigger>
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
