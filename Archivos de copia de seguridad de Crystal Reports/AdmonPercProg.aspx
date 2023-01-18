<%@ Page Language="VB" EnableEventValidation="false" MasterPageFile="~/MasterPageBlanca.master"
    AutoEventWireup="false" CodeFile="AdmonPercProg.aspx.vb" Inherits="Administracion_Percepciones_AdmonPercProg"
    Title="COBAEV - N�mina - Administraci�n de percepciones programadas" StylesheetTheme="SkinFile" %>
<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress" TagPrefix="TP_wucUpdateProgress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
    <table style="width: 100%; vertical-align: top; text-align: center;" align="left">
        <tr>
            <td style="vertical-align: top; text-align: right">
                <h2>
                    Sistema de n�mina: Par�metros a utilizar para c�lculo de percepci�n programada</h2>
                <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                    <ContentTemplate>
                        <asp:MultiView ID="MultiView1" runat="server">
                            <asp:View ID="viewCaptura" runat="server">
                                <table style="width: 70%;">
                                    <tr>
                                        <td style="vertical-align: top; width: 100%; height: 100%; text-align: left">
                                            <table align="left" style="width: 100%">
                                                <tr>
                                                    <td style="vertical-align: top; text-align: left; width: 1062px;">
                                                        <asp:DetailsView ID="dvPercepcion" runat="server" AutoGenerateRows="False" 
                                                            DefaultMode="Edit" SkinID="SkinDetailsView" Width="100%">
                                                            <Fields>
                                                                <asp:TemplateField ShowHeader="False">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblHeader" runat="server" SkinID="SkinLblHeader" 
                                                                            Text="Actualizar par�metros de percepci�n programada"></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <InsertItemTemplate>
                                                                        <asp:Label ID="lblValoresActuales" runat="server" SkinID="SkinLblHeader" 
                                                                            Text="Valores actuales"></asp:Label>
                                                                    </InsertItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblValoresActuales0" runat="server" SkinID="SkinLblHeader" 
                                                                            Text="Valores actuales"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="ClavePercepcion" HeaderText="Clave percepci�n" 
                                                                    ReadOnly="True" />
                                                                <asp:BoundField DataField="NombrePercepcion" HeaderText="Percepci�n" 
                                                                    ReadOnly="True" />
                                                                <asp:BoundField DataField="NumParte" HeaderText="Parte" ReadOnly="True" />
                                                                <asp:TemplateField HeaderText="Pagar en n�mina extarordinaria">
                                                                    <EditItemTemplate>
                                                                        <asp:CheckBox ID="chbxFormaPago" runat="server" AutoPostBack="True" 
                                                                            Checked='<%# Bind("PagarIndividualmente") %>' 
                                                                            OnCheckedChanged="chbxFormaPago_CheckedChanged" />
                                                                    </EditItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Quincena de pago">
                                                                    <EditItemTemplate>
                                                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:DropDownList ID="ddlQnasPago" runat="server" AutoPostBack="True" 
                                                                                    OnSelectedIndexChanged="ddlQnasPago_SelectedIndexChanged" 
                                                                                    SkinID="SkinDropDownList">
                                                                                </asp:DropDownList>
                                                                                <asp:RequiredFieldValidator ID="rfvddlQnasPago" runat="server" 
                                                                                    ControlToValidate="ddlQnasPago" Display="None" 
                                                                                    ErrorMessage="Quincena no v�lida." InitialValue="-1"></asp:RequiredFieldValidator>
                                                                            </ContentTemplate>
                                                                            <Triggers>
                                                                                <asp:AsyncPostBackTrigger ControlID="chbxFormaPago" 
                                                                                    EventName="CheckedChanged" />
                                                                            </Triggers>
                                                                        </asp:UpdatePanel>
                                                                    </EditItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Quincena para segunda parte">
                                                                    <EditItemTemplate>
                                                                        <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:DropDownList ID="ddlQnasPago2aParte" runat="server" 
                                                                                    SkinID="SkinDropDownList">
                                                                                </asp:DropDownList>
                                                                                <asp:RequiredFieldValidator ID="rfvddlQnasPago2aParte" runat="server" 
                                                                                    ControlToValidate="ddlQnasPago2aParte" Display="None" 
                                                                                    ErrorMessage="Quincena no v�lida." InitialValue="-1"></asp:RequiredFieldValidator>
                                                                            </ContentTemplate>
                                                                        </asp:UpdatePanel>
                                                                    </EditItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Quincena de retroactividad">
                                                                    <EditItemTemplate>
                                                                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:DropDownList ID="ddlQnasRetro" runat="server" Enabled="False" 
                                                                                    SkinID="SkinDropDownList">
                                                                                    <asp:ListItem Value="-1">No disponible</asp:ListItem>
                                                                                </asp:DropDownList>
                                                                            </ContentTemplate>
                                                                            <Triggers>
                                                                                <asp:AsyncPostBackTrigger ControlID="ddlQnasPago" 
                                                                                    EventName="SelectedIndexChanged" />
                                                                            </Triggers>
                                                                        </asp:UpdatePanel>
                                                                    </EditItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="M�todo para calcular el impuesto">
                                                                    <EditItemTemplate>
                                                                        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:DropDownList ID="ddlTipoImpuesto" runat="server" AutoPostBack="True" 
                                                                                    OnSelectedIndexChanged="ddlTipoImpuesto_SelectedIndexChanged" 
                                                                                    SkinID="SkinDropDownList">
                                                                                </asp:DropDownList>
                                                                            </ContentTemplate>
                                                                            <Triggers>
                                                                                <asp:AsyncPostBackTrigger ControlID="chbxFormaPago" 
                                                                                    EventName="CheckedChanged" />
                                                                            </Triggers>
                                                                        </asp:UpdatePanel>
                                                                    </EditItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="D�as a considerar para el c�lculo">
                                                                    <EditItemTemplate>
                                                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:TextBox ID="txtbxDias" runat="server" Enabled="False" MaxLength="3" 
                                                                                    SkinID="SkinTextBox" Width="50px"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="RFVDias" runat="server" 
                                                                                    ControlToValidate="txtbxDias" Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                                                <asp:RangeValidator ID="RVDias" runat="server" ControlToValidate="txtbxDias" 
                                                                                    Display="Dynamic" ErrorMessage="Escriba un valor entre 1 y 365" 
                                                                                    MaximumValue="365" MinimumValue="1" Type="Integer"></asp:RangeValidator>
                                                                                <ajaxToolkit:FilteredTextBoxExtender ID="FTBEDias" runat="server" 
                                                                                    FilterType="Numbers" TargetControlID="txtbxDias">
                                                                                </ajaxToolkit:FilteredTextBoxExtender>
                                                                                <asp:HiddenField ID="hfDias" runat="server" />
                                                                            </ContentTemplate>
                                                                            <Triggers>
                                                                                <asp:AsyncPostBackTrigger ControlID="ddlTipoImpuesto" 
                                                                                    EventName="SelectedIndexChanged" />
                                                                            </Triggers>
                                                                        </asp:UpdatePanel>
                                                                    </EditItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Considerar mes actual para c�lculo del impuesto">
                                                                    <EditItemTemplate>
                                                                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:CheckBox ID="chbxMesActualParaImpuesto" runat="server" 
                                                                                    Checked='<%# Bind("MesActualParaImpuesto") %>' />
                                                                            </ContentTemplate>
                                                                            <Triggers>
                                                                                <asp:AsyncPostBackTrigger ControlID="chbxFormaPago" 
                                                                                    EventName="CheckedChanged" />
                                                                            </Triggers>
                                                                        </asp:UpdatePanel>
                                                                    </EditItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField ShowHeader="False">
                                                                    <EditItemTemplate>
                                                                        <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:Button ID="btnDesasociar" runat="server" Enabled="False" 
                                                                                    OnClick="btnDesasociar_Click" SkinID="SkinBoton" Text="Desasociar" 
                                                                                    ToolTip="Desasociar percepci�n programada de la quincena indicada" />
                                                                                <asp:Button ID="btnGuardar" runat="server" OnClick="btnGuardar_Click" 
                                                                                    SkinID="SkinBoton" Text="Guardar" />
                                                                                <ajaxToolkit:ConfirmButtonExtender ID="CBEGuardar" runat="server" 
                                                                                    ConfirmText="�Informaci�n correcta?" TargetControlID="btnGuardar">
                                                                                </ajaxToolkit:ConfirmButtonExtender>
                                                                            </ContentTemplate>
                                                                            <Triggers>
                                                                                <asp:AsyncPostBackTrigger ControlID="chbxFormaPago" 
                                                                                    EventName="CheckedChanged" />
                                                                            </Triggers>
                                                                        </asp:UpdatePanel>
                                                                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                                                                            ShowMessageBox="True" ShowSummary="False" />
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
                                <table style="width: 100%" align="left">
                                    <tr>
                                        <td style="vertical-align: middle; text-align: left; width: 0%;">
                                            <asp:Image ID="Image2" runat="server" ImageUrl="~/Imagenes/Symbol-Check.png" 
                                                Width="100px" />
                                        </td>
                                        <td style="vertical-align: middle; text-align: left">
                                            <asp:Label ID="lblCapturaExitosa" runat="server" SkinID="SkinLblMsjExito" 
                                                Text="Actualizaci�n realizada exitosamente"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </asp:View>
                            <asp:View ID="viewErrores" runat="server">
                                <table style="width: 100%" align="left">
                                    <tr>
                                        <td style="vertical-align: middle; text-align: left; width: 0%;">
                                            <asp:Image ID="Image3" runat="server" ImageUrl="~/Imagenes/Symbol-Stop.png" 
                                                Width="100px" />
                                        </td>
                                        <td style="vertical-align: middle; text-align: left;">
                                            <asp:Label ID="lblErrores" runat="server" SkinID="SkinLblMsjErrores"></asp:Label>
                                            <br />
                        <br />
                                            <asp:LinkButton ID="lbReintentar" runat="server" SkinID="SkinLinkButton">Reintentar parametrizaci�n</asp:LinkButton>
                                        </td>
                                    </tr>
                                </table>
                            </asp:View>
                        </asp:MultiView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
    </asp:Content>
