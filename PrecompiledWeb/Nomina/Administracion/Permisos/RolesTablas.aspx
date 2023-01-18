<%@ page language="VB" enableeventvalidation="false" masterpagefile="~/MasterPageBlanca.master" autoeventwireup="false" inherits="RolesTablas, App_Web_ximrphjl" title="COBAEV - Nómina - Administración de permisos Roles-Tablas" stylesheettheme="SkinFile" maintainScrollPositionOnPostBack="true" %>
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
                    Sistema de nómina: Administración de permisos Roles-Tablas
                </h2>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top; text-align: left">
                <asp:UpdatePanel ID="UPAddTabla" runat="server">
                    <ContentTemplate>
                        <br />
                        <asp:Panel ID="pnlAddTabla" runat="server" DefaultButton="btnAddTabla"
                            Font-Names="Verdana" Font-Size="X-Small" GroupingText="Agregar Tabla a Catálogo">
                            <br />
                            <asp:TextBox ID="txtbxNomTabla" runat="server" SkinID="SkinTextBox" 
                                Width="300px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvNombreTabla" runat="server" 
                                ControlToValidate="txtbxNomTabla" ErrorMessage="Nombre de Tabla requerido.">*</asp:RequiredFieldValidator>
                            <asp:Button ID="btnAddTabla" runat="server" 
                                SkinID="SkinBoton" Text="Agregar" 
                                ToolTip="Agregar la Tabla al Catálogo" />
                            <ajaxToolkit:ConfirmButtonExtender ID="btnAddTabla_CBE" runat="server" 
                                ConfirmText="¿Es correcto el nombre de la Tabla?" Enabled="True" 
                                TargetControlID="btnAddTabla">
                            </ajaxToolkit:ConfirmButtonExtender>
                            <br />
                            <br />
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
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
                                SkinID="SkinBoton" Text="Ver permisos sobre tablas" 
                                ToolTip="Consultar permisos sobre Tablas para el Rol seleccionado" 
                                CausesValidation="False" /><br />
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
    <asp:GridView ID="gvTablasPermisos" runat="server" CellPadding="1" SkinID="SkinGridView" 
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
            <asp:TemplateField HeaderText="IdTabla" Visible="False">
                <ItemTemplate>
                    <asp:Label ID="lblIdTabla" runat="server" Text='<%# Bind("IdTabla") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:Label ID="lblIdTablaE" runat="server" Text='<%# Bind("IdTabla") %>'></asp:Label>
                </EditItemTemplate>
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle HorizontalAlign="Left" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Nombre de la tabla">
                <ItemTemplate>
                    <asp:Label ID="lblNombreTabla" runat="server" Text='<%# Bind("NombreTabla") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtbxNombreTablaE" SkinID="SkinTextBox" runat="server" Text='<%# Bind("NombreTabla") %>'></asp:TextBox>
                </EditItemTemplate>
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle HorizontalAlign="Left" Wrap="False" />
            </asp:TemplateField>          
            <asp:TemplateField HeaderText="Permiso para UPDATE">
                <EditItemTemplate>
                    <asp:CheckBox ID="chkbxActualizacionE" runat="server" Checked='<%# Bind("Actualizacion") %>' SkinID="SkinCheckBox" />
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:checkbox ID="chkbxActualizacion" runat="server" Enabled="false" Checked='<%# Bind("Actualizacion") %>'  SkinID="SkinCheckBox"></asp:checkbox>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" Wrap="False" />
            </asp:TemplateField> 
            <asp:TemplateField HeaderText="Permiso para INSERT">
                <EditItemTemplate>
                    <asp:CheckBox ID="chkbxInsercionE" runat="server" Checked='<%# Bind("Insercion") %>'  SkinID="SkinCheckBox"/>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:checkbox ID="chkbxInsercion" runat="server" Enabled="false" Checked='<%# Bind("Insercion") %>' SkinID="SkinCheckBox"></asp:checkbox>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" Wrap="False" />
            </asp:TemplateField> 
            <asp:TemplateField HeaderText="Permiso para DELETE">
                <EditItemTemplate>
                    <asp:CheckBox ID="chkbxEliminacionE" runat="server" Checked='<%# Bind("Eliminacion") %>' SkinID="SkinCheckBox"/>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:checkbox ID="chkbxEliminacionE" runat="server" Enabled="false" Checked='<%# Bind("Eliminacion") %>' SkinID="SkinCheckBox"></asp:checkbox>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" Wrap="False" />
            </asp:TemplateField> 
            <asp:TemplateField HeaderText="Permiso para CONSULTA">
                <EditItemTemplate>
                    <asp:CheckBox ID="chkbxConsultaE" runat="server" Checked='<%# Bind("Consulta") %>' SkinID="SkinCheckBox"/>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:checkbox ID="chkbxConsulta" runat="server" Enabled="false" Checked='<%# Bind("Consulta") %>' SkinID="SkinCheckBox"></asp:checkbox>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" Wrap="False" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Permiso para SOLO CONSULTA">
                <EditItemTemplate>
                    <asp:CheckBox ID="chkbxSoloConsultaE" runat="server" Checked='<%# Bind("SoloConsulta") %>' SkinID="SkinCheckBox"/>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:checkbox ID="chkbxSoloConsulta" runat="server" Enabled="false" Checked='<%# Bind("SoloConsulta") %>' SkinID="SkinCheckBox"></asp:checkbox>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" Wrap="False" />
            </asp:TemplateField> 
            <asp:TemplateField ShowHeader="False">
                <EditItemTemplate>
                    <asp:ImageButton ID="ibGuardar" runat="server" CausesValidation="False" CommandName="Update"
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
                        <asp:AsyncPostBackTrigger ControlID="btnAddTabla" EventName="Click" />
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

