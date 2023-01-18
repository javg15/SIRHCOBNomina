<%@ page language="VB" masterpagefile="~/MasterPageBlanca.master" autoeventwireup="false" inherits="ABC_Recibos_AgregarEmpsParaRecibos, App_Web_5lgpnrst" title="COBAEV - Nómina - Agregar empleados para recibos" stylesheettheme="SkinFile" maintainScrollPositionOnPostBack="true" %>

<%@ Register Src="../../WebControls/wucSearchEmps.ascx" TagName="wucBuscaEmpleados"
    TagPrefix="uc1" %>
<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress"
    TagPrefix="TP_wucUpdateProgress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        <table style="width: 100%; vertical-align: top; text-align: center;">
            <tr>
                <td style="vertical-align: top; text-align: right">
                    <h2>
                        Sistema de nómina: Agregar empleado para recibo de pago fuera de nómina
                    </h2>
                </td>
            </tr>
            </table>
            <asp:MultiView ID="MultiView1" runat="server">
                <asp:View ID="View_Principal" runat="server">
                    <table style="width: 100%; vertical-align: top; text-align: center; height: 300px;">
                        <tr>
                            <td style="vertical-align: top; width: 100%; height: 100%; text-align: left">
                                <table style="width: 100%; background-position: center center; vertical-align: top;
                                    background-repeat: no-repeat; text-align: center;">
                                    <tr>
                                        <td style="text-align: left; vertical-align: top;">
                                            <uc1:wucBuscaEmpleados ID="WucBuscaEmpleados1" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="vertical-align: top; text-align: left;">
                                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                <ContentTemplate>
                                                    <asp:Button ID="btnAgregar" runat="server" SkinID="SkinBoton" Text="Agregar" ToolTip="Agregar empleado para poder generarle recibos" /><ajaxToolkit:ConfirmButtonExtender
                                                        ID="ConfirmButtonExtender1" runat="server" ConfirmText="La operación solicitada guardará las modificaciones realizadas en la Base de datos, ¿Continuar?"
                                                        TargetControlID="btnAgregar">
                                                    </ajaxToolkit:ConfirmButtonExtender>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="WucBuscaEmpleados1" EventName="PreRender" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="vertical-align: top; text-align: left">
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </asp:View>
                <asp:View ID="View_Exito" runat="server">
                    <table>
                        <tr>
                            <td style="vertical-align: middle; text-align: left">
                                <asp:Image ID="Image2" runat="server" ImageUrl="~/Imagenes/Symbol-Check.png" Width="100px" />
                            </td>
                            <td style="vertical-align: middle; text-align: left">
                                <asp:Label ID="lblExito" runat="server" SkinID="SkinLblMsjExito"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </asp:View>
                <asp:View ID="View_Errores" runat="server">
                    <table>
                        <tr>
                            <td style="vertical-align: middle; text-align: left">
                                <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/Symbol-Stop.png" Width="100px" />
                            </td>
                            <td style="vertical-align: middle; text-align: left">
                                <asp:Label ID="lblError" runat="server" SkinID="SkinLblMsjErrores"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </asp:View>
            </asp:MultiView>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnAgregar" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
