<%@ Page Title="Captura de correo electrónico" Language="VB" MasterPageFile="~/MasterPageSesionNoIniciada.master"
    AutoEventWireup="false" CodeFile="RegistroEmail.aspx.vb" Inherits="RegistroEmail"
    Theme="SkinFile" %>

<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress" TagPrefix="TP_wucUpdateProgress" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                <asp:View ID="View_Captura" runat="server">
                    <table style="width: 100%">
                        <tr>
                            <td style="text-align: left; width: 100%;" colspan="2">
                                <asp:Label ID="Label5" runat="server" SkinID="SkinLblMsjExito" 
                                    
                                    Text="Por favor introduzca los datos que se le piden a continuación. Su correo electrónico será utilizado para enviarle sus notificaciones de pago quincenales de nómina. Es muy importante que su correo sea válido y solo usted conozca las credenciales para ingresar."></asp:Label>
                                    <br /><br />
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left; width: 30%">
                                <asp:Label ID="Label1" runat="server" SkinID="SkinlblGris" 
                                    Text="Número de empleado"></asp:Label>
                            </td>
                            <td style="text-align: left; width: 70%;">
                                <asp:TextBox ID="txtbxNumEmp" runat="server" Columns="30" MaxLength="5" 
                                    SkinID="SkinTextBox" ValidationGroup="Grupo1"></asp:TextBox>
                                <asp:TextBoxWatermarkExtender ID="txtbxNumEmp_TBWMarkExt" runat="server" 
                                    Enabled="True" TargetControlID="txtbxNumEmp" WatermarkCssClass="WaterMark" 
                                    WatermarkText="Ejemplo: 09876">
                                </asp:TextBoxWatermarkExtender>
                                <asp:RequiredFieldValidator ID="rfvNumEmp" runat="server" 
                                    ControlToValidate="txtbxNumEmp" Display="None" 
                                    
                                    ErrorMessage="El Número de empleado es necesario para la operación de registro de correo electrónico." 
                                    ValidationGroup="Grupo1"></asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="cvNumEmp" runat="server" 
                                    ControlToValidate="txtbxNumEmp" Display="None" 
                                    ErrorMessage="Número de empleado incorrecto." Operator="DataTypeCheck" 
                                    Type="Integer" ValidationGroup="Grupo1"></asp:CompareValidator>
                                <asp:RegularExpressionValidator ID="revNumEmp" runat="server" 
                                    ControlToValidate="txtbxNumEmp" Display="None" 
                                    ErrorMessage="Longitud incorrecta del Número de empleado." 
                                    ValidationExpression="\d{5}" ValidationGroup="Grupo1"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left; width: 30%">
                                <asp:Label ID="Label2" runat="server" SkinID="SkinlblGris" Text="R.F.C."></asp:Label>
                            </td>
                            <td style="text-align: left; width: 70%;">
                                <asp:TextBox ID="txtbxRFC" runat="server" Columns="30" MaxLength="13" 
                                    SkinID="SkinTextBox" ValidationGroup="Grupo1"></asp:TextBox>
                                <asp:TextBoxWatermarkExtender ID="txtbxRFC_TBWMarkExt" runat="server" 
                                    Enabled="True" TargetControlID="txtbxRFC" WatermarkCssClass="WaterMark" 
                                    WatermarkText="Ejemplo: FELJ701026G92">
                                </asp:TextBoxWatermarkExtender>
                                <asp:RegularExpressionValidator ID="revRFC" runat="server" ControlToValidate="txtbxRFC"
                                    Display="None" ErrorMessage="R.F.C. incorrecto." 
                                    ValidationExpression="[a-zA-Z]{3,4}(\d{6})((\D|\d){3})" 
                                    ValidationGroup="Grupo1"></asp:RegularExpressionValidator>
                                <asp:RequiredFieldValidator ID="rfvRFC" runat="server" ControlToValidate="txtbxRFC"
                                    Display="None" 
                                    ErrorMessage="El R.F.C. es necesario para la operación de registro de correo electrónico." 
                                    ValidationGroup="Grupo1"></asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="cvRFC" runat="server" ControlToValidate="txtbxRFC" Display="None"
                                    ErrorMessage="R.F.C. incorrecto." Operator="DataTypeCheck" 
                                    ValidationGroup="Grupo1"></asp:CompareValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left; width: 30%">
                                <asp:Label ID="Label3" runat="server" SkinID="SkinlblGris" Text="Correo electrónico"></asp:Label>
                            </td>
                            <td style="text-align: left; width: 70%;">
                                <asp:TextBox ID="txtbxEmail" runat="server" Columns="70" MaxLength="100" 
                                    SkinID="SkinTextBox" ValidationGroup="Grupo1"></asp:TextBox>
                                <asp:TextBoxWatermarkExtender ID="txtbxEmail_TBWMarkExt" runat="server" 
                                    Enabled="True" TargetControlID="txtbxEmail" WatermarkCssClass="WaterMark" 
                                    WatermarkText="Ejemplo: correo@outlook.com">
                                </asp:TextBoxWatermarkExtender>
                                <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtbxEmail"
                                    Display="None" ErrorMessage="Correo electrónico incorrecto." 
                                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                                    ValidationGroup="Grupo1"></asp:RegularExpressionValidator>
                                <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtbxEmail"
                                    Display="None" 
                                    ErrorMessage="El correo electrónico es necesario." 
                                    ValidationGroup="Grupo1"></asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="cvEmail" runat="server" 
                                    ControlToValidate="txtbxEmail" Display="None"
                                    ErrorMessage="Correo electrónico diferente del Correo electrónico de confirmación." 
                                    ValidationGroup="Grupo1" ControlToCompare="txtbxEmail2"></asp:CompareValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left; width: 30%">
                                <asp:Label ID="Label8" runat="server" SkinID="SkinlblGris" 
                                    Text="Confirme su correo electrónico"></asp:Label>
                            </td>
                            <td style="text-align: left; width: 70%;">
                                <asp:TextBox ID="txtbxEmail2" runat="server" Columns="70" MaxLength="100" 
                                    SkinID="SkinTextBox" ValidationGroup="Grupo1"></asp:TextBox>
                                <asp:TextBoxWatermarkExtender ID="txtbxEmail2_TextBoxWatermarkExtender" 
                                    runat="server" Enabled="True" TargetControlID="txtbxEmail2" 
                                    WatermarkCssClass="WaterMark" WatermarkText="Ejemplo: correo@outlook.com">
                                </asp:TextBoxWatermarkExtender>
                                <asp:RegularExpressionValidator ID="revEmail2" runat="server" 
                                    ControlToValidate="txtbxEmail2" Display="None" 
                                    ErrorMessage="Correo electrónico de confirmación incorrecto." 
                                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                                    ValidationGroup="Grupo1"></asp:RegularExpressionValidator>
                                <asp:RequiredFieldValidator ID="rfvEmail2" runat="server" 
                                    ControlToValidate="txtbxEmail2" Display="None" 
                                    ErrorMessage="El correo electrónico de confirmación es necesario." 
                                    ValidationGroup="Grupo1"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left; width: 30%">
                                &nbsp;
                            </td>
                            <td style="text-align: left; width: 70%;">
                                <asp:Button ID="btnGuardar" runat="server" SkinID="SkinBoton" Text="Guardar" 
                                    ValidationGroup="Grupo1" />
                                <asp:ConfirmButtonExtender ID="btnGuardar_CBE" runat="server" ConfirmText="¿La información es correcta?"
                                    Enabled="True" TargetControlID="btnGuardar">
                                </asp:ConfirmButtonExtender>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 30%; text-align: left;">
                                &nbsp;
                            </td>
                            <td style="text-align: left; width: 70%;">
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                                    ShowSummary="False" ValidationGroup="Grupo1" />
                            </td>
                        </tr>
                    </table>
                </asp:View>
                <asp:View ID="View_Results" runat="server">
                    <table style="width: 100%">
                        <tr>
                            <td colspan="2" style="text-align: left; widht: 100%;">
                                <asp:Label ID="Label6" runat="server" SkinID="SkinLblMsjExito" 
                                    
                                    
                                    Text="Su información ha sido recibida correctamente. Hemos enviado a su correo electrónico registrado una clave la cual tendrá que introducir a continuación, de no hacerlo consideraremos incompleto su proceso de registro de correo electrónico y tendrá que repetir todo el proceso."></asp:Label>
                                <br />
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left; widht: 30%;">
                                <asp:Label ID="Label7" runat="server" SkinID="SkinlblGris" 
                                    Text="Introduzca la clave:"></asp:Label>
                            </td>
                            <td style="text-align: left; width: 70%;">
                                <asp:TextBox ID="txtbxClaveViaEmail" runat="server" Columns="20" MaxLength="10" 
                                    SkinID="SkinTextBox" ValidationGroup="Grupo2"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvClaveViaEmail" runat="server" 
                                    ControlToValidate="txtbxClaveViaEmail" Display="None" 
                                    
                                    ErrorMessage="La clave que recibió vía correo electrónico es necesaria para concluir su proceso de registro." 
                                    ValidationGroup="Grupo2"></asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="cvClaveViaEmail" runat="server" 
                                    ControlToValidate="txtbxClaveViaEmail" Display="None" 
                                    ErrorMessage="Clave recibida vía correo electrónico incorrecta." Operator="DataTypeCheck" 
                                    Type="Integer" ValidationGroup="Grupo2"></asp:CompareValidator>
                                <asp:RegularExpressionValidator ID="revClaveViaEmail" runat="server" 
                                    ControlToValidate="txtbxClaveViaEmail" Display="None" 
                                    ErrorMessage="Longitud incorrecta de la clave recibida vía correo electrónico." 
                                    ValidationExpression="\d{10}" ValidationGroup="Grupo2"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left; widht: 30%;">
                                &nbsp;</td>
                            <td style="text-align: left; width: 70%;">
                                <asp:Label ID="lblErrorClaveConfEmail" runat="server" 
                                    SkinID="SkinLblMsjErrores" 
                                    Text="Clave de confirmación incorrecta. Introdúzcala nuevamente." 
                                    Visible="False"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left; widht: 30%;">
                                &nbsp;</td>
                            <td style="text-align: left; width: 70%;">
                                <asp:Button ID="btnGuardar2" runat="server" SkinID="SkinBoton" Text="Guardar" 
                                    ValidationGroup="Grupo2" />
                                <asp:ConfirmButtonExtender ID="btnGuardar2_ConfirmButtonExtender" 
                                    runat="server" ConfirmText="¿La información es correcta?" Enabled="True" 
                                    TargetControlID="btnGuardar2">
                                </asp:ConfirmButtonExtender>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left; widht: 30%;">
                                &nbsp;
                            </td>
                            <td style="text-align: left; width: 70%">
                                <asp:ValidationSummary ID="ValidationSummary2" runat="server" 
                                    ShowMessageBox="True" ShowSummary="False" ValidationGroup="Grupo2" />
                            </td>
                        </tr>
                    </table>
                </asp:View>
                <asp:View ID="View_FinProceso" runat="server">
                    <table style="width: 100%">
                        <tr>
                            <td colspan="2" style="text-align: left; ">
                                <asp:Label ID="Label4" runat="server" SkinID="SkinLblMsjExito" 
                                    
                                    
                                    
                                    
                                    Text="El registro de su información ha concluido satisfactoriamente. Gracias por su apoyo."></asp:Label>
                                <br />
                                <br />
                            </td>
                        </tr>
                    </table>
                </asp:View>
                <asp:View ID="View_Errores" runat="server">
                    <table style="width: 100%">
                        <tr>
                            <td style="text-align: left; ">
                                <asp:Label ID="lblErrores" runat="server" SkinID="SkinLblMsjExito" 
                                    Text="Hemos encontrado inconsistencias en el registro de su información."></asp:Label>
                                <br />
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left; width: 100%;">
                                <asp:GridView ID="gvErrores" runat="server" AutoGenerateColumns="False" 
                                    SkinID="SkinGridView" Width="100%">
                                    <Columns>
                                        <asp:BoundField DataField="Error" HeaderText="Errores">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left; width: 100%;">
                                <asp:Button ID="btnReintentarCaptura" runat="server" CausesValidation="False" 
                                    SkinID="SkinBoton" Text="Reintentar captura" />
                            </td>
                        </tr>
                    </table>
                </asp:View>
            </asp:MultiView>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
