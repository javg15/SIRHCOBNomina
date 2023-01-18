<%@ page language="VB" enableeventvalidation="false" masterpagefile="~/MasterPageSesionIniciada.master" autoeventwireup="false" inherits="Consultas_Empleados_DetallePago, App_Web_00vntztu" title="COBAEV - Nómina - Detalle de pago por empleado" stylesheettheme="SkinFile" maintainScrollPositionOnPostBack="true" %>

<%@ Register Src="~/WebControls/wucSearchEmps.ascx" TagName="wucBuscaEmpleados" TagPrefix="uc1" %>
<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress" TagPrefix="TP_wucUpdateProgress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
    <table style="width: 100%" align="center">
        <tr>
            <td style="vertical-align: top; text-align: right">
                <h2>
                    Sistema de nómina: Detalle de pago semestral (Empleados docentes)
                </h2>
            </td>
        </tr>
        <tr>
            <td style="text-align: left;">
                <table style="width: 100%">
                    <tr>
                        <td style="vertical-align: top; text-align: left">
                            <uc1:wucBuscaEmpleados ID="WucBuscaEmpleados1" runat="server" EnableViewState="true">
                            </uc1:wucBuscaEmpleados>
                        </td>
                        <td style="vertical-align: top; text-align: right">
                            <asp:ImageButton ID="ibActualizar" runat="server" ImageUrl="~/Imagenes/Refresh.jpg"
                                ToolTip="Actualizar información" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="text-align: left;">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="pnl1" runat="server">
                            <asp:Label ID="lblEmpInf" runat="server" Font-Strikeout="False" Font-Underline="True"
                                SkinID="SkinLblDatos" Visible="False"></asp:Label><br />
                            <asp:Panel ID="pnlSemestres" runat="server" DefaultButton="btnDetallePago" Font-Names="Verdana"
                                Font-Size="X-Small" GroupingText="Seleccione semestre">
                                <br />
                                <asp:DropDownList ID="ddlSemestres" runat="server" SkinID="SkinDropDownList">
                                </asp:DropDownList>
                                <asp:Button ID="btnDetallePago" runat="server" SkinID="SkinBoton" Text="Detalle de pago"
                                    ToolTip="Consultar detalle de pago para el semestre seleccionado" OnClick="btnDetallePago_Click" /><br />
                                <br />
                            </asp:Panel>
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
            <td style="width: 100%; text-align: left;">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="pnl2" runat="server">
                            <ajaxToolkit:CollapsiblePanelExtender ID="CPEDetallePago" runat="Server" CollapseControlID="TitlePanelDetallePago"
                                Collapsed="False" CollapsedImage="~/Imagenes/expand_blue.jpg" CollapsedText="(Mostrar detalles...)"
                                ExpandControlID="TitlePanelDetallePago" ExpandedImage="~/Imagenes/collapse_blue.jpg"
                                ExpandedText="(Ocultar detalles...)" ImageControlID="Image1" SuppressPostBack="true"
                                TargetControlID="ContentPanelDetallePago" TextLabelID="Label1">
                            </ajaxToolkit:CollapsiblePanelExtender>
                            <table cellpadding="0" cellspacing="0" style="width: 100%">
                                <tbody>
                                    <tr>
                                        <td colspan="2" style="vertical-align: top; width: 100%; text-align: left">
                                            <asp:Panel ID="TitlePanelDetallePago" runat="server" BorderColor="White" BorderStyle="Solid"
                                                BorderWidth="1px" CssClass="collapsePanelHeader" Width="100%">
                                                <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/expand_blue.jpg" />
                                                Detalle de pago histórico
                                                <asp:Label ID="Label1" runat="server">(Mostrar detalles...)</asp:Label>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" style="vertical-align: top; width: 100%; text-align: left">
                                            <asp:Panel ID="ContentPanelDetallePago" runat="server" CssClass="collapsePanel" Width="100%">
                                                <asp:GridView ID="gvDetallePago" runat="server" CellPadding="1" SkinID="SkinGridView"
                                                    Width="100%" EmptyDataText="No existe detalle de pago para el semestre seleccionado.">
                                                    <Columns>
                                                        <asp:BoundField DataField="Semestre" HeaderText="Semestre">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Quincena" HeaderText="Quincena">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="ClaveCategoria" HeaderText="Clave categor&#237;a">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="DescCategoria" HeaderText="Categor&#237;a">
                                                            <ItemStyle Wrap="False" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="ClaveZonaEco" HeaderText="Zona econ&#243;mica">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                    </Columns>
                                                </asp:GridView>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </asp:Panel>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnDetallePago" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="WucBuscaEmpleados1" EventName="PreRender" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>
