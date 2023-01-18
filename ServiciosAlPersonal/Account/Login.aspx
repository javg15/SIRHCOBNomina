<%@ Page Title="COBAEV - Iniciar sesión" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="false"
    CodeFile="Login.aspx.vb" Inherits="Account_Login" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2 class="alineadoIzquierda">Inicio de sesión</h2>
    <div class="accountInfoCenter" align="center">
            <asp:Login ID="Login1" runat="server" BackColor="#FFFBD6" BorderColor="Maroon" BorderStyle="Solid"
                BorderWidth="1px" Font-Names="Verdana" DisplayRememberMe="False"
                Height="114px" BorderPadding="4" ForeColor="#333333" DestinationPageUrl="~/Administracion/Quincenas/Quincenas.aspx"
                FailureText="Su intentó de inicio de sesión no fue exitoso. Por favor inténtelo nuevamente.">
                <TitleTextStyle BackColor="#990000" Font-Bold="True" ForeColor="White"/>
                <TextBoxStyle />
                <LoginButtonStyle BackColor="White" BorderColor="#CC9966" BorderStyle="Solid" BorderWidth="1px"
                    Font-Names="Verdana" ForeColor="#990000" />
                <InstructionTextStyle Font-Italic="True" ForeColor="Black" />

                <LayoutTemplate>
                    <table border="0" cellpadding="4" cellspacing="0" style="border-collapse: collapse;">
                        <tr>
                            <td>
                                <table border="0" cellpadding="0" style="height: 114px;">
                                    <tr>
                                        <td colspan="2" style="font-weight: bold; color: maroon; background-color: #ffcc66; text-align:center;">Ingrese sus credenciales
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">R.F.C.:</asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="UserName" runat="server" MaxLength="13" Width="168px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" ErrorMessage="Nombre de usuario requerido" ToolTip="El nombre de usuario es obligatorio." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr style="height:5px;">
                                        <td colspan="2">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Contraseña:</asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="Password" runat="server" TextMode="Password" Width="168px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" ErrorMessage="La contraseña es obligatoria." ToolTip="La contraseña es obligatoria." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="2" style="color: red">
                                            <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" colspan="2" style="text-align: center">
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="text-align: center">&nbsp;</td>
                                        <td align="right" style="text-align: center">
                                            <asp:Button ID="LoginButton" runat="server" BackColor="White" BorderColor="#CC9966" BorderStyle="Solid" BorderWidth="1px" CommandName="Login" Font-Names="Verdana" ForeColor="#990000" Text="Inicio de sesión" ValidationGroup="Login1" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" colspan="2" style="text-align: center">
                                            &nbsp;</td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </LayoutTemplate>
            </asp:Login>
    </div>
    <div style="text-align:center;">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
                <ContentTemplate>
                    <asp:Label ID="lblError" runat="server" EnableViewState="False" SkinID="SkinLblMsjErrores"></asp:Label>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="Login1" EventName="Authenticate"></asp:AsyncPostBackTrigger>
                </Triggers>
            </asp:UpdatePanel>
        <br />
       <asp:LinkButton ID="lbRecuperaContrasenia" runat="server" PostBackUrl="~/Account/wfRecuperaContrasenia.aspx">¿Olvidaste tu contraseña?</asp:LinkButton>
        <br />
        <asp:Label ID="Label1" runat="server" Text="¿No dispones de una cuenta? "></asp:Label>
        <asp:LinkButton ID="lbCrearCuenta" runat="server" PostBackUrl="~/Account/wfRecuperaContrasenia.aspx">Regístrate ahora</asp:LinkButton>
        <br />
        <asp:Image ID="ImgGifAnim" runat="server" ImageUrl="~/Imagenes/ComodinBlanco.gif" style="text-align: left" />
    </div>
</asp:Content>
