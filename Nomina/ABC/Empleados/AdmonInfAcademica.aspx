<%@ Page Language="VB" MasterPageFile="~/MasterPageSesionIniciada.master" AutoEventWireup="false"
    CodeFile="AdmonInfAcademica.aspx.vb" Inherits="ABC_Empleados_AdmonInfAcademica"
    Title="COBAEV - Nómina - Administrar información académica" StylesheetTheme="SkinFile"
    Culture="Auto" UICulture="Auto" %>

<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress"
    TagPrefix="TP_wucUpdateProgress" %>
<%@ Register Src="~/WebControls/wucSearchEmps.ascx" TagName="wucBuscaEmpleados" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
    <table style="width: 100%;" align="center">
        <tr>
            <td style="vertical-align: top; text-align: right">
                <h2>
                    Sistema de nómina: Empleados (Administrar información académica)
                </h2>
            </td>
        </tr>
    </table>
<asp:UpdatePanel ID="UPEstudios" runat="server">
    <ContentTemplate>
    <uc1:wucBuscaEmpleados ID="WucBuscaEmpleados1" runat="server" EnableViewState="true" />
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="viewCaptura" runat="server">
            <table style="width: 100%; height: 300px" align="center">
                <tr>
                    <td style="vertical-align: top; width: 100%; height: 100%; text-align: left">
                        <table style="width: 100%">
                            <tr>
                                <td style="vertical-align: top; text-align: left; height: 213px;">
                                    <ajaxToolkit:CollapsiblePanelExtender ID="CPEDatosAcad" runat="Server" CollapseControlID="TitlePanelDatosAcad"
                                        Collapsed="False" CollapsedImage="~/Imagenes/expand_blue.jpg" CollapsedText="(Mostrar panel...)"
                                        ExpandControlID="TitlePanelDatosAcad" ExpandedImage="~/Imagenes/collapse_blue.jpg"
                                        ExpandedText="(Ocultar panel...)" ImageControlID="Image1" SuppressPostBack="true"
                                        TargetControlID="ContentPanelDatosAcad" TextLabelID="Label1">
                                    </ajaxToolkit:CollapsiblePanelExtender>
                                    <table cellpadding="0" cellspacing="0" style="width: 100%">
                                        <tr>
                                            <td colspan="2" style="vertical-align: top; text-align: left;">
                                                <asp:Panel ID="TitlePanelDatosAcad" runat="server" BorderColor="White" BorderStyle="Solid"
                                                    BorderWidth="1px" CssClass="collapsePanelHeader" Width="100%">
                                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/expand_blue.jpg" />
                                                    Inserción/Modificación de datos académicos
                                                    <asp:Label ID="Label1" runat="server">(Mostrar detalles...)</asp:Label>
                                                </asp:Panel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="vertical-align: top; text-align: left;">

                                                        <asp:Panel ID="ContentPanelDatosAcad" runat="server" Width="100%" CssClass="collapsePanel">
                                                            <asp:DetailsView ID="dvNivAcad" runat="server" AutoGenerateRows="False" DefaultMode="Insert"
                                                                EmptyDataText="Sin información de datos académicos" SkinID="SkinDetailsView"
                                                                CellPadding="0" Width="100%">
                                                                <Fields>
                                                                    <asp:TemplateField HeaderText="Niveles académicos">
                                                                        <EditItemTemplate>
                                                                            <asp:Label ID="lblIdNivel_E" runat="server" Text='<%# Bind(""IdNivel") %>' Visible="False"></asp:Label>
                                                                            <asp:DropDownList ID="ddlNivAcad_E" runat="server" AutoPostBack="True" SkinID="SkinDropDownList"
                                                                                OnSelectedIndexChanged="ddlNivAcad_SelectedIndexChanged">
                                                                            </asp:DropDownList>
                                                                        </EditItemTemplate>
                                                                        <InsertItemTemplate>
                                                                            <asp:DropDownList ID="ddlNivAcad_I" runat="server" AutoPostBack="True" SkinID="SkinDropDownList"
                                                                                OnSelectedIndexChanged="ddlNivAcad_SelectedIndexChanged">
                                                                            </asp:DropDownList>
                                                                        </InsertItemTemplate>
                                                                        <HeaderStyle Wrap="False" />
                                                                        <ItemStyle Wrap="False" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Carreras por nivel">
                                                                        <EditItemTemplate>
                                                                                    <asp:Label ID="lblIdCarrera_E" runat="server" Text='<%# Bind(""IdCarrera") %>' Visible="False"></asp:Label>
                                                                                    <asp:DropDownList ID="ddlCarrPorNiv_E" runat="server" SkinID="SkinDropDownList">
                                                                                    </asp:DropDownList>
                                                                        </EditItemTemplate>
                                                                        <InsertItemTemplate>
                                                                                    <asp:DropDownList ID="ddlCarrPorNiv_I" runat="server" SkinID="SkinDropDownList">
                                                                                    </asp:DropDownList>
                                                                        </InsertItemTemplate>
                                                                        <ItemTemplate>
                                                                        </ItemTemplate>
                                                                        <HeaderStyle Wrap="False" />
                                                                        <ItemStyle Wrap="False" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Titulado">
                                                                        <EditItemTemplate>
                                                                                    <asp:CheckBox ID="chbTitulado_E" runat="server" 
                                                                                        Checked='<%# Bind("Titulado") %>' 
                                                                                        oncheckedchanged="chbTitulado_CheckedChanged" AutoPostBack="True" />
                                                                        </EditItemTemplate>
                                                                        <InsertItemTemplate>
                                                                                    <asp:CheckBox ID="chbTitulado_I" runat="server" 
                                                                                        oncheckedchanged="chbTitulado_CheckedChanged" AutoPostBack="True" />
                                                                        </InsertItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Cédula profesional">
                                                                        <EditItemTemplate>
                                                                                    <asp:TextBox ID="tbNumCedProf_E" runat="server" Columns="30" MaxLength="20" SkinID="SkinTextBox"
                                                                                        Text='<%# Bind("NumCedProf") %>'></asp:TextBox>
                                                                        </EditItemTemplate>
                                                                        <InsertItemTemplate>
                                                                                    <asp:TextBox ID="tbNumCedProf_I" runat="server" Columns="30" MaxLength="20" SkinID="SkinTextBox"></asp:TextBox>
                                                                        </InsertItemTemplate>
                                                                        <HeaderStyle Wrap="False" />
                                                                        <ItemStyle Wrap="False" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Estudios incompletos">
                                                                        <EditItemTemplate>
                                                                                    <asp:CheckBox ID="chbIncompleta_E" runat="server" 
                                                                                        Checked='<%# Bind("Incompleta") %>' 
                                                                                        oncheckedchanged="chbIncompleta_CheckedChanged" AutoPostBack="True" />
                                                                        </EditItemTemplate>
                                                                        <InsertItemTemplate>
                                                                                    <asp:CheckBox ID="chbIncompleta_I" runat="server" 
                                                                                        oncheckedchanged="chbIncompleta_CheckedChanged" AutoPostBack="True" />
                                                                        </InsertItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Cursando actualmente">
                                                                        <EditItemTemplate>
                                                                             <asp:CheckBox ID="chbCursando_E" runat="server" 
                                                                                        Checked='<%# Bind("Cursando") %>' 
                                                                                        oncheckedchanged="chbCursando_CheckedChanged" AutoPostBack="True" />
                                                                        </EditItemTemplate>
                                                                        <InsertItemTemplate>
                                                                                    <asp:CheckBox ID="chbCursando_I" runat="server" 
                                                                                        oncheckedchanged="chbCursando_CheckedChanged" AutoPostBack="True" />
                                                                        </InsertItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Ult. nivel de estudios">
                                                                        <EditItemTemplate>
                                                                                    <asp:CheckBox ID="chbUltNivEstudios_E" runat="server" Checked='<%# Bind("UltNivEstudios") %>' />
                                                                        </EditItemTemplate>
                                                                        <InsertItemTemplate>
                                                                                    <asp:CheckBox ID="chbUltNivEstudios_I" runat="server" />
                                                                        </InsertItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Abrev. profesión">
                                                                        <EditItemTemplate>
                                                                                    <asp:TextBox ID="tbAbrevProf_E" runat="server" Columns="10" MaxLength="10" SkinID="SkinTextBox"
                                                                                        Text='<%# Bind("SiglasINI") %>'></asp:TextBox>
                                                                        </EditItemTemplate>
                                                                        <InsertItemTemplate>
                                                                                    <asp:TextBox ID="tbAbrevProf_I" runat="server" Columns="10" MaxLength="10" SkinID="SkinTextBox"></asp:TextBox>
                                                                        </InsertItemTemplate>
                                                                        <HeaderStyle Wrap="False" />
                                                                        <ItemStyle Wrap="False" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Fecha exp. doc.">
                                                                        <EditItemTemplate>
                                                                            <asp:TextBox ID="tbFecha_E" runat="server" Columns="15" MaxLength="10" SkinID="SkinTextBox"
                                                                                Text='<%# Bind("Fecha","{0:d}") %>' Wrap="False"></asp:TextBox>
                                                                            <ajaxToolkit:TextBoxWatermarkExtender ID="tbFecha_E_TextBoxWatermarkExtender" runat="server"
                                                                                Enabled="True" TargetControlID="tbFecha_E" WatermarkText="dd/mm/aaaa" WatermarkCssClass="WaterMark">
                                                                            </ajaxToolkit:TextBoxWatermarkExtender>
                                                                            <asp:RequiredFieldValidator ID="RFVtbFecha_E" runat="server" ControlToValidate="tbFecha_E"
                                                                                Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ToolTip="Fecha de pago requerida."></asp:RequiredFieldValidator>
                                                                            <asp:CompareValidator ID="CVtbFecha_E" runat="server" ControlToValidate="tbFecha_E"
                                                                                Display="Dynamic" ErrorMessage="Error en la fecha." Operator="DataTypeCheck"
                                                                                Type="Date"></asp:CompareValidator>
                                                                        </EditItemTemplate>
                                                                        <InsertItemTemplate>
                                                                            <asp:TextBox ID="tbFecha_I" runat="server" Columns="15" MaxLength="10" SkinID="SkinTextBox"
                                                                                Wrap="False"></asp:TextBox>
                                                                            <ajaxToolkit:TextBoxWatermarkExtender ID="tbFecha_I_TextBoxWatermarkExtender" runat="server"
                                                                                Enabled="True" TargetControlID="tbFecha_I" WatermarkText="dd/mm/aaaa" WatermarkCssClass="WaterMark">
                                                                            </ajaxToolkit:TextBoxWatermarkExtender>
                                                                            <asp:RequiredFieldValidator ID="RFVtbFecha_I" runat="server" ControlToValidate="tbFecha_I"
                                                                                Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ToolTip="Fecha de pago requerida."></asp:RequiredFieldValidator>
                                                                            <asp:CompareValidator ID="CVtbFecha_I" runat="server" ControlToValidate="tbFecha_I"
                                                                                Display="Dynamic" ErrorMessage="Error en la fecha." Operator="DataTypeCheck"
                                                                                Type="Date"></asp:CompareValidator>
                                                                        </InsertItemTemplate>
                                                                        <HeaderStyle Wrap="False" />
                                                                        <ItemStyle Wrap="False" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ShowHeader="False">
                                                                        <EditItemTemplate>
                                                                            <asp:Button ID="btnCancelar_E" runat="server" SkinID="SkinBoton" Text="Cancelar" CausesValidation="False" />
                                                                            <ajaxToolkit:ConfirmButtonExtender ID="CBEbtnGuardar_E" runat="server" ConfirmText="¿Está seguro de guardar los cambios realizados?"
                                                                                TargetControlID="btnGuardar_E">
                                                                            </ajaxToolkit:ConfirmButtonExtender>
                                                                            <asp:Button ID="btnGuardar_E" runat="server" SkinID="SkinBoton" Text="Guardar" ToolTip="Guardar información"
                                                                                Width="80px" OnClick="btnGuardar_Click" />
                                                                        </EditItemTemplate>
                                                                        <HeaderStyle Wrap="False" />
                                                                        <ItemStyle HorizontalAlign="Right" Wrap="False" />
                                                                        <InsertItemTemplate>
                                                                            <asp:Button ID="btnCancelar_I" runat="server" SkinID="SkinBoton" Text="Cancelar" CausesValidation="False" />
                                                                            <ajaxToolkit:ConfirmButtonExtender ID="CBEbtnGuardar_I" runat="server" ConfirmText="¿Está seguro de guardar los cambios realizados?"
                                                                                TargetControlID="btnGuardar_I">
                                                                            </ajaxToolkit:ConfirmButtonExtender>
                                                                            <asp:Button ID="btnGuardar_I" runat="server" SkinID="SkinBoton" Text="Guardar" ToolTip="Guardar información del empleado"
                                                                                OnClick="btnGuardar_Click" Width="80px" />
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
                        <asp:Label ID="lblCapturaExitosa" runat="server" SkinID="SkinLblMsjExito" Text="Operación realizada exitosamente"></asp:Label>
                        <br />
                        <asp:LinkButton ID="lbOtraOperacion" runat="server" SkinID="SkinLinkButton">Cambiar más datos</asp:LinkButton>
                        &nbsp;<asp:LinkButton ID="lbOtraOperacion0" runat="server" 
                            PostBackUrl="~/Consultas/Empleados/InfAcademica.aspx?TipoOperacion=4" 
                            SkinID="SkinLinkButton">Continuar con otra operación en el sistema</asp:LinkButton>
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
                        <asp:LinkButton ID="lbReintentarCaptura" runat="server" SkinID="SkinLinkButton">Reintentar captura</asp:LinkButton>
                    </td>
                </tr>
            </table>
        </asp:View>
    </asp:MultiView>
    </ContentTemplate>
</asp:UpdatePanel>
</asp:Content>
