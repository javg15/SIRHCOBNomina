<%@ page language="VB" masterpagefile="~/MasterPageSesionIniciada.master" autoeventwireup="false" inherits="wfCapturaNuevoMovDePersonal, App_Web_pfakqicg" title="COBAEV - Nómina - Captura de nuevos movimientos de personal" stylesheettheme="SkinFile" maintainScrollPositionOnPostBack="true" %>

<%@ Register Src="~/WebControls/wucSearchEmps.ascx" TagName="wucBuscaEmpleados" TagPrefix="uc1" %>
<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress"
    TagPrefix="TP_wucUpdateProgress" %>
<%@ Register Src="../../WebControls/wucPlazas.ascx" TagName="wucPlazas" TagPrefix="uc2" %>
<%@ Register Src="../../WebControls/wucPlazas2.ascx" TagName="wucPlazas2" TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UPMain" runat="server">
        <ContentTemplate>
            <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
            <h2>
                Sistema de nómina: Captura de nuevos movimientos de personal
            </h2>
            <asp:Panel ID="pnlBuscaEmps" runat="server">
                <uc1:wucBuscaEmpleados ID="WucBuscaEmpleados1" runat="server" EnableViewState="true" />
            </asp:Panel>
            <asp:Panel ID="pnlInfMovPers" runat="server" HorizontalAlign="Left">
                <asp:Panel ID="pnl1" runat="server" CssClass="accountInfo" GroupingText="">
                    <!--<div class="accountInfo">-->
                    <fieldset id="fsCaptura">
                        <!--
                                <legend>
                                    <asp:Label ID="lblInfEmp" runat="server" Font-Strikeout="False" Font-Underline="True"></asp:Label>
                                </legend>
                                -->
                        <div class="panelIzquierda">
                            <p class="pLabel">
                                <asp:Label ID="lblCadena" runat="server" Text="Cadena a la que se asociará el movimiento de personal:"
                                    CssClass="pLabel" />
                            </p>
                            <p class="pTextBox">
                                <asp:DropDownList ID="ddlCadenas" runat="server" CssClass="textEntry" ValidationGroup="GrupoGuardar"
                                    AutoPostBack="True">
                                </asp:DropDownList>
                                <asp:CompareValidator ID="CV_ddlCadenas" runat="server" ControlToValidate="ddlCadenas"
                                    Display="Dynamic" ErrorMessage="*" Operator="NotEqual" ToolTip="Parece ser que no hay cadenas abiertas para asociar el movimiento de personal."
                                    ValidationGroup="GrupoGuardar" ValueToCompare="-1"></asp:CompareValidator>
                            </p>
                            <p class="pLabel">
                                <asp:Label ID="lblOrigenProp" runat="server" Text="Origen de la propuesta:" CssClass="pLabel" />
                            </p>
                            <p class="pTextBox">
                                <asp:DropDownList ID="ddlOrigenPropuestas" runat="server" CssClass="textEntry" Enabled="false">
                                </asp:DropDownList>
                            </p>
                            <p class="pLabel">
                                <asp:Label ID="lblComentarios" runat="server" Text="Comentarios:" CssClass="pLabel" />
                            </p>
                            <p class="pTextBoxML">
                                <asp:TextBox ID="txtbxComentarios" runat="server" CssClass="textEntry" Enabled="false"
                                    TextMode="MultiLine"></asp:TextBox>
                            </p>
                            <p class="pLabel">
                                <asp:Label ID="lblTramite" runat="server" Text="Seleccione el tipo de trámite:" CssClass="pLabel" />
                            </p>
                            <p class="pTextBox">
                                <asp:DropDownList ID="ddlTramites" runat="server" CssClass="textEntry" AutoPostBack="True">
                                </asp:DropDownList>
                            </p>
                        </div>
                        <div class="pnlDerecha">
                            <p class="pLabel">
                            </p>
                            <p class="pTextBox">
                            </p>
                            <p class="pLabel">
                                <asp:Label ID="lblOficioProp" runat="server" Text="Oficio de la propuesta:" CssClass="pLabel" />
                            </p>
                            <p class="pTextBox">
                                <asp:TextBox ID="txtbxOficioProp" runat="server" MaxLength="50" CssClass="textEntry"
                                    Enabled="false"></asp:TextBox>
                            </p>
                            <p class="pLabel">
                            </p>
                            <p class="pTextBoxML">
                            </p>
                            <p class="pLabel">
                                <asp:Label ID="lblMotivos" runat="server" Text="Seleccione el motivo que da origen al trámite:"
                                    CssClass="pLabel" />
                            </p>
                            <p class="pTextBox">
                                <asp:DropDownList ID="ddlMotivos" runat="server" CssClass="textEntry">
                                </asp:DropDownList>
                            </p>
                        </div>
                    </fieldset>
                    <!--</div>-->
                </asp:Panel>
                <asp:Panel ID="pnl1Botones" runat="server" GroupingText="" BorderStyle="None">
                    <div id="divBotones">
                        <p class="submitButton">
                            <asp:Button ID="btnContinuar" runat="server" Text="Continuar" ValidationGroup="GrupoGuardar"
                                ToolTip="Continuar con la captura de más información del movimiento de personal"
                                CommandArgument="Continuar" />
                        </p>
                    </div>
                </asp:Panel>
                <asp:MultiView ID="mviewMain" runat="server" ActiveViewIndex="0">
                    <asp:View ID="viewInfMovPers" runat="server">
                    </asp:View>
                    <asp:View ID="viewAlta" runat="server">
                        <asp:Panel ID="pnlviewAlta" runat="server" CssClass="accountInfo" GroupingText="Tipo de movimiento de personal: ALTA">
                            <uc2:wucPlazas ID="wucPlazas1" runat="server" />

                        </asp:Panel>
                        <asp:Panel ID="pnlviewAltaBotones" runat="server" GroupingText="" BorderStyle="None">
                            <div id="divBotonesAlta">
                                <p class="submitButton">
                                    <asp:Button ID="btnRegresarAviewInfMovPers" runat="server" Text="Regresar" ValidationGroup="GrupoGuardar"
                                        ToolTip="Regresar a la pantalla anterior en el proceso de captura de información del movimiento de personal"
                                        CausesValidation="False" />
                                    <asp:Button ID="btnContinuar2" runat="server" Text="Continuar" ToolTip="Continuar con la captura de más información del movimiento de personal"
                                        ValidationGroup="GrupoGuardar" />
                                </p>
                            </div>
                        </asp:Panel>
                    </asp:View>
                    <asp:View ID="viewAlta2" runat="server">
                        <h2>
                            Tipo de movimiento de personal: ALTA
                        </h2>
                                                    <uc3:wucPlazas2 ID="wucPlazas2" runat="server" />
                        <div id="divBotonesAlta2">
                            <p class="submitButton">
                                <asp:Button ID="btnRegresarAviewAlta" runat="server" Text="Regresar" ValidationGroup="GrupoGuardar"
                                    ToolTip="Regresar a la pantalla anterior en el proceso de captura de información del movimiento de personal"
                                    CausesValidation="False" />
                                <asp:Button ID="btnContinuar3" runat="server" Text="Continuar" ToolTip="Continuar con la captura de más información del movimiento de personal"
                                    ValidationGroup="GrupoGuardar" />
                            </p>
                        </div>
                    </asp:View>
                </asp:MultiView>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
