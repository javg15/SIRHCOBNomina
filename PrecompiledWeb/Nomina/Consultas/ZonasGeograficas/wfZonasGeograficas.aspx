<%@ page language="VB" enableeventvalidation="false" masterpagefile="~/MasterPageSesionIniciada.master" autoeventwireup="false" inherits="Consultas_wfZonasGeograficas, App_Web_rhut5ev3" title="COBAEV - Nómina - Zonas geográficas" stylesheettheme="SkinFile" maintainScrollPositionOnPostBack="true" %>

<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress"
    TagPrefix="TP_wucUpdateProgress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UPMain" runat="server">
        <ContentTemplate>
            <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
            <table style="width: 100%; vertical-align: top;" align="center">
                <tr>
                    <td style="vertical-align: top; text-align: right">
                        <h2>
                            Sistema de nómina: Consulta de zonas geográficas
                        </h2>
                    </td>
                </tr>
            </table>
            <asp:Panel ID="pnlZonasGeo" runat="server" Font-Names="Verdana" Font-Size="X-Small"
                GroupingText="Zonas geográficas" HorizontalAlign="Left">
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
            </asp:Panel>
            <asp:Panel ID="pnlPlantelesPorZG" runat="server" Font-Names="Verdana" Font-Size="X-Small"
                GroupingText="Planteles de la zona geográfica:" HorizontalAlign="Left">
            <asp:GridView ID="gvCTs" runat="server" CellPadding="1" SkinID="SkinGridView" Visible="False"
                Width="100%">
                <Columns>
                    <asp:TemplateField HeaderText="IdCT" Visible="False">
                        <ItemTemplate>
                            <asp:Label ID="lblIdCT" runat="server" Text='<%# Bind("IdCT") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="ClaveCT" HeaderText="Clave">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
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
                    <asp:TemplateField HeaderText="Empleados" Visible="false">
                        <ItemTemplate>
                            <asp:ImageButton ID="ibEmpPorCT" runat="server" ImageUrl="~/Imagenes/Empleado.jpg"
                                ToolTip="Ver empleados por centro de trabajo" />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
