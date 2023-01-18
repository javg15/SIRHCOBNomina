<%@ Page Language="VB" EnableEventValidation="false" MasterPageFile="~/MasterPageSesionIniciada.master"
    AutoEventWireup="false" CodeFile="PensionAlimenticia.aspx.vb" Inherits="ConsultasPensionAlimenticia"
    Title="COBAEV - Nómina - Consulta de empleados con pensión alimenticia" StylesheetTheme="SkinFile" %>

<%@ Register Src="~/WebControls/wucSearchEmps.ascx" TagName="wucBuscaEmpleados" TagPrefix="uc1" %>
<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress" TagPrefix="TP_wucUpdateProgress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
    <table style="background-position: center center; width: 100%; background-repeat: no-repeat;
        height: 300px" align="center">
        <tr>
            <td style="vertical-align: top; text-align: right">
                <h2>
                    Sistema de nómina: Empleados (Información sobre beneficiarios de pensión alimenticia)
                </h2>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top; width: 100%; height: 100%; text-align: left">
                <table style="width: 100%">
                    <tr>
                        <td style="width: 100%">
                            <table style="width: 100%">
                                <tr>
                                    <td style="vertical-align: top; text-align: left">
                                        <uc1:wucBuscaEmpleados ID="WucBuscaEmpleados1" runat="server" EnableViewState="true">
                                        </uc1:wucBuscaEmpleados>
                                    </td>
                                    <td style="vertical-align: top; text-align: right">
                                        <asp:ImageButton ID="ibActualizar" runat="server" ImageUrl="~/Imagenes/Refresh.jpg"
                                            ToolTip="Actualizar información" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100%">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                <asp:Panel ID="pnl1" runat="server">
                                    <asp:Label ID="lblEmpInf" runat="server" Font-Strikeout="False" Font-Underline="True"
                                        SkinID="SkinLblDatos" Visible="False"></asp:Label><br />
                                    <br />
                                    <asp:LinkButton ID="lbAgregarNuevo" runat="server" Font-Bold="False" Font-Italic="False"
                                        SkinID="SkinLinkButton" ToolTip="Agregar nuevo beneficiario  para pensión alimenticia"
                                        Visible="False" OnClick="lbAgregarNuevo_Click">Agregar nuevo beneficiario</asp:LinkButton>
                                </asp:Panel>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ibActualizar" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="WucBuscaEmpleados1" EventName="PreRender" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100%">
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                <asp:Panel ID="pnl2" runat="server">
                                    <ajaxToolkit:CollapsiblePanelExtender ID="CPEPensionados" runat="Server" CollapseControlID="TitlePanelPensionados"
                                        Collapsed="False" CollapsedImage="~/Imagenes/expand_blue.jpg" CollapsedText="(Mostrar detalles...)"
                                        ExpandControlID="TitlePanelPensionados" ExpandedImage="~/Imagenes/collapse_blue.jpg"
                                        ExpandedText="(Ocultar detalles...)" ImageControlID="Image1" SuppressPostBack="true"
                                        TargetControlID="ContentPanelPensionados" TextLabelID="Label1">
                                    </ajaxToolkit:CollapsiblePanelExtender>
                                    <table cellpadding="0" cellspacing="0" style="width: 100%">
                                        <tbody>
                                            <tr>
                                                <td colspan="2" style="vertical-align: top; width: 100%; text-align: left">
                                                    <asp:Panel ID="TitlePanelPensionados" runat="server" BorderColor="White" BorderStyle="Solid"
                                                        BorderWidth="1px" CssClass="collapsePanelHeader" Width="100%">
                                                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/expand_blue.jpg" />
                                                        Beneficiarios de pensión alimenticia (Vigentes)
                                                        <asp:Label ID="Label1" runat="server">(Mostrar detalles...)</asp:Label>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="vertical-align: top; width: 100%; text-align: left">
                                                    <asp:Panel ID="ContentPanelPensionados" runat="server" CssClass="collapsePanel" Width="100%">
                                                        <asp:GridView ID="gvPensionados" runat="server" EmptyDataText="Sin información de beneficarios de pensión alimenticia vigentes"
                                                            SkinID="SkinGridView" Width="100%" AutoGenerateColumns="False">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="IdBeneficiario" Visible="False">
                                                                    <EditItemTemplate>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblIdBeneficiario" runat="server" Text='<%# Bind("IdBeneficiario") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="RFC" HeaderText="RFC" />
                                                                <asp:BoundField DataField="ApePat" HeaderText="Apellido paterno" />
                                                                <asp:BoundField DataField="ApeMat" HeaderText="Apellido materno" />
                                                                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                                                                <asp:BoundField DataField="DescParentesco" HeaderText="Parentesco" />
                                                                <asp:BoundField DataField="Porcentaje" HeaderText="Porcentaje">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="PrioridadCalculo" HeaderText="Prioridad">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="QnaIni" HeaderText="Inicio">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="QnaFin" HeaderText="T&#233;rmino">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="DescPlantel" HeaderText="Plantel de pago">
                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                </asp:BoundField>
                                                                <asp:TemplateField>
                                                                    <ItemTemplate>
                                                                        <asp:ImageButton ID="ibModificar" runat="server" ImageUrl="~/Imagenes/Modificar.png"
                                                                            ToolTip="Modificar la información del beneficiario" OnClick="ibModificar_Click" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <ItemTemplate>
                                                                        <asp:ImageButton ID="ibBaja" runat="server" ImageUrl="~/Imagenes/HandDown.png" ToolTip="Modificar la vigencia final del beneficiario"
                                                                            OnClick="ibBaja_Click" />
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <ItemTemplate>
                                                                        <asp:ImageButton ID="ibEliminar" runat="server" ImageUrl="~/Imagenes/Eliminar.png"
                                                                            ToolTip="Eliminar registro de beneficiario de pensión alimenticia" OnClick="ibEliminar_Click" />
                                                                        <ajaxToolkit:ConfirmButtonExtender ID="CBEEliminar" runat="server" ConfirmText="La operación solicitada eliminará definitivamente éste registro de la Base de Datos, ¿Continuar?"
                                                                            TargetControlID="ibEliminar">
                                                                        </ajaxToolkit:ConfirmButtonExtender>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="vertical-align: top; width: 100%; height: 20px; text-align: left">
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                    </asp:Panel>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ibActualizar" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="WucBuscaEmpleados1" EventName="PreRender" />
                                    <asp:AsyncPostBackTrigger ControlID="lbAgregarNuevo" EventName="Click" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100%">
                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                <ContentTemplate>
                                <asp:Panel ID="pnl3" runat="server">
                                    <ajaxToolkit:CollapsiblePanelExtender ID="CollapsiblePanelExtender1" runat="Server"
                                        CollapseControlID="TitlePanelPensionados2" Collapsed="False" CollapsedImage="~/Imagenes/expand_blue.jpg"
                                        CollapsedText="(Mostrar detalles...)" ExpandControlID="TitlePanelPensionados2"
                                        ExpandedImage="~/Imagenes/collapse_blue.jpg" ExpandedText="(Ocultar detalles...)"
                                        ImageControlID="Image3" SuppressPostBack="true" TargetControlID="ContentPanelPensionados2"
                                        TextLabelID="Label3">
                                    </ajaxToolkit:CollapsiblePanelExtender>
                                    <table cellpadding="0" cellspacing="0" style="width: 100%">
                                        <tbody>
                                            <tr>
                                                <td colspan="2" style="vertical-align: top; width: 100%; text-align: left">
                                                    <asp:Panel ID="TitlePanelPensionados2" runat="server" BorderColor="White" BorderStyle="Solid"
                                                        BorderWidth="1px" CssClass="collapsePanelHeader" Width="100%">
                                                        <asp:Image ID="Image3" runat="server" ImageUrl="~/Imagenes/expand_blue.jpg" />
                                                        Beneficiarios de pensión alimenticia (Histórico)
                                                        <asp:Label ID="Label3" runat="server">(Mostrar detalles...)</asp:Label>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="vertical-align: top; width: 100%; text-align: left">
                                                    <asp:Panel ID="ContentPanelPensionados2" runat="server" CssClass="collapsePanel"
                                                        Width="100%">
                                                        <asp:GridView ID="gvPensionados2" runat="server" EmptyDataText="Sin información histórica de beneficarios de pensión alimenticia"
                                                            SkinID="SkinGridView" Width="100%" AutoGenerateColumns="False" OnRowDataBound="gvPensionados2_RowDataBound">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="IdBeneficiario" Visible="False">
                                                                    <EditItemTemplate>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblIdBeneficiario" runat="server" Text='<%# Bind("IdBeneficiario") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="RFC" HeaderText="RFC" />
                                                                <asp:BoundField DataField="ApePat" HeaderText="Apellido paterno" />
                                                                <asp:BoundField DataField="ApeMat" HeaderText="Apellido materno" />
                                                                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                                                                <asp:BoundField DataField="DescParentesco" HeaderText="Parentesco" />
                                                                <asp:BoundField DataField="Porcentaje" HeaderText="Porcentaje">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="PrioridadCalculo" HeaderText="Prioridad">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="QnaIni" HeaderText="Inicio">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="QnaFin" HeaderText="T&#233;rmino">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="DescPlantel" HeaderText="Plantel de pago">
                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                </asp:BoundField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="vertical-align: top; width: 100%; height: 20px; text-align: left">
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                    </asp:Panel>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ibActualizar" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="WucBuscaEmpleados1" EventName="PreRender" />
                                    <asp:AsyncPostBackTrigger ControlID="lbAgregarNuevo" EventName="Click" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
