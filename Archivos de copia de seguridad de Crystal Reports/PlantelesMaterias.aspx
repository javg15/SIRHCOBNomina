<%@ Page Language="VB" EnableEventValidation="false" MasterPageFile="~/MasterPageBlanca.master"
    AutoEventWireup="false" CodeFile="PlantelesMaterias.aspx.vb" Inherits="Consulta_PlantelesMaterias"
    Title="COBAEV - Nómina - Relación plantel-materias" StylesheetTheme="SkinFile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<script type="text/javascript">
    self.focus();
</script>
<asp:UpdatePanel id="updpnlGlobal" runat="server">
    <ContentTemplate>
    <asp:Panel id="divExport" runat="server">
        <table style="width: 70%; vertical-align: top; text-align: center;" align="center">
            <tr>
                <td style="vertical-align: top; text-align: left">
                    <h2>
                        Sistema de nómina: Relación Plantel/Materias
                    </h2>
                </td>
            </tr>
            <tr>
                <td style="vertical-align: top; text-align: left">
                    <asp:GridView ID="gvPlantel" runat="server" CellPadding="1" SkinID="SkinGridView"
                        Width="100%">
                        <Columns>
                            <asp:TemplateField HeaderText="IdPlantel" Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblIdPlantel" runat="server" Text='<%# Bind("IdPlantel") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="ClavePlantel" HeaderText="Clave plantel">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="DescPlantel" HeaderText="Plantel">
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="IdZonaEco" HeaderText="IdZonaEco" Visible="False" />
                            <asp:BoundField DataField="ClaveZonaEco" HeaderText="Zona económica">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="IdZonaGeografica" HeaderText="IdZonaGeografica" Visible="False" />
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td style="text-align: left; vertical-align: top;">
                </td>
            </tr>
            <tr>
                <td style="text-align: left; vertical-align: top;">
                    <asp:Label ID="lblInfRelQna" runat="server" SkinID="SkinLblDatos"></asp:Label>
                    <asp:GridView ID="gvMaterias" runat="server" CellPadding="1" SkinID="SkinGridView"
                        Width="100%">
                        <Columns>
                            <asp:CommandField ButtonType="Image" SelectImageUrl="~/Imagenes/Select.png" ShowSelectButton="True">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:CommandField>
                            <asp:TemplateField HeaderText="IdMateria" Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblIdMateria" runat="server" Text='<%# Bind("IdMateria") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Clave materia" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblClaveMateria" runat="server" 
                                        Text='<%# Bind("ClaveMateria") %>' SkinID="SkinLblNormal"></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Clave materia">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbClaveMateria" runat="server" 
                                        Text='<%# Bind("ClaveMateria") %>' SkinID="SkinLinkButton"
                                        ToolTip="Ver empleados que imparten la materia en el plantel (En la quincena indicada)"></asp:LinkButton>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="NombreMateria" HeaderText="Nombre materia">
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Semestre" HeaderText="Semestre">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="IdPlantel" Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblIdPlantel" runat="server" Text='<%# Bind("IdPlantel") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td style="text-align: left; vertical-align: top;">
                    <asp:Button ID="btnExport" runat="server" SkinID="SkinBoton" Text="Exportar a EXCEL" />
                    &nbsp;<asp:Button ID="btnExport0" runat="server" SkinID="SkinBoton" 
                        Text="Exportar a PDF" Visible="False" />
                </td>
            </tr>
        </table>
    </asp:Panel>
    </ContentTemplate>
    <Triggers>
        <asp:PostBackTrigger ControlID="btnExport" />
        <asp:PostBackTrigger ControlID="btnExport0" />
    </Triggers>
</asp:UpdatePanel>
</asp:Content>
