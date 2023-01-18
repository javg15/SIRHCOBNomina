<%@ Page EnableEventValidation="false" Language="VB" MasterPageFile="~/MasterPageSesionIniciada.master"
    AutoEventWireup="false" CodeFile="DiasEconomicos.aspx.vb" Inherits="Consultas_Empleados_DiasEconomicos"
    Title="COBAEV - Nómina - Empleados, días económicos" StylesheetTheme="SkinFile" %>

<%@ Register Src="~/WebControls/wucSearchEmps.ascx" TagName="wucBuscaEmpleados" TagPrefix="uc1" %>
<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress" TagPrefix="TP_wucUpdateProgress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
    <table style="width: 100%; height: 300px" align="center">
        <tr>
            <td style="vertical-align: top; text-align: right">
                <h2>
                    Sistema de nómina: Empleados (Administración días económicos)
                </h2>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top; width: 100%; height: 100%; text-align: left">
                <table style="width: 100%">
                    <tr>
                        <td style="vertical-align: top; text-align: left;">
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
                        <td style="vertical-align: top; text-align: left;">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                <asp:Panel ID="pnl1" runat="server">
                                    <ajaxToolkit:CollapsiblePanelExtender ID="CPEEmpsDiasEco" runat="Server" SuppressPostBack="true"
                                        CollapsedImage="~/Imagenes/expand_blue.jpg" ExpandedImage="~/Imagenes/collapse_blue.jpg"
                                        ImageControlID="Image2" CollapsedText="(Mostrar detalles...)" ExpandedText="(Ocultar detalles...)"
                                        TextLabelID="Label2" Collapsed="False" CollapseControlID="TitlePanelEmpsDiasEco"
                                        ExpandControlID="TitlePanelEmpsDiasEco" TargetControlID="ContentPanelEmpsDiasEco">
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
                                                    <asp:Panel ID="pnlAños" runat="server" DefaultButton="btnConsultar" Font-Names="Verdana"
                                                        Font-Size="X-Small" GroupingText="Seleccione año">
                                                        <br />
                                                        <asp:DropDownList ID="ddlAños" runat="server" SkinID="SkinDropDownList">
                                                        </asp:DropDownList>
                                                        <asp:Button ID="btnConsultar" runat="server" OnClick="btnConsultar_Click" SkinID="SkinBoton"
                                                            Text="Consultar" ToolTip="Consultar días disfrutados para el año seleccionado"
                                                            CausesValidation="False" /><br />
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="vertical-align: top; text-align: left">
                                                    <br />
                                                    <asp:Label ID="lblNuevoDiaEco" runat="server" Enabled="False" Font-Strikeout="False"
                                                        Font-Underline="False" SkinID="SkinLblNormal">Nuevo día económico disfrutado</asp:Label><br />
                                                    <asp:TextBox ID="txtbxFechaNuevoDiaEco" runat="server" Enabled="False" MaxLength="10"
                                                        SkinID="SkinTextBox" Width="90px" OnTextChanged="txtbxFechaNuevoDiaEco_TextChanged"
                                                        ValidationGroup="NuevoDia"></asp:TextBox>
                                                    <asp:ImageButton ID="ibFechaNuevoDiaEco" runat="server" CssClass="ibFechNac" ImageUrl="~/Imagenes/Fecha.png"
                                                        CausesValidation="False" OnClick="ibFechaNuevoDiaEco_Click" Enabled="False" />&nbsp;<asp:Button
                                                            ID="btnGuardarNuevoDiaEco" runat="server" Enabled="False" OnClick="btnGuardarNuevoDiaEco_Click"
                                                            SkinID="SkinBoton" Text="Guardar" ValidationGroup="NuevoDia" /><ajaxToolkit:ConfirmButtonExtender
                                                                ID="CBEbtnGuardar" runat="server" TargetControlID="btnGuardarNuevoDiaEco" ConfirmText="La operación solicitada guardará las modificaciones realizadas en la Base de datos, ¿Continuar?">
                                                            </ajaxToolkit:ConfirmButtonExtender>
                                                    <asp:HiddenField ID="hfFechaNuevoDiaEco" runat="server" />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtbxFechaNuevoDiaEco"
                                                        Display="None" ErrorMessage="La fecha en que el día económico fue disfrutado es requerida."
                                                        ValidationGroup="NuevoDia"></asp:RequiredFieldValidator><asp:CompareValidator ID="CompareValidator1"
                                                            runat="server" ControlToValidate="txtbxFechaNuevoDiaEco" Display="None" ErrorMessage="La fecha en que el día económico fue disfrutado es incorrecta."
                                                            Operator="DataTypeCheck" Type="Date" ValidationGroup="NuevoDia"></asp:CompareValidator><asp:ValidationSummary
                                                                ID="ValidationSummary2" runat="server" ShowMessageBox="True" ShowSummary="False"
                                                                ValidationGroup="NuevoDia" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="vertical-align: top; text-align: left">
                                                    <br />
                                                    <asp:Label ID="lblMsj1" runat="server" Font-Strikeout="False" Font-Underline="True"
                                                        SkinID="SkinLblDatos">Año: Sin especificar</asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="vertical-align: top; width: 100%; text-align: left">
                                                    <asp:Panel ID="TitlePanelEmpsDiasEco" runat="server" Width="100%" BorderWidth="1px"
                                                        BorderStyle="Solid" BorderColor="White" CssClass="collapsePanelHeader">
                                                        <asp:Image ID="Image2" runat="server" ImageUrl="~/Imagenes/expand_blue.jpg"></asp:Image>
                                                        Días económicos disfrutados por año
                                                        <asp:Label ID="Label2" runat="server">(Mostrar detalles...)</asp:Label>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="vertical-align: top; width: 100%; text-align: left">
                                                    <asp:Panel ID="ContentPanelEmpsDiasEco" runat="server" Width="100%" CssClass="collapsePanel">
                                                        <asp:GridView ID="gvDiasEco" runat="server" AutoGenerateColumns="False" EmptyDataText="No existe información de días económicos disfrutados."
                                                            OnRowCancelingEdit="gvDiasEco_RowCancelingEdit" OnRowEditing="gvDiasEco_RowEditing"
                                                            OnSelectedIndexChanged="gvDiasEco_SelectedIndexChanged" PageSize="20" SkinID="SkinGridView"
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
                                                                <asp:TemplateField HeaderText="D&#237;a econ&#243;mico disfrutado el">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblFecha" runat="server" Text='<%# Bind("Fecha","{0:d}") %>' Visible="False"></asp:Label>
                                                                        <asp:TextBox ID="txtbxFecha" runat="server" SkinID="SkinTextBox" Width="90px" OnTextChanged="txtbxFecha_TextChanged"
                                                                            ValidationGroup="ModifDia"></asp:TextBox>
                                                                        <asp:ImageButton ID="ibFecNac" runat="server" CssClass="ibFechNac" ImageUrl="~/Imagenes/Fecha.png"
                                                                            CausesValidation="False" OnClick="ibFecNac_Click" ValidationGroup="ModifDia" />
                                                                        <asp:HiddenField ID="hfFecNac" runat="server" />
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtbxFecha"
                                                                            Display="None" ErrorMessage="La fecha en que el día económico fue disfrutado es requerida."
                                                                            ValidationGroup="ModifDia"></asp:RequiredFieldValidator>
                                                                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtbxFecha"
                                                                            Display="None" ErrorMessage="La fecha en que el día económico fue disfrutado es incorrecta."
                                                                            Operator="DataTypeCheck" Type="Date" ValidationGroup="ModifDia"></asp:CompareValidator>
                                                                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                                                                            ShowSummary="False" ValidationGroup="ModifDia" />
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblFecha" runat="server" Text='<%# Bind("Fecha","{0:d}") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="FechaCaptura" HeaderText="Fecha Captura/Modificaci&#243;n"
                                                                    ReadOnly="True" DataFormatString="{0:d}">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                                <asp:TemplateField HeaderText="Capturado/Modificado por">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblIdUsuario" runat="server" Text='<%# Bind("IdUsuario") %>' Visible="False"></asp:Label><asp:Label
                                                                            ID="lblLogin" runat="server"></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblIdUsuario" runat="server" Text='<%# Bind("IdUsuario") %>' Visible="False"></asp:Label><asp:Label
                                                                            ID="lblLogin" runat="server"></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Modificar">
                                                                    <EditItemTemplate>
                                                                        <asp:ImageButton ID="ibGuardar" runat="server" CausesValidation="True" CommandName="Update"
                                                                            ImageUrl="~/Imagenes/CDROM.png" ToolTip="Guardar" ValidationGroup="ModifDia" />
                                                                        <asp:ImageButton ID="ibCancelar" runat="server" CausesValidation="False" CommandName="Cancel"
                                                                            ImageUrl="~/Imagenes/Eliminar.png" ToolTip="Cancelar" /><ajaxToolkit:ConfirmButtonExtender
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
                                    <asp:AsyncPostBackTrigger ControlID="btnConsultar" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="ibActualizar" EventName="Click" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
