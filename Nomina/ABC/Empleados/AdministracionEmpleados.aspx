<%@ Page Language="VB" MasterPageFile="~/MasterPageSesionIniciada.master" AutoEventWireup="false"
    CodeFile="AdministracionEmpleados.aspx.vb" Inherits="ABC_Empleados_AdministracionEmpleados"
    Title="COBAEV - Nómina - Administrar empleados" StylesheetTheme="SkinFile" Culture="Auto"
    UICulture="Auto" %>

<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress"
    TagPrefix="TP_wucUpdateProgress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
    <table style="width: 100%;" align="center">
        <tr>
            <td style="vertical-align: top; text-align: right">
                <h2>
                    Sistema de nómina: Empleados (Administrar información personal)
                </h2>
            </td>
        </tr>
    </table>
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="viewCaptura" runat="server">
            <table style="width: 100%; height: 300px" align="center">
                <tr>
                    <td style="vertical-align: top; width: 100%; height: 100%; text-align: left">
                        <table style="width: 100%">
                            <tr>
                                <td style="vertical-align: top; text-align: left; height: 213px;">
                                    <ajaxToolkit:CollapsiblePanelExtender ID="CPEDatosPersonales" runat="Server" CollapseControlID="TitlePanelDatosPers"
                                        Collapsed="False" CollapsedImage="~/Imagenes/expand_blue.jpg" CollapsedText="(Mostrar panel...)"
                                        ExpandControlID="TitlePanelDatosPers" ExpandedImage="~/Imagenes/collapse_blue.jpg"
                                        ExpandedText="(Ocultar panel...)" ImageControlID="Image1" SuppressPostBack="true"
                                        TargetControlID="ContentPanelDatosPers" TextLabelID="Label1">
                                    </ajaxToolkit:CollapsiblePanelExtender>
                                    <table cellpadding="0" cellspacing="0" style="width: 100%">
                                        <tr>
                                            <td colspan="2" style="vertical-align: top; text-align: left;">
                                                <asp:Panel ID="TitlePanelDatosPers" runat="server" BorderColor="White" BorderStyle="Solid"
                                                    BorderWidth="1px" CssClass="collapsePanelHeader" Width="100%">
                                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/expand_blue.jpg" />
                                                    Captura/Modificación
                                                    <asp:Label ID="Label1" runat="server">(Mostrar detalles...)</asp:Label>
                                                </asp:Panel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="vertical-align: top; text-align: left;">
                                                <asp:Panel ID="ContentPanelDatosPers" runat="server" Width="100%" CssClass="collapsePanel">
                                                    <asp:DetailsView ID="dvDatosPers" runat="server" AutoGenerateRows="False" DefaultMode="Insert"
                                                        EmptyDataText="Sin información de datos personales" SkinID="SkinDetailsView"
                                                        CellPadding="0">
                                                        <Fields>
                                                            <asp:TemplateField ShowHeader="False">
                                                                <InsertItemTemplate>
                                                                    <asp:Label ID="Label2" runat="server" SkinID="SkinLblHeader" Text="Datos personales"></asp:Label></InsertItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="IdEmp" Visible="False">
                                                                <InsertItemTemplate>
                                                                    <asp:Label ID="lblIdEmp" runat="server" Text='<%# Eval("IdEmp") %>'></asp:Label></InsertItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="R.F.C.">
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="txtbxRFC" runat="server" Columns="20" MaxLength="13" SkinID="SkinTextBox"></asp:TextBox></EditItemTemplate>
                                                                <InsertItemTemplate>
                                                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:TextBox ID="txtbxRFC" runat="server" SkinID="SkinTextBox" MaxLength="13" Columns="20"
                                                                                AutoPostBack="true" OnTextChanged="txtbxRFC_TextChanged"></asp:TextBox><asp:RequiredFieldValidator
                                                                                    ID="RFVRFC" runat="server" ValidationGroup="GrupoGuardar" ErrorMessage="RFC requerido"
                                                                                    Display="None" ControlToValidate="txtbxRFC"></asp:RequiredFieldValidator><asp:RegularExpressionValidator
                                                                                        ID="REVRFC" runat="server" ValidationGroup="GrupoGuardar" ErrorMessage="Longitud de RFC no válida"
                                                                                        Display="None" ControlToValidate="txtbxRFC" ValidationExpression="[A-Z]{4}\d{6}[A-Z, 0-9][A-Z, 0-9][A-Z, 0-9]"></asp:RegularExpressionValidator><ajaxToolkit:FilteredTextBoxExtender
                                                                                            ID="FTBERFC" runat="server" TargetControlID="txtbxRFC" FilterType="Numbers, UppercaseLetters">
                                                                                        </ajaxToolkit:FilteredTextBoxExtender>
                                                                        </ContentTemplate>
                                                                        <Triggers>
                                                                            <asp:AsyncPostBackTrigger ControlID="btnGeneraRFC" EventName="Click" />
                                                                            <asp:AsyncPostBackTrigger ControlID="txtbxCURP" EventName="TextChanged" />
                                                                        </Triggers>
                                                                    </asp:UpdatePanel>
                                                                </InsertItemTemplate>
                                                                <HeaderStyle Wrap="False" />
                                                                <ItemStyle Wrap="False" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="C.U.R.P.">
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="txtbxCURP" runat="server" Columns="30" MaxLength="18" SkinID="SkinTextBox"></asp:TextBox></EditItemTemplate>
                                                                <InsertItemTemplate>
                                                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:TextBox ID="txtbxCURP" runat="server" SkinID="SkinTextBox" MaxLength="18" Columns="30"
                                                                                AutoPostBack="True" OnTextChanged="txtbxCURP_TextChanged"></asp:TextBox><asp:RequiredFieldValidator
                                                                                    ID="RFVCURP" runat="server" ValidationGroup="GrupoGuardar" ErrorMessage="CURP requerido"
                                                                                    Display="None" ControlToValidate="txtbxCURP"></asp:RequiredFieldValidator><asp:RegularExpressionValidator
                                                                                        ID="REVCURP" runat="server" ValidationGroup="GrupoGuardar" ErrorMessage="Longitud o formato de CURP no válida"
                                                                                        Display="None" ControlToValidate="txtbxCURP" ValidationExpression="[A-Z]{4}\d{6}[A-Z]{6}[A-Z, 0-9]{2}"></asp:RegularExpressionValidator><ajaxToolkit:FilteredTextBoxExtender
                                                                                            ID="FTBECURP" runat="server" TargetControlID="txtbxCURP" FilterType="Numbers, UppercaseLetters">
                                                                                        </ajaxToolkit:FilteredTextBoxExtender>
                                                                        </ContentTemplate>
                                                                        <Triggers>
                                                                            <asp:AsyncPostBackTrigger ControlID="btnGeneraRFC" EventName="Click" />
                                                                            <asp:AsyncPostBackTrigger ControlID="txtbxRFC" EventName="TextChanged" />
                                                                        </Triggers>
                                                                    </asp:UpdatePanel>
                                                                </InsertItemTemplate>
                                                                <HeaderStyle Wrap="False" />
                                                                <ItemStyle Wrap="False" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Apellido paterno">
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="txtbxApePat" runat="server" Columns="40" MaxLength="30" SkinID="SkinTextBox"></asp:TextBox></EditItemTemplate>
                                                                <InsertItemTemplate>
                                                                    <asp:TextBox ID="txtbxApePat" runat="server" Columns="40" MaxLength="30" SkinID="SkinTextBox"></asp:TextBox><asp:RequiredFieldValidator
                                                                        ID="RFVApePatEmp1" runat="server" ControlToValidate="txtbxApePat" Display="None"
                                                                        ErrorMessage="Apellido paterno requerido" ValidationGroup="GrupoGuardar"></asp:RequiredFieldValidator><asp:RequiredFieldValidator
                                                                            ID="RFVApePatEmp2" runat="server" ControlToValidate="txtbxApePat" Display="None"
                                                                            ErrorMessage="Apellido paterno requerido" ValidationGroup="GrupoRFCCURP"></asp:RequiredFieldValidator><ajaxToolkit:AutoCompleteExtender
                                                                                BehaviorID="AutoCompleteAP" ID="ACEApellidosP" runat="server" MinimumPrefixLength="2"
                                                                                ServiceMethod="BuscarApellidos" ServicePath="~/WSBusquedas.asmx" TargetControlID="txtbxApePat"
                                                                                EnableCaching="true">
                                                                            </ajaxToolkit:AutoCompleteExtender>
                                                                    <ajaxToolkit:FilteredTextBoxExtender ID="FTBEApellidosP" runat="server" TargetControlID="txtbxApePat"
                                                                        ValidChars=" ñÑáÁéÉíÍóÓúÚ-." FilterType="Custom, UppercaseLetters, LowercaseLetters">
                                                                    </ajaxToolkit:FilteredTextBoxExtender>
                                                                </InsertItemTemplate>
                                                                <HeaderStyle Wrap="False" />
                                                                <ItemStyle Wrap="False" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Apellido materno">
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="txtbxApeMat" runat="server" Columns="40" MaxLength="30" SkinID="SkinTextBox"></asp:TextBox></EditItemTemplate>
                                                                <InsertItemTemplate>
                                                                    <asp:TextBox ID="txtbxApeMat" runat="server" Columns="40" MaxLength="30" SkinID="SkinTextBox"></asp:TextBox><ajaxToolkit:AutoCompleteExtender
                                                                        ID="ACEApellidosM" runat="server" MinimumPrefixLength="2" ServiceMethod="BuscarApellidos"
                                                                        ServicePath="~/WSBusquedas.asmx" TargetControlID="txtbxApeMat" EnableCaching="true">
                                                                    </ajaxToolkit:AutoCompleteExtender>
                                                                    <ajaxToolkit:FilteredTextBoxExtender ID="FTBEApellidosM" runat="server" FilterType="Custom, UppercaseLetters, LowercaseLetters"
                                                                        TargetControlID="txtbxApeMat" ValidChars=" ñÑáÁéÉíÍóÓúÚ-.">
                                                                    </ajaxToolkit:FilteredTextBoxExtender>
                                                                </InsertItemTemplate>
                                                                <HeaderStyle Wrap="False" />
                                                                <ItemStyle Wrap="False" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Nombre">
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="txtbxNombre" runat="server" Columns="40" MaxLength="30" SkinID="SkinTextBox"></asp:TextBox></EditItemTemplate>
                                                                <InsertItemTemplate>
                                                                    <asp:TextBox ID="txtbxNombre" runat="server" Columns="40" MaxLength="30" SkinID="SkinTextBox"></asp:TextBox><asp:RequiredFieldValidator
                                                                        ID="RFVNombre1" runat="server" ControlToValidate="txtbxNombre" Display="None"
                                                                        ErrorMessage="Nombre requerido" ValidationGroup="GrupoGuardar"></asp:RequiredFieldValidator><asp:RequiredFieldValidator
                                                                            ID="RFVNombre2" runat="server" ControlToValidate="txtbxNombre" Display="None"
                                                                            ErrorMessage="Nombre requerido" ValidationGroup="GrupoRFCCURP"></asp:RequiredFieldValidator><ajaxToolkit:AutoCompleteExtender
                                                                                ID="ACENombres" runat="server" MinimumPrefixLength="2" ServiceMethod="BuscarNombres"
                                                                                ServicePath="~/WSBusquedas.asmx" TargetControlID="txtbxNombre" EnableCaching="true">
                                                                            </ajaxToolkit:AutoCompleteExtender>
                                                                    <ajaxToolkit:FilteredTextBoxExtender ID="FTBENombres" runat="server" FilterType="Custom, UppercaseLetters, LowercaseLetters"
                                                                        TargetControlID="txtbxNombre" ValidChars=" ñÑáÁéÉíÍóÓúÚ-.">
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
                                                                    <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:DropDownList ID="ddlSexos" runat="server" SkinID="SkinDropDownList" AutoPostBack="True"
                                                                                OnSelectedIndexChanged="ddlSexos_SelectedIndexChanged">
                                                                            </asp:DropDownList>
                                                                            <asp:RequiredFieldValidator ID="RFVSexos" runat="server" ControlToValidate="ddlSexos"
                                                                                Display="None" ErrorMessage="Sexo requerido" InitialValue="3" ValidationGroup="GrupoRFCCURP"></asp:RequiredFieldValidator></ContentTemplate>
                                                                        <Triggers>
                                                                            <asp:AsyncPostBackTrigger ControlID="txtbxCURP" EventName="TextChanged" />
                                                                        </Triggers>
                                                                    </asp:UpdatePanel>
                                                                </InsertItemTemplate>
                                                                <ItemTemplate>
                                                                    &nbsp;</ItemTemplate>
                                                                <HeaderStyle Wrap="False" />
                                                                <ItemStyle Wrap="False" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Nacionalidad">
                                                                <EditItemTemplate>
                                                                    <asp:DropDownList ID="ddlNacionalidades" runat="server" SkinID="SkinDropDownList">
                                                                    </asp:DropDownList>
                                                                </EditItemTemplate>
                                                                <InsertItemTemplate>
                                                                    <asp:UpdatePanel ID="UPNacionalidades" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:DropDownList ID="ddlNacionalidades" runat="server" SkinID="SkinDropDownList">
                                                                            </asp:DropDownList>
                                                                            &#160;<asp:RequiredFieldValidator ID="RFVNacionalidades" runat="server" ValidationGroup="GrupoRFCCURP"
                                                                                ErrorMessage="Nacionalidad requerida" Display="None" ControlToValidate="ddlNacionalidades"
                                                                                InitialValue="99"></asp:RequiredFieldValidator></ContentTemplate>
                                                                        <Triggers>
                                                                            <asp:AsyncPostBackTrigger ControlID="ddlSexos" EventName="SelectedIndexChanged">
                                                                            </asp:AsyncPostBackTrigger>
                                                                            <asp:AsyncPostBackTrigger ControlID="txtbxCURP" EventName="TextChanged" />
                                                                        </Triggers>
                                                                    </asp:UpdatePanel>
                                                                </InsertItemTemplate>
                                                                <HeaderStyle Wrap="False" />
                                                                <ItemStyle Wrap="False" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Estado civ&#237;l">
                                                                <EditItemTemplate>
                                                                    <asp:DropDownList ID="ddlEstadosCiviles" runat="server" SkinID="SkinDropDownList">
                                                                    </asp:DropDownList>
                                                                </EditItemTemplate>
                                                                <InsertItemTemplate>
                                                                    <asp:UpdatePanel ID="UPEstadosCiviles" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:DropDownList ID="ddlEstadosCiviles" runat="server" SkinID="SkinDropDownList">
                                                                            </asp:DropDownList>
                                                                        </ContentTemplate>
                                                                        <Triggers>
                                                                            <asp:AsyncPostBackTrigger ControlID="ddlSexos" EventName="SelectedIndexChanged" />
                                                                            <asp:AsyncPostBackTrigger ControlID="txtbxCURP" EventName="TextChanged" />
                                                                        </Triggers>
                                                                    </asp:UpdatePanel>
                                                                </InsertItemTemplate>
                                                                <ItemTemplate>
                                                                    &nbsp;</ItemTemplate>
                                                                <HeaderStyle Wrap="False" />
                                                                <ItemStyle Wrap="False" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Estado natal">
                                                                <EditItemTemplate>
                                                                    <asp:DropDownList ID="ddlEstados" runat="server" SkinID="SkinDropDownList">
                                                                    </asp:DropDownList>
                                                                </EditItemTemplate>
                                                                <InsertItemTemplate>
                                                                    <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:DropDownList ID="ddlEstados" runat="server" SkinID="SkinDropDownList">
                                                                            </asp:DropDownList>
                                                                            <asp:RequiredFieldValidator ID="RFVEstados" runat="server" ControlToValidate="ddlEstados"
                                                                                Display="None" ErrorMessage="Estado natal requerido" InitialValue="99" ValidationGroup="GrupoRFCCURP"></asp:RequiredFieldValidator></ContentTemplate>
                                                                        <Triggers>
                                                                            <asp:AsyncPostBackTrigger ControlID="txtbxCURP" EventName="TextChanged" />
                                                                        </Triggers>
                                                                    </asp:UpdatePanel>
                                                                </InsertItemTemplate>
                                                                <HeaderStyle Wrap="False" />
                                                                <ItemStyle Wrap="False" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Fecha de nacimiento">
                                                                <InsertItemTemplate>
                                                                    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:TextBox ID="txtbxFecNac" runat="server" MaxLength="10" SkinID="SkinTextBox"
                                                                                Wrap="False"></asp:TextBox>&nbsp;
                                                                            <asp:ImageButton ID="ibFecNac" runat="server" CssClass="ibFechNac" ImageUrl="~/Imagenes/Fecha.png"
                                                                                CausesValidation="False" /><asp:RequiredFieldValidator ID="RFVFecNac1" runat="server"
                                                                                    ControlToValidate="txtbxFecNac" Display="None" ErrorMessage="Fecha de nacimiento requerida"
                                                                                    ValidationGroup="GrupoGuardar"></asp:RequiredFieldValidator><asp:RequiredFieldValidator
                                                                                        ID="RFVFecNac2" runat="server" ControlToValidate="txtbxFecNac" Display="None"
                                                                                        ErrorMessage="Fecha de nacimiento requerida" ValidationGroup="GrupoRFCCURP"></asp:RequiredFieldValidator><asp:CompareValidator
                                                                                            ID="CVFecNac1" runat="server" ControlToValidate="txtbxFecNac" Display="None"
                                                                                            ErrorMessage="Fecha no válida" Operator="DataTypeCheck" Type="Date" ValidationGroup="GrupoGuardar"></asp:CompareValidator><asp:CompareValidator
                                                                                                ID="CVFecNac2" runat="server" ControlToValidate="txtbxFecNac" Display="None"
                                                                                                ErrorMessage="Fecha no válida" Operator="DataTypeCheck" Type="Date" ValidationGroup="GrupoRFCCURP"></asp:CompareValidator><asp:HiddenField
                                                                                                    ID="hfFecNac" runat="server" />
                                                                        </ContentTemplate>
                                                                        <Triggers>
                                                                            <asp:AsyncPostBackTrigger ControlID="txtbxCURP" EventName="TextChanged" />
                                                                            <asp:AsyncPostBackTrigger ControlID="txtbxRFC" EventName="TextChanged" />
                                                                        </Triggers>
                                                                    </asp:UpdatePanel>
                                                                </InsertItemTemplate>
                                                                <HeaderStyle Wrap="False" />
                                                                <ItemStyle Wrap="False" />
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="txtbxFecNac" runat="server" MaxLength="10" SkinID="SkinTextBox"
                                                                        Wrap="False"></asp:TextBox><asp:ImageButton ID="ibFecNac" runat="server" CssClass="ibFechNac"
                                                                            ImageUrl="~/Imagenes/Fecha.png" /><asp:HiddenField ID="hfFecNac" runat="server" />
                                                                </EditItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="&#191;Es mam&#225;?">
                                                                <InsertItemTemplate>
                                                                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:DropDownList ID="ddlEsMama" runat="server" SkinID="SkinDropDownList">
                                                                                <asp:ListItem Value="0">S&#237;</asp:ListItem>
                                                                                <asp:ListItem Value="1">No</asp:ListItem>
                                                                                <asp:ListItem Value="2">No aplica</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </ContentTemplate>
                                                                        <Triggers>
                                                                            <asp:AsyncPostBackTrigger ControlID="ddlSexos" EventName="SelectedIndexChanged" />
                                                                            <asp:AsyncPostBackTrigger ControlID="txtbxCURP" EventName="TextChanged" />
                                                                        </Triggers>
                                                                    </asp:UpdatePanel>
                                                                </InsertItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Correo electrónico">
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="txtbxEmail" runat="server" Columns="70" MaxLength="100" SkinID="SkinTextBox" ValidationGroup="GrupoGuardar"></asp:TextBox></EditItemTemplate>
                                                                <InsertItemTemplate>
                                                                    <asp:UpdatePanel ID="UPEmail" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:TextBox ID="txtbxEmail" runat="server" Columns="70" MaxLength="100" SkinID="SkinTextBox"></asp:TextBox><ajaxToolkit:TextBoxWatermarkExtender
                                                                                ID="txtbxEmail_TBWatMarkExt" runat="server" Enabled="True" TargetControlID="txtbxEmail"
                                                                                WatermarkCssClass="WaterMark" WatermarkText="Ejemplo: correo@outlook.com">
                                                                            </ajaxToolkit:TextBoxWatermarkExtender>
                                                                            <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtbxEmail"
                                                                                Display="None" ErrorMessage="Correo electrónico incorrecto." ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                                                ValidationGroup="GrupoGuardar"></asp:RegularExpressionValidator>
                                                                            <asp:RequiredFieldValidator
                                                                                    ID="rfvEmail" runat="server" ControlToValidate="txtbxEmail" 
                                                                                Display="None" ErrorMessage="El correo electrónico es necesario."
                                                                                    ValidationGroup="GrupoGuardar"></asp:RequiredFieldValidator></ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </InsertItemTemplate>
                                                                <HeaderStyle Wrap="False" />
                                                                <ItemStyle Wrap="False" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ShowHeader="False">
                                                                <InsertItemTemplate>
                                                                    <asp:Label ID="Label3" runat="server" SkinID="SkinLblHeader" Text="Datos laborales"></asp:Label></InsertItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="N&#250;mero de empleado">
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="txtbxNumEmp" runat="server" Columns="10" MaxLength="5" SkinID="SkinTextBox"></asp:TextBox></EditItemTemplate>
                                                                <InsertItemTemplate>
                                                                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:TextBox ID="txtbxNumEmp" runat="server" Columns="10" MaxLength="5" SkinID="SkinTextBox"
                                                                                CausesValidation="True" ValidationGroup="GrupoGuardar"></asp:TextBox><asp:Button
                                                                                    ID="btnNumEmp" OnClick="btnNumEmp_Click" runat="server" SkinID="SkinBoton" Text="Actualizar"
                                                                                    Enabled="False" Visible="False"></asp:Button><asp:CompareValidator ID="CVNumEmp"
                                                                                        runat="server" ControlToValidate="txtbxNumEmp" Display="None" ErrorMessage="Número de empleado no válido."
                                                                                        Operator="DataTypeCheck" Type="Integer" ValidationGroup="GrupoGuardar"></asp:CompareValidator><asp:HiddenField
                                                                                            ID="hfNumEmp" runat="server"></asp:HiddenField>
                                                                        </ContentTemplate>
                                                                        <Triggers>
                                                                            <asp:AsyncPostBackTrigger ControlID="btnNumEmp" EventName="Click"></asp:AsyncPostBackTrigger>
                                                                        </Triggers>
                                                                    </asp:UpdatePanel>
                                                                </InsertItemTemplate>
                                                                <HeaderStyle Wrap="False" />
                                                                <ItemStyle Wrap="False" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Plantel para pago">
                                                                <InsertItemTemplate>
                                                                    <asp:DropDownList ID="ddlPlantelesParaPago" runat="server" SkinID="SkinDropDownList">
                                                                    </asp:DropDownList>
                                                                </InsertItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ShowHeader="False">
                                                                <EditItemTemplate>
                                                                    <ajaxToolkit:ConfirmButtonExtender ID="CBE" runat="server" ConfirmText="¿Está seguro de guardar los cambios realizados?"
                                                                        TargetControlID="btnGuardar">
                                                                    </ajaxToolkit:ConfirmButtonExtender>
                                                                    <asp:Button ID="btnGuardar" runat="server" SkinID="SkinBoton" Text="Guardar" ToolTip="Guardar información del nuevo empleado" /></EditItemTemplate>
                                                                <HeaderStyle Wrap="False" />
                                                                <ItemStyle HorizontalAlign="Right" Wrap="False" />
                                                                <InsertItemTemplate>
                                                                    <ajaxToolkit:ConfirmButtonExtender ID="CBE" runat="server" ConfirmText="¿Está seguro de guardar los cambios realizados?"
                                                                        TargetControlID="btnGuardar">
                                                                    </ajaxToolkit:ConfirmButtonExtender>
                                                                    <asp:Button ID="btnGeneraRFC" runat="server" OnClick="btnGeneraRFC_Click" SkinID="SkinBoton"
                                                                        Text="RFC, CURP" ToolTip="Genera RFC y CURP" Width="80px" ValidationGroup="GrupoRFCCURP"
                                                                        Enabled="false" /><asp:Button ID="btnGuardar" runat="server" SkinID="SkinBoton" Text="Guardar"
                                                                            ToolTip="Guardar información del empleado" OnClick="btnGuardar_Click" Width="80px"
                                                                            ValidationGroup="GrupoGuardar" /><asp:ValidationSummary ID="VSGrupoRFCCURP" runat="server"
                                                                                ShowMessageBox="True" ShowSummary="False" ValidationGroup="GrupoRFCCURP" />
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
            <table style="width: 100%" align="center">
                <tr>
                    <td style="vertical-align: middle; width: 0%; text-align: left">
                        <asp:Image ID="Image2" runat="server" ImageUrl="~/Imagenes/Symbol-Check.png" Width="100px" />
                    </td>
                    <td style="vertical-align: middle; text-align: left">
                        <asp:Label ID="lblCapturaExitosa" runat="server" SkinID="SkinLblMsjExito" Text="Captura realizada exitosamente"></asp:Label><br />
                        <br />
                        <asp:LinkButton ID="lbVerDatosPersonales" runat="server" PostBackUrl="~/Consultas/Empleados/DatosPersonales.aspx"
                            SkinID="SkinLinkButton">Ver datos capturados</asp:LinkButton>
                    </td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="viewErrores" runat="server">
            <table style="width: 100%" align="center">
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
