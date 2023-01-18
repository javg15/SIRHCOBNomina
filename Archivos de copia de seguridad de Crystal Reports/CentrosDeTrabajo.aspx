<%@ Page Language="VB" EnableEventValidation="false" MasterPageFile="~/MasterPageSesionIniciada.master"
    AutoEventWireup="false" CodeFile="CentrosDeTrabajo.aspx.vb" Inherits="Administracion_CentrosDeTrabajo"
    Title="COBAEV - Nómina - Centros de trabajo" StylesheetTheme="SkinFile" %>

<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress"
    TagPrefix="TP_wucUpdateProgress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UPMain" runat="server">
        <ContentTemplate>
            <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
            <table style="width: 100%; vertical-align: top; text-align: center;" align="center">
                <tr>
                    <td style="vertical-align: top; text-align: right">
                        <h2>
                            Sistema de nómina: Centros de trabajo
                        </h2>
                    </td>
                </tr>
            </table>
            <asp:Panel ID="pnlTiposDeCT" runat="server" Font-Names="Verdana" Font-Size="X-Small"
                GroupingText="Seleccione tipo de centro de trabajo" HorizontalAlign="Left">
                <asp:DropDownList ID="ddlFiltroTipoCT" runat="server" SkinID="SkinDropDownList" AutoPostBack="True">
                </asp:DropDownList>
                <asp:Button ID="btnConsultar" runat="server" SkinID="SkinBoton9pt" Text="Consultar"
                    ToolTip="Consultar centros de trabajo asociados al tipo de centro de trabajo seleccionado." />
            </asp:Panel>
            <asp:Panel ID="pnlCTsPorTipo" runat="server" Font-Names="Verdana" Font-Size="X-Small" GroupingText="Centros de trabajo asociados al tipo: "
                HorizontalAlign="Left">
                <asp:GridView ID="gvCTs" runat="server" CellPadding="1" SkinID="SkinGridView" 
                    Width="100%" AllowSorting="True">
                    <Columns>
                        <asp:TemplateField HeaderText="IdCT" Visible="False">
                            <ItemTemplate>
                                <asp:Label ID="lblIdCT" runat="server" Text='<%# Bind("IdCT") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="ClaveCT" HeaderText="Clave" SortExpression="ClaveCT">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="NombreCT" HeaderText="Centro de trabajo" SortExpression="NombreCT">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Zona econ&#243;mica" SortExpression="ClaveZonaEco">
                            <ItemTemplate>
                                <asp:Label ID="lblZE" runat="server" Text='<%# Bind("ClaveZonaEco") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Zona grogr&#225;fica" SortExpression="IdZonaGeografica">
                            <ItemTemplate>
                                <asp:Label ID="lblZG" runat="server" Text='<%# Bind("IdZonaGeografica") %>' ToolTip='<%# Bind("NombreZonaGeografica") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="IdUsuario" Visible="False">
                            <ItemTemplate>
                                <asp:Label ID="lblIdUsuario" runat="server" Text='<%# Bind("IdUsuario") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Analista de zona">
                            <ItemTemplate>
                                <asp:Label ID="lblNombreAnalista" runat="server"></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Empleados">
                            <ItemTemplate>
                                <asp:ImageButton ID="ibEmpPorCT" runat="server" ImageUrl="~/Imagenes/Empleado.jpg"
                                    ToolTip="Ver empleados por centro de trabajo" />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField Visible="False">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbModificar" runat="server">Modificar</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
