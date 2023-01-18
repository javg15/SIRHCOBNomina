<%@ Page Language="VB" EnableEventValidation="false" MasterPageFile="~/MasterPageSesionIniciada.master"
    AutoEventWireup="false" CodeFile="ConsultarMovsDePers.aspx.vb" Inherits="ConsultarMovsDePers"
    Title="COBAEV - Nómina - Movimientos de personal, consultas por empleado" StylesheetTheme="SkinFile" %>

<%@ Register Src="~/WebControls/wucSearchEmps.ascx" TagName="wucBuscaEmpleados"
    TagPrefix="uc1" %>
<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress"
    TagPrefix="TP_wucUpdateProgress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
    <table style="width: 100%; height: 300px" align="center">
        <tr>
            <td style="vertical-align: top; text-align: right">
                <h2>
                    Sistema de nómina: Movimientos de personal (Consulta por empleado)
                </h2>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top; width: 100%; height: 100%; text-align: left">
                <table style="width: 100%">
                    <tr>
                        <td style="vertical-align: top; text-align: left">
                            <table style="width: 100%">
                                <tr>
                                    <td>
                                        <uc1:wucBuscaEmpleados ID="WucBuscaEmpleados1" runat="server" EnableViewState="true" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top; text-align: left">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                   <asp:Panel ID="pnl1" runat="server">
                                    <ajaxToolkit:CollapsiblePanelExtender ID="CPEMovsDePers" runat="Server" CollapseControlID="TPMovsDePers"
                                        Collapsed="False" CollapsedImage="~/Imagenes/expand_blue.jpg" CollapsedText="(Mostrar detalles...)"
                                        ExpandControlID="TPMovsDePers" ExpandedImage="~/Imagenes/collapse_blue.jpg"
                                        ExpandedText="(Ocultar detalles...)" ImageControlID="Image1" SuppressPostBack="true"
                                        TargetControlID="CPMovsDePers" TextLabelID="S_H_Detalles">
                                    </ajaxToolkit:CollapsiblePanelExtender>
                                    <table cellpadding="0" cellspacing="0" style="width: 100%">
                                        <tbody>
                                            <tr>
                                                <td style="vertical-align: top; text-align: left">
                                                    <asp:Label ID="lblEmpInf" runat="server" Font-Strikeout="False" Font-Underline="True"
                                                        SkinID="SkinLblDatos"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="vertical-align: top; width: 100%; text-align: left">
                                                    <asp:Panel ID="TPMovsDePers" runat="server" BorderColor="White" BorderStyle="Solid"
                                                        BorderWidth="1px" CssClass="collapsePanelHeader" Width="100%">
                                                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/expand_blue.jpg" />
                                                        &nbsp;Movimientos de personal
                                                        <asp:Label ID="S_H_Detalles" runat="server">(Mostrar detalles...)</asp:Label>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="vertical-align: top; width: 100%; text-align: left">
                                                    <asp:Panel ID="CPMovsDePers" runat="server" CssClass="collapsePanel"
                                                        Width="100%">
                                                        <asp:GridView ID="gvMovsDePers" runat="server" EmptyDataText="El empleado no tiene movimientos de personal registrados."
                                                            Height="100%" SkinID="SkinGridView" Width="100%" 
                                                            >
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="IdMovPers" Visible="False">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblIdMovPers" runat="server" Text='<%# Bind("IdMovPers") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Tramite">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblTramite" runat="server" Text='<%# Bind("Tramite") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Motivo">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblMotivo" runat="server" Text='<%# Bind("Motivo") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Qna. Inicio">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblQnaInicio" runat="server" Text='<%# Bind("QnaInicio") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Qna. Término">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblQnaTermino" runat="server" Text='<%# Bind("QnaTermino") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Fecha Inicio">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblFechaIni" runat="server" Text='<%# Bind("FechaIni","{0:d}") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Fecha Término">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblFechaFin" runat="server" Text='<%# Bind("FechaFin","{0:d}") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Núm Oficio">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblNumOficio" runat="server" Text='<%# Bind("NumOficio") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Movto. en Nómina">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblDescTipoMovEnNomina" runat="server"  Text='<%# Bind("DescTipoMovEnNomina") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Movto. ante ISSSTE">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblDescTipoMovISSSTE" runat="server" Text='<%# Bind("DescTipoMovISSSTE") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Movto. ante CGE">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblDescTipoDeMovAnteCGE" runat="server" Text='<%# Bind("DescTipoDeMovAnteCGE") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Estatus Mov. Pers.">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblDescEstatusMovPers" runat="server" Text='<%# Bind("DescEstatusMovPers") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <EmptyDataTemplate>
                                                            </EmptyDataTemplate>
                                                        </asp:GridView>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="vertical-align: top; width: 100%; text-align: left">
                                                    &nbsp;</td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </asp:Panel>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="WucBuscaEmpleados1" EventName="PreRender" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    </table>
            </td>
        </tr>
    </table>
</asp:Content>
