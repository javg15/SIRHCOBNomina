<%@ page language="VB" masterpagefile="~/MasterPageSesionIniciada.master" autoeventwireup="false" inherits="AdmonPercCapturadas, App_Web_sogedhgo" title="COBAEV - Nómina - ABC Percepciones por empleado" stylesheettheme="SkinFile" maintainScrollPositionOnPostBack="true" %>

<%@ Register Src="../../WebControls/wucEfectos2.ascx" TagName="wucEfectos2" TagPrefix="uc1" %>
<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress"
    TagPrefix="TP_wucUpdateProgress" %>
<%@ Register Src="~/WebControls/wucSearchEmps.ascx" TagName="wucBuscaEmpleados" TagPrefix="uc1" %>
<%@ Register src="../../WebControls/wucMuestraErrores.ascx" tagname="wucmuestraerrores" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
    <table style="width: 100%;">
        <tr>
            <td style="vertical-align: top; text-align: right">
                <h2>
                    Sistema de nómina: ABC Percepciones por empleado
                </h2>
            </td>
        </tr>
    </table>
    <asp:UpdatePanel ID="UPMain" runat="server">
        <ContentTemplate>
            <uc1:wucBuscaEmpleados ID="WucBuscaEmpleados1" runat="server" EnableViewState="true" />
            <asp:MultiView ID="MultiView1" runat="server">
                <asp:View ID="viewPercepciones" runat="server">
                    <div class="accountInfo">
                        <fieldset id="fsCaptura">
                            <legend>
                                <asp:Label ID="lblEmpInf2" Text="Información específica de la percepción" runat="server"
                                    Font-Strikeout="False" Font-Underline="True"></asp:Label>
                            </legend>
                            <div class="panelIzquierda">
                                <p class="pLabel">
                                    <asp:Label ID="lblPercepcion" runat="server" CssClass="pLabel"></asp:Label>
                                </p>
                                <p class="pTextBox">
                                    <asp:Label ID="lblPercepcion2" runat="server" CssClass="pLabel"></asp:Label>
                                </p>
                                <p class="pLabel">
                                    <asp:Label ID="lblImportePercepcion" runat="server" Text="Importe $" CssClass="pLabel"></asp:Label>
                                </p>
                                <p class="pTextBox">
                                    <asp:TextBox ID="txtbxImportePercepcion" runat="server" CssClass="textEntry"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RFVImportePercepcion" runat="server" Display="Dynamic"
                                        ErrorMessage="*" ControlToValidate="txtbxImportePercepcion"></asp:RequiredFieldValidator>
                                    <asp:CompareValidator ID="CVImportePercepcion" runat="server" Display="Dynamic" ErrorMessage="Importe incorrecto"
                                        ControlToValidate="txtbxImportePercepcion" Type="Currency" Operator="DataTypeCheck"></asp:CompareValidator>
                                </p>
                                <p class="pLabel">
                                    <asp:Label ID="lblDiasAPagar" runat="server" Text="Días a pagar" CssClass="pLabel"></asp:Label>
                                </p>
                                <p class="pTextBox">
                                    <asp:TextBox ID="tbDiasAPagar" runat="server" MaxLength="2" CssClass="textEntry"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvNumDias" runat="server" ControlToValidate="tbDiasAPagar"
                                        Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                        FilterType="Numbers" TargetControlID="tbDiasAPagar"></ajaxToolkit:FilteredTextBoxExtender>
                                </p>
                                <p class="pLabel">
                                    <asp:Label ID="Label3" runat="server" Text="Duración del descuento:" CssClass="pLabel"></asp:Label>
                                </p>
                                <p>
                                    <uc1:wucEfectos2 ID="WucEfectos2" runat="server" Visible="true"></uc1:wucEfectos2>
                                </p>
                            </div>
                        </fieldset>
                    </div>
                    <asp:Panel ID="pnldivBotones" runat="server" Visible="true">
                        <div id="divBotones">
                            <p class="submitButton">
                                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CausesValidation="False" />
                                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" />
                                <ajaxToolkit:ConfirmButtonExtender ID="CBEBtnGuardar" runat="server" ConfirmText="¿Información correcta?"
                                    TargetControlID="btnGuardar"></ajaxToolkit:ConfirmButtonExtender>
                            </p>
                        </div>
                    </asp:Panel>
                    <asp:Label ID="Label1" runat="server" Text="Seleccione percepción" Visible="false"></asp:Label>
                    <asp:DropDownList ID="ddlPercepciones" runat="server" AutoPostBack="True" Visible="false">
                    </asp:DropDownList>
                    <asp:Label ID="Label2" runat="server" Text="Seleccione plaza" Visible="false"></asp:Label>
                    <asp:DropDownList ID="ddlPlazas" runat="server" AutoPostBack="True" Visible="false"
                        OnSelectedIndexChanged="ddlPlazas_SelectedIndexChanged">
                    </asp:DropDownList>
                </asp:View>
                <asp:View ID="viewExito" runat="server">
                    <table>
                        <tr>
                            <td style="vertical-align: middle; text-align: left">
                                <asp:Image ID="Image2" runat="server" ImageUrl="~/Imagenes/Symbol-Check.png" Width="100px" />
                            </td>
                            <td style="vertical-align: middle; text-align: left">
                                <asp:Label ID="lblExito" runat="server" SkinID="SkinLblMsjExito">Operación realizada exitosamente.</asp:Label>
                                <br />
                                <asp:LinkButton ID="lbOtraOperacion" runat="server" SkinID="SkinLinkButton">Cambiar más datos</asp:LinkButton>
                                &nbsp;<asp:LinkButton ID="lbOtraOperacion0" runat="server" 
                                    PostBackUrl="~/ABC/Nomina/CapturaPercDeduc.aspx" SkinID="SkinLinkButton">Continuar con otra operación en el sistema</asp:LinkButton>
                            </td>
                        </tr>
                    </table>
                </asp:View>
                <asp:View ID="viewError" runat="server">
                    <uc2:wucMuestraErrores ID="wucMuestraErrores" runat="server" />
                    <div id="divBotonesErrores">
                        <p class="submitButton">
                            <asp:LinkButton ID="lbOtraOperacion2" runat="server" SkinID="SkinLinkButton">Reintentar captura</asp:LinkButton>
                            &nbsp;<asp:LinkButton ID="lbOtraOperacion1" runat="server" 
                                PostBackUrl="~/ABC/Nomina/CapturaPercDeduc.aspx" SkinID="SkinLinkButton">Continuar con otra operación en el sistema</asp:LinkButton>
                        </p>
                    </div>
                </asp:View>
                <asp:View ID="viewErrorNoCont" runat="server">
                    <table>
                        <tr>
                            <td style="vertical-align: middle; text-align: left">
                                <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/Symbol-Stop.png" Width="100px" />
                            </td>
                            <td style="vertical-align: middle; text-align: left">
                                <asp:Label ID="lblError" runat="server" SkinID="SkinLblMsjErrores"></asp:Label>
                                <br />
                                <asp:LinkButton ID="lbReintentarCaptura" runat="server" SkinID="SkinLinkButton">Reintentar captura</asp:LinkButton>
                                &nbsp;<asp:LinkButton ID="lbOtraOperacion3" runat="server" 
                                    PostBackUrl="~/ABC/Nomina/CapturaPercDeduc.aspx" SkinID="SkinLinkButton">Continuar con otra operación en el sistema</asp:LinkButton>
                            </td>
                        </tr>
                    </table>
                </asp:View>
            </asp:MultiView>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
