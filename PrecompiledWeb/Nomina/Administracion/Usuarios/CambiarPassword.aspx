<%@ page language="VB" masterpagefile="~/MasterPageSesionIniciada.master" autoeventwireup="false" inherits="Administracion_Usuarios_CambiarPassword, App_Web_malua2mc" title="COBAEV - Nómina - Cambiar password de usuario" stylesheettheme="SkinFile" maintainScrollPositionOnPostBack="true" %>
<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress" TagPrefix="TP_wucUpdateProgress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
        <table style="width: 100%;" align="center">
        <tr>
            <td style="vertical-align: top; text-align: right">
                <h2>
                    Sistema de nómina: Cambiar contraseña de usuario
                </h2>
            </td>
        </tr>
    </table>
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="viewCambioPassw" runat="server">
            <table style="width: 100%; height: 300px" align="center">
                <tr>
                    <td style="vertical-align: top; width: 100%; height: 100%;" align="center">
                        <table style="width: 100%" align="center">
                            <tr>
                                <td style="vertical-align: top; height: 213px; text-align: left">
                                    <ajaxToolkit:CollapsiblePanelExtender ID="CPEUsuarios" runat="Server" CollapseControlID="TitlePanelUsuarios"
                                        Collapsed="False" CollapsedImage="~/Imagenes/expand_blue.jpg" CollapsedText="(Mostrar panel...)"
                                        ExpandControlID="TitlePanelUsuarios" ExpandedImage="~/Imagenes/collapse_blue.jpg"
                                        ExpandedText="(Ocultar panel...)" ImageControlID="Image1" SuppressPostBack="true"
                                        TargetControlID="ContentPanelUsuarios" TextLabelID="Label1">
                                    </ajaxToolkit:CollapsiblePanelExtender>
                                    <table cellpadding="0" cellspacing="0" style="width: 100%" align="center">
                                        <tr>
                                            <td colspan="2" style="vertical-align: top; text-align: left; height: 81px;">
                                                <asp:Panel ID="TitlePanelUsuarios" runat="server" BorderColor="White" BorderStyle="Solid"
                                                    BorderWidth="1px" CssClass="collapsePanelHeader" Width="100%">
                                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/expand_blue.jpg" />
                                                    Modificar contraseña de usuario &nbsp;<asp:Label ID="Label1" runat="server">(Mostrar detalles...)</asp:Label>
                                                </asp:Panel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="vertical-align: top;" align="center">
                                                <asp:Panel ID="ContentPanelUsuarios" runat="server" CssClass="collapsePanel" Width="100%">
                                                    <asp:ChangePassword ID="ChangePassword1" runat="server" BackColor="#FFFBD6" BorderColor="#333333"
                                                        BorderPadding="4" BorderStyle="Solid" BorderWidth="2px" CancelDestinationPageUrl="~/Administracion/Quincenas/Quincenas.aspx"
                                                        ContinueDestinationPageUrl="~/Administracion/Quincenas/Quincenas.aspx" Font-Names="Verdana" Font-Size="0.9em"
                                                        PasswordLabelText="Contraseña actual:">
                                                        <CancelButtonStyle BackColor="White" BorderColor="#CC9966" BorderStyle="Solid" BorderWidth="1px"
                                                            Font-Names="Verdana" Font-Size="0.9em" ForeColor="#990000" />
                                                        <PasswordHintStyle Font-Italic="True" ForeColor="#888888" />
                                                        <ChangePasswordTemplate>
                                                            <table cellpadding="4" cellspacing="0" style="border-collapse:collapse;">
                                                                <tr>
                                                                    <td>
                                                                        <table cellpadding="2px" style="height: 114px; width:350px;">
                                                                            <tr>
                                                                                <td align="center" colspan="2" 
                                                                                    style='font-weight: bold; font-size: 0.9em; color:  #333333;
                                                                                    height: 16px; border-bottom-color: #808080; border-bottom-width: 2px; 
                                                                                    border-bottom-style: solid; background-color: #E3EAEB;'">
                                                                                    Modificar contraseña</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="right" style="padding-top: 5px">
                                                                                    <asp:Label ID="CurrentPasswordLabel" runat="server" 
                                                                                        AssociatedControlID="CurrentPassword">Contraseña actual:</asp:Label>
                                                                                </td>
                                                                                <td style="padding-top: 5px">
                                                                                    <asp:TextBox ID="CurrentPassword" runat="server" Font-Size="0.8em" 
                                                                                        TextMode="Password"></asp:TextBox>
                                                                                    <asp:RequiredFieldValidator ID="CurrentPasswordRequired" runat="server" 
                                                                                        ControlToValidate="CurrentPassword" ErrorMessage="La contraseña actual es obligatoria." 
                                                                                        ToolTip="La contraseña actual es obligatoria." ValidationGroup="ChangePassword1">*</asp:RequiredFieldValidator>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="right">
                                                                                    <asp:Label ID="NewPasswordLabel" runat="server" 
                                                                                        AssociatedControlID="NewPassword">New Password:</asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="NewPassword" runat="server" Font-Size="0.8em" 
                                                                                        TextMode="Password"></asp:TextBox>
                                                                                    <asp:RequiredFieldValidator ID="NewPasswordRequired" runat="server" 
                                                                                        ControlToValidate="NewPassword" ErrorMessage="La nueva contraseña es obligatoria." 
                                                                                        ToolTip="La nueva contraseña es obligatoria." ValidationGroup="ChangePassword1">*</asp:RequiredFieldValidator>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="right">
                                                                                    <asp:Label ID="ConfirmNewPasswordLabel" runat="server" 
                                                                                        AssociatedControlID="ConfirmNewPassword">Confirm New Password:</asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="ConfirmNewPassword" runat="server" Font-Size="0.8em" 
                                                                                        TextMode="Password"></asp:TextBox>
                                                                                    <asp:RequiredFieldValidator ID="ConfirmNewPasswordRequired" runat="server" 
                                                                                        ControlToValidate="ConfirmNewPassword" 
                                                                                        ErrorMessage="Confirmar la nueva contraseña es obligatorio." 
                                                                                        ToolTip="Confirmar la nueva contraseña es obligatorio." ValidationGroup="ChangePassword1">*</asp:RequiredFieldValidator>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="center" colspan="2">
                                                                                    <asp:CompareValidator ID="NewPasswordCompare" runat="server" 
                                                                                        ControlToCompare="NewPassword" ControlToValidate="ConfirmNewPassword" 
                                                                                        Display="Dynamic" 
                                                                                        ErrorMessage="Error al confirmar la nueva contraseña." 
                                                                                        ValidationGroup="ChangePassword1"></asp:CompareValidator>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="center" colspan="2" style="color:Red;">
                                                                                    <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="right">
                                                                                    <asp:Button ID="ChangePasswordPushButton" runat="server" BackColor="White" 
                                                                                        BorderColor="#CC9966" BorderStyle="Solid" BorderWidth="1px" 
                                                                                        CommandName="ChangePassword" Font-Names="Verdana" Font-Size="0.9em" 
                                                                                        ForeColor="#990000" Text="Cambiar contraseña" 
                                                                                        ValidationGroup="ChangePassword1" />
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Button ID="CancelPushButton" runat="server" BackColor="White" 
                                                                                        BorderColor="#CC9966" BorderStyle="Solid" BorderWidth="1px" 
                                                                                        CausesValidation="False" CommandName="Cancel" Font-Names="Verdana" 
                                                                                        Font-Size="0.9em" ForeColor="#990000" Text="Cancelar" 
                                                                                       />
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </ChangePasswordTemplate>
                                                        <ContinueButtonStyle BackColor="White" BorderColor="#CC9966" BorderStyle="Solid"
                                                            BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#990000" />
                                                        <ChangePasswordButtonStyle BackColor="White" BorderColor="#CC9966" BorderStyle="Solid"
                                                            BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#990000" />
                                                        <TitleTextStyle BackColor="#990000" Font-Bold="True" Font-Size="0.9em" ForeColor="White" />
                                                        <TextBoxStyle Font-Size="0.8em" />
                                                        <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
                                                    </asp:ChangePassword>
                                                    &nbsp;</asp:Panel>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="viewCapturaExitosa" runat="server">
            <table style="width: 100%" align="center">
                <tr>
                    <td style="vertical-align: middle; width: 0%; text-align: left">
                        <asp:Image ID="Image2" runat="server" ImageUrl="~/Imagenes/Symbol-Check.png" Width="100px" /></td>
                    <td style="vertical-align: middle; text-align: left">
                        <asp:Label ID="lblCapturaExitosa" runat="server" SkinID="SkinLblMsjExito" Text="Contraseña cambiada correctamente."></asp:Label><br />
                        <br />
                        <asp:LinkButton ID="lbContinuar" runat="server" PostBackUrl="~/Administracion/Quincenas/Quincenas.aspx"
                            SkinID="SkinLinkButton">Continuar</asp:LinkButton></td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="viewErrores" runat="server">
            <table style="width: 100%" align="center">
                <tr>
                    <td style="vertical-align: middle; width: 0%; text-align: left">
                        <asp:Image ID="Image3" runat="server" ImageUrl="~/Imagenes/Symbol-Stop.png" Width="100px" /></td>
                    <td style="vertical-align: middle; text-align: left">
                        <asp:Label ID="lblErrores" runat="server" SkinID="SkinLblMsjErrores"></asp:Label>
                        <br />
                        <br />
                        <asp:LinkButton ID="lbReintentarCaptura" runat="server" SkinID="SkinLinkButton">Reintentar captura</asp:LinkButton></td>
                </tr>
            </table>
        </asp:View>
    </asp:MultiView>
</asp:Content>

