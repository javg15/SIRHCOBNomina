<%@ Page Language="VB" enableEventValidation="false" MasterPageFile="~/MasterPageBlanca.master" AutoEventWireup="false" 
CodeFile="AdmonPercRetro.aspx.vb" Inherits="Administracion_Percepciones_AdmonPercRetro" 
title="COBAEV - Nómina - Administración de percepciones retroactivas" StylesheetTheme="SkinFile" %>
<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress" TagPrefix="TP_wucUpdateProgress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
    <table style="width: 100%; vertical-align: top; text-align: center;" align="center">
        <tr>
            <td style="vertical-align: top; text-align: right">
                <h2>
                    Sistema de nómina: Parámetros a utilizar para cálculo de retroactividad
                </h2>
            </td>
        </tr>
    </table>
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="viewCaptura" runat="server">
            <table style="width: 100%;">
                <tr>
                    <td style="vertical-align: top; width: 70%; height: 100%; text-align: left">
                        <table style="width: 100%">
                            <tr>
                                <td style="vertical-align: top; text-align: left; width: 1062px;">
                                    <asp:DetailsView ID="dvPercepcion" runat="server" AutoGenerateRows="False" DefaultMode="Edit" SkinID="SkinDetailsView" Width="100%">
                                        <Fields>
                                            <asp:TemplateField ShowHeader="False">
                                                <EditItemTemplate>
                                                    <asp:Label ID="lblHeader" runat="server" SkinID="SkinLblHeader" Text="Actualizar parámetros de percepción retroactiva"></asp:Label>
                                                </EditItemTemplate>
                                                <InsertItemTemplate>
                                                    <asp:Label ID="lblValoresActuales" runat="server" SkinID="SkinLblHeader" Text="Valores actuales"></asp:Label>
                                                </InsertItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblValoresActuales" runat="server" SkinID="SkinLblHeader" Text="Valores actuales"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="ClavePercepcion" HeaderText="Clave percepci&#243;n" ReadOnly="True" />
                                            <asp:BoundField DataField="NombrePercepcion" HeaderText="Percepci&#243;n" ReadOnly="True" />
                                            <asp:BoundField DataField="ClaveZonaEco" HeaderText="Zona Económica" 
                                                ReadOnly="True" />
                                            <asp:TemplateField HeaderText="Porcentaje de incremento">
                                                <EditItemTemplate>
                                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                        <ContentTemplate>
                                                            <asp:TextBox ID="txtbxPorcInc" runat="server" MaxLength="6" SkinID="SkinTextBox"
                                                                Width="50px" Text='<%# Bind("PorcInc") %>'></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RFVPorcInc" runat="server" ControlToValidate="txtbxPorcInc"
                                                                Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator><asp:RangeValidator
                                                                    ID="RVPorcInc" runat="server" ControlToValidate="txtbxPorcInc" Display="Dynamic" ErrorMessage="Escriba un valor entre 1 y 100"
                                                                    MaximumValue="100.00" MinimumValue="00.00" Type="Double"></asp:RangeValidator>
                                                            <asp:CompareValidator ID="CVPorcInc" runat="server" ControlToValidate="txtbxPorcInc"
                                                                Display="Dynamic" ErrorMessage="Valor incorrecto" Operator="DataTypeCheck" Type="Double"></asp:CompareValidator>
                                                            <ajaxToolkit:FilteredTextBoxExtender
                                                                        ID="FTBEPorcInc" runat="server" TargetControlID="txtbxPorcInc" ValidChars="0123456789.">
                                                                    </ajaxToolkit:FilteredTextBoxExtender>
                                                            <asp:HiddenField ID="hfPorcInc" runat="server" />
                                                        </ContentTemplate>
                                                        <Triggers>
                                                            <asp:AsyncPostBackTrigger ControlID="chbxRetroPorDif" 
                                                                EventName="CheckedChanged" />
                                                        </Triggers>
                                                    </asp:UpdatePanel>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Incluir en pago">
                                                <EditItemTemplate>
                                                    <asp:CheckBox ID="chbxIncluirEnPago" runat="server" Checked='<%# Bind("IncluirEnPago") %>' />
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Pagar por diferencia">
                                                <EditItemTemplate>
                                                    <asp:CheckBox ID="chbxRetroPorDif" runat="server" 
                                                        Checked='<%# Bind("RetroPorDiferencia") %>' AutoPostBack="True" 
                                                        oncheckedchanged="chbxRetroPorDif_CheckedChanged" />
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Importe diferencia">
                                                <EditItemTemplate>
                                                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                        <ContentTemplate>
                                                            <asp:TextBox ID="txtbxImpDif" runat="server" MaxLength="7" SkinID="SkinTextBox"
                                                                Width="50px" Text='<%# Bind("ImporteDiferencia") %>'></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RFVImpDif" runat="server" ControlToValidate="txtbxImpDif"
                                                                Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator><asp:RangeValidator
                                                                    ID="RVImpDif" runat="server" ControlToValidate="txtbxImpDif" Display="Dynamic" ErrorMessage="Escriba un valor monetario"
                                                                    MaximumValue="9999.99" MinimumValue="0.00" Type="Double"></asp:RangeValidator>
                                                            <asp:CompareValidator ID="CVImpDif" runat="server" ControlToValidate="txtbxImpDif"
                                                                Display="Dynamic" ErrorMessage="Valor incorrecto" Operator="DataTypeCheck" Type="Double"></asp:CompareValidator>
                                                            <ajaxToolkit:FilteredTextBoxExtender
                                                                        ID="FTBEImpDif" runat="server" TargetControlID="txtbxImpDif" ValidChars="0123456789.">
                                                                    </ajaxToolkit:FilteredTextBoxExtender>
                                                            <asp:HiddenField ID="hfImpDif" runat="server" />
                                                        </ContentTemplate>
                                                        <Triggers>
                                                            <asp:AsyncPostBackTrigger ControlID="chbxRetroPorDif" 
                                                                EventName="CheckedChanged" />
                                                        </Triggers>
                                                    </asp:UpdatePanel>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ShowHeader="False">
                                                <EditItemTemplate>
                                                    <asp:Button ID="btnGuardar" runat="server" OnClick="btnGuardar_Click" SkinID="SkinBoton"
                                                        Text="Guardar" /><ajaxToolkit:ConfirmButtonExtender ID="CBEGuardar" runat="server" ConfirmText="¿Información correcta?"
                                                        TargetControlID="btnGuardar">
                                                    </ajaxToolkit:ConfirmButtonExtender>
                                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                                                        ShowSummary="False" />
                                                </EditItemTemplate>
                                                <ItemStyle HorizontalAlign="Right" />
                                            </asp:TemplateField>
                                        </Fields>
                                    </asp:DetailsView>
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="viewCapturaExitosa" runat="server">
            <table style="width: 100%">
                <tr>
                    <td style="vertical-align: middle; text-align: left; width: 0%;">
                        <asp:Image ID="Image2" runat="server" ImageUrl="~/Imagenes/Symbol-Check.png" Width="100px" /></td>
                    <td style="vertical-align: middle; text-align: left">
                        <asp:Label ID="lblCapturaExitosa" runat="server" SkinID="SkinLblMsjExito" Text="Actualización realizada exitosamente"></asp:Label></td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="viewErrores" runat="server">
            <table style="width: 100%">
                <tr>
                    <td style="vertical-align: middle; text-align: left; width: 0%;">
                        <asp:Image ID="Image3" runat="server" ImageUrl="~/Imagenes/Symbol-Stop.png" Width="100px" /></td>
                    <td style="vertical-align: middle; text-align: left;">
                        <asp:Label ID="lblErrores" runat="server" SkinID="SkinLblMsjErrores"></asp:Label><br />
                        <br />
                        <asp:LinkButton ID="lbReintentar" runat="server" SkinID="SkinLinkButton">Reintentar parametrización</asp:LinkButton></td>
                </tr>
            </table>
        </asp:View>
    </asp:MultiView>
</asp:Content>

