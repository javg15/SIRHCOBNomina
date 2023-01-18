<%@ page language="VB" masterpagefile="~/MasterPageSesionIniciada.master" autoeventwireup="false" inherits="ABCDeducciones, App_Web_bjue1s5v" title="COBAEV - Nómina - ABC Deducciones" stylesheettheme="SkinFile" culture="Auto" uiculture="Auto" maintainScrollPositionOnPostBack="true" %>

<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress"
    TagPrefix="TP_wucUpdateProgress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
    <div>
    <table style="width: 100%; height: 100%;" align="left">
        <tr>
            <td style="vertical-align: top; text-align: right">
                <h2>
                    Sistema de nómina: ABC Deducciones
                </h2>
            </td>
        </tr>
        <tr>
            <td>
                <asp:UpdatePanel ID="UPNuevaDeduccion" runat="server">
                    <ContentTemplate>
                        <asp:MultiView ID="MultiView1" runat="server">
                            <asp:View ID="viewCaptura" runat="server">
                                <table style="width: 100%;" align="left">
                                    <tr>
                                        <td style="vertical-align: top; width: 100%; text-align: left">
                                            <table style="width: 100%">
                                                <tr>
                                                    <td style="vertical-align: top; text-align: left;">
                                                        <ajaxToolkit:CollapsiblePanelExtender ID="CPEDatosPersonales" runat="Server" CollapseControlID="TitlePanelDatosPers"
                                                            Collapsed="False" CollapsedImage="~/Imagenes/expand_blue.jpg" CollapsedText="(Mostrar panel...)"
                                                            ExpandControlID="TitlePanelDatosPers" ExpandedImage="~/Imagenes/collapse_blue.jpg"
                                                            ExpandedText="(Ocultar panel...)" ImageControlID="Image1" SuppressPostBack="true"
                                                            TargetControlID="ContentPanelDatosDeduc" TextLabelID="Label1">
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
                                                                    <asp:Panel ID="ContentPanelDatosDeduc" runat="server" Width="100%" CssClass="collapsePanel">
                                                                        <asp:DetailsView ID="dvDatosDeduc" runat="server" AutoGenerateRows="False" DefaultMode="Insert"
                                                                            EmptyDataText="Sin información de Deducción" SkinID="SkinDetailsView" CellPadding="0">
                                                                            <Fields>
                                                                                <asp:TemplateField HeaderText="IdDeduccion" Visible="False">
                                                                                    <EditItemTemplate>
                                                                                        <asp:Label ID="lblIdDeduccionE" runat="server" Text='<%# Bind("IdDeduccion") %>'
                                                                                            SkinID="SkinLblNormal"></asp:Label>
                                                                                    </EditItemTemplate>
                                                                                    <InsertItemTemplate>
                                                                                        <asp:Label ID="lblIdDeduccionI" runat="server" Text="0" SkinID="SkinLblNormal"></asp:Label>
                                                                                    </InsertItemTemplate>
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblIdDeduccion" runat="server" Text='<%# Bind("IdDeduccion") %>' SkinID="SkinLblNormal"></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Clave de la deducción">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblClaveDeduccion" runat="server" Text='<%# Bind("ClaveDeduccion") %>'
                                                                                            SkinID="SkinLblNormal"></asp:Label>
                                                                                    </ItemTemplate>
                                                                                    <InsertItemTemplate>
                                                                                        <asp:Label ID="lblClaveDeduccionI" runat="server" Text="" SkinID="SkinLblNormal"></asp:Label>
                                                                                    </InsertItemTemplate>
                                                                                    <EditItemTemplate>
                                                                                        <asp:Label ID="lblClaveDeduccionE" runat="server" Text='<%# Bind("ClaveDeduccion") %>'
                                                                                            SkinID="SkinLblNormal"></asp:Label>
                                                                                    </EditItemTemplate>
                                                                                    <HeaderStyle Wrap="False" />
                                                                                    <ItemStyle Wrap="False" />
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Nombre de la deducción">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblNombreDeduccion" runat="server" Text='<%# Bind("NombreDeduccion") %>'
                                                                                            SkinID="SkinLblNormal"></asp:Label>
                                                                                    </ItemTemplate>
                                                                                    <InsertItemTemplate>
                                                                                        <asp:TextBox ID="txtbxNombreDeduccionI" runat="server" Text="" SkinID="SkinTextBox"
                                                                                            MaxLength="50" Columns="80"></asp:TextBox>
                                                                                    </InsertItemTemplate>
                                                                                    <EditItemTemplate>
                                                                                        <asp:TextBox ID="txtbxNombreDeduccionE" runat="server" Text='<%# Bind("NombreDeduccion") %>'
                                                                                            SkinID="SkinTextBox" MaxLength="50" Columns="80"></asp:TextBox>
                                                                                    </EditItemTemplate>
                                                                                    <HeaderStyle Wrap="False" />
                                                                                    <ItemStyle Wrap="False" />
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="SP para cálculo">
                                                                                    <ItemTemplate>
                                                                                        <asp:DropDownList ID="ddlSPs" runat="server" SkinID="SkinDropDownList" Enabled="false">
                                                                                        </asp:DropDownList>
                                                                                    </ItemTemplate>
                                                                                    <EditItemTemplate>
                                                                                        <asp:DropDownList ID="ddlSPsE" runat="server" SkinID="SkinDropDownList">
                                                                                        </asp:DropDownList>
                                                                                    </EditItemTemplate>
                                                                                    <InsertItemTemplate>
                                                                                        <asp:DropDownList ID="ddlSPsI" runat="server" SkinID="SkinDropDownList">
                                                                                        </asp:DropDownList>
                                                                                    </InsertItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="¿Mostrar para captura?">
                                                                                    <ItemTemplate>
                                                                                        <asp:CheckBox ID="chbxMostrarParaCaptura" runat="server" SkinID="SkinCheckBox" Checked='<%# Bind("MostrarParaCaptura") %>'
                                                                                            Enabled="false"></asp:CheckBox>
                                                                                    </ItemTemplate>
                                                                                    <EditItemTemplate>
                                                                                        <asp:CheckBox ID="chbxMostrarParaCapturaE" runat="server" SkinID="SkinCheckBox" Checked='<%# Bind("MostrarParaCaptura") %>'>
                                                                                        </asp:CheckBox>
                                                                                    </EditItemTemplate>
                                                                                    <InsertItemTemplate>
                                                                                        <asp:CheckBox ID="chbxMostrarParaCapturaI" runat="server" SkinID="SkinCheckBox">
                                                                                        </asp:CheckBox>
                                                                                    </InsertItemTemplate>
                                                                                    <HeaderStyle Wrap="False" />
                                                                                    <ItemStyle Wrap="True" />
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Ambito de aplicación">
                                                                                    <ItemTemplate>
                                                                                        <asp:DropDownList ID="ddlAmbitoAplic" Enabled="false" runat="server" SkinID="SkinDropDownList">
                                                                                        </asp:DropDownList>
                                                                                    </ItemTemplate>
                                                                                    <EditItemTemplate>
                                                                                        <asp:DropDownList ID="ddlAmbitoAplicE" runat="server" SkinID="SkinDropDownList">
                                                                                        </asp:DropDownList>
                                                                                    </EditItemTemplate>
                                                                                    <InsertItemTemplate>
                                                                                        <asp:DropDownList ID="ddlAmbitoAplicI" runat="server" SkinID="SkinDropDownList">
                                                                                        </asp:DropDownList>
                                                                                    </InsertItemTemplate>
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
                                                                                <asp:TemplateField HeaderText="¿Efectos abiertos?">
                                                                                    <ItemTemplate>
                                                                                        <asp:CheckBox ID="chbxEfectosAbiertos" Enabled="false" runat="server" SkinID="SkinCheckBox"
                                                                                            Checked='<%# Bind("EfectosAbiertos") %>'></asp:CheckBox>
                                                                                    </ItemTemplate>
                                                                                    <EditItemTemplate>
                                                                                        <asp:CheckBox ID="chbxEfectosAbiertosE" runat="server" SkinID="SkinCheckBox" Checked='<%# Bind("EfectosAbiertos") %>'>
                                                                                        </asp:CheckBox>
                                                                                    </EditItemTemplate>
                                                                                    <InsertItemTemplate>
                                                                                        <asp:CheckBox ID="chbxEfectosAbiertosI" runat="server" SkinID="SkinCheckBox"></asp:CheckBox>
                                                                                    </InsertItemTemplate>
                                                                                    <HeaderStyle Wrap="False" />
                                                                                    <ItemStyle Wrap="True" />
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Quincenas durante las que se descontará a un empleado">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblNumQnas" runat="server" Text='<%# Bind("NumQnas") %>' SkinID="SkinLblNormal"></asp:Label>
                                                                                    </ItemTemplate>
                                                                                    <EditItemTemplate>
                                                                                        <asp:TextBox ID="txtbxNumQnasE" runat="server" Columns="10" MaxLength="2" SkinID="SkinTextBox"
                                                                                            CausesValidation="False" Text='<%# Bind("NumQnas") %>'></asp:TextBox>
                                                                                        <asp:CompareValidator ID="CVNumQnas" runat="server" ControlToValidate="txtbxNumQnasE"
                                                                                            Display="None" ErrorMessage="Número de quincenas incorrecto." Operator="DataTypeCheck"
                                                                                            Type="Integer" ValidationGroup="GrupoGuardar">
                                                                                        </asp:CompareValidator>
                                                                                    </EditItemTemplate>
                                                                                    <InsertItemTemplate>
                                                                                        <asp:TextBox ID="txtbxNumQnasI" runat="server" Columns="10" MaxLength="2" SkinID="SkinTextBox"
                                                                                            CausesValidation="False"></asp:TextBox>
                                                                                        <asp:CompareValidator ID="CVNumQnas" runat="server" ControlToValidate="txtbxNumQnasI"
                                                                                            Display="None" ErrorMessage="Número de quincenas incorrecto." Operator="DataTypeCheck"
                                                                                            Type="Integer" ValidationGroup="GrupoGuardar">
                                                                                        </asp:CompareValidator>
                                                                                    </InsertItemTemplate>
                                                                                    <HeaderStyle Wrap="False" />
                                                                                    <ItemStyle Wrap="False" />
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Tipo de empleado al que aplica">
                                                                                    <HeaderStyle Wrap="False" />
                                                                                    <ItemTemplate>
                                                                                        <asp:DropDownList ID="ddlTiposDeEmp" Enabled="false" runat="server" SkinID="SkinDropDownList">
                                                                                        </asp:DropDownList>
                                                                                    </ItemTemplate>
                                                                                    <EditItemTemplate>
                                                                                        <asp:DropDownList ID="ddlTiposDeEmpE" runat="server" SkinID="SkinDropDownList">
                                                                                        </asp:DropDownList>
                                                                                    </EditItemTemplate>
                                                                                    <InsertItemTemplate>
                                                                                        <asp:DropDownList ID="ddlTiposDeEmpI" runat="server" SkinID="SkinDropDownList">
                                                                                        </asp:DropDownList>
                                                                                    </InsertItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Zona económina a en la que aplica">
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
                                                                                <asp:TemplateField HeaderText="¿Es masiva?">
                                                                                    <ItemTemplate>
                                                                                        <asp:CheckBox ID="chbxMasiva" Enabled="false" runat="server" SkinID="SkinCheckBox"
                                                                                            Checked='<%# Bind("Masiva") %>'></asp:CheckBox>
                                                                                    </ItemTemplate>
                                                                                    <EditItemTemplate>
                                                                                        <asp:CheckBox ID="chbxMasivaE" runat="server" SkinID="SkinCheckBox" Checked='<%# Bind("Masiva") %>'>
                                                                                        </asp:CheckBox>
                                                                                    </EditItemTemplate>
                                                                                    <InsertItemTemplate>
                                                                                        <asp:CheckBox ID="chbxMasivaI" runat="server" SkinID="SkinCheckBox"></asp:CheckBox>
                                                                                    </InsertItemTemplate>
                                                                                    <HeaderStyle Wrap="False" />
                                                                                    <ItemStyle Wrap="True" />
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="¿Calcular como vigente?">
                                                                                    <ItemTemplate>
                                                                                        <asp:CheckBox ID="chbxCalcularComoVigente" Enabled="false" runat="server" SkinID="SkinCheckBox"
                                                                                            Checked='<%# Bind("CalcularComoVigente") %>'></asp:CheckBox>
                                                                                    </ItemTemplate>
                                                                                    <EditItemTemplate>
                                                                                        <asp:CheckBox ID="chbxCalcularComoVigenteE" runat="server" SkinID="SkinCheckBox"
                                                                                            Checked='<%# Bind("CalcularComoVigente") %>'></asp:CheckBox>
                                                                                    </EditItemTemplate>
                                                                                    <InsertItemTemplate>
                                                                                        <asp:CheckBox ID="chbxCalcularComoVigenteI" runat="server" SkinID="SkinCheckBox">
                                                                                        </asp:CheckBox>
                                                                                    </InsertItemTemplate>
                                                                                    <HeaderStyle Wrap="False" />
                                                                                    <ItemStyle Wrap="True" />
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="URL">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblURL" runat="server" SkinID="SkinLblNormal" Text='<%# Bind("URL") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                    <EditItemTemplate>
                                                                                        <asp:TextBox ID="txtbxURLE" runat="server" SkinID="SkinTextBox" MaxLength="50" Columns="80"
                                                                                            AutoPostBack="False" Text='<%# Bind("URL") %>'></asp:TextBox>
                                                                                    </EditItemTemplate>
                                                                                    <InsertItemTemplate>
                                                                                        <asp:TextBox ID="txtbxURLI" runat="server" SkinID="SkinTextBox" MaxLength="50" Columns="80"
                                                                                            AutoPostBack="False" Text=""></asp:TextBox>
                                                                                    </InsertItemTemplate>
                                                                                    <HeaderStyle Wrap="False" />
                                                                                    <ItemStyle Wrap="False" />
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="¿Es descripción de horas para recibo de pago?">
                                                                                    <ItemTemplate>
                                                                                        <asp:DropDownList ID="ddlHoras" Enabled="false" runat="server" SkinID="SkinDropDownList">
                                                                                            <asp:ListItem Value="S" Text="SI"></asp:ListItem>
                                                                                            <asp:ListItem Value="N" Text="NO"></asp:ListItem>
                                                                                        </asp:DropDownList>
                                                                                    </ItemTemplate>
                                                                                    <EditItemTemplate>
                                                                                        <asp:DropDownList ID="ddlHorasE" runat="server" SkinID="SkinDropDownList">
                                                                                            <asp:ListItem Value="S" Text="SI"></asp:ListItem>
                                                                                            <asp:ListItem Value="N" Text="NO"></asp:ListItem>
                                                                                        </asp:DropDownList>
                                                                                    </EditItemTemplate>
                                                                                    <InsertItemTemplate>
                                                                                        <asp:DropDownList ID="ddlHorasI" runat="server" SkinID="SkinDropDownList">
                                                                                            <asp:ListItem Value="S" Text="SI" Selected="True"></asp:ListItem>
                                                                                            <asp:ListItem Value="N" Text="NO"></asp:ListItem>
                                                                                        </asp:DropDownList>
                                                                                    </InsertItemTemplate>
                                                                                    <HeaderStyle Wrap="False" />
                                                                                    <ItemStyle Wrap="True" />
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="¿Incluir para corrección automática de importes netos negativos?">
                                                                                    <ItemTemplate>
                                                                                        <asp:CheckBox ID="chbxIncluirParaNegativos" runat="server" SkinID="SkinCheckBox"
                                                                                            Enabled="false" Checked='<%# Bind("DosPorcNomina") %>'></asp:CheckBox>
                                                                                    </ItemTemplate>
                                                                                    <EditItemTemplate>
                                                                                        <asp:CheckBox ID="chbxIncluirParaNegativosE" runat="server" SkinID="SkinCheckBox"
                                                                                            Checked='<%# Bind("IncluirParaNegativos") %>'></asp:CheckBox>
                                                                                    </EditItemTemplate>
                                                                                    <InsertItemTemplate>
                                                                                        <asp:CheckBox ID="chbxIncluirParaNegativosI" runat="server" SkinID="SkinCheckBox">
                                                                                        </asp:CheckBox>
                                                                                    </InsertItemTemplate>
                                                                                    <HeaderStyle Wrap="False" />
                                                                                    <ItemStyle Wrap="True" />
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Clasificación interna de la Deducción (para corregir importes netos negativos)">
                                                                                    <HeaderStyle Wrap="False" />
                                                                                    <ItemTemplate>
                                                                                        <asp:DropDownList ID="ddlClasifDeduc" Enabled="false" runat="server" SkinID="SkinDropDownList">
                                                                                        </asp:DropDownList>
                                                                                    </ItemTemplate>
                                                                                    <EditItemTemplate>
                                                                                        <asp:DropDownList ID="ddlClasifDeducE" runat="server" SkinID="SkinDropDownList">
                                                                                        </asp:DropDownList>
                                                                                    </EditItemTemplate>
                                                                                    <InsertItemTemplate>
                                                                                        <asp:DropDownList ID="ddlClasifDeducI" runat="server" SkinID="SkinDropDownList">
                                                                                        </asp:DropDownList>
                                                                                    </InsertItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="¿Participa para el cálculo del 2% a la nómina?">
                                                                                    <ItemTemplate>
                                                                                        <asp:CheckBox ID="chbxDosPorcNomina" runat="server" SkinID="SkinCheckBox" Enabled="false"
                                                                                            Checked='<%# Bind("DosPorcNomina") %>'></asp:CheckBox>
                                                                                    </ItemTemplate>
                                                                                    <EditItemTemplate>
                                                                                        <asp:CheckBox ID="chbxDosPorcNominaE" runat="server" SkinID="SkinCheckBox" Checked='<%# Bind("DosPorcNomina") %>'>
                                                                                        </asp:CheckBox>
                                                                                    </EditItemTemplate>
                                                                                    <InsertItemTemplate>
                                                                                        <asp:CheckBox ID="chbxDosPorcNominaI" runat="server" SkinID="SkinCheckBox"></asp:CheckBox>
                                                                                    </InsertItemTemplate>
                                                                                    <HeaderStyle Wrap="False" />
                                                                                    <ItemStyle Wrap="True" />
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="¿Válida para RP?">
                                                                                    <ItemTemplate>
                                                                                        <asp:CheckBox ID="chbxValidaParaRP" runat="server" SkinID="SkinCheckBox" Enabled="false"
                                                                                            Checked='<%# Bind("ValidaParaRP") %>'></asp:CheckBox>
                                                                                    </ItemTemplate>
                                                                                    <EditItemTemplate>
                                                                                        <asp:CheckBox ID="chbxValidaParaRPE" runat="server" SkinID="SkinCheckBox" Checked='<%# Bind("ValidaParaRP") %>'>
                                                                                        </asp:CheckBox>
                                                                                    </EditItemTemplate>
                                                                                    <InsertItemTemplate>
                                                                                        <asp:CheckBox ID="chbxValidaParaRPI" runat="server" SkinID="SkinCheckBox"></asp:CheckBox>
                                                                                    </InsertItemTemplate>
                                                                                    <HeaderStyle Wrap="False" />
                                                                                    <ItemStyle Wrap="True" />
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="¿Tiene deducción padre?">
                                                                                    <ItemTemplate>
                                                                                        <asp:CheckBox ID="chbxTieneDeducPadre" runat="server" SkinID="SkinCheckBox" Enabled="false"
                                                                                            Checked='<%# Bind("TieneDeduccionPadre") %>'></asp:CheckBox>
                                                                                    </ItemTemplate>
                                                                                    <EditItemTemplate>
                                                                                        <asp:CheckBox ID="chbxTieneDeducPadreE" runat="server" SkinID="SkinCheckBox" AutoPostBack="true"
                                                                                            OnCheckedChanged="chbxTieneDeducPadre_CheckedChanged" Checked='<%# Bind("TieneDeduccionPadre") %>'>
                                                                                        </asp:CheckBox>
                                                                                    </EditItemTemplate>
                                                                                    <InsertItemTemplate>
                                                                                        <asp:CheckBox ID="chbxTieneDeducPadreI" runat="server" SkinID="SkinCheckBox" AutoPostBack="true"
                                                                                            OnCheckedChanged="chbxTieneDeducPadre_CheckedChanged"></asp:CheckBox>
                                                                                    </InsertItemTemplate>
                                                                                    <HeaderStyle Wrap="False" />
                                                                                    <ItemStyle Wrap="True" />
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Deducción padre">
                                                                                    <HeaderStyle Wrap="False" />
                                                                                    <ItemTemplate>
                                                                                        <asp:DropDownList ID="ddlDeducsPadre" Enabled="false" runat="server" SkinID="SkinDropDownList">
                                                                                        </asp:DropDownList>
                                                                                    </ItemTemplate>
                                                                                    <EditItemTemplate>
                                                                                        <asp:DropDownList ID="ddlDeducsPadreE" runat="server" SkinID="SkinDropDownList">
                                                                                        </asp:DropDownList>
                                                                                    </EditItemTemplate>
                                                                                    <InsertItemTemplate>
                                                                                        <asp:DropDownList ID="ddlDeducsPadreI" runat="server" SkinID="SkinDropDownList">
                                                                                        </asp:DropDownList>
                                                                                    </InsertItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="¿Es Deducción por Ley?">
                                                                                    <ItemTemplate>
                                                                                        <asp:CheckBox ID="chbxDeduccionPorLey" Enabled="false" Checked='<%# Bind("DeduccionPorLey") %>'
                                                                                            runat="server" SkinID="SkinCheckBox"></asp:CheckBox>
                                                                                    </ItemTemplate>
                                                                                    <EditItemTemplate>
                                                                                        <asp:CheckBox ID="chbxDeduccionPorLeyE" Checked='<%# Bind("DeduccionPorLey") %>'
                                                                                            runat="server" SkinID="SkinCheckBox"></asp:CheckBox>
                                                                                    </EditItemTemplate>
                                                                                    <InsertItemTemplate>
                                                                                        <asp:CheckBox ID="chbxDeduccionPorLeyI" runat="server" SkinID="SkinCheckBox"></asp:CheckBox>
                                                                                    </InsertItemTemplate>
                                                                                    <HeaderStyle Wrap="False" />
                                                                                    <ItemStyle Wrap="True" />
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="¿Incluir para recibos de pago fuera de nómina?">
                                                                                    <ItemTemplate>
                                                                                        <asp:CheckBox ID="chbxIncluirParaRecibos" Enabled="false" runat="server" SkinID="SkinCheckBox"
                                                                                            Checked='<%# Bind("IncluirParaRecibos") %>'></asp:CheckBox>
                                                                                    </ItemTemplate>
                                                                                    <EditItemTemplate>
                                                                                        <asp:CheckBox ID="chbxIncluirParaRecibosE" runat="server" SkinID="SkinCheckBox" Checked='<%# Bind("IncluirParaRecibos") %>'>
                                                                                        </asp:CheckBox>
                                                                                    </EditItemTemplate>
                                                                                    <InsertItemTemplate>
                                                                                        <asp:CheckBox ID="chbxIncluirParaRecibosI" runat="server" SkinID="SkinCheckBox">
                                                                                        </asp:CheckBox>
                                                                                    </InsertItemTemplate>
                                                                                    <HeaderStyle Wrap="False" />
                                                                                    <ItemStyle Wrap="True" />
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="¿Es concepto indemnizatorio?">
                                                                                    <ItemTemplate>
                                                                                        <asp:CheckBox ID="chbxConceptoIndemnizatorio" Enabled="false" runat="server" SkinID="SkinCheckBox"
                                                                                            Checked='<%# Bind("ConceptoIndemnizatorio") %>'></asp:CheckBox>
                                                                                    </ItemTemplate>
                                                                                    <EditItemTemplate>
                                                                                        <asp:CheckBox ID="chbxConceptoIndemnizatorioE" runat="server" SkinID="SkinCheckBox"
                                                                                            Checked='<%# Bind("ConceptoIndemnizatorio") %>'></asp:CheckBox>
                                                                                    </EditItemTemplate>
                                                                                    <InsertItemTemplate>
                                                                                        <asp:CheckBox ID="chbxConceptoIndemnizatorioI" runat="server" SkinID="SkinCheckBox">
                                                                                        </asp:CheckBox></InsertItemTemplate>
                                                                                    <HeaderStyle Wrap="False" />
                                                                                    <ItemStyle Wrap="True" />
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Forma de descuento primaria (Administrativos/Directivos)">
                                                                                    <HeaderStyle Wrap="False" />
                                                                                    <ItemTemplate>
                                                                                        <asp:DropDownList ID="ddlFormasDePago1A" Enabled="false" runat="server" SkinID="SkinDropDownList">
                                                                                        </asp:DropDownList>
                                                                                    </ItemTemplate>
                                                                                    <EditItemTemplate>
                                                                                        <asp:DropDownList ID="ddlFormasDePago1AE" runat="server" SkinID="SkinDropDownList">
                                                                                        </asp:DropDownList>
                                                                                    </EditItemTemplate>
                                                                                    <InsertItemTemplate>
                                                                                        <asp:DropDownList ID="ddlFormasDePago1AI" runat="server" SkinID="SkinDropDownList">
                                                                                        </asp:DropDownList>
                                                                                    </InsertItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Forma de descuento primaria (Docentes)">
                                                                                    <HeaderStyle Wrap="False" />
                                                                                    <ItemTemplate>
                                                                                        <asp:DropDownList ID="ddlFormasDePago1D" Enabled="false" runat="server" SkinID="SkinDropDownList">
                                                                                        </asp:DropDownList>
                                                                                    </ItemTemplate>
                                                                                    <EditItemTemplate>
                                                                                        <asp:DropDownList ID="ddlFormasDePago1DE" runat="server" SkinID="SkinDropDownList">
                                                                                        </asp:DropDownList>
                                                                                    </EditItemTemplate>
                                                                                    <InsertItemTemplate>
                                                                                        <asp:DropDownList ID="ddlFormasDePago1DI" runat="server" SkinID="SkinDropDownList">
                                                                                        </asp:DropDownList>
                                                                                    </InsertItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="¿Es clave de devolución (a la empresa) de alguna percepción ordinaria?">
                                                                                    <ItemTemplate>
                                                                                        <asp:CheckBox ID="chbxSeraDeducDeDevol" runat="server" SkinID="SkinCheckBox" Enabled="false"
                                                                                            Checked='<%# Bind("EsPercDevolDePerc") %>'></asp:CheckBox></ItemTemplate>
                                                                                    <EditItemTemplate>
                                                                                        <asp:CheckBox ID="chbxSeraDeducDeDevolE" runat="server" SkinID="SkinCheckBox" AutoPostBack="true"
                                                                                            OnCheckedChanged="chbxSeraDeducDeDevol_CheckedChanged" Checked='<%# Bind("EsPercDevolDePerc") %>'>
                                                                                        </asp:CheckBox></EditItemTemplate>
                                                                                    <InsertItemTemplate>
                                                                                        <asp:CheckBox ID="chbxSeraDeducDeDevolI" runat="server" SkinID="SkinCheckBox" AutoPostBack="true"
                                                                                            OnCheckedChanged="chbxSeraDeducDeDevol_CheckedChanged"></asp:CheckBox></InsertItemTemplate>
                                                                                    <HeaderStyle Wrap="False" />
                                                                                    <ItemStyle Wrap="True" />
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Percepción ordinaria a la cual se relacionará como devolución (a la empresa)">
                                                                                    <HeaderStyle Wrap="False" />
                                                                                    <ItemTemplate>
                                                                                        <asp:DropDownList ID="ddlPercsParaRelComoDevol" Enabled="false" runat="server" SkinID="SkinDropDownList">
                                                                                        </asp:DropDownList>
                                                                                    </ItemTemplate>
                                                                                    <EditItemTemplate>
                                                                                        <asp:DropDownList ID="ddlPercsParaRelComoDevolE" runat="server" SkinID="SkinDropDownList">
                                                                                        </asp:DropDownList>
                                                                                    </EditItemTemplate>
                                                                                    <InsertItemTemplate>
                                                                                        <asp:DropDownList ID="ddlPercsParaRelComoDevolI" runat="server" SkinID="SkinDropDownList">
                                                                                        </asp:DropDownList>
                                                                                    </InsertItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="¿Tiene percepción (no ordinaria) de devolución al empleado?">
                                                                                    <ItemTemplate>
                                                                                        <asp:CheckBox ID="chbxDeduccionContraria" Enabled="false" runat="server" SkinID="SkinCheckBox"
                                                                                            Checked='<%# Bind("TienePercNoOrdParaDevol") %>'></asp:CheckBox></ItemTemplate>
                                                                                    <EditItemTemplate>
                                                                                        <asp:CheckBox ID="chbxDeduccionContrariaE" runat="server" SkinID="SkinCheckBox" AutoPostBack="True"
                                                                                            OnCheckedChanged="chbxDeduccionContraria_CheckedChanged" Checked='<%# Bind("TienePercNoOrdParaDevol") %>'>
                                                                                        </asp:CheckBox></EditItemTemplate>
                                                                                    <InsertItemTemplate>
                                                                                        <asp:CheckBox ID="chbxDeduccionContrariaI" runat="server" SkinID="SkinCheckBox" AutoPostBack="True"
                                                                                            OnCheckedChanged="chbxDeduccionContraria_CheckedChanged"></asp:CheckBox></InsertItemTemplate>
                                                                                    <HeaderStyle Wrap="False" />
                                                                                    <ItemStyle Wrap="false" />
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Seleccione la percepción (no ordinaria) de devolución al empleado">
                                                                                    <HeaderStyle Wrap="False" />
                                                                                    <ItemTemplate>
                                                                                        <asp:DropDownList ID="ddlDeducsContrarias" runat="server" SkinID="SkinDropDownList"
                                                                                            Enabled="false">
                                                                                        </asp:DropDownList>
                                                                                    </ItemTemplate>
                                                                                    <EditItemTemplate>
                                                                                        <asp:DropDownList ID="ddlDeducsContrariasE" runat="server" SkinID="SkinDropDownList"
                                                                                            Enabled="false">
                                                                                        </asp:DropDownList>
                                                                                    </EditItemTemplate>
                                                                                    <InsertItemTemplate>
                                                                                        <asp:DropDownList ID="ddlDeducsContrariasI" runat="server" SkinID="SkinDropDownList"
                                                                                            Enabled="false">
                                                                                        </asp:DropDownList>
                                                                                    </InsertItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Seleccione el tipo de deducción SAT al que se asociará la deducción">
                                                                                    <HeaderStyle Wrap="False" />
                                                                                    <ItemStyle Wrap="true" />
                                                                                    <ItemTemplate>
                                                                                        <asp:DropDownList ID="ddlDeducsSAT" runat="server" SkinID="SkinDropDownList" Enabled="false"
                                                                                             width="100%">
                                                                                        </asp:DropDownList>
                                                                                    </ItemTemplate>
                                                                                    <EditItemTemplate>
                                                                                        <asp:DropDownList ID="ddlDeducsSATE" runat="server" SkinID="SkinDropDownList"  width="100%">
                                                                                        </asp:DropDownList>
                                                                                    </EditItemTemplate>
                                                                                    <InsertItemTemplate>
                                                                                        <asp:DropDownList ID="ddlDeducsSATI" runat="server" SkinID="SkinDropDownList" width="100%">
                                                                                        </asp:DropDownList>
                                                                                    </InsertItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="¿Calculada por diferencia entre Percepciones/Deducciones?">
                                                                                    <ItemTemplate>
                                                                                        <asp:CheckBox ID="chbxDerivadaDePercsDeducs" runat="server" SkinID="SkinCheckBox" Enabled="false"
                                                                                            Checked='<%# Bind("DerivadaDePercsDeducs") %>'></asp:CheckBox>
                                                                                    </ItemTemplate>
                                                                                    <EditItemTemplate>
                                                                                        <asp:CheckBox ID="chbxDerivadaDePercsDeducsE" runat="server" SkinID="SkinCheckBox" Checked='<%# Bind("DerivadaDePercsDeducs") %>'>
                                                                                        </asp:CheckBox>
                                                                                    </EditItemTemplate>
                                                                                    <InsertItemTemplate>
                                                                                        <asp:CheckBox ID="chbxDerivadaDePercsDeducsI" runat="server" SkinID="SkinCheckBox"></asp:CheckBox>
                                                                                    </InsertItemTemplate>
                                                                                    <HeaderStyle Wrap="False" />
                                                                                    <ItemStyle Wrap="True" />
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField ShowHeader="False">
                                                                                    <HeaderStyle Wrap="False" />
                                                                                    <ItemStyle HorizontalAlign="Right" Wrap="False" />
                                                                                    <ItemTemplate>
                                                                                        <asp:Button ID="btnCancelar" runat="server" SkinID="SkinBoton" Text="Cancelar" />
                                                                                    </ItemTemplate>
                                                                                    <EditItemTemplate>
                                                                                        <asp:Button ID="btnCancelarE" runat="server" SkinID="SkinBoton" Text="Cancelar" />
                                                                                        <ajaxToolkit:ConfirmButtonExtender ID="CBEE" runat="server" ConfirmText="¿Está seguro de guardar los cambios realizados?"
                                                                                            TargetControlID="btnGuardarE">
                                                                                        </ajaxToolkit:ConfirmButtonExtender>
                                                                                        <asp:Button ID="btnGuardarE" runat="server" SkinID="SkinBoton" Text="Guardar" ToolTip="Guardar información de la Deducción"
                                                                                            OnClick="btnGuardar_Click" Width="80px" ValidationGroup="GrupoGuardar" />
                                                                                        <asp:ValidationSummary ID="VSGrupoGuardarE" runat="server" ShowMessageBox="True"
                                                                                            ShowSummary="False" ValidationGroup="GrupoGuardar" />
                                                                                    </EditItemTemplate>
                                                                                    <InsertItemTemplate>
                                                                                        <asp:Button ID="btnCancelarI" runat="server" SkinID="SkinBoton" Text="Cancelar" />
                                                                                        <ajaxToolkit:ConfirmButtonExtender ID="CBEI" runat="server" ConfirmText="¿Está seguro de guardar los cambios realizados?"
                                                                                            TargetControlID="btnGuardarI">
                                                                                        </ajaxToolkit:ConfirmButtonExtender>
                                                                                        <asp:Button ID="btnGuardarI" runat="server" SkinID="SkinBoton" Text="Guardar" ToolTip="Guardar información de la Deducción"
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
                                            <br />
                                            <asp:LinkButton ID="lbOtraOperacion" runat="server" SkinID="SkinLinkButton">Cambiar más datos</asp:LinkButton>
                                            &nbsp;<asp:LinkButton ID="lbOtraOperacion0" runat="server" 
                                                PostBackUrl="~/Consultas/Deducciones/CatalogoDeducsParaABC.aspx" 
                                                SkinID="SkinLinkButton">Continuar con otra operación en el sistema</asp:LinkButton>
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
    </div>
</asp:Content>
