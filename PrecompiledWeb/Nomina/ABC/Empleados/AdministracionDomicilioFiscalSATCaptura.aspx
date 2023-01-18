<%@ page language="VB" masterpagefile="~/MasterPageSesionIniciada.master" autoeventwireup="false" inherits="ABC_Empleados_AdministracionDomicilioFiscalSATCaptura, App_Web_afkwdrmm" title="COBAEV - Nómina - Captura de domicilio fiscal de los empleados" stylesheettheme="SkinFile" culture="Auto" uiculture="Auto" maintainScrollPositionOnPostBack="true" %>

<%@ Register Src="~/WebControls/wucSearchEmps.ascx" TagName="wucBuscaEmpleados" TagPrefix="uc1" %>
<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress" TagPrefix="TP_wucUpdateProgress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
    <table style="width: 100%; height: 300px" align="center">
        <tr>
            <td style="vertical-align: top; text-align: right">
                <h2>
                    Sistema de nómina: Empleados (Información personal)
                </h2>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top; width: 100%; height: 100%; text-align: left">
                <table style="width: 100%">
                    <tr>
                        <td style="vertical-align: top; text-align: left">
                            <table style="width: 100%">
                                <tr>
                                    <td>
                                        <uc1:wucBuscaEmpleados ID="WucBuscaEmpleados1" runat="server" EnableViewState="true" />
                                    </td>
                                    <td style="vertical-align: top; text-align: right">
                                        &nbsp;<asp:ImageButton ID="ibActualizar" runat="server" ImageUrl="~/Imagenes/Refresh.jpg"
                                            ToolTip="Actualizar información" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top; text-align: left">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                <asp:Panel ID="pnlGral" runat="server">
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
                                                                                                    <asp:Label ID="Label3" runat="server" SkinID="SkinLblHeader" Text="Datos de su domicilio"></asp:Label>
                                                                                                </InsertItemTemplate>
                                                                                                <ItemStyle HorizontalAlign="Left" />
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField ShowHeader="False">
                                                                                                <InsertItemTemplate>
                                                                                                    <asp:HiddenField ID="hdIdEmp" runat="server"/>
                                                                                                </InsertItemTemplate>
                                                                                                <ItemStyle HorizontalAlign="Left" />
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="Calle">
                                                                                                <EditItemTemplate>
                                                                                                    &nbsp;
                                                                                                </EditItemTemplate>
                                                                                                <InsertItemTemplate>
                                                                                                    <asp:TextBox ID="tbCalle" runat="server" Columns="60" SkinID="SkinTextBox" MaxLength="60" Enabled="False"></asp:TextBox>
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
                                                                                                                            Columns="15" Enabled="False"></asp:TextBox>
                                                                                                                    </td>
                                                                                                                    <td>
                                                                                                                        <asp:CheckBox ID="chbSN" runat="server" AutoPostBack="True" OnCheckedChanged="chbSN_CheckedChanged"
                                                                                                                            Text="Sin número"  Enabled="False"/>
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
                                                                                                                CausesValidation="True" Enabled="False"></asp:TextBox>
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
                                                                                                        OnSelectedIndexChanged="ddlEstados_SelectedIndexChanged" Enabled="False">
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
                                                                                                                OnSelectedIndexChanged="ddlMunicipios_SelectedIndexChanged" Enabled="False">
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
                                                                                                                OnSelectedIndexChanged="ddlLocalidades_SelectedIndexChanged" Enabled="False">
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
                                                                                                                            OnSelectedIndexChanged="ddlColonias_SelectedIndexChanged" Enabled="False">
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
                                                                                                                            MaxLength="60" Enabled="False"></asp:TextBox>
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
                                                                                                                ReadOnly="True" Enabled="False"></asp:TextBox>
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

                                                                                                    <asp:Button ID="btnEditar" runat="server" SkinID="SkinBoton" Text="Editar"  ToolTip="Editar Información"
                                                                                                         OnClick="btnEditar_Click" Width="80px" />

                                                                                                    <ajaxToolkit:ConfirmButtonExtender ID="CBE" runat="server" ConfirmText="¿Está seguro de guardar los cambios realizados?"
                                                                                                        TargetControlID="btnGuardar">
                                                                                                    </ajaxToolkit:ConfirmButtonExtender>
                                                                                                    &nbsp;
                                                                                                    <asp:Button ID="btnGuardar" runat="server" SkinID="SkinBoton" Text="Guardar" ToolTip="Guardar información del empleado"
                                                                                                        OnClick="btnGuardar_Click" Width="80px" ValidationGroup="GrupoGuardar"/>
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
                                                        <asp:LinkButton ID="lbVerDatosPersonales" runat="server"
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
                                </asp:Panel>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ibActualizar" EventName="Click"></asp:AsyncPostBackTrigger>
                                    <asp:AsyncPostBackTrigger ControlID="WucBuscaEmpleados1" EventName="PreRender" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
