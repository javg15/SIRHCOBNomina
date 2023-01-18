<%@ Page Language="VB" EnableEventValidation="false" MasterPageFile="~/MasterPageSesionIniciada.master"
    AutoEventWireup="false" CodeFile="Quincenas.aspx.vb" Inherits="Administracion_Quincenas"
    Title="COBAEV - Nómina - Administración de quincenas" StylesheetTheme="SkinFile" %>

<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress"
    TagPrefix="TP_wucUpdateProgress" %>
<%@ Register Assembly="BusyBoxDotNet" Namespace="BusyBoxDotNet" TagPrefix="busyboxdotnet" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
    <asp:UpdatePanel ID="UPMain" runat="server">
        <ContentTemplate>
            <table style="width: 100%; vertical-align: top;" align="center">
                <tr>
                    <td style="vertical-align: top; text-align: right">
                        <h2>
                            Sistema de nómina: Quincenas (Administración por semestre)
                        </h2>
                    </td>
                </tr>
            </table>
            <asp:MultiView ID="MVQnas" runat="server" ActiveViewIndex="0">
                <asp:View ID="viewQnas" runat="server">
            <table style="width: 100%; vertical-align: top;" align="center">
                <tr>
                    <td style="vertical-align: top; text-align: left">
                                <br />
                                <asp:Panel ID="pnlSemestres" runat="server" DefaultButton="btnConsultarQuincenas"
                                    Font-Names="Verdana" Font-Size="X-Small" GroupingText="Seleccione semestre">
                                    <br />
                                    <asp:DropDownList ID="ddlSemestres" runat="server" SkinID="SkinDropDownList">
                                    </asp:DropDownList>
                                    <asp:Button ID="btnConsultarQuincenas" runat="server" SkinID="SkinBoton" Text="Ver quincenas"
                                        ToolTip="Consultar quincenas para el semestre seleccionado" OnClick="btnConsultarQuincenas_Click" /><br />
                                    <br />
                                </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: left; vertical-align: top;">
                                <asp:GridView ID="gvQuincenas" runat="server" CellPadding="1" SkinID="SkinGridView"
                                    Width="100%" AllowSorting="True">
                                    <Columns>
                                        <asp:TemplateField HeaderText="IdQuincena" Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="lblIdQuincena" runat="server" Text='<%# Bind("IdQuincena") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Quincena" SortExpression="Quincena">
                                            <ItemTemplate>
                                                <asp:Label ID="lblQuincena" runat="server" Text='<%# Bind("Quincena") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" Wrap="False" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="IdEstatusQuincena" Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="lblIdEstatusQuincena" runat="server" Text='<%# Bind("IdEstatusQuincena") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Estatus quincena">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDescEstatusQna" runat="server" Text='<%# Bind("DescEstatusQna") %>'
                                                    ToolTip='<%# Bind("AbrevEstatusQna") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="FechaCierre" DataFormatString="{0:d}" HeaderText="Fecha de cierre">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="FechaDePago" DataFormatString="{0:d}" HeaderText="Fecha de pago">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Observaciones2" HeaderText="Observaciones">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle Wrap="True" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="Adicional (+)">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ibAddAdic" runat="server" ImageUrl="~/Imagenes/Add2.png" ToolTip="Agregar quincena adicional" />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" Wrap="True" />
                                            <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Detalles">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ibDetalles" runat="server" ImageUrl="~/Imagenes/Detalles.gif"
                                                    ToolTip="Ver detalles de la quincena" />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Eliminar (x)">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ibEliminar" runat="server" ImageUrl="~/Imagenes/Eliminar.png"
                                                    ToolTip="Eliminar quincena adicional" />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Modificar">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ibModificar" runat="server" ImageUrl="~/Imagenes/Modificar.png"
                                                    ToolTip="Modificar datos de la quincena" />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" Wrap="False" />
                                            <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Validar">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ibValidar" runat="server" ImageUrl="~/Imagenes/ValidarNomina.png"
                                                    ToolTip="Validar algunos datos de la quincena" onclick="ibValidar_Click" />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" Wrap="False" />
                                            <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                    </td>
                </tr>
            </table>
            </asp:View>
                <asp:View ID="viewQnasResultsValidacion" runat="server">
                    <asp:Panel ID="pnlResultsValidacion" runat="server" 
                        Font-Names="Verdana" Font-Size="X-Small" GroupingText="" HorizontalAlign="Left">
                        <asp:DetailsView ID="dvResultsValidacion" runat="server" 
                            EmptyDataText="Sin resultados en la validación." SkinID="SkinDetailsView" 
                            AutoGenerateRows="False">
                            <Fields>
                                <asp:BoundField DataField="# Total de Empleados en Nómina" 
                                    HeaderText="# Total de Empleados en Nómina">
                                <HeaderStyle Wrap="False" />
                                <ItemStyle Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="# Total de Empleados con Importe Neto <= Cero" 
                                    HeaderText="# Total de Empleados con Importe Neto <= Cero">
                                <HeaderStyle Wrap="False" />
                                <ItemStyle Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="# Total de Empleados con Clave 496" 
                                    HeaderText="# Total de Empleados con Clave 496">
                                <HeaderStyle Wrap="False" />
                                <ItemStyle Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="# Total de Empleados con Clave 497" 
                                    HeaderText="# Total de Empleados con Clave 497">
                                <HeaderStyle Wrap="False" />
                                <ItemStyle Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="# Total de Empleados con Clave 401" 
                                    HeaderText="# Total de Empleados con Clave 401">
                                <HeaderStyle Wrap="False" />
                                <ItemStyle Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="# Total de Empleados con Clave 132" 
                                    HeaderText="# Total de Empleados con Clave 132">
                                <HeaderStyle Wrap="False" />
                                <ItemStyle Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="# Total de Empleados con Impuesto(401)/Subsidio(132)" 
                                    HeaderText="# Total de Empleados con Impuesto(401)/Subsidio(132)">                                
                                <HeaderStyle Wrap="False" />
                                <ItemStyle Wrap="False" />
                                </asp:BoundField>
                            </Fields>
                            <HeaderStyle HorizontalAlign="Left" Wrap="False" />
                            <RowStyle HorizontalAlign="Left" Wrap="false" />
                        </asp:DetailsView>
                        <br />
                        <asp:Button ID="btnRegresar" runat="server" SkinID="SkinBoton" Text="Regresar"
                            ToolTip="Regresar a la consulta de quincenas." CausesValidation="False" />
                    </asp:Panel>
                </asp:View>
            </asp:MultiView>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
