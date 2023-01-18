<%@ page language="VB" enableeventvalidation="false" masterpagefile="~/MasterPageSesionNoIniciada.master" autoeventwireup="false" inherits="Login, App_Web_cyyqwboa" title="COBAEV - Nómina" stylesheettheme="SkinFile" maintainScrollPositionOnPostBack="true" %>
<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress"
    TagPrefix="TP_wucUpdateProgress" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
    <div>
        <table style="width: 100%;" align="center">
            <tr>
                <td style="vertical-align: top; text-align: right">
                    <h2>
                        Sistema de nómina: Iniciar sesión
                    </h2>
                </td>
            </tr>
            <tr>
                <td style="height: 250px;" align="center">
                    <asp:Login ID="Login1" runat="server" BackColor="#FFFBD6" BorderColor="#333333" BorderStyle="Solid"
                        BorderWidth="2px" Font-Names="Verdana" Font-Size="0.8em" DisplayRememberMe="False"
                        Height="114px" BorderPadding="4" ForeColor="#333333" DestinationPageUrl="~/Administracion/Quincenas/Quincenas.aspx"
                        
                        
                        FailureText="Su intento de inicio de sesión no fue exitoso. Por favor inténtelo nuevamente.">
                        <TitleTextStyle BackColor="#990000" Font-Bold="True" ForeColor="White" Font-Size="0.9em" />
                        <TextBoxStyle Font-Size="0.8em" />
                        <LoginButtonStyle BackColor="White" BorderColor="#CC9966" BorderStyle="Solid" BorderWidth="1px"
                            Font-Names="Verdana" Font-Size="0.8em" ForeColor="#990000" />
                        <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
                        <LayoutTemplate>
                            <table border="0" cellpadding="4" cellspacing="0" style="border-collapse: collapse">
                                <tr>
                                    <td>
                                        <table border="0" cellpadding="0" style="height: 114px;">
                                            <tr>
                                                <td align="center" colspan="2" style='font-weight: bold; 
                                                    font-size: 0.9em; color:  #333333;
                                                    height: 16px; border-bottom-color: #333333; border-bottom-style: solid; border-bottom-width: 2px; background-color: #E3EAEB;'>
                                                    Credenciales
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Nombre de usuario:</asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="UserName" runat="server" Font-Size="0.8em"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                                        ErrorMessage="Nombre de usuario requerido" ToolTip="El nombre de usuario es obligatorio."
                                                        ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Contraseña:</asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="Password" runat="server" Font-Size="0.8em" TextMode="Password"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                                        ErrorMessage="La contraseña es obligatoria." ToolTip="La contraseña es obligatoria."
                                                        ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="2" style="color: red">
                                                    <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" colspan="2">
                                                    <asp:Button ID="LoginButton" runat="server" BackColor="White" BorderColor="#CC9966"
                                                        BorderStyle="Solid" BorderWidth="1px" CommandName="Login" Font-Names="Verdana"
                                                        Font-Size="0.8em" ForeColor="#990000" Text="Inicio de sesión" ValidationGroup="Login1" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </LayoutTemplate>
                    </asp:Login>
                </td>
            </tr>
            <tr>
                <td style="vertical-align: top; text-align: center">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
    <ContentTemplate>
                            <asp:Label ID="lblError" runat="server" EnableViewState="False" SkinID="SkinLblMsjErrores"></asp:Label>
                         </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="Login1" EventName="Authenticate"></asp:AsyncPostBackTrigger>
                        </Triggers>
                    </asp:UpdatePanel>
                    <asp:Image ID="ImgGifAnim" runat="server" ImageUrl="~/Imagenes/ComodinBlanco.gif" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
