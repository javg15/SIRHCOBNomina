<%@ page language="VB" masterpagefile="~/MasterPageSesionIniciada.master" autoeventwireup="false" inherits="wfInfParaEnvioRecibosPago, App_Web_sogedhgo" title="COBAEV - Nómina - Cambiar password de usuario" stylesheettheme="SkinFile" maintainScrollPositionOnPostBack="true" %>
<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress" TagPrefix="TP_wucUpdateProgress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
        <table style="width: 100%;" align="center">
        <tr>
            <td style="vertical-align: top; text-align: right">
                <h2>
                    Sistema de nómina: ADMINISTRACIÓN DE DATOS para envío de recibos de pago</h2>
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
                                                    <asp:ChangePassword ID="ChangePassword1" runat="server" BackColor="#FFFBD6" BorderColor="#FFDFAD"
                                                        BorderPadding="4" BorderStyle="Solid" BorderWidth="1px" CancelDestinationPageUrl="~/MenuPrincipal.aspx"
                                                        ContinueDestinationPageUrl="~/MenuPrincipal.aspx" Font-Names="Verdana" Font-Size="Small"
                                                        PasswordLabelText="Contraseña actual:">
                                                        <CancelButtonStyle BackColor="White" BorderColor="#CC9966" BorderStyle="Solid" BorderWidth="1px"
                                                            Font-Names="Verdana" Font-Size="0.8em" ForeColor="#990000" />
                                                        <PasswordHintStyle Font-Italic="True" ForeColor="#888888" />
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
                        <asp:LinkButton ID="lbContinuar" runat="server" PostBackUrl="~/MenuPrincipal.aspx"
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

