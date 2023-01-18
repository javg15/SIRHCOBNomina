<%@ Page Language="VB" MasterPageFile="~/MasterPageSesionIniciada.master" AutoEventWireup="false"
    CodeFile="wfAdmonDatosPagomatico.aspx.vb" Inherits="wfAdmonDatosPagomatico"
    Title="COBAEV - Nómina - Administrar forma de pago a los empleados"
    StylesheetTheme="SkinFile" %>

<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress" TagPrefix="TP_wucUpdateProgress" %>
<%@ Register src="../../WebControls/wucMuestraErrores.ascx" tagname="wucMuestraErrores" tagprefix="uc2" %>
<%@ Register Src="~/WebControls/wucSearchEmps.ascx" TagName="wucBuscaEmpleados" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
    <asp:UpdatePanel ID="UPMain" runat="server">
        <ContentTemplate>
            <h2>
                Sistema de nómina: Administrar forma de pago a los empleados
            </h2>
            <uc1:wucBuscaEmpleados ID="WucBuscaEmpleados1" runat="server" EnableViewState="true" />
            <asp:MultiView ID="MultiView1" runat="server">
                <asp:View ID="viewEdit" runat="server">
                    <p style="text-align:left;">
                        <asp:CheckBox ID="chbxMostrarOcultarTips" runat="server" AutoPostBack="True" 
                            Text="Mostrar ayuda en los campos a llenar" />
                    </p>
                    <fieldset id="fsCaptura">
                        <legend>
                            <asp:Label ID="lblEmpInf2" runat="server" Font-Strikeout="False" Font-Underline="True"></asp:Label>
                        </legend>
                        <div class="panelIzquierda">
                            <p class="pTextBox">
                                <asp:CheckBox runat="server" ID="chkbxTransBanc" Text="Pagar mediante transferencia bancaria"
                                    TabIndex="1" AutoPostBack="True" />
                                <ajaxToolkit:BalloonPopupExtender ID="chkbxTransBanc_BPE" runat="server" 
                                    BalloonPopupControlID="pnlHelpchkbxTransBanc"
                                    BalloonSize="Medium" CustomCssUrl="" DisplayOnFocus="True" DynamicServicePath=""
                                    Enabled="True" ExtenderControlID="chkbxTransBanc" TargetControlID="chkbxTransBanc">
                                </ajaxToolkit:BalloonPopupExtender>
                            </p>
                            <p class="pLabel">
                                <asp:Label ID="lblBancosTB" runat="server" CssClass="pLabel" Text="Banco para la transferencia bancaria:" />
                            </p>
                            <p class="pTextBox">
                                <asp:DropDownList ID="ddlBancosTB" runat="server" CssClass="textEntry" Enabled="false"
                                    TabIndex="2" AutoPostBack="True">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="ddlBancosTB_RFV" runat="server" ControlToValidate="ddlBancosTB"
                                    Display="Dynamic" ErrorMessage="*" InitialValue="3" ToolTip="Seleccionar el banco para la transferencia bancaria es obligatorio."
                                    ValidationGroup="GrupoGuardar" Enabled="false">
                                </asp:RequiredFieldValidator>
                                <ajaxToolkit:BalloonPopupExtender ID="ddlBancosTB_BPE" runat="server" BalloonPopupControlID="pnlHelpBancosTB"
                                    BalloonSize="Medium" CustomCssUrl="" DisplayOnFocus="True" DynamicServicePath=""
                                    Enabled="True" ExtenderControlID="ddlBancosTB" TargetControlID="ddlBancosTB">
                                </ajaxToolkit:BalloonPopupExtender>
                            </p>
                            <p class="pLabel">
                                <asp:Label ID="lblCtaBancBT" runat="server" CssClass="pLabel" Text="Cuenta para la transferencia bancaria:" />
                            </p>
                            <p class="pTextBox">
                                <asp:TextBox ID="txtbxCtaBancTB" runat="server" CssClass="textEntry" TabIndex="3"
                                    ValidationGroup="GrupoGuardar"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="txtbxCtaBancTB_REV" runat="server" ValidationExpression=""
                                    ControlToValidate="txtbxCtaBancTB" Display="Dynamic" ErrorMessage="*" ToolTip=""
                                    ValidationGroup="GrupoGuardar">
                                </asp:RegularExpressionValidator>
                                <ajaxToolkit:BalloonPopupExtender ID="txtbxCtaBancTB_BPE" runat="server" BalloonPopupControlID="pnlHelpCtaBancTB"
                                    BalloonSize="Medium" CustomCssUrl="" DisplayOnFocus="True" DynamicServicePath=""
                                    Enabled="True" ExtenderControlID="txtbxCtaBancTB" TargetControlID="txtbxCtaBancTB">
                                </ajaxToolkit:BalloonPopupExtender>
                                <ajaxToolkit:FilteredTextBoxExtender ID="txtbxCtaBancTB_FTE" runat="server" FilterType="Numbers"
                                    TargetControlID="txtbxCtaBancTB" ValidChars="">
                                </ajaxToolkit:FilteredTextBoxExtender>
                                <asp:RequiredFieldValidator ID="txtbxCtaBancTB_RFV" runat="server" ControlToValidate="txtbxCtaBancTB"
                                    Display="Dynamic" ErrorMessage="*" ToolTip="La captura de la cuenta para la transferencia bancaria es obligatoria."
                                    ValidationGroup="GrupoGuardar"></asp:RequiredFieldValidator>
                            </p>
                        </div>
                    </fieldset>
                    <div id="divBotones">
                        <p class="submitButton">
                            <asp:Button ID="btnCancelar" runat="server" TabIndex="6" Text="Cancelar" 
                                ToolTip="Cancelar operación actual" />
                            <asp:Button ID="btnCrearBenef" runat="server" Text="Guardar" ValidationGroup="GrupoGuardar"
                                
                                ToolTip="Guardar información del nuevo beneficiario de pensión alimenticia" 
                                TabIndex="4" Visible="False" />
                            <asp:Button ID="btnModifBenef" runat="server" TabIndex="5" Text="Guardar" ToolTip="Guardar datos ingresados"
                                ValidationGroup="GrupoGuardar" />
                            <ajaxToolkit:ConfirmButtonExtender ID="btnModifBenef_ConfirmButtonExtender" runat="server"
                                ConfirmText="¿Está seguro de que los datos ingresados son correctos?" Enabled="True"
                                TargetControlID="btnModifBenef">
                            </ajaxToolkit:ConfirmButtonExtender>
                            <ajaxToolkit:ConfirmButtonExtender ID="btnCrearBenef_CBE" runat="server" ConfirmText="¿Está seguro de que los datos ingresados son correctos?"
                                Enabled="True" TargetControlID="btnCrearBenef">
                            </ajaxToolkit:ConfirmButtonExtender>
                        </p>
                    </div>
                    <div>
                         <asp:Panel ID="pnlHelpchkbxTransBanc" runat="server" HorizontalAlign="Justify">
                            Sí lo que desea es pagar mediante cheque al empleado, favor de dejar sin marcar la casilla.<br />
                        </asp:Panel>
                         <asp:Panel ID="pnlHelpBancosTB" runat="server" HorizontalAlign="Justify">
                            Dato obligatorio solo si realizará transferencia bancaria al empleado.<br />
                        </asp:Panel>
                         <asp:Panel ID="pnlHelpCtaBancTB" runat="server" HorizontalAlign="Justify">
                            <p>
                                Dato obligatorio solo si realizará transferencia bancaria al empleado.
                            </p>
                            <p>
                                La longitud de la cuenta bancaria debe ser de <asp:Label ID="lblLongCtaBacTB" runat="server" Text=""></asp:Label> dígitos.
                            </p>
                        </asp:Panel>  
                    </div>
                </asp:View>
                <asp:View ID="viewExito" runat="server">
                    <p>
                        <asp:Image ID="Image2" runat="server" ImageUrl="~/Imagenes/Symbol-Check.png" Width="100px" />
                    </p>
                    <p>
                        <asp:Label ID="lblCapturaExitosa" runat="server" SkinID="SkinLblMsjExito"></asp:Label>
                    </p>
                    <p>
                        <asp:LinkButton ID="lbOtraOperacion" runat="server" SkinID="SkinLinkButton">Cambiar más datos</asp:LinkButton>
                        &nbsp;<asp:LinkButton ID="lbOtraOperacion0" runat="server" 
                            PostBackUrl="~/Consultas/Empleados/DatosCOBAEV.aspx" SkinID="SkinLinkButton">Continuar con otra operación en el sistema</asp:LinkButton>
                    </p>
                </asp:View>
                <asp:View ID="viewError" runat="server">
                    <uc2:wucMuestraErrores ID="wucMuestraErrores" runat="server"  />
                    <div id="divBotonesErrores">
                        <p class="submitButton">
                            <asp:Button ID="btnContinuar" runat="server" Text="Regresar a pantalla de captura" ToolTip=""
                                TabIndex="24" />
                        </p>
                    </div>
                </asp:View>
            </asp:MultiView>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
