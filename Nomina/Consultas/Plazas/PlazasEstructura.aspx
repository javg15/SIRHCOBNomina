<%@ Page Language="VB" MasterPageFile="~/MasterPageSesionIniciada.master"
    AutoEventWireup="false" CodeFile="PlazasEstructura.aspx.vb" Inherits="PlazasEstructura"
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
                    Sistema de nómina: Consulta de Estrucutra de Plazas
                </h2>
            </td>
        </tr>
    </table>
    <asp:UpdatePanel ID="UpdPnlMain" runat="server">
        <ContentTemplate>
            
            <asp:Panel ID="pnlBusquedaControles" runat="server" GroupingText="Parámetros de busqueda"
                        HorizontalAlign="Left" DefaultButton="btnMostrar">
                    <table class="style1" style="width: 100%">
                        <tr>
                            <td style="text-align: left; width: 250px;" valign="middle">
                                <asp:Label ID="lblPlantel" runat="server" SkinID="SkinLblNormal" Text="Plantel"></asp:Label>
                            </td>
                            <td style="width: 600px; text-align: left;" valign="middle">
                                <asp:DropDownList ID="ddlPlanteles" runat="server" SkinID="SkinDropDownList">
                                </asp:DropDownList>
                            </td>
                            <td style="width: 10px; text-align: left;" valign="middle">
                                <asp:ImageButton ID="ibCleanPlanteles" runat="server" 
                                    ImageUrl="~/Imagenes/Eliminar.png" ToolTip="Limpiar" OnClick="ibCleanPlanteles_Click" style="width: 15px" />
                            </td>
                            <td style="width: 1000px; text-align: left;" valign="middle">
                                
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left; width: 250px;" valign="middle">
                                <asp:Label ID="lblCategoria" runat="server" SkinID="SkinLblNormal" Text="Categoría"></asp:Label>
                            </td>
                            <td style="width: 600px; text-align: left;" valign="middle">
                                <asp:DropDownList ID="ddlCategorias" runat="server" SkinID="SkinDropDownList">
                                </asp:DropDownList>
                            </td>
                            <td style="width: 10px; text-align: left;" valign="middle">
                                <asp:ImageButton ID="ibCleanCategoria" runat="server" 
                                    ImageUrl="~/Imagenes/Eliminar.png" ToolTip="Limpiar" OnClick="ibCleanCategoria_Click" />
                            </td>
                            <td style="width: 1000px; text-align: left;" valign="middle">
                                
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left; width: 250px;" valign="middle">
                                <asp:Label ID="lblTipoPlaza" runat="server" SkinID="SkinLblNormal" Text="Tipo de plaza"></asp:Label>
                            </td>
                            <td style="width: 600px; text-align: left;" valign="middle">
                                <asp:DropDownList ID="ddlTipoPlaza" runat="server" SkinID="SkinDropDownList">
                                </asp:DropDownList>
                            </td>
                            <td style="width: 10px; text-align: left;" valign="middle">
                                <asp:ImageButton ID="ibCleanTipoPlaza" runat="server" 
                                    ImageUrl="~/Imagenes/Eliminar.png" ToolTip="Limpiar" OnClick="ibCleanTipoPlaza_Click"  />
                            </td>
                            <td style="width: 1000px; text-align: left;" valign="middle">
                                
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left; width: 250px;" valign="middle">
                                <asp:Label ID="lblEstatusPlaza" runat="server" SkinID="SkinLblNormal" Text="Estatus de plaza"></asp:Label>
                            </td>
                            <td style="width: 600px; text-align: left;" valign="middle">
                                <asp:DropDownList ID="ddlEstatusPlaza" runat="server" SkinID="SkinDropDownList">
                                </asp:DropDownList>
                            </td>
                            <td style="width: 10px; text-align: left;" valign="middle">
                                <asp:ImageButton ID="ibCleanEstatusPlaza" runat="server" 
                                    ImageUrl="~/Imagenes/Eliminar.png" ToolTip="Limpiar" OnClick="ibCleanEstatusPlaza_Click" />
                            </td>
                            <td style="width: 1000px; text-align: left;" valign="middle">
                                
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left; width: 250px;" valign="middle">
                                <asp:Label ID="Label1" runat="server" SkinID="SkinLblNormal" Text="Empleado"></asp:Label>
                            </td>
                            <td style="width: 600px; text-align: left;" valign="middle">
                                <uc1:wucBuscaEmpleados ID="WucBuscaEmpleados1" runat="server" EnableViewState="True" Visible="True" />
                            </td>
                            <td>
                                <asp:ImageButton ID="ibCleanEmpleado" runat="server" 
                                    ImageUrl="~/Imagenes/Eliminar.png" ToolTip="Limpiar" OnClick="ibCleanEmpleado_Click"  />
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td colspan="2">
                                <asp:Label ID="lblMsjSinFiltros" runat="server" Text="** Elija al menos un filtro de busqueda para mostrar la información" ForeColor="#990000" Visible="False" Font-Size="12"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td></td><td></td>
                            <td style="text-align: right; width: 250px;" valign="middle">
                                <asp:Button ID="btnMostrar" runat="server" SkinID="SkinBoton" Text="Mostrar información" BackColor="#EEEEEE" Height="50px"  />
                            </td>
                        </tr>
                        
                    </table>
                    </asp:Panel>
                     <ajaxToolkit:CollapsiblePanelExtender ID="CPEPlazasEstructura" runat="Server" SuppressPostBack="true"
                        CollapsedImage="~/Imagenes/expand_blue.jpg" ExpandedImage="~/Imagenes/collapse_blue.jpg"
                        ImageControlID="Image2" CollapsedText="(Mostrar detalles...)" ExpandedText="(Ocultar detalles...)"
                        TextLabelID="Label2" Collapsed="False" CollapseControlID="TitlePanelPlazasEstructura"
                        ExpandControlID="TitlePanelPlazasEstructura" TargetControlID="ContentPanelPlazasEstructura">
                    </ajaxToolkit:CollapsiblePanelExtender>

                        <asp:Panel ID="ContentPanelPlazasEstructura" runat="server" Width="100%" CssClass="collapsePanel">
                            <asp:Panel ID="pnlDatos" runat="server" Width="100%" GroupingText="Plazas"
                                >
                                <asp:GridView ID="gvDatos" runat="server" AutoGenerateColumns="False" EmptyDataText="No existe información de permisos económicos en el año seleccionado."
                                    PageSize="20" SkinID="SkinGridView" Width="100%" >
                                    <EmptyDataTemplate>
                                        <div>
                                            <asp:Label ID="lblMsjSinPermisosEco" runat="server" Text="No existe información de permisos económicos en el año/mes seleccionado."></asp:Label>
                                        </div>
                                    </EmptyDataTemplate>
                                    <EmptyDataRowStyle Font-Italic="True" />
                                    <Columns>
                                        <asp:CommandField ButtonType="Image" SelectImageUrl="~/Imagenes/Select.png" ShowSelectButton="True">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:CommandField>
                                        <asp:TemplateField HeaderText="ID">
                                            <ItemTemplate>
                                                <asp:Label ID="lblNo" runat="server" Text='<%# Bind("IdPlazas") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Plantel">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl2" runat="server" Text='<%# Bind("DescPlantelPlaza") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Categoría">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl3" runat="server" Text='<%# Bind("DescCategoria") %>'></asp:Label></ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Función">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl4" runat="server" Text='<%# Bind("Funcion") %>'></asp:Label></ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Estatus (Base)">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl5" runat="server" Text='<%# Bind("DescEstatusPlazaBase") %>'></asp:Label></ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="Empleado Titular">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl6" runat="server" Text='<%# Bind("NombT") %>'></asp:Label></ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Ultimo Nomb de Titular">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl7" runat="server" Text='<%# Bind("infoT") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Inicio (Base)">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl9" runat="server" Text='<%# Bind("QuinInicio") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Término (Base)">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl10" runat="server" Text='<%# Bind("QuinTermino") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Empleado Ocupante">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl8" runat="server" Text='<%# Bind("NombO") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        
                                        
                                    </Columns>
                                </asp:GridView>
                            </asp:Panel>
                        </asp:Panel>
                    
                
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
               