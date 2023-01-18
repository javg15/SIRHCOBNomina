<%@ page language="VB" enableeventvalidation="false" masterpagefile="~/MasterPageSesionIniciada.master" autoeventwireup="false" inherits="wfMsjsPorUsr, App_Web_zxf13rgc" title="COBAEV - Nómina - Notificaciones por usuario" stylesheettheme="SkinFile" maintainScrollPositionOnPostBack="true" %>
<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress" TagPrefix="TP_wucUpdateProgress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
    <table style="width: 100%; vertical-align: top; text-align: center;" align="center">
        <tr>
            <td style="vertical-align: top; text-align: right">
                <h2>
                    Sistema de nómina: Notificaciones por usuario
                </h2>
            </td>
        </tr>
        <tr>
            <td style="text-align: left; vertical-align: top;">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
    <asp:GridView ID="gvNotificaciones" runat="server" CellPadding="1" SkinID="SkinGridView" 
                            Width="100%" ShowHeaderWhenEmpty="True">
        <Columns>
            <asp:CommandField ButtonType="Image" SelectImageUrl="~/Imagenes/Select.png" ShowSelectButton="True">
                <ItemStyle HorizontalAlign="Center" />
            </asp:CommandField>
            <asp:TemplateField HeaderText="IdMsj" Visible="False">
                <ItemTemplate>
                    <asp:Label ID="lblIdMsj" runat="server" Text='<%# Bind("IdMsj") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:Label ID="lblIdMsj_E" runat="server" Text='<%# Bind("IdMsj") %>'></asp:Label>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Mensaje de">
                <ItemTemplate>
                    <asp:Label ID="lblLoginOrigen" runat="server" Text='<%# Bind("LoginOrigen") %>' Tooltip='<%# Bind("NombreUsuarioOrigen") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:Label ID="lblLoginOrigen_E" runat="server" Text='<%# Bind("LoginOrigen") %>' Tooltip='<%# Bind("NombreUsuarioOrigen") %>'></asp:Label>
                </EditItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" />                
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Mensaje para">
                <ItemTemplate>
                    <asp:Label ID="lblLoginDestino" runat="server" Text='<%# Bind("LoginDestino") %>' Tooltip='<%# Bind("NombreUsuarioDestino") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:Label ID="lblLoginDestino_E" runat="server" Text='<%# Bind("LoginDestino") %>' Tooltip='<%# Bind("NombreUsuarioDestino") %>'></asp:Label>
                </EditItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:BoundField DataField="Msj" HeaderText="Contenido del mensaje" ReadOnly="True">
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="FechaCreacionMsj" HeaderText="Mensaje creado el" 
                ReadOnly="True" DataFormatString="{0:d}">
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="Atendido">
                <ItemTemplate>
                    <asp:CheckBox ID="ChkBxAtendido" runat="server" Checked='<%# Bind("Atendido") %>'
                        Enabled="False" />
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" />
                <EditItemTemplate>
                    <asp:CheckBox ID="ChkBxAtendido_E" runat="server" Checked='<%# Bind("Atendido") %>' />
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="FechaAtencion" HeaderText="Atendido el" 
                ReadOnly="True" DataFormatString="{0:d}">
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:TemplateField ShowHeader="False">
                <EditItemTemplate>
                    <asp:ImageButton ID="ibGuardar" runat="server" CausesValidation="True" CommandName="Update"
                        ImageUrl="~/Imagenes/CDROM.png" ToolTip="Guardar" />&nbsp;<asp:ImageButton
                            ID="ibCancelar" runat="server" CausesValidation="False" CommandName="Cancel"
                            ImageUrl="~/Imagenes/Eliminar.png" ToolTip="Cancelar" />
                    <ajaxToolkit:ConfirmButtonExtender ID="CBECancelar" runat="server" ConfirmText="La operación solicitada guardará las modificaciones realizadas en la Base de datos, ¿Continuar?"
                        TargetControlID="ibGuardar">
                    </ajaxToolkit:ConfirmButtonExtender>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:ImageButton ID="ibEditar" runat="server" CausesValidation="False" CommandName="Edit"
                        ImageUrl="~/Imagenes/Modificar.png" ToolTip="Modificar" />
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="gvNotificaciones" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="gvNotificaciones" EventName="RowEditing" />
                        <asp:AsyncPostBackTrigger ControlID="gvNotificaciones" EventName="RowCancelingEdit" />
                        <asp:AsyncPostBackTrigger ControlID="gvNotificaciones" EventName="RowDeleting" />
                        <asp:AsyncPostBackTrigger ControlID="gvNotificaciones" EventName="RowUpdating" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>

