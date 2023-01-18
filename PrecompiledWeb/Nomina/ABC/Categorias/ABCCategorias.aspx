<%@ page language="VB" masterpagefile="~/MasterPageBlanca.master" autoeventwireup="false" inherits="ABCCategorias, App_Web_kgihrihx" title="COBAEV - Nómina - ABC Categorías" stylesheettheme="SkinFile" culture="Auto" uiculture="Auto" maintainScrollPositionOnPostBack="true" %>

<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress"
    TagPrefix="TP_wucUpdateProgress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
    <table style="width: 100%;" align="left">
        <tr>
            <td style="vertical-align: top; text-align: right">
                <h2>
                    Sistema de nómina: ABC Categorías
                </h2>
            </td>
        </tr>
        <tr>
            <td>
                <asp:UpdatePanel ID="UPNuevaCategoria" runat="server">
                    <ContentTemplate>
                        <asp:MultiView ID="MultiView1" runat="server">
                            <asp:View ID="viewCaptura" runat="server">
                                <table style="width: 100%; height: 300px" align="left">
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
                                                                        &nbsp;<asp:Label ID="lblTipoOp" runat="server"></asp:Label>
                                                                        &nbsp;<asp:Label ID="Label1" runat="server">(Mostrar detalles...)</asp:Label>
                                                                    </asp:Panel>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2" style="vertical-align: top; text-align: left;">
                                                                    <asp:Panel ID="ContentPanelDatosPers" runat="server" Width="100%" CssClass="collapsePanel">
                                                                        <asp:DetailsView ID="dvDatosCatego" runat="server" AutoGenerateRows="False" DefaultMode="Insert"
                                                                            EmptyDataText="Sin información sobre la categoría." SkinID="SkinDetailsView"
                                                                            CellPadding="0">
                                                                            <Fields>
                                                                                <asp:TemplateField HeaderText="IdCategoria" Visible="False">
                                                                                    <EditItemTemplate>
                                                                                        <asp:Label ID="lblIdCategoriaE" runat="server" Text='<%# Bind("IdCategoria") %>'
                                                                                            SkinID="SkinLblNormal"></asp:Label>
                                                                                    </EditItemTemplate>
                                                                                    <InsertItemTemplate>
                                                                                        <asp:Label ID="lblIdCategoriaI" runat="server" Text="0" SkinID="SkinLblNormal"></asp:Label>
                                                                                    </InsertItemTemplate>
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblIdCategoria" runat="server" Text='<%# Bind("IdCategoria") %>'
                                                                                            SkinID="SkinLblNormal"></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Clave de la Categoría">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblClaveCategoria" runat="server" Text='<%# Bind("ClaveCategoria") %>'
                                                                                            SkinID="SkinLblNormal"></asp:Label>
                                                                                    </ItemTemplate>
                                                                                    <InsertItemTemplate>
                                                                                        <asp:Label ID="lblClaveCategoriaI" runat="server" Text="" SkinID="SkinLblNormal"></asp:Label>
                                                                                    </InsertItemTemplate>
                                                                                    <EditItemTemplate>
                                                                                        <asp:Label ID="lblClaveCategoriaE" runat="server" Text='<%# Bind("ClaveCategoria") %>'
                                                                                            SkinID="SkinLblNormal"></asp:Label>
                                                                                    </EditItemTemplate>
                                                                                    <HeaderStyle Wrap="False" />
                                                                                    <ItemStyle Wrap="False" />
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Nombre de la Categoría">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblDescCategoria" runat="server" Text='<%# Bind("DescCategoria") %>'
                                                                                            SkinID="SkinLblNormal"></asp:Label>
                                                                                    </ItemTemplate>
                                                                                    <InsertItemTemplate>
                                                                                        <asp:TextBox ID="txtbxDescCategoriaI" runat="server" Text="" SkinID="SkinTextBox"
                                                                                            MaxLength="50" Columns="50"></asp:TextBox>
                                                                                    </InsertItemTemplate>
                                                                                    <EditItemTemplate>
                                                                                        <asp:TextBox ID="txtbxDescCategoriaE" runat="server" Text='<%# Bind("DescCategoria") %>'
                                                                                            SkinID="SkinTextBox" MaxLength="50" Columns="50"></asp:TextBox>
                                                                                    </EditItemTemplate>
                                                                                    <HeaderStyle Wrap="False" />
                                                                                    <ItemStyle Wrap="False" />
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Clave del puesto">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblPuesto" runat="server" Text='<%# Bind("Puesto") %>'
                                                                                            SkinID="SkinLblNormal"></asp:Label>
                                                                                    </ItemTemplate>
                                                                                    <InsertItemTemplate>
                                                                                        <asp:TextBox ID="txtbxPuestoI" runat="server" Text="" SkinID="SkinTextBox"
                                                                                            MaxLength="15" Columns="15"></asp:TextBox>
                                                                                    </InsertItemTemplate>
                                                                                    <EditItemTemplate>
                                                                                        <asp:TextBox ID="txtbxPuestoE" runat="server" Text='<%# Bind("Puesto") %>'
                                                                                            SkinID="SkinTextBox" MaxLength="15" Columns="15"></asp:TextBox>
                                                                                    </EditItemTemplate>
                                                                                    <HeaderStyle Wrap="False" />
                                                                                    <ItemStyle Wrap="False" />
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Tipo de Categoría">
                                                                                    <HeaderStyle Wrap="False" />
                                                                                    <ItemTemplate>
                                                                                        <asp:DropDownList ID="ddlTiposDeCatego" Enabled="false" runat="server" SkinID="SkinDropDownList">
                                                                                        </asp:DropDownList>
                                                                                    </ItemTemplate>
                                                                                    <EditItemTemplate>
                                                                                        <asp:DropDownList ID="ddlTiposDeCategoE" runat="server" 
                                                                                            SkinID="SkinDropDownList" AutoPostBack="True" 
                                                                                            onselectedindexchanged="ddlTiposDeCatego_SelectedIndexChanged">
                                                                                        </asp:DropDownList>
                                                                                    </EditItemTemplate>
                                                                                    <InsertItemTemplate>
                                                                                        <asp:DropDownList ID="ddlTiposDeCategoI" runat="server" 
                                                                                            SkinID="SkinDropDownList" AutoPostBack="True" 
                                                                                            onselectedindexchanged="ddlTiposDeCatego_SelectedIndexChanged">
                                                                                        </asp:DropDownList>
                                                                                    </InsertItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Percepción para Material Didáctico">
                                                                                    <HeaderStyle Wrap="False" />
                                                                                    <ItemTemplate>
                                                                                        <asp:DropDownList ID="ddlPercsParaMatDid" Enabled="false" runat="server" SkinID="SkinDropDownList">
                                                                                        </asp:DropDownList>
                                                                                    </ItemTemplate>
                                                                                    <EditItemTemplate>
                                                                                        <asp:DropDownList ID="ddlPercsParaMatDidE" runat="server" SkinID="SkinDropDownList">
                                                                                        </asp:DropDownList>
                                                                                    </EditItemTemplate>
                                                                                    <InsertItemTemplate>
                                                                                        <asp:DropDownList ID="ddlPercsParaMatDidI" runat="server" SkinID="SkinDropDownList">
                                                                                        </asp:DropDownList>
                                                                                    </InsertItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Percepción para descripción de Horas en Nómina">
                                                                                    <HeaderStyle Wrap="False" />
                                                                                    <ItemTemplate>
                                                                                        <asp:DropDownList ID="ddlPercsParaDescHoras" Enabled="false" runat="server" SkinID="SkinDropDownList">
                                                                                        </asp:DropDownList>
                                                                                    </ItemTemplate>
                                                                                    <EditItemTemplate>
                                                                                        <asp:DropDownList ID="ddlPercsParaDescHorasE" runat="server" SkinID="SkinDropDownList">
                                                                                        </asp:DropDownList>
                                                                                    </EditItemTemplate>
                                                                                    <InsertItemTemplate>
                                                                                        <asp:DropDownList ID="ddlPercsParaDescHorasI" runat="server" SkinID="SkinDropDownList">
                                                                                        </asp:DropDownList>
                                                                                    </InsertItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Zona económina en la que aplica">
                                                                                    <HeaderStyle Wrap="False" />
                                                                                    <ItemTemplate>
                                                                                        <asp:DropDownList ID="ddlZonasEco" Enabled="false" runat="server" SkinID="SkinDropDownList">
                                                                                        </asp:DropDownList>
                                                                                    </ItemTemplate>
                                                                                    <EditItemTemplate>
                                                                                        <asp:DropDownList ID="ddlZonasEcoE" runat="server" SkinID="SkinDropDownList">
                                                                                        </asp:DropDownList>
                                                                                    </EditItemTemplate>
                                                                                    <InsertItemTemplate>
                                                                                        <asp:DropDownList ID="ddlZonasEcoI" runat="server" SkinID="SkinDropDownList">
                                                                                        </asp:DropDownList>
                                                                                    </InsertItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Número de horas asociadas a la Categoría">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblNumHoras" runat="server" Text='<%# Bind("Horas") %>' SkinID="SkinLblNormal"></asp:Label>
                                                                                    </ItemTemplate>
                                                                                    <EditItemTemplate>
                                                                                        <asp:TextBox ID="txtbxNumHorasE" runat="server" Columns="10" MaxLength="2" SkinID="SkinTextBox"
                                                                                            CausesValidation="False" Text='<%# Bind("Horas") %>'></asp:TextBox>
                                                                                        <asp:CompareValidator ID="CVNumHoras" runat="server" ControlToValidate="txtbxNumHorasE"
                                                                                            Display="None" ErrorMessage="Número de horas incorrecto." Operator="DataTypeCheck"
                                                                                            Type="Integer" ValidationGroup="GrupoGuardar">
                                                                                        </asp:CompareValidator>
                                                                                        <asp:RangeValidator ID="RVNumHoras" runat="server" 
                                                                                            ControlToValidate="txtbxNumHorasE" Display="None" 
                                                                                            ErrorMessage="El número de horas debe estar entre 0 y 40." MaximumValue="40" 
                                                                                            MinimumValue="0" ValidationGroup="GrupoGuardar"></asp:RangeValidator>
                                                                                    </EditItemTemplate>
                                                                                    <InsertItemTemplate>
                                                                                        <asp:TextBox ID="txtbxNumHorasI" runat="server" Columns="10" MaxLength="2" SkinID="SkinTextBox"
                                                                                            CausesValidation="False"></asp:TextBox>
                                                                                        <asp:CompareValidator ID="CVNumHoras" runat="server" ControlToValidate="txtbxNumHorasI"
                                                                                            Display="None" ErrorMessage="Número de horas incorrecto." Operator="DataTypeCheck"
                                                                                            Type="Integer" ValidationGroup="GrupoGuardar">
                                                                                        </asp:CompareValidator>
                                                                                        <asp:RangeValidator ID="RVNumHoras" runat="server" 
                                                                                            ControlToValidate="txtbxNumHorasI" Display="None" 
                                                                                            ErrorMessage="El número de horas debe estar entre 0 y 40." MaximumValue="40" 
                                                                                            MinimumValue="0" ValidationGroup="GrupoGuardar"></asp:RangeValidator>
                                                                                    </InsertItemTemplate>
                                                                                    <HeaderStyle Wrap="False" />
                                                                                    <ItemStyle Wrap="False" />
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="¿Categoría de Recursos Propios?">
                                                                                    <ItemTemplate>
                                                                                        <asp:CheckBox ID="chbxRecursosPropios" runat="server" SkinID="SkinCheckBox" Checked='<%# Bind("RecursosPropios") %>'
                                                                                            Enabled="false"></asp:CheckBox>
                                                                                    </ItemTemplate>
                                                                                    <EditItemTemplate>
                                                                                        <asp:CheckBox ID="chbxRecursosPropiosE" runat="server" SkinID="SkinCheckBox" Checked='<%# Bind("RecursosPropios") %>'>
                                                                                        </asp:CheckBox>
                                                                                    </EditItemTemplate>
                                                                                    <InsertItemTemplate>
                                                                                        <asp:CheckBox ID="chbxRecursosPropiosI" runat="server" SkinID="SkinCheckBox">
                                                                                        </asp:CheckBox>
                                                                                    </InsertItemTemplate>
                                                                                    <HeaderStyle Wrap="False" />
                                                                                    <ItemStyle Wrap="True" />
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="¿Activa?">
                                                                                    <ItemTemplate>
                                                                                        <asp:CheckBox ID="chbxActiva" Enabled="false" runat="server" SkinID="SkinCheckBox"
                                                                                            Checked='<%# Bind("Activa") %>'></asp:CheckBox>
                                                                                    </ItemTemplate>
                                                                                    <EditItemTemplate>
                                                                                        <asp:CheckBox ID="chbxActivaE" runat="server" SkinID="SkinCheckBox" Checked='<%# Bind("Activa") %>'>
                                                                                        </asp:CheckBox>
                                                                                    </EditItemTemplate>
                                                                                    <InsertItemTemplate>
                                                                                        <asp:CheckBox ID="chbxActivaI" runat="server" SkinID="SkinCheckBox"></asp:CheckBox>
                                                                                    </InsertItemTemplate>
                                                                                    <HeaderStyle Wrap="False" />
                                                                                    <ItemStyle Wrap="True" />
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="¿Categoría Técnica Docente?">
                                                                                    <ItemTemplate>
                                                                                        <asp:CheckBox ID="chbxCategoriaTecnicaDocente" Enabled="false" runat="server" SkinID="SkinCheckBox"
                                                                                            Checked='<%# Bind("CategoriaTecnicaDocente") %>'></asp:CheckBox>
                                                                                    </ItemTemplate>
                                                                                    <EditItemTemplate>
                                                                                        <asp:CheckBox ID="chbxCategoriaTecnicaDocenteE" runat="server" SkinID="SkinCheckBox" Checked='<%# Bind("CategoriaTecnicaDocente") %>'>
                                                                                        </asp:CheckBox>
                                                                                    </EditItemTemplate>
                                                                                    <InsertItemTemplate>
                                                                                        <asp:CheckBox ID="chbxCategoriaTecnicaDocenteI" runat="server" SkinID="SkinCheckBox"></asp:CheckBox>
                                                                                    </InsertItemTemplate>
                                                                                    <HeaderStyle Wrap="False" />
                                                                                    <ItemStyle Wrap="True" />
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="¿Tiene asociada Categoría de Recursos Propios?">
                                                                                    <ItemTemplate>
                                                                                        <asp:CheckBox ID="chbxTieneCategoAsocRP" Enabled="false" runat="server" SkinID="SkinCheckBox"
                                                                                            Checked='<%# Bind("TieneCategoAsocRP") %>'></asp:CheckBox></ItemTemplate>
                                                                                    <EditItemTemplate>
                                                                                        <asp:CheckBox ID="chbxTieneCategoAsocRPE" runat="server" SkinID="SkinCheckBox" AutoPostBack="True"
                                                                                            OnCheckedChanged="chbxTieneCategoAsocRP_CheckedChanged" Checked='<%# Bind("TieneCategoAsocRP") %>'>
                                                                                        </asp:CheckBox></EditItemTemplate>
                                                                                    <InsertItemTemplate>
                                                                                        <asp:CheckBox ID="chbxTieneCategoAsocRPI" runat="server" SkinID="SkinCheckBox" AutoPostBack="True"
                                                                                            OnCheckedChanged="chbxTieneCategoAsocRP_CheckedChanged"></asp:CheckBox></InsertItemTemplate>
                                                                                    <HeaderStyle Wrap="False" />
                                                                                    <ItemStyle Wrap="false" />
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Seleccione la Categoría de Recursos Propios">
                                                                                    <HeaderStyle Wrap="False" />
                                                                                    <ItemTemplate>
                                                                                        <asp:DropDownList ID="ddlCategosRP" runat="server" SkinID="SkinDropDownList"
                                                                                            Enabled="false">
                                                                                        </asp:DropDownList>
                                                                                    </ItemTemplate>
                                                                                    <EditItemTemplate>
                                                                                        <asp:DropDownList ID="ddlCategosRPE" runat="server" SkinID="SkinDropDownList"
                                                                                            Enabled="false">
                                                                                        </asp:DropDownList>
                                                                                    </EditItemTemplate>
                                                                                    <InsertItemTemplate>
                                                                                        <asp:DropDownList ID="ddlCategosRPI" runat="server" SkinID="SkinDropDownList"
                                                                                            Enabled="false">
                                                                                        </asp:DropDownList>
                                                                                    </InsertItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Seleccione la función primaria asociada a la Categoría">
                                                                                    <ItemTemplate>
                                                                                        <asp:DropDownList ID="ddlFuncsPrim" runat="server" SkinID="SkinDropDownList" Enabled="false">
                                                                                        </asp:DropDownList>
                                                                                    </ItemTemplate>
                                                                                    <EditItemTemplate>
                                                                                        <asp:DropDownList ID="ddlFuncsPrimE" runat="server" SkinID="SkinDropDownList">
                                                                                        </asp:DropDownList>
                                                                                    </EditItemTemplate>
                                                                                    <InsertItemTemplate>
                                                                                        <asp:DropDownList ID="ddlFuncsPrimI" runat="server" SkinID="SkinDropDownList">
                                                                                        </asp:DropDownList>
                                                                                    </InsertItemTemplate>
                                                                                    <HeaderStyle Wrap="False" />
                                                                                </asp:TemplateField>                                                                                
                                                                                <asp:TemplateField HeaderText="¿Es Categoría Homologada?">
                                                                                    <ItemTemplate>
                                                                                        <asp:CheckBox ID="chbxEsCategoHomologada" Enabled="false" runat="server" SkinID="SkinCheckBox"
                                                                                            Checked='<%# Bind("EsCategoHomologada") %>'></asp:CheckBox>
                                                                                    </ItemTemplate>
                                                                                    <EditItemTemplate>
                                                                                        <asp:CheckBox ID="chbxEsCategoHomologadaE" runat="server" SkinID="SkinCheckBox" Checked='<%# Bind("EsCategoHomologada") %>'>
                                                                                        </asp:CheckBox>
                                                                                    </EditItemTemplate>
                                                                                    <InsertItemTemplate>
                                                                                        <asp:CheckBox ID="chbxEsCategoHomologadaI" runat="server" SkinID="SkinCheckBox"></asp:CheckBox>
                                                                                    </InsertItemTemplate>
                                                                                    <HeaderStyle Wrap="False" />
                                                                                    <ItemStyle Wrap="True" />
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField ShowHeader="False">
                                                                                    <HeaderStyle Wrap="False" />
                                                                                    <ItemStyle HorizontalAlign="Right" Wrap="False" />
                                                                                    <EditItemTemplate>
                                                                                        <ajaxToolkit:ConfirmButtonExtender ID="CBEE" runat="server" ConfirmText="¿Está seguro de guardar los cambios realizados?"
                                                                                            TargetControlID="btnGuardarE">
                                                                                        </ajaxToolkit:ConfirmButtonExtender>
                                                                                        <asp:Button ID="btnGuardarE" runat="server" SkinID="SkinBoton" Text="Guardar" ToolTip="Guardar información  de la Categoría"
                                                                                            OnClick="btnGuardar_Click" Width="80px" ValidationGroup="GrupoGuardar" />
                                                                                        <asp:ValidationSummary ID="VSGrupoGuardarE" runat="server" ShowMessageBox="True"
                                                                                            ShowSummary="False" ValidationGroup="GrupoGuardar" />
                                                                                    </EditItemTemplate>
                                                                                    <InsertItemTemplate>
                                                                                        <ajaxToolkit:ConfirmButtonExtender ID="CBEI" runat="server" ConfirmText="¿Está seguro de guardar los cambios realizados?"
                                                                                            TargetControlID="btnGuardarI">
                                                                                        </ajaxToolkit:ConfirmButtonExtender>
                                                                                        <asp:Button ID="btnGuardarI" runat="server" SkinID="SkinBoton" Text="Guardar" ToolTip="Guardar información de la Categoría"
                                                                                            OnClick="btnGuardar_Click" Width="80px" ValidationGroup="GrupoGuardar" /><asp:ValidationSummary
                                                                                                ID="VSGrupoGuardarI" runat="server" ShowMessageBox="True" ShowSummary="False"
                                                                                                ValidationGroup="GrupoGuardar" />
                                                                                    </InsertItemTemplate>
                                                                                </asp:TemplateField>
                                                                            </Fields>
                                                                            <HeaderStyle Wrap="True" />
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
                                            <asp:Label ID="lblCapturaExitosa" runat="server" SkinID="SkinLblMsjExito" Text="Operación realizada exitosamente."></asp:Label>
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
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
    <br />
</asp:Content>
