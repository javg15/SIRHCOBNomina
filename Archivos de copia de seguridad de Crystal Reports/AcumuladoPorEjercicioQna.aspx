<%@ Page Language="VB" EnableEventValidation="false" MasterPageFile="~/MasterPageBlanca.master" AutoEventWireup="false" CodeFile="AcumuladoPorEjercicioQna.aspx.vb" Inherits="EjerciciosFiscalesAcumuladoPorEjercicioQna" title="COBAEV - Nómina - Ejercicios fiscales, acumulados" StylesheetTheme="SkinFile" %>
<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress" TagPrefix="TP_wucUpdateProgress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
    <table border="0" cellpadding="0" cellspacing="0" style="width: 70%;">
        <tr>
            <td colspan="2" style="vertical-align: top; text-align: right">
                <h2>
                    Sistema de nómina: Declaración anual (Acumulados y Cálculo)
                </h2>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: left">
                <br />
                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                    <ContentTemplate>
                <asp:Label ID="Label1" runat="server" SkinID="SkinLblNormal" Text="Seleccione ejercicio"></asp:Label><br />
                <asp:DropDownList ID="ddlAnios" runat="server" SkinID="SkinDropDownList" AutoPostBack="True">
                </asp:DropDownList>&nbsp;<asp:Button ID="btnConsultar" runat="server" Text="Consultar" SkinID="SkinBoton" />&nbsp;<asp:Button
                    ID="btnGeneraAcumulado" runat="server" SkinID="SkinBoton" Text="Generar acumulado"
                    Width="216px" />&nbsp;<asp:Button ID="btnGenerarDecAnual" runat="server" 
                        SkinID="SkinBoton" Text="Generar declaración anual" Width="216px" />
                        <ajaxToolkit:ConfirmButtonExtender ID="cbebtnGeneraAcumulado" runat="server" ConfirmText="¿Realmente desea generar el acumulado anual para el ejercicio seleccionado?"
                            TargetControlID="btnGeneraAcumulado">
                        </ajaxToolkit:ConfirmButtonExtender>
                        <ajaxToolkit:ConfirmButtonExtender ID="cbebtnGenerarDecAnual" runat="server" ConfirmText="¿Realmente desea generar la declaración anual para el ejercicio seleccionado?"
                            TargetControlID="btnGenerarDecAnual">
                        </ajaxToolkit:ConfirmButtonExtender>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td style="width: 25%; vertical-align: top; text-align: left; height: 700px;">
                <br /><asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                <asp:Label ID="Label2" runat="server" SkinID="SkinLblNormal" Text="Quincenas del ejercicio"></asp:Label><asp:Label ID="lblEjercicio" runat="server" SkinID="SkinLblMsjExito"></asp:Label>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnConsultar" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
                <div style="overflow: auto; width: 190px; height: 600px">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                <asp:GridView ID="gvQnas" runat="server" AutoGenerateColumns="False" SkinID="SkinGridView" EmptyDataText="Quincenas inexistentes.">
                    <Columns>
                        <asp:TemplateField HeaderText="IdQuincena" Visible="False">
                            <ItemTemplate>
                                <asp:Label ID="lblIdQuincena" runat="server" Text='<%# Bind("IdQuincenaAplicacion") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Quincena">
                            <ItemTemplate>
                                <asp:Label ID="lblQuincena" runat="server" Text='<%# Bind("strQuincena") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Wrap="False" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="FechaDePago" DataFormatString="{0:d}" HeaderText="Fecha de pago" Visible="False">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" Wrap="True" />
                        </asp:BoundField>
                        <asp:CommandField ShowSelectButton="True" />
                    </Columns>
                </asp:GridView>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnConsultar" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
                </div>
            </td>
            <td style="vertical-align: top; text-align: left; height: 700px; width: 75%;">
                <br /><asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                <asp:Label ID="Label3" runat="server" SkinID="SkinLblNormal" Text="Detalle de ejercicio"></asp:Label><asp:Label ID="lblEjercicio2" runat="server" SkinID="SkinLblMsjExito"></asp:Label>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="gvQnas" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="btnConsultar" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
                <div>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                <asp:GridView ID="gvDetalle" runat="server" SkinID="SkinGridView" AutoGenerateColumns="False" EmptyDataText="Detalle inexistente." ShowFooter="True" OnRowDataBound="gvDetalle_RowDataBound">
                    <Columns>
                        <asp:BoundField DataField="Clave" HeaderText="Clave">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Concepto" HeaderText="Concepto">
                            <ItemStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="TipoConcepto" HeaderText="P/D">
                            <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                            <ItemStyle HorizontalAlign="Center" Wrap="True" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Grava" HeaderText="Grava">
                            <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                            <ItemStyle HorizontalAlign="Center" Wrap="True" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="N&#243;mina">
                            <FooterTemplate>
                                <asp:Label ID="lblNominaNormal2" runat="server"></asp:Label>
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblNominaNormal" runat="server" Text='<%# Bind("ImporteNominaNormal", "{0:c}") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterStyle HorizontalAlign="Right" Wrap="False" />
                            <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                            <ItemStyle HorizontalAlign="Right" Wrap="False" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="N&#243;mina RP">
                            <FooterTemplate>
                                <asp:Label ID="lblNominaRP2" runat="server"></asp:Label>
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblNominaRP" runat="server" Text='<%# Bind("ImporteNominaRP", "{0:c}") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterStyle HorizontalAlign="Right" Wrap="False" />
                            <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                            <ItemStyle HorizontalAlign="Right" Wrap="False" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Compensaciones">
                            <FooterTemplate>
                                <asp:Label ID="lblCompe2" runat="server"></asp:Label>
                            </FooterTemplate>                        
                            <ItemTemplate>
                                <asp:Label ID="lblCompe" runat="server" Text='<%# Bind("ImporteCompe", "{0:c}") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterStyle HorizontalAlign="Right" Wrap="False" />
                            <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                            <ItemStyle HorizontalAlign="Right" Wrap="False" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Devol. N&#243;mina">
                            <FooterTemplate>
                                <asp:Label ID="lblDevolPR2" runat="server"></asp:Label>
                            </FooterTemplate>                        
                            <ItemTemplate>
                                <asp:Label ID="lblDevolPR" runat="server" Text='<%# Bind("ImporteDevolPR", "{0:c}") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterStyle HorizontalAlign="Right" Wrap="False" />
                            <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                            <ItemStyle HorizontalAlign="Right" Wrap="False" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Devol. N&#243;mina RP">
                            <FooterTemplate>
                                <asp:Label ID="lblDevolRP2" runat="server"></asp:Label>
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblDevolRP" runat="server" Text='<%# Bind("ImporteDevolRP", "{0:c}") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterStyle HorizontalAlign="Right" Wrap="False" />
                            <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                            <ItemStyle HorizontalAlign="Right" Wrap="False" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Recibos N&#243;mina">
                            <FooterTemplate>
                                <asp:Label ID="lblRecibosPR2" runat="server"></asp:Label>
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblRecibosPR" runat="server" Text='<%# Bind("ImporteRecibosPR", "{0:c}") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterStyle HorizontalAlign="Right" Wrap="False" />
                            <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                            <ItemStyle HorizontalAlign="Right" Wrap="False" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Recibos N&#243;mina RP">
                            <FooterTemplate>
                                <asp:Label ID="lblRecibosRP2" runat="server"></asp:Label>
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblRecibosRP" runat="server" Text='<%# Bind("ImporteRecibosRP", "{0:c}") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterStyle HorizontalAlign="Right" Wrap="False" />
                            <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                            <ItemStyle HorizontalAlign="Right" Wrap="False" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Devol. Recibos N&#243;mina">
                            <FooterTemplate>
                                <asp:Label ID="lblRecibosDevolPR2" runat="server"></asp:Label>
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblRecibosDevolPR" runat="server" Text='<%# Bind("ImporteRecibosDevolPR", "{0:c}") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterStyle HorizontalAlign="Right" Wrap="False" />
                            <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                            <ItemStyle HorizontalAlign="Right" Wrap="False" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Devol. Recibos N&#243;mina RP">
                            <FooterTemplate>
                                <asp:Label ID="lblRecibosDevolRP2" runat="server"></asp:Label>
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblRecibosDevolRP" runat="server" Text='<%# Bind("ImporteRecibosDevolRP", "{0:c}") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterStyle HorizontalAlign="Right" Wrap="False" />
                            <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                            <ItemStyle HorizontalAlign="Right" Wrap="False" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Claves Extra N&#243;mina">
                            <FooterTemplate>
                                <asp:Label ID="lblConceptosExtraParaDecAnual2" runat="server"></asp:Label>
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblConceptosExtraParaDecAnual" runat="server" Text='<%# Bind("ImporteConceptosExtraParaDecAnual", "{0:c}") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterStyle HorizontalAlign="Right" Wrap="False" />
                            <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                            <ItemStyle HorizontalAlign="Right" Wrap="False" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Claves Extra N&#243;mina RP">
                            <FooterTemplate>
                                <asp:Label ID="lblConceptosExtraParaDecAnualRP2" runat="server"></asp:Label>
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblConceptosExtraParaDecAnualRP" runat="server" Text='<%# Bind("ImporteConceptosExtraParaDecAnualRP", "{0:c}") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterStyle HorizontalAlign="Right" Wrap="False" />
                            <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                            <ItemStyle HorizontalAlign="Right" Wrap="False" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Total por clave">
                            <FooterTemplate>
                                <asp:Label ID="lblTotalPorClave2" runat="server"></asp:Label>
                            </FooterTemplate>                        
                            <ItemTemplate>
                                <asp:Label ID="lblTotalPorClave" runat="server" Text='<%# Bind("TotalPorClave", "{0:c}") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterStyle HorizontalAlign="Right" Wrap="False" />
                            <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                            <ItemStyle HorizontalAlign="Right" Wrap="False" BackColor="#990000" Font-Bold="True" Font-Names="Verdana" ForeColor="White" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="gvQnas" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="btnConsultar" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>

