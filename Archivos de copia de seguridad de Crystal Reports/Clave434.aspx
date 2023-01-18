<%@ Page Language="VB" EnableEventValidation="false" MasterPageFile="~/MasterPageSesionIniciada.master"
    AutoEventWireup="false" CodeFile="Clave434.aspx.vb" Inherits="ConsultasDeduccionesClave434"
    Title="COBAEV - Nómina - Préstamo hipotecario FOVISSSTE" StylesheetTheme="SkinFile" %>
<%@ Register Src="~/WebControls/wucSearchEmps.ascx" TagName="wucBuscaEmpleados" TagPrefix="uc1" %>
<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress" TagPrefix="TP_wucUpdateProgress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
    <table style="width: 100%; height: 300px" align="center">
        <tr>
            <td style="vertical-align: top; text-align: right">
                <h2>
                    Sistema de nómina: Empleados (Información sobre créditos hipotecarios FOVISSSTE)
                </h2>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top; width: 100%; text-align: left">
                <table style="width: 100%">
                    <tr>
                        <td>
                            <uc1:wucBuscaEmpleados ID="WucBuscaEmpleados1" runat="server" EnableViewState="true" />
                        </td>
                        <td style="vertical-align: top; text-align: right">
                            &nbsp;<asp:ImageButton ID="ibActualizar" runat="server" ImageUrl="~/Imagenes/Refresh.jpg"
                                ToolTip="Actualizar información" /><br />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top; width: 100%; height: 100%; text-align: left">
                <table style="width: 100%">
                    <tr>
                        <td style="width: 100%">
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                <asp:Panel ID="pnl1" runat="server">
                                    <ajaxToolkit:CollapsiblePanelExtender ID="CPEEmpsConClave434" runat="Server" CollapseControlID="TitlePanelEmpsConClave434"
                                        Collapsed="False" CollapsedImage="~/Imagenes/expand_blue.jpg" CollapsedText="(Mostrar detalles...)"
                                        ExpandControlID="TitlePanelEmpsConClave434" ExpandedImage="~/Imagenes/collapse_blue.jpg"
                                        ExpandedText="(Ocultar detalles...)" ImageControlID="Image1" SuppressPostBack="true"
                                        TargetControlID="ContentPanelEmpsConClave434" TextLabelID="Label1">
                                    </ajaxToolkit:CollapsiblePanelExtender>
                                    <table cellpadding="0" cellspacing="0" style="width: 100%">
                                        <tbody>
                                            <tr>
                                                <td style="vertical-align: top; width: 100%; text-align: left;">
                                                    <asp:Panel ID="TitlePanelEmpsConClave434" runat="server" BorderColor="White" BorderStyle="Solid"
                                                        BorderWidth="1px" CssClass="collapsePanelHeader" Width="100%">
                                                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/expand_blue.jpg" />
                                                        &nbsp;Información sobre porcentajes de descuento de préstamo hipotecario FOVISSSTE
                                                        <asp:Label ID="Label1" runat="server">(Mostrar detalles...)</asp:Label>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="vertical-align: top; width: 100%; text-align: left">
                                                    <asp:Panel ID="ContentPanelEmpsConClave434" runat="server" CssClass="collapsePanel"
                                                        Height="100%" Width="100%">
                                                        <asp:GridView ID="gvEmpleado" runat="server" AutoGenerateColumns="False" SkinID="SkinGridView">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="IdEmp" Visible="False">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblIdEmp" runat="server" Text='<%# Bind("IdEmp") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="NumEmp" HeaderText="Num. Emp.">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="RFC" HeaderText="R.F.C." />
                                                                <asp:BoundField DataField="CURP" HeaderText="C.U.R.P." />
                                                                <asp:BoundField DataField="ApellidoPaterno" HeaderText="Apellido paterno" />
                                                                <asp:BoundField DataField="ApellidoMaterno" HeaderText="Apellido materno" />
                                                                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                                                                <asp:BoundField DataField="IdPlantel" HeaderText="IdPlantel" Visible="False" />
                                                                <asp:TemplateField HeaderText="Clave plantel">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblClavePlantel" runat="server" Text='<%# Bind("ClavePlantel") %>'
                                                                            ToolTip='<%# Bind("DescPlantel") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="DescPlantel" HeaderText="Plantel" Visible="False" />
                                                            </Columns>
                                                        </asp:GridView>
                                                        <br />
                                                        <asp:GridView ID="gvHistoriaClave434" runat="server" EmptyDataText="Sin información de préstamos hipotecarios FOVISSSTE."
                                                            SkinID="SkinGridView">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Porcentaje">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblPorcDesc" runat="server" Text='<%# Bind("PorcDesc", "{0:f2}%") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="IdQnaIni" Visible="False">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblIdQnaIni" runat="server" Text='<%# Bind("IdQnaIni") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="QnaIni" HeaderText="Inicio">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                                <asp:TemplateField HeaderText="IdQnaFin" Visible="False">
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("IdQnaFin") %>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblIdQnaFin" runat="server" Text='<%# Bind("IdQnaFin") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="QnaFin" HeaderText="Fin">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                                <asp:TemplateField Visible="False">
                                                                    <ItemTemplate>
                                                                        <asp:ImageButton ID="ibHistoriaPago" runat="server" CommandName="HistoriaPago" ImageUrl="~/Imagenes/Detalles.gif"
                                                                            ToolTip="Consultar historia de pagos asociados a porcentaje" />
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <ItemTemplate>
                                                                        <asp:ImageButton ID="ibModificar" runat="server" ImageUrl="~/Imagenes/Modificar.png"
                                                                            ToolTip="Modificar/Cambiar porcentaje de descuento." OnClick="ibModificar_Click" />
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="vertical-align: top; width: 100%; text-align: left">
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                    </asp:Panel>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ibActualizar" EventName="Click" />
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
