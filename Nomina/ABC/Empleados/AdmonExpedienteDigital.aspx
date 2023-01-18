<%@ Page EnableEventValidation="false" Language="VB" MasterPageFile="~/MasterPageSesionIniciada.master"
    AutoEventWireup="false" CodeFile="AdmonExpedienteDigital.aspx.vb" Inherits="AdmonExpedienteDigital"
    Title="COBAEV - Nómina - Administración de expedientes digitales" StylesheetTheme="SkinFile" %>

<%@ Register Src="~/WebControls/wucSearchEmps.ascx" TagName="wucBuscaEmpleados" TagPrefix="uc1" %>
<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress" TagPrefix="TP_wucUpdateProgress" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
    <table style="width: 100%; height: 300px" align="center">
        <tr>
            <td style="vertical-align: top; text-align: right">
                <h2>
                    Sistema de nómina: Administración de expedientes digitales por empleado
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
                                    <td style="vertical-align: top; text-align: right">
                                        &nbsp;<asp:ImageButton ID="ibActualizar" runat="server" ImageUrl="~/Imagenes/Refresh.jpg"
                                            ToolTip="Actualizar información" CausesValidation="False" /><br />
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
                                        <ajaxToolkit:CollapsiblePanelExtender ID="CPEExpedientes" runat="Server" SuppressPostBack="true"
                                            CollapsedImage="~/Imagenes/expand_blue.jpg" ExpandedImage="~/Imagenes/collapse_blue.jpg"
                                            ImageControlID="Image2" CollapsedText="(Mostrar detalles...)" ExpandedText="(Ocultar detalles...)"
                                            TextLabelID="Label2" Collapsed="False" CollapseControlID="TitlePanelExpediente"
                                            ExpandControlID="TitlePanelExpediente" TargetControlID="ContentPanelExpediente">
                                        </ajaxToolkit:CollapsiblePanelExtender>
                                        <table style="width: 100%" cellspacing="0" cellpadding="0">
                                            <tbody>
                                                <tr>
                                                    <td style="vertical-align: top; text-align: left" colspan="2">
                                                        <asp:Label ID="lblEmpInf" runat="server" SkinID="SkinLblDatos" Font-Underline="True"
                                                            Font-Strikeout="False"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="vertical-align: top; width: 100%; text-align: left">
                                                        <asp:Panel ID="TitlePanelExpediente" runat="server" Width="100%" BorderWidth="1px"
                                                            BorderStyle="Solid" BorderColor="White" CssClass="collapsePanelHeader">
                                                            <asp:Image ID="Image2" runat="server" ImageUrl="~/Imagenes/expand_blue.jpg"></asp:Image>
                                                            Expediente digital
                                                            <asp:Label ID="Label2" runat="server">(Mostrar detalles...)</asp:Label>
                                                        </asp:Panel>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="vertical-align: top; width: 100%; text-align: left;">
                                                        <asp:Panel ID="ContentPanelExpediente" runat="server" Width="100%" 
                                                            CssClass="collapsePanel" HorizontalAlign="Left">
                                                            <asp:GridView ID="gvDocumentos" runat="server" AutoGenerateColumns="False" 
                                                                SkinID="SkinGridView" EmptyDataText="Sin información de expediente digital."
                                                                OnRowDataBound="gvDocumentos_RowDataBound">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Clave">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblCveDoc" runat="server" Text='<%# Bind("CveDoc") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="DescDoc" HeaderText="Descripci&#243;n" />
                                                                    <asp:BoundField DataField="NumPag" HeaderText="No. hoja">
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                    </asp:BoundField>
                                                                    <asp:TemplateField HeaderText="Nombre archivo" Visible="False">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblNomArch" runat="server" Text='<%# Bind("NomArchivo") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <ItemTemplate>
                                                                            <asp:ImageButton ID="ibEliminar" runat="server" CausesValidation="False" ImageUrl="~/Imagenes/Eliminar.png"
                                                                                OnClick="ibEliminar_Click" ToolTip="Eliminar documento" />
                                                                            <ajaxToolkit:ConfirmButtonExtender ID="CFEEliminar" runat="server" ConfirmText="¿Está seguro de eliminar el documento?"
                                                                                TargetControlID="ibEliminar">
                                                                            </ajaxToolkit:ConfirmButtonExtender>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lbVerDoc" CausesValidation="False" runat="server" ToolTip="Ver documento en formato PDF"
                                                                                Visible="False">Ver</asp:LinkButton><asp:ImageButton ID="ibVerDoc" runat="server"
                                                                                    CausesValidation="False" ImageUrl="~/Imagenes/Buscar.jpg" ToolTip="Ver documento en formato PDF" />
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <EmptyDataTemplate>
                                                                    <asp:LinkButton ID="lbCrearExpediente" runat="server" Font-Bold="False" Font-Italic="False"
                                                                        OnClick="lbCrearExpediente_Click" SkinID="SkinLinkButton" CausesValidation="False">Crear expediente</asp:LinkButton>
                                                                    <ajaxToolkit:ConfirmButtonExtender ID="CBECrearExpediente" runat="server" ConfirmText="¿Está seguro de crear el expediente para el empleado?"
                                                                        TargetControlID="lbCrearExpediente">
                                                                    </ajaxToolkit:ConfirmButtonExtender>
                                                                </EmptyDataTemplate>
                                                            </asp:GridView>
                                                        </asp:Panel>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </asp:Panel>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ibActualizar" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="WucBuscaEmpleados1" EventName="PreRender" />
                                    <asp:AsyncPostBackTrigger ControlID="gvDocumentos" EventName="DataBound" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                    </tr>
                    </table>
            </td>
        </tr>
    </table>
</asp:Content>
