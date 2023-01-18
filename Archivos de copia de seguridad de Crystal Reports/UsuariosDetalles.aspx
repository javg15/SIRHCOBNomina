<%@ Page Language="VB" MasterPageFile="~/MasterPageSesionIniciada.master" AutoEventWireup="false"
    CodeFile="UsuariosDetalles.aspx.vb" Inherits="Administracion_Usuarios_UsuariosDetalles"
    Title="COBAEV - Nómina - Administrar usuarios" StylesheetTheme="SkinFile" %>

<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress"
    TagPrefix="TP_wucUpdateProgress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
    <table style="width: 100%;" align="center">
        <tr>
            <td style="vertical-align: top; text-align: right">
                <h2>
                    <asp:Label ID="lblHeadPage" runat="server" Text="Usuarios (Vista detalle)"></asp:Label>
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
                                <td style="vertical-align: top; height: 213px; text-align: left">
                                    <ajaxToolkit:CollapsiblePanelExtender ID="CPEUsuarios" runat="Server" CollapseControlID="TitlePanelUsuarios"
                                        Collapsed="False" CollapsedImage="~/Imagenes/expand_blue.jpg" CollapsedText="(Mostrar panel...)"
                                        ExpandControlID="TitlePanelUsuarios" ExpandedImage="~/Imagenes/collapse_blue.jpg"
                                        ExpandedText="(Ocultar panel...)" ImageControlID="Image1" SuppressPostBack="true"
                                        TargetControlID="ContentPanelUsuarios" TextLabelID="Label1">
                                    </ajaxToolkit:CollapsiblePanelExtender>
                                    <table cellpadding="0" cellspacing="0" style="width: 100%">
                                        <tr>
                                            <td colspan="2" style="vertical-align: top; text-align: left">
                                                <asp:Panel ID="TitlePanelUsuarios" runat="server" BorderColor="White" BorderStyle="Solid"
                                                    BorderWidth="1px" CssClass="collapsePanelHeader" Width="100%">
                                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/expand_blue.jpg" />
                                                    Captura/Modificación
                                                    <asp:Label ID="Label1" runat="server">(Mostrar detalles...)</asp:Label>
                                                </asp:Panel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="vertical-align: top; text-align: left">
                                                <asp:Panel ID="ContentPanelUsuarios" runat="server" CssClass="collapsePanel" Width="100%">
                                                    <asp:DetailsView ID="dvUsuarios" runat="server" AutoGenerateRows="False" CellPadding="0"
                                                        DefaultMode="Insert" EmptyDataText="Sin información de hijos" 
                                                        SkinID="SkinDetailsView" Width="100%">
                                                        <Fields>
                                                            <asp:TemplateField ShowHeader="False">
                                                                <InsertItemTemplate>
                                                                    <asp:Label ID="Label2" runat="server" SkinID="SkinLblHeader" Text="Datos del usuario"></asp:Label>
                                                                </InsertItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Login">
                                                                <InsertItemTemplate>
                                                                    <asp:TextBox ID="txtbxLogin" runat="server" Columns="20" MaxLength="30" SkinID="SkinTextBox"></asp:TextBox><asp:RequiredFieldValidator
                                                                        ID="RFVLogin" runat="server" ControlToValidate="txtbxLogin" Display="None" ErrorMessage="Login requerido."
                                                                        ValidationGroup="GrupoGuardar"></asp:RequiredFieldValidator>
                                                                </InsertItemTemplate>
                                                                <HeaderStyle Wrap="False" />
                                                                <ItemStyle Wrap="False" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Password">
                                                                <InsertItemTemplate>
                                                                    <asp:TextBox ID="txtbxPassw1" runat="server" Columns="20" MaxLength="15" SkinID="SkinTextBox"
                                                                        TextMode="Password" ValidationGroup="GrupoGuardar"></asp:TextBox><asp:RequiredFieldValidator
                                                                            ID="RFVPassw1" runat="server" Display="None" ErrorMessage="Password requerido."
                                                                            ValidationGroup="GrupoGuardar" ControlToValidate="txtbxPassw1"></asp:RequiredFieldValidator>
                                                                </InsertItemTemplate>
                                                                <HeaderStyle Wrap="False" />
                                                                <ItemStyle Wrap="False" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Confirme password">
                                                                <InsertItemTemplate>
                                                                    <asp:TextBox ID="txtbxPassw2" runat="server" Columns="20" MaxLength="15" SkinID="SkinTextBox"
                                                                        TextMode="Password" ValidationGroup="GrupoGuardar"></asp:TextBox><asp:RequiredFieldValidator
                                                                            ID="RFVPassw2" runat="server" ControlToValidate="txtbxPassw2" Display="None"
                                                                            ErrorMessage="Password requerido." ValidationGroup="GrupoGuardar"></asp:RequiredFieldValidator>
                                                                    <asp:CompareValidator ID="CVPassw" runat="server" ControlToCompare="txtbxPassw1"
                                                                        ControlToValidate="txtbxPassw2" Display="None" ErrorMessage="Contraseñas no coinciden."
                                                                        ValidationGroup="GrupoGuardar"></asp:CompareValidator>
                                                                </InsertItemTemplate>
                                                                <HeaderStyle Wrap="False" />
                                                                <ItemStyle Wrap="False" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Apellido paterno">
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="txtbxApePat" runat="server" Columns="40" MaxLength="30" SkinID="SkinTextBox"></asp:TextBox>
                                                                </EditItemTemplate>
                                                                <InsertItemTemplate>
                                                                    <asp:TextBox ID="txtbxApePat" runat="server" Columns="40" MaxLength="30" SkinID="SkinTextBox"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RFVApePatEmp1" runat="server" ControlToValidate="txtbxApePat"
                                                                        Display="None" ErrorMessage="Apellido paterno requerido" ValidationGroup="GrupoGuardar"></asp:RequiredFieldValidator><asp:RequiredFieldValidator
                                                                            ID="RFVApePatEmp2" runat="server" ControlToValidate="txtbxApePat" Display="None"
                                                                            ErrorMessage="Apellido paterno requerido" ValidationGroup="GrupoRFCCURP"></asp:RequiredFieldValidator><ajaxToolkit:AutoCompleteExtender
                                                                                ID="ACEApellidosP" runat="server" BehaviorID="AutoCompleteAP" EnableCaching="true"
                                                                                MinimumPrefixLength="2" ServiceMethod="BuscarApellidos" ServicePath="~/WSBusquedas.asmx"
                                                                                TargetControlID="txtbxApePat">
                                                                            </ajaxToolkit:AutoCompleteExtender>
                                                                    <ajaxToolkit:FilteredTextBoxExtender ID="FTBEApellidosP" runat="server" FilterType="Custom, UppercaseLetters, LowercaseLetters"
                                                                        TargetControlID="txtbxApePat" ValidChars=" ñÑáÁéÉíÍóÓúÚ">
                                                                    </ajaxToolkit:FilteredTextBoxExtender>
                                                                </InsertItemTemplate>
                                                                <HeaderStyle Wrap="False" />
                                                                <ItemStyle Wrap="False" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Apellido materno">
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="txtbxApeMat" runat="server" Columns="40" MaxLength="30" SkinID="SkinTextBox"></asp:TextBox>
                                                                </EditItemTemplate>
                                                                <InsertItemTemplate>
                                                                    <asp:TextBox ID="txtbxApeMat" runat="server" Columns="40" MaxLength="30" SkinID="SkinTextBox"></asp:TextBox><ajaxToolkit:AutoCompleteExtender
                                                                        ID="ACEApellidosM" runat="server" EnableCaching="true" MinimumPrefixLength="2"
                                                                        ServiceMethod="BuscarApellidos" ServicePath="~/WSBusquedas.asmx" TargetControlID="txtbxApeMat">
                                                                    </ajaxToolkit:AutoCompleteExtender>
                                                                    <ajaxToolkit:FilteredTextBoxExtender ID="FTBEApellidosM" runat="server" FilterType="Custom, UppercaseLetters, LowercaseLetters"
                                                                        TargetControlID="txtbxApeMat" ValidChars=" ñÑáÁéÉíÍóÓúÚ">
                                                                    </ajaxToolkit:FilteredTextBoxExtender>
                                                                </InsertItemTemplate>
                                                                <HeaderStyle Wrap="False" />
                                                                <ItemStyle Wrap="False" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Nombre">
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="txtbxNombre" runat="server" Columns="40" MaxLength="30" SkinID="SkinTextBox"></asp:TextBox>
                                                                </EditItemTemplate>
                                                                <InsertItemTemplate>
                                                                    <asp:TextBox ID="txtbxNombre" runat="server" Columns="40" MaxLength="30" SkinID="SkinTextBox"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RFVNombre1" runat="server" ControlToValidate="txtbxNombre"
                                                                        Display="None" ErrorMessage="Nombre requerido" ValidationGroup="GrupoGuardar"></asp:RequiredFieldValidator><asp:RequiredFieldValidator
                                                                            ID="RFVNombre2" runat="server" ControlToValidate="txtbxNombre" Display="None"
                                                                            ErrorMessage="Nombre requerido" ValidationGroup="GrupoRFCCURP"></asp:RequiredFieldValidator>
                                                                    <ajaxToolkit:AutoCompleteExtender ID="ACENombres" runat="server" EnableCaching="true"
                                                                        MinimumPrefixLength="2" ServiceMethod="BuscarNombres" ServicePath="~/WSBusquedas.asmx"
                                                                        TargetControlID="txtbxNombre">
                                                                    </ajaxToolkit:AutoCompleteExtender>
                                                                    <ajaxToolkit:FilteredTextBoxExtender ID="FTBENombres" runat="server" FilterType="Custom, UppercaseLetters, LowercaseLetters"
                                                                        TargetControlID="txtbxNombre" ValidChars=" ñÑáÁéÉíÍóÓúÚ">
                                                                    </ajaxToolkit:FilteredTextBoxExtender>
                                                                </InsertItemTemplate>
                                                                <HeaderStyle Wrap="False" />
                                                                <ItemStyle Wrap="False" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Iniciales">
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="txtbxIniciales" runat="server" Columns="10" MaxLength="10" SkinID="SkinTextBox"></asp:TextBox>
                                                                </EditItemTemplate>
                                                                <InsertItemTemplate>
                                                                    <asp:TextBox ID="txtbxIniciales" runat="server" Columns="10" MaxLength="10" SkinID="SkinTextBox"></asp:TextBox>
                                                                    <ajaxToolkit:FilteredTextBoxExtender ID="FTBEIniciales" runat="server" FilterType="Custom, UppercaseLetters, LowercaseLetters"
                                                                        TargetControlID="txtbxIniciales" ValidChars=" ñÑáÁéÉíÍóÓúÚ">
                                                                    </ajaxToolkit:FilteredTextBoxExtender>
                                                                </InsertItemTemplate>
                                                                <HeaderStyle Wrap="False" />
                                                                <ItemStyle Wrap="False" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Rol">
                                                                <EditItemTemplate>
                                                                    <asp:DropDownList ID="ddlRoles" runat="server" SkinID="SkinDropDownList">
                                                                    </asp:DropDownList>
                                                                </EditItemTemplate>
                                                                <InsertItemTemplate>
                                                                    <asp:DropDownList ID="ddlRoles" runat="server" SkinID="SkinDropDownList">
                                                                    </asp:DropDownList>
                                                                </InsertItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ShowHeader="False">
                                                                <HeaderStyle Wrap="False" />
                                                                <ItemStyle HorizontalAlign="Right" Wrap="False" />
                                                                <InsertItemTemplate>
                                                                    <ajaxToolkit:ConfirmButtonExtender ID="CBE" runat="server" ConfirmText="¿Está seguro de guardar los cambios realizados?"
                                                                        TargetControlID="btnGuardar">
                                                                    </ajaxToolkit:ConfirmButtonExtender>
                                                                    <asp:Button ID="btnCancelar" runat="server" SkinID="SkinBoton" Text="Cancelar" 
                                                                        ToolTip="Cancelar" OnClick="btnGuardar_Click" CausesValidation="False" 
                                                                        PostBackUrl="~/Administracion/Usuarios.aspx?TipoOperacion=4" />&nbsp;<asp:Button 
                                                                        ID="btnGuardar" runat="server" OnClick="btnGuardar_Click" SkinID="SkinBoton" 
                                                                        Text="Guardar" ToolTip="Guardar información del usuario" 
                                                                        ValidationGroup="GrupoGuardar" />
                                                                    <asp:ValidationSummary
                                                                            ID="VSGrupoGuardar" runat="server" ShowMessageBox="True" ShowSummary="False"
                                                                            ValidationGroup="GrupoGuardar" />
                                                                </InsertItemTemplate>
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
                        <asp:Image ID="Image2" runat="server" ImageUrl="~/Imagenes/Symbol-Check.png" Width="100px" />
                    </td>
                    <td style="vertical-align: middle; text-align: left">
                        <asp:Label ID="lblCapturaExitosa" runat="server" SkinID="SkinLblMsjExito" Text="Captura realizada exitosamente"></asp:Label>
                        <br />
                        <asp:LinkButton ID="lbContinuar" runat="server" 
                            PostBackUrl="~/Administracion/Usuarios.aspx?TipoOperacion=4">Continuar</asp:LinkButton>
                    </td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="viewErrores" runat="server">
            <table style="width: 70%">
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
    </asp:MultiView>
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
