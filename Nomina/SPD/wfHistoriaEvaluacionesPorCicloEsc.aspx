<%@ Page Language="VB" EnableEventValidation="false" MasterPageFile="~/MasterPageSesionIniciada.master"
    AutoEventWireup="false" CodeFile="wfHistoriaEvaluacionesPorCicloEsc.aspx.vb" Inherits="wfHistoriaEvaluacionesPorCicloEsc"
    Title="COBAEV - Nómina - SPD, Historial de evaluaciones por ciclo escolar" StylesheetTheme="SkinFile" %>

<%@ Register Src="~/WebControls/wucSearchEmps.ascx" TagName="wucBuscaEmpleados"
    TagPrefix="uc1" %>
<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress"
    TagPrefix="TP_wucUpdateProgress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<style type="text/css">
    .modalBackground
    {
        background-color:Silver;
        filter: alpha(opacity=60);
        opacity: 0.5;
    }
    .modalPopup
    {
        background-color: #FFFFFF;
        border-width: 3px;
        border-style: solid;
        border-color: maroon;
        padding-top: 5px;
        padding-left: 5px;
        padding-right:5px;
        width: 900px;
        /*height: 240px;*/
    }
 </style>
    <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
    <asp:UpdatePanel ID="UPMain" runat="server">
        <ContentTemplate>
            <h2>
                <asp:Label ID="lblH2" runat="server" Text="Sistema de nómina: SPD, Historial de evaluaciones por Ciclo Escolar."></asp:Label>
            </h2>
            <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                <asp:View ID="viewHistoria" runat="server">
                    <asp:Panel ID="pnlCaptura" runat="server" BorderStyle="None">
                    <fieldset id="fsCaptura1">
                        <legend>
                            <asp:Label ID="lblLegend1" runat="server" Font-Strikeout="False" Font-Underline="True"
                             Text="Elija ciclo escolar"></asp:Label>
                        </legend>
                        <div class="panelIzquierda">
                            <p class="pLabel">
                                <asp:Label ID="lblCiclosEscolares" runat="server" Text="Ciclos escolares:" CssClass="pLabel" />
                            </p>
                            <p class="pTextBox">
                                <asp:DropDownList ID="ddlCiclosEscolares" runat="server"  CssClass="textEntry" 
                                    TabIndex="1" AutoPostBack="True">
                                </asp:DropDownList>
                            </p>
                        </div>
                    </fieldset>
                        <div class="accountInfo">
                            <fieldset id="fsCaptura2">
                                <legend>
                                    <asp:Label ID="lblLegend" runat="server" Font-Strikeout="False" Font-Underline="True"
                                        Text="Historial encontrado:"></asp:Label>
                                </legend>
                                <asp:GridView ID="gvHistoriaEvaluaciones" runat="server" 
                                    EmptyDataText="Sin historial de evaluaciones." Height="100%" 
                                    SkinID="SkinGridViewEmpty" Width="100%" ShowHeaderWhenEmpty="True">
                                    <Columns>
                                        <asp:TemplateField HeaderText="R.F.C.">
                                            <ItemTemplate>
                                                <asp:LinkButton id="lnkbtnRFC" runat="server" Text='<%# Bind("RFCEmp") %>' 
                                                    onclick="lnkbtnRFC_Click" 
                                                    ToolTip="Selecciones el R.F.C. del empleado para consultar su historial de evaluaciones."></asp:LinkButton>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="ApePatEmp" HeaderText="Apellido paterno" Visible="false">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="ApeMatEmp" HeaderText="Apellido materno" Visible="false">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="NomEmp" HeaderText="Nombre(s)" Visible="false">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="NombreEmpleado" HeaderText="Empleado">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="ClaveCTSE" HeaderText="Clave C.T." Visible="false">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="DescPlantel" HeaderText="Centro de trabajo">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="ZonaGeo" HeaderText="Zona">
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

                <ajaxToolkit:ModalPopupExtender ID="ibNuevosValores_MPE" runat="server" 
                    DynamicServicePath="" Enabled="True" 
                    PopupControlID="pnlNuevosValores" DropShadow="true" 
                    TargetControlID="btnOpenModalPopUp1" BackgroundCssClass="modalBackground" CancelControlID="btnCloseModalPopUp1" >
                </ajaxToolkit:ModalPopupExtender>
                <asp:Button ID="btnCloseModalPopUp1" runat="server" Text="Cerrar" style="display:none"/>
                <asp:Button ID="btnOpenModalPopUp1" runat="server" Text="Cerrar" style="display:none"/>
                <asp:Panel ID="pnlNuevosValores" runat="server" CssClass="modalPopup">
                    <asp:UpdatePanel ID="UPModalPopUp1" runat="server">
                    <ContentTemplate>
                    <asp:Panel ID="Panel1" runat="server" BorderStyle="None">
                        <div class="accountInfo">
                            <fieldset id="fsCaptura">
                                <legend>
                                    <asp:Label ID="lblLegend2" runat="server" Font-Strikeout="False" Font-Underline="True"
                                        Text="Historial encontrado:"></asp:Label>
                                </legend>
                                <asp:GridView ID="gvHistoriaEvaluacionesEmp" runat="server" 
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
                    <div id="divBotones">
                        <p class="submitButton">
                                    <asp:Button ID="btnCerrar" runat="server" OnClick="btnCerrar_Click" 
                                        Text="Cancelar" CausesValidation="False" />
                        </p>
                    </div>
                    </ContentTemplate>
                    </asp:UpdatePanel>
                </asp:Panel>
                </asp:View>
            </asp:MultiView>
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
