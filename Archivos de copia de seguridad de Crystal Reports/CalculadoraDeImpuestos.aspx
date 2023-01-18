<%@ Page EnableEventValidation="false" Language="VB" MasterPageFile="~/MasterPageSesionIniciada.master"
    AutoEventWireup="false" CodeFile="CalculadoraDeImpuestos.aspx.vb" Inherits="Herramientas_CalculadoraDeImpuestos"
    Title="COBAEV - Nómina - Calculadora de impuestos" StylesheetTheme="SkinFile" %>

<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress"
    TagPrefix="TP_wucUpdateProgress" %>
<%@ Register Src="~/WebControls/wucSearchEmps.ascx" TagName="wucSearchEmps" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <table style="width: 100%; height: 300px" align="center">
            <tr>
                <td style="vertical-align: top; text-align: right">
                    <h2>
                        Sistema de nómina: Calculadora de impuestos
                    </h2>
                </td>
            </tr>
                    <tr>
                        <td style="vertical-align: top; text-align: left">
                            <table style="width: 100%">
                                <tr>
                                    <td>
                                        <uc1:wucSearchEmps ID="wucSearchEmps1" runat="server" EnableViewState="true" />
                                    </td>
                                    <td style="vertical-align: top; text-align: right">
                                        &nbsp;<asp:ImageButton ID="ibActualizar" runat="server" ImageUrl="~/Imagenes/Refresh.jpg"
                                            ToolTip="Actualizar información" Visible="False" /><br />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
        <tr>
            <td style="vertical-align: top; width: 100%; height: 100%; text-align: left">
            <asp:Panel ID="pnlDatosParaImpuesto" runat="server" 
                    GroupingText="Introduzca los valores para cálculo de impuesto" 
                    DefaultButton="btnCalcular">
                <table style="width: 100%">
                    <tr>
                        <td style="vertical-align: top; width: 290px; text-align: left">
                            <asp:Label ID="Label1" runat="server" SkinID="SkinLblNormal" Text="Tipo de impuesto"></asp:Label>
                        </td>
                        <td style="vertical-align: top; text-align: left">
                            <asp:DropDownList ID="ddlTipoImpuesto" runat="server" SkinID="SkinDropDownList" OnSelectedIndexChanged="ddlTipoImpuesto_SelectedIndexChanged"
                                AutoPostBack="True">
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
<%--                <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="500" DynamicLayout="true">
                    <ProgressTemplate>
                        <div id="ParentDiv">
                        </div>
                        <div id="div1" runat="server" align="center" valign="middle" style="width: 100%;
                            height: 200%; position: absolute; left: 0; top: 0; visibility: visible; vertical-align: middle;
                            background-color: White; z-index: 10; filter: alpha(opacity=40);">
                        </div>
                        <div id="div2" runat="server" align="center" valign="middle" style="width: 250px;
                            height: 100px; position: absolute; left: 40%; top: 40%; visibility: visible;
                            vertical-align: middle; border-style: inset; border-color: black; background-color: White;
                            z-index: 20">
                            <br />
                            <table>
                                <tr>
                                    <td style="vertical-align: middle; text-align: center;">
                                        <asp:Image runat="server" ID="img1" ImageUrl="~/Imagenes/Spinner2.gif" />
                                    </td>
                                    <td style="vertical-align: middle; text-align: center;">
                                        <asp:Label runat="server" ID="lblMsjEspera" Text="Por favor espere..." SkinID="SkinLblMsjExito"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="vertical-align: middle; text-align: center;">
                                        <asp:Button runat="server" ID="btnCancelar" OnClientClick="javascript:CancelPostBack(); return false;"
                                            SkinID="SkinBoton" Text="Cancelar" />
                                    </td>
                                </tr>
                            </table>
                            <br />
                        </div>
                    </ProgressTemplate>
                </asp:UpdateProgress>--%>

                        <table style="width: 100%">
                            <tr>
                                <td style="vertical-align: top; width: 290px; text-align: left">
                                    <asp:Label ID="Label2" runat="server" SkinID="SkinLblNormal" Text="Percepciones a gravar"></asp:Label>
                                </td>
                                <td style="vertical-align: top; text-align: left">
                                    <asp:TextBox ID="txtPercAGrav" runat="server" MaxLength="10" 
                                        SkinID="SkinTextBox" ValidationGroup="gpoValoresCalculo"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPercAGrav"
                                        ErrorMessage="*" SetFocusOnError="True" 
                                        ValidationGroup="gpoValoresCalculo"></asp:RequiredFieldValidator><asp:CompareValidator
                                            ID="CompareValidator1" runat="server" ControlToValidate="txtPercAGrav" ErrorMessage="Importe incorrecto"
                                            Operator="DataTypeCheck" Type="Currency" 
                                        ValidationGroup="gpoValoresCalculo"></asp:CompareValidator><ajaxToolkit:FilteredTextBoxExtender
                                                ID="FTBEtxtPercAGrav" runat="server" FilterType="Custom, Numbers" TargetControlID="txtPercAGrav"
                                                ValidChars=".">
                                            </ajaxToolkit:FilteredTextBoxExtender>
                                </td>
                            </tr>
                            <tr>
                                <td style="vertical-align: top; width: 290px; text-align: left">
                                    <asp:Label ID="Label6" runat="server" SkinID="SkinLblNormal" Text="Ultimo sueldo mensual ordinario"></asp:Label>
                                </td>
                                <td style="vertical-align: top; text-align: left">
                                    <asp:TextBox ID="txtbxBaseGravable" runat="server" MaxLength="10" SkinID="SkinTextBox"
                                        Enabled="False" ValidationGroup="gpoValoresCalculo">0</asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtbxBaseGravable"
                                        ErrorMessage="*" SetFocusOnError="True" 
                                        ValidationGroup="gpoValoresCalculo"></asp:RequiredFieldValidator><asp:CompareValidator
                                            ID="CompareValidator2" runat="server" 
                                        ControlToValidate="txtbxBaseGravable" ErrorMessage="Importe incorrecto"
                                            Operator="DataTypeCheck" Type="Currency" 
                                        ValidationGroup="gpoValoresCalculo"></asp:CompareValidator><ajaxToolkit:FilteredTextBoxExtender
                                                ID="FilteredTextBoxExtender1" runat="server" FilterType="Custom, Numbers" TargetControlID="txtbxBaseGravable"
                                                ValidChars=".">
                                            </ajaxToolkit:FilteredTextBoxExtender>
                                </td>
                            </tr>
                            <tr>
                                <td style="vertical-align: top; width: 290px; text-align: left">
                                    <asp:Label ID="Label3" runat="server" SkinID="SkinLblNormal" Text="Usar tablas de impuestos "></asp:Label>
                                </td>
                                <td style="vertical-align: top; text-align: left">
                                    <asp:DropDownList ID="ddlImpMensualQnal" runat="server" SkinID="SkinDropDownList">
                                        <asp:ListItem Value="Q">Quincenal</asp:ListItem>
                                        <asp:ListItem Value="M">Mensual</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td style="vertical-align: top; width: 290px; text-align: left">
                                    <asp:Label ID="Label4" runat="server" SkinID="SkinLblNormal" Text="Número de días al que corresponde la percepción"></asp:Label>
                                </td>
                                <td style="vertical-align: top; text-align: left">
                                    <asp:TextBox ID="txtbxDias" runat="server" MaxLength="3" SkinID="SkinTextBox" Width="50px"
                                        Enabled="False" ValidationGroup="gpoValoresCalculo">0</asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtbxDias"
                                        ErrorMessage="*" SetFocusOnError="True" 
                                        ValidationGroup="gpoValoresCalculo"></asp:RequiredFieldValidator><ajaxToolkit:FilteredTextBoxExtender
                                            ID="FTBEtxtDias" runat="server" FilterType="Numbers" TargetControlID="txtbxDias">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                </td>
                            </tr>
                            <tr>
                                <td style="vertical-align: top; width: 290px; text-align: left">
                                </td>
                                <td style="vertical-align: top; text-align: left">
                                    <asp:Button ID="btnCalcular" runat="server" SkinID="SkinBoton" Text="Calcular" 
                                        OnClick="btnCalcular_Click" ValidationGroup="gpoValoresCalculo" />
                                </td>
                            </tr>
                            <tr>
                                <td style="vertical-align: top; width: 290px; text-align: left">
                                    <asp:Label ID="lblImpuesto_Subsidio" runat="server" SkinID="SkinLblNormal" Text="Impuesto"></asp:Label>
                                </td>
                                <td style="vertical-align: top; text-align: left">
                                    <asp:TextBox ID="txtbxImpuestoCalculado" runat="server" MaxLength="10" SkinID="SkinTextBox"
                                        ReadOnly="True" Font-Bold="True">0</asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 290px">
                                </td>
                                <td>
                                </td>
                            </tr>
                        </table>
                <br />
                </asp:Panel>
            </td>
        </tr>
    </table>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="ddlTipoImpuesto" EventName="SelectedIndexChanged" />
    </Triggers>
</asp:UpdatePanel>
</asp:Content>
