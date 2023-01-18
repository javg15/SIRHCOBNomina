<%@ Page Language="VB" MasterPageFile="~/MasterPageSesionIniciada.master" AutoEventWireup="false"
    CodeFile="AdministracionDomicilioFiscalSAT.aspx.vb" Inherits="ABC_Empleados_AdministracionDomicilioFiscalSAT"
    Title="COBAEV - Nómina - Administrar domicilio fiscal de los empleados" StylesheetTheme="SkinFile"
    Culture="Auto" UICulture="Auto" %>

<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress"
    TagPrefix="TP_wucUpdateProgress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
    <table style="width: 100%;" align="center">
        <tr>
            <td style="vertical-align: top; text-align: right">
                <h2>
                    Sistema de nómina: Empleados (Administrar información de domicilio)
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
                                                    <asp:DetailsView ID="dvDatosDom" runat="server" AutoGenerateRows="False" DefaultMode="Insert"
                                                        EmptyDataText="Sin información de domicilio" SkinID="SkinDetailsView" CellPadding="0">
                                                        <Fields>
                                                            <asp:TemplateField ShowHeader="False">
                                                                <InsertItemTemplate>
                                                                    <asp:Label ID="Label2" runat="server" SkinID="SkinLblHeader" Text="Empleado"></asp:Label>
                                                                </InsertItemTemplate>
                                                                <ItemStyle HorizontalAlign="Left" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="IdEmp" Visible="False">
                                                                <InsertItemTemplate>
                                                                    <asp:Label ID="lblIdEmp" runat="server" Text='<%# Eval("IdEmp") %>'></asp:Label>
                                                                </InsertItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="R.F.C.">
                                                                <EditItemTemplate>
                                                                    &nbsp;
                                                                </EditItemTemplate>
                                                                <InsertItemTemplate>
                                                                    <asp:TextBox ID="txtbxRFC" runat="server" SkinID="SkinTextBox" MaxLength="13" Columns="20"
                                                                        ReadOnly="True"></asp:TextBox>
                                                                </InsertItemTemplate>
                                                                <HeaderStyle Wrap="False" />
                                                                <ItemStyle Wrap="False" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Nombre">
                                                                <EditItemTemplate>
                                                                    &nbsp;
                                                                </EditItemTemplate>
                                                                <InsertItemTemplate>
                                                                    <asp:TextBox ID="txtbxNombre" runat="server" Columns="40" MaxLength="30" SkinID="SkinTextBox"
                                                                        ReadOnly="True"></asp:TextBox>
                                                                    &nbsp;
                                                                </InsertItemTemplate>
                                                                <HeaderStyle Wrap="False" />
                                                                <ItemStyle Wrap="False" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ShowHeader="False">
                                                                <InsertItemTemplate>
                                                                    <asp:Label ID="Label3" runat="server" SkinID="SkinLblHeader" Text="Datos de su domicilio"></asp:Label>
                                                                </InsertItemTemplate>
                                                                <ItemStyle HorizontalAlign="Left" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Calle">
                                                                <EditItemTemplate>
                                                                    &nbsp;
                                                                </EditItemTemplate>
                                                                <InsertItemTemplate>
                                                                    <asp:TextBox ID="tbCalle" runat="server" Columns="60" SkinID="SkinTextBox" MaxLength="60"></asp:TextBox>
                                                                    <ajaxToolkit:AutoCompleteExtender ID="ACECalles" runat="server" EnableCaching="true"
                                                                        MinimumPrefixLength="2" ServiceMethod="BuscarCalles" ServicePath="~/WSBusquedas.asmx"
                                                                        TargetControlID="tbCalle">
                                                                    </ajaxToolkit:AutoCompleteExtender>
                                                                </InsertItemTemplate>
                                                                <ItemTemplate>
                                                                    &nbsp;
                                                                </ItemTemplate>
                                                                <HeaderStyle Wrap="False" />
                                                                <ItemStyle Wrap="False" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="N&#250;m. Ext.">
                                                                <InsertItemTemplate>
                                                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                                        <ContentTemplate>
                                                                            <table>
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbNumExt" runat="server" MaxLength="15" SkinID="SkinTextBox" Wrap="False"
                                                                                            Columns="15"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:CheckBox ID="chbSN" runat="server" AutoPostBack="True" OnCheckedChanged="chbSN_CheckedChanged"
                                                                                            Text="Sin número" />
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </ContentTemplate>
                                                                        <Triggers>
                                                                            <asp:AsyncPostBackTrigger ControlID="chbSN" EventName="CheckedChanged" />
                                                                        </Triggers>
                                                                    </asp:UpdatePanel>
                                                                </InsertItemTemplate>
                                                                <HeaderStyle Wrap="False" />
                                                                <ItemStyle Wrap="False" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="N&#250;m. Int.">
                                                                <InsertItemTemplate>
                                                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:TextBox ID="tbNumInt" runat="server" Columns="15" MaxLength="15" SkinID="SkinTextBox"
                                                                                CausesValidation="True"></asp:TextBox>
                                                                        </ContentTemplate>
                                                                        <Triggers>
                                                                            <asp:AsyncPostBackTrigger ControlID="chbSN" EventName="CheckedChanged" />
                                                                        </Triggers>
                                                                    </asp:UpdatePanel>
                                                                </InsertItemTemplate>
                                                                <HeaderStyle Wrap="False" />
                                                                <ItemStyle Wrap="False" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Estado">
                                                                <InsertItemTemplate>
                                                                    <asp:DropDownList ID="ddlEstados" runat="server" SkinID="SkinDropDownList" AutoPostBack="True"
                                                                        OnSelectedIndexChanged="ddlEstados_SelectedIndexChanged">
                                                                    </asp:DropDownList>
                                                                </InsertItemTemplate>
                                                                <HeaderStyle Wrap="False" />
                                                                <ItemStyle Wrap="False" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Municipio">
                                                                <EditItemTemplate>
                                                                    &nbsp;
                                                                </EditItemTemplate>
                                                                <InsertItemTemplate>
                                                                    <asp:UpdatePanel ID="UPMunicipios" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:DropDownList ID="ddlMunicipios" runat="server" SkinID="SkinDropDownList" AutoPostBack="True"
                                                                                OnSelectedIndexChanged="ddlMunicipios_SelectedIndexChanged">
                                                                            </asp:DropDownList>
                                                                        </ContentTemplate>
                                                                        <Triggers>
                                                                            <asp:AsyncPostBackTrigger ControlID="ddlEstados" EventName="SelectedIndexChanged" />
                                                                        </Triggers>
                                                                    </asp:UpdatePanel>
                                                                </InsertItemTemplate>
                                                                <HeaderStyle Wrap="False" />
                                                                <ItemStyle Wrap="False" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Localidad">
                                                                <EditItemTemplate>
                                                                    &nbsp;
                                                                </EditItemTemplate>
                                                                <InsertItemTemplate>
                                                                    <asp:UpdatePanel ID="UPLocalidades" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:DropDownList ID="ddlLocalidades" runat="server" SkinID="SkinDropDownList" AutoPostBack="True"
                                                                                OnSelectedIndexChanged="ddlLocalidades_SelectedIndexChanged">
                                                                            </asp:DropDownList>
                                                                        </ContentTemplate>
                                                                        <Triggers>
                                                                            <asp:AsyncPostBackTrigger ControlID="ddlMunicipios" EventName="SelectedIndexChanged" />
                                                                        </Triggers>
                                                                    </asp:UpdatePanel>
                                                                </InsertItemTemplate>
                                                                <ItemTemplate>
                                                                    &nbsp;
                                                                </ItemTemplate>
                                                                <HeaderStyle Wrap="False" />
                                                                <ItemStyle Wrap="False" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Colonia">
                                                                <InsertItemTemplate>
                                                                    <asp:UpdatePanel ID="UPColonias" runat="server">
                                                                        <ContentTemplate>
                                                                            <table>
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:DropDownList ID="ddlColonias" runat="server" SkinID="SkinDropDownList" AutoPostBack="True"
                                                                                            OnSelectedIndexChanged="ddlColonias_SelectedIndexChanged">
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:CheckBox ID="chbCapturarColonia" runat="server" AutoPostBack="True" OnCheckedChanged="chbCapturarColonia_CheckedChanged"
                                                                                            SkinID="SkinCheckBox" Text="Capturar" Visible="False" />
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="2">
                                                                                        <asp:TextBox ID="tbColonia" runat="server" SkinID="SkinTextBox" Visible="False" Columns="60"
                                                                                            MaxLength="60"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="2">
                                                                                        <ajaxToolkit:AutoCompleteExtender ID="ACEColonias" runat="server" EnableCaching="true"
                                                                                            MinimumPrefixLength="2" ServiceMethod="BuscarColonias" ServicePath="~/WSBusquedas.asmx"
                                                                                            TargetControlID="tbColonia">
                                                                                        </ajaxToolkit:AutoCompleteExtender>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </ContentTemplate>
                                                                        <Triggers>
                                                                            <asp:AsyncPostBackTrigger ControlID="ddlLocalidades" EventName="SelectedIndexChanged" />
                                                                            <asp:AsyncPostBackTrigger ControlID="chbCapturarColonia" EventName="CheckedChanged" />
                                                                        </Triggers>
                                                                    </asp:UpdatePanel>
                                                                </InsertItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="C&#243;digo postal">
                                                                <InsertItemTemplate>
                                                                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:TextBox ID="tbCodPos" runat="server" Columns="10" MaxLength="10" SkinID="SkinTextBox"
                                                                                ReadOnly="True"></asp:TextBox>
                                                                        </ContentTemplate>
                                                                        <Triggers>
                                                                            <asp:AsyncPostBackTrigger ControlID="ddlColonias" EventName="SelectedIndexChanged" />
                                                                        </Triggers>
                                                                    </asp:UpdatePanel>
                                                                </InsertItemTemplate>
                                                                <HeaderStyle Wrap="False" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ShowHeader="False">
                                                                <HeaderStyle Wrap="False" />
                                                                <ItemStyle HorizontalAlign="Right" Wrap="False" />
                                                                <InsertItemTemplate>
                                                                    <ajaxToolkit:ConfirmButtonExtender ID="CBE" runat="server" ConfirmText="¿Está seguro de guardar los cambios realizados?"
                                                                        TargetControlID="btnGuardar">
                                                                    </ajaxToolkit:ConfirmButtonExtender>
                                                                    &nbsp;
                                                                    <asp:Button ID="btnGuardar" runat="server" SkinID="SkinBoton" Text="Guardar" ToolTip="Guardar información del empleado"
                                                                        OnClick="btnGuardar_Click" Width="80px" ValidationGroup="GrupoGuardar" />
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
            <table style="width: 100%">
                <tr>
                    <td style="vertical-align: middle; width: 0%; text-align: left">
                        <asp:Image ID="Image2" runat="server" ImageUrl="~/Imagenes/Symbol-Check.png" Width="100px" />
                    </td>
                    <td style="vertical-align: middle; text-align: left">
                        <asp:Label ID="lblCapturaExitosa" runat="server" SkinID="SkinLblMsjExito" Text="Operación realizada exitosamente."></asp:Label><br />
                        <br />
                        <asp:LinkButton ID="lbVerDatosPersonales" runat="server" PostBackUrl="~/Consultas/Empleados/DatosPersonales.aspx"
                            SkinID="SkinLinkButton">Ver datos capturados</asp:LinkButton>
                    </td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="viewErrores" runat="server">
            <table style="width: 100%">
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
