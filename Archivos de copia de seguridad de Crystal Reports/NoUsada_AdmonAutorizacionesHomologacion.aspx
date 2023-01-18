<%@ Page Language="VB" MasterPageFile="~/MasterPageBlanca.master" AutoEventWireup="false" CodeFile="NoUsada_AdmonAutorizacionesHomologacion.aspx.vb" Inherits="ABC_Empleados_AdmonAutorizacionesHomologacion" title="COBAEV - Nómina - Administrar autorizaciones para homologación" StylesheetTheme="SkinFile" %>

<%@ Register Src="../../WebControls/wucBuscaEmpleados.ascx" TagName="wucBuscaEmpleados"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <table style="width: 100%; height: 100%">
            <tr>
                <td>
                    <asp:MultiView ID="MultiView1" runat="server">
                        <asp:View ID="viewAutorizacion" runat="server">
                            <table style="width: 100%">
                                <tr>
                                    <td>
                            <uc1:wucBuscaEmpleados ID="WucBuscaEmpleados1" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                <ContentTemplate>
                                    <asp:Panel ID="pnlOpcionesDeConsulta" runat="server"
                                        Font-Names="Verdana" Font-Size="X-Small" GroupingText="Seleccione quincena para aplicación" Width="100%">
                                        <br />
                                        <asp:DropDownList
                                            ID="ddlQnas" runat="server" SkinID="SkinDropDownList">
                                        </asp:DropDownList><br />
                                    </asp:Panel>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: right">
                                        <asp:Button ID="btnGuardar" runat="server" SkinID="SkinBoton"
                                            Text="Guardar" />
                                        <ajaxToolkit:ConfirmButtonExtender ID="CBEBtnGuardar" runat="server" ConfirmText="¿Información correcta?"
                                            TargetControlID="btnGuardar">
                                        </ajaxToolkit:ConfirmButtonExtender>
                                    </td>
                                </tr>
                            </table>
                        </asp:View>
                        <asp:View ID="viewExito" runat="server">
                            <table>
                                <tr>
                                    <td style="vertical-align: middle; text-align: left">
                                        <asp:Image ID="Image2" runat="server" ImageUrl="~/Imagenes/Symbol-Check.png" Width="100px" /></td>
                                    <td style="vertical-align: middle; text-align: left">
                                        <asp:Label ID="lblExito" runat="server" SkinID="SkinLblMsjExito" Text="Autorización creada exitosamente."></asp:Label><br />
                                        <br />
                                        <asp:LinkButton ID="lbCerrar" runat="server" SkinID="SkinLinkButton">Cerrar ventana</asp:LinkButton></td>
                                </tr>
                            </table>
                        </asp:View>
                        <asp:View ID="viewError" runat="server">
                            <table>
                                <tr>
                                    <td style="vertical-align: middle; text-align: left">
                                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/Symbol-Stop.png" Width="100px" /></td>
                                    <td style="vertical-align: middle; text-align: left">
                                        <asp:Label ID="lblError" runat="server" SkinID="SkinLblMsjErrores"></asp:Label><br />
                                        <br />
                                        <asp:LinkButton ID="lbContinuar" runat="server" SkinID="SkinLinkButton" Visible="False">Continuar</asp:LinkButton></td>
                                </tr>
                            </table>
                        </asp:View>
                    </asp:MultiView></td>
            </tr>
            <tr>
                <td>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

