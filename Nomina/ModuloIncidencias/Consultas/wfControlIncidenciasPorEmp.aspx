<%@ Page EnableEventValidation="false" Language="VB" MasterPageFile="~/MasterPageSesionIniciada.master"
    AutoEventWireup="false" CodeFile="wfControlIncidenciasPorEmp.aspx.vb" Inherits="wfControlIncidenciasPorEmp"
    Title="COBAEV - Nómina - Empleados, control de incidencias" StylesheetTheme="SkinFile" %>

<%@ Register Src="~/WebControls/wucSearchEmps.ascx" TagName="wucBuscaEmpleados" TagPrefix="uc1" %>
<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress"
    TagPrefix="TP_wucUpdateProgress" %>
<%@ Register Src="../../WebControls/wucCalendario2.ascx" TagName="wucCalendario2" TagPrefix="uc2" %>
<%@ Register src="../../WebControls/wucMuestraErrores.ascx" tagname="wucMuestraErrores" tagprefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    °<TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
    <table style="width: 100%;" align="center">
        <tr>
            <td style="vertical-align: top; text-align: right">
                <h2>
                    Sistema de nómina: Empleados (Administración de incidencias por año)
                </h2>
            </td>
        </tr>
    </table>
    <asp:UpdatePanel ID="UpdPnlMain" runat="server">
        <ContentTemplate>
            <uc1:wucBuscaEmpleados ID="WucBuscaEmpleados1" runat="server" EnableViewState="true" />
            <asp:MultiView ID="MultiView1" runat="server">
                <asp:View ID="viewControlIncidencias" runat="server">
                    <ajaxToolkit:CollapsiblePanelExtender ID="CPEEmpsDiasEco" runat="Server" SuppressPostBack="true"
                        CollapsedImage="~/Imagenes/expand_blue.jpg" ExpandedImage="~/Imagenes/collapse_blue.jpg"
                        ImageControlID="Image2" CollapsedText="(Mostrar detalles...)" ExpandedText="(Ocultar detalles...)"
                        TextLabelID="Label2" Collapsed="False" CollapseControlID="TitlePanelEmpsDiasEco"
                        ExpandControlID="TitlePanelEmpsDiasEco" TargetControlID="ContentPanelEmpsDiasEco">
                    </ajaxToolkit:CollapsiblePanelExtender>
                    <ajaxToolkit:CollapsiblePanelExtender ID="CPEAusenciasJustificadas" runat="Server" SuppressPostBack="true"
                        CollapsedImage="~/Imagenes/expand_blue.jpg" ExpandedImage="~/Imagenes/collapse_blue.jpg"
                        ImageControlID="imgAusenciasJustificadas" CollapsedText="(Mostrar detalles...)" ExpandedText="(Ocultar detalles...)"
                        TextLabelID="lblAusenciasJustificadas" Collapsed="True" CollapseControlID="TitlePanelAusenciasJustificadas"
                        ExpandControlID="TitlePanelAusenciasJustificadas" TargetControlID="ContentPanelAusenciasJustificadas">
                    </ajaxToolkit:CollapsiblePanelExtender>
                    <ajaxToolkit:CollapsiblePanelExtender ID="CPEAusenciasNoJustificadas" runat="Server" SuppressPostBack="true"
                        CollapsedImage="~/Imagenes/expand_blue.jpg" ExpandedImage="~/Imagenes/collapse_blue.jpg"
                        ImageControlID="imgAusenciasNoJustificadas" CollapsedText="(Mostrar detalles...)" ExpandedText="(Ocultar detalles...)"
                        TextLabelID="lblAusenciasNoJustificadas" Collapsed="True" CollapseControlID="TitlePanelAusenciasNoJustificadas"
                        ExpandControlID="TitlePanelAusenciasNoJustificadas" TargetControlID="ContentPanelAusenciasNoJustificadas">
                    </ajaxToolkit:CollapsiblePanelExtender>
                    <ajaxToolkit:CollapsiblePanelExtender ID="CPEOtros" runat="Server" SuppressPostBack="true"
                        CollapsedImage="~/Imagenes/expand_blue.jpg" ExpandedImage="~/Imagenes/collapse_blue.jpg"
                        ImageControlID="imgOtros" CollapsedText="(Mostrar detalles...)" ExpandedText="(Ocultar detalles...)"
                        TextLabelID="lblOtros" Collapsed="True" CollapseControlID="TitlePanelOtros"
                        ExpandControlID="TitlePanelOtros" TargetControlID="ContentPanelOtros">
                    </ajaxToolkit:CollapsiblePanelExtender>
                    <ajaxToolkit:CollapsiblePanelExtender ID="CPELicMed" runat="Server" SuppressPostBack="true"
                        CollapsedImage="~/Imagenes/expand_blue.jpg" ExpandedImage="~/Imagenes/collapse_blue.jpg"
                        ImageControlID="imgLicMed" CollapsedText="(Mostrar detalles...)" ExpandedText="(Ocultar detalles...)"
                        TextLabelID="lblLicMed" Collapsed="True" CollapseControlID="TitlePanelLicMed"
                        ExpandControlID="TitlePanelLicMed" TargetControlID="ContentPanelLicMed">
                    </ajaxToolkit:CollapsiblePanelExtender>
                    <ajaxToolkit:CollapsiblePanelExtender ID="CPEPermSindic" runat="Server" SuppressPostBack="true"
                        CollapsedImage="~/Imagenes/expand_blue.jpg" ExpandedImage="~/Imagenes/collapse_blue.jpg"
                        ImageControlID="imgPermSindic" CollapsedText="(Mostrar detalles...)" ExpandedText="(Ocultar detalles...)"
                        TextLabelID="lblPermSindic" Collapsed="True" CollapseControlID="TitlePanelPermSindic"
                        ExpandControlID="TitlePanelPermSindic" TargetControlID="ContentPanelPermSindic">
                    </ajaxToolkit:CollapsiblePanelExtender>

                    <ajaxToolkit:CollapsiblePanelExtender ID="CPEPerm2Hrs" runat="Server" SuppressPostBack="true"
                        CollapsedImage="~/Imagenes/expand_blue.jpg" ExpandedImage="~/Imagenes/collapse_blue.jpg"
                        ImageControlID="imgPerm2Hrs" CollapsedText="(Mostrar detalles...)" ExpandedText="(Ocultar detalles...)"
                        TextLabelID="lblPerm2Hrs" Collapsed="True" CollapseControlID="TitlePanelPerm2Hrs"
                        ExpandControlID="TitlePanelPerm2Hrs" TargetControlID="ContentPanelPerm2Hrs">
                    </ajaxToolkit:CollapsiblePanelExtender>

                    

                    <div style="text-align: left;">
                        <asp:Label ID="lblEmpInf" runat="server" SkinID="SkinLblDatos" Font-Underline="True"
                            Font-Strikeout="False"></asp:Label>
                    </div>
                    <asp:Panel ID="pnlTiposDeIncidencias" runat="server" GroupingText="Tipos de incidencias"
                        HorizontalAlign="Left">
                        <asp:DropDownList ID="ddlTiposDeIncidencias" runat="server" SkinID="SkinDropDownList">
                        </asp:DropDownList>
                        <asp:Button ID="btnCapturarIncidencia" runat="server" SkinID="SkinBoton" Text="Capturar"
                            ToolTip="Capturar incidencia seleccionada" CausesValidation="False" /><br />
                    </asp:Panel>
                    <asp:Panel ID="pnlAños" runat="server" DefaultButton="btnConsultar" GroupingText="Seleccione año"
                        HorizontalAlign="Left">
                        <asp:DropDownList ID="ddlAños" runat="server" SkinID="SkinDropDownList">
                        </asp:DropDownList>
                        <asp:Button ID="btnConsultar" runat="server" OnClick="btnConsultar_Click" SkinID="SkinBoton"
                            Text="Consultar" ToolTip="Consultar incidencias relacionadas con el empleado"
                            CausesValidation="False" /><br />
                    </asp:Panel>
                    <asp:Panel runat="server" ID="pnlControlIncidencias" GroupingText="Incidencias del empleado en el Año: Sin especificar"
                        HorizontalAlign="Left">
                        <asp:Panel ID="TitlePanelEmpsDiasEco" runat="server" Width="100%" BorderWidth="1px"
                            BorderStyle="Solid" BorderColor="White" CssClass="collapsePanelHeader">
                            <asp:Image ID="Image2" runat="server" ImageUrl="~/Imagenes/expand_blue.jpg"></asp:Image>
                            &nbsp;Permisos económicos
                            <asp:Label ID="Label2" runat="server">(Mostrar detalles...)</asp:Label>
                        </asp:Panel>
                        <asp:Panel ID="ContentPanelEmpsDiasEco" runat="server" Width="100%" CssClass="collapsePanel">
                            <asp:GridView ID="gvResumenPermEco" runat="server" AutoGenerateColumns="False" SkinID="SkinGridView"
                                Width="100%">
                                <Columns>
                                    <asp:TemplateField HeaderText="Ene">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbEnero" runat="server" Text='<%# Bind("Enero") %>' CausesValidation="False"
                                                OnClick="lbVerDetallePermEco_Click" CommandArgument="1"></asp:LinkButton>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Feb">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbFebrero" CommandArgument="2" runat="server" Text='<%# Eval("Febrero") %>'
                                                OnClick="lbVerDetallePermEco_Click" ToolTip="Ver detalle" CausesValidation="False"></asp:LinkButton></ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Mar">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbMarzo" CommandArgument="3" runat="server" Text='<%# Eval("Marzo") %>'
                                                OnClick="lbVerDetallePermEco_Click" ToolTip="Ver detalle" CausesValidation="False"></asp:LinkButton></ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Abr">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbAbril" CommandArgument="4" runat="server" Text='<%# Eval("Abril") %>'
                                                OnClick="lbVerDetallePermEco_Click" ToolTip="Ver detalle" CausesValidation="False"></asp:LinkButton></ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="May">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbMayo" CommandArgument="5" runat="server" Text='<%# Eval("Mayo") %>'
                                                OnClick="lbVerDetallePermEco_Click" ToolTip="Ver detalle" CausesValidation="False"></asp:LinkButton></ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Jun">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbJunio" CommandArgument="6" runat="server" Text='<%# Eval("Junio") %>'
                                                OnClick="lbVerDetallePermEco_Click" ToolTip="Ver detalle" CausesValidation="False"></asp:LinkButton></ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Jul">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbJulio" CommandArgument="7" runat="server" Text='<%# Eval("Julio") %>'
                                                OnClick="lbVerDetallePermEco_Click" ToolTip="Ver detalle" CausesValidation="False"></asp:LinkButton></ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Ago">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbAgosto" CommandArgument="8" runat="server" Text='<%# Eval("Agosto") %>'
                                                OnClick="lbVerDetallePermEco_Click" ToolTip="Ver detalle" CausesValidation="False"></asp:LinkButton></ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Sep">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbSeptiembre" CommandArgument="9" runat="server" Text='<%# Eval("Septiembre") %>'
                                                OnClick="lbVerDetallePermEco_Click" ToolTip="Ver detalle" CausesValidation="False"></asp:LinkButton></ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Oct">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbOctubre" CommandArgument="10" runat="server" Text='<%# Eval("Octubre") %>'
                                                OnClick="lbVerDetallePermEco_Click" ToolTip="Ver detalle" CausesValidation="False"></asp:LinkButton></ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Nov">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbNoviembre" CommandArgument="11" runat="server" Text='<%# Eval("Noviembre") %>'
                                                OnClick="lbVerDetallePermEco_Click" ToolTip="Ver detalle" CausesValidation="False"></asp:LinkButton></ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Dic">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbDiciembre" CommandArgument="12" runat="server" Text='<%# Eval("Diciembre") %>'
                                                OnClick="lbVerDetallePermEco_Click" ToolTip="Ver detalle" CausesValidation="False"></asp:LinkButton></ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Permisos económicos<br />(Gran total anual)">
                                        <ItemTemplate>
                                            <asp:Label ID="lbPermEcoTot" runat="server" Text='<%# Eval("TotalPermEco") %>' Font-Bold="true"></asp:Label></ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" Width="150px" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <asp:Panel ID="pnlPermEcoDetalleMes" runat="server" Width="100%" GroupingText="Detalle del mes: Sin Especificar"
                                >
                                <asp:GridView ID="gvDiasEco" runat="server" AutoGenerateColumns="False" EmptyDataText="No existe información de permisos económicos en el año seleccionado."
                                    OnSelectedIndexChanged="gvDiasEco_SelectedIndexChanged" PageSize="20" SkinID="SkinGridView"
                                    Width="100%" >
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
                                                <asp:Label ID="lblIdIncidencia" runat="server" Text='<%# Bind("Id") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Folio incidencia">
                                            <ItemTemplate>
                                                <asp:Label ID="lblFolioIncidencia" runat="server" Text='<%# Bind("FolioIncidencia") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Fecha inicial del permiso económico">
                                            <ItemTemplate>
                                                <asp:Label ID="lblFechaIni" runat="server" Text='<%# Bind("FechaIni", "{0:d}") %>'></asp:Label></ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Fecha final del permiso económico">
                                            <ItemTemplate>
                                                <asp:Label ID="lblFechaFin" runat="server" Text='<%# Bind("FechaFin", "{0:d}") %>'></asp:Label></ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Día(s)">
                                            <ItemTemplate>
                                                <asp:Label ID="lblNumDias" runat="server" Text='<%# Bind("NumDias") %>'></asp:Label></ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Autorizados por Jefe">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDiasAutPorJefe" runat="server" Text='<%# Bind("AutorizadaPorJefe") %>'></asp:Label></ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Observaciones">
                                            <ItemTemplate>
                                                <asp:Label ID="lblFolioIncidencia2" runat="server" Text='<%# Bind("FolioIncidencia2") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="IDS afectados">
                                            <ItemTemplate>
                                                <asp:Label ID="lblIdsAfectados" runat="server" Text='<%# Bind("idsAfectados") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="FechaCaptura" DataFormatString="{0:d}" HeaderText="Fecha Captura/Modificación"
                                            ReadOnly="True">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="Capturado/Modificado por">
                                            <ItemTemplate>
                                                <asp:Label ID="lblIdUsuario" runat="server" Text='<%# Bind("IdUsuario") %>' Visible="False"></asp:Label><asp:Label
                                                    ID="lblLogin" runat="server"></asp:Label></ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="" Visible="false">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ibEditar" runat="server" CausesValidation="False" ImageUrl="~/Imagenes/Modificar.png"
                                                    ToolTip="Modificar" OnClick="ibEditar_Click" /></ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ibEliminar" runat="server" CausesValidation="False"
                                                    ImageUrl="~/Imagenes/Eliminar.png" ToolTip="Eliminar" OnClick="ibEliminar_Click" /><ajaxToolkit:ConfirmButtonExtender
                                                        ID="CBEEliminar" runat="server" ConfirmText="La operación solicitada eliminará el registro de la Base de datos, ¿Continuar?"
                                                        TargetControlID="ibEliminar">
                                                    </ajaxToolkit:ConfirmButtonExtender>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>

                                    </Columns>
                                </asp:GridView>
                            </asp:Panel>
                        </asp:Panel>
                        <asp:Panel ID="TitlePanelAusenciasJustificadas" runat="server" Width="100%" BorderWidth="1px"
                            BorderStyle="Solid" BorderColor="White" CssClass="collapsePanelHeader">
                            <asp:Image ID="imgAusenciasJustificadas" runat="server" ImageUrl="~/Imagenes/expand_blue.jpg">
                            </asp:Image>
                            &nbsp;Ausencias Justificadas
                            <asp:Label ID="lblAusenciasJustificadas" runat="server">(Mostrar detalles...)</asp:Label>
                        </asp:Panel>
                        <asp:Panel ID="ContentPanelAusenciasJustificadas" runat="server" Width="100%" CssClass="collapsePanel">
                            <asp:GridView ID="gvResumenAusenciasJustificadas" runat="server" AutoGenerateColumns="False" SkinID="SkinGridView"
                                Width="100%" >
                                <Columns>
                                    <asp:TemplateField HeaderText="Ene">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbEnero" runat="server" Text='<%# Bind("Enero") %>' CausesValidation="False"
                                                OnClick="lbVerDetalleAusenciasJustificadas_Click" CommandArgument="1"></asp:LinkButton>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Feb">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbFebrero" CommandArgument="2" runat="server" Text='<%# Eval("Febrero") %>'
                                                OnClick="lbVerDetalleAusenciasJustificadas_Click" ToolTip="Ver detalle" CausesValidation="False"></asp:LinkButton>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Mar">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbMarzo" CommandArgument="3" runat="server" Text='<%# Eval("Marzo") %>'
                                                OnClick="lbVerDetalleAusenciasJustificadas_Click" ToolTip="Ver detalle" CausesValidation="False"></asp:LinkButton>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Abr">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbAbril" CommandArgument="4" runat="server" Text='<%# Eval("Abril") %>'
                                                OnClick="lbVerDetalleAusenciasJustificadas_Click" ToolTip="Ver detalle" CausesValidation="False"></asp:LinkButton>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="May">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbMayo" CommandArgument="5" runat="server" Text='<%# Eval("Mayo") %>'
                                                OnClick="lbVerDetalleAusenciasJustificadas_Click" ToolTip="Ver detalle" CausesValidation="False"></asp:LinkButton>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Jun">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbJunio" CommandArgument="6" runat="server" Text='<%# Eval("Junio") %>'
                                                OnClick="lbVerDetalleAusenciasJustificadas_Click" ToolTip="Ver detalle" CausesValidation="False"></asp:LinkButton>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Jul">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbJulio" CommandArgument="7" runat="server" Text='<%# Eval("Julio") %>'
                                                OnClick="lbVerDetalleAusenciasJustificadas_Click" ToolTip="Ver detalle" CausesValidation="False"></asp:LinkButton>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Ago">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbAgosto" CommandArgument="8" runat="server" Text='<%# Eval("Agosto") %>'
                                                OnClick="lbVerDetalleAusenciasJustificadas_Click" ToolTip="Ver detalle" CausesValidation="False"></asp:LinkButton>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Sep">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbSeptiembre" CommandArgument="9" runat="server" Text='<%# Eval("Septiembre") %>'
                                                OnClick="lbVerDetalleAusenciasJustificadas_Click" ToolTip="Ver detalle" CausesValidation="False"></asp:LinkButton>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Oct">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbOctubre" CommandArgument="10" runat="server" Text='<%# Eval("Octubre") %>'
                                                OnClick="lbVerDetalleAusenciasJustificadas_Click" ToolTip="Ver detalle" CausesValidation="False"></asp:LinkButton>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Nov">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbNoviembre" CommandArgument="11" runat="server" Text='<%# Eval("Noviembre") %>'
                                                OnClick="lbVerDetalleAusenciasJustificadas_Click" ToolTip="Ver detalle" CausesValidation="False"></asp:LinkButton>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Dic">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbDiciembre" CommandArgument="12" runat="server" Text='<%# Eval("Diciembre") %>'
                                                OnClick="lbVerDetalleAusenciasJustificadas_Click" ToolTip="Ver detalle" CausesValidation="False"></asp:LinkButton>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Total Anual">
                                        <ItemTemplate>
                                            <asp:Label ID="lbAusenciasJustificadasTot" runat="server" Text='<%# Eval("TotalAusenciasJustificadas") %>'
                                                Font-Bold="true"></asp:Label></ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" Width="150px" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    
                                </Columns>
                            </asp:GridView>
                            <asp:Panel ID="pnlAusenciasJustificadasDetalleMes" runat="server" Width="100%" GroupingText="Detalle del mes: Sin Especificar"
                                Visible="False">
                                <asp:GridView ID="gvAusenciasJustificadas" runat="server" AutoGenerateColumns="False" EmptyDataText="No existe información de AusenciasJustificadas en el año seleccionado."
                                    OnSelectedIndexChanged="gvAusenciasJustificadas_SelectedIndexChanged" PageSize="20" SkinID="SkinGridView"
                                    Width="100%" Visible="False">
                                    <EmptyDataTemplate>
                                        <div>
                                            <asp:Label ID="lblMsjSinAusenciasJustificadas" runat="server" Text="No existe información de AusenciasJustificadas en el año/mes seleccionado."></asp:Label>
                                        </div>
                                    </EmptyDataTemplate>
                                    <EmptyDataRowStyle Font-Italic="True" />
                                    <Columns>
                                        <asp:CommandField ButtonType="Image" SelectImageUrl="~/Imagenes/Select.png" ShowSelectButton="True">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:CommandField>
                                        <asp:TemplateField HeaderText="ID">
                                            <ItemTemplate>
                                                <asp:Label ID="lblIdIncidencia" runat="server" Text='<%# Bind("Id") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="SubTipo">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSubTipo" runat="server" Text='<%# Bind("DescSubtipo") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="Folio incidencia">
                                            <ItemTemplate>
                                                <asp:Label ID="lblFolioIncidencia" runat="server" Text='<%# Bind("FolioIncidencia") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Fecha inicio">
                                            <ItemTemplate>
                                                <asp:Label ID="lblFecha" runat="server" Text='<%# Bind("FechaIni", "{0:d}") %>' ForeColor="Blue"></asp:Label></ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Fecha fin">
                                            <ItemTemplate>
                                                <asp:Label ID="lblFechaFin" runat="server" Text='<%# Bind("FechaFin", "{0:d}") %>' ForeColor="Blue"></asp:Label></ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Fecha de justificación">
                                            <ItemTemplate>
                                                <asp:Label ID="lblFechaJust" runat="server" Text='<%# Bind("FechaJust", "{0:d}") %>' ForeColor="Red"></asp:Label></ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Observaciones">
                                            <ItemTemplate>
                                                <asp:Label ID="lblFolioIncidencia2" runat="server" Text='<%# Bind("FolioIncidencia2") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="IDS afectados">
                                            <ItemTemplate>
                                                <asp:Label ID="lblIdsAfectados" runat="server" Text='<%# Bind("idsAfectados") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Día(s)">
                                            <ItemTemplate>
                                                <asp:Label ID="lblNumDias" runat="server" Text='<%# Bind("NumDias") %>' ForeColor="Blue"></asp:Label></ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="FechaCaptura" DataFormatString="{0:d}" HeaderText="Fecha Captura/Modificación"
                                            ReadOnly="True">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="Capturado/Modificado por">
                                            <ItemTemplate>
                                                <asp:Label ID="lblIdUsuario" runat="server" Text='<%# Bind("IdUsuario") %>' Visible="False"></asp:Label><asp:Label
                                                    ID="lblLogin" runat="server"></asp:Label></ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="" Visible="false">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ibEditar" runat="server" CausesValidation="False" ImageUrl="~/Imagenes/Modificar.png"
                                                    ToolTip="Modificar" OnClick="ibEditar_Click" /></ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ibEliminar" runat="server" CausesValidation="False"
                                                    ImageUrl="~/Imagenes/Eliminar.png" ToolTip="Eliminar" OnClick="ibEliminar_Click" />
                                                <ajaxToolkit:ConfirmButtonExtender ID="CBEEliminar" runat="server" ConfirmText="La operación solicitada eliminará el registro de la Base de datos, ¿Continuar?"
                                                    TargetControlID="ibEliminar">
                                                </ajaxToolkit:ConfirmButtonExtender>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ibJustifPorJefe" runat="server" CausesValidation="False" 
                                                    ImageUrl="~/Imagenes/JustifPorJefe.png" 
                                                    ToolTip="Justificar retardo (Justificación por Jefe)" 
                                                    onclick="ibJustifPorJefe_Click" />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </asp:Panel>
                        </asp:Panel>
                        <asp:Panel ID="TitlePanelAusenciasNoJustificadas" runat="server" Width="100%" BorderWidth="1px"
                            BorderStyle="Solid" BorderColor="White" CssClass="collapsePanelHeader">
                            <asp:Image ID="imgAusenciasNoJustificadas" runat="server" ImageUrl="~/Imagenes/expand_blue.jpg">
                            </asp:Image>
                            &nbsp;Ausencias No Justificadas
                            <asp:Label ID="lblAusenciasNoJustificadas" runat="server">(Mostrar detalles...)</asp:Label>
                        </asp:Panel>
                        <asp:Panel ID="ContentPanelAusenciasNoJustificadas" runat="server" Width="100%" CssClass="collapsePanel">
                            <asp:GridView ID="gvResumenAusenciasNoJustificadas" runat="server" AutoGenerateColumns="False" SkinID="SkinGridView"
                                Width="100%">
                                <Columns>
                                    <asp:TemplateField HeaderText="Ene">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbEnero" runat="server" Text='<%# Bind("Enero") %>' CausesValidation="False"
                                                OnClick="lbVerDetalleAusenciasNoJustificadas_Click" CommandArgument="1"></asp:LinkButton>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Feb">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbFebrero" CommandArgument="2" runat="server" Text='<%# Eval("Febrero") %>'
                                                OnClick="lbVerDetalleAusenciasNoJustificadas_Click" ToolTip="Ver detalle" CausesValidation="False"></asp:LinkButton>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Mar">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbMarzo" CommandArgument="3" runat="server" Text='<%# Eval("Marzo") %>'
                                                OnClick="lbVerDetalleAusenciasNoJustificadas_Click" ToolTip="Ver detalle" CausesValidation="False"></asp:LinkButton>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Abr">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbAbril" CommandArgument="4" runat="server" Text='<%# Eval("Abril") %>'
                                                OnClick="lbVerDetalleAusenciasNoJustificadas_Click" ToolTip="Ver detalle" CausesValidation="False"></asp:LinkButton>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="May">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbMayo" CommandArgument="5" runat="server" Text='<%# Eval("Mayo") %>'
                                                OnClick="lbVerDetalleAusenciasNoJustificadas_Click" ToolTip="Ver detalle" CausesValidation="False"></asp:LinkButton>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Jun">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbJunio" CommandArgument="6" runat="server" Text='<%# Eval("Junio") %>'
                                                OnClick="lbVerDetalleAusenciasNoJustificadas_Click" ToolTip="Ver detalle" CausesValidation="False"></asp:LinkButton>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Jul">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbJulio" CommandArgument="7" runat="server" Text='<%# Eval("Julio") %>'
                                                OnClick="lbVerDetalleAusenciasNoJustificadas_Click" ToolTip="Ver detalle" CausesValidation="False"></asp:LinkButton>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Ago">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbAgosto" CommandArgument="8" runat="server" Text='<%# Eval("Agosto") %>'
                                                OnClick="lbVerDetalleAusenciasNoJustificadas_Click" ToolTip="Ver detalle" CausesValidation="False"></asp:LinkButton>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Sep">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbSeptiembre" CommandArgument="9" runat="server" Text='<%# Eval("Septiembre") %>'
                                                OnClick="lbVerDetalleAusenciasNoJustificadas_Click" ToolTip="Ver detalle" CausesValidation="False"></asp:LinkButton>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Oct">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbOctubre" CommandArgument="10" runat="server" Text='<%# Eval("Octubre") %>'
                                                OnClick="lbVerDetalleAusenciasNoJustificadas_Click" ToolTip="Ver detalle" CausesValidation="False"></asp:LinkButton>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Nov">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbNoviembre" CommandArgument="11" runat="server" Text='<%# Eval("Noviembre") %>'
                                                OnClick="lbVerDetalleAusenciasNoJustificadas_Click" ToolTip="Ver detalle" CausesValidation="False"></asp:LinkButton>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Dic">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbDiciembre" CommandArgument="12" runat="server" Text='<%# Eval("Diciembre") %>'
                                                OnClick="lbVerDetalleAusenciasNoJustificadas_Click" ToolTip="Ver detalle" CausesValidation="False"></asp:LinkButton>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Ausencias No Justificadas<br/>(Total anual)">
                                        <ItemTemplate>
                                            <asp:Label ID="lbAusenciasNoJustificadasTot" runat="server" Text='<%# Eval("TotalAusenciasNoJustificadas") %>'
                                                Font-Bold="true"></asp:Label></ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" Width="150px" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <asp:Panel ID="pnlAusenciasNoJustificadasDetalleMes" runat="server" Width="100%" GroupingText="Detalle del mes: Sin Especificar"
                                Visible="False">
                                <asp:GridView ID="gvAusenciasNoJustificadas" runat="server" AutoGenerateColumns="False" EmptyDataText="No existe información de Ausencias No Justificadas en el año seleccionado."
                                    OnSelectedIndexChanged="gvAusenciasNoJustificadas_SelectedIndexChanged" PageSize="20" SkinID="SkinGridView"
                                    Width="100%" Visible="False">
                                    <EmptyDataTemplate>
                                        <div>
                                            <asp:Label ID="lblMsjSinAusenciasNoJustificadas" runat="server" Text="No existe información de AusenciasNoJustificadas en el año/mes seleccionado."></asp:Label>
                                        </div>
                                    </EmptyDataTemplate>
                                    <EmptyDataRowStyle Font-Italic="True" />
                                    <Columns>
                                        <asp:CommandField ButtonType="Image" SelectImageUrl="~/Imagenes/Select.png" ShowSelectButton="True">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:CommandField>
                                        <asp:TemplateField HeaderText="ID">
                                            <ItemTemplate>
                                                <asp:Label ID="lblIdIncidencia" runat="server" Text='<%# Bind("Id") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="SubTipo">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSubTipo" runat="server" Text='<%# Bind("DescSubtipo") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Folio incidencia">
                                            <ItemTemplate>
                                                <asp:Label ID="lblFolioIncidencia" runat="server" Text='<%# Bind("FolioIncidencia") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Fecha inicio">
                                            <ItemTemplate>
                                                <asp:Label ID="lblFecha" runat="server" Text='<%# Bind("FechaIni", "{0:d}") %>' ForeColor="Blue"></asp:Label></ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Fecha fin">
                                            <ItemTemplate>
                                                <asp:Label ID="lblFechaFin" runat="server" Text='<%# Bind("FechaFin", "{0:d}") %>' ForeColor="Blue"></asp:Label></ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Día(s)">
                                            <ItemTemplate>
                                                <asp:Label ID="lblNumDias" runat="server" Text='<%# Bind("NumDias") %>' ForeColor="Blue"></asp:Label></ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Fecha de justificación">
                                            <ItemTemplate>
                                                <asp:Label ID="lblFechaJust" runat="server" Text='<%# Bind("FechaJust", "{0:d}") %>' ForeColor="Red"></asp:Label></ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Observaciones">
                                            <ItemTemplate>
                                                <asp:Label ID="lblFolioIncidencia2" runat="server" Text='<%# Bind("FolioIncidencia2") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="IDS afectados">
                                            <ItemTemplate>
                                                <asp:Label ID="lblIdsAfectados" runat="server" Text='<%# Bind("idsAfectados") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="FechaCaptura" DataFormatString="{0:d}" HeaderText="Fecha Captura/Modificación"
                                            ReadOnly="True">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="Capturado/Modificado por">
                                            <ItemTemplate>
                                                <asp:Label ID="lblIdUsuario" runat="server" Text='<%# Bind("IdUsuario") %>' Visible="False"></asp:Label><asp:Label
                                                    ID="lblLogin" runat="server"></asp:Label></ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="" Visible="false">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ibEditar" runat="server" CausesValidation="False" ImageUrl="~/Imagenes/Modificar.png"
                                                    ToolTip="Modificar" OnClick="ibEditar_Click" /></ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ibEliminar" runat="server" CausesValidation="False" 
                                                    ImageUrl="~/Imagenes/Eliminar.png" ToolTip="Eliminar" OnClick="ibEliminar_Click" />
                                                <ajaxToolkit:ConfirmButtonExtender ID="CBEEliminar" runat="server" ConfirmText="La operación solicitada eliminará el registro de la Base de datos, ¿Continuar?"
                                                    TargetControlID="ibEliminar">
                                                </ajaxToolkit:ConfirmButtonExtender>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ibJustifPorJefe" runat="server" CausesValidation="False" 
                                                    ImageUrl="~/Imagenes/JustifPorJefe.png" ToolTip="Justificar falta (Justificación por Jefe)" 
                                                    onclick="ibJustifPorJefe_Click"/>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </asp:Panel>
                        </asp:Panel>
                        <asp:Panel ID="TitlePanelLicMed" runat="server" Width="100%" BorderWidth="1px"
                            BorderStyle="Solid" BorderColor="White" CssClass="collapsePanelHeader">
                            <asp:Image ID="imgLicMed" runat="server" ImageUrl="~/Imagenes/expand_blue.jpg">
                            </asp:Image>
                            &nbsp;Licencias médicas
                            <asp:Label ID="lblLicMedS" runat="server">(Mostrar detalles...)</asp:Label>
                        </asp:Panel>
                        <asp:Panel ID="ContentPanelLicMed" runat="server"  Width="100%" CssClass="collapsePanel" >
                            <asp:GridView ID="gvResumenLicMed" runat="server"  AutoGenerateColumns="False" SkinID="SkinGridView"
                                Width="100%">
                                <Columns>
                                    <asp:TemplateField HeaderText="Ene">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbEnero" runat="server" Text='<%# Bind("Enero") %>' CausesValidation="False"
                                                OnClick="lbVerDetalleLicMed_Click" CommandArgument="1"></asp:LinkButton>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Feb">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbFebrero" CommandArgument="2" runat="server" Text='<%# Eval("Febrero") %>'
                                                OnClick="lbVerDetalleLicMed_Click" ToolTip="Ver detalle" CausesValidation="False"></asp:LinkButton></ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Mar">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbMarzo" CommandArgument="3" runat="server" Text='<%# Eval("Marzo") %>'
                                                OnClick="lbVerDetalleLicMed_Click" ToolTip="Ver detalle" CausesValidation="False"></asp:LinkButton></ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Abr">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbAbril" CommandArgument="4" runat="server" Text='<%# Eval("Abril") %>'
                                                OnClick="lbVerDetalleLicMed_Click" ToolTip="Ver detalle" CausesValidation="False"></asp:LinkButton></ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="May">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbMayo" CommandArgument="5" runat="server" Text='<%# Eval("Mayo") %>'
                                                OnClick="lbVerDetalleLicMed_Click" ToolTip="Ver detalle" CausesValidation="False"></asp:LinkButton></ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Jun">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbJunio" CommandArgument="6" runat="server" Text='<%# Eval("Junio") %>'
                                                OnClick="lbVerDetalleLicMed_Click" ToolTip="Ver detalle" CausesValidation="False"></asp:LinkButton></ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Jul">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbJulio" CommandArgument="7" runat="server" Text='<%# Eval("Julio") %>'
                                                OnClick="lbVerDetalleLicMed_Click" ToolTip="Ver detalle" CausesValidation="False"></asp:LinkButton></ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Ago">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbAgosto" CommandArgument="8" runat="server" Text='<%# Eval("Agosto") %>'
                                                OnClick="lbVerDetalleLicMed_Click" ToolTip="Ver detalle" CausesValidation="False"></asp:LinkButton></ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Sep">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbSeptiembre" CommandArgument="9" runat="server" Text='<%# Eval("Septiembre") %>'
                                                OnClick="lbVerDetalleLicMed_Click" ToolTip="Ver detalle" CausesValidation="False"></asp:LinkButton></ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Oct">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbOctubre" CommandArgument="10" runat="server" Text='<%# Eval("Octubre") %>'
                                                OnClick="lbVerDetalleLicMed_Click" ToolTip="Ver detalle" CausesValidation="False"></asp:LinkButton></ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Nov">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbNoviembre" CommandArgument="11" runat="server" Text='<%# Eval("Noviembre") %>'
                                                OnClick="lbVerDetalleLicMed_Click" ToolTip="Ver detalle" CausesValidation="False"></asp:LinkButton></ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Dic">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbDiciembre" CommandArgument="12" runat="server" Text='<%# Eval("Diciembre") %>'
                                                OnClick="lbVerDetalleLicMed_Click" ToolTip="Ver detalle" CausesValidation="False"></asp:LinkButton></ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Licencias Médicas (Gran total anual)">
                                        <ItemTemplate>
                                            <asp:Label ID="lblLicMedTot" runat="server" Text='<%# Eval("TotalLicMed") %>'
                                                Font-Bold="true"></asp:Label></ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" Width="150px" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                </Columns>

                            </asp:GridView>
                            &nbsp;Licencias médicas resúmen&nbsp;
                            <br />
                            <asp:Button ID="btnRptLicMed" 
                                runat="server" 
                                SkinID="SkinBoton"  
                                Text="Ver reporte" ToolTip="Ver reporte de licencias médicas dado un periodo" CausesValidation="False" />
                            &nbsp;&nbsp;<asp:RadioButton ID="radioPeriodoAnt" runat="server" Checked="True" GroupName="PeriodoLicencias" Text="Periodo anterior" AutoPostBack="True" />
                            <asp:RadioButton ID="radioPeriodoAct" runat="server" GroupName="PeriodoLicencias" Text="Periodo actual" AutoPostBack="True" />
                            <asp:Panel ID="pnlLicMedDetalleMes" runat="server" GroupingText="Detalle del mes: Sin Especificar">
                                <asp:GridView ID="gvLicMed" runat="server" AutoGenerateColumns="False" EmptyDataText="No existe información de licencias médicas en el año seleccionado."
                                    OnSelectedIndexChanged="gvLicMed_SelectedIndexChanged" PageSize="20" SkinID="SkinGridView"
                                    Width="100%" >
                                <EmptyDataTemplate>
                                        <div>
                                            <asp:Label ID="lblMsjSinLicMed" runat="server" Text="No existe información de licencias médicas en el año/mes seleccionado."></asp:Label>
                                        </div>
                                </EmptyDataTemplate>
                                <EmptyDataRowStyle Font-Italic="True" />
                                <Columns>
                                        <asp:CommandField ButtonType="Image" SelectImageUrl="~/Imagenes/Select.png" ShowSelectButton="True">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:CommandField>
                                        <asp:TemplateField HeaderText="ID">
                                            <ItemTemplate>
                                                <asp:Label ID="lblIdIncidencia" runat="server" Text='<%# Bind("Id") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="SubTipo">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSubTipo" runat="server" Text='<%# Bind("DescSubtipo") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Folio incidencia">
                                            <ItemTemplate>
                                                <asp:Label ID="lblFolioIncidencia" runat="server" Text='<%# Bind("FolioIncidencia") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Folio ISSSTE">
                                            <ItemTemplate>
                                                <asp:Label ID="lblFolioISSSTE" runat="server" Text='<%# Bind("FolioISSSTE") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Fecha de inicio de la Licencia">
                                            <ItemTemplate>
                                                <asp:Label ID="lblFecha" runat="server" Text='<%# Bind("FechaIni", "{0:d}") %>'></asp:Label></ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Fecha de justificación" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblFechaJust" runat="server" Text='<%# Bind("FechaFin", "{0:d}") %>'></asp:Label></ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Fecha de término de la Licencia">
                                            <EditItemTemplate>
                                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("FechaFin", "{0:d}") %>'></asp:Label>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblFechaFin" runat="server" Text='<%# Bind("FechaFin", "{0:d}") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Observaciones">
                                            <ItemTemplate>
                                                <asp:Label ID="FolioIncidencia2" runat="server" Text='<%# Bind("FolioIncidencia2") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="IDS afectados">
                                            <ItemTemplate>
                                                <asp:Label ID="lblIdsAfectados" runat="server" Text='<%# Bind("idsAfectados") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Capturado  / Modificado por">
                                            <ItemTemplate>
                                                <asp:Label ID="lblIdUsuario" runat="server" Text='<%# Bind("IdUsuario") %>' Visible="False"></asp:Label><asp:Label
                                                    ID="lblLogin" runat="server"></asp:Label></ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ibEditar" runat="server" CausesValidation="False" ImageUrl="~/Imagenes/Modificar.png"
                                                    ToolTip="Modificar" OnClick="ibEditar_Click" /></ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ibEliminar" runat="server" CausesValidation="False" 
                                                    ImageUrl="~/Imagenes/Eliminar.png" ToolTip="Eliminar" OnClick="ibEliminar_Click" />
                                                <ajaxToolkit:ConfirmButtonExtender ID="CBEEliminar" runat="server" ConfirmText="La operación solicitada eliminará el registro de la Base de datos, ¿Continuar?"
                                                    TargetControlID="ibEliminar">
                                                </ajaxToolkit:ConfirmButtonExtender>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Tipo de Justificación" Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="IdTiposDeIndicenciasSubtipos" runat="server" Text='<%# Bind("IdTiposDeIndicenciasSubtipos") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Fecha de Justificación" Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="FechaJust" runat="server" Text='<%# Bind("FechaJust")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                </Columns>
                                

                                </asp:GridView>
                                
                            </asp:Panel>
                        </asp:Panel>
                        <asp:Panel ID="TitlePanelOtros" runat="server" Width="100%" BorderWidth="1px"
                            BorderStyle="Solid" BorderColor="White" CssClass="collapsePanelHeader">
                            <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/expand_blue.jpg">
                            </asp:Image>
                            &nbsp;Otros
                            <asp:Label ID="lblOtrosS" runat="server">(Mostrar detalles...)</asp:Label>
                        </asp:Panel>
                        <asp:Panel ID="ContentPanelOtros" runat="server" Width="100%" CssClass="collapsePanel">
                            <asp:GridView ID="gvResumenOtros" runat="server" AutoGenerateColumns="False" SkinID="SkinGridView"
                                Width="100%">
                                <Columns>
                                    <asp:TemplateField HeaderText="Enero">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbEnero" runat="server" Text='<%# Bind("Enero") %>' CausesValidation="False"
                                                OnClick="lbVerDetalleOtros_Click" CommandArgument="1"></asp:LinkButton>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Febrero">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbFebrero" CommandArgument="2" runat="server" Text='<%# Eval("Febrero") %>'
                                                OnClick="lbVerDetalleOtros_Click" ToolTip="Ver detalle" CausesValidation="False"></asp:LinkButton></ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Marzo">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbMarzo" CommandArgument="3" runat="server" Text='<%# Eval("Marzo") %>'
                                                OnClick="lbVerDetalleOtros_Click" ToolTip="Ver detalle" CausesValidation="False"></asp:LinkButton></ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Abril">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbAbril" CommandArgument="4" runat="server" Text='<%# Eval("Abril") %>'
                                                OnClick="lbVerDetalleOtros_Click" ToolTip="Ver detalle" CausesValidation="False"></asp:LinkButton></ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Mayo">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbMayo" CommandArgument="5" runat="server" Text='<%# Eval("Mayo") %>'
                                                OnClick="lbVerDetalleOtros_Click" ToolTip="Ver detalle" CausesValidation="False"></asp:LinkButton></ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Junio">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbJunio" CommandArgument="6" runat="server" Text='<%# Eval("Junio") %>'
                                                OnClick="lbVerDetalleOtros_Click" ToolTip="Ver detalle" CausesValidation="False"></asp:LinkButton></ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Julio">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbJulio" CommandArgument="7" runat="server" Text='<%# Eval("Julio") %>'
                                                OnClick="lbVerDetalleOtros_Click" ToolTip="Ver detalle" CausesValidation="False"></asp:LinkButton></ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Agosto">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbAgosto" CommandArgument="8" runat="server" Text='<%# Eval("Agosto") %>'
                                                OnClick="lbVerDetalleOtros_Click" ToolTip="Ver detalle" CausesValidation="False"></asp:LinkButton></ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Septiembre">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbSeptiembre" CommandArgument="9" runat="server" Text='<%# Eval("Septiembre") %>'
                                                OnClick="lbVerDetalleOtros_Click" ToolTip="Ver detalle" CausesValidation="False"></asp:LinkButton></ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Octubre">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbOctubre" CommandArgument="10" runat="server" Text='<%# Eval("Octubre") %>'
                                                OnClick="lbVerDetalleOtros_Click" ToolTip="Ver detalle" CausesValidation="False"></asp:LinkButton></ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Noviembre">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbNoviembre" CommandArgument="11" runat="server" Text='<%# Eval("Noviembre") %>'
                                                OnClick="lbVerDetalleOtros_Click" ToolTip="Ver detalle" CausesValidation="False"></asp:LinkButton></ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Diciembre">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbDiciembre" CommandArgument="12" runat="server" Text='<%# Eval("Diciembre") %>'
                                                OnClick="lbVerDetalleOtros_Click" ToolTip="Ver detalle" CausesValidation="False"></asp:LinkButton></ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Otros en el año">
                                        <ItemTemplate>
                                            <asp:Label ID="lbOtrosTot" runat="server" Text='<%# Eval("TotalOtros") %>'
                                                Font-Bold="true"></asp:Label></ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" Width="150px" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <asp:Panel ID="pnlOtrosDetalleMes" runat="server" Width="100%" GroupingText="Detalle del mes: Sin Especificar"
                                Visible="False">
                                <asp:GridView ID="gvOtros" runat="server" AutoGenerateColumns="False" EmptyDataText="No existe información de omisiones de checado (Entrada) en el año seleccionado."
                                    OnSelectedIndexChanged="gvOtros_SelectedIndexChanged" PageSize="20" SkinID="SkinGridView"
                                    Width="100%" Visible="False">
                                    <EmptyDataTemplate>
                                        <div>
                                            <asp:Label ID="lblMsjSinOtros" runat="server" Text="No existe información de omisiones de checado (Entrada) en el año/mes seleccionado."></asp:Label>
                                        </div>
                                    </EmptyDataTemplate>
                                    <EmptyDataRowStyle Font-Italic="True" />
                                    <Columns>
                                        <asp:CommandField ButtonType="Image" SelectImageUrl="~/Imagenes/Select.png" ShowSelectButton="True">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:CommandField>
                                        <asp:TemplateField HeaderText="ID">
                                            <ItemTemplate>
                                                <asp:Label ID="lblIdIncidencia" runat="server" Text='<%# Bind("Id") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="SubTipo">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSubTipo" runat="server" Text='<%# Bind("DescSubtipo") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Folio incidencia">
                                            <ItemTemplate>
                                                <asp:Label ID="lblFolioIncidencia" runat="server" Text='<%# Bind("FolioIncidencia") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Fecha de incidencia">
                                            <ItemTemplate>
                                                <asp:Label ID="lblFecha" runat="server" Text='<%# Bind("FechaIni", "{0:d}") %>'></asp:Label></ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Observaciones">
                                            <ItemTemplate>
                                                <asp:Label ID="lblFolioIncidencia2" runat="server" Text='<%# Bind("FolioIncidencia2") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="IDS afectados">
                                            <ItemTemplate>
                                                <asp:Label ID="lblIdsAfectados" runat="server" Text='<%# Bind("idsAfectados") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="FechaCaptura" DataFormatString="{0:d}" HeaderText="Fecha Captura/Modificación"
                                            ReadOnly="True">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="Capturado/Modificado por">
                                            <ItemTemplate>
                                                <asp:Label ID="lblIdUsuario" runat="server" Text='<%# Bind("IdUsuario") %>' Visible="False"></asp:Label><asp:Label
                                                    ID="lblLogin" runat="server"></asp:Label></ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ibEditar" runat="server" CausesValidation="False" ImageUrl="~/Imagenes/Modificar.png"
                                                    ToolTip="Modificar" OnClick="ibEditar_Click" /></ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ibEliminar" runat="server" CausesValidation="False" 
                                                    ImageUrl="~/Imagenes/Eliminar.png" ToolTip="Eliminar" OnClick="ibEliminar_Click" />
                                                <ajaxToolkit:ConfirmButtonExtender ID="CBEEliminar" runat="server" ConfirmText="La operación solicitada eliminará el registro de la Base de datos, ¿Continuar?"
                                                    TargetControlID="ibEliminar">
                                                </ajaxToolkit:ConfirmButtonExtender>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ibJustifPorJefe" runat="server" CausesValidation="False" 
                                                    ImageUrl="~/Imagenes/JustifPorJefe.png" ToolTip="Justificar omisión de checada (Entrada) (Justificación por Jefe)" 
                                                    onclick="ibJustifPorJefe_Click"/>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </asp:Panel>
                        </asp:Panel>
                        <asp:Panel ID="TitlePanelPermSindic" runat="server" Width="100%" BorderWidth="1px"
                            BorderStyle="Solid" BorderColor="White" CssClass="collapsePanelHeader" Visible="False">
                            <asp:Image ID="imgPermSindic" runat="server" ImageUrl="~/Imagenes/expand_blue.jpg">
                            </asp:Image>
                            &nbsp;Permanencias sindicales
                            <asp:Label ID="lblPermSindic" runat="server">(Mostrar detalles...)</asp:Label>
                        </asp:Panel>
                        <asp:Panel ID="ContentPanelPermSindic" runat="server" Width="100%" CssClass="collapsePanel">
                            <asp:GridView ID="gvResumenPermSindic" runat="server" AutoGenerateColumns="False" SkinID="SkinGridView"
                                Width="100%">
                                <Columns>
                                    <asp:TemplateField HeaderText="Ene">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbEnero" runat="server" Text='<%# Bind("Enero") %>' CausesValidation="False"
                                                OnClick="lbVerDetallePermSindic_Click" CommandArgument="1"></asp:LinkButton>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Feb">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbFebrero" CommandArgument="2" runat="server" Text='<%# Eval("Febrero") %>'
                                                OnClick="lbVerDetallePermSindic_Click" ToolTip="Ver detalle" CausesValidation="False"></asp:LinkButton></ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Mar">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbMarzo" CommandArgument="3" runat="server" Text='<%# Eval("Marzo") %>'
                                                OnClick="lbVerDetallePermSindic_Click" ToolTip="Ver detalle" CausesValidation="False"></asp:LinkButton></ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Abr">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbAbril" CommandArgument="4" runat="server" Text='<%# Eval("Abril") %>'
                                                OnClick="lbVerDetallePermSindic_Click" ToolTip="Ver detalle" CausesValidation="False"></asp:LinkButton></ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="May">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbMayo" CommandArgument="5" runat="server" Text='<%# Eval("Mayo") %>'
                                                OnClick="lbVerDetallePermSindic_Click" ToolTip="Ver detalle" CausesValidation="False"></asp:LinkButton></ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Jun">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbJunio" CommandArgument="6" runat="server" Text='<%# Eval("Junio") %>'
                                                OnClick="lbVerDetallePermSindic_Click" ToolTip="Ver detalle" CausesValidation="False"></asp:LinkButton></ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Jul">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbJulio" CommandArgument="7" runat="server" Text='<%# Eval("Julio") %>'
                                                OnClick="lbVerDetallePermSindic_Click" ToolTip="Ver detalle" CausesValidation="False"></asp:LinkButton></ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Ago">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbAgosto" CommandArgument="8" runat="server" Text='<%# Eval("Agosto") %>'
                                                OnClick="lbVerDetallePermSindic_Click" ToolTip="Ver detalle" CausesValidation="False"></asp:LinkButton></ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Sep">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbSeptiembre" CommandArgument="9" runat="server" Text='<%# Eval("Septiembre") %>'
                                                OnClick="lbVerDetallePermSindic_Click" ToolTip="Ver detalle" CausesValidation="False"></asp:LinkButton></ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Oct">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbOctubre" CommandArgument="10" runat="server" Text='<%# Eval("Octubre") %>'
                                                OnClick="lbVerDetallePermSindic_Click" ToolTip="Ver detalle" CausesValidation="False"></asp:LinkButton></ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Nov">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbNoviembre" CommandArgument="11" runat="server" Text='<%# Eval("Noviembre") %>'
                                                OnClick="lbVerDetallePermSindic_Click" ToolTip="Ver detalle" CausesValidation="False"></asp:LinkButton></ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Dic">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbDiciembre" CommandArgument="12" runat="server" Text='<%# Eval("Diciembre") %>'
                                                OnClick="lbVerDetallePermSindic_Click" ToolTip="Ver detalle" CausesValidation="False"></asp:LinkButton></ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Permanencias sindicales (Gran total anual)">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPermSindicTot" runat="server" Text='<%# Eval("TotalPermSindic") %>'
                                                Font-Bold="true"></asp:Label></ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" Width="150px" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                                <asp:Panel ID="pnlPermSindicDetalleMes" runat="server" Width="100%" GroupingText="Detalle del mes: Sin Especificar"
                                Visible="False">
                                <asp:GridView ID="gvPermSindic" runat="server" AutoGenerateColumns="False" EmptyDataText="No existe información de permanencias sindicales en el año seleccionado."
                                    OnSelectedIndexChanged="gvPermSindic_SelectedIndexChanged" PageSize="20" SkinID="SkinGridView"
                                    Width="100%" Visible="False">
                                    <EmptyDataTemplate>
                                        <div>
                                            <asp:Label ID="lblMsjSinPermSindic" runat="server" Text="No existe información de permanencias sindicales en el año/mes seleccionado."></asp:Label>
                                        </div>
                                    </EmptyDataTemplate>
                                    <EmptyDataRowStyle Font-Italic="True" />
                                    <Columns>
                                        <asp:CommandField ButtonType="Image" SelectImageUrl="~/Imagenes/Select.png" ShowSelectButton="True">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:CommandField>
                                        <asp:TemplateField HeaderText="ID">
                                            <ItemTemplate>
                                                <asp:Label ID="lblIdIncidencia" runat="server" Text='<%# Bind("Id") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Folio incidencia">
                                            <ItemTemplate>
                                                <asp:Label ID="lblFolioIncidencia" runat="server" Text='<%# Bind("FolioIncidencia") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Fecha de la permanencia sindical">
                                            <ItemTemplate>
                                                <asp:Label ID="lblFecha" runat="server" Text='<%# Bind("FechaIni", "{0:d}") %>'></asp:Label></ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Fecha de justificación" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblFechaJust" runat="server" Text='<%# Bind("FechaJust", "{0:d}") %>'></asp:Label></ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="FechaCaptura" DataFormatString="{0:d}" HeaderText="Fecha Captura/Modificación"
                                            ReadOnly="True">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="Capturado/Modificado por">
                                            <ItemTemplate>
                                                <asp:Label ID="lblIdUsuario" runat="server" Text='<%# Bind("IdUsuario") %>' Visible="False"></asp:Label><asp:Label
                                                    ID="lblLogin" runat="server"></asp:Label></ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ibEditar" runat="server" CausesValidation="False" ImageUrl="~/Imagenes/Modificar.png"
                                                    ToolTip="Modificar" OnClick="ibEditar_Click" /></ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ibEliminar" runat="server" CausesValidation="False" 
                                                    ImageUrl="~/Imagenes/Eliminar.png" ToolTip="Eliminar" OnClick="ibEliminar_Click" />
                                                <ajaxToolkit:ConfirmButtonExtender ID="CBEEliminar" runat="server" ConfirmText="La operación solicitada eliminará el registro de la Base de datos, ¿Continuar?"
                                                    TargetControlID="ibEliminar">
                                                </ajaxToolkit:ConfirmButtonExtender>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="" Visible="false">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ibJustifPorJefe" runat="server" CausesValidation="False" 
                                                    ImageUrl="~/Imagenes/JustifPorJefe.png" ToolTip="Justificar permanencia sindical (Justificación por Jefe)" 
                                                    onclick="ibJustifPorJefe_Click"/>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </asp:Panel>
                        </asp:Panel>
                        <asp:Panel ID="TitlePanelPerm2Hrs" runat="server" Width="100%" BorderWidth="1px"
                            BorderStyle="Solid" BorderColor="White" CssClass="collapsePanelHeader" Visible="False">
                            <asp:Image ID="imgPerm2Hrs" runat="server" ImageUrl="~/Imagenes/expand_blue.jpg">
                            </asp:Image>
                            &nbsp;Permisos de 2 horas
                            <asp:Label ID="lblPerm2Hrs" runat="server">(Mostrar detalles...)</asp:Label>
                        </asp:Panel>
                        <asp:Panel ID="ContentPanelPerm2Hrs" runat="server" Width="100%" CssClass="collapsePanel">
                            <asp:GridView ID="gvResumenPerm2Hrs" runat="server" AutoGenerateColumns="False" SkinID="SkinGridView"
                                Width="100%">
                                <Columns>
                                    <asp:TemplateField HeaderText="Ene">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbEnero" runat="server" Text='<%# Bind("Enero") %>' CausesValidation="False"
                                                OnClick="lbVerDetallePerm2Hrs_Click" CommandArgument="1"></asp:LinkButton>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Feb">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbFebrero" CommandArgument="2" runat="server" Text='<%# Eval("Febrero") %>'
                                                OnClick="lbVerDetallePerm2Hrs_Click" ToolTip="Ver detalle" CausesValidation="False"></asp:LinkButton></ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Mar">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbMarzo" CommandArgument="3" runat="server" Text='<%# Eval("Marzo") %>'
                                                OnClick="lbVerDetallePerm2Hrs_Click" ToolTip="Ver detalle" CausesValidation="False"></asp:LinkButton></ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Abr">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbAbril" CommandArgument="4" runat="server" Text='<%# Eval("Abril") %>'
                                                OnClick="lbVerDetallePerm2Hrs_Click" ToolTip="Ver detalle" CausesValidation="False"></asp:LinkButton></ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="May">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbMayo" CommandArgument="5" runat="server" Text='<%# Eval("Mayo") %>'
                                                OnClick="lbVerDetallePerm2Hrs_Click" ToolTip="Ver detalle" CausesValidation="False"></asp:LinkButton></ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Jun">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbJunio" CommandArgument="6" runat="server" Text='<%# Eval("Junio") %>'
                                                OnClick="lbVerDetallePerm2Hrs_Click" ToolTip="Ver detalle" CausesValidation="False"></asp:LinkButton></ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Jul">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbJulio" CommandArgument="7" runat="server" Text='<%# Eval("Julio") %>'
                                                OnClick="lbVerDetallePerm2Hrs_Click" ToolTip="Ver detalle" CausesValidation="False"></asp:LinkButton></ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Ago">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbAgosto" CommandArgument="8" runat="server" Text='<%# Eval("Agosto") %>'
                                                OnClick="lbVerDetallePerm2Hrs_Click" ToolTip="Ver detalle" CausesValidation="False"></asp:LinkButton></ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Sep">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbSeptiembre" CommandArgument="9" runat="server" Text='<%# Eval("Septiembre") %>'
                                                OnClick="lbVerDetallePerm2Hrs_Click" ToolTip="Ver detalle" CausesValidation="False"></asp:LinkButton></ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Oct">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbOctubre" CommandArgument="10" runat="server" Text='<%# Eval("Octubre") %>'
                                                OnClick="lbVerDetallePerm2Hrs_Click" ToolTip="Ver detalle" CausesValidation="False"></asp:LinkButton></ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Nov">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbNoviembre" CommandArgument="11" runat="server" Text='<%# Eval("Noviembre") %>'
                                                OnClick="lbVerDetallePerm2Hrs_Click" ToolTip="Ver detalle" CausesValidation="False"></asp:LinkButton></ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Dic">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbDiciembre" CommandArgument="12" runat="server" Text='<%# Eval("Diciembre") %>'
                                                OnClick="lbVerDetallePerm2Hrs_Click" ToolTip="Ver detalle" CausesValidation="False"></asp:LinkButton></ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Permisos de 2 horas (Gran total anual)">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPerm2HrsTot" runat="server" Text='<%# Eval("TotalPerm2Hrs") %>'
                                                Font-Bold="true"></asp:Label></ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" Width="150px" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <asp:Panel ID="pnlPerm2HrsDetalleMes" runat="server" Width="100%" GroupingText="Detalle del mes: Sin Especificar"
                                Visible="False">
                                <asp:GridView ID="gvPerm2Hrs" runat="server" AutoGenerateColumns="False" EmptyDataText="No existe información de permisos de 2 horas en el año seleccionado."
                                    OnSelectedIndexChanged="gvPerm2Hrs_SelectedIndexChanged" PageSize="20" SkinID="SkinGridView"
                                    Width="100%" Visible="False">
                                    <EmptyDataTemplate>
                                        <div>
                                            <asp:Label ID="lblMsjSinPerm2Hrs" runat="server" Text="No existe información de permisos de 2 horas en el año/mes seleccionado."></asp:Label>
                                        </div>
                                    </EmptyDataTemplate>
                                    <EmptyDataRowStyle Font-Italic="True" />
                                    <Columns>
                                        <asp:CommandField ButtonType="Image" SelectImageUrl="~/Imagenes/Select.png" ShowSelectButton="True">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:CommandField>
                                        <asp:TemplateField HeaderText="ID">
                                            <ItemTemplate>
                                                <asp:Label ID="lblIdIncidencia" runat="server" Text='<%# Bind("Id") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Folio incidencia">
                                            <ItemTemplate>
                                                <asp:Label ID="lblFolioIncidencia" runat="server" Text='<%# Bind("FolioIncidencia") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Fecha del permiso de 2 horas">
                                            <ItemTemplate>
                                                <asp:Label ID="lblFecha" runat="server" Text='<%# Bind("FechaIni", "{0:d}") %>'></asp:Label></ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Fecha de justificación" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblFechaJust" runat="server" Text='<%# Bind("FechaJust", "{0:d}") %>'></asp:Label></ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="FechaCaptura" DataFormatString="{0:d}" HeaderText="Fecha Captura/Modificación"
                                            ReadOnly="True">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="Capturado/Modificado por">
                                            <ItemTemplate>
                                                <asp:Label ID="lblIdUsuario" runat="server" Text='<%# Bind("IdUsuario") %>' Visible="False"></asp:Label><asp:Label
                                                    ID="lblLogin" runat="server"></asp:Label></ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ibEditar" runat="server" CausesValidation="False" ImageUrl="~/Imagenes/Modificar.png"
                                                    ToolTip="Modificar" OnClick="ibEditar_Click" /></ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ibEliminar" runat="server" CausesValidation="False" 
                                                    ImageUrl="~/Imagenes/Eliminar.png" ToolTip="Eliminar" OnClick="ibEliminar_Click" />
                                                <ajaxToolkit:ConfirmButtonExtender ID="CBEEliminar" runat="server" ConfirmText="La operación solicitada eliminará el registro de la Base de datos, ¿Continuar?"
                                                    TargetControlID="ibEliminar">
                                                </ajaxToolkit:ConfirmButtonExtender>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="" Visible="false">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ibJustifPorJefe" runat="server" CausesValidation="False" 
                                                    ImageUrl="~/Imagenes/JustifPorJefe.png" ToolTip="Justificar permiso de 2 horas (Justificación por Jefe)" 
                                                    onclick="ibJustifPorJefe_Click"/>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </asp:Panel>
                        </asp:Panel>
                    </asp:Panel>
                </asp:View>
                <asp:View ID="viewABCIncidencias" runat="server">
                    <asp:Panel runat="server" ID="pnlABCIncidencias" GroupingText="Captura de incidencias"
                        HorizontalAlign="Left">
                        <div class="accountInfo">
                            <fieldset id="fsCaptura">
                                <!--<legend>
                                    <asp:Label ID="lblEmpInf2" runat="server" Font-Strikeout="False" Font-Underline="True"></asp:Label>
                                </legend>-->
                                <div class="panelIzquierda">
                                    <p class="pTextBox">
                                        <asp:TextBox ID="txtId" Enabled="false" runat="server" CssClass="textEntry" Visible="false"></asp:TextBox>
                                    </p>
                                    <p class="pLabel">
                                        <asp:Label ID="lblNomCortoInci" runat="server" Enabled="False" CssClass="pLabel"
                                            Text="Nombre corto de la incidencia:">
                                        </asp:Label>
                                    </p>
                                    
                                    <p class="pTextBox">
                                        <asp:TextBox ID="txtbxNomCortoIncidencia" Enabled="false" runat="server" CssClass="textEntry"></asp:TextBox>
                                    </p>

                                    <p class="pLabel">
                                        <asp:Label ID="lblFolioIncidencia" runat="server" Enabled="False" CssClass="pLabel"
                                            Text="Folio de la incidencia:">
                                        </asp:Label>
                                    </p>
                                    
                                    <p class="pTextBox">
                                        <asp:TextBox ID="txtbxFolioIncidencia" Enabled="false" runat="server" CssClass="textEntry"></asp:TextBox>
                                    </p>
                                    <p class="pLabel">
                                                        <asp:Label ID="lblSubtipo" runat="server" CssClass="pLabel" Enabled="False" Text="Concepto de justificación:">
                                            </asp:Label>
                                                    </p>
                                    <p class="pTextBox">
                                                        <asp:DropDownList ID="ddlSubtipo" runat="server" CssClass="textEntry" AutoPostBack="True">
                                                        </asp:DropDownList>
                                           <p class="pLabel">
                                               <asp:Label ID="lblMensajePrevio" runat="server" Visible="False" CssClass="pLabel"
                                                    Text="" ForeColor="Red">
                                                </asp:Label>  
                                            </p>
                                                        <asp:RequiredFieldValidator ID="ddlSubtipo_RFV" runat="server" ControlToValidate="ddlSubtipo" Display="Dynamic" ErrorMessage="*" InitialValue="0" ToolTip="Seleccionar el tipo de justificación es obligatorio." ValidationGroup="NuevoDia"></asp:RequiredFieldValidator>
                                                        <p>
                                                        </p>
                                                        <p class="pLabel">
                                                            <asp:Label ID="lblFolioISSSTE" runat="server" CssClass="pLabel" Enabled="False" Text="Folio del ISSSTE:">
                                        </asp:Label>
                                                        </p>
                                                        <p class="pTextBox">
                                                            <asp:TextBox ID="txtbxFolioISSSTE" runat="server" CssClass="textEntry" Enabled="false" MaxLength="15"></asp:TextBox>
                                                        </p>
                                                        <p class="pLabel">
                                                            <asp:Label ID="lblFechaIni" runat="server" CssClass="pLabel" Enabled="False" Text="Fecha inicial de la incidencia:">
                                        </asp:Label>
                                                        </p>
                                                        <p class="pTextBox">
                                                            <asp:TextBox ID="txtbxFechaIni" runat="server" AutoPostBack="True" CssClass="textEntry" MaxLength="10" ValidationGroup="NuevoDia"></asp:TextBox>
                                                            <asp:ImageButton ID="ibFechaIni" runat="server" CssClass="textEntry2" ImageUrl="~/Imagenes/ico_calendar.png" />
                                                            <asp:RequiredFieldValidator ID="txtbxFechaIni_RFV" runat="server" ControlToValidate="txtbxFechaIni" Display="Dynamic" ErrorMessage="La fecha inicial de la incidencia es requerida." ToolTip="La fecha inicial de la incidencia es requerida." ValidationGroup="NuevoDia">*</asp:RequiredFieldValidator>
                                                            <asp:CompareValidator ID="txtbxFechaIni_CV" runat="server" ControlToValidate="txtbxFechaIni" Display="Dynamic" ErrorMessage="La fecha inicial de la incidencia es incorrecta." Operator="DataTypeCheck" ToolTip="La fecha inicial de la incidencia es incorrecta." Type="Date" ValidationGroup="NuevoDia">*</asp:CompareValidator>
                                                        </p>
                                                        <p class="pLabel">
                                                            &nbsp;<asp:Panel ID="pnlFechIni" runat="server" Visible="false">
                                                                <uc2:wucCalendario2 ID="wucCalendarFechIni" runat="server" />
                                                            </asp:Panel>
                                                            <p>
                                                            </p>
                                                            <p class="pLabel">
                                                                <asp:Label ID="lblFechaFin" runat="server" CssClass="pLabel" Enabled="False" Text="Fecha final de la incidencia:">
                                            </asp:Label>
                                                            </p>
                                                            <p class="pTextBox">
                                                                <asp:TextBox ID="txtbxFechaFin" runat="server" CssClass="textEntry" MaxLength="10" ValidationGroup="NuevoDia"></asp:TextBox>
                                                                <asp:ImageButton ID="ibFechaFin" runat="server" CssClass="textEntry2" ImageUrl="~/Imagenes/ico_calendar.png" />
                                                                <asp:RequiredFieldValidator ID="txtbxFechaFin_RFV" runat="server" ControlToValidate="txtbxFechaFin" Display="Dynamic" ErrorMessage="La fecha final de la incidencia es requerida." ToolTip="La fecha final de la incidencia es requerida." ValidationGroup="NuevoDia">*</asp:RequiredFieldValidator>
                                                                <asp:CompareValidator ID="txtbxFechaFin_CV" runat="server" ControlToValidate="txtbxFechaFin" Display="Dynamic" ErrorMessage="La fecha final de la incidencia es incorrecta." Operator="DataTypeCheck" ToolTip="La fecha final de la incidencia es incorrecta." Type="Date" ValidationGroup="NuevoDia">*</asp:CompareValidator>
                                                                <asp:CompareValidator ID="txtbxFechaFin_CV2" runat="server" ControlToCompare="txtbxFechaIni" ControlToValidate="txtbxFechaFin" Display="Dynamic" ErrorMessage="La fecha final de la incidencia debe ser mayor o igual que la fecha inicial." Operator="GreaterThanEqual" ToolTip="La fecha final de la incidencia debe ser mayor o igual que la fecha inicial." Type="Date" ValidationGroup="NuevoDia">*</asp:CompareValidator>
                                                            </p>
                                                            <p class="pLabel">
                                                                &nbsp;<asp:Panel ID="pnlFechFin" runat="server" Visible="false">
                                                                    <uc2:wucCalendario2 ID="wucCalendarFechFin" runat="server" />
                                                                </asp:Panel>
                                                                <p>
                                                                </p>
                                                                <p class="pLabel">
                                                                    <asp:Label ID="lblFechaJust" runat="server" CssClass="pLabel" Enabled="False" Text="Fecha de la justifiación:"></asp:Label>
                                                                </p>
                                                                <p>
                                                                </p>
                                                                <p class="pTextBox">
                                                                    <asp:TextBox ID="txtbxFechaJust" runat="server" AutoPostBack="True" CssClass="textEntry" MaxLength="10" ValidationGroup="NuevoDia"></asp:TextBox>
                                                                    <asp:ImageButton ID="ibFechaJust" runat="server" CssClass="textEntry2" ImageUrl="~/Imagenes/ico_calendar.png" />
                                                                    <asp:CompareValidator ID="txtbxFechaJust_CV" runat="server" ControlToValidate="txtbxFechaJust" Display="Dynamic" ErrorMessage="La fecha de la justificación es incorrecta." Operator="DataTypeCheck" ToolTip="La fecha de la justificación es incorrecta." Type="Date" ValidationGroup="NuevoDia">*</asp:CompareValidator>
                                                                </p>
                                                                <p class="pLabel">
                                                                    &nbsp;<asp:Panel ID="pnlFechaJust" runat="server" Visible="false">
                                                                        <uc2:wucCalendario2 ID="wucCalendarFechJust" runat="server" />
                                                                    </asp:Panel>
                                                                    <p>
                                                                    </p>
                                                                    <p class="pLabel">
                                                                        <asp:Label ID="lblFolioIncidencia2" runat="server" CssClass="pLabel" Enabled="False" Text="Observaciones:"></asp:Label>
                                                                    </p>
                                                                    <p class="pTextBox">
                                                                        <asp:TextBox ID="txtFolioIncidencia2" runat="server" CssClass="textEntry" Enabled="false" MaxLength="150"></asp:TextBox>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                    <p>
                                                                    </p>
                                                                </p>
                                                            </p>
                                                        </p>
                                     </p>
                                     
                                    </div>
                                
                          </fieldset>
                        </div>
                        <div id="divBotones">
                            <p class="submitButton">
                                <asp:Button ID="btnGuardarIncidencia" runat="server" Text="Guardar" ValidationGroup="NuevoDia" />
                                <asp:Button ID="btnCancelar" runat="server" CausesValidation="False" Text="Cancelar"
                                    ToolTip="Cancelar operación" />
                                <ajaxToolkit:ConfirmButtonExtender ID="CBEbtnGuardar" runat="server" ConfirmText="La operación solicitada guardará las modificaciones realizadas en la Base de datos, ¿Continuar?"
                                    TargetControlID="btnGuardarIncidencia">
                                </ajaxToolkit:ConfirmButtonExtender>
                            </p>
                        </div>
                    </asp:Panel>
                </asp:View>
                <asp:View ID="viewErrores" runat="server">
                    <uc3:wucMuestraErrores ID="wucMuestraErrores" runat="server"  />
                    <div id="divBotonesErrores">
                        <p class="submitButton">
                            <asp:Button ID="btnContinuar" runat="server" Text="Regresar a pantalla de captura" ToolTip=""
                                TabIndex="24" />
                            <asp:Button ID="btnContinuar0" runat="server" TabIndex="24" 
                                Text="Regresar a pantalla de consulta" ToolTip="" />
                        </p>
                    </div>
                </asp:View>                
            </asp:MultiView>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
               