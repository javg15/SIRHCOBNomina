<%@ Page Language="VB" MasterPageFile="~/MasterPageBlanca.master" EnableEventValidation="false"
    AutoEventWireup="false" CodeFile="HistoriaClave434.aspx.vb" Inherits="ConsultasDeduccionesHistoriaClave434"
    Title="COBAEV - Nómina - Historia Préstamo Hipotecario FOVISSSTE" StylesheetTheme="SkinFile" %>
<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress" TagPrefix="TP_wucUpdateProgress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
        <table style="width: 100%;" align="center">
        <tr>
            <td style="vertical-align: top; text-align: right">
                <h2>
                    Sistema de nómina: Préstamo hipotecario FOVISSSTE (Nuevo porcentaje)
                </h2>
            </td>
        </tr>
        </table>
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="viewCapturaExitosa" runat="server">
            <table style="width: 70%" align="center">
                <tr>
                    <td style="vertical-align: middle; width: 0%; text-align: left">
                        <asp:Image ID="Image2" runat="server" ImageUrl="~/Imagenes/Symbol-Check.png" Width="100px" />
                    </td>
                    <td style="vertical-align: middle; text-align: left">
                        <asp:Label ID="lblCapturaExitosa" runat="server" SkinID="SkinLblMsjExito" Text="Captura realizada exitosamente"></asp:Label>
                    </td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="viewErrores" runat="server">
            <table style="width: 70%" align="center">
                <tr>
                    <td style="vertical-align: middle; width: 0%; text-align: left">
                        <asp:Image ID="Image3" runat="server" ImageUrl="~/Imagenes/Symbol-Stop.png" Width="100px" />
                    </td>
                    <td style="vertical-align: middle; text-align: left">
                        <asp:Label ID="lblErrores" runat="server" SkinID="SkinLblMsjErrores"></asp:Label><br />
                        <br />
                        <asp:LinkButton ID="lbReintentarCaptura" runat="server" SkinID="SkinLinkButton">Reintentar captura</asp:LinkButton>
                    </td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="viewNuevoPorcDesc" runat="server">
            <table style="width: 70%" align="center">
                <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" SkinID="SkinLblNormal" Text="Nuevo porcentaje de descuento"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtbxNuevoPorcDesc" runat="server" SkinID="SkinTextBox" MaxLength="6"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFVPorcDesc" runat="server" ControlToValidate="txtbxNuevoPorcDesc"
                            Display="None" ErrorMessage="Olvidó escribir el porcentaje de descuento"></asp:RequiredFieldValidator><asp:CompareValidator
                                ID="CVPorcDesc" runat="server" ControlToValidate="txtbxNuevoPorcDesc" Display="None"
                                ErrorMessage="Porcentaje incorrecto" Operator="DataTypeCheck" Type="Double"></asp:CompareValidator><asp:RangeValidator
                                    ID="RVPorcDesc" runat="server" ControlToValidate="txtbxNuevoPorcDesc" Display="None"
                                    ErrorMessage="Rango de valores permitído [0.01-100.00]" MaximumValue="100.00"
                                    MinimumValue="0.01" Type="Double"></asp:RangeValidator><asp:ValidationSummary ID="VSPorcDesc"
                                        runat="server" ShowMessageBox="True" ShowSummary="False" />
                        <ajaxToolkit:FilteredTextBoxExtender ID="FTBEPorcDesc" runat="server" FilterType="Custom, Numbers"
                            TargetControlID="txtbxNuevoPorcDesc" ValidChars=".">
                        </ajaxToolkit:FilteredTextBoxExtender>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label4" runat="server" SkinID="SkinLblNormal" Text="Aplicar descuento a partir de la quincena"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlQnaAplic" runat="server" SkinID="SkinDropDownList">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <asp:Button ID="btnGuardar" runat="server" SkinID="SkinBoton" Text="Guardar" />
                        <ajaxToolkit:ConfirmButtonExtender ID="CBEBtnGuardar" runat="server" ConfirmText="¿Valores correctos?"
                            TargetControlID="btnGuardar">
                        </ajaxToolkit:ConfirmButtonExtender>
                    </td>
                </tr>
            </table>
            <br />
        </asp:View>
    </asp:MultiView>
</asp:Content>
