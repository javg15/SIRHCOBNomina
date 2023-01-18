<%@ page language="VB" masterpagefile="~/MasterPageBlanca.master" autoeventwireup="false" inherits="ABC_Recibos_AdmonConceptosRecibos, App_Web_5lgpnrst" title="COBAEV - Nómina - Administrar conceptos de los recibos" stylesheettheme="SkinFile" maintainScrollPositionOnPostBack="true" %>
<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress" TagPrefix="TP_wucUpdateProgress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
    <div>
        <table style="width: 100%; height: 100%">
        <tr>
            <td style="vertical-align: top; text-align: right">
                <h2>
                    Recibos de pago fuera de nómina <br />
                    Administración de conceptos a incluir en el recibo
                </h2>
            </td>
        </tr>
            <tr>
                <td>
                            <asp:UpdatePanel ID="UPMain" runat="server">
                                <ContentTemplate>
                                    <asp:MultiView ID="MultiView1" runat="server">
                                        <asp:View ID="viewEditar" runat="server">
                                            <asp:DetailsView ID="dvConcepto" runat="server" AutoGenerateRows="False" 
                                                CellPadding="1" DefaultMode="Edit" SkinID="SkinDetailsView">
                                                <Fields>
                                                    <asp:TemplateField HeaderText="Concepto">
                                                        <EditItemTemplate>
                                                            <asp:DropDownList ID="ddlConcepto_E" runat="server" SkinID="SkinDropDownList">
                                                            </asp:DropDownList>
                                                        </EditItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Left" Wrap="False" />
                                                        <ItemStyle HorizontalAlign="Left" />
                                                        <InsertItemTemplate>
                                                            <asp:DropDownList ID="ddlConcepto_I" runat="server" AutoPostBack="True" 
                                                                onselectedindexchanged="ddlConcepto_I_SelectedIndexChanged" 
                                                                SkinID="SkinDropDownList">
                                                            </asp:DropDownList>
                                                        </InsertItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Mostrar en recibo">
                                                        <EditItemTemplate>
                                                            <asp:CheckBox ID="ChBxMostrarEnRecibo_E" runat="server" 
                                                                Checked='<%# Bind("MostrarEnRecibo") %>' />
                                                        </EditItemTemplate>
                                                        <InsertItemTemplate>
                                                            <asp:CheckBox ID="ChBxMostrarEnRecibo_I" runat="server" Checked="True" />
                                                        </InsertItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Importe">
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="tbImporte_E" runat="server" SkinID="SkinTextBox" 
                                                                Text='<%# Bind("Importe") %>'></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RFVImporte_E" runat="server" 
                                                                ControlToValidate="tbImporte_E" Display="None" ErrorMessage="Importe requerido"></asp:RequiredFieldValidator>
                                                            <asp:CompareValidator ID="CVImporte_E" runat="server" 
                                                                ControlToValidate="tbImporte_E" Display="None" 
                                                                ErrorMessage="Importe incorrecto" Operator="DataTypeCheck" Type="Currency"></asp:CompareValidator>
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            &nbsp;
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Left" Wrap="False" />
                                                        <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                                        <InsertItemTemplate>
                                                            <asp:TextBox ID="tbImporte_I" runat="server" AutoPostBack="True" 
                                                                OnTextChanged="tbImporte_I_TextChanged" SkinID="SkinTextBox">0</asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RFVImporte_I" runat="server" 
                                                                ControlToValidate="tbImporte_I" Display="None" ErrorMessage="Importe requerido"></asp:RequiredFieldValidator>
                                                            <asp:CompareValidator ID="CVImporte_I" runat="server" 
                                                                ControlToValidate="tbImporte_I" Display="None" 
                                                                ErrorMessage="Importe incorrecto" Operator="DataTypeCheck" Type="Currency"></asp:CompareValidator>
                                                        </InsertItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Importe para retroactivo">
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="tbImporteRetroactivo_E" runat="server" SkinID="SkinTextBox" 
                                                                Text='<%# Bind("ImporteParaRetroactivo") %>'></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RFVImporteRetroactivo_E" runat="server" 
                                                                ControlToValidate="tbImporteRetroactivo_E" Display="None" 
                                                                ErrorMessage="Importe para retroactivo requerido"></asp:RequiredFieldValidator>
                                                            <asp:CompareValidator ID="CVImporteRetroactivo_E" runat="server" 
                                                                ControlToValidate="tbImporteRetroactivo_E" Display="None" 
                                                                ErrorMessage="Importe para retroactivo incorrecto" Operator="DataTypeCheck" 
                                                                Type="Currency"></asp:CompareValidator>
                                                        </EditItemTemplate>
                                                        <HeaderStyle Wrap="False" />
                                                        <InsertItemTemplate>
                                                            <asp:TextBox ID="tbImporteRetroactivo_I" runat="server" SkinID="SkinTextBox">0</asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RFVImporteRetroactivo_I" runat="server" 
                                                                ControlToValidate="tbImporteRetroactivo_I" Display="None" 
                                                                ErrorMessage="Importe para retroactivo requerido"></asp:RequiredFieldValidator>
                                                            <asp:CompareValidator ID="CVImporteRetroactivo_I" runat="server" 
                                                                ControlToValidate="tbImporteRetroactivo_I" Display="None" 
                                                                ErrorMessage="Importe para retroactivo incorrecto" Operator="DataTypeCheck" 
                                                                Type="Currency"></asp:CompareValidator>
                                                        </InsertItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Importe para aguinaldo">
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="tbImporteAguinaldo_E" runat="server" SkinID="SkinTextBox" 
                                                                Text='<%# Bind("ImporteParaAguinaldo") %>'></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RFVImporteAguinaldo_E" runat="server" 
                                                                ControlToValidate="tbImporteAguinaldo_E" Display="None" 
                                                                ErrorMessage="Importe para aguinaldo requerido"></asp:RequiredFieldValidator>
                                                            <asp:CompareValidator ID="CVImporteAguinaldo_E" runat="server" 
                                                                ControlToValidate="tbImporteAguinaldo_E" Display="None" 
                                                                ErrorMessage="Importe para aguinaldo incorrecto" Operator="DataTypeCheck" 
                                                                Type="Currency"></asp:CompareValidator>
                                                        </EditItemTemplate>
                                                        <InsertItemTemplate>
                                                            <asp:TextBox ID="tbImporteAguinaldo_I" runat="server" SkinID="SkinTextBox">0</asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RFVImporteAguinaldo_I" runat="server" 
                                                                ControlToValidate="tbImporteAguinaldo_I" Display="None" 
                                                                ErrorMessage="Importe para aguinaldo requerido"></asp:RequiredFieldValidator>
                                                            <asp:CompareValidator ID="CVImporteAguinaldo_I" runat="server" 
                                                                ControlToValidate="tbImporteAguinaldo_I" Display="None" 
                                                                ErrorMessage="mporte para aguinaldo incorrecto" Operator="DataTypeCheck" 
                                                                Type="Currency"></asp:CompareValidator>
                                                        </InsertItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Importe gravado">
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="tbImporteGrav_E" runat="server" SkinID="SkinTextBox" 
                                                                Text='<%# Bind("ImporteGravado") %>'></asp:TextBox>
                                                            <asp:Label ID="lblGrava_E" runat="server" Font-Bold="True" Font-Size="8pt" 
                                                                SkinID="SkinLblMsjErrores"></asp:Label>
                                                            <asp:RequiredFieldValidator ID="RFVImporteGrav_E" runat="server" 
                                                                ControlToValidate="tbImporteGrav_E" Display="None" 
                                                                ErrorMessage="Importe gravado requerido"></asp:RequiredFieldValidator>
                                                            <asp:CompareValidator ID="CVImporteGrav_E" runat="server" 
                                                                ControlToValidate="tbImporteGrav_E" Display="None" 
                                                                ErrorMessage="Importe gravado incorrecto" Operator="DataTypeCheck" 
                                                                Type="Currency"></asp:CompareValidator>
                                                        </EditItemTemplate>
                                                        <InsertItemTemplate>
                                                            <asp:TextBox ID="tbImporteGrav_I" runat="server" SkinID="SkinTextBox">0.00</asp:TextBox>
                                                            <asp:Label ID="lblGrava_I" runat="server" Font-Bold="True" Font-Size="8pt" 
                                                                SkinID="SkinLblMsjErrores"></asp:Label>
                                                            <asp:RequiredFieldValidator ID="RFVImporteGrav_I" runat="server" 
                                                                ControlToValidate="tbImporteGrav_I" Display="None" 
                                                                ErrorMessage="Importe gravado requerido"></asp:RequiredFieldValidator>
                                                            <asp:CompareValidator ID="CVImporteGrav_I" runat="server" 
                                                                ControlToValidate="tbImporteGrav_I" Display="None" 
                                                                ErrorMessage="Importe gravado incorrecto" Operator="DataTypeCheck" 
                                                                Type="Currency"></asp:CompareValidator>
                                                        </InsertItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Días exentos">
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="tbDiasExentos_E" runat="server" SkinID="SkinTextBox" 
                                                                Text='<%# Bind("DiasExentos") %>'></asp:TextBox>
                                                            <asp:Label ID="lblDiasExentos_E" runat="server" Font-Bold="True" Font-Size="8pt" 
                                                                SkinID="SkinLblMsjErrores"></asp:Label>
<%--                                                            <asp:RequiredFieldValidator ID="RFVDiasExentos_E" runat="server" 
                                                                ControlToValidate="tbDiasExentos_E" Display="None" 
                                                                ErrorMessage="Días exentos requeridos."></asp:RequiredFieldValidator>--%>
                                                            <asp:CompareValidator ID="CVDiasExentos_E" runat="server" 
                                                                ControlToValidate="tbDiasExentos_E" Display="None" 
                                                                ErrorMessage="Días exentos incorrectos." Operator="DataTypeCheck" 
                                                                Type="Double"></asp:CompareValidator>
                                                        </EditItemTemplate>
                                                        <InsertItemTemplate>
                                                            <asp:TextBox ID="tbDiasExentos_I" runat="server" SkinID="SkinTextBox">0</asp:TextBox>
                                                            <asp:Label ID="lblDiasExentos_I" runat="server" Font-Bold="True" Font-Size="8pt" 
                                                                SkinID="SkinLblMsjErrores"></asp:Label>
<%--                                                            <asp:RequiredFieldValidator ID="RFVDiasExentos_I" runat="server" 
                                                                ControlToValidate="tbDiasExentos_I" Display="None" 
                                                                ErrorMessage="Días exentos requeridos."></asp:RequiredFieldValidator>--%>
                                                            <asp:CompareValidator ID="CVDiasExentos_I" runat="server" 
                                                                ControlToValidate="tbDiasExentos_I" Display="None" 
                                                                ErrorMessage="Días exentos incorrectos." Operator="DataTypeCheck" 
                                                                Type="Double"></asp:CompareValidator>
                                                        </InsertItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ShowHeader="False">
                                                        <EditItemTemplate>
                                                            <asp:Button ID="btnGurdar_E" runat="server" OnClick="btnGurdar_E_Click" 
                                                                SkinID="SkinBoton" Text="Guardar" />
                                                            <ajaxToolkit:ConfirmButtonExtender ID="CBEbtnGuardar" runat="server" 
                                                                ConfirmText="¿Está seguro de guardar los cambios realizados?" 
                                                                TargetControlID="btnGurdar_E">
                                                            </ajaxToolkit:ConfirmButtonExtender>
                                                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                                                                ShowMessageBox="True" ShowSummary="False" />
                                                        </EditItemTemplate>
                                                        <ItemStyle HorizontalAlign="Right" />
                                                        <InsertItemTemplate>
                                                            <asp:Button ID="btnGurdar_I" runat="server" OnClick="btnGurdar_E_Click" 
                                                                SkinID="SkinBoton" Text="Guardar" />
                                                            <ajaxToolkit:ConfirmButtonExtender ID="CBEbtnGuardar0" runat="server" 
                                                                ConfirmText="¿Está seguro de guardar los cambios realizados?" 
                                                                TargetControlID="btnGurdar_I">
                                                            </ajaxToolkit:ConfirmButtonExtender>
                                                            <asp:ValidationSummary ID="ValidationSummary2" runat="server" 
                                                                ShowMessageBox="True" ShowSummary="False" />
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
                                                        <asp:Image ID="Image2" runat="server" ImageUrl="~/Imagenes/Symbol-Check.png" 
                                                            Width="100px" />
                                                    </td>
                                                    <td style="vertical-align: middle; text-align: left">
                                                        <asp:Label ID="lblExito" runat="server" SkinID="SkinLblMsjExito" 
                                                            Text="Operación realizada exitosamente."></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:View>
                                        <asp:View ID="viewError" runat="server">
                                            <table>
                                                <tr>
                                                    <td style="vertical-align: middle; text-align: left">
                                                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/Symbol-Stop.png" 
                                                            Width="100px" />
                                                    </td>
                                                    <td style="vertical-align: middle; text-align: left">
                                                        <asp:Label ID="lblError" runat="server" SkinID="SkinLblMsjErrores"></asp:Label>
                                                        <br />
                                                        <asp:LinkButton ID="lbReintentarCaptura" runat="server" 
                                                            SkinID="SkinLinkButton9pt">Reintentar captura</asp:LinkButton>
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
    </div>
</asp:Content>
