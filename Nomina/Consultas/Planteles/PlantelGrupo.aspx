<%@ Page Language="VB" EnableEventValidation="false" MasterPageFile="~/MasterPageBlanca.master"
    AutoEventWireup="false" CodeFile="PlantelGrupo.aspx.vb" Inherits="Consulta_PlantelGrupo"
    Title="COBAEV - Nómina - Relación plantel-grupo-materias" StylesheetTheme="SkinFile" %>
    <%@ MasterType VirtualPath="~/MasterPageBlanca.master" %>

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
                        Sistema de nómina: Relación Plantel/grupo/materias
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
                        Width="100%" ShowFooter="True">
                        <Columns>
                            <asp:CommandField ButtonType="Image" SelectImageUrl="~/Imagenes/Select.png" ShowSelectButton="True">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:CommandField>
                            <asp:TemplateField HeaderText="Grupo" Visible="True">
                                <ItemTemplate>
                                    <asp:Label ID="lblGrupo" runat="server" Text='<%# Bind("Grupo") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="IdMateria" Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblIdMateria" runat="server" Text='<%# Bind("IdMateria") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Clave materia">
                                <ItemTemplate>
                                    <asp:Label ID="lblClaveMateria" runat="server" 
s                                        Text='<%# Bind("ClaveMateria") %>' SkinID="SkinLblNormal" Visible="false"></asp:Label>
                                    <asp:LinkButton ID="lbClaveMateria" runat="server" 
                                        Text='<%# Bind("ClaveMateria") %>' SkinID="SkinLinkButton"
                                        ToolTip="Ver empleados que imparten la materia en el plantel (En la quincena indicada)"></asp:LinkButton>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="Claveasignatura" HeaderText="Clave asignatura">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="NombreMateria" HeaderText="Nombre materia">
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Horas">
                                <ItemTemplate>
                                    <asp:Label ID="lblHoras" runat="server" Text='<%# Bind("Horas") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="lblHoras2" runat="server" Text="0"></asp:Label>
                                </FooterTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                                <FooterStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="IdPlantel" Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblIdPlantel" runat="server" Text='<%# Bind("IdPlantel") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="IdEmp" Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblIdEmp" runat="server" Text='<%# Bind("IdEmp") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="NumEmp" HeaderText="Núm. Emp.">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ApePatEmp" HeaderText="Apellido paterno">
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ApeMatEmp" HeaderText="Apellido materno">
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="NomEmp" HeaderText="Nombre">
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="AbrevNombramiento" HeaderText="Nomb.">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="AbrevEstatus" HeaderText="Estatus">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Inicio" HeaderText="Inicio">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Fin" HeaderText="Fin">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
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
