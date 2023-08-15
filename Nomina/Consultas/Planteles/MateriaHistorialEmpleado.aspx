<%@ Page Language="VB" MasterPageFile="~/MasterPageBlanca.master"
    AutoEventWireup="false" CodeFile="MateriaHistorialEmpleado.aspx.vb" Inherits="MateriaHistorialEmpleado"
    Title="COBAEV - Nómina - Empleados, control de incidencias" StylesheetTheme="SkinFile" %>

<%@ Register Src="~/WebControls/wucSearchEmps.ascx" TagName="wucBuscaEmpleados" TagPrefix="uc1" %>
<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress"
    TagPrefix="TP_wucUpdateProgress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
    <table style="width: 100%;" align="center">
        <tr>
            <td style="vertical-align: top; text-align: right">
                <h2>
                    Sistema de nómina: Relación Empleado/Materia en el Plantel (Todos los grupos)
                </h2>
            </td>
        </tr>
    </table>
    <asp:UpdatePanel ID="UpdPnlMain" runat="server">
        <ContentTemplate>
            
                     <ajaxToolkit:CollapsiblePanelExtender ID="CPEMateriaHistorialEmpleado" runat="Server" SuppressPostBack="true"
                        CollapsedImage="~/Imagenes/expand_blue.jpg" ExpandedImage="~/Imagenes/collapse_blue.jpg"
                        ImageControlID="Image2" CollapsedText="(Mostrar detalles...)" ExpandedText="(Ocultar detalles...)"
                        TextLabelID="Label2" Collapsed="False" CollapseControlID="TitlePanelMateriaHistorialEmpleado"
                        ExpandControlID="TitlePanelMateriaHistorialEmpleado" TargetControlID="ContentPanelMateriaHistorialEmpleado">
                    </ajaxToolkit:CollapsiblePanelExtender>

                        <asp:Panel ID="ContentPanelMateriaHistorialEmpleado" runat="server" Width="100%" CssClass="collapsePanel">
                            <asp:Panel ID="pnlDatos" runat="server" Width="100%" GroupingText="Plazas">
                                <table style="width: 70%; vertical-align: top; text-align: center;" align="center">
                                    <tr>
                                        <td style="vertical-align: top; text-align: left">
                                            <asp:GridView ID="gvEmpleado" runat="server" CellPadding="1" SkinID="SkinGridView"
                                                Width="100%">
                                                <Columns>
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
                                                    <asp:BoundField DataField="ClaveMateria" HeaderText="Clave de Materia">
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                            <ItemStyle HorizontalAlign="Left" />
                                                        </asp:BoundField>
                                                    <asp:BoundField DataField="NombreMateria" HeaderText="Materia">
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                            <ItemStyle HorizontalAlign="Left" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Horas" HeaderText="Horas">
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                            <ItemStyle HorizontalAlign="Left" />
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
                                        <td style="text-align: left; vertical-align: top;" align="left">
                                            <table>
                                                <tr>
                                                    <td>
                                                        Grupo:
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlGrupo" runat="server" AutoPostBack="True"></asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        Docente:
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlDocente" runat="server" AutoPostBack="True"></asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: left; vertical-align: top;">
                                            <asp:GridView ID="gvDatos" runat="server" EmptyDataText="El empleado no tiene registradas plazas base"
                                                    Height="100%" ShowFooter="True" SkinID="SkinGridViewEmpty" Width="100%" 
                                                    AutoGenerateColumns="False" EnableViewState="true" AllowSorting="True">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="IdGrupo" Visible="False">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblIdGrupo" runat="server" Text='<%# Bind("IdGrupo") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Grupo" SortExpression="Grupo">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblGrupo" runat="server" Text='<%# Bind("Grupo") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Center" />
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
                                                        <asp:TemplateField HeaderText="Semestre" SortExpression="Semestre">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblSemestre" runat="server" Text='<%# Bind("Semestre") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Tipo Hora" SortExpression="TipoHora">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblTipoHora" runat="server" Text='<%# Bind("TipoHora") %>' ToolTip='<%# Bind("DescCategoria") %>' ></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                        
                                                        <asp:BoundField DataField="QuincenaIni" HeaderText="Quincena Inicio" SortExpression="QuincenaIni">
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                            <ItemStyle HorizontalAlign="Left" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="QuincenaFin" HeaderText="Quincena Fin" SortExpression="QuincenaFin">
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                            <ItemStyle HorizontalAlign="Left" />
                                                        </asp:BoundField>
                                                    </Columns>
                                                    <EmptyDataRowStyle Font-Bold="True" Font-Italic="True" />
                                                </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </asp:Panel>
                    
                
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
               