<%@ Control Language="VB" EnableViewState="true" AutoEventWireup="false" CodeFile="wucPlazas.ascx.vb"
    Inherits="wucPlazas" %>
<%@ Register Src="~/WebControls/wucCalendario.ascx" TagName="wucCalendario" TagPrefix="uc2" %>
<link href="../StyleSheetAlternativa.css" rel="stylesheet" type="text/css" />
<%--<div class="accountInfo">--%>
    <fieldset id="fsCaptura">
<%--        <legend>
            <asp:Label ID="lblInfEmp" runat="server" Font-Strikeout="False" Font-Underline="True" Visible="false"></asp:Label>
        </legend>--%>
        <div class="panelIzquierda">
<%--            <p class="pLabel">
                <asp:Label ID="lblNumCadena" runat="server" CssClass="pLabel" visible="false"/>
            </p>--%>
<%--            <p class="pLabel2">
                <asp:Label ID="lblTramite" runat="server" CssClass="pLabel" visible="false"/>
            </p>--%>
            <p class="pLabel">
                <asp:Label ID="lblPlaza" runat="server" Text="Capture la información de la plaza a ocupar:"
                    CssClass="pLabel" />
            </p>
            <p class="pLabel">
                <asp:Label ID="lblCvePlazaTipo" runat="server" Text="Tipo:" CssClass="pLabel" />
            </p>
            <p class="pTextBox">
                <asp:DropDownList ID="ddlCvePlazaTipo" runat="server" CssClass="textEntry" AutoPostBack="True">
                </asp:DropDownList>
            </p>
            <p class="pLabel">
                <asp:Label ID="lblZonaEco" runat="server" Text="Zona económica:" CssClass="pLabel" />
            </p>
            <p class="pTextBox">
                <asp:DropDownList ID="ddlZonasEco" runat="server" CssClass="textEntry" AutoPostBack="True">
                </asp:DropDownList>
            </p>
            <p class="pLabel">
                <asp:Label ID="lblCod_Pago" runat="server" Text="Código de pago:" CssClass="pLabel" />
            </p>
            <p class="pTextBox">
                <asp:TextBox ID="txtbxCod_Pago" runat="server" CssClass="textEntry" Enabled="false"></asp:TextBox>
            </p>
            <p class="pLabel">
                <asp:Label ID="lblUnidad" runat="server" Text="Unidad:" CssClass="pLabel" />
            </p>
            <p class="pTextBox">
                <asp:TextBox ID="txtbxUnidad" runat="server" CssClass="textEntry" Enabled="false"></asp:TextBox>
            </p>
            <p class="pLabel">
                <asp:Label ID="lblSubUnidad" runat="server" Text="SubUnidad:" CssClass="pLabel" />
            </p>
            <p class="pTextBox">
                <asp:TextBox ID="txtbxSubUnidad" runat="server" CssClass="textEntry" Enabled="false"></asp:TextBox>
            </p>
            <p class="pLabel">
                <asp:Label ID="lblCveCategoCOBACH" runat="server" Text="Clave de puesto:" CssClass="pLabel" />
            </p>
            <p class="pTextBox">
                <asp:DropDownList ID="ddlCveCategoCOBACH" runat="server" CssClass="textEntry"
                    AutoPostBack="True">
                </asp:DropDownList>
                <asp:CompareValidator ID="CV_ddlCveCategoCOBACH" runat="server" ControlToValidate="ddlCveCategoCOBACH"
                    Display="Dynamic" ErrorMessage="*" Operator="NotEqual" ToolTip="La categoría es un dato obligatorio."
                    ValidationGroup="GrupoGuardar" ValueToCompare="-1"></asp:CompareValidator>
            </p>
            <p class="pLabel">
                <asp:Label ID="lblHorasPlaza" runat="server" Text="Horas:" CssClass="pLabel" />
            </p>
            <p class="pTextBox">
                <asp:TextBox ID="txtbxHorasPlaza" runat="server" CssClass="textEntry" Enabled="false"></asp:TextBox>
            </p>
            <p class="pLabel">
                <asp:Label ID="lblConsPlaza" runat="server" Text="Consecutivo:" CssClass="pLabel" />
            </p>
            <p class="pTextBox">
                <asp:TextBox ID="txtbxConsPlaza" runat="server" CssClass="textEntry" MaxLength="5"
                    AutoPostBack="True" ValidationGroup="GrupoGuardar"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RFV_txtbxConsPlaza" runat="server" ControlToValidate="txtbxConsPlaza"
                    Display="Dynamic" ErrorMessage="*" ToolTip="El consecutivo es un dato obligatorio."
                    ValidationGroup="GrupoGuardar"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CV_txtbxConsPlaza" runat="server" ControlToValidate="txtbxConsPlaza"
                    Display="Dynamic" ErrorMessage="*" Operator="DataTypeCheck" ToolTip="El consecutivo debe ser un valor númérico."
                    Type="Integer" ValidationGroup="GrupoGuardar"></asp:CompareValidator>
            </p>
            <p class="pLabel">
                <asp:Label ID="lblClavePlaza" runat="server" CssClass="pLabel" Text="Clave de plaza:" />
            </p>
            <p class="pTextBox">
                <asp:TextBox ID="txtbxClavePlaza" runat="server" CssClass="textEntry" Enabled="false"></asp:TextBox>
                <asp:Image ID="imgPlazaCorrecta" runat="server" ImageUrl="~/Imagenes/check.png" Visible="False"
                    ToolTip="Plaza correcta." />
                <asp:Image ID="imgPlazaIncorrecta" runat="server" ImageUrl="~/Imagenes/nocheck.png"
                    Visible="False" ToolTip="Plaza incorrecta o inexistente." />
            </p>
            <p class="pLabel">
                <asp:Label ID="lblFechaIni" runat="server" Enabled="False" CssClass="pLabel" Text="Fecha inicial del movimiento de personal:">
                </asp:Label>
            </p>
            <p class="pTextBox">
                <asp:TextBox ID="txtbxFechaIni" runat="server" MaxLength="10" CssClass="textEntry"
                    ValidationGroup="GrupoGuardar" ReadOnly="True"></asp:TextBox>
                <asp:ImageButton ID="ibFechaIni" runat="server" 
                    ImageUrl="~/Imagenes/ico_calendar.png" CssClass="textEntry2" 
                    CausesValidation="False" ValidationGroup="GrupoGuardar" />
                <asp:RequiredFieldValidator ID="txtbxFechaIni_RFV" runat="server" ControlToValidate="txtbxFechaIni"
                    Display="Dynamic" ErrorMessage="La fecha inicial del movimiento de personal es obligatoria."
                    ValidationGroup="GrupoGuardar" ToolTip="La fecha inicial del movimiento de personal es obligatoria.">*</asp:RequiredFieldValidator>
                <asp:CompareValidator ID="txtbxFechaIni_CV" runat="server" ControlToValidate="txtbxFechaIni"
                    Display="Dynamic" ErrorMessage="La fecha inicial del movimiento de personal es incorrecta."
                    Operator="DataTypeCheck" Type="Date" ValidationGroup="GrupoGuardar" 
                    ToolTip="La fecha inicial del movimiento de personal es incorrecta.">*</asp:CompareValidator>
            </p>
            <p class="pLabel">
                &nbsp;<asp:Panel ID="pnlFechIni" runat="server" Visible="false">
                    <uc2:wucCalendario ID="wucCalendarFechIni" runat="server" />
                </asp:Panel>
            </p>
        </div>
        <div class="pnlDerecha">
<%--            <p class="pLabel">
            </p>--%>
<%--            <p class="pLabel2">
                <asp:Label ID="lblMotivo" runat="server" CssClass="pLabel" visible="false"/>
            </p>--%>
            <p class="pLabel">
            </p>
            <p class="pLabel">
            </p>
            <p class="pTextBox">
                <asp:Label ID="lblDescPlazaTipo" runat="server" CssClass="pLabel" />
            </p>
            <p class="pLabel">
            </p>
            <p class="pTextBox">
                <asp:Label ID="lblDescZonaEco" runat="server" CssClass="pLabel" />
            </p>
            <p class="pLabel">
            </p>
            <p class="pTextBox">
                <asp:Label ID="lblDescCod_Pago" runat="server" CssClass="pLabel" />
            </p>
            <p class="pLabel">
            </p>
            <p class="pTextBox">
            </p>
            <p class="pLabel">
            </p>
            <p class="pTextBox">
            </p>
            <p class="pLabel">
            </p>
            <p class="pTextBox">
                <asp:Label ID="lblDescCatego" runat="server" CssClass="pLabel" />
            </p>
            <p class="pLabel">
            </p>
            <p class="pTextBox">
            </p>
            <p class="pLabel">
            </p>
            <p class="pTextBox">
            </p>
            <p class="pLabel">
            </p>
            <p class="pTextBox">
            </p>
           <p class="pLabel">
                <asp:Label ID="lblFechaFin" runat="server" CssClass="pLabel" Enabled="False" Text="Fecha final del movimiento de personal:">
                </asp:Label>
            </p>
            <p class="pTextBox">
                <asp:TextBox ID="txtbxFechaFin" runat="server" CssClass="textEntry" MaxLength="10"
                    ValidationGroup="GrupoGuardar" ReadOnly="True"></asp:TextBox>
                <asp:ImageButton ID="ibFechaFin" runat="server" CssClass="textEntry2" 
                    ImageUrl="~/Imagenes/ico_calendar.png" CausesValidation="False" 
                    ValidationGroup="GrupoGuardar" />
                <asp:RequiredFieldValidator ID="txtbxFechaFin_RFV" runat="server" ControlToValidate="txtbxFechaFin"
                    Display="Dynamic" ErrorMessage="La fecha final del movimiento de personal es obligatoria."
                    ToolTip="La fecha final del movimiento de personal es obligatoria." 
                    ValidationGroup="GrupoGuardar">*</asp:RequiredFieldValidator>
                <asp:CompareValidator ID="txtbxFechaFin_CV" runat="server" ControlToValidate="txtbxFechaFin"
                    Display="Dynamic" ErrorMessage="La fecha final del movimiento de personal es incorrecta."
                    Operator="DataTypeCheck" ToolTip="La fecha final del movimiento de personal es incorrecta."
                    Type="Date" ValidationGroup="GrupoGuardar">*</asp:CompareValidator>
                <asp:CompareValidator ID="txtbxFechaFin_CV2" runat="server" ControlToCompare="txtbxFechaIni"
                    ControlToValidate="txtbxFechaFin" Display="Dynamic" 
                    ErrorMessage="La fecha final del movimiento de personal debe ser mayor o igual que la fecha inicial."
                    Operator="GreaterThanEqual" 
                    ToolTip="La fecha final del movimiento de personal debe ser mayor o igual que la fecha inicial."
                    Type="Date" ValidationGroup="GrupoGuardar">*</asp:CompareValidator>
            </p>
            <p class="pLabel">
                &nbsp;<asp:Panel ID="pnlFechFin" runat="server" Visible="false">
                    <uc2:wucCalendario ID="wucCalendarFechFin" runat="server" />
                </asp:Panel>
            </p>
        </div>
    </fieldset>
<%--</div>--%>
