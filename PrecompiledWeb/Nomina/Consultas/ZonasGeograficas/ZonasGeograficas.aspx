<%@ page language="VB" enableeventvalidation="false" masterpagefile="~/MasterPageSesionIniciada.master" autoeventwireup="false" inherits="Consultas_ZonasGeograficas, App_Web_rhut5ev3" title="COBAEV - Nómina - Zonas geográficas" stylesheettheme="SkinFile" maintainScrollPositionOnPostBack="true" %>

<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress" TagPrefix="TP_wucUpdateProgress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
    <table style="width: 100%; vertical-align: top;" align="center">
        <tr>
            <td style="vertical-align: top; text-align: right">
                <h2>
                    Sistema de nómina: Consulta de zonas geográficas
                </h2>
            </td>
        </tr>
        <tr>
            <td style="text-align: left; vertical-align: top;">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="gvZonasGeo" runat="server" CellPadding="1" SkinID="SkinGridView"
                            Width="100%">
                            <Columns>
                                <asp:TemplateField HeaderText="IdZonaGeografica" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIdZonaGeografica" runat="server" Text='<%# Bind("IdZonaGeografica") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Zona geogr&#225;fica">
                                    <ItemTemplate>
                                        <asp:Label ID="lblNombreZonaGeografica" runat="server" Text='<%# Bind("NombreZonaGeografica") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Planteles">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ibPlantel" runat="server" ImageUrl="~/Imagenes/Schools.png"
                                            ToolTip="Ver planteles por zona geográfica" CommandName="VerPlanteles" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle HorizontalAlign="Center" />
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
                            </Columns>
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td style="text-align: left">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="gvCTs" runat="server" CellPadding="1" SkinID="SkinGridView" Visible="False"
                            Width="100%">
                            <Columns>
                                <asp:TemplateField HeaderText="IdCT" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIdCT" runat="server" Text='<%# Bind("IdCT") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="ClaveCT" HeaderText="Clave">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="NombreCT" HeaderText="Centro de trabajo">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Zona econ&#243;mica">
                                    <ItemTemplate>
                                        <asp:Label ID="lblZE" runat="server" Text='<%# Bind("ClaveZonaEco") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Zona geogr&#225;fica">
                                    <ItemTemplate>
                                        <asp:Label ID="lblZG" runat="server" Text='<%# Bind("IdZonaGeografica") %>' ToolTip='<%# Bind("NombreZonaGeografica") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Empleados">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ibEmpPorCT" runat="server" ImageUrl="~/Imagenes/Empleado.jpg"
                                            ToolTip="Ver empleados por centro de trabajo" />
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="gvZonasGeo" EventName="RowCommand" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>
