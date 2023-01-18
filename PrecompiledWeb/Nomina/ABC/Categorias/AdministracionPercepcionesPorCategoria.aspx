<%@ page language="VB" enableeventvalidation="false" masterpagefile="~/MasterPageBlanca.master" autoeventwireup="false" inherits="Administracion_PercepcionesPorCategoria, App_Web_kgihrihx" title="COBAEV - Nómina - Administración de percepciones por categoría" stylesheettheme="SkinFile" maintainScrollPositionOnPostBack="true" %>
<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress" TagPrefix="TP_wucUpdateProgress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
     <table style="width: 100%; vertical-align: top; text-align: center;" align="center">
        <tr>
            <td style="vertical-align: top; text-align: right">
                <h2>
                    Sistema de nómina: Importe de percepción</h2>
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
                                <td style="vertical-align: top; height: 213px; text-align: left;" >
                                    <asp:DetailsView ID="dvPercepcion" runat="server" AutoGenerateRows="False" DefaultMode="Edit"
                                        Height="50px" SkinID="SkinDetailsView" Width="70%">
                                        <Fields>
                                            <asp:TemplateField ShowHeader="False"><ItemTemplate><asp:Label ID="lblValoresActuales" runat="server" SkinID="SkinLblHeader" Text="Valores actuales"></asp:Label></ItemTemplate><EditItemTemplate><asp:Label 
                                                ID="lblValoresActuales" runat="server" SkinID="SkinLblHeader" 
                                                Text="Valores actuales"></asp:Label></EditItemTemplate><InsertItemTemplate><asp:Label 
                                                    ID="lblValoresActuales" runat="server" SkinID="SkinLblHeader" 
                                                    Text="Valores actuales"></asp:Label></InsertItemTemplate></asp:TemplateField>
                                            <asp:BoundField DataField="ClavePercepcion" HeaderText="Clave percepci&#243;n" 
                                                ReadOnly="True" >
                                                <HeaderStyle Wrap="False" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="NombrePercepcion" HeaderText="Percepci&#243;n" 
                                                ReadOnly="True" >
                                                <HeaderStyle Wrap="False" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="ClaveZonaEco" HeaderText="Zona econ&#243;mica" 
                                                ReadOnly="True" >
                                                <HeaderStyle Wrap="False" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="IdQnaVigIniPerc" Visible="False"><ItemTemplate><asp:Label ID="lblIdQnaVigIniPerc" runat="server" Text='<%# Bind("IdQnaVigIniPerc") %>'></asp:Label></ItemTemplate><EditItemTemplate><asp:Label 
                                                ID="lblIdQnaVigIniPerc" runat="server" Text='<%# Bind("IdQnaVigIniPerc") %>'></asp:Label></EditItemTemplate><InsertItemTemplate><asp:Label 
                                                    ID="lblIdQnaVigIniPerc" runat="server" Text='<%# Bind("IdQnaVigIniPerc") %>'></asp:Label></InsertItemTemplate></asp:TemplateField>
                                            <asp:TemplateField HeaderText="Inicio"><ItemTemplate><asp:Label ID="lblVigIniPerc" runat="server" Text='<%# Bind("VigIniPerc") %>'></asp:Label></ItemTemplate><EditItemTemplate><asp:DropDownList 
                                                ID="ddlVigIniPerc" runat="server" SkinID="SkinDropDownList"></asp:DropDownList></EditItemTemplate><InsertItemTemplate><asp:Label 
                                                    ID="lblVigIniPerc" runat="server" Text='<%# Bind("VigIniPerc") %>'></asp:Label></InsertItemTemplate><HeaderStyle 
                                                Wrap="False" /></asp:TemplateField>
                                            <asp:TemplateField HeaderText="IdQnaVigFinPerc" Visible="False"><ItemTemplate><asp:Label ID="lblIdQnaVigFinPerc" runat="server" Text='<%# Bind("IdQnaVigFinPerc") %>'></asp:Label></ItemTemplate><EditItemTemplate><asp:Label 
                                                ID="lblIdQnaVigFinPerc" runat="server" Text='<%# Bind("IdQnaVigFinPerc") %>'></asp:Label></EditItemTemplate><InsertItemTemplate><asp:Label ID="lblIdQnaVigFinPerc" runat="server" Text='<%# Bind("IdQnaVigFinPerc") %>'></asp:Label></InsertItemTemplate></asp:TemplateField>
                                            <asp:TemplateField HeaderText="Fin"><ItemTemplate><asp:Label ID="lblVigFinPerc" runat="server" Text='<%# Bind("VigFinPerc") %>'></asp:Label></ItemTemplate><EditItemTemplate><asp:Label 
                                                ID="lblVigFinPerc" runat="server" Text='<%# Bind("VigFinPerc") %>'></asp:Label></EditItemTemplate><InsertItemTemplate><asp:Label ID="lblVigFinPerc" runat="server" Text='<%# Bind("VigFinPerc") %>'></asp:Label></InsertItemTemplate><HeaderStyle 
                                                Wrap="False" /></asp:TemplateField>
                                            <asp:TemplateField HeaderText="Importe mensual"><ItemTemplate><asp:Label ID="lblImpMenPerc" runat="server" Text='<%# Bind("ImpMenPerc", "{0:c}") %>'></asp:Label></ItemTemplate><EditItemTemplate><asp:TextBox 
                                                ID="txtbxImpMenPerc" runat="server" MaxLength="8" SkinID="SkinTextBox" 
                                                Text='<%# Bind("ImpMenPerc") %>'></asp:TextBox><asp:RequiredFieldValidator 
                                                ID="RFVImportePercepcion" runat="server" ControlToValidate="txtbxImpMenPerc" 
                                                Display="None" ErrorMessage="Importe requerido"></asp:RequiredFieldValidator><asp:CompareValidator 
                                                ID="CVImportePercepcion" runat="server" ControlToValidate="txtbxImpMenPerc" 
                                                Display="None" ErrorMessage="Importe incorrecto" Operator="DataTypeCheck" 
                                                Type="Currency"></asp:CompareValidator></EditItemTemplate><HeaderStyle 
                                                Wrap="False" /></asp:TemplateField>
                                            <asp:TemplateField HeaderText="Modificar categor&#237;a RP asociada"><EditItemTemplate><asp:CheckBox ID="ChBxModifRP" runat="server" Enabled="False" /></EditItemTemplate><HeaderStyle 
                                                Wrap="False" /></asp:TemplateField>
                                            <asp:TemplateField ShowHeader="False"><EditItemTemplate><asp:Button ID="btnGuardar" runat="server" OnClick="btnGuardar_Click" SkinID="SkinBoton"
                                                        Text="Guardar" /><ajaxToolkit:ConfirmButtonExtender ID="CBEGuardar" runat="server" ConfirmText="¿Información correcta?"
                                                        TargetControlID="btnGuardar"></ajaxToolkit:ConfirmButtonExtender><asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                                                        ShowSummary="False" /></EditItemTemplate><InsertItemTemplate><asp:Button ID="btnGuardar" runat="server" OnClick="btnGuardar_Click" SkinID="SkinBoton"
                                                        Text="Guardar" /><ajaxToolkit:ConfirmButtonExtender ID="CBEGuardar" runat="server" ConfirmText="¿Información correcta?"
                                                        TargetControlID="btnGuardar"></ajaxToolkit:ConfirmButtonExtender><asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                                                        ShowSummary="False" /></InsertItemTemplate><ItemStyle HorizontalAlign="Right" /></asp:TemplateField>
                                        </Fields>
                                    </asp:DetailsView>
                                    <asp:DetailsView ID="dvNuevosValores" runat="server" AutoGenerateRows="False" DefaultMode="Insert"
                                        Height="50px" SkinID="SkinDetailsView" Width="70%">
                                        <Fields>
                                            <asp:TemplateField ShowHeader="False"><EditItemTemplate><asp:Label ID="lblNuevosValores" runat="server" SkinID="SkinLblHeader" Text="Nuevos valores"></asp:Label></EditItemTemplate><InsertItemTemplate><asp:Label ID="lblNuevosValores" runat="server" SkinID="SkinLblHeader" Text="Nuevos valores"></asp:Label></InsertItemTemplate><ItemTemplate><asp:Label ID="lblNuevosValores" runat="server" SkinID="SkinLblHeader" Text="Nuevos valores"></asp:Label></ItemTemplate></asp:TemplateField>
                                            <asp:TemplateField HeaderText="Nuevo importe"><EditItemTemplate><asp:Label ID="lblNuevoImporte" runat="server" Text="No disponible"></asp:Label></EditItemTemplate><InsertItemTemplate><asp:TextBox ID="txtbxNuevoImporte" runat="server" MaxLength="8" SkinID="SkinTextBox"></asp:TextBox><asp:RequiredFieldValidator ID="RFVImportePercepcion" runat="server" ControlToValidate="txtbxNuevoImporte"
                                                        Display="None" ErrorMessage="Importe requerido"></asp:RequiredFieldValidator><asp:CompareValidator ID="CVImportePercepcion" runat="server" ControlToValidate="txtbxNuevoImporte"
                                                        Display="None" ErrorMessage="Importe incorrecto" Operator="DataTypeCheck" Type="Currency"></asp:CompareValidator></InsertItemTemplate><ItemTemplate><asp:Label ID="lblNuevoImporte" runat="server" Text="No disponible"></asp:Label></ItemTemplate></asp:TemplateField>
                                            <asp:TemplateField HeaderText="Quincena inicial"><EditItemTemplate><asp:Label ID="lblQnaIni" runat="server" Text="No disponible"></asp:Label></EditItemTemplate><InsertItemTemplate><asp:DropDownList ID="ddlQnaIni" runat="server" SkinID="SkinDropDownList"></asp:DropDownList></InsertItemTemplate><ItemTemplate><asp:Label ID="lblQnaIni" runat="server" Text="No disponible"></asp:Label></ItemTemplate></asp:TemplateField>
                                            <asp:TemplateField HeaderText="Modificar categor&#237;a RP asociada"><InsertItemTemplate><asp:CheckBox ID="ChBxModifRP" runat="server" Enabled="False" /></InsertItemTemplate></asp:TemplateField>
                                            <asp:TemplateField ShowHeader="False"><EditItemTemplate><asp:Button ID="btnGuardar" runat="server" SkinID="SkinBoton"
                                                        Text="Guardar" /><ajaxToolkit:ConfirmButtonExtender ID="CBEGuardar" runat="server" ConfirmText="¿Información correcta?"
                                                        TargetControlID="btnGuardar"></ajaxToolkit:ConfirmButtonExtender><asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                                                        ShowSummary="False" /></EditItemTemplate><ItemStyle HorizontalAlign="Right" /><InsertItemTemplate><asp:Button ID="btnGuardar" runat="server" OnClick="btnGuardar_Click1" SkinID="SkinBoton"
                                                        Text="Guardar" /><ajaxToolkit:ConfirmButtonExtender ID="CBEGuardar" runat="server" ConfirmText="¿Información correcta?"
                                                        TargetControlID="btnGuardar"></ajaxToolkit:ConfirmButtonExtender><asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                                                        ShowSummary="False" /></InsertItemTemplate></asp:TemplateField>
                                        </Fields>
                                    </asp:DetailsView>
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
                        <asp:Label ID="lblCapturaExitosa" runat="server" SkinID="SkinLblMsjExito" Text="Captura realizada exitosamente"></asp:Label></td>
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
</asp:Content>

