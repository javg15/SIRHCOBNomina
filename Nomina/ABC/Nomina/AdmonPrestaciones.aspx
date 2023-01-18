<%@ Page Language="VB" enableEventValidation="false" MasterPageFile="~/MasterPageSesionIniciada.master" AutoEventWireup="false" 
CodeFile="AdmonPrestaciones.aspx.vb" Inherits="AdmonPrestaciones" title="COBAEV - Nómina - Admistración de prestaciones"
StylesheetTheme="SkinFile" %>
<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress" TagPrefix="TP_wucUpdateProgress" %>
<%@ Register src="../../WebControls/wucSearchEmps.ascx" tagname="wucSearchEmps" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<style type="text/css">
    .modalBackground
    {
        background-color:Silver;
        filter: alpha(opacity=60);
        opacity: 0.5;
    }
    .modalPopup
    {
        background-color: #FFFFFF;
        border-width: 3px;
        border-style: solid;
        border-color: maroon;
        padding-top: 5px;
        padding-left: 5px;
        padding-right: 15px;
        width: 1000px;
        height: 500px;
    }
 </style>
    <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
    <table style="width: 100%; vertical-align: top; text-align: center;" align="center">
        <tr>
            <td style="vertical-align: top; text-align: right">
                <h2>
                    Sistema de nómina: Administración de prestaciones</h2>
            </td>
        </tr>
        <tr>
            <td style="text-align: left; vertical-align: top;">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
    <asp:GridView ID="gvEjersFisc" runat="server" CellPadding="1" SkinID="SkinGridView" Width="100%" 
    OnSelectedIndexChanged="gvEjersFisc_SelectedIndexChanged" 
                            OnRowCancelingEdit="gvEjersFisc_RowCancelingEdit" 
                            OnRowEditing="gvEjersFisc_RowEditing" OnRowDeleting="gvEjersFisc_RowDeleting" 
                            OnRowUpdating="gvEjersFisc_RowUpdating" 
                            OnRowDataBound="gvEjersFisc_RowDataBound">
        <Columns>
            <asp:CommandField ButtonType="Image" SelectImageUrl="~/Imagenes/Select.png" ShowSelectButton="True">
                <ItemStyle HorizontalAlign="Center" />
            </asp:CommandField>
            <asp:TemplateField HeaderText="Ejercicio">
                <ItemTemplate>
                    <asp:Label ID="lblAnio" runat="server" Text='<%# Bind("Ejercicio") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:Label ID="lblAnioE" runat="server" Text='<%# Bind("Ejercicio") %>'></asp:Label>
                </EditItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" Wrap="false" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Estatus">
                <EditItemTemplate>
                    <asp:CheckBox ID="chbxConcluidoE" runat="server" Text="Concluido" Enabled="false" Checked='<%# Bind("Concluido") %>' />
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:CheckBox ID="chbxConcluido" runat="server"  Enabled="false" Checked='<%# Bind("Concluido") %>' Text="Concluido" />
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" Wrap="false" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Solicitudes de pago de Estímulo de Puntualidad y Asistencia">
                <EditItemTemplate>
                    <asp:CheckBox ID="chbxCapt1aParteClave125E" runat="server" Text="Permite captura"
                        Checked='<%# Bind("PermiteCapt1aParteClave125") %>' />
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:CheckBox ID="chbxCapt1aParteClave125" runat="server" Text="Permite captura"
                        Checked='<%# Bind("PermiteCapt1aParteClave125") %>' Enabled="False" />
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" Wrap="false" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Solicitudes de pago de Estímulo de Puntualidad y Asistencia">
                <EditItemTemplate>
                    <asp:CheckBox ID="chbxCapt2aParteClave125E" runat="server" Text="Permite captura"
                        Checked='<%# Bind("PermiteCapt2aParteClave125") %>' />
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:CheckBox ID="chbxCapt2aParteClave125" runat="server" Text="Permite captura"
                        Checked='<%# Bind("PermiteCapt2aParteClave125") %>' Enabled="False" />
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" Wrap="false" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Solicitudes de pago de Días Económicos No Disfrutados">
                <EditItemTemplate>
                    <asp:CheckBox ID="chbxCaptClave181E" runat="server" Text="Permite captura"
                        Checked='<%# Bind("PermiteCaptClave181") %>' />
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:CheckBox ID="chbxCaptClave181" runat="server" Text="Permite captura"
                        Checked='<%# Bind("PermiteCaptClave181") %>' Enabled="False" />
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" Wrap="false" />
            </asp:TemplateField>
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
                <ItemStyle HorizontalAlign="Center" Wrap="false" />
            </asp:TemplateField>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:ImageButton ID="ibEliminar" runat="server" CausesValidation="False" CommandName="Delete"
                        ImageUrl="~/Imagenes/Eliminar.png" ToolTip="Eliminar" />
                    <ajaxToolkit:ConfirmButtonExtender ID="CBEEliminar" runat="server" ConfirmText="La operación solicitada eliminará el registro de la Base de datos, ¿Continuar?"
                        TargetControlID="ibEliminar">
                    </ajaxToolkit:ConfirmButtonExtender>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Wrap="false" />
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="gvEjersFisc" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="gvEjersFisc" EventName="RowEditing" />
                        <asp:AsyncPostBackTrigger ControlID="gvEjersFisc" EventName="RowCancelingEdit" />
                        <asp:AsyncPostBackTrigger ControlID="gvEjersFisc" EventName="RowDeleting" />
                        <asp:AsyncPostBackTrigger ControlID="gvEjersFisc" EventName="RowUpdating" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>

