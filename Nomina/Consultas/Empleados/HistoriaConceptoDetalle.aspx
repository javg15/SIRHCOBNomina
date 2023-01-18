<%@ Page EnableEventValidation="false" Language="VB" MasterPageFile="~/MasterPageBlanca.master" AutoEventWireup="false" 
CodeFile="HistoriaConceptoDetalle.aspx.vb" Inherits="Consultas_Emps_HistoriaConceptoDetalle" 
title="COBAEV - Nómina - Historia conceptos detalle" Theme="SkinFile" StylesheetTheme="SkinFile" %>
<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress" TagPrefix="TP_wucUpdateProgress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
    <table style="width: 100%; height: 100%">
        <tr>
            <td style="vertical-align: top; text-align: right">
                <h2>
                    Sistema de nómina: Detalle de pago anual por concepto
                </h2>
            </td>
        </tr>
        <tr>
            <td style="text-align: left">
                <table>
                    <tr>
                        <td style="vertical-align: top; text-align: left">
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                    <asp:Panel ID="pnlAños" runat="server" Font-Names="Verdana"
                                        Font-Size="X-Small" GroupingText="Seleccione ejercicio">
                                        <br />
                                        <asp:DropDownList ID="ddlAños" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlAños_SelectedIndexChanged"
                                            SkinID="SkinDropDownList">
                                        </asp:DropDownList>
                                        <br />
                                    </asp:Panel>
                                    <br />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left; vertical-align: top;">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:Label ID="lblEmpInf" runat="server" Font-Strikeout="False" Font-Underline="True"
                                        SkinID="SkinLblDatos"></asp:Label><br />
                                    <asp:Label ID="lblInfConcepto" runat="server" Font-Strikeout="False" Font-Underline="True"
                                        SkinID="SkinLblDatos"></asp:Label><br />
                            <asp:GridView ID="gvDetalleConcepto" runat="server" AutoGenerateColumns="False" EmptyDataText="No existe detalle."
                                SkinID="SkinGridView" OnRowDataBound="gvDetalleConcepto_RowDataBound">
                                <Columns>
                                    <asp:BoundField DataField="Importe" HeaderText="Importe" DataFormatString="{0:c}">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="QuincenaPago" HeaderText="Quincena pago">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Origen" HeaderText="Origen">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Observaciones" HeaderText="Observaciones">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="QuincenaDevolucion" HeaderText="Quincena devoluci&#243;n">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddlA&#241;os" EventName="SelectedIndexChanged" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top; text-align: center">
    <asp:LinkButton ID="lbCerrar" runat="server" SkinID="SkinLinkButton">Cerrar ventana</asp:LinkButton></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="text-align: left">
    </td>
        </tr>
    </table>
</asp:Content>

