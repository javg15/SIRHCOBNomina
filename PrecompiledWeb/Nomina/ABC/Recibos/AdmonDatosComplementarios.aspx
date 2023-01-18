<%@ page language="VB" masterpagefile="~/MasterPageBlanca.master" autoeventwireup="false" inherits="ABC_Recibos_AdmonDatosComplementarios, App_Web_5lgpnrst" title="COBAEV - Nómina - Administrar datos complementarios del recibo" stylesheettheme="SkinFile" maintainScrollPositionOnPostBack="true" %>

<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress"
    TagPrefix="TP_wucUpdateProgress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
    <div>
        <table style="width: 100%; height: 100%">
            <tr>
                <td style="vertical-align: top; text-align: right">
                    <h2>
                        Recibos de pago fuera de nómina <br />
                        Datos complementarios (Indemnizaciones)
                    </h2>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:MultiView ID="MultiView1" runat="server">
                        <asp:View ID="viewEditar" runat="server">
                            <asp:DetailsView ID="dvDatosComplemen" runat="server" AutoGenerateRows="False" CellPadding="1"
                                DefaultMode="Edit" SkinID="SkinDetailsView">
                                <Fields>
                                    <asp:TemplateField HeaderText="A&#241;os de servicio">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="tbAniosDeServicio_E" runat="server" MaxLength="5" SkinID="SkinTextBox"
                                                Text='<%# Bind("AniosDeServicio") %>' Width="50px"></asp:TextBox><asp:RequiredFieldValidator
                                                    ID="RFVtbAniosDeServicio_E" runat="server" ControlToValidate="tbAniosDeServicio_E"
                                                    Display="None" ErrorMessage="Años de servicio requeridos."></asp:RequiredFieldValidator>
                                            <asp:CompareValidator ID="CVtbAniosDeServicio_E" runat="server" ControlToValidate="tbAniosDeServicio_E"
                                                Display="None" ErrorMessage="Años de servicio incorrectos." Operator="DataTypeCheck"
                                                Type="Double"></asp:CompareValidator>
                                            <asp:CompareValidator ID="CV2tbAniosDeServicio_E" runat="server" ControlToValidate="tbAniosDeServicio_E"
                                                Display="None" ErrorMessage="Años de servicio debe ser mayor o igual a cero."
                                                Operator="GreaterThanEqual" Type="Double" ValueToCompare="0"></asp:CompareValidator>
                                        </EditItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" Wrap="False" />
                                        <ItemStyle HorizontalAlign="Left" />
                                        <InsertItemTemplate>
                                            <asp:TextBox ID="tbAniosDeServicio_I" runat="server" MaxLength="5" SkinID="SkinTextBox"
                                                Width="50px">0</asp:TextBox><asp:RequiredFieldValidator ID="RFVtbAniosDeServicio_I"
                                                    runat="server" ControlToValidate="tbAniosDeServicio_I" Display="None" ErrorMessage="Años de servicio requeridos."></asp:RequiredFieldValidator><asp:CompareValidator
                                                        ID="CVtbAniosDeServicio_I" runat="server" ControlToValidate="tbAniosDeServicio_I"
                                                        Display="None" ErrorMessage="Años de servicio incorrectos." Operator="DataTypeCheck"
                                                        Type="Double"></asp:CompareValidator><asp:CompareValidator ID="CV2tbAniosDeServicio_I"
                                                            runat="server" ControlToValidate="tbAniosDeServicio_I" Display="None" ErrorMessage="Años de servicio debe ser mayor o igual a cero."
                                                            Operator="GreaterThanEqual" Type="Double" ValueToCompare="0"></asp:CompareValidator>
                                        </InsertItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Ingreso exento">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="tbIngresoExcento_E" runat="server" MaxLength="10" SkinID="SkinTextBox"
                                                Text='<%# Bind("IngresoExcento") %>' Width="120px"></asp:TextBox><asp:RequiredFieldValidator
                                                    ID="RFVtbIngresoExcento_E" runat="server" ControlToValidate="tbIngresoExcento_E"
                                                    Display="None" ErrorMessage="Ingreso exento requerido."></asp:RequiredFieldValidator><asp:CompareValidator
                                                        ID="CVtbIngresoExcento_E" runat="server" ControlToValidate="tbIngresoExcento_E"
                                                        Display="None" ErrorMessage="Ingreso exento incorrecto." Operator="DataTypeCheck"
                                                        Type="Currency"></asp:CompareValidator><asp:CompareValidator ID="CV2tbIngresoExcento_E"
                                                            runat="server" ControlToValidate="tbIngresoExcento_E" Display="None" ErrorMessage="Ingreso exento debe ser mayor o igual a cero."
                                                            Operator="GreaterThanEqual" Type="Currency" ValueToCompare="0"></asp:CompareValidator>
                                        </EditItemTemplate>
                                        <InsertItemTemplate>
                                            <asp:TextBox ID="tbIngresoExcento_I" runat="server" MaxLength="10" SkinID="SkinTextBox"
                                                Text="0" Width="120px"></asp:TextBox><asp:RequiredFieldValidator ID="RFVtbIngresoExcento_I"
                                                    runat="server" ControlToValidate="tbIngresoExcento_I" Display="None" ErrorMessage="Ingreso exento requerido."></asp:RequiredFieldValidator><asp:CompareValidator
                                                        ID="CVtbIngresoExcento_I" runat="server" ControlToValidate="tbIngresoExcento_I"
                                                        Display="None" ErrorMessage="Ingreso exento incorrecto." Operator="DataTypeCheck"
                                                        Type="Currency"></asp:CompareValidator><asp:CompareValidator ID="CV2tbIngresoExcento_I"
                                                            runat="server" ControlToValidate="tbIngresoExcento_I" Display="None" ErrorMessage="Ingreso exento debe ser mayor o igual a cero."
                                                            Operator="GreaterThanEqual" Type="Currency" ValueToCompare="0"></asp:CompareValidator>
                                        </InsertItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#218;ltimo sueldo">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="tbUltimoSueldo_E" runat="server" MaxLength="10" SkinID="SkinTextBox"
                                                Text='<%# Bind("UltimoSueldo") %>' Width="120px"></asp:TextBox><asp:RequiredFieldValidator
                                                    ID="RFVtbUltimoSueldo_E" runat="server" ControlToValidate="tbUltimoSueldo_E"
                                                    Display="None" ErrorMessage="Ultimo sueldo requerido."></asp:RequiredFieldValidator><asp:CompareValidator
                                                        ID="CVtbUltimoSueldo_E" runat="server" ControlToValidate="tbUltimoSueldo_E" Display="None"
                                                        ErrorMessage="Ultimo sueldo incorrecto." Operator="DataTypeCheck" Type="Currency"></asp:CompareValidator><asp:CompareValidator
                                                            ID="CV2tbUltimoSueldo_E" runat="server" ControlToValidate="tbUltimoSueldo_E"
                                                            Display="None" ErrorMessage="Ultimo sueldo debe ser mayor o igual a cero." Operator="GreaterThanEqual"
                                                            Type="Currency" ValueToCompare="0"></asp:CompareValidator>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            &nbsp;
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" Wrap="False" />
                                        <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                        <InsertItemTemplate>
                                            <asp:TextBox ID="tbUltimoSueldo_I" runat="server" MaxLength="10" SkinID="SkinTextBox"
                                                Text="0" Width="120px"></asp:TextBox><asp:RequiredFieldValidator ID="RFVtbUltimoSueldo_I"
                                                    runat="server" ControlToValidate="tbUltimoSueldo_I" Display="None" ErrorMessage="Ultimo sueldo requerido."></asp:RequiredFieldValidator><asp:CompareValidator
                                                        ID="CVtbUltimoSueldo_I" runat="server" ControlToValidate="tbUltimoSueldo_I" Display="None"
                                                        ErrorMessage="Ultimo sueldo incorrecto." Operator="DataTypeCheck" Type="Currency"></asp:CompareValidator><asp:CompareValidator
                                                            ID="CV2tbUltimoSueldo_I" runat="server" ControlToValidate="tbUltimoSueldo_I"
                                                            Display="None" ErrorMessage="Ultimo sueldo debe ser mayor o igual a cero." Operator="GreaterThanEqual"
                                                            Type="Currency" ValueToCompare="0"></asp:CompareValidator>
                                        </InsertItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="I.S.R. &#250;ltimo sueldo">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="tbISRUltimoSueldo_E" runat="server" MaxLength="10" SkinID="SkinTextBox"
                                                Text='<%# Bind("ISRUltimoSueldo") %>' Width="120px"></asp:TextBox><asp:RequiredFieldValidator
                                                    ID="RFVtbISRUltimoSueldo_E" runat="server" ControlToValidate="tbISRUltimoSueldo_E"
                                                    Display="None" ErrorMessage="I.S.R. último sueldo requerido."></asp:RequiredFieldValidator><asp:CompareValidator
                                                        ID="CVtbISRUltimoSueldo_E" runat="server" ControlToValidate="tbISRUltimoSueldo_E"
                                                        Display="None" ErrorMessage="I.S.R. último sueldo incorrecto." Operator="DataTypeCheck"
                                                        Type="Currency"></asp:CompareValidator><asp:CompareValidator ID="CV2tbISRUltimoSueldo_E"
                                                            runat="server" ControlToValidate="tbISRUltimoSueldo_E" Display="None" ErrorMessage="I.S.R. último sueldo debe ser mayor o igual a cero."
                                                            Operator="GreaterThanEqual" Type="Currency" ValueToCompare="0"></asp:CompareValidator>
                                        </EditItemTemplate>
                                        <HeaderStyle Wrap="False" />
                                        <InsertItemTemplate>
                                            <asp:TextBox ID="tbISRUltimoSueldo_I" runat="server" MaxLength="10" SkinID="SkinTextBox"
                                                Text="0" Width="120px"></asp:TextBox><asp:RequiredFieldValidator ID="RFVtbISRUltimoSueldo_I"
                                                    runat="server" ControlToValidate="tbISRUltimoSueldo_I" Display="None" ErrorMessage="I.S.R. último sueldo requerido."></asp:RequiredFieldValidator><asp:CompareValidator
                                                        ID="CVtbISRUltimoSueldo_I" runat="server" ControlToValidate="tbISRUltimoSueldo_I"
                                                        Display="None" ErrorMessage="I.S.R. último sueldo incorrecto." Operator="DataTypeCheck"
                                                        Type="Currency"></asp:CompareValidator><asp:CompareValidator ID="CV2tbISRUltimoSueldo_I"
                                                            runat="server" ControlToValidate="tbISRUltimoSueldo_I" Display="None" ErrorMessage="I.S.R. último sueldo debe ser mayor o igual a cero."
                                                            Operator="GreaterThanEqual" Type="Currency" ValueToCompare="0"></asp:CompareValidator>
                                        </InsertItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ShowHeader="False">
                                        <EditItemTemplate>
                                            <asp:Button ID="btnGurdar_E" runat="server" SkinID="SkinBoton" Text="Guardar" OnClick="btnGurdar_E_Click" /><ajaxToolkit:ConfirmButtonExtender
                                                ID="CBEbtnGuardar" runat="server" ConfirmText="¿Está seguro de guardar los cambios realizados?"
                                                TargetControlID="btnGurdar_E">
                                            </ajaxToolkit:ConfirmButtonExtender>
                                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                                                ShowSummary="False" />
                                        </EditItemTemplate>
                                        <ItemStyle HorizontalAlign="Right" />
                                        <InsertItemTemplate>
                                            <asp:Button ID="btnGurdar_I" runat="server" SkinID="SkinBoton" Text="Guardar" OnClick="btnGurdar_E_Click" /><ajaxToolkit:ConfirmButtonExtender
                                                ID="CBEbtnGuardar" runat="server" ConfirmText="¿Está seguro de guardar los cambios realizados?"
                                                TargetControlID="btnGurdar_I">
                                            </ajaxToolkit:ConfirmButtonExtender>
                                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                                                ShowSummary="False" />
                                        </InsertItemTemplate>
                                    </asp:TemplateField>
                                </Fields>
                                <HeaderStyle Font-Names="Verdana" Font-Size="Small" />
                            </asp:DetailsView>
                        </asp:View>
                        <asp:View ID="viewExito" runat="server">
                            <table>
                                <tr>
                                    <td style="vertical-align: middle; text-align: left">
                                        <asp:Image ID="Image2" runat="server" ImageUrl="~/Imagenes/Symbol-Check.png" Width="100px" />
                                    </td>
                                    <td style="vertical-align: middle; text-align: left">
                                        <asp:Label ID="lblExito" runat="server" SkinID="SkinLblMsjExito" Text="Operación realizada exitosamente."></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </asp:View>
                        <asp:View ID="viewError" runat="server">
                            <table>
                                <tr>
                                    <td style="vertical-align: middle; text-align: left">
                                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/Symbol-Stop.png" Width="100px" />
                                    </td>
                                    <td style="vertical-align: middle; text-align: left">
                                        <asp:Label ID="lblError" runat="server" SkinID="SkinLblMsjErrores"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </asp:View>
                    </asp:MultiView>
                </td>
            </tr>
            <tr>
                <td>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
