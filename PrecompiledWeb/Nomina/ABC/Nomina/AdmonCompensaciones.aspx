<%@ page language="VB" masterpagefile="~/MasterPageBlanca.master" autoeventwireup="false" inherits="ABC_Nomina_AdmonCompensaciones, App_Web_sogedhgo" title="COBAEV - Nómina - Administración de compensaciones" stylesheettheme="SkinFile" maintainScrollPositionOnPostBack="true" %>

<%@ Register Src="../../WebControls/wucSearchEmps.ascx" TagName="wucBuscaEmpleados"
    TagPrefix="uc1" %>
<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress"
    TagPrefix="TP_wucUpdateProgress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
    <div id="divMain" style="text-align: center;">
        <table style="width: 100%; vertical-align: top; text-align: center; height: 300px;">
            <tr>
                <td style="vertical-align: top; text-align: right">
                    <h2>
                        Sistema de nómina: Administración de compensaciones por empleado
                    </h2>
                </td>
            </tr>
            <tr>
                <td style="vertical-align: top; width: 100%; height: 100%; text-align: left">
                    <table style="width: 100%; vertical-align: top; text-align: center;">
                        <tr>
                            <td style="text-align: left; vertical-align: top;">
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                        <uc1:wucBuscaEmpleados ID="WucBuscaEmpleados1" runat="server" />
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="dvDatosNuevaCompe" EventName="ItemCommand" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td style="vertical-align: top; text-align: left;">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <asp:DetailsView ID="dvDatosNuevaCompe" runat="server" AutoGenerateRows="False" EmptyDataText="Sin datos para nueva compensación."
                                            SkinID="SkinDetailsView" Width="400px" OnDataBound="dvDatosNuevaCompe_DataBound"
                                            HeaderText="Nueva compensación" Height="1px">
                                            <Fields>
                                                <asp:TemplateField HeaderText="IdEmp" Visible="False">
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblIdEmp_EI" runat="server" Text='<%# Bind("IdEmp") %>'></asp:Label>
                                                    </EditItemTemplate>
                                                    <InsertItemTemplate>
                                                        <asp:Label ID="lblIdEmp_II" runat="server" Text='<%# Bind("IdEmp") %>'></asp:Label>
                                                    </InsertItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblIdEmp_RO" runat="server" Text='<%# Bind("IdEmp") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Width="150px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Nombre" Visible="False">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtbxNombre_EI" runat="server" Columns="30" MaxLength="30" SkinID="SkinTextBox"
                                                            Text='<%# Bind("Nombre") %>' ReadOnly="True"></asp:TextBox><asp:RequiredFieldValidator
                                                                ID="RFVNombre" runat="server" ControlToValidate="txtbxNombre_EI" Display="None"
                                                                ErrorMessage="Nombre requerido." Enabled="False"></asp:RequiredFieldValidator>
                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FTBENombre" runat="server" ValidChars=" ñÑáÁéÉíÍóÓúÚ"
                                                            FilterType="Custom, UppercaseLetters, LowercaseLetters" TargetControlID="txtbxNombre_EI">
                                                        </ajaxToolkit:FilteredTextBoxExtender>
                                                        <ajaxToolkit:AutoCompleteExtender ID="ACENombre" runat="server" EnableCaching="true"
                                                            MinimumPrefixLength="2" ServiceMethod="BuscarNombres" ServicePath="~/WSBusquedas.asmx"
                                                            TargetControlID="txtbxNombre_EI" FirstRowSelected="True">
                                                        </ajaxToolkit:AutoCompleteExtender>
                                                    </EditItemTemplate>
                                                    <InsertItemTemplate>
                                                        <asp:TextBox ID="txtbxNombre_II" runat="server" Columns="30" SkinID="SkinTextBox"
                                                            Text='<%# Bind("Nombre") %>'></asp:TextBox>
                                                    </InsertItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblNombre_RO" runat="server" SkinID="SkinLblNormal" Text='<%# Bind("Nombre") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Apellido paterno" Visible="False">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtbxApePat_EI" runat="server" Columns="30" MaxLength="30" SkinID="SkinTextBox"
                                                            Text='<%# Bind("ApePat") %>' ReadOnly="True"></asp:TextBox><asp:RequiredFieldValidator
                                                                ID="RFVApePat" runat="server" ControlToValidate="txtbxApePat_EI" Display="None"
                                                                ErrorMessage="Apellido paterno requerido." Enabled="False"></asp:RequiredFieldValidator><ajaxToolkit:FilteredTextBoxExtender
                                                                    ID="FTBEApePat" runat="server" ValidChars=" ñÑáÁéÉíÍóÓúÚ" FilterType="Custom, UppercaseLetters, LowercaseLetters"
                                                                    TargetControlID="txtbxApePat_EI">
                                                                </ajaxToolkit:FilteredTextBoxExtender>
                                                        <ajaxToolkit:AutoCompleteExtender ID="ACEApePat" runat="server" BehaviorID="AutoCompleteAP"
                                                            EnableCaching="true" MinimumPrefixLength="2" ServiceMethod="BuscarApellidos"
                                                            ServicePath="~/WSBusquedas.asmx" TargetControlID="txtbxApePat_EI" FirstRowSelected="True">
                                                        </ajaxToolkit:AutoCompleteExtender>
                                                    </EditItemTemplate>
                                                    <InsertItemTemplate>
                                                        <asp:TextBox ID="txtbxApePat_II" runat="server" Columns="30" MaxLength="30" SkinID="SkinTextBox"
                                                            Text='<%# Bind("ApePat") %>'></asp:TextBox>
                                                    </InsertItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblApePat" runat="server" SkinID="SkinLblNormal" Text='<%# Bind("ApePat") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Apellido materno" Visible="False">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtbxApeMat_EI" runat="server" Columns="30" MaxLength="30" SkinID="SkinTextBox"
                                                            Text='<%# Bind("ApeMat") %>' ReadOnly="True"></asp:TextBox>
                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FTBEApeMat" runat="server" ValidChars=" ñÑáÁéÉíÍóÓúÚ"
                                                            FilterType="Custom, UppercaseLetters, LowercaseLetters" TargetControlID="txtbxApeMat_EI">
                                                        </ajaxToolkit:FilteredTextBoxExtender>
                                                        <ajaxToolkit:AutoCompleteExtender ID="ACEApeMat" runat="server" EnableCaching="true"
                                                            FirstRowSelected="True" MinimumPrefixLength="2" ServiceMethod="BuscarApellidos"
                                                            ServicePath="~/WSBusquedas.asmx" TargetControlID="txtbxApeMat_EI">
                                                        </ajaxToolkit:AutoCompleteExtender>
                                                    </EditItemTemplate>
                                                    <InsertItemTemplate>
                                                        <asp:TextBox ID="txtbxApeMat_II" runat="server" Columns="30" MaxLength="30" SkinID="SkinTextBox"
                                                            Text='<%# Bind("ApeMat") %>'></asp:TextBox>
                                                    </InsertItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblApeMat_RO" runat="server" SkinID="SkinLblNormal" Text='<%# Bind("ApeMat") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Origen" Visible="False">
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblOrigen_EI" runat="server" Text='<%# Bind("Origen") %>'></asp:Label>
                                                    </EditItemTemplate>
                                                    <InsertItemTemplate>
                                                        <asp:TextBox ID="tbOrigen_I" runat="server" MaxLength="30" SkinID="SkinTextBox" Text='<%# Bind("Origen") %>'></asp:TextBox>
                                                    </InsertItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblOrigen_RO" runat="server" Text='<%# Bind("Origen") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Importe a pagar">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="tbImporte_E" runat="server" MaxLength="10" SkinID="SkinTextBox"
                                                            Text='<%# Bind("Importe") %>'></asp:TextBox>
                                                        <asp:CompareValidator ID="CVImporte" runat="server" ControlToValidate="tbImporte_E"
                                                            Display="None" ErrorMessage="Importe incorrecto." Operator="DataTypeCheck" Type="Currency"></asp:CompareValidator><asp:RequiredFieldValidator
                                                                ID="RFVImporte" runat="server" ControlToValidate="tbImporte_E" Display="None"
                                                                ErrorMessage="Importe requerido."></asp:RequiredFieldValidator>
                                                    </EditItemTemplate>
                                                    <InsertItemTemplate>
                                                        <asp:TextBox ID="tbImporte_I" runat="server" MaxLength="10" SkinID="SkinTextBox"
                                                            Text='<%# Bind("Importe", "{0:c}") %>'></asp:TextBox>
                                                    </InsertItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblImporte_RO" runat="server" Text='<%# Bind("Importe", "{0:c}") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Left" Width="200px" Wrap="False" />
                                                    <ItemStyle Width="200px" Wrap="False" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Mes de pago">
                                                    <EditItemTemplate>
                                                        <asp:Label ID="LblNombreMes_EI" runat="server" SkinID="SkinLblNormal" Text='<%# Eval("NombreMes") %>'></asp:Label>
                                                    </EditItemTemplate>
                                                    <InsertItemTemplate>
                                                        <asp:Label ID="LblNombreMes_II" runat="server" SkinID="SkinLblNormal" Text='<%# Eval("NombreMes") %>'></asp:Label>
                                                    </InsertItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="LblNombreMes_RO" runat="server" SkinID="SkinLblNormal" Text='<%# Bind("NombreMes") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Left" Wrap="False" />
                                                    <ItemStyle Wrap="False" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="A&#241;o de pago">
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblAnio_EI" runat="server" SkinID="SkinLblNormal" Text='<%# Eval("Anio") %>'></asp:Label>
                                                    </EditItemTemplate>
                                                    <InsertItemTemplate>
                                                        <asp:Label ID="lblAnio_II" runat="server" SkinID="SkinLblNormal" Text='<%# Eval("Anio") %>'></asp:Label>
                                                    </InsertItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAnio_RO" runat="server" SkinID="SkinLblNormal" Text='<%# Bind("Anio") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Left" Wrap="False" />
                                                    <ItemStyle Wrap="False" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Adicional">
                                                    <EditItemTemplate>
                                                        <asp:Label ID="LblAdicional_EI" runat="server" Text='<%# Bind("Adicional") %>'></asp:Label>
                                                    </EditItemTemplate>
                                                    <InsertItemTemplate>
                                                        <asp:Label ID="LblAdicional_II" runat="server" Text='<%# Bind("Adicional") %>'></asp:Label>
                                                    </InsertItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="LblAdicional_RO" runat="server" Text='<%# Bind("Adicional") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Pagar con cheque">
                                                    <EditItemTemplate>
                                                        <asp:CheckBox ID="ChBxPagarConCheque_EI" runat="server" Checked='<%# Bind("PagarConCheque") %>'
                                                            SkinID="SkinCheckBox" AutoPostBack="True" OnCheckedChanged="ChBxPagarConCheque_EI_CheckedChanged" />
                                                    </EditItemTemplate>
                                                    <InsertItemTemplate>
                                                        <asp:CheckBox ID="ChBxPagarConCheque_II" runat="server" Checked='<%# Bind("PagarConCheque") %>'
                                                            SkinID="SkinCheckBox" />
                                                    </InsertItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="ChBxPagarConCheque_RO" runat="server" Checked='<%# Bind("PagarConCheque") %>'
                                                            Enabled="False" SkinID="SkinCheckBox" />
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Left" Wrap="False" />
                                                    <ItemStyle Wrap="False" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Clave de cobro">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="tbClaveCobro_EI" runat="server" MaxLength="8" SkinID="SkinTextBox"
                                                            Text='<%# Bind("ClaveCobro") %>'></asp:TextBox><asp:CompareValidator ID="CVClaveCobro"
                                                                runat="server" ControlToValidate="tbClaveCobro_EI" Display="None" ErrorMessage="Clave de cobro incorrecta."
                                                                Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator><asp:RequiredFieldValidator
                                                                    ID="RFVClaveCobro" runat="server" ControlToValidate="tbClaveCobro_EI" Display="None"
                                                                    ErrorMessage="Clave de cobro requerida."></asp:RequiredFieldValidator><asp:RegularExpressionValidator
                                                                        ID="REVClaveCobro" runat="server" ControlToValidate="tbClaveCobro_EI" Display="None"
                                                                        ErrorMessage="Longitud de clave de cobro incorrecta." ValidationExpression="\d{8}"></asp:RegularExpressionValidator>
                                                    </EditItemTemplate>
                                                    <InsertItemTemplate>
                                                        <asp:TextBox ID="tbClaveCobro_II" runat="server" SkinID="SkinTextBox" Text='<%# Bind("ClaveCobro") %>'></asp:TextBox>
                                                    </InsertItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblClaveCobro_RO" runat="server" SkinID="SkinLblNormal" Text='<%# Bind("ClaveCobro") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Left" Wrap="False" />
                                                    <ItemStyle Wrap="False" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Banco">
                                                    <EditItemTemplate>
                                                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                            <ContentTemplate>
                                                                <asp:Label ID="lblIdBanco_EI" runat="server" Text='<%# Bind("IdBanco") %>' Visible="False"></asp:Label><asp:DropDownList
                                                                    ID="ddlBancos_EI" runat="server" SkinID="SkinDropDownList">
                                                                </asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="RFVBanco" runat="server" ControlToValidate="ddlBancos_EI"
                                                                    Display="None" Enabled="False" ErrorMessage="Banco requerido." InitialValue="3"></asp:RequiredFieldValidator>
                                                            </ContentTemplate>
                                                            <Triggers>
                                                                <asp:AsyncPostBackTrigger ControlID="ChBxPagarConCheque_EI" EventName="CheckedChanged" />
                                                            </Triggers>
                                                        </asp:UpdatePanel>
                                                    </EditItemTemplate>
                                                    <InsertItemTemplate>
                                                        <asp:Label ID="lblIdBanco_II" runat="server" Text='<%# Bind("IdBanco") %>'></asp:Label><asp:DropDownList
                                                            ID="ddlBancos_II" runat="server" SkinID="SkinDropDownList">
                                                        </asp:DropDownList>
                                                    </InsertItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblNombreBanco_RO" runat="server" Text='<%# Bind("NombreCortoBanco") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Left" Wrap="False" />
                                                    <ItemStyle Wrap="False" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Cuenta bancaria">
                                                    <EditItemTemplate>
                                                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                            <ContentTemplate>
                                                                <asp:TextBox ID="tbCuentaBancaria_EI" runat="server" MaxLength="18" SkinID="SkinTextBox"
                                                                    Text='<%# Bind("CuentaBancaria") %>'></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RFVCuentaBancaria" runat="server" ControlToValidate="tbCuentaBancaria_EI"
                                                                    Display="None" Enabled="False" ErrorMessage="Cuenta bancaria requerida."></asp:RequiredFieldValidator>
                                                                <asp:CompareValidator ID="CVCuentaBancaria" runat="server" ControlToValidate="tbCuentaBancaria_EI"
                                                                    Display="None" ErrorMessage="Cuenta bancaria incorrecta." Operator="DataTypeCheck"
                                                                    Type="Integer"></asp:CompareValidator>
                                                                <ajaxToolkit:FilteredTextBoxExtender ID="FTBEtbCuentaBancaria_EI" runat="server"
                                                                    FilterType="Numbers" TargetControlID="tbCuentaBancaria_EI">
                                                                </ajaxToolkit:FilteredTextBoxExtender>
                                                            </ContentTemplate>
                                                            <Triggers>
                                                                <asp:AsyncPostBackTrigger ControlID="ChBxPagarConCheque_EI" EventName="CheckedChanged" />
                                                            </Triggers>
                                                        </asp:UpdatePanel>
                                                    </EditItemTemplate>
                                                    <InsertItemTemplate>
                                                        <asp:TextBox ID="tbCuentaBancaria_II" runat="server" SkinID="SkinTextBox" 
                                                            Text='<%# Bind("CuentaBancaria") %>' MaxLength="18"></asp:TextBox>
                                                    </InsertItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCuentaBancaria_RO" runat="server" Text='<%# Bind("CuentaBancaria") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Wrap="False" />
                                                    <ItemStyle Wrap="False" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Observaciones" Visible="False">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtbxObservaciones_EI" runat="server" Columns="100" MaxLength="100"
                                                            Rows="2" SkinID="SkinTextBox" Text='<%# Bind("Observaciones") %>' TextMode="MultiLine"></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <InsertItemTemplate>
                                                        <asp:TextBox ID="txtbxObservaciones_II" runat="server" Columns="100" MaxLength="100"
                                                            Rows="2" SkinID="SkinTextBox" Text='<%# Bind("Observaciones") %>' TextMode="MultiLine"></asp:TextBox>
                                                    </InsertItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblObservaciones_RO" runat="server" SkinID="SkinLblNormal" Text='<%# Bind("Observaciones") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Meses amparados con el pago">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtbxMesesQueAmparaPago_EI" runat="server" MaxLength="1" SkinID="SkinTextBox"
                                                            Text='<%# Bind("MesesQueAmparaPago") %>' Width="50px"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RFVtxtbxMesesQueAmparaPago" runat="server" ControlToValidate="txtbxMesesQueAmparaPago_EI"
                                                            Display="None" ErrorMessage="Meses que ampara el pago requerido."></asp:RequiredFieldValidator>
                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FTBEtxtbxMesesQueAmparaPago_EI" runat="server"
                                                            FilterType="Numbers" TargetControlID="txtbxMesesQueAmparaPago_EI">
                                                        </ajaxToolkit:FilteredTextBoxExtender>
                                                    </EditItemTemplate>
                                                    <InsertItemTemplate>
                                                        <asp:TextBox ID="txtbxMesesQueAmparaPago_II" runat="server" MaxLength="1" SkinID="SkinTextBox"
                                                            Text='<%# Bind("MesesQueAmparaPago") %>' Width="50px"></asp:TextBox>
                                                    </InsertItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblMesesQueAmparaPago_RO" runat="server" Text='<%# Bind("MesesQueAmparaPago") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Wrap="False" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="N&#250;mero de empleado oficial">
                                                    <EditItemTemplate>
                                                        <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
                                                            <ContentTemplate>
                                                                <asp:TextBox ID="txtbxNumEmpOficial_EI" runat="server" MaxLength="5" SkinID="SkinTextBox"
                                                                    Text='<%# Bind("NumEmpOficial") %>'></asp:TextBox>
                                                                <asp:Button ID="btnValidarNumEmpOficial" runat="server" SkinID="SkinBoton" Text="Validar"
                                                                    OnClick="btnValidarNumEmpOficial_Click" />
                                                                <asp:Label ID="lblNomEmpOficial" runat="server" SkinID="SkinLblMsjExito"></asp:Label>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </EditItemTemplate>
                                                    <InsertItemTemplate>
                                                        <asp:TextBox ID="txtbxNumEmpOficial_II" runat="server" MaxLength="5" SkinID="SkinTextBox"
                                                            Text='<%# Bind("NumEmpOficial") %>'></asp:TextBox>
                                                    </InsertItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblNumEmpOficial_RO" runat="server" Text='<%# Bind("NumEmpOficial") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Wrap="False" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="N&#250;mero de empleado al que se afecta">
                                                    <EditItemTemplate>
                                                        <asp:UpdatePanel ID="UpdatePanel6" runat="server" UpdateMode="Conditional">
                                                            <ContentTemplate>
                                                                <asp:TextBox ID="txtbxNumEmpAfectado_EI" runat="server" MaxLength="5" SkinID="SkinTextBox"
                                                                    Text='<%# Bind("NumEmpAfectado") %>'></asp:TextBox>
                                                                <asp:Button ID="btnValidarNumEmpAfectado" runat="server" SkinID="SkinBoton" Text="Validar"
                                                                    OnClick="btnValidarNumEmpAfectado_Click" />
                                                                <asp:Label ID="lblNomEmpAfectado" runat="server" SkinID="SkinLblMsjExito"></asp:Label>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </EditItemTemplate>
                                                    <InsertItemTemplate>
                                                        <asp:TextBox ID="txtbxNumEmpAfectado_II" runat="server" MaxLength="5" SkinID="SkinTextBox"
                                                            Text='<%# Bind("NumEmpAfectado") %>'></asp:TextBox>
                                                    </InsertItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblNumEmpAfectado_RO" runat="server" Text='<%# Bind("NumEmpAfectado") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Wrap="False" />
                                                </asp:TemplateField>
                                                <asp:TemplateField ShowHeader="False">
                                                    <EditItemTemplate>
                                                        <asp:Button ID="btnGuardar" runat="server" CommandName="Update" OnClick="btnGuardar_Click"
                                                            SkinID="SkinBoton" Text="Guardar" />&nbsp;<asp:Button ID="btnCancelar" runat="server"
                                                                CausesValidation="False" CommandName="Cancel" OnClick="btnCancelar_Click" SkinID="SkinBoton"
                                                                Text="Cancelar" /><ajaxToolkit:ConfirmButtonExtender ID="CBEGuardar" runat="server"
                                                                    ConfirmText="Esta operación guardará los cambios realizados en la Base de datos, ¿Continuar?"
                                                                    TargetControlID="btnGuardar">
                                                                </ajaxToolkit:ConfirmButtonExtender>
                                                        <ajaxToolkit:ConfirmButtonExtender ID="CBECancelar" runat="server" ConfirmText="Esta operación cancelará los cambios realizados, ¿Continuar?"
                                                            TargetControlID="btnCancelar">
                                                        </ajaxToolkit:ConfirmButtonExtender>
                                                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                                                            ShowSummary="False" />
                                                        <asp:UpdateProgress ID="UP1" runat="server" AssociatedUpdatePanelID="UpdatePanel1"
                                                            DisplayAfter="0" Visible="True">
                                                            <ProgressTemplate>
                                                                <table>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Image ID="ImgUP1" runat="server" ImageUrl="~/Imagenes/Spinner2.gif" />
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lblUP1" runat="server" SkinID="SkinLblMsjExito" Text="Actualizando, por favor espere..."></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </ProgressTemplate>
                                                        </asp:UpdateProgress>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Button ID="btnModificar" runat="server" CausesValidation="False" CommandName="Edit"
                                                            OnClick="btnModificar_Click" SkinID="SkinBoton" Text="Modificar" />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" Wrap="True" />
                                                </asp:TemplateField>
                                            </Fields>
                                            <HeaderStyle Font-Names="Verdana" Font-Size="X-Small" HorizontalAlign="Center" />
                                        </asp:DetailsView>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="WucBuscaEmpleados1" EventName="PreRender" />
                                        <asp:AsyncPostBackTrigger ControlID="dvDatosNuevaCompe" EventName="ItemCommand" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td style="vertical-align: top; text-align: left">
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
