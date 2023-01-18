<%@ Page Language="VB" enableEventValidation="false" MasterPageFile="~/MasterPageBlanca.master" AutoEventWireup="false" CodeFile="RolesPaginas.aspx.vb" Inherits="RolesPaginas" title="COBAEV - Nómina - Administración de permisos Roles-Páginas" StylesheetTheme="SkinFile" %>
<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress" TagPrefix="TP_wucUpdateProgress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script type="text/javascript">
    self.focus();
</script>
    <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
    <table style="width: 70%; vertical-align: top;" align="center">
        <tr>
            <td style="vertical-align: top; text-align: right">
                <h2>
                    Sistema de nómina: Administración de permisos Roles-Páginas
                </h2>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top; text-align: left">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <br />
                        <asp:Panel ID="pnlRoles" runat="server" DefaultButton="btnConsultarPermisos"
                            Font-Names="Verdana" Font-Size="X-Small" GroupingText="Seleccione Rol">
                            <br />
                            <asp:DropDownList ID="ddlRoles" runat="server" SkinID="SkinDropDownList">
                            </asp:DropDownList>
                            <asp:Button ID="btnConsultarPermisos" runat="server" 
                                SkinID="SkinBoton" Text="Ver permisos sobre páginas" 
                                ToolTip="Consultar permisos sobre páginas para el Rol seleccionado" /><br />
                            <br />
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td style="text-align: left; vertical-align: top;">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
    <asp:GridView ID="gvPaginasPermisos" runat="server" CellPadding="1" SkinID="SkinGridView" 
                            Width="100%">
        <Columns>
            <asp:CommandField ButtonType="Image" SelectImageUrl="~/Imagenes/Select.png" ShowSelectButton="True">
                <ItemStyle HorizontalAlign="Center" />
            </asp:CommandField>
            <asp:TemplateField HeaderText="IdRol" Visible="False">
                <ItemTemplate>
                    <asp:Label ID="lblIdRol" runat="server" Text='<%# Bind("IdRol") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:Label ID="lblIdRolE" runat="server" Text='<%# Bind("IdRol") %>'></asp:Label>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Rol">
                <ItemTemplate>
                    <asp:Label ID="lblNombreRol" runat="server" Text='<%# Bind("NombreRol") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:Label ID="lblNombreRolE" runat="server" Text='<%# Bind("NombreRol") %>'></asp:Label>
                </EditItemTemplate>
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle HorizontalAlign="Left" Wrap="False" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="IdPagina" Visible="False">
                <ItemTemplate>
                    <asp:Label ID="lblIdPagina" runat="server" Text='<%# Bind("IdPagina") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:Label ID="lblIdPaginaE" runat="server" Text='<%# Bind("IdPagina") %>'></asp:Label>
                </EditItemTemplate>
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle HorizontalAlign="Left" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Nombre de la página">
                <ItemTemplate>
                    <asp:Label ID="lblNombrePagina" runat="server" Text='<%# Bind("NombrePagina") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:Label ID="lblNombrePaginaE" runat="server" Text='<%# Bind("NombrePagina") %>'></asp:Label>
                </EditItemTemplate>
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle HorizontalAlign="Left" Wrap="False" />
            </asp:TemplateField>          
            <asp:TemplateField HeaderText="Permiso para UPDATE">
                <EditItemTemplate>
                    <asp:CheckBox ID="chkbxActualizacionE" runat="server" SkinID="SkinCheckBox" Checked='<%# Bind("Actualizacion") %>' />
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:checkbox ID="chkbxActualizacion" runat="server" SkinID="SkinCheckBox" Enabled="false" Checked='<%# Bind("Actualizacion") %>'></asp:checkbox>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" Wrap="False" />
            </asp:TemplateField> 
            <asp:TemplateField HeaderText="Permiso para INSERT">
                <EditItemTemplate>
                    <asp:CheckBox ID="chkbxInsercionE" runat="server" SkinID="SkinCheckBox" Checked='<%# Bind("Insercion") %>' />
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:checkbox ID="chkbxInsercion" runat="server" SkinID="SkinCheckBox" Enabled="false" Checked='<%# Bind("Insercion") %>'></asp:checkbox>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" Wrap="False" />
            </asp:TemplateField> 
            <asp:TemplateField HeaderText="Permiso para DELETE">
                <EditItemTemplate>
                    <asp:CheckBox ID="chkbxEliminacionE" runat="server" SkinID="SkinCheckBox" Checked='<%# Bind("Eliminacion") %>' />
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:checkbox ID="chkbxEliminacionE" runat="server" SkinID="SkinCheckBox" Enabled="false" Checked='<%# Bind("Eliminacion") %>'></asp:checkbox>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" Wrap="False" />
            </asp:TemplateField> 
            <asp:TemplateField HeaderText="Permiso para CONSULTA">
                <EditItemTemplate>
                    <asp:CheckBox ID="chkbxConsultaE" runat="server" SkinID="SkinCheckBox" Checked='<%# Bind("Consulta") %>' />
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:checkbox ID="chkbxConsulta" runat="server" SkinID="SkinCheckBox" Enabled="false" Checked='<%# Bind("Consulta") %>'></asp:checkbox>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" Wrap="False" />
            </asp:TemplateField> 
            <asp:TemplateField ShowHeader="False">
                <EditItemTemplate>
                    <asp:ImageButton ID="ibGuardar" runat="server" CausesValidation="True" CommandName="Update"
                        ImageUrl="~/Imagenes/CDROM.png" ToolTip="Guardar cambios" />&nbsp;<asp:ImageButton
                            ID="ibCancelar" runat="server" CausesValidation="False" CommandName="Cancel"
                            ImageUrl="~/Imagenes/Eliminar.png" ToolTip="Cancelar" />
                    <ajaxToolkit:ConfirmButtonExtender ID="CBECancelar" runat="server" ConfirmText="La operación solicitada guardará las modificaciones realizadas en la Base de datos, ¿Continuar?"
                        TargetControlID="ibGuardar">
                    </ajaxToolkit:ConfirmButtonExtender>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:ImageButton ID="ibEditar" runat="server" CausesValidation="False" CommandName="Edit"
                        ImageUrl="~/Imagenes/Modificar.png" ToolTip="Modificar permisos" />
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Wrap="false" />
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnConsultarPermisos" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
            </td>
        </tr>
    </table>
</asp:Content>

