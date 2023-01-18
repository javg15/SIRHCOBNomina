<%@ Page Language="VB" enableEventValidation="false" MasterPageFile="~/MasterPageBlanca.master" AutoEventWireup="false" CodeFile="RolesReportes.aspx.vb" Inherits="RolesReportes" title="COBAEV - Nómina - Administración de permisos Roles-Reportes" StylesheetTheme="SkinFile" %>
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
                    Sistema de nómina: Administración de permisos Roles-Reportes
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
                            <asp:DropDownList ID="ddlRoles" runat="server" SkinID="SkinDropDownList" 
                                AutoPostBack="True">
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
                        <br />
                        <asp:Label ID="lblPermisosRolX" runat="server" SkinID="SkinLblDatos"></asp:Label>
    <asp:GridView ID="gvReportesPermisos" runat="server" CellPadding="1" SkinID="SkinGridView" 
                            Width="100%">
        <Columns>
            <asp:CommandField ButtonType="Image" SelectImageUrl="~/Imagenes/Select.png" ShowSelectButton="True">
                <ItemStyle HorizontalAlign="Center" />
            </asp:CommandField>
            <asp:TemplateField HeaderText="IdReporte" Visible="False">
                <ItemTemplate>
                    <asp:Label ID="lblIdReporte" runat="server" Text='<%# Bind("IdReporte") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:Label ID="lblIdReporteE" runat="server" Text='<%# Bind("IdReporte") %>'></asp:Label>
                </EditItemTemplate>
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle HorizontalAlign="Left" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Nombre del reporte">
                <ItemTemplate>
                    <asp:Label ID="lblNombreReporte" runat="server" Text='<%# Bind("NombreReporte") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:Label ID="lblNombreReporteE" runat="server" Text='<%# Bind("NombreReporte") %>'></asp:Label>
                </EditItemTemplate>
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle HorizontalAlign="Left" />
            </asp:TemplateField>          
            <asp:TemplateField HeaderText="Descripción de la finalidad del reporte">
                <ItemTemplate>
                    <asp:Label ID="lblDescripcionDelReporte" runat="server" Text='<%# Bind("DescripcionDelReporte") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:Label ID="lblDescripcionDelReporteE" runat="server" Text='<%# Bind("DescripcionDelReporte") %>'></asp:Label>
                </EditItemTemplate>
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle HorizontalAlign="Left" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Descripción del reporte (Usuario)">
                <ItemTemplate>
                    <asp:Label ID="lblDescParaUsuario" runat="server" Text='<%# Bind("DescParaUsuario") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:Label ID="lblDescParaUsuarioE" runat="server" Text='<%# Bind("DescParaUsuario") %>'></asp:Label>
                </EditItemTemplate>
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle HorizontalAlign="Left" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Permiso para CONSULTA">
                <EditItemTemplate>
                    <asp:CheckBox ID="chkbxPermisoE" runat="server" SkinID="SkinCheckBox" Checked='<%# Bind("Permiso") %>' />
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:checkbox ID="chkbxPermiso" runat="server" SkinID="SkinCheckBox" Enabled="false" Checked='<%# Bind("Permiso") %>'></asp:checkbox>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" />
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
                        <asp:AsyncPostBackTrigger ControlID="ddlRoles" 
                            EventName="SelectedIndexChanged" />
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

