<%@ page language="VB" enableeventvalidation="false" masterpagefile="~/MasterPageSesionIniciada.master" autoeventwireup="false" inherits="Consultas_Nomina_Devoluciones, App_Web_xh1ifbg5" title="COBAEV - Nómina - Devoluciones quincenales" stylesheettheme="SkinFile" maintainScrollPositionOnPostBack="true" %>

<%@ Register Src="~/WebControls/wucBuscaEmpleados.ascx" TagName="wucBuscaEmpleados"
    TagPrefix="uc1" %>
<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress" TagPrefix="TP_wucUpdateProgress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
    <table style="width: 100%; height: 300px" align="center">
        <tr>
            <td style="vertical-align: top; text-align: right">
                <h2>
                    Sistema de nómina: Empleados para descuento de devoluciones quincenales
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
                                                    DefaultButton="btnConsultarQna" GroupingText="Consulta de devoluciones">
                                                    <br />
                                                    <asp:Label ID="Label3" runat="server" SkinID="SkinLblNormal" Text="Seleccione quincena"></asp:Label>&nbsp;<asp:DropDownList
                                                        ID="ddlQnas" runat="server" SkinID="SkinDropDownList">
                                                    </asp:DropDownList>
                                                    <asp:Button ID="btnConsultarQna" OnClick="btnConsultarQna_Click" runat="server" SkinID="SkinBoton"
                                                        Text="Consultar"></asp:Button><br />
                                                </asp:Panel>
                                            </td>
                                            <td style="width: 100px">
                                                <asp:ImageButton ID="ibRefresh" runat="server" ImageUrl="~/Imagenes/Refresh.jpg"
                                                    OnClick="ibRefresh_Click" ToolTip="Actualizar información" />
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ibRefresh" EventName="Click" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100%">
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                    <ajaxToolkit:CollapsiblePanelExtender ID="CPEDevoluciones" runat="Server" TextLabelID="Label1"
                                        TargetControlID="ContentPanelDevoluciones" SuppressPostBack="true" ImageControlID="Image1"
                                        ExpandedText="(Ocultar detalles...)" ExpandedImage="~/Imagenes/collapse_blue.jpg"
                                        ExpandControlID="TitlePanelDevoluciones" CollapsedText="(Mostrar detalles...)"
                                        CollapsedImage="~/Imagenes/expand_blue.jpg" Collapsed="False" CollapseControlID="TitlePanelDevoluciones">
                                    </ajaxToolkit:CollapsiblePanelExtender>
                                    <table style="width: 100%" cellspacing="0" cellpadding="0">
                                        <tbody>
                                            <tr>
                                                <td colspan="2" style="vertical-align: top; width: 100%; text-align: left; height: 31px;">
                                                    <br />
                                                    <asp:LinkButton ID="lbAgregarDevolucion" runat="server" SkinID="SkinLinkButton" OnClick="lbAgregarDevolucion_Click">Capturar nueva devolución</asp:LinkButton>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="vertical-align: top; width: 100%; text-align: left" colspan="2">
                                                    <asp:Panel ID="TitlePanelDevoluciones" runat="server" Width="100%" BorderWidth="1px"
                                                        BorderStyle="Solid" BorderColor="White" CssClass="collapsePanelHeader">
                                                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/expand_blue.jpg"></asp:Image>
                                                        Empleados con devoluciones quincenales
                                                        <asp:Label ID="Label1" runat="server">
        (Mostrar detalles...)</asp:Label>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="vertical-align: top; width: 100%; text-align: left" colspan="2">
                                                    <asp:Panel ID="ContentPanelDevoluciones" runat="server" Width="100%" CssClass="collapsePanel">
                                                        <asp:GridView ID="gvDevoluciones" runat="server" Width="100%" SkinID="SkinGridView"
                                                            EmptyDataText="No existen devoluciones capturadas" AutoGenerateColumns="false">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="IdQuincena" Visible="False">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblIdQnaAplicacion" runat="server" Text='<%# Bind("IdQnaAplicacion") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="QnaAplic" HeaderText="Qna. aplic.">
                                                                    <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="QnaIni" HeaderText="Qna. Ini.">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="QnaFin" HeaderText="Qna Fin">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                                <asp:TemplateField HeaderText="RFC">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="lbRFC" runat="server" CommandName="CmdRFC" Text='<%# Bind("RFCemp") %>'></asp:LinkButton>
                                                                        <ajaxToolkit:ConfirmButtonExtender ID="CBEEmpSel" runat="server" ConfirmText="¿Seleccionar empleado para consultas posteriores?"
                                                                            TargetControlID="lbRFC">
                                                                        </ajaxToolkit:ConfirmButtonExtender>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="CURP">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblCURP" runat="server" Text='<%# Bind("CURPEmp") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="A. paterno">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblApePat" runat="server" Text='<%# Bind("ApePatEmp") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="A. materno">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblApeMat" runat="server" Text='<%# Bind("ApeMatEmp") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Nombre">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblNombre" runat="server" Text='<%# Bind("NomEmp") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="N&#250;m. emp.">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblNumEmp" runat="server" Text='<%# Bind("NumEmp") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="DescPlantel" HeaderText="Plantel" />
                                                                <asp:TemplateField>
                                                                    <ItemTemplate>
                                                                        <asp:ImageButton ID="ibEliminar" runat="server" CommandName="CmdEliminar" ImageUrl="~/Imagenes/Eliminar.png"
                                                                            ToolTip="Eliminar registro" />
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <ItemTemplate>
                                                                        <asp:ImageButton ID="ibModificar" runat="server" ImageUrl="~/Imagenes/Modificar.png"
                                                                            CommandName="CmdModificar" ToolTip="Modificar la información de éste registro" />
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <EmptyDataRowStyle Font-Italic="True" />
                                                        </asp:GridView>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="vertical-align: top; width: 100%; text-align: left" colspan="2">
                                                    &nbsp;
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
                                    <asp:AsyncPostBackTrigger ControlID="btnConsultarQna" EventName="Click"></asp:AsyncPostBackTrigger>
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
