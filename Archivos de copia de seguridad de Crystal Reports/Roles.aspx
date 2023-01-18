<%@ Page Language="VB" MasterPageFile="~/MasterPageSesionIniciada.master" AutoEventWireup="false"
    CodeFile="Roles.aspx.vb" Inherits="Administracion_Roles" Title="COBAEV - Nómina - Administración de roles"
    StylesheetTheme="SkinFile" %>
<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress" TagPrefix="TP_wucUpdateProgress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
    <table style="width: 100%;" align="center">
        <tr>
            <td style="vertical-align: top; text-align: right">
                <h2>
                    Sistema de nómina: Roles de usuario (Administración)
                </h2>
            </td>
        </tr>
    </table>
    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
        <ContentTemplate>
            <asp:MultiView ID="MultiView1" runat="server">
                <asp:View ID="viewCaptura" runat="server">
                    <table style="vertical-align: top; overflow: auto; width: 100%; height: 150px; text-align: left" align="center">
                        <tbody>
                            <tr>
                                <td style="vertical-align: top">
                                    <table cellspacing="0" cellpadding="0">
                                        <tbody>
                                            <tr>
                                                <td style="vertical-align: middle">
                                                    <asp:Label ID="lblElegirRol" runat="server" Visible="False" Text="Elija un rol:"
                                                        SkinID="SkinLblMsjExito"></asp:Label><asp:DropDownList ID="ddlRoles" runat="server"
                                                            Visible="False" SkinID="SkinDropDownList" AutoPostBack="True">
                                                        </asp:DropDownList>
                                                    <asp:Label ID="lblNuevoRol" runat="server" Visible="False" Text="Escriba el nombre del nuevo rol:"
                                                        SkinID="SkinLblMsjExito"></asp:Label><asp:TextBox ID="txtbxNombreRol" runat="server"
                                                            Visible="False" SkinID="SkinTextBox" MaxLength="50" Columns="50"></asp:TextBox>&nbsp;<asp:Button
                                                                ID="btnGuardar" runat="server" Visible="False" Text="Guardar" SkinID="SkinBoton">
                                                            </asp:Button>
                                                </td>
                                                <td style="vertical-align: middle">
                                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                        <ContentTemplate>
                                                            <asp:Button ID="btnModificar" runat="server" Text="Modificar" SkinID="SkinBoton"
                                                                CommandName="Modificar" PostBackUrl="~/Administracion/Roles.aspx?TipoOperacion=0">
                                                            </asp:Button><ajaxToolkit:ConfirmButtonExtender ID="CBEGuardar" runat="server" TargetControlID="btnModificar"
                                                                Enabled="False" ConfirmText="¿Está seguro de guardar los cambios?">
                                                            </ajaxToolkit:ConfirmButtonExtender>
                                                        </ContentTemplate>
                                                        <Triggers>
                                                            <asp:AsyncPostBackTrigger ControlID="btnModificar" EventName="Command"></asp:AsyncPostBackTrigger>
                                                            <asp:AsyncPostBackTrigger ControlID="ddlRoles" EventName="SelectedIndexChanged">
                                                            </asp:AsyncPostBackTrigger>
                                                        </Triggers>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <ajaxToolkit:ConfirmButtonExtender ID="CBEGuardarNuevoRol" runat="server" TargetControlID="btnGuardar"
                                                        Enabled="True" ConfirmText="¿Está seguro de guardar los cambios?">
                                                    </ajaxToolkit:ConfirmButtonExtender>
                                                    <asp:RequiredFieldValidator ID="RFVNombreRol" runat="server" ErrorMessage="Escriba el nombre del nuevo rol."
                                                        Display="None" ControlToValidate="txtbxNombreRol"></asp:RequiredFieldValidator><asp:ValidationSummary
                                                            ID="ValidationSummary1" runat="server" ShowSummary="False" ShowMessageBox="True">
                                                        </asp:ValidationSummary>
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                            <table style="width: 100%">
                                                <tbody>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOpcMenu0" runat="server" SkinID="SkinLblMsjExito" 
                                                                Text="Permisos otorgados"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:CheckBoxList ID="chbxlstOpcsRol" runat="server" Enabled="False" 
                                                                Font-Names="Verdana" Font-Size="Smaller">
                                                                <asp:ListItem Value="0">Consulta zonas específicas</asp:ListItem>
                                                                <asp:ListItem Value="1">Consulta planteles específicos</asp:ListItem>
                                                                <asp:ListItem Value="2">Visibilidad de quincenas adicionales</asp:ListItem>
                                                                <asp:ListItem Value="3">Calcula declaración anual</asp:ListItem>
                                                                <asp:ListItem Value="4">Administrador</asp:ListItem>
                                                            </asp:CheckBoxList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOpcMenu" runat="server" SkinID="SkinLblMsjExito" 
                                                                Text="Opciones que conforman el menú para el rol seleccionado"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:TreeView ID="TreeView1" runat="server" Enabled="False" ShowCheckBoxes="All"
                                                                ImageSet="Arrows" ShowExpandCollapse="False">
                                                                <ParentNodeStyle Font-Bold="False" />
                                                                <HoverNodeStyle Font-Underline="True" ForeColor="#5555DD" />
                                                                <SelectedNodeStyle Font-Underline="True" ForeColor="#5555DD" HorizontalPadding="0px"
                                                                    VerticalPadding="0px" />
                                                                <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" HorizontalPadding="5px"
                                                                    NodeSpacing="0px" VerticalPadding="0px" />
                                                            </asp:TreeView>
                                                            <asp:Button ID="BtnTreeView" runat="server" SkinID="SkinBoton" CausesValidation="False">
                                                            </asp:Button>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="ddlRoles" EventName="SelectedIndexChanged">
                                            </asp:AsyncPostBackTrigger>
                                            <asp:AsyncPostBackTrigger ControlID="btnModificar" EventName="Command"></asp:AsyncPostBackTrigger>
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </asp:View>
                <asp:View ID="viewCapturaExitosa" runat="server">
                    <table style="width: 100%" align="center">
                        <tbody>
                            <tr>
                                <td style="vertical-align: middle; width: 0%; text-align: left">
                                    <asp:Image ID="Image2" runat="server" ImageUrl="~/Imagenes/Symbol-Check.png" Width="100px">
                                    </asp:Image>
                                </td>
                                <td style="vertical-align: middle; text-align: left">
                                    <asp:Label ID="lblCapturaExitosa" runat="server" Text="Captura realizada exitosamente"
                                        SkinID="SkinLblMsjExito"></asp:Label><br />
                                    <br />
                                    <asp:LinkButton ID="lbConsultaRoles" runat="server" SkinID="SkinLinkButton" CausesValidation="False">Consultar/Modificar roles</asp:LinkButton>
                                    |
                                    <asp:LinkButton ID="lbNuevoRol" runat="server" SkinID="SkinLinkButton" CausesValidation="False">Capturar nuevo rol</asp:LinkButton>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </asp:View>
                <asp:View ID="viewErrores" runat="server">
                    <table style="width: 100%" align="center">
                        <tbody>
                            <tr>
                                <td style="vertical-align: middle; width: 0%; text-align: left">
                                    <asp:Image ID="Image3" runat="server" ImageUrl="~/Imagenes/Symbol-Stop.png" Width="100px">
                                    </asp:Image>
                                </td>
                                <td style="vertical-align: middle; text-align: left">
                                    <asp:Label ID="lblErrores" runat="server" SkinID="SkinLblMsjErrores"></asp:Label><br />
                                    <br />
                                    <asp:LinkButton ID="lbReintentarCaptura" runat="server" SkinID="SkinLinkButton" CausesValidation="False">Reintentar captura</asp:LinkButton>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </asp:View>
            </asp:MultiView>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnModificar" EventName="Command"></asp:AsyncPostBackTrigger>
            <asp:AsyncPostBackTrigger ControlID="btnGuardar" EventName="Click"></asp:AsyncPostBackTrigger>
            <asp:AsyncPostBackTrigger ControlID="lbReintentarCaptura" EventName="Click"></asp:AsyncPostBackTrigger>
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
