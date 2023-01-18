<%@ page language="VB" masterpagefile="~/MasterPageBlanca.master" autoeventwireup="false" inherits="ABCPercepciones, App_Web_ou3vf2bz" title="COBAEV - Nómina - ABC Percepciones" stylesheettheme="SkinFile" culture="Auto" uiculture="Auto" maintainScrollPositionOnPostBack="true" %>

<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress"
    TagPrefix="TP_wucUpdateProgress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
    <table style="width: 70%;" align="left">
        <tr>
            <td style="vertical-align: top; text-align: right">
                <h2>
                    Sistema de nómina: ABC Percepciones
                </h2>
            </td>
        </tr>
        <tr>
            <td>
                <asp:UpdatePanel ID="UPNuevaPercepcion" runat="server">
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
                                                                        <asp:DetailsView ID="dvDatosPerc" runat="server" AutoGenerateRows="False" DefaultMode="Insert"
                                                                            EmptyDataText="Sin información de datos personales" SkinID="SkinDetailsView"
                                                                            CellPadding="0">
                                                                            <Fields>
                                                                                <asp:TemplateField HeaderText="IdPercepcion" Visible="False">
                                                                                    <EditItemTemplate>
                                                                                        <asp:Label ID="lblIdPercepcionE" runat="server" Text='<%# Bind("IdPercepcion") %>'
                                                                                            SkinID="SkinLblNormal"></asp:Label>
                                                                                    </EditItemTemplate>
                                                                                    <InsertItemTemplate>
                                                                                        <asp:Label ID="lblIdPercepcionI" runat="server" Text="0" SkinID="SkinLblNormal"></asp:Label>
                                                                                    </InsertItemTemplate>
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblIdPercepcion" runat="server" Text='<%# Bind("IdPercepcion") %>'
                                                                                            SkinID="SkinLblNormal"></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Clave de la percepción">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblClavePercepcion" runat="server" Text='<%# Bind("ClavePercepcion") %>'
                                                                                            SkinID="SkinLblNormal"></asp:Label>
                                                                                    </ItemTemplate>
                                                                                    <InsertItemTemplate>
                                                                                        <asp:Label ID="lblClavePercepcionI" runat="server" Text="" SkinID="SkinLblNormal"></asp:Label>
                                                                                    </InsertItemTemplate>
                                                                                    <EditItemTemplate>
                                                                                        <asp:Label ID="lblClavePercepcionE" runat="server" Text='<%# Bind("ClavePercepcion") %>'
                                                                                            SkinID="SkinLblNormal"></asp:Label>
                                                                                    </EditItemTemplate>
                                                                                    <HeaderStyle Wrap="False" />
                                                                                    <ItemStyle Wrap="False" />
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Nombre de la percepción">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblNombrePercepcion" runat="server" Text='<%# Bind("NombrePercepcion") %>'
                                                                                            SkinID="SkinLblNormal"></asp:Label>
                                                                                    </ItemTemplate>
                                                                                    <InsertItemTemplate>
                                                                                        <asp:TextBox ID="txtbxNombrePercepcionI" runat="server" Text="" SkinID="SkinTextBox"
                                                                                            MaxLength="50" Columns="80"></asp:TextBox>
                                                                                    </InsertItemTemplate>
                                                                                    <EditItemTemplate>
                                                                                        <asp:TextBox ID="txtbxNombrePercepcionE" runat="server" Text='<%# Bind("NombrePercepcion") %>'
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
                                                                                <asp:TemplateField HeaderText="Quincenas durante las que se pagará a un empleado">
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
                                                                                <asp:TemplateField HeaderText="¿Tiene percepción padre?">
                                                                                    <ItemTemplate>
                                                                                        <asp:CheckBox ID="chbxTienePercPadre" runat="server" SkinID="SkinCheckBox" Enabled="false"
                                                                                            Checked='<%# Bind("TienePercepcionPadre") %>'></asp:CheckBox>
                                                                                    </ItemTemplate>
                                                                                    <EditItemTemplate>
                                                                                        <asp:CheckBox ID="chbxTienePercPadreE" runat="server" SkinID="SkinCheckBox" AutoPostBack="true"
                                                                                            OnCheckedChanged="chbxTienePercPadre_CheckedChanged" Checked='<%# Bind("TienePercepcionPadre") %>'>
                                                                                        </asp:CheckBox>
                                                                                    </EditItemTemplate>
                                                                                    <InsertItemTemplate>
                                                                                        <asp:CheckBox ID="chbxTienePercPadreI" runat="server" SkinID="SkinCheckBox" AutoPostBack="true"
                                                                                            OnCheckedChanged="chbxTienePercPadre_CheckedChanged"></asp:CheckBox>
                                                                                    </InsertItemTemplate>
                                                                                    <HeaderStyle Wrap="False" />
                                                                                    <ItemStyle Wrap="True" />
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Percepción padre">
                                                                                    <HeaderStyle Wrap="False" />
                                                                                    <ItemTemplate>
                                                                                        <asp:DropDownList ID="ddlPercsPadre" Enabled="false" runat="server" SkinID="SkinDropDownList">
                                                                                        </asp:DropDownList>
                                                                                    </ItemTemplate>
                                                                                    <EditItemTemplate>
                                                                                        <asp:DropDownList ID="ddlPercsPadreE" runat="server" SkinID="SkinDropDownList">
                                                                                        </asp:DropDownList>
                                                                                    </EditItemTemplate>
                                                                                    <InsertItemTemplate>
                                                                                        <asp:DropDownList ID="ddlPercsPadreI" runat="server" SkinID="SkinDropDownList">
                                                                                        </asp:DropDownList>
                                                                                    </InsertItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="¿Impuesto absorbido por la empresa?">
                                                                                    <ItemTemplate>
                                                                                        <asp:CheckBox ID="chbxImpuestoAbsorbidoPorColegio" Enabled="false" Checked='<%# Bind("ImpuestoAbsorbidoPorColegio") %>'
                                                                                            runat="server" SkinID="SkinCheckBox"></asp:CheckBox>
                                                                                    </ItemTemplate>
                                                                                    <EditItemTemplate>
                                                                                        <asp:CheckBox ID="chbxImpuestoAbsorbidoPorColegioE" Checked='<%# Bind("ImpuestoAbsorbidoPorColegio") %>'
                                                                                            runat="server" SkinID="SkinCheckBox"></asp:CheckBox>
                                                                                    </EditItemTemplate>
                                                                                    <InsertItemTemplate>
                                                                                        <asp:CheckBox ID="chbxImpuestoAbsorbidoPorColegioI" runat="server" SkinID="SkinCheckBox">
                                                                                        </asp:CheckBox>
                                                                                    </InsertItemTemplate>
                                                                                    <HeaderStyle Wrap="False" />
                                                                                    <ItemStyle Wrap="True" />
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="¿Es ordinaria?">
                                                                                    <ItemTemplate>
                                                                                        <asp:CheckBox ID="chbxOrdinaria" Enabled="false" runat="server" SkinID="SkinCheckBox"
                                                                                            Checked='<%# Bind("Ordinaria") %>'></asp:CheckBox>
                                                                                    </ItemTemplate>
                                                                                    <EditItemTemplate>
                                                                                        <asp:CheckBox ID="chbxOrdinariaE" runat="server" SkinID="SkinCheckBox" AutoPostBack="True"
                                                                                            OnCheckedChanged="chbxOrdinaria_CheckedChanged" Checked='<%# Bind("Ordinaria") %>'>
                                                                                        </asp:CheckBox>&nbsp;
                                                                                        <asp:Label ID="lblAyudachbxOrdinariaE" runat="server" SkinID="SkinLblMsjErrores"
                                                                                            Text="No olvide crear su clave de devolución correspondiente (Deducción)" Visible="False"></asp:Label>
                                                                                    </EditItemTemplate>
                                                                                    <InsertItemTemplate>
                                                                                        <asp:CheckBox ID="chbxOrdinariaI" runat="server" SkinID="SkinCheckBox" AutoPostBack="True"
                                                                                            OnCheckedChanged="chbxOrdinaria_CheckedChanged"></asp:CheckBox>&nbsp;<asp:Label ID="lblAyudachbxOrdinariaI"
                                                                                                runat="server" SkinID="SkinLblMsjErrores" Text="No olvide crear su clave de devolución correspondiente (Deducción)"
                                                                                                Visible="False"></asp:Label>
                                                                                    </InsertItemTemplate>
                                                                                    <HeaderStyle Wrap="False" />
                                                                                    <ItemStyle Wrap="false" />
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
                                                                                <asp:TemplateField HeaderText="¿Requiere definir días para su cálculo?">
                                                                                    <ItemTemplate>
                                                                                        <asp:CheckBox ID="chbxRequiereDias" Enabled="false" runat="server" SkinID="SkinCheckBox"
                                                                                            Checked='<%# Bind("RequiereDias") %>'></asp:CheckBox>
                                                                                    </ItemTemplate>
                                                                                    <EditItemTemplate>
                                                                                        <asp:CheckBox ID="chbxRequiereDiasE" runat="server" SkinID="SkinCheckBox" Checked='<%# Bind("RequiereDias") %>'>
                                                                                        </asp:CheckBox>
                                                                                    </EditItemTemplate>
                                                                                    <InsertItemTemplate>
                                                                                        <asp:CheckBox ID="chbxRequiereDiasI" runat="server" SkinID="SkinCheckBox"></asp:CheckBox>
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
                                                                                <asp:TemplateField HeaderText="¿Es percepción por ley?">
                                                                                    <ItemTemplate>
                                                                                        <asp:CheckBox ID="chbxPercepcionPorLey" Enabled="false" runat="server" SkinID="SkinCheckBox"
                                                                                            Checked='<%# Bind("PercepcionPorLey") %>'></asp:CheckBox>
                                                                                    </ItemTemplate>
                                                                                    <EditItemTemplate>
                                                                                        <asp:CheckBox ID="chbxPercepcionPorLeyE" runat="server" SkinID="SkinCheckBox" Checked='<%# Bind("PercepcionPorLey") %>'>
                                                                                        </asp:CheckBox>
                                                                                    </EditItemTemplate>
                                                                                    <InsertItemTemplate>
                                                                                        <asp:CheckBox ID="chbxPercepcionPorLeyI" runat="server" SkinID="SkinCheckBox"></asp:CheckBox></InsertItemTemplate>
                                                                                    <HeaderStyle Wrap="False" />
                                                                                    <ItemStyle Wrap="True" />
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="¿Es ficticia?">
                                                                                    <ItemTemplate>
                                                                                        <asp:CheckBox ID="chbxFicticia" Enabled="false" runat="server" SkinID="SkinCheckBox"
                                                                                            Checked='<%# Bind("Ficticia") %>'></asp:CheckBox>
                                                                                    </ItemTemplate>
                                                                                    <EditItemTemplate>
                                                                                        <asp:CheckBox ID="chbxFicticiaE" runat="server" SkinID="SkinCheckBox" Checked='<%# Bind("Ficticia") %>'>
                                                                                        </asp:CheckBox>
                                                                                    </EditItemTemplate>
                                                                                    <InsertItemTemplate>
                                                                                        <asp:CheckBox ID="chbxFicticiaI" runat="server" SkinID="SkinCheckBox"></asp:CheckBox>
                                                                                    </InsertItemTemplate>
                                                                                    <HeaderStyle Wrap="False" />
                                                                                    <ItemStyle Wrap="True" />
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="¿Es percepción de devolución al empleado de alguna deducción (no odrinaria)?">
                                                                                    <ItemTemplate>
                                                                                        <asp:CheckBox ID="chbxDeduccionContraria" Enabled="false" runat="server" SkinID="SkinCheckBox"
                                                                                            Checked='<%# Bind("EsDeducContrariaDePerc") %>'></asp:CheckBox></ItemTemplate>
                                                                                    <EditItemTemplate>
                                                                                        <asp:CheckBox ID="chbxDeduccionContrariaE" runat="server" SkinID="SkinCheckBox" AutoPostBack="True"
                                                                                            OnCheckedChanged="chbxDeduccionContraria_CheckedChanged" Checked='<%# Bind("EsDeducContrariaDePerc") %>'>
                                                                                        </asp:CheckBox></EditItemTemplate>
                                                                                    <InsertItemTemplate>
                                                                                        <asp:CheckBox ID="chbxDeduccionContrariaI" runat="server" SkinID="SkinCheckBox" AutoPostBack="True"
                                                                                            OnCheckedChanged="chbxDeduccionContraria_CheckedChanged"></asp:CheckBox></InsertItemTemplate>
                                                                                    <HeaderStyle Wrap="False" />
                                                                                    <ItemStyle Wrap="false" />
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Seleccione la deducción (no ordinaria) a relacionar con la percepción">
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
                                                                                <asp:TemplateField HeaderText="¿Es clave de adeudo de alguna otra percepción?">
                                                                                    <ItemTemplate>
                                                                                        <asp:CheckBox ID="chbxSeraPercDeAdeudo" runat="server" SkinID="SkinCheckBox" Enabled="false"
                                                                                            Checked='<%# Bind("EsPercAdeudoDePerc") %>'></asp:CheckBox></ItemTemplate>
                                                                                    <EditItemTemplate>
                                                                                        <asp:CheckBox ID="chbxSeraPercDeAdeudoE" runat="server" SkinID="SkinCheckBox" AutoPostBack="true"
                                                                                            OnCheckedChanged="chbxSeraPercDeAdeudo_CheckedChanged" Checked='<%# Bind("EsPercAdeudoDePerc") %>'>
                                                                                        </asp:CheckBox></EditItemTemplate>
                                                                                    <InsertItemTemplate>
                                                                                        <asp:CheckBox ID="chbxSeraPercDeAdeudoI" runat="server" SkinID="SkinCheckBox" AutoPostBack="true"
                                                                                            OnCheckedChanged="chbxSeraPercDeAdeudo_CheckedChanged"></asp:CheckBox></InsertItemTemplate>
                                                                                    <HeaderStyle Wrap="False" />
                                                                                    <ItemStyle Wrap="True" />
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Percepción a la cual se relacionará como adeudo">
                                                                                    <HeaderStyle Wrap="False" />
                                                                                    <ItemTemplate>
                                                                                        <asp:DropDownList ID="ddlPercsParaRelComoAdeudo" Enabled="false" runat="server" SkinID="SkinDropDownList">
                                                                                        </asp:DropDownList>
                                                                                    </ItemTemplate>
                                                                                    <EditItemTemplate>
                                                                                        <asp:DropDownList ID="ddlPercsParaRelComoAdeudoE" runat="server" SkinID="SkinDropDownList">
                                                                                        </asp:DropDownList>
                                                                                    </EditItemTemplate>
                                                                                    <InsertItemTemplate>
                                                                                        <asp:DropDownList ID="ddlPercsParaRelComoAdeudoI" runat="server" SkinID="SkinDropDownList">
                                                                                        </asp:DropDownList>
                                                                                    </InsertItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="¿Es clave retroactiva de alguna otra percepción?">
                                                                                    <ItemTemplate>
                                                                                        <asp:CheckBox ID="chbxSeraPercDeRetro" runat="server" SkinID="SkinCheckBox" Enabled="false"
                                                                                            Checked='<%# Bind("EsPercRetroDePerc") %>'></asp:CheckBox></ItemTemplate>
                                                                                    <EditItemTemplate>
                                                                                        <asp:CheckBox ID="chbxSeraPercDeRetroE" runat="server" SkinID="SkinCheckBox" AutoPostBack="true"
                                                                                            OnCheckedChanged="chbxSeraPercDeRetro_CheckedChanged" Checked='<%# Bind("EsPercRetroDePerc") %>'>
                                                                                        </asp:CheckBox></EditItemTemplate>
                                                                                    <InsertItemTemplate>
                                                                                        <asp:CheckBox ID="chbxSeraPercDeRetroI" runat="server" SkinID="SkinCheckBox" AutoPostBack="true"
                                                                                            OnCheckedChanged="chbxSeraPercDeRetro_CheckedChanged"></asp:CheckBox></InsertItemTemplate>
                                                                                    <HeaderStyle Wrap="False" />
                                                                                    <ItemStyle Wrap="True" />
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Percepción a la cual se relacionará como retroactiva">
                                                                                    <HeaderStyle Wrap="False" />
                                                                                    <ItemTemplate>
                                                                                        <asp:DropDownList ID="ddlPercsParaRelComoRetro" Enabled="false" runat="server" SkinID="SkinDropDownList">
                                                                                        </asp:DropDownList>
                                                                                    </ItemTemplate>
                                                                                    <EditItemTemplate>
                                                                                        <asp:DropDownList ID="ddlPercsParaRelComoRetroE" runat="server" SkinID="SkinDropDownList">
                                                                                        </asp:DropDownList>
                                                                                    </EditItemTemplate>
                                                                                    <InsertItemTemplate>
                                                                                        <asp:DropDownList ID="ddlPercsParaRelComoRetroI" runat="server" SkinID="SkinDropDownList">
                                                                                        </asp:DropDownList>
                                                                                    </InsertItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Número de quincenas requeridas para su cálculo">
                                                                                    <HeaderStyle Wrap="False" />
                                                                                    <ItemTemplate>
                                                                                        <asp:DropDownList ID="ddlNumQnasReqParaCalc" Enabled="false" runat="server" SkinID="SkinDropDownList">
                                                                                            <asp:ListItem Text="0" Value="0" />
                                                                                            <asp:ListItem Text="1" Value="1" />
                                                                                            <asp:ListItem Text="2" Value="2" />
                                                                                            <asp:ListItem Text="3" Value="3" />
                                                                                            <asp:ListItem Text="4" Value="4" />
                                                                                            <asp:ListItem Text="5" Value="5" />
                                                                                            <asp:ListItem Text="6" Value="6" />
                                                                                            <asp:ListItem Text="7" Value="7" />
                                                                                            <asp:ListItem Text="8" Value="8" />
                                                                                            <asp:ListItem Text="9" Value="9" />
                                                                                            <asp:ListItem Text="10" Value="10" />
                                                                                            <asp:ListItem Text="11" Value="11" />
                                                                                            <asp:ListItem Text="12" Value="12" />
                                                                                            <asp:ListItem Text="13" Value="13" />
                                                                                            <asp:ListItem Text="14" Value="14" />
                                                                                            <asp:ListItem Text="15" Value="15" />
                                                                                            <asp:ListItem Text="16" Value="16" />
                                                                                            <asp:ListItem Text="17" Value="17" />
                                                                                            <asp:ListItem Text="18" Value="18" />
                                                                                            <asp:ListItem Text="19" Value="19" />
                                                                                            <asp:ListItem Text="20" Value="20" />
                                                                                            <asp:ListItem Text="21" Value="21" />
                                                                                            <asp:ListItem Text="22" Value="22" />
                                                                                            <asp:ListItem Text="23" Value="23" />
                                                                                            <asp:ListItem Text="24" Value="24" />
                                                                                        </asp:DropDownList>
                                                                                    </ItemTemplate>
                                                                                    <EditItemTemplate>
                                                                                        <asp:DropDownList ID="ddlNumQnasReqParaCalcE" runat="server" SkinID="SkinDropDownList">
                                                                                            <asp:ListItem Text="0" Value="0" />
                                                                                            <asp:ListItem Text="1" Value="1" />
                                                                                            <asp:ListItem Text="2" Value="2" />
                                                                                            <asp:ListItem Text="3" Value="3" />
                                                                                            <asp:ListItem Text="4" Value="4" />
                                                                                            <asp:ListItem Text="5" Value="5" />
                                                                                            <asp:ListItem Text="6" Value="6" />
                                                                                            <asp:ListItem Text="7" Value="7" />
                                                                                            <asp:ListItem Text="8" Value="8" />
                                                                                            <asp:ListItem Text="9" Value="9" />
                                                                                            <asp:ListItem Text="10" Value="10" />
                                                                                            <asp:ListItem Text="11" Value="11" />
                                                                                            <asp:ListItem Text="12" Value="12" />
                                                                                            <asp:ListItem Text="13" Value="13" />
                                                                                            <asp:ListItem Text="14" Value="14" />
                                                                                            <asp:ListItem Text="15" Value="15" />
                                                                                            <asp:ListItem Text="16" Value="16" />
                                                                                            <asp:ListItem Text="17" Value="17" />
                                                                                            <asp:ListItem Text="18" Value="18" />
                                                                                            <asp:ListItem Text="19" Value="19" />
                                                                                            <asp:ListItem Text="20" Value="20" />
                                                                                            <asp:ListItem Text="21" Value="21" />
                                                                                            <asp:ListItem Text="22" Value="22" />
                                                                                            <asp:ListItem Text="23" Value="23" />
                                                                                            <asp:ListItem Text="24" Value="24" />
                                                                                        </asp:DropDownList>
                                                                                    </EditItemTemplate>
                                                                                    <InsertItemTemplate>
                                                                                        <asp:DropDownList ID="ddlNumQnasReqParaCalcI" runat="server" SkinID="SkinDropDownList">
                                                                                            <asp:ListItem Text="0" Selected="True" Value="0" />
                                                                                            <asp:ListItem Text="1" Value="1" />
                                                                                            <asp:ListItem Text="2" Value="2" />
                                                                                            <asp:ListItem Text="3" Value="3" />
                                                                                            <asp:ListItem Text="4" Value="4" />
                                                                                            <asp:ListItem Text="5" Value="5" />
                                                                                            <asp:ListItem Text="6" Value="6" />
                                                                                            <asp:ListItem Text="7" Value="7" />
                                                                                            <asp:ListItem Text="8" Value="8" />
                                                                                            <asp:ListItem Text="9" Value="9" />
                                                                                            <asp:ListItem Text="10" Value="10" />
                                                                                            <asp:ListItem Text="11" Value="11" />
                                                                                            <asp:ListItem Text="12" Value="12" />
                                                                                            <asp:ListItem Text="13" Value="13" />
                                                                                            <asp:ListItem Text="14" Value="14" />
                                                                                            <asp:ListItem Text="15" Value="15" />
                                                                                            <asp:ListItem Text="16" Value="16" />
                                                                                            <asp:ListItem Text="17" Value="17" />
                                                                                            <asp:ListItem Text="18" Value="18" />
                                                                                            <asp:ListItem Text="19" Value="19" />
                                                                                            <asp:ListItem Text="20" Value="20" />
                                                                                            <asp:ListItem Text="21" Value="21" />
                                                                                            <asp:ListItem Text="22" Value="22" />
                                                                                            <asp:ListItem Text="23" Value="23" />
                                                                                            <asp:ListItem Text="24" Value="24" />
                                                                                        </asp:DropDownList>
                                                                                    </InsertItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Forma de pago primaria (Administrativos/Directivos)">
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
                                                                                <asp:TemplateField HeaderText="Forma de pago primaria (Docentes)">
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
                                                                                <asp:TemplateField HeaderText="Forma de pago secundaria (Administrativos/Directivos)">
                                                                                    <HeaderStyle Wrap="False" />
                                                                                    <ItemTemplate>
                                                                                        <asp:DropDownList ID="ddlFormasDePago2A" Enabled="false" runat="server" SkinID="SkinDropDownList">
                                                                                        </asp:DropDownList>
                                                                                    </ItemTemplate>
                                                                                    <EditItemTemplate>
                                                                                        <asp:DropDownList ID="ddlFormasDePago2AE" runat="server" SkinID="SkinDropDownList">
                                                                                        </asp:DropDownList>
                                                                                    </EditItemTemplate>
                                                                                    <InsertItemTemplate>
                                                                                        <asp:DropDownList ID="ddlFormasDePago2AI" runat="server" SkinID="SkinDropDownList">
                                                                                        </asp:DropDownList>
                                                                                    </InsertItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Forma de pago secundaria (Docentes)">
                                                                                    <HeaderStyle Wrap="False" />
                                                                                    <ItemTemplate>
                                                                                        <asp:DropDownList ID="ddlFormasDePago2D" Enabled="false" runat="server" SkinID="SkinDropDownList">
                                                                                        </asp:DropDownList>
                                                                                    </ItemTemplate>
                                                                                    <EditItemTemplate>
                                                                                        <asp:DropDownList ID="ddlFormasDePago2DE" runat="server" SkinID="SkinDropDownList">
                                                                                        </asp:DropDownList>
                                                                                    </EditItemTemplate>
                                                                                    <InsertItemTemplate>
                                                                                        <asp:DropDownList ID="ddlFormasDePago2DI" runat="server" SkinID="SkinDropDownList">
                                                                                        </asp:DropDownList>
                                                                                    </InsertItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Seleccione el tipo de percepción SAT al que se asociará la percepción">
                                                                                    <HeaderStyle Wrap="False" />
                                                                                    <ItemTemplate>
                                                                                        <asp:DropDownList ID="ddlPercsSAT" runat="server" SkinID="SkinDropDownList" Enabled="false">
                                                                                        </asp:DropDownList>
                                                                                    </ItemTemplate>
                                                                                    <EditItemTemplate>
                                                                                        <asp:DropDownList ID="ddlPercsSATE" runat="server" SkinID="SkinDropDownList">
                                                                                        </asp:DropDownList>
                                                                                    </EditItemTemplate>
                                                                                    <InsertItemTemplate>
                                                                                        <asp:DropDownList ID="ddlPercsSATI" runat="server" SkinID="SkinDropDownList">
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
                                                                                    <EditItemTemplate>
                                                                                        <ajaxToolkit:ConfirmButtonExtender ID="CBEE" runat="server" ConfirmText="¿Está seguro de guardar los cambios realizados?"
                                                                                            TargetControlID="btnGuardarE">
                                                                                        </ajaxToolkit:ConfirmButtonExtender>
                                                                                        <asp:Button ID="btnGuardarE" runat="server" SkinID="SkinBoton" Text="Guardar" ToolTip="Guardar información del empleado"
                                                                                            OnClick="btnGuardar_Click" Width="80px" ValidationGroup="GrupoGuardar" />
                                                                                        <asp:ValidationSummary ID="VSGrupoGuardarE" runat="server" ShowMessageBox="True"
                                                                                            ShowSummary="False" ValidationGroup="GrupoGuardar" />
                                                                                    </EditItemTemplate>
                                                                                    <InsertItemTemplate>
                                                                                        <ajaxToolkit:ConfirmButtonExtender ID="CBEI" runat="server" ConfirmText="¿Está seguro de guardar los cambios realizados?"
                                                                                            TargetControlID="btnGuardarI">
                                                                                        </ajaxToolkit:ConfirmButtonExtender>
                                                                                        <asp:Button ID="btnGuardarI" runat="server" SkinID="SkinBoton" Text="Guardar" ToolTip="Guardar información del empleado"
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
