<%@ Page Language="VB" EnableEventValidation="false" MasterPageFile="~/MasterPageSesionIniciada.master"
    AutoEventWireup="false" CodeFile="EmpleadosRecibos.aspx.vb" Inherits="Consultas_Recibos_EmpleadosRecibos"
    Title="COBAEV - Nómina - Listado de empleados para recibos" StylesheetTheme="SkinFile" %>

<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress"
    TagPrefix="TP_wucUpdateProgress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
    <table style="width: 100%; height: 300px;" align="center">
        <tr>
            <td style="vertical-align: top; text-align: right">
                <h2>
                    Sistema de nómina: Empleados para generar recibos de pago fuera de nómina
                </h2>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top; width: 100%; height: 100%; text-align: left">
                <table style="width: 100%">
                    <tr>
                        <td style="width: 100%">
                            <asp:LinkButton ID="lbAgregarEmps" runat="server" SkinID="SkinLinkButton">Agregar empleados</asp:LinkButton>
                            <asp:LinkButton ID="lbConsultaRecibos" runat="server" PostBackUrl="~/Consultas/Recibos/Recibos.aspx?TipoOperacion=4"
                                SkinID="SkinLinkButton">Consulta de recibos</asp:LinkButton>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100%">
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                    <ajaxToolkit:CollapsiblePanelExtender ID="CPEEmps" runat="Server" TextLabelID="Label1"
                                        TargetControlID="ContentPanelEmps" SuppressPostBack="true" ImageControlID="Image1"
                                        ExpandedText="(Ocultar detalles...)" ExpandedImage="~/Imagenes/collapse_blue.jpg"
                                        ExpandControlID="TitlePanelEmps" CollapsedText="(Mostrar detalles...)" CollapsedImage="~/Imagenes/expand_blue.jpg"
                                        Collapsed="False" CollapseControlID="TitlePanelEmps">
                                    </ajaxToolkit:CollapsiblePanelExtender>
                                    <table style="width: 100%" cellspacing="0" cellpadding="0">
                                        <tbody>
                                            <tr>
                                                <td style="vertical-align: top; width: 100%; text-align: left" colspan="2">
                                                    <asp:Panel ID="TitlePanelEmps" runat="server" Width="100%" BorderWidth="1px" BorderStyle="Solid"
                                                        BorderColor="White" CssClass="collapsePanelHeader">
                                                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/expand_blue.jpg"></asp:Image>
                                                        Listado de empleados a los cuales se les pueden generar recibos
                                                        <asp:Label ID="Label1" runat="server">
        (Mostrar detalles...)</asp:Label>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="vertical-align: top; width: 100%; text-align: left" colspan="2">
                                                    <asp:Panel ID="ContentPanelEmps" runat="server" Width="100%" CssClass="collapsePanel">
                                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                            <Triggers>
                                                                <asp:AsyncPostBackTrigger ControlID="gvEmps" EventName="RowEditing" />
                                                                <asp:AsyncPostBackTrigger ControlID="gvEmps" EventName="RowCancelingEdit" />
                                                                <asp:AsyncPostBackTrigger ControlID="gvEmps" EventName="SelectedIndexChanged" />
                                                                <asp:AsyncPostBackTrigger ControlID="gvEmps" EventName="RowDeleting" />
                                                            </Triggers>
                                                            <ContentTemplate>
                                                                <asp:GridView ID="gvEmps" runat="server" Width="100%" SkinID="SkinGridView" EmptyDataText="No existen empleados dados de alta para captura de recibos."
                                                                    AutoGenerateColumns="False" PageSize="20" OnRowCancelingEdit="gvEmps_RowCancelingEdit"
                                                                    OnRowEditing="gvEmps_RowEditing" OnSelectedIndexChanged="gvEmps_SelectedIndexChanged">
                                                                    <Columns>
                                                                        <asp:CommandField ButtonType="Image" SelectImageUrl="~/Imagenes/Select.png" ShowSelectButton="True">
                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                        </asp:CommandField>
                                                                        <asp:TemplateField HeaderText="IdEmp" Visible="False">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblIdEmp" runat="server" Text='<%# Bind("IdEmp") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <EditItemTemplate>
                                                                                <asp:Label ID="lblIdEmp" runat="server" Text='<%# Bind("IdEmp") %>'></asp:Label>
                                                                            </EditItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:BoundField DataField="NumEmp" HeaderText="N&#250;mero de empleado" ReadOnly="True">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                        </asp:BoundField>
                                                                        <asp:TemplateField HeaderText="R.F.C.">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lbRFCEmp" runat="server" CommandName="CmdRFC" Text='<%# Bind("RFCEmp") %>'></asp:LinkButton>
                                                                                <ajaxToolkit:ConfirmButtonExtender ID="CBEEmpSel" runat="server" ConfirmText="¿Seleccionar empleado para consultas posteriores?"
                                                                                    TargetControlID="lbRFCEmp">
                                                                                </ajaxToolkit:ConfirmButtonExtender>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                            <EditItemTemplate>
                                                                                <asp:LinkButton ID="lbRFCEmp" runat="server" CommandName="CmdRFC" Text='<%# Bind("RFCEmp") %>'></asp:LinkButton><ajaxToolkit:ConfirmButtonExtender
                                                                                    ID="CBEEmpSel" runat="server" ConfirmText="¿Seleccionar empleado para consultas posteriores?"
                                                                                    TargetControlID="lbRFCEmp">
                                                                                </ajaxToolkit:ConfirmButtonExtender>
                                                                            </EditItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:BoundField DataField="ApePatEmp" HeaderText="Apellido paterno" ReadOnly="True" />
                                                                        <asp:BoundField DataField="ApeMatEmp" HeaderText="Apellido materno" ReadOnly="True" />
                                                                        <asp:BoundField DataField="NomEmp" HeaderText="Nombre" ReadOnly="True" />
                                                                        <asp:TemplateField HeaderText="IdQnaIni" Visible="False">
                                                                            <EditItemTemplate>
                                                                                <asp:Label ID="lblIdQnaIni" runat="server" Text='<%# Bind("IdQnaIni") %>'></asp:Label>
                                                                            </EditItemTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblIdQnaIni" runat="server" Text='<%# Bind("IdQnaIni") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                        </asp:TemplateField>
                                                                        <asp:BoundField DataField="QnaIni" HeaderText="Inicio" ReadOnly="True">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                        </asp:BoundField>
                                                                        <asp:TemplateField HeaderText="IdQnaFin" Visible="False">
                                                                            <EditItemTemplate>
                                                                                <asp:Label ID="lblIdQnaFin" runat="server" Text='<%# Bind("IdQnaFin") %>' Visible="False"></asp:Label>
                                                                            </EditItemTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblIdQnaFin" runat="server" Text='<%# Bind("IdQnaFin") %>' Visible="False"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="T&#233;rmino">
                                                                            <EditItemTemplate>
                                                                                <asp:DropDownList ID="ddlQnasFin" runat="server" SkinID="SkinDropDownList">
                                                                                </asp:DropDownList>
                                                                            </EditItemTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblQnaFin" runat="server" Text='<%# Bind("QnaFin") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Modificar">
                                                                            <EditItemTemplate>
                                                                                <asp:ImageButton ID="ibGuardar" runat="server" CausesValidation="True" CommandName="Update"
                                                                                    ImageUrl="~/Imagenes/CDROM.png" ToolTip="Guardar" />&nbsp;<asp:ImageButton ID="ibCancelar"
                                                                                        runat="server" CausesValidation="False" CommandName="Cancel" ImageUrl="~/Imagenes/Eliminar.png"
                                                                                        ToolTip="Cancelar" /><ajaxToolkit:ConfirmButtonExtender ID="CBECancelar" runat="server"
                                                                                            ConfirmText="La operación solicitada guardará las modificaciones realizadas en la Base de datos, ¿Continuar?"
                                                                                            TargetControlID="ibGuardar">
                                                                                        </ajaxToolkit:ConfirmButtonExtender>
                                                                            </EditItemTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:ImageButton ID="ibEditar" runat="server" CausesValidation="False" CommandName="Edit"
                                                                                    ImageUrl="~/Imagenes/Modificar.png" ToolTip="Modificar" />
                                                                            </ItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Eliminar">
                                                                            <ItemTemplate>
                                                                                <asp:ImageButton ID="ibEliminar" runat="server" CausesValidation="False" CommandName="Delete"
                                                                                    ImageUrl="~/Imagenes/Eliminar.png" ToolTip="Eliminar" /><ajaxToolkit:ConfirmButtonExtender
                                                                                        ID="CBEEliminar" runat="server" ConfirmText="La operación solicitada eliminará el registro de la Base de datos, ¿Continuar?"
                                                                                        TargetControlID="ibEliminar">
                                                                                    </ajaxToolkit:ConfirmButtonExtender>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                    <EmptyDataRowStyle Font-Italic="True" />
                                                                    <PagerSettings Mode="NumericFirstLast" Position="TopAndBottom" />
                                                                </asp:GridView>
                                                            </ContentTemplate>
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
                                    <asp:AsyncPostBackTrigger ControlID="lbAgregarEmps" EventName="Click" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
