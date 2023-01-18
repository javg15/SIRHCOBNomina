<%@ Page Language="VB" EnableEventValidation="false" MasterPageFile="~/MasterPageSesionIniciada.master"
    AutoEventWireup="false" CodeFile="wfHistoriaEvaluacionesPorEmp.aspx.vb" Inherits="wfHistoriaEvaluacionesPorEmp"
    Title="COBAEV - Nómina - SPD, Historial de evaluaciones por emplado" StylesheetTheme="SkinFile" %>

<%@ Register Src="~/WebControls/wucSearchEmps.ascx" TagName="wucBuscaEmpleados"
    TagPrefix="uc1" %>
<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress"
    TagPrefix="TP_wucUpdateProgress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
    <asp:UpdatePanel ID="UPMain" runat="server">
        <ContentTemplate>
            <h2>
                <asp:Label ID="lblH2" runat="server" Text="Sistema de nómina: SPD, Historial de evaluaciones por emplado."></asp:Label>
            </h2>
            <asp:Panel ID="pnlBuscaEmps" runat="server">
                <uc1:wucBuscaEmpleados ID="wucBuscaEmps" runat="server" EnableViewState="true"></uc1:wucBuscaEmpleados>
            </asp:Panel>
            <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                <asp:View ID="viewHistoria" runat="server">
                    <asp:Panel ID="pnlCaptura" runat="server" BorderStyle="None">
                        <div class="accountInfo">
                            <fieldset id="fsCaptura">
                                <legend>
                                    <asp:Label ID="lblLegend" runat="server" Font-Strikeout="False" Font-Underline="True"
                                        Text="Historial encontrado:"></asp:Label>
                                </legend>
                                <asp:GridView ID="gvHistoriaEvaluaciones" runat="server" 
                                    EmptyDataText="Sin historial de evaluaciones." Height="100%" 
                                    SkinID="SkinGridViewEmpty" Width="100%" ShowHeaderWhenEmpty="True">
                                    <Columns>
                                        <asp:BoundField DataField="CicloEscolar" HeaderText="Ciclo Escolar">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="EvaluadoEn" HeaderText="Evaluado en" >
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Resultado" HeaderText="Resultado" >
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Evaluador" HeaderText="¿Evaluador?">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="IncentivoEconomico" HeaderText="Beneficio económico asignado">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Observaciones" HeaderText="Observaciones" >
                                        <HeaderStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                    </Columns>
                                </asp:GridView>
                            </fieldset>
                        </asp:Panel>
                </asp:View>
            </asp:MultiView>
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
