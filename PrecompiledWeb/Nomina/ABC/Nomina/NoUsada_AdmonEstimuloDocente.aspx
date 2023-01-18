<%@ page language="VB" masterpagefile="~/MasterPageBlanca.master" autoeventwireup="false" inherits="ABC_Nomina_AdmonEstimuloDocente, App_Web_sogedhgo" title="COBAEV - Nómina - Administrar estímulos docentes" stylesheettheme="SkinFile" maintainScrollPositionOnPostBack="true" %>
<%@ PreviousPageType VirtualPath="~/Consultas/Percepciones/NoUsada_EstimuloDocente.aspx" %> 
<%@ Register Src="../../WebControls/wucBuscaEmpleados.ascx" TagName="wucBuscaEmpleados"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <table style="width: 100%; height: 100%">
            <tr>
                <td>
                    <asp:MultiView ID="MultiView1" runat="server">
                        <asp:View ID="viewOperacion" runat="server">
                            <table style="width: 100%">
                                <tr>
                                    <td>
                            <uc1:wucBuscaEmpleados ID="WucBuscaEmpleados1" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left">
                                        <asp:Label ID="Label1" runat="server" SkinID="SkinLblNormal" Text="Importe: "></asp:Label>
                                        <asp:TextBox ID="txtbxImporte" runat="server" MaxLength="10" SkinID="SkinTextBox"></asp:TextBox>
                                        <asp:RequiredFieldValidator
                                            ID="RFVImportePercepcion" runat="server" ControlToValidate="txtbxImporte" Display="Dynamic"
                                            ErrorMessage="*"></asp:RequiredFieldValidator><asp:CompareValidator ID="CVImportePercepcion"
                                                runat="server" ControlToValidate="txtbxImporte" Display="Dynamic" ErrorMessage="Importe incorrecto"
                                                Operator="DataTypeCheck" Type="Currency"></asp:CompareValidator></td>
                                </tr>
                                <tr>
                                    <td style="text-align: left">
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
                                        <asp:Label ID="lblExito" runat="server" SkinID="SkinLblMsjExito" Text="Operación realizada exitosamente."></asp:Label><br />
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

