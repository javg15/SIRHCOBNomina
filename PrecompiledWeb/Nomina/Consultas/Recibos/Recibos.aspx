<%@ page language="VB" enableeventvalidation="false" masterpagefile="~/MasterPageSesionIniciada.master" autoeventwireup="false" inherits="Consultas_Recibos, App_Web_n4f25cef" title="COBAEV - Nómina - Recibos" stylesheettheme="SkinFile" maintainScrollPositionOnPostBack="true" %>

<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress" TagPrefix="TP_wucUpdateProgress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
    <table style="width: 100%; height: 300px" align="center">
        <tr>
            <td style="vertical-align: top; text-align: right">
                <h2>
                    Sistema de nómina: Recibos de pago fuera de nómina
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
                                        <tbody>
                                            <tr>
                                                <td style="width: 100%">
                                                    <asp:Panel ID="pnlOpcionesDeConsulta" runat="server" Font-Size="X-Small" Font-Names="Verdana"
                                                        GroupingText="Consulta de recibos" DefaultButton="btnConsultarAnio">
                                                        <br />
                                                        <table>
                                                            <tbody>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="Label2" runat="server" Text="Seleccione año" SkinID="SkinLblNormal"></asp:Label>
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
                                                                        <asp:Label ID="Label4" runat="server" Text="Seleccione quincena" SkinID="SkinLblNormal"></asp:Label>
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
                                                                                <asp:AsyncPostBackTrigger ControlID="ddlAnios" EventName="SelectedIndexChanged">
                                                                                </asp:AsyncPostBackTrigger>
                                                                            </Triggers>
                                                                        </asp:UpdatePanel>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Button ID="btnConsultarAnio" OnClick="btnConsultarAnio_Click" runat="server"
                                                                            Text="Consultar" SkinID="SkinBoton"></asp:Button>
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                        <br />
                                                    </asp:Panel>
                                                </td>
                                                <td style="vertical-align: top; width: 100px; text-align: center">
                                                    <asp:ImageButton ID="ibRefresh" OnClick="ibRefresh_Click" runat="server" ImageUrl="~/Imagenes/Refresh.jpg"
                                                        ToolTip="Actualizar información"></asp:ImageButton>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ibRefresh" EventName="Click"></asp:AsyncPostBackTrigger>
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100%">
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                    <ajaxToolkit:CollapsiblePanelExtender ID="CPERecibos" runat="Server" TextLabelID="Label1"
                                        TargetControlID="ContentPaneRecibos" SuppressPostBack="true" ImageControlID="Image1"
                                        ExpandedText="(Ocultar detalles...)" ExpandedImage="~/Imagenes/collapse_blue.jpg"
                                        ExpandControlID="TitlePanelRecibos" CollapsedText="(Mostrar detalles...)" CollapsedImage="~/Imagenes/expand_blue.jpg"
                                        Collapsed="False" CollapseControlID="TitlePanelRecibos">
                                    </ajaxToolkit:CollapsiblePanelExtender>
                                    <table style="width: 100%" cellspacing="0" cellpadding="0">
                                        <tbody>
                                            <tr>
                                                <td colspan="2" style="vertical-align: top; width: 100%; text-align: left">
                                                    <br />
                                                    <asp:LinkButton ID="lbCrearRecibo" runat="server" SkinID="SkinLinkButton" OnClick="lbCrearRecibo_Click">Crear nuevo recibo</asp:LinkButton>&nbsp;
                                                    <asp:LinkButton ID="lbEmpleadosRecibos" runat="server" PostBackUrl="~/Consultas/Recibos/EmpleadosRecibos.aspx?TipoOperacion=4"
                                                        SkinID="SkinLinkButton" ToolTip="Ver un listado de empleados a los cuales se les pueden generar actualmente recibos.">Empleados para recibos</asp:LinkButton>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="vertical-align: top; width: 100%; text-align: left" colspan="2">
                                                    <asp:Panel ID="TitlePanelRecibos" runat="server" Width="100%" BorderWidth="1px" BorderStyle="Solid"
                                                        BorderColor="White" CssClass="collapsePanelHeader">
                                                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/expand_blue.jpg"></asp:Image>
                                                        Recibos expedidos por año/quincena
                                                        <asp:Label ID="Label1" runat="server">
        (Mostrar detalles...)</asp:Label>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="vertical-align: top; width: 100%; text-align: left" colspan="2">
                                                    <asp:Panel ID="ContentPaneRecibos" runat="server" Width="100%" CssClass="collapsePanel">
                                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                            <ContentTemplate>
                                                                <asp:GridView ID="gvRecibos" runat="server" Width="100%" SkinID="SkinGridView" EmptyDataText="No existen recibos capturados"
                                                                    AutoGenerateColumns="False" OnRowCommand="gvRecibos_RowCommand" 
                                                                    OnRowDataBound="gvRecibos_RowDataBound">
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="IdQuincena" Visible="False">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblIdRecibo" runat="server" Text='<%# Bind("IdRecibo") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:BoundField DataField="NumRecibo" HeaderText="Recibo">
                                                                            <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="NomEmp" HeaderText="Empleado" />
                                                                        <asp:BoundField DataField="FechaRealDePago" HeaderText="Fecha real de pago" DataFormatString="{0:d}">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="Anio" HeaderText="A&#241;o">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="DescTipoRecibo" HeaderText="Tipo" />
                                                                        <asp:BoundField DataField="DescEstatusRecibo" HeaderText="Estatus" />
                                                                        <asp:TemplateField HeaderText="IdUsuario" Visible="False">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblIdUsuario" runat="server" Text='<%# Bind("IdUsuario") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Usuario creador">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblUsuario" runat="server"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:BoundField DataField="QnaDeDevol" HeaderText="Qna. Devol.">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="ReciboTimbrado" HeaderText="Timbrado">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                        </asp:BoundField>
                                                                        <asp:TemplateField>
                                                                            <ItemTemplate>
                                                                                <asp:ImageButton ID="ibEliminar" runat="server" CommandName="CmdEliminar" ImageUrl="~/Imagenes/Eliminar.png"
                                                                                    ToolTip="Eliminar éste recibo" />
                                                                                <ajaxToolkit:ConfirmButtonExtender ID="CBEEliminar" runat="server" ConfirmText="Ésta operación eliminará el registro definitivamente, ¿Continuar?"
                                                                                    TargetControlID="ibEliminar">
                                                                                </ajaxToolkit:ConfirmButtonExtender>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField>
                                                                            <ItemTemplate>
                                                                                <asp:ImageButton ID="ibModificar" runat="server" ImageUrl="~/Imagenes/Modificar.png"
                                                                                    CommandName="CmdModificar" ToolTip="Modificar la información de éste recibo" />
                                                                            </ItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField>
                                                                            <ItemTemplate>
                                                                                <asp:ImageButton ID="ibConsultaDetalles" runat="server" ImageUrl="~/Imagenes/Detalles.gif"
                                                                                    ToolTip="Consultar los detalles del recibo" />
                                                                            </ItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField>
                                                                            <ItemTemplate>
                                                                                <asp:ImageButton ID="ibCapturar" runat="server" ImageUrl="~/Imagenes/Captura1.jpg"
                                                                                    ToolTip="Capturar/Modificar la informacion complementaria del recibo" />
                                                                            </ItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="IdEstatusRecibo" Visible="False">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblIdEstatusRecibo" runat="server" Text='<%# Bind("IdEstatusRecibo") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                    <EmptyDataRowStyle Font-Italic="True" />
                                                                    <PagerSettings Mode="NumericFirstLast" Position="TopAndBottom" />
                                                                </asp:GridView>
                                                            </ContentTemplate>
                                                            <Triggers>
                                                                <asp:AsyncPostBackTrigger ControlID="gvRecibos" EventName="PageIndexChanging" />
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
                                    <asp:AsyncPostBackTrigger ControlID="btnConsultarAnio" EventName="Click"></asp:AsyncPostBackTrigger>
                                    <asp:AsyncPostBackTrigger ControlID="lbCrearRecibo" EventName="Click" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
