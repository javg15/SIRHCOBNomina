<%@ Page Language="VB" EnableEventValidation="false" MasterPageFile="~/MasterPageBlanca.master"
    AutoEventWireup="false" CodeFile="MateriaEnPlantel.aspx.vb" Inherits="Consulta_MateriaEnPlantel"
    Title="COBAEV - N�mina - Relaci�n plantel-materia-empleados" StylesheetTheme="SkinFile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<script type="text/javascript">
    self.focus();
</script>
<script type="text/javascript">
    function PrintGridData() {
        var printGrid = document.getElementById('<%=gvPlantel.ClientID %>');
        var printGrid2 = document.getElementById('<%=gvMateria.ClientID %>');
        var printGrid3 = document.getElementById('<%=gvEmpleados.ClientID %>');
        var printwin = window.open('', 'Impresi�n',
'left=100,top=100,width=600,height=600,tollbar=0,scrollbars=1,status=0,resizable=1');
        printwin.document.write(printGrid.outerHTML);
        printwin.document.write(printGrid2.outerHTML);
        printwin.document.write(printGrid3.outerHTML);
        printwin.document.close();
        printwin.focus();
        printwin.print();
        printwin.close();
    }
   </script> 
<asp:UpdatePanel id="updpnlGlobal" runat="server">
    <ContentTemplate>
    <asp:Panel id="divExport" runat="server">
        <table style="width: 70%; vertical-align: top; text-align: center;" align="center">
            <tr>
                <td style="vertical-align: top; text-align: left">
                    <h2>
                        Sistema de n�mina: Relaci�n Plantel/Materia/Empleados
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
                            <asp:BoundField DataField="ClaveZonaEco" HeaderText="Zona econ�mica">
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
                <td style="vertical-align: top; text-align: left">
                    <asp:GridView ID="gvMateria" runat="server" CellPadding="1" SkinID="SkinGridView"
                        Width="100%">
                        <Columns>
                            <asp:TemplateField HeaderText="IdMateria" Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblIdMateria" runat="server" Text='<%# Bind("IdMateria") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="ClaveMateria" HeaderText="Clave materia">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Nombremateria2" HeaderText="Descripci�n materia">
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="HorasMateria" HeaderText="Horas">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
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
                    <asp:GridView ID="gvEmpleados" runat="server" CellPadding="1" SkinID="SkinGridView"
                        Width="100%">
                        <Columns>
                            <asp:CommandField ButtonType="Image" SelectImageUrl="~/Imagenes/Select.png" ShowSelectButton="True">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:CommandField>
                            <asp:TemplateField HeaderText="IdGrupo" Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblIdGrupo" runat="server" Text='<%# Bind("IdGrupo") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Grupo" Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblGrupo" runat="server" Text='<%# Bind("Grupo") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Grupo">
                                <ItemTemplate>
                                    <asp:Label ID="lblGrupoAux" runat="server" Text='<%# Bind("Grupo") %>' Visible="false"></asp:Label>
                                    <asp:LinkButton ID="lbGrupo" runat="server" 
                                        Text='<%# Bind("Grupo") %>' SkinID="SkinLinkButton" ToolTip="Ver materias que se imparten en el plantel/grupo (En la quincena indicada)"
                                        Visible="true"></asp:LinkButton>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="IdEmp" Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblIdEmp" runat="server" Text='<%# Bind("IdEmp") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="NumEmp" HeaderText="N�m. Emp.">
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
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td style="text-align: left; vertical-align: top;">
                    <asp:Button ID="btnExport" runat="server" SkinID="SkinBoton" Text="Exportar a EXCEL" />
                    &nbsp;<asp:Button ID="btnExport0" runat="server" SkinID="SkinBoton" 
                        Text="Exportar a PDF" Visible="False" />
                    <asp:Button ID="btnImprimir" runat="server" SkinID="SkinBoton" 
                        Text="Imprimir" OnClientClick="PrintGridData();" Visible="False"/>
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
