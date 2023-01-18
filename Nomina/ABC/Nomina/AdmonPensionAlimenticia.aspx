<%@ Page Language="VB" MasterPageFile="~/MasterPageBlanca.master" AutoEventWireup="false"
    CodeFile="AdmonPensionAlimenticia.aspx.vb" Inherits="AdmonPensionAlimenticia"
    Title="COBAEV - Nómina - Administrar pensión alimenticia" StylesheetTheme="SkinFile" %>

<%@ Register Src="../../WebControls/wucEfectos.ascx" TagName="wucEfectos" TagPrefix="uc1" %>
<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress"
    TagPrefix="TP_wucUpdateProgress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
        <table style="width: 100%;">
            <tr>
                <td style="vertical-align: top; text-align: right">
                    <h2>
                        Pensión alimenticia: Administración datos de beneficario
                    </h2>
                </td>
            </tr>
        </table>
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="viewCaptura" runat="server">
            <table style="width: 70%; height: 300px">
                <tr>
                    <td style="vertical-align: top; width: 70%; height: 100%; text-align: left">
                        <table style="width: 100%">
                            <tr>
                                <td style="vertical-align: top; height: 213px; text-align: left">
                                    <ajaxToolkit:CollapsiblePanelExtender ID="CPEBeneficiarios" runat="Server" CollapseControlID="TitlePanelBeneficiarios"
                                        Collapsed="False" CollapsedImage="~/Imagenes/expand_blue.jpg" CollapsedText="(Mostrar panel...)"
                                        ExpandControlID="TitlePanelBeneficiarios" ExpandedImage="~/Imagenes/collapse_blue.jpg"
                                        ExpandedText="(Ocultar panel...)" ImageControlID="Image1" SuppressPostBack="true"
                                        TargetControlID="ContentPanelBeneficiarios" TextLabelID="Label1">
                                    </ajaxToolkit:CollapsiblePanelExtender>
                                    <table cellpadding="0" cellspacing="0" style="width: 100%">
                                        <tr>
                                            <td colspan="2" style="vertical-align: top; text-align: left">
                                                <asp:Panel ID="TitlePanelBeneficiarios" runat="server" BorderColor="White" BorderStyle="Solid"
                                                    BorderWidth="1px" CssClass="collapsePanelHeader" Width="100%">
                                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/expand_blue.jpg" />
                                                    Captura/Modificación
                                                    <asp:Label ID="Label1" runat="server">(Mostrar detalles...)</asp:Label>
                                                </asp:Panel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="vertical-align: top; text-align: left">
                                                <asp:Panel ID="ContentPanelBeneficiarios" runat="server" CssClass="collapsePanel"
                                                    Width="100%">
                                                    <asp:DetailsView ID="dvBeneficiarios" runat="server" AutoGenerateRows="False" CellPadding="0"
                                                        DefaultMode="Insert" EmptyDataText="Sin información de beneficarios" SkinID="SkinDetailsView">
                                                        <Fields>
                                                            <asp:TemplateField ShowHeader="False">
                                                                <InsertItemTemplate>
                                                                    <asp:Label ID="Label2" runat="server" SkinID="SkinLblHeader" Text="Datos del beneficiario"></asp:Label>
                                                                </InsertItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="R.F.C.">
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="txtbxRFC" runat="server" Columns="20" MaxLength="13" SkinID="SkinTextBox"></asp:TextBox>
                                                                </EditItemTemplate>
                                                                <InsertItemTemplate>
                                                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:TextBox ID="txtbxRFC" runat="server" SkinID="SkinTextBox" MaxLength="13" Columns="20"></asp:TextBox><asp:RegularExpressionValidator
                                                                                ID="REVRFC" runat="server" ValidationExpression="[A-Z]{4}\d{6}[A-Z, 0-9][A-Z, 0-9][A-Z, 0-9]"
                                                                                ControlToValidate="txtbxRFC" Display="None" ErrorMessage="Longitud de RFC no válida"
                                                                                ValidationGroup="GrupoGuardar"></asp:RegularExpressionValidator><ajaxToolkit:FilteredTextBoxExtender
                                                                                    ID="FTBERFC" runat="server" TargetControlID="txtbxRFC" FilterType="Numbers, UppercaseLetters">
                                                                                </ajaxToolkit:FilteredTextBoxExtender>
                                                                        </ContentTemplate>
                                                                        <Triggers>
                                                                            <asp:AsyncPostBackTrigger ControlID="btnGeneraRFC" EventName="Click"></asp:AsyncPostBackTrigger>
                                                                        </Triggers>
                                                                    </asp:UpdatePanel>
                                                                </InsertItemTemplate>
                                                                <HeaderStyle Wrap="False" />
                                                                <ItemStyle Wrap="False" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="C.U.R.P.">
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="txtbxCURP" runat="server" Columns="30" MaxLength="18" SkinID="SkinTextBox"></asp:TextBox>
                                                                </EditItemTemplate>
                                                                <InsertItemTemplate>
                                                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:TextBox ID="txtbxCURP" runat="server" SkinID="SkinTextBox" MaxLength="18" Columns="30"></asp:TextBox><asp:RegularExpressionValidator
                                                                                ID="REVCURP" runat="server" ValidationExpression="[A-Z]{4}\d{6}[A-Z]{6}[A-Z, 0-9]{2}"
                                                                                ControlToValidate="txtbxCURP" Display="None" ErrorMessage="Longitud o formato de CURP no válida"
                                                                                ValidationGroup="GrupoGuardar"></asp:RegularExpressionValidator><ajaxToolkit:FilteredTextBoxExtender
                                                                                    ID="FTBECURP" runat="server" TargetControlID="txtbxCURP" FilterType="Numbers, UppercaseLetters">
                                                                                </ajaxToolkit:FilteredTextBoxExtender>
                                                                        </ContentTemplate>
                                                                        <Triggers>
                                                                            <asp:AsyncPostBackTrigger ControlID="btnGeneraRFC" EventName="Click"></asp:AsyncPostBackTrigger>
                                                                        </Triggers>
                                                                    </asp:UpdatePanel>
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
                                                                            ErrorMessage="Apellido paterno requerido" ValidationGroup="GrupoRFCCURP"></asp:RequiredFieldValidator>
                                                                            <ajaxToolkit:AutoCompleteExtender
                                                                                ID="ACEApellidosP" runat="server" BehaviorID="AutoCompleteAP" EnableCaching="true"
                                                                                MinimumPrefixLength="2" ServiceMethod="BuscarApellidos" ServicePath="~/WSBusquedas.asmx"
                                                                                TargetControlID="txtbxApePat">
                                                                            </ajaxToolkit:AutoCompleteExtender>
                                                                    <ajaxToolkit:FilteredTextBoxExtender ID="FTBEApellidosP" runat="server" FilterType="Custom, UppercaseLetters, LowercaseLetters"
                                                                        TargetControlID="txtbxApePat" ValidChars=" ÑñÁáÉéÍíÓóÚó">
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
                                                                        TargetControlID="txtbxApeMat" ValidChars=" ÑñÁáÉéÍíÓóÚó">
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
                                                                        TargetControlID="txtbxNombre" ValidChars=" ÑñÁáÉéÍíÓóÚó">
                                                                    </ajaxToolkit:FilteredTextBoxExtender>
                                                                </InsertItemTemplate>
                                                                <HeaderStyle Wrap="False" />
                                                                <ItemStyle Wrap="False" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Sexo">
                                                                <EditItemTemplate>
                                                                    <asp:DropDownList ID="ddlSexos" runat="server" SkinID="SkinDropDownList">
                                                                    </asp:DropDownList>
                                                                </EditItemTemplate>
                                                                <InsertItemTemplate>
                                                                    <asp:DropDownList ID="ddlSexos" runat="server" AutoPostBack="True" SkinID="SkinDropDownList"
                                                                        OnSelectedIndexChanged="ddlSexos_SelectedIndexChanged">
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="RFVSexos" runat="server" ControlToValidate="ddlSexos"
                                                                        Display="None" ErrorMessage="Sexo requerido" InitialValue="3" ValidationGroup="GrupoRFCCURP"></asp:RequiredFieldValidator>
                                                                </InsertItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Fecha de nacimiento">
                                                                <InsertItemTemplate>
                                                                    <asp:TextBox ID="txtbxFecNac" runat="server" MaxLength="10" SkinID="SkinTextBox"
                                                                        Wrap="False"></asp:TextBox>
                                                                    <asp:ImageButton ID="ibFecNac" runat="server" CausesValidation="False" CssClass="ibFechNac"
                                                                        ImageUrl="~/Imagenes/Fecha.png" /><asp:RequiredFieldValidator ID="RFVFecNac2" runat="server"
                                                                            ControlToValidate="txtbxFecNac" Display="None" ErrorMessage="Fecha de nacimiento requerida"
                                                                            ValidationGroup="GrupoRFCCURP"></asp:RequiredFieldValidator><asp:CompareValidator
                                                                                ID="CVFecNac1" runat="server" ControlToValidate="txtbxFecNac" Display="None"
                                                                                ErrorMessage="Fecha no válida" Operator="DataTypeCheck" Type="Date" ValidationGroup="GrupoGuardar"></asp:CompareValidator><asp:CompareValidator
                                                                                    ID="CVFecNac2" runat="server" ControlToValidate="txtbxFecNac" Display="None"
                                                                                    ErrorMessage="Fecha no válida" Operator="DataTypeCheck" Type="Date" ValidationGroup="GrupoRFCCURP"></asp:CompareValidator>
                                                                    <asp:HiddenField ID="hfFecNac" runat="server" />
                                                                </InsertItemTemplate>
                                                                <HeaderStyle Wrap="False" />
                                                                <ItemStyle Wrap="False" />
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="txtbxFecNac" runat="server" MaxLength="10" SkinID="SkinTextBox"
                                                                        Wrap="False"></asp:TextBox>
                                                                    <asp:ImageButton ID="ibFecNac" runat="server" CssClass="ibFechNac" ImageUrl="~/Imagenes/Fecha.png" />
                                                                    <asp:HiddenField ID="hfFecNac" runat="server" />
                                                                </EditItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Estado natal">
                                                                <EditItemTemplate>
                                                                    <asp:DropDownList ID="ddlEstados" runat="server" SkinID="SkinDropDownList">
                                                                    </asp:DropDownList>
                                                                </EditItemTemplate>
                                                                <InsertItemTemplate>
                                                                    <asp:DropDownList ID="ddlEstados" runat="server" SkinID="SkinDropDownList">
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="RFVEstados" runat="server" ControlToValidate="ddlEstados"
                                                                        Display="None" ErrorMessage="Estado natal requerido" InitialValue="99" ValidationGroup="GrupoRFCCURP"></asp:RequiredFieldValidator>
                                                                </InsertItemTemplate>
                                                                <HeaderStyle Wrap="False" />
                                                                <ItemStyle Wrap="False" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Parentesco">
                                                                <EditItemTemplate>
                                                                    <asp:DropDownList ID="ddlParentescos" runat="server" SkinID="SkinDropDownList">
                                                                    </asp:DropDownList>
                                                                </EditItemTemplate>
                                                                <InsertItemTemplate>
                                                                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:DropDownList ID="ddlParentescos" runat="server" SkinID="SkinDropDownList">
                                                                            </asp:DropDownList>
                                                                            <asp:RequiredFieldValidator ID="RFVParentescos" runat="server" ControlToValidate="ddlParentescos"
                                                                                Display="None" ErrorMessage="Parentesco requerido" InitialValue="7" ValidationGroup="GrupoGuardar">
                                                                                </asp:RequiredFieldValidator>
                                                                        </ContentTemplate>
                                                                        <Triggers>
                                                                            <asp:AsyncPostBackTrigger ControlID="ddlsexos" EventName="SelectedIndexChanged" />
                                                                        </Triggers>
                                                                    </asp:UpdatePanel>
                                                                </InsertItemTemplate>
                                                                <ItemTemplate>
                                                                    &nbsp;
                                                                </ItemTemplate>
                                                                <HeaderStyle Wrap="False" />
                                                                <ItemStyle Wrap="False" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Porcentaje">
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="txtbxPorc" runat="server" Columns="10" MaxLength="5" SkinID="SkinTextBox"></asp:TextBox>
                                                                </EditItemTemplate>
                                                                <InsertItemTemplate>
                                                                    <asp:TextBox ID="txtbxPorc" runat="server" Columns="10" MaxLength="5" SkinID="SkinTextBox"
                                                                        ValidationGroup="GrupoGuardar"></asp:TextBox><ajaxToolkit:FilteredTextBoxExtender
                                                                            ID="FTBEPorc" runat="server" FilterType="Custom, Numbers" TargetControlID="txtbxPorc"
                                                                            ValidChars=".">
                                                                        </ajaxToolkit:FilteredTextBoxExtender>
                                                                    <asp:CompareValidator ID="CVPorc" runat="server" ControlToValidate="txtbxPorc" Display="None"
                                                                        ErrorMessage="Porcentaje incorrecto" Operator="DataTypeCheck" Type="Double" ValidationGroup="GrupoGuardar"></asp:CompareValidator><asp:RequiredFieldValidator
                                                                            ID="RFVPorc" runat="server" ControlToValidate="txtbxPorc" Display="None" ErrorMessage="Porcentaje requerido"
                                                                            ValidationGroup="GrupoGuardar"></asp:RequiredFieldValidator>
                                                                    <asp:CompareValidator ID="CVPorc2" runat="server" ControlToValidate="txtbxPorc" Display="None"
                                                                        ErrorMessage="Porcentaje debe ser mayor de 0" Operator="GreaterThan" Type="Double"
                                                                        ValidationGroup="GrupoGuardar" ValueToCompare="0.01"></asp:CompareValidator>
                                                                </InsertItemTemplate>
                                                                <HeaderStyle Wrap="False" />
                                                                <ItemStyle Wrap="False" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Prioridad para c&#225;lculo">
                                                                <EditItemTemplate>
                                                                    <asp:DropDownList ID="ddlPrioridadCalculo" runat="server" SkinID="SkinDropDownList">
                                                                        <asp:ListItem Selected="True">1</asp:ListItem>
                                                                        <asp:ListItem>2</asp:ListItem>
                                                                        <asp:ListItem>3</asp:ListItem>
                                                                        <asp:ListItem>4</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </EditItemTemplate>
                                                                <InsertItemTemplate>
                                                                    <asp:DropDownList ID="ddlPrioridadCalculo" runat="server" SkinID="SkinDropDownList">
                                                                    </asp:DropDownList>
                                                                </InsertItemTemplate>
                                                                <ItemTemplate>
                                                                    &nbsp;
                                                                </ItemTemplate>
                                                                <HeaderStyle Wrap="False" />
                                                                <ItemStyle Wrap="False" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Vigencia inicial/final">
                                                                <EditItemTemplate>
                                                                    <uc1:wucEfectos ID="WucEfectos1" runat="server" />
                                                                </EditItemTemplate>
                                                                <InsertItemTemplate>
                                                                    <uc1:wucEfectos ID="WucEfectos1" runat="server" />
                                                                </InsertItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Plantel para pago">
                                                                <EditItemTemplate>
                                                                    <asp:DropDownList ID="ddlPlanteles" runat="server" SkinID="SkinDropDownList">
                                                                    </asp:DropDownList>
                                                                </EditItemTemplate>
                                                                <InsertItemTemplate>
                                                                    <asp:DropDownList ID="ddlPlanteles" runat="server" SkinID="SkinDropDownList">
                                                                    </asp:DropDownList>
                                                                </InsertItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ShowHeader="False">
                                                                <EditItemTemplate>
                                                                    <ajaxToolkit:ConfirmButtonExtender ID="CBE" runat="server" ConfirmText="¿Está seguro de guardar los cambios realizados?"
                                                                        TargetControlID="btnGuardar">
                                                                    </ajaxToolkit:ConfirmButtonExtender>
                                                                    <asp:Button ID="btnGuardar" runat="server" SkinID="SkinBoton" Text="Guardar" ToolTip="Guardar información del nuevo empleado" />
                                                                </EditItemTemplate>
                                                                <HeaderStyle Wrap="False" />
                                                                <ItemStyle HorizontalAlign="Right" Wrap="False" />
                                                                <InsertItemTemplate>
                                                                    <ajaxToolkit:ConfirmButtonExtender ID="CBE" runat="server" ConfirmText="¿Está seguro de guardar los cambios realizados?"
                                                                        TargetControlID="btnGuardar">
                                                                    </ajaxToolkit:ConfirmButtonExtender>
                                                                    <asp:Button ID="btnGeneraRFC" runat="server" OnClick="btnGeneraRFC_Click" SkinID="SkinBoton"
                                                                        Text="RFC, CURP" ToolTip="Genera RFC y CURP" ValidationGroup="GrupoRFCCURP" Width="80px" />
                                                                    <asp:Button ID="btnGuardar" runat="server" OnClick="btnGuardar_Click" SkinID="SkinBoton"
                                                                        Text="Guardar" ToolTip="Guardar información del nuevo empleado" ValidationGroup="GrupoGuardar"
                                                                        Width="80px" />
                                                                    <asp:ValidationSummary ID="VSGrupoRFCCURP" runat="server" ShowMessageBox="True" ShowSummary="False"
                                                                        ValidationGroup="GrupoRFCCURP" />
                                                                    <asp:ValidationSummary ID="VSGrupoGuardar" runat="server" ShowMessageBox="True" ShowSummary="False"
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
                        <asp:Label ID="lblCapturaExitosa" runat="server" SkinID="SkinLblMsjExito" Text="Operación realizada exitosamente."></asp:Label>
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
</asp:Content>
