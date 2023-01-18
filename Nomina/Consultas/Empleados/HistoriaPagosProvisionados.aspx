<%@ Page EnableEventValidation="false" Language="VB" MasterPageFile="~/MasterPageSesionIniciada.master"
    AutoEventWireup="false" CodeFile="HistoriaPagosProvisionados.aspx.vb" Inherits="Consultas_PagosProvisionados"
    Title="COBAEV - Nómina - Historia pagos provisionados por empleado/ejercicio"
    StylesheetTheme="SkinFile" %>

<%@ Register Src="~/WebControls/wucSearchEmps.ascx" TagName="wucBuscaEmpleados" TagPrefix="uc1" %>
<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress"
    TagPrefix="TP_wucUpdateProgress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UPMain" runat="server">
        <ContentTemplate>
            <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
            <h2>
                Sistema de nómina: Historia de pagos provisionados por empleado/ejercicio
            </h2>
            <asp:Panel ID="pnlBuscaEmps" runat="server">
                <uc1:wucBuscaEmpleados ID="WucBuscaEmpleados1" runat="server" EnableViewState="true" />
            </asp:Panel>
            <asp:Panel ID="pnl1" runat="server" HorizontalAlign="Left">
                <asp:Panel ID="pnlAños" runat="server" DefaultButton="btnConsultar" Font-Names="Verdana"
                    Font-Size="X-Small" GroupingText="Seleccione ejercicio">
                    <br />
                    <asp:DropDownList ID="ddlAños" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlAños_SelectedIndexChanged"
                        SkinID="SkinDropDownList">
                    </asp:DropDownList>
                    <asp:Button ID="btnConsultar" runat="server" SkinID="SkinBoton" Text="Consultar"
                        ToolTip="Consultar el acumulado anual de subsidio para el empleo del empleado seleccionado"
                        Visible="False" /><br />
                </asp:Panel>
            </asp:Panel>
            <asp:Panel ID="pnl2" runat="server"  HorizontalAlign="Left">
                <asp:Panel ID="pnlEmpInf" runat="server" HorizontalAlign="Left">
                    <asp:Label ID="lblEmpInf" runat="server" Font-Strikeout="False" Font-Underline="True"
                        SkinID="SkinLblDatos">
                    </asp:Label>
                </asp:Panel>
                <ajaxToolkit:CollapsiblePanelExtender ID="CPEPercsVigs" runat="Server" CollapseControlID="TitlePnlPagosPorvisionados"
                    Collapsed="False" CollapsedImage="~/Imagenes/expand_blue.jpg" CollapsedText="(Mostrar detalles...)"
                    ExpandControlID="TitlePnlPagosPorvisionados" ExpandedImage="~/Imagenes/collapse_blue.jpg"
                    ExpandedText="(Ocultar detalles...)" ImageControlID="imgPagosPorvisionados" SuppressPostBack="true"
                    TargetControlID="ContentPnlPagosPorvisionados" TextLabelID="lblPagosPorvisionados">
                </ajaxToolkit:CollapsiblePanelExtender>
                <asp:Panel ID="TitlePnlPagosPorvisionados" runat="server" BorderColor="White" BorderStyle="Solid"
                    BorderWidth="1px" CssClass="collapsePanelHeader" Width="100%">
                    <asp:Image ID="imgPagosPorvisionados" runat="server" ImageUrl="~/Imagenes/expand_blue.jpg" />
                    &nbsp;Pagos provisionados
                    <asp:Label ID="lblPagosPorvisionados" runat="server">(Mostrar detalles...)</asp:Label>
                </asp:Panel>
                <asp:Panel ID="ContentPnlPagosPorvisionados" runat="server" CssClass="collapsePanel"
                    Width="100%">
                    <asp:GridView ID="gvPagosPorvisionados" runat="server" Height="100%" 
                        SkinID="SkinGridViewEmpty" Width="100%" AutoGenerateColumns="False" 
                        ShowHeaderWhenEmpty="True">
                        <Columns>
                            <asp:BoundField DataField="IdPercepcion" HeaderText="IdPercepcion" Visible="False" />
                            <asp:BoundField DataField="ClavePercepcion" HeaderText="Clave">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="NombrePercepcion" HeaderText="Percepci&#243;n" />
                            <asp:BoundField DataField="Importe" DataFormatString="{0:c}" HeaderText="Importe">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>
                            <asp:BoundField DataField="FechaDePagoEnNomina" DataFormatString="{0:d}" HeaderText="Fecha de pago en Nómina">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                        </Columns>
                        <EmptyDataTemplate>
                            <asp:Label ID="lblgvPagosPorvisionadosVacio" runat="server" 
                                SkinID="SkinLblMsjErrores" 
                                Text="No existe información de pagos provisionados para el empleado en el ejercicio indicado."></asp:Label>
                        </EmptyDataTemplate>
                    </asp:GridView>
                </asp:Panel>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
