<%@ page language="VB" enableeventvalidation="false" masterpagefile="~/MasterPageBlanca.master" autoeventwireup="false" inherits="RolesDeducciones, App_Web_ximrphjl" title="COBAEV - Nómina - Administración de permisos Roles-Deducciones" stylesheettheme="SkinFile" maintainScrollPositionOnPostBack="true" %>
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
                    Sistema de nómina: Administración de permisos Roles-Deducciones
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
                                SkinID="SkinBoton" Text="Ver permisos sobre deducciones" 
                                ToolTip="Consultar permisos sobre deducciones para el Rol seleccionado" /><br />
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
    <asp:GridView ID="gvDeducsPermisos" runat="server" CellPadding="1" SkinID="SkinGridView" 
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
            <asp:TemplateField HeaderText="Nombre ROL">
                <ItemTemplate>
                    <asp:Label ID="lblNombreRol" runat="server" Text='<%# Bind("NombreRol") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:Label ID="lblNombreRolE" runat="server" Text='<%# Bind("NombreRol") %>'></asp:Label>
                </EditItemTemplate>
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle HorizontalAlign="Left" Wrap="False" />
            </asp:TemplateField>   
            <asp:TemplateField HeaderText="IdDeduccion" Visible="False">
                <ItemTemplate>
                    <asp:Label ID="lblIdDeduccion" runat="server" Text='<%# Bind("IdDeduccion") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:Label ID="lblIdDeduccionE" runat="server" Text='<%# Bind("IdDeduccion") %>'></asp:Label>
                </EditItemTemplate>
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle HorizontalAlign="Left" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Nombre deducción">
                <ItemTemplate>
                    <asp:Label ID="lblNombreDeduccion" runat="server" Text='<%# Bind("NombreDeduccion") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:Label ID="lblNombreDeduccionE" runat="server" Text='<%# Bind("NombreDeduccion") %>'></asp:Label>
                </EditItemTemplate>
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle HorizontalAlign="Left" Wrap="False" />
            </asp:TemplateField>          
            <asp:TemplateField HeaderText="Permiso de captura para Nómina">
                <EditItemTemplate>
                    <asp:CheckBox ID="chkbxPermisoCapturaNominaE" runat="server" SkinID="SkinCheckBox" Checked='<%# Bind("PermisoCapturaNomina") %>' />
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:checkbox ID="chkbxPermisoCapturaNomina" runat="server" SkinID="SkinCheckBox" Enabled="false" Checked='<%# Bind("PermisoCapturaNomina") %>'></asp:checkbox>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" Wrap="False" />
            </asp:TemplateField> 
            <asp:TemplateField HeaderText="Permiso de captura para Recibos">
                <EditItemTemplate>
                    <asp:CheckBox ID="chkbxPermisoCapturaReciboE" runat="server" SkinID="SkinCheckBox" Checked='<%# Bind("PermisoCapturaRecibo") %>' />
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:checkbox ID="chkbxPermisoCapturaRecibo" runat="server" SkinID="SkinCheckBox" Enabled="false" Checked='<%# Bind("PermisoCapturaRecibo") %>'></asp:checkbox>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" Wrap="False" />
            </asp:TemplateField> 
            <asp:TemplateField HeaderText="Permiso para CONSULTA">
                <EditItemTemplate>
                    <asp:CheckBox ID="chkbxPermisoConsultaE" runat="server" SkinID="SkinCheckBox" Checked='<%# Bind("PermisoConsulta") %>' />
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:checkbox ID="chkbxPermisoConsulta" runat="server" SkinID="SkinCheckBox" Enabled="false" Checked='<%# Bind("PermisoConsulta") %>'></asp:checkbox>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" Wrap="False" />
            </asp:TemplateField> 
            <asp:TemplateField HeaderText="Permiso en Tabla RolesDeduccionesParaRecibos">
                <EditItemTemplate>
                    <asp:CheckBox ID="chkbxPermisoTblRolesDeduccionesParaRecibosE" runat="server" SkinID="SkinCheckBox" Checked='<%# Bind("PermisoTblRolesDeduccionesParaRecibos") %>' />
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:checkbox ID="chkbxPermisoTblRolesDeduccionesParaRecibos" runat="server" SkinID="SkinCheckBox" Enabled="false" Checked='<%# Bind("PermisoTblRolesDeduccionesParaRecibos") %>'></asp:checkbox>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" Wrap="False" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Permiso en Tabla RolesDeducciones">
                <EditItemTemplate>
                    <asp:CheckBox ID="chkbxPermisoTblRolesDeduccionesE" runat="server" SkinID="SkinCheckBox" Checked='<%# Bind("PermisoTblRolesDeducciones") %>' />
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:checkbox ID="chkbxPermisoRolesDeducciones" runat="server" SkinID="SkinCheckBox" Enabled="false" Checked='<%# Bind("PermisoTblRolesDeducciones") %>'></asp:checkbox>
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

