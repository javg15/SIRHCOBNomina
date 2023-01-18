<%@ Control Language="VB" EnableViewState="true" AutoEventWireup="false" CodeFile="wucPlazas2.ascx.vb"
    Inherits="wucPlazas2" %>
<%@ Register Src="~/WebControls/wucCalendario.ascx" TagName="wucCalendario" TagPrefix="uc2" %>
<link href="../StyleSheetAlternativa.css" rel="stylesheet" type="text/css" />
<div class="accountInfo">
    <fieldset id="fsCaptura">
        <legend>
            <asp:Label ID="lblInfEmp" runat="server" Font-Strikeout="False" Font-Underline="True"></asp:Label>
        </legend>
        <div class="panelIzquierda">
            <p class="pLabel">
                <asp:Label ID="lblNumCadena" runat="server" CssClass="pLabel" />
            </p>
            <p class="pLabel2">
                <asp:Label ID="lblTramite" runat="server" CssClass="pLabel" />
            </p>
            <p class="pLabel">
                <asp:Label ID="lblClavePlaza" runat="server" CssClass="pLabel" />
            </p>
            <p class="pLabel">
                <asp:Label ID="lblDescClavePlaza" runat="server" Text="Descripción de la clave de plaza:"
                    CssClass="pLabel" />
            </p>
            <p class="pLabel">
                <asp:Label ID="lblCvePlazaTipo" runat="server" CssClass="pLabel" />
            </p>
            <p class="pLabel2">
                <asp:Label ID="lblCod_Pago" runat="server" CssClass="pLabel" />
            </p>
            <p class="pLabel2">
                <asp:Label ID="lblHorasPlaza" runat="server" CssClass="pLabel" />
            </p>
            <p class="pLabel">
                <asp:Label ID="lblFechaIni" runat="server" Enabled="False" CssClass="pLabel" Text="Fecha inicial del movimiento de personal:">
                </asp:Label>
            </p>
            <p class="pTextBox">
                <asp:TextBox ID="txtbxFechaIni" runat="server" MaxLength="10" CssClass="textEntry"
                    ValidationGroup="GrupoGuardar"></asp:TextBox>
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
            <p class="pLabel">
            </p>
            <p class="pLabel2">
                <asp:Label ID="lblMotivo" runat="server" CssClass="pLabel" />
            </p>
            <p class="pLabel">
            </p>
            <p class="pLabel">
            </p>
            <p class="pLabel">
                <asp:Label ID="lblZonaEco" runat="server" CssClass="pLabel" />
            </p>
            <p class="pLabel2">
                <asp:Label ID="lblCveCategoCOBACH" runat="server" CssClass="pLabel" />
            </p>
            <p class="pLabel2">
                <asp:Label ID="lblConsPlaza" runat="server" CssClass="pLabel" />
            </p>
            <p class="pLabel">
                <asp:Label ID="lblFechaFin" runat="server" CssClass="pLabel" Enabled="False" Text="Fecha final del movimiento de personal:">
                </asp:Label>
            </p>
            <p class="pTextBox">
                <asp:TextBox ID="txtbxFechaFin" runat="server" CssClass="textEntry" MaxLength="10"
                    ValidationGroup="GrupoGuardar"></asp:TextBox>
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
</div>
