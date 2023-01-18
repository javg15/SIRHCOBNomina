<%@ Page Language="VB" MasterPageFile="~/MasterPageSesionIniciada.master"  AutoEventWireup="false" CodeFile="QuincenasDetalles.aspx.vb" 
Inherits="Administracion_Quincenas_Detalles" title="COBAEV - Nómina - Quincenas (Detalles)" StylesheetTheme="SkinFile" 
Culture="Auto" UICulture="Auto" %>
<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress" TagPrefix="TP_wucUpdateProgress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
    <table style="width: 100%;" align="center">
        <tr>
            <td style="vertical-align: top; text-align: right">
                <h2>
                    <asp:Label ID="lblHeadPage" runat="server" Text="Quincenas: Vista detalle"></asp:Label>
                </h2>
            </td>
        </tr>
    </table>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="viewCaptura" runat="server">
            <table style="width: 70%; height: 300px">
                <tr>
                    <td style="vertical-align: top; width: 70%; height: 100%; text-align: left">
                        <table style="width: 100%">
                            <tr>
                                <td style="vertical-align: top; text-align: left">
                                    <ajaxToolkit:CollapsiblePanelExtender ID="CPEQuincenas" runat="Server" CollapseControlID="TitlePanelUsuarios"
                                        Collapsed="False" CollapsedImage="~/Imagenes/expand_blue.jpg" CollapsedText="(Mostrar panel...)"
                                        ExpandControlID="TitlePanelUsuarios" ExpandedImage="~/Imagenes/collapse_blue.jpg"
                                        ExpandedText="(Ocultar panel...)" ImageControlID="Image1" SuppressPostBack="true"
                                        TargetControlID="ContentPanelUsuarios" TextLabelID="Label1">
                                    </ajaxToolkit:CollapsiblePanelExtender>
                                    <table cellpadding="0" cellspacing="0" style="width: 100%">
                                        <tr>
                                            <td colspan="2" style="vertical-align: top; text-align: left;">
                                                <asp:Panel ID="TitlePanelUsuarios" runat="server" BorderColor="White" BorderStyle="Solid"
                                                    BorderWidth="1px" CssClass="collapsePanelHeader" Width="100%">
                                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/expand_blue.jpg" />
                                                    Captura/Modificación
                                                    <asp:Label ID="Label1" runat="server">(Mostrar detalles...)</asp:Label>
                                                </asp:Panel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="vertical-align: top; text-align: left;">
                                                <asp:Panel ID="ContentPanelUsuarios" runat="server" CssClass="collapsePanel" Width="100%">
                                                    <asp:DetailsView ID="dvQuincenas" runat="server" AutoGenerateRows="False" CellPadding="0" SkinID="SkinDetailsView" Width="100%">
                                                        <Fields>
                                                            <asp:TemplateField ShowHeader="False">
                                                                <InsertItemTemplate>
                                                                </InsertItemTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblDatosQna" runat="server" SkinID="SkinLblHeader" Text="Datos de la quincena"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Quincena">
                                                                <InsertItemTemplate>
                                                                </InsertItemTemplate>
                                                                <HeaderStyle Wrap="False" />
                                                                <ItemStyle Wrap="False" />
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblQuincena" runat="server" Text='<%# Bind("Quincena") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Estatus actual">
                                                                <InsertItemTemplate>
                                                                </InsertItemTemplate>
                                                                <HeaderStyle Wrap="False" />
                                                                <ItemStyle Wrap="False" />
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblEstatusQna" runat="server" Text='<%# Bind("DescEstatusQna") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Nuevo estatus">
                                                                <InsertItemTemplate>
                                                                </InsertItemTemplate>
                                                                <HeaderStyle Wrap="False" />
                                                                <ItemStyle Wrap="False" />
                                                                <ItemTemplate>
                                                                    <asp:DropDownList ID="ddlEstatusQuincena" runat="server" SkinID="SkinDropDownList">
                                                                    </asp:DropDownList>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Adicional">
                                                                <InsertItemTemplate>
                                                                </InsertItemTemplate>
                                                                <HeaderStyle Wrap="False" />
                                                                <ItemStyle Wrap="False" />
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbltxtNuevaAdic" runat="server" Text='<%# Bind("NuevaAdicional") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Abarca per&#237;odo vacacional">
                                                                <InsertItemTemplate>
                                                                </InsertItemTemplate>
                                                                <HeaderStyle Wrap="False" />
                                                                <ItemStyle Wrap="False" />
                                                                <ItemTemplate>
                                                                    <asp:CheckBox ID="chkbxPeriodoVacacional" runat="server" Checked='<%# Bind("PeriodoVacacional") %>'
                                                                        SkinID="SkinCheckBox" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Fecha de pago">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtbxFecNac" runat="server" MaxLength="10" SkinID="SkinTextBox"
                                                                        Text='<%# Bind("FechaDePago") %>' Wrap="False"></asp:TextBox>
                                                                    <ajaxToolkit:CalendarExtender ID="txtbxFecNac_CE" runat="server" Enabled="True" 
                                                                        TargetControlID="txtbxFecNac" Format="dd/MM/yyyy" 
                                                                        TodaysDateFormat="MMMM dd, yyyy">
                                                                    </ajaxToolkit:CalendarExtender>
                                                                    &nbsp;<asp:ImageButton
                                                                            ID="ibFecNac" runat="server" CausesValidation="False" 
                                                                        CssClass="ibFechNac" ImageUrl="~/Imagenes/Fecha.png" Visible="False" />
                                                                    <asp:RequiredFieldValidator ID="RFVFecNac1" runat="server" ControlToValidate="txtbxFecNac"
                                                                        Display="None" ErrorMessage="Fecha de nacimiento requerida" ValidationGroup="GrupoGuardar"></asp:RequiredFieldValidator>
                                                                    <asp:CompareValidator ID="CVFechaPagoVSFechaCierre" runat="server" 
                                                                        ControlToCompare="txtbxFecCierre" ControlToValidate="txtbxFecNac" 
                                                                        Display="None" 
                                                                        ErrorMessage="Fecha de pago debe ser mayor o igual que la Fecha de Cierre." 
                                                                        Operator="GreaterThanEqual" Type="Date" ValidationGroup="GrupoGuardar"></asp:CompareValidator>
                                                                    <asp:CompareValidator
                                                                            ID="CVFecNac1" runat="server" ControlToValidate="txtbxFecNac" Display="None"
                                                                            ErrorMessage="Fecha no válida" Operator="DataTypeCheck" Type="Date" ValidationGroup="GrupoGuardar"></asp:CompareValidator>
                                                                    <asp:HiddenField ID="hfFecNac" runat="server" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Fecha de cierre">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtbxFecCierre" runat="server" MaxLength="10" SkinID="SkinTextBox"
                                                                        Text='<%# Bind("FechaCierre") %>' Wrap="False"></asp:TextBox>
                                                                    <ajaxToolkit:CalendarExtender ID="txtbxFecCierre_CE" runat="server" 
                                                                        Enabled="True" TargetControlID="txtbxFecCierre" Format="dd/MM/yyyy" 
                                                                        TodaysDateFormat="MMMM dd, yyyy">
                                                                    </ajaxToolkit:CalendarExtender>
                                                                    &nbsp;<asp:ImageButton
                                                                            ID="ibFecCierre" runat="server" CausesValidation="False" 
                                                                        CssClass="ibFechNac" ImageUrl="~/Imagenes/Fecha.png" Visible="False" />
                                                                            <asp:CompareValidator ID="CVFecCierre" runat="server" ControlToValidate="txtbxFecCierre" Display="None"
                                                                            ErrorMessage="Fecha no válida" Operator="DataTypeCheck" Type="Date" ValidationGroup="GrupoGuardar"></asp:CompareValidator>
                                                                    <asp:HiddenField ID="hfFecCierre" runat="server" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="T&#237;tulo para reportes">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="tbObservs" runat="server" Height="50px" SkinID="SkinTextBox" Text='<%# Bind("Observaciones") %>'
                                                                        TextMode="MultiLine" Width="300px"></asp:TextBox>
                                                                </ItemTemplate>
                                                                <HeaderStyle VerticalAlign="Top" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Comentarios">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="tbComentarios" runat="server" Height="50px" SkinID="SkinTextBox" Text='<%# Bind("Observaciones2") %>'
                                                                        TextMode="MultiLine" Width="300px"></asp:TextBox>
                                                                </ItemTemplate>
                                                                <HeaderStyle VerticalAlign="Top" />
                                                            </asp:TemplateField>                                                            
                                                            <asp:TemplateField HeaderText="Aplicar ajuste I.S.P.T.">
                                                                <ItemTemplate>
                                                                    <asp:CheckBox ID="chbxAplicarAjusteISPT" runat="server" Checked='<%# Bind("AplicarAjusteISPT") %>'
                                                                        SkinID="SkinCheckBox" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Pago de retroactividad">
                                                                <ItemTemplate>
                                                                    <asp:CheckBox ID="chbxPagoDeRetro" runat="server" Checked='<%# Bind("PagoDeRetroactividad") %>'
                                                                        SkinID="SkinCheckBox" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Liberar para procesos externos">
                                                                <ItemTemplate>
                                                                    <asp:CheckBox ID="chbxLiberadaParaPortalAdmvo" runat="server" Checked='<%# Bind("LiberadaParaPortalAdmvo") %>'
                                                                        SkinID="SkinCheckBox" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField> 
                                                            <asp:TemplateField HeaderText="Permitir administrar recibos fuera de nómina">
                                                                <ItemTemplate>
                                                                    <asp:CheckBox ID="chbxPermiteABCdeRecibos" runat="server" Checked='<%# Bind("PermiteABCdeRecibos") %>'
                                                                        SkinID="SkinCheckBox" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField> 
                                                            <asp:TemplateField ShowHeader="False">
                                                                <HeaderStyle Wrap="False" />
                                                                <ItemStyle HorizontalAlign="Right" Wrap="False" />
                                                                <InsertItemTemplate>
                                                                </InsertItemTemplate>
                                                                <ItemTemplate>
                                                                    <ajaxToolkit:ConfirmButtonExtender ID="CBE" runat="server" ConfirmText="¿Está seguro de realizar la operación?"
                                                                        TargetControlID="btnGuardar">
                                                                    </ajaxToolkit:ConfirmButtonExtender>
                                                                    <asp:Button ID="btnCancelar" runat="server" OnClick="btnGuardar_Click" SkinID="SkinBoton"
                                                                        Text="Cancelar"
                                                                        Width="80px" CausesValidation="False" 
                                                                        PostBackUrl="~/Administracion/Quincenas/Quincenas.aspx?TipoOperacion=4" 
                                                                        ToolTip="Cancelar operación actual" />
                                                                    <asp:Button ID="btnGuardar" runat="server" OnClick="btnGuardar_Click" 
                                                                        SkinID="SkinBoton" Text="Guardar" ValidationGroup="GrupoGuardar" Width="80px" />
                                                                    <asp:ValidationSummary ID="VSGrupoGuardar" runat="server" ShowMessageBox="True"
                                                                            ShowSummary="False" ValidationGroup="GrupoGuardar" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Fields>
                                                    </asp:DetailsView>                                                
                                                </asp:Panel>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="viewCapturaExitosa" runat="server">
            <table style="width: 70%">
                <tr>
                    <td style="vertical-align: middle; width: 0%; text-align: left">
                        <asp:Image ID="Image2" runat="server" ImageUrl="~/Imagenes/Symbol-Check.png" Width="100px" /></td>
                    <td style="vertical-align: middle; text-align: left">
                        <asp:Label ID="lblCapturaExitosa" runat="server" SkinID="SkinLblMsjExito" Text="Operación realizada exitosamente."></asp:Label><br />
                        <br />
                        <asp:LinkButton ID="lbOtraOperacion" runat="server" SkinID="SkinLinkButton">Cambiar más datos a la quincena</asp:LinkButton>
                        &nbsp;<asp:LinkButton ID="lbOtraOperacion0" runat="server" 
                            PostBackUrl="~/Administracion/Quincenas/Quincenas.aspx?TipoOperacion=4" 
                            SkinID="SkinLinkButton">Continuar con otra operación en el sistema</asp:LinkButton>
                    </td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="viewErrores" runat="server">
            <table style="width: 70%">
                <tr>
                    <td style="vertical-align: middle; width: 0%; text-align: left">
                        <asp:Image ID="Image3" runat="server" ImageUrl="~/Imagenes/Symbol-Stop.png" Width="100px" /></td>
                    <td style="vertical-align: middle; text-align: left">
                        <asp:Label ID="lblErrores" runat="server" SkinID="SkinLblMsjErrores"></asp:Label><br />
                        <br />
                        <asp:LinkButton ID="lbReintentarCaptura" runat="server" SkinID="SkinLinkButton">Reintentar captura</asp:LinkButton></td>
                </tr>
            </table>
        </asp:View>
    </asp:MultiView>
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

