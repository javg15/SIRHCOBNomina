<%@ Page Language="VB" EnableEventValidation="false" MasterPageFile="~/MasterPageSesionIniciada.master"
    AutoEventWireup="false" CodeFile="ABCMovsDePers.aspx.vb" Inherits="ABCMovsDePers"
    Title="COBAEV - Nómina - ABC Movimientos de personal" StylesheetTheme="SkinFile" %>

<%@ Register Src="~/WebControls/wucSearchEmps.ascx" TagName="wucBuscaEmpleados"
    TagPrefix="uc1" %>
<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress"
    TagPrefix="TP_wucUpdateProgress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
    <asp:UpdatePanel ID="UPMain" runat="server">
        <ContentTemplate>
            <h2>
                <asp:Label ID="lblH2" runat="server" Text="Sistema de nómina: Captura de Movimientos de personal"></asp:Label>
            </h2>
            <asp:Panel ID="pnlBuscaEmps" runat="server">
                <uc1:wucBuscaEmpleados ID="wucBuscaEmps" runat="server" EnableViewState="true"></uc1:wucBuscaEmpleados>
            </asp:Panel>
            <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                <asp:View ID="viewCapturaModif" runat="server">
                    <asp:Panel ID="pnlCaptura" runat="server" GroupingText="Captura de Movimientos de personal">
                        <div class="accountInfo">
                            <fieldset id="fsCaptura">
                                <legend>
                                    <asp:Label ID="lblInf1" runat="server" Font-Strikeout="False" Font-Underline="True"
                                        Text="Seleccione trámite y motivo:"></asp:Label>
                                </legend>
                                <div class="panelIzquierda">
                                    <p class="pLabel">
                                        <asp:Label ID="lblTramites" runat="server" CssClass="pLabel" Text="Trámite:" />
                                    </p>
                                    <p class="pTextBox">
                                        <asp:DropDownList ID="ddlTramites" runat="server" AutoPostBack="True" CssClass="textEntry"
                                            TabIndex="1">
                                        </asp:DropDownList>
                                    </p>
                                </div>
                                <div class="pnlDerecha">
                                    <p class="pLabel">
                                        <asp:Label ID="lblMotivos" runat="server" CssClass="pLabel" Text="Motivo:" />
                                    </p>
                                    <p class="pTextBox">
                                        <asp:DropDownList ID="ddlMotivos" runat="server" CssClass="textEntry"
                                            TabIndex="2">
                                        </asp:DropDownList>
                                    </p>
                                </div>
                            </fieldset>
                        </div>
                    <div id="divBotones">
                        <p class="submitButton">
                            <asp:Button ID="btnContinuar" runat="server" Text="Continuar" 
                                TabIndex="3" />
                        </p>
                    </div>
                    </asp:Panel>
                </asp:View>
            </asp:MultiView>
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
