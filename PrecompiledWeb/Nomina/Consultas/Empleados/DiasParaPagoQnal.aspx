<%@ page enableeventvalidation="false" language="VB" masterpagefile="~/MasterPageSesionIniciada.master" autoeventwireup="false" inherits="Consultas_Empleados_DiasParaPagoQnal, App_Web_00vntztu" title="COBAEV - Nómina - Empleados, días para pago quincenal" stylesheettheme="SkinFile" maintainScrollPositionOnPostBack="true" %>

<%@ Register Src="~/WebControls/wucSearchEmps.ascx" TagName="wucBuscaEmpleados" TagPrefix="uc1" %>
<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress" TagPrefix="TP_wucUpdateProgress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
    <table style="width: 100%; height: 300px" align="center">
        <tr>
            <td style="vertical-align: top; text-align: right">
                <h2>
                    Sistema de nómina: Empleados (Administración días para pago quincenal)
                </h2>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top; width: 100%; height: 100%; text-align: left">
                <table style="width: 100%">
                    <tr>
                        <td style="vertical-align: top; text-align: left; width: 976px;">
                            <table style="width: 100%">
                                <tr>
                                    <td>
                                        <uc1:wucBuscaEmpleados ID="WucBuscaEmpleados1" runat="server" EnableViewState="true" />
                                    </td>
                                    <td align="right" valign="top">
                                        <asp:ImageButton ID="ibActualizar" runat="server" ImageUrl="~/Imagenes/Refresh.jpg"
                                            ToolTip="Actualizar información" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top; text-align: left; width: 976px;">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                <asp:Panel ID="pnl1" runat="server">
                                    <ajaxToolkit:CollapsiblePanelExtender ID="CPEEmpsDiasAPagar" runat="Server" SuppressPostBack="true"
                                        CollapsedImage="~/Imagenes/expand_blue.jpg" ExpandedImage="~/Imagenes/collapse_blue.jpg"
                                        ImageControlID="Image2" CollapsedText="(Mostrar detalles...)" ExpandedText="(Ocultar detalles...)"
                                        TextLabelID="Label2" Collapsed="False" CollapseControlID="TitlePanelEmpsDiasAPagar"
                                        ExpandControlID="TitlePanelEmpsDiasAPagar" TargetControlID="ContentPanelEmpsDiasAPagar">
                                    </ajaxToolkit:CollapsiblePanelExtender>
                                    <table style="width: 100%" cellspacing="0" cellpadding="0">
                                        <tbody>
                                            <tr>
                                                <td style="vertical-align: top; text-align: left" colspan="2">
                                                    <asp:Label ID="lblEmpInf" runat="server" SkinID="SkinLblDatos" Font-Underline="True"
                                                        Font-Strikeout="False"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="vertical-align: top; text-align: left">
                                                    <asp:Panel ID="pnlAños" runat="server" DefaultButton="btnConsultarQuincenas" Font-Names="Verdana"
                                                        Font-Size="X-Small" GroupingText="Seleccione año">
                                                        <br />
                                                        <asp:DropDownList ID="ddlAños" runat="server" SkinID="SkinDropDownList">
                                                        </asp:DropDownList>
                                                        <asp:Button ID="btnConsultarQuincenas" runat="server" OnClick="btnConsultarQuincenas_Click"
                                                            SkinID="SkinBoton" Text="Ver quincenas" ToolTip="Consultar quincenas para el año seleccionado" /><br />
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="vertical-align: top; width: 100%; text-align: left">
                                                    <asp:Panel ID="TitlePanelEmpsDiasAPagar" runat="server" Width="100%" BorderWidth="1px"
                                                        BorderStyle="Solid" BorderColor="White" CssClass="collapsePanelHeader">
                                                        <asp:Image ID="Image2" runat="server" ImageUrl="~/Imagenes/expand_blue.jpg"></asp:Image>
                                                        Días pagados por quincena
                                                        <asp:Label ID="Label2" runat="server">(Mostrar detalles...)</asp:Label>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="vertical-align: top; width: 100%; text-align: left">
                                                    <asp:Panel ID="ContentPanelEmpsDiasAPagar" runat="server" Width="100%" CssClass="collapsePanel">
                                                        <asp:GridView ID="gvEmps" runat="server" AutoGenerateColumns="False" EmptyDataText="No existe información de días de pago para el empleado."
                                                            OnRowCancelingEdit="gvEmps_RowCancelingEdit" OnRowEditing="gvEmps_RowEditing"
                                                            OnSelectedIndexChanged="gvEmps_SelectedIndexChanged" PageSize="20" SkinID="SkinGridView"
                                                            Width="100%">
                                                            <PagerSettings Mode="NumericFirstLast" Position="TopAndBottom" />
                                                            <EmptyDataRowStyle Font-Italic="True" />
                                                            <Columns>
                                                                <asp:CommandField ButtonType="Image" SelectImageUrl="~/Imagenes/Select.png" ShowSelectButton="True">
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:CommandField>
                                                                <asp:TemplateField HeaderText="IdEmp" Visible="False">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblIdEmp" runat="server" Text='<%# Bind("IdEmp") %>'></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblIdEmp" runat="server" Text='<%# Bind("IdEmp") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="IdQuincena" Visible="False">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblIdQuincena" runat="server" Text='<%# Bind("IdQuincena") %>'></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblIdQuincena" runat="server" Text='<%# Bind("IdQuincena") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="Quincena" HeaderText="Quincena" ReadOnly="True">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                                <asp:TemplateField HeaderText="D&#237;as pagados">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblDias" runat="server" Text='<%# Bind("Dias") %>' Visible="False"></asp:Label><asp:DropDownList
                                                                            ID="ddlDias" runat="server" SkinID="SkinDropDownList">
                                                                        </asp:DropDownList>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblDias" runat="server" Text='<%# Bind("Dias") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Modificar">
                                                                    <EditItemTemplate>
                                                                        <asp:ImageButton ID="ibGuardar" runat="server" CausesValidation="True" CommandName="Update"
                                                                            ImageUrl="~/Imagenes/CDROM.png" ToolTip="Guardar" />
                                                                        <asp:ImageButton ID="ibCancelar" runat="server" CausesValidation="False" CommandName="Cancel"
                                                                            ImageUrl="~/Imagenes/Eliminar.png" ToolTip="Cancelar" />
                                                                            <ajaxToolkit:ConfirmButtonExtender
                                                                                ID="CBECancelar" runat="server" ConfirmText="La operación solicitada guardará las modificaciones realizadas en la Base de datos, ¿Continuar?"
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
                                                                <asp:TemplateField HeaderText="AbiertaParaCaptura" Visible="False">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblAbiertaParaCaptura" runat="server" Text='<%# Bind("AbiertaParaCaptura") %>'></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblAbiertaParaCaptura" runat="server" Text='<%# Bind("AbiertaParaCaptura") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="A&#241;o" Visible="False">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblAnio" runat="server" Text='<%# Bind("Anio") %>'></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblAnio" runat="server" Text='<%# Bind("Anio") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
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
                                    <asp:AsyncPostBackTrigger ControlID="WucBuscaEmpleados1" EventName="PreRender" />
                                    <asp:AsyncPostBackTrigger ControlID="gvEmps" EventName="SelectedIndexChanged" />
                                    <asp:AsyncPostBackTrigger ControlID="btnConsultarQuincenas" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="gvEmps" EventName="RowEditing" />
                                    <asp:AsyncPostBackTrigger ControlID="gvEmps" EventName="RowCancelingEdit" />
                                    <asp:AsyncPostBackTrigger ControlID="gvEmps" EventName="RowDeleting" />
                                    <asp:AsyncPostBackTrigger ControlID="gvEmps" EventName="RowUpdating" />
                                    <asp:AsyncPostBackTrigger ControlID="ibActualizar" EventName="Click" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
