<%@ page title="Solicitud de pago de prestaciones" language="VB" masterpagefile="~/MasterPageSesionNoIniciada.master" autoeventwireup="false" inherits="SolicitudEstPuntyAsist, App_Web_4btqp3v2" theme="SkinFile" %>

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
                            <h2>
                                Solicitud de pago de prestaciones<br />
                            </h2>
                        </td>
                    </tr>
                        <tr>
                            <td style="text-align: left; width: 100%;" colspan="2">
                                <asp:Label ID="Label5" runat="server" SkinID="SkinLblMsjExito" 
                                    
                                    Text="Por favor introduzca los datos que se le piden a continuación "></asp:Label>
                                    <br /><br />
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left; width: 20%">
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
                                    
                                    ErrorMessage="El Número de empleado es necesario para la operación solicitada." 
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
                            <td style="text-align: left; width: 20%">
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
                                    ErrorMessage="El R.F.C. es necesario para la operación solicitada." 
                                    ValidationGroup="Grupo1"></asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="cvRFC" runat="server" ControlToValidate="txtbxRFC" Display="None"
                                    ErrorMessage="R.F.C. incorrecto." Operator="DataTypeCheck" 
                                    ValidationGroup="Grupo1"></asp:CompareValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left; width: 20%">
                                <asp:Label ID="Label7" runat="server" SkinID="SkinlblGris" 
                                    Text="Correo electrónico:"></asp:Label>
                            </td>
                            <td style="text-align: left; width: 70%;">
                                <asp:TextBox ID="txtbxEmail" runat="server" Columns="50" MaxLength="100" 
                                    SkinID="SkinTextBox" ValidationGroup="Grupo1"></asp:TextBox>
                                <asp:TextBoxWatermarkExtender ID="txtbxEmail_TextBoxWatermarkExtender" 
                                    runat="server" Enabled="True" TargetControlID="txtbxEmail" 
                                    WatermarkCssClass="WaterMark" WatermarkText="Ejemplo: correo@outlook.com">
                                </asp:TextBoxWatermarkExtender>
                                <asp:RegularExpressionValidator ID="revEmail" runat="server" 
                                    ControlToValidate="txtbxEmail" Display="None" 
                                    ErrorMessage="Correo electrónico incorrecto." 
                                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                                    ValidationGroup="Grupo1" Enabled="False" EnableTheming="True"></asp:RegularExpressionValidator>
                                <asp:RequiredFieldValidator ID="rfvEmail" runat="server" 
                                    ControlToValidate="txtbxEmail" Display="None" 
                                    ErrorMessage="El correo electrónico es necesario para la operación solicitada." 
                                    ValidationGroup="Grupo1"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left; width: 20%">
                                <asp:Label ID="Label8" runat="server" SkinID="SkinlblGris" 
                                    Text="Prestaciones solicitadas:"></asp:Label>
                            </td>
                            <td style="text-align: left; width: 70%;">
                                <asp:CheckBox ID="chkbxEstPunt" runat="server" AutoPostBack="True" 
                                    SkinID="SkinCheckBox" 
                                    Text="1a. Parte del Estímulo de Puntualidad y Asistencia 2015" />
                                <br />
                                <asp:CheckBox ID="chkbxDiasEco" runat="server" AutoPostBack="True" 
                                    SkinID="SkinCheckBox" Text="Días Económicos no Disfrutados  en el 2015" 
                                    Visible="False" />
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left; width: 20%">
                                &nbsp;
                            </td>
                            <td style="text-align: left; width: 70%;">
                                <asp:Button ID="btnGuardar" runat="server" SkinID="SkinBoton" Text="Continuar" 
                                    ValidationGroup="Grupo1" Enabled="False" />
                                <asp:ConfirmButtonExtender ID="btnGuardar_CBE" runat="server" ConfirmText="¿La información es correcta?"
                                    Enabled="True" TargetControlID="btnGuardar">
                                </asp:ConfirmButtonExtender>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 20%; text-align: left;">
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
                        <td style="text-align: left; width: 100%;" colspan="2">
                            <h2>
                                Solicitud de pago de prestaciones<br />
                            </h2>
                        </td>
                    </tr>
                        <tr>
                            <td style="text-align: left; widht: 100%;">
                                <asp:Label ID="Label6" runat="server" SkinID="SkinLblMsjExito" 
                                    Text="Su solicitud ha sido registrada con éxito. "></asp:Label>
                                <br />
                                <br />
                            </td>
                        </tr>
                    </table>
                </asp:View>
                <asp:View ID="View_Errores" runat="server">
                    <table style="width: 100%">
                    <tr>
                        <td style="text-align: left; width: 100%;" colspan="2">
                            <h2>
                                Solicitud de pago de prestaciones<br />
                            </h2>
                        </td>
                    </tr>
                        <tr>
                            <td style="text-align: left; ">
                                <asp:Label ID="lblErrores" runat="server" SkinID="SkinLblMsjExito" 
                                    Text="Hemos encontrado inconsistencias en el registro de su solicitud."></asp:Label>
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
