<%@ Page EnableEventValidation="false" Language="VB" MasterPageFile="~/MasterPageSesionIniciada.master"
    AutoEventWireup="false" CodeFile="wfControlIncidenciasPorEmp.aspx.vb" Inherits="wfControlIncidenciasPorEmp"
    Title="COBAEV - Nómina - Empleados, control de incidencias" StylesheetTheme="SkinFile" %>

<%@ Register Src="~/WebControls/wucSearchEmps.ascx" TagName="wucBuscaEmpleados" TagPrefix="uc1" %>
<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress"
    TagPrefix="TP_wucUpdateProgress" %>
<%@ Register Src="../../WebControls/wucCalendario.ascx" TagName="wucCalendario" TagPrefix="uc2" %>
<%@ Register src="../../WebControls/wucMuestraErrores.ascx" tagname="wucMuestraErrores" tagprefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
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
                    <ajaxToolkit:CollapsiblePanelExtender ID="CPERetardos" runat="Server" SuppressPostBack="true"
                        CollapsedImage="~/Imagenes/expand_blue.jpg" ExpandedImage="~/Imagenes/collapse_blue.jpg"
                        ImageControlID="imgRetardos" CollapsedText="(Mostrar detalles...)" ExpandedText="(Ocultar detalles...)"
                        TextLabelID="lblRetardos" Collapsed="True" CollapseControlID="TitlePanelRetardos"
                        ExpandControlID="TitlePanelRetardos" TargetControlID="ContentPanelRetardos">
                    </ajaxToolkit:CollapsiblePanelExtender>
                    <ajaxToolkit:CollapsiblePanelExtender ID="CPEFaltas" runat="Server" SuppressPostBack="true"
                        CollapsedImage="~/Imagenes/expand_blue.jpg" ExpandedImage="~/Imagenes/collapse_blue.jpg"
                        ImageControlID="imgFaltas" CollapsedText="(Mostrar detalles...)" ExpandedText="(Ocultar detalles...)"
                        TextLabelID="lblFaltas" Collapsed="True" CollapseControlID="TitlePanelFaltas"
                        ExpandControlID="TitlePanelFaltas" TargetControlID="ContentPanelFaltas">
                    </ajaxToolkit:CollapsiblePanelExtender>
                    <ajaxToolkit:CollapsiblePanelExtender ID="CPEOmisionesChecadaE" runat="Server" SuppressPostBack="true"
                        CollapsedImage="~/Imagenes/expand_blue.jpg" ExpandedImage="~/Imagenes/collapse_blue.jpg"
                        ImageControlID="imgOmisionesChecadaE" CollapsedText="(Mostrar detalles...)" ExpandedText="(Ocultar detalles...)"
                        TextLabelID="lblOmisionesChecadaE" Collapsed="True" CollapseControlID="TitlePanelOmisionesChecadaE"
                        ExpandControlID="TitlePanelOmisionesChecadaE" TargetControlID="ContentPanelOmisionesChecadaE">
                    </ajaxToolkit:CollapsiblePanelExtender>
                    <ajaxToolkit:CollapsiblePanelExtender ID="CPEOmisionesChecadaS" runat="Server" SuppressPostBack="true"
                        CollapsedImage="~/Imagenes/expand_blue.jpg" ExpandedImage="~/Imagenes/collapse_blue.jpg"
                        ImageControlID="imgOmisionesChecadaS" CollapsedText="(Mostrar detalles...)" ExpandedText="(Ocultar detalles...)"
                        TextLabelID="lblOmisionesChecadaS" Collapsed="True" CollapseControlID="TitlePanelOmisionesChecadaS"
                        ExpandControlID="TitlePanelOmisionesChecadaS" TargetControlID="ContentPanelOmisionesChecadaS">
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
                    <asp:Panel runat="server" ID="pnlControlIncidencias" GroupingText="Incidencias del empleado en el Año: Sin espicificar"
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
                                Visible="False">
                                <asp:GridView ID="gvDiasEco" runat="server" AutoGenerateColumns="False" EmptyDataText="No existe información de permisos económicos en el año seleccionado."
                                    OnSelectedIndexChanged="gvDiasEco_SelectedIndexChanged" PageSize="20" SkinID="SkinGridView"
                                    Width="100%" Visible="False">
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
                                        <asp:TemplateField HeaderText="Folio incidencia">
                                            <ItemTemplate>
                                                <asp:Label ID="lblFolioIncidencia" runat="server" Text='<%# Bind("FolioIncidencia") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Fecha inicial del permiso económico">
                                            <ItemTemplate>
                                                <asp:Label ID="lblFechaIni" runat="server" Text='<%# Bind("FechaIni","{0:d}") %>'></asp:Label></ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Fecha final del permiso económico">
                                            <ItemTemplate>
                                                <asp:Label ID="lblFechaFin" runat="server" Text='<%# Bind("FechaFin","{0:d}") %>'></asp:Label></ItemTemplate>
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
                        <asp:Panel ID="TitlePanelRetardos" runat="server" Width="100%" BorderWidth="1px"
                            BorderStyle="Solid" BorderColor="White" CssClass="collapsePanelHeader">
                            <asp:Image ID="imgRetardos" runat="server" ImageUrl="~/Imagenes/expand_blue.jpg">
                            </asp:Image>
                            &nbsp;Retardos
                            <asp:Label ID="lblRetardos" runat="server">(Mostrar detalles...)</asp:Label>
                        </asp:Panel>
                        <asp:Panel ID="ContentPanelRetardos" runat="server" Width="100%" CssClass="collapsePanel">
                            <asp:GridView ID="gvResumenRetardos" runat="server" AutoGenerateColumns="False" SkinID="SkinGridView"
                                Width="100%" >
                                <Columns>
                                    <asp:TemplateField HeaderText="Ene">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbEnero" runat="server" Text='<%# Bind("Enero") %>' CausesValidation="False"
                                                OnClick="lbVerDetalleRetardos_Click" CommandArgument="1"></asp:LinkButton>
                                            <asp:Label ID="lblEneroJust" runat="server" Text='<%# Bind("EneroJust") %>' ToolTip='<%# Bind("EneroJustToolTip") %>' ForeColor="Red">
                                            </asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Feb">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbFebrero" CommandArgument="2" runat="server" Text='<%# Eval("Febrero") %>'
                                                OnClick="lbVerDetalleRetardos_Click" ToolTip="Ver detalle" CausesValidation="False"></asp:LinkButton>
                                            <asp:Label ID="lblFebreroJust" runat="server" Text='<%# Bind("FebreroJust") %>' ToolTip='<%# Bind("FebreroJustToolTip") %>' ForeColor="Red">
                                            </asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Mar">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbMarzo" CommandArgument="3" runat="server" Text='<%# Eval("Marzo") %>'
                                                OnClick="lbVerDetalleRetardos_Click" ToolTip="Ver detalle" CausesValidation="False"></asp:LinkButton>
                                            <asp:Label ID="lblMarzoJust" runat="server" Text='<%# Bind("MarzoJust") %>' ToolTip='<%# Bind("MarzoJustToolTip") %>' ForeColor="Red">
                                            </asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Abr">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbAbril" CommandArgument="4" runat="server" Text='<%# Eval("Abril") %>'
                                                OnClick="lbVerDetalleRetardos_Click" ToolTip="Ver detalle" CausesValidation="False"></asp:LinkButton>
                                            <asp:Label ID="lblAbrilJust" runat="server" Text='<%# Bind("AbrilJust") %>' ToolTip='<%# Bind("AbrilJustToolTip") %>' ForeColor="Red">
                                            </asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="May">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbMayo" CommandArgument="5" runat="server" Text='<%# Eval("Mayo") %>'
                                                OnClick="lbVerDetalleRetardos_Click" ToolTip="Ver detalle" CausesValidation="False"></asp:LinkButton>
                                            <asp:Label ID="lblMayoJust" runat="server" Text='<%# Bind("MayoJust") %>' ToolTip='<%# Bind("MayoJustToolTip") %>' ForeColor="Red">
                                            </asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Jun">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbJunio" CommandArgument="6" runat="server" Text='<%# Eval("Junio") %>'
                                                OnClick="lbVerDetalleRetardos_Click" ToolTip="Ver detalle" CausesValidation="False"></asp:LinkButton>
                                            <asp:Label ID="lblJunioJust" runat="server" Text='<%# Bind("JunioJust") %>'  ToolTip='<%# Bind("JunioJustToolTip") %>' ForeColor="Red">
                                            </asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Jul">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbJulio" CommandArgument="7" runat="server" Text='<%# Eval("Julio") %>'
                                                OnClick="lbVerDetalleRetardos_Click" ToolTip="Ver detalle" CausesValidation="False"></asp:LinkButton>
                                            <asp:Label ID="lblJulioJust" runat="server" Text='<%# Bind("JulioJust") %>'  ToolTip='<%# Bind("JulioJustToolTip") %>' ForeColor="Red">
                                            </asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Ago">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbAgosto" CommandArgument="8" runat="server" Text='<%# Eval("Agosto") %>'
                                                OnClick="lbVerDetalleRetardos_Click" ToolTip="Ver detalle" CausesValidation="False"></asp:LinkButton>
                                            <asp:Label ID="lblAgostoJust" runat="server" Text='<%# Bind("AgostoJust") %>' ToolTip='<%# Bind("AgostoJustToolTip") %>' ForeColor="Red">
                                            </asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Sep">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbSeptiembre" CommandArgument="9" runat="server" Text='<%# Eval("Septiembre") %>'
                                                OnClick="lbVerDetalleRetardos_Click" ToolTip="Ver detalle" CausesValidation="False"></asp:LinkButton>
                                            <asp:Label ID="lblSeptiembreJust" runat="server" Text='<%# Bind("SeptiembreJust") %>'  ToolTip='<%# Bind("SeptiembreJustToolTip") %>' ForeColor="Red">
                                            </asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Oct">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbOctubre" CommandArgument="10" runat="server" Text='<%# Eval("Octubre") %>'
                                                OnClick="lbVerDetalleRetardos_Click" ToolTip="Ver detalle" CausesValidation="False"></asp:LinkButton>
                                            <asp:Label ID="lblOctubreJust" runat="server" Text='<%# Bind("OctubreJust") %>' ToolTip='<%# Bind("OctubreJustToolTip") %>' ForeColor="Red">
                                            </asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Nov">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbNoviembre" CommandArgument="11" runat="server" Text='<%# Eval("Noviembre") %>'
                                                OnClick="lbVerDetalleRetardos_Click" ToolTip="Ver detalle" CausesValidation="False"></asp:LinkButton>
                                            <asp:Label ID="lblNoviembreJust" runat="server" Text='<%# Bind("NoviembreJust") %>' ToolTip='<%# Bind("NoviembreJustToolTip") %>' ForeColor="Red">
                                            </asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Dic">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbDiciembre" CommandArgument="12" runat="server" Text='<%# Eval("Diciembre") %>'
                                                OnClick="lbVerDetalleRetardos_Click" ToolTip="Ver detalle" CausesValidation="False"></asp:LinkButton>
                                            <asp:Label ID="lblDiciembreJust" runat="server" Text='<%# Bind("DiciembreJust") %>' ToolTip='<%# Bind("DiciembreJustToolTip") %>' ForeColor="Red">
                                            </asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Retardos<br />(Total anual)">
                                        <ItemTemplate>
                                            <asp:Label ID="lbRetardosTot" runat="server" Text='<%# Eval("TotalRetardos") %>'
                                                Font-Bold="true"></asp:Label></ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" Width="150px" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Retardos justificados<br />(Total anual)">
                                        <ItemTemplate>
                                            <asp:Label ID="lbRetardosTotJust" runat="server" Text='<%# Eval("TotalRetardosJust") %>'
                                                Font-Bold="true"></asp:Label></ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" Width="150px" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Retardos<br />(Gran total anual)">
                                        <ItemTemplate>
                                            <asp:Label ID="lbGranTotalRetardos" runat="server" Text='<%# Eval("GranTotalRetardos") %>'
                                                Font-Bold="true"></asp:Label></ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" Width="150px" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <asp:Panel ID="pnlRetardosDetalleMes" runat="server" Width="100%" GroupingText="Detalle del mes: Sin Especificar"
                                Visible="False">
                                <asp:GridView ID="gvRetardos" runat="server" AutoGenerateColumns="False" EmptyDataText="No existe información de retardos en el año seleccionado."
                                    OnSelectedIndexChanged="gvRetardos_SelectedIndexChanged" PageSize="20" SkinID="SkinGridView"
                                    Width="100%" Visible="False">
                                    <EmptyDataTemplate>
                                        <div>
                                            <asp:Label ID="lblMsjSinRetardos" runat="server" Text="No existe información de retardos en el año/mes seleccionado."></asp:Label>
                                        </div>
                                    </EmptyDataTemplate>
                                    <EmptyDataRowStyle Font-Italic="True" />
                                    <Columns>
                                        <asp:CommandField ButtonType="Image" SelectImageUrl="~/Imagenes/Select.png" ShowSelectButton="True">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:CommandField>
                                        <asp:TemplateField HeaderText="Folio incidencia">
                                            <ItemTemplate>
                                                <asp:Label ID="lblFolioIncidencia" runat="server" Text='<%# Bind("FolioIncidencia") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Fecha del retardo">
                                            <ItemTemplate>
                                                <asp:Label ID="lblFecha" runat="server" Text='<%# Bind("FechaIni","{0:d}") %>' ForeColor="Blue"></asp:Label></ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Fecha de justificación">
                                            <ItemTemplate>
                                                <asp:Label ID="lblFechaJust" runat="server" Text='<%# Bind("FechaJust","{0:d}") %>' ForeColor="Red"></asp:Label></ItemTemplate>
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
                        <asp:Panel ID="TitlePanelFaltas" runat="server" Width="100%" BorderWidth="1px"
                            BorderStyle="Solid" BorderColor="White" CssClass="collapsePanelHeader">
                            <asp:Image ID="imgFaltas" runat="server" ImageUrl="~/Imagenes/expand_blue.jpg">
                            </asp:Image>
                            &nbsp;Faltas
                            <asp:Label ID="lblFaltas" runat="server">(Mostrar detalles...)</asp:Label>
                        </asp:Panel>
                        <asp:Panel ID="ContentPanelFaltas" runat="server" Width="100%" CssClass="collapsePanel">
                            <asp:GridView ID="gvResumenFaltas" runat="server" AutoGenerateColumns="False" SkinID="SkinGridView"
                                Width="100%">
                                <Columns>
                                    <asp:TemplateField HeaderText="Ene">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbEnero" runat="server" Text='<%# Bind("Enero") %>' CausesValidation="False"
                                                OnClick="lbVerDetalleFaltas_Click" CommandArgument="1"></asp:LinkButton>
                                            <asp:Label ID="lblEneroJust" runat="server" Text='<%# Bind("EneroJust") %>' ToolTip='<%# Bind("EneroJustToolTip") %>' ForeColor="Red">
                                            </asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Feb">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbFebrero" CommandArgument="2" runat="server" Text='<%# Eval("Febrero") %>'
                                                OnClick="lbVerDetalleFaltas_Click" ToolTip="Ver detalle" CausesValidation="False"></asp:LinkButton>
                                            <asp:Label ID="lblFebreroJust" runat="server" Text='<%# Bind("FebreroJust") %>' ToolTip='<%# Bind("FebreroJustToolTip") %>' ForeColor="Red">
                                            </asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Mar">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbMarzo" CommandArgument="3" runat="server" Text='<%# Eval("Marzo") %>'
                                                OnClick="lbVerDetalleFaltas_Click" ToolTip="Ver detalle" CausesValidation="False"></asp:LinkButton>
                                            <asp:Label ID="lblMarzoJust" runat="server" Text='<%# Bind("MarzoJust") %>' ToolTip='<%# Bind("MarzoJustToolTip") %>' ForeColor="Red">
                                            </asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Abr">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbAbril" CommandArgument="4" runat="server" Text='<%# Eval("Abril") %>'
                                                OnClick="lbVerDetalleFaltas_Click" ToolTip="Ver detalle" CausesValidation="False"></asp:LinkButton>
                                            <asp:Label ID="lblAbrilJust" runat="server" Text='<%# Bind("AbrilJust") %>' ToolTip='<%# Bind("AbrilJustToolTip") %>' ForeColor="Red">
                                            </asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="May">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbMayo" CommandArgument="5" runat="server" Text='<%# Eval("Mayo") %>'
                                                OnClick="lbVerDetalleFaltas_Click" ToolTip="Ver detalle" CausesValidation="False"></asp:LinkButton>
                                            <asp:Label ID="lblMayoJust" runat="server" Text='<%# Bind("MayoJust") %>' ToolTip='<%# Bind("MayoJustToolTip") %>' ForeColor="Red">
                                            </asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Jun">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbJunio" CommandArgument="6" runat="server" Text='<%# Eval("Junio") %>'
                                                OnClick="lbVerDetalleFaltas_Click" ToolTip="Ver detalle" CausesValidation="False"></asp:LinkButton>
                                            <asp:Label ID="lblJunioJust" runat="server" Text='<%# Bind("JunioJust") %>' ToolTip='<%# Bind("JunioJustToolTip") %>' ForeColor="Red">
                                            </asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Jul">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbJulio" CommandArgument="7" runat="server" Text='<%# Eval("Julio") %>'
                                                OnClick="lbVerDetalleFaltas_Click" ToolTip="Ver detalle" CausesValidation="False"></asp:LinkButton>
                                            <asp:Label ID="lblJulioJust" runat="server" Text='<%# Bind("JulioJust") %>' ToolTip='<%# Bind("JulioJustToolTip") %>' ForeColor="Red">
                                            </asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Ago">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbAgosto" CommandArgument="8" runat="server" Text='<%# Eval("Agosto") %>'
                                                OnClick="lbVerDetalleFaltas_Click" ToolTip="Ver detalle" CausesValidation="False"></asp:LinkButton>
                                            <asp:Label ID="lblAgostoJust" runat="server" Text='<%# Bind("AgostoJust") %>' ToolTip='<%# Bind("AgostoJustToolTip") %>' ForeColor="Red">
                                            </asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Sep">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbSeptiembre" CommandArgument="9" runat="server" Text='<%# Eval("Septiembre") %>'
                                                OnClick="lbVerDetalleFaltas_Click" ToolTip="Ver detalle" CausesValidation="False"></asp:LinkButton>
                                            <asp:Label ID="lblSeptiembreJust" runat="server" Text='<%# Bind("SeptiembreJust") %>' ToolTip='<%# Bind("SeptiembreJustToolTip") %>' ForeColor="Red">
                                            </asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Oct">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbOctubre" CommandArgument="10" runat="server" Text='<%# Eval("Octubre") %>'
                                                OnClick="lbVerDetalleFaltas_Click" ToolTip="Ver detalle" CausesValidation="False"></asp:LinkButton>
                                            <asp:Label ID="lblOctubreJust" runat="server" Text='<%# Bind("OctubreJust") %>' ToolTip='<%# Bind("OctubreJustToolTip") %>' ForeColor="Red">
                                            </asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Nov">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbNoviembre" CommandArgument="11" runat="server" Text='<%# Eval("Noviembre") %>'
                                                OnClick="lbVerDetalleFaltas_Click" ToolTip="Ver detalle" CausesValidation="False"></asp:LinkButton>
                                            <asp:Label ID="lblNoviembreJust" runat="server" Text='<%# Bind("NoviembreJust") %>' ToolTip='<%# Bind("NoviembreJustToolTip") %>' ForeColor="Red">
                                            </asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Dic">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbDiciembre" CommandArgument="12" runat="server" Text='<%# Eval("Diciembre") %>'
                                                OnClick="lbVerDetalleFaltas_Click" ToolTip="Ver detalle" CausesValidation="False"></asp:LinkButton>
                                            <asp:Label ID="lblDiciembreJust" runat="server" Text='<%# Bind("DiciembreJust") %>' ToolTip='<%# Bind("DiciembreJustToolTip") %>' ForeColor="Red">
                                            </asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Faltas<br/>(Total anual)">
                                        <ItemTemplate>
                                            <asp:Label ID="lbFaltasTot" runat="server" Text='<%# Eval("TotalFaltas") %>'
                                                Font-Bold="true"></asp:Label></ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" Width="150px" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Faltas justificadas<br />(Total anual)">
                                        <ItemTemplate>
                                            <asp:Label ID="lbFaltasTotJust" runat="server" Text='<%# Eval("TotalFaltasJust") %>'
                                                Font-Bold="true"></asp:Label></ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" Width="150px" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Faltas<br />(Gran total anual)">
                                        <ItemTemplate>
                                            <asp:Label ID="lbGranTotalFaltas" runat="server" Text='<%# Eval("GranTotalFaltas") %>'
                                                Font-Bold="true"></asp:Label></ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" Width="150px" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <asp:Panel ID="pnlFaltasDetalleMes" runat="server" Width="100%" GroupingText="Detalle del mes: Sin Especificar"
                                Visible="False">
                                <asp:GridView ID="gvFaltas" runat="server" AutoGenerateColumns="False" EmptyDataText="No existe información de faltas en el año seleccionado."
                                    OnSelectedIndexChanged="gvFaltas_SelectedIndexChanged" PageSize="20" SkinID="SkinGridView"
                                    Width="100%" Visible="False">
                                    <EmptyDataTemplate>
                                        <div>
                                            <asp:Label ID="lblMsjSinFaltas" runat="server" Text="No existe información de faltas en el año/mes seleccionado."></asp:Label>
                                        </div>
                                    </EmptyDataTemplate>
                                    <EmptyDataRowStyle Font-Italic="True" />
                                    <Columns>
                                        <asp:CommandField ButtonType="Image" SelectImageUrl="~/Imagenes/Select.png" ShowSelectButton="True">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:CommandField>
                                        <asp:TemplateField HeaderText="Folio incidencia">
                                            <ItemTemplate>
                                                <asp:Label ID="lblFolioIncidencia" runat="server" Text='<%# Bind("FolioIncidencia") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Fecha de la falta">
                                            <ItemTemplate>
                                                <asp:Label ID="lblFecha" runat="server" Text='<%# Bind("FechaIni","{0:d}") %>'  ForeColor="Blue"></asp:Label></ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Fecha de justificación">
                                            <ItemTemplate>
                                                <asp:Label ID="lblFechaJust" runat="server" Text='<%# Bind("FechaJust","{0:d}") %>' ForeColor="Red"></asp:Label></ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Tipo de justificación">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDescTipoJustifPorJefe" runat="server" Text='<%# Bind("DescTipoJustifPorJefe") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
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
                        <asp:Panel ID="TitlePanelOmisionesChecadaE" runat="server" Width="100%" BorderWidth="1px"
                            BorderStyle="Solid" BorderColor="White" CssClass="collapsePanelHeader" Visible="false">
                            <asp:Image ID="imgOmisionesChecadaS" runat="server" ImageUrl="~/Imagenes/expand_blue.jpg">
                            </asp:Image>
                            &nbsp;Omisiones de checado (Entrada)
                            <asp:Label ID="lblOmisionesChecadaS" runat="server">(Mostrar detalles...)</asp:Label>
                        </asp:Panel>
                        <asp:Panel ID="ContentPanelOmisionesChecadaE" runat="server" Width="100%" CssClass="collapsePanel" Visible="false">
                            <asp:GridView ID="gvResumenOmisionesChecadaE" runat="server" AutoGenerateColumns="False" SkinID="SkinGridView"
                                Width="100%">
                                <Columns>
                                    <asp:TemplateField HeaderText="Enero">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbEnero" runat="server" Text='<%# Bind("Enero") %>' CausesValidation="False"
                                                OnClick="lbVerDetalleOmisionesChecadaE_Click" CommandArgument="1"></asp:LinkButton>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Febrero">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbFebrero" CommandArgument="2" runat="server" Text='<%# Eval("Febrero") %>'
                                                OnClick="lbVerDetalleOmisionesChecadaE_Click" ToolTip="Ver detalle" CausesValidation="False"></asp:LinkButton></ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Marzo">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbMarzo" CommandArgument="3" runat="server" Text='<%# Eval("Marzo") %>'
                                                OnClick="lbVerDetalleOmisionesChecadaE_Click" ToolTip="Ver detalle" CausesValidation="False"></asp:LinkButton></ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Abril">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbAbril" CommandArgument="4" runat="server" Text='<%# Eval("Abril") %>'
                                                OnClick="lbVerDetalleOmisionesChecadaE_Click" ToolTip="Ver detalle" CausesValidation="False"></asp:LinkButton></ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Mayo">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbMayo" CommandArgument="5" runat="server" Text='<%# Eval("Mayo") %>'
                                                OnClick="lbVerDetalleOmisionesChecadaE_Click" ToolTip="Ver detalle" CausesValidation="False"></asp:LinkButton></ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Junio">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbJunio" CommandArgument="6" runat="server" Text='<%# Eval("Junio") %>'
                                                OnClick="lbVerDetalleOmisionesChecadaE_Click" ToolTip="Ver detalle" CausesValidation="False"></asp:LinkButton></ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Julio">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbJulio" CommandArgument="7" runat="server" Text='<%# Eval("Julio") %>'
                                                OnClick="lbVerDetalleOmisionesChecadaE_Click" ToolTip="Ver detalle" CausesValidation="False"></asp:LinkButton></ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Agosto">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbAgosto" CommandArgument="8" runat="server" Text='<%# Eval("Agosto") %>'
                                                OnClick="lbVerDetalleOmisionesChecadaE_Click" ToolTip="Ver detalle" CausesValidation="False"></asp:LinkButton></ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Septiembre">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbSeptiembre" CommandArgument="9" runat="server" Text='<%# Eval("Septiembre") %>'
                                                OnClick="lbVerDetalleOmisionesChecadaE_Click" ToolTip="Ver detalle" CausesValidation="False"></asp:LinkButton></ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Octubre">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbOctubre" CommandArgument="10" runat="server" Text='<%# Eval("Octubre") %>'
                                                OnClick="lbVerDetalleOmisionesChecadaE_Click" ToolTip="Ver detalle" CausesValidation="False"></asp:LinkButton></ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Noviembre">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbNoviembre" CommandArgument="11" runat="server" Text='<%# Eval("Noviembre") %>'
                                                OnClick="lbVerDetalleOmisionesChecadaE_Click" ToolTip="Ver detalle" CausesValidation="False"></asp:LinkButton></ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Diciembre">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbDiciembre" CommandArgument="12" runat="server" Text='<%# Eval("Diciembre") %>'
                                                OnClick="lbVerDetalleOmisionesChecadaE_Click" ToolTip="Ver detalle" CausesValidation="False"></asp:LinkButton></ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Omisiones de checado (Entrada) en el año">
                                        <ItemTemplate>
                                            <asp:Label ID="lbOmisionesChecadaETot" runat="server" Text='<%# Eval("TotalOmisionesChecadoE") %>'
                                                Font-Bold="true"></asp:Label></ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" Width="150px" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <asp:Panel ID="pnlOmisionesChecadaEDetalleMes" runat="server" Width="100%" GroupingText="Detalle del mes: Sin Especificar"
                                Visible="False">
                                <asp:GridView ID="gvOmisionesChecadaE" runat="server" AutoGenerateColumns="False" EmptyDataText="No existe información de omisiones de checado (Entrada) en el año seleccionado."
                                    OnSelectedIndexChanged="gvOmisionesChecadaE_SelectedIndexChanged" PageSize="20" SkinID="SkinGridView"
                                    Width="100%" Visible="False">
                                    <EmptyDataTemplate>
                                        <div>
                                            <asp:Label ID="lblMsjSinOmisionesChecadaE" runat="server" Text="No existe información de omisiones de checado (Entrada) en el año/mes seleccionado."></asp:Label>
                                        </div>
                                    </EmptyDataTemplate>
                                    <EmptyDataRowStyle Font-Italic="True" />
                                    <Columns>
                                        <asp:CommandField ButtonType="Image" SelectImageUrl="~/Imagenes/Select.png" ShowSelectButton="True">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:CommandField>
                                        <asp:TemplateField HeaderText="Folio incidencia">
                                            <ItemTemplate>
                                                <asp:Label ID="lblFolioIncidencia" runat="server" Text='<%# Bind("FolioIncidencia") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Fecha de la omisión de checado (Entrada)">
                                            <ItemTemplate>
                                                <asp:Label ID="lblFecha" runat="server" Text='<%# Bind("FechaIni","{0:d}") %>'></asp:Label></ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Fecha de justificación">
                                            <ItemTemplate>
                                                <asp:Label ID="lblFechaJust" runat="server" Text='<%# Bind("FechaJust","{0:d}") %>'></asp:Label></ItemTemplate>
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
                        <asp:Panel ID="TitlePanelOmisionesChecadaS" runat="server" Width="100%" BorderWidth="1px"
                            BorderStyle="Solid" BorderColor="White" CssClass="collapsePanelHeader" Visible="false">
                            <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/expand_blue.jpg">
                            </asp:Image>
                            &nbsp;Omisiones de checado (Salida)
                            <asp:Label ID="Label1" runat="server">(Mostrar detalles...)</asp:Label>
                        </asp:Panel>
                        <asp:Panel ID="ContentPanelOmisionesChecadaS" runat="server" Width="100%" CssClass="collapsePanel" Visible="false">
                            <asp:GridView ID="gvResumenOmisionesChecadaS" runat="server" AutoGenerateColumns="False" SkinID="SkinGridView"
                                Width="100%">
                                <Columns>
                                    <asp:TemplateField HeaderText="Enero">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbEnero" runat="server" Text='<%# Bind("Enero") %>' CausesValidation="False"
                                                OnClick="lbVerDetalleOmisionesChecadaS_Click" CommandArgument="1"></asp:LinkButton>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Febrero">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbFebrero" CommandArgument="2" runat="server" Text='<%# Eval("Febrero") %>'
                                                OnClick="lbVerDetalleOmisionesChecadaS_Click" ToolTip="Ver detalle" CausesValidation="False"></asp:LinkButton></ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Marzo">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbMarzo" CommandArgument="3" runat="server" Text='<%# Eval("Marzo") %>'
                                                OnClick="lbVerDetalleOmisionesChecadaS_Click" ToolTip="Ver detalle" CausesValidation="False"></asp:LinkButton></ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Abril">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbAbril" CommandArgument="4" runat="server" Text='<%# Eval("Abril") %>'
                                                OnClick="lbVerDetalleOmisionesChecadaS_Click" ToolTip="Ver detalle" CausesValidation="False"></asp:LinkButton></ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Mayo">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbMayo" CommandArgument="5" runat="server" Text='<%# Eval("Mayo") %>'
                                                OnClick="lbVerDetalleOmisionesChecadaS_Click" ToolTip="Ver detalle" CausesValidation="False"></asp:LinkButton></ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Junio">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbJunio" CommandArgument="6" runat="server" Text='<%# Eval("Junio") %>'
                                                OnClick="lbVerDetalleOmisionesChecadaS_Click" ToolTip="Ver detalle" CausesValidation="False"></asp:LinkButton></ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Julio">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbJulio" CommandArgument="7" runat="server" Text='<%# Eval("Julio") %>'
                                                OnClick="lbVerDetalleOmisionesChecadaS_Click" ToolTip="Ver detalle" CausesValidation="False"></asp:LinkButton></ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Agosto">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbAgosto" CommandArgument="8" runat="server" Text='<%# Eval("Agosto") %>'
                                                OnClick="lbVerDetalleOmisionesChecadaS_Click" ToolTip="Ver detalle" CausesValidation="False"></asp:LinkButton></ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Septiembre">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbSeptiembre" CommandArgument="9" runat="server" Text='<%# Eval("Septiembre") %>'
                                                OnClick="lbVerDetalleOmisionesChecadaS_Click" ToolTip="Ver detalle" CausesValidation="False"></asp:LinkButton></ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Octubre">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbOctubre" CommandArgument="10" runat="server" Text='<%# Eval("Octubre") %>'
                                                OnClick="lbVerDetalleOmisionesChecadaS_Click" ToolTip="Ver detalle" CausesValidation="False"></asp:LinkButton></ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Noviembre">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbNoviembre" CommandArgument="11" runat="server" Text='<%# Eval("Noviembre") %>'
                                                OnClick="lbVerDetalleOmisionesChecadaS_Click" ToolTip="Ver detalle" CausesValidation="False"></asp:LinkButton></ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Diciembre">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbDiciembre" CommandArgument="12" runat="server" Text='<%# Eval("Diciembre") %>'
                                                OnClick="lbVerDetalleOmisionesChecadaS_Click" ToolTip="Ver detalle" CausesValidation="False"></asp:LinkButton></ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Omisiones de checado (Salida) en el año">
                                        <ItemTemplate>
                                            <asp:Label ID="lbOmisionesChecadaSTot" runat="server" Text='<%# Eval("TotalOmisionesChecadoS") %>'
                                                Font-Bold="true"></asp:Label></ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" Width="150px" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <asp:Panel ID="pnlOmisionesChecadaSDetalleMes" runat="server" Width="100%" GroupingText="Detalle del mes: Sin Especificar"
                                Visible="False">
                                <asp:GridView ID="gvOmisionesChecadaS" runat="server" AutoGenerateColumns="False" EmptyDataText="No existe información de omisiones de checado (Salida) en el año seleccionado."
                                    OnSelectedIndexChanged="gvOmisionesChecadaS_SelectedIndexChanged" PageSize="20" SkinID="SkinGridView"
                                    Width="100%" Visible="False">
                                    <EmptyDataTemplate>
                                        <div>
                                            <asp:Label ID="lblMsjSinOmisionesChecadaS" runat="server" Text="No existe información de omisiones de checado (Salida) en el año/mes seleccionado."></asp:Label>
                                        </div>
                                    </EmptyDataTemplate>
                                    <EmptyDataRowStyle Font-Italic="True" />
                                    <Columns>
                                        <asp:CommandField ButtonType="Image" SelectImageUrl="~/Imagenes/Select.png" ShowSelectButton="True">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:CommandField>
                                        <asp:TemplateField HeaderText="Folio incidencia">
                                            <ItemTemplate>
                                                <asp:Label ID="lblFolioIncidencia" runat="server" Text='<%# Bind("FolioIncidencia") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Fecha de la omisión de checado (Salida)">
                                            <ItemTemplate>
                                                <asp:Label ID="lblFecha" runat="server" Text='<%# Bind("FechaIni","{0:d}") %>'></asp:Label></ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Fecha de justificación">
                                            <ItemTemplate>
                                                <asp:Label ID="lblFechaJust" runat="server" Text='<%# Bind("FechaJust","{0:d}") %>'></asp:Label></ItemTemplate>
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
                                                    ImageUrl="~/Imagenes/JustifPorJefe.png" ToolTip="Justificar omisión de checada (Salida) (Justificación por Jefe)" 
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
                            BorderStyle="Solid" BorderColor="White" CssClass="collapsePanelHeader">
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
                                        <asp:TemplateField HeaderText="Folio incidencia">
                                            <ItemTemplate>
                                                <asp:Label ID="lblFolioIncidencia" runat="server" Text='<%# Bind("FolioIncidencia") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Fecha de la permanencia sindical">
                                            <ItemTemplate>
                                                <asp:Label ID="lblFecha" runat="server" Text='<%# Bind("FechaIni","{0:d}") %>'></asp:Label></ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Fecha de justificación" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblFechaJust" runat="server" Text='<%# Bind("FechaJust","{0:d}") %>'></asp:Label></ItemTemplate>
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
                            BorderStyle="Solid" BorderColor="White" CssClass="collapsePanelHeader">
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
                                        <asp:TemplateField HeaderText="Folio incidencia">
                                            <ItemTemplate>
                                                <asp:Label ID="lblFolioIncidencia" runat="server" Text='<%# Bind("FolioIncidencia") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Fecha del permiso de 2 horas">
                                            <ItemTemplate>
                                                <asp:Label ID="lblFecha" runat="server" Text='<%# Bind("FechaIni","{0:d}") %>'></asp:Label></ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Fecha de justificación" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblFechaJust" runat="server" Text='<%# Bind("FechaJust","{0:d}") %>'></asp:Label></ItemTemplate>
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
                                        <asp:Label ID="lblFechaIni" runat="server" Enabled="False" CssClass="pLabel" Text="Fecha inicial de la incidencia:">
                                        </asp:Label>
                                    </p>
                                    <p class="pTextBox">
                                        <asp:TextBox ID="txtbxFechaIni" runat="server" MaxLength="10" CssClass="textEntry"
                                            ValidationGroup="NuevoDia" AutoPostBack="True"></asp:TextBox>
                                        <asp:ImageButton ID="ibFechaIni" runat="server" 
                                            ImageUrl="~/Imagenes/ico_calendar.png" CssClass="textEntry2"/>
                                        <asp:RequiredFieldValidator ID="txtbxFechaIni_RFV" runat="server" ControlToValidate="txtbxFechaIni"
                                            Display="Dynamic" ErrorMessage="La fecha inicial de la incidencia es requerida."
                                            ValidationGroup="NuevoDia" ToolTip="La fecha inicial de la incidencia es requerida.">*</asp:RequiredFieldValidator>
                                        <asp:CompareValidator ID="txtbxFechaIni_CV" runat="server" ControlToValidate="txtbxFechaIni"
                                            Display="Dynamic" ErrorMessage="La fecha inicial de la incidencia es incorrecta."
                                            Operator="DataTypeCheck" Type="Date" ValidationGroup="NuevoDia" ToolTip="La fecha inicial de la incidencia es incorrecta.">*</asp:CompareValidator>

                                            <p class="pLabel">
                                                &nbsp;<asp:Panel ID="pnlFechIni" runat="server" Visible="false">
                                                    <uc2:wucCalendario ID="wucCalendarFechIni" runat="server" />
                                                </asp:Panel>
                                                <p>
                                                </p>
                                                <p class="pLabel">
                                                    <asp:Label ID="lblFechaFin" runat="server" CssClass="pLabel" Enabled="False" 
                                                        Text="Fecha final de la incidencia:">
                                                </asp:Label>
                                                </p>
                                                <p class="pTextBox">
                                                    <asp:TextBox ID="txtbxFechaFin" runat="server" CssClass="textEntry" 
                                                        MaxLength="10" ValidationGroup="NuevoDia"></asp:TextBox>
                                                    <asp:ImageButton ID="ibFechaFin" runat="server" CssClass="textEntry2" 
                                                        ImageUrl="~/Imagenes/ico_calendar.png" />
                                                    <asp:RequiredFieldValidator ID="txtbxFechaFin_RFV" runat="server" 
                                                        ControlToValidate="txtbxFechaFin" Display="Dynamic" 
                                                        ErrorMessage="La fecha final de la incidencia es requerida." 
                                                        ToolTip="La fecha final de la incidencia es requerida." 
                                                        ValidationGroup="NuevoDia">*</asp:RequiredFieldValidator>
                                                    <asp:CompareValidator ID="txtbxFechaFin_CV" runat="server" 
                                                        ControlToValidate="txtbxFechaFin" Display="Dynamic" 
                                                        ErrorMessage="La fecha final de la incidencia es incorrecta." 
                                                        Operator="DataTypeCheck" 
                                                        ToolTip="La fecha final de la incidencia es incorrecta." Type="Date" 
                                                        ValidationGroup="NuevoDia">*</asp:CompareValidator>
                                                    <asp:CompareValidator ID="txtbxFechaFin_CV2" runat="server" 
                                                        ControlToCompare="txtbxFechaIni" ControlToValidate="txtbxFechaFin" 
                                                        Display="Dynamic" 
                                                        ErrorMessage="La fecha final de la incidencia debe ser mayor o igual que la fecha inicial." 
                                                        Operator="GreaterThanEqual" 
                                                        
                                                        ToolTip="La fecha final de la incidencia debe ser mayor o igual que la fecha inicial." Type="Date" 
                                                        ValidationGroup="NuevoDia">*</asp:CompareValidator>
                                                </p>
                                                <p class="pLabel">
                                                    &nbsp;<asp:Panel ID="pnlFechFin" runat="server" Visible="false">
                                                        <uc2:wucCalendario ID="wucCalendarFechFin" runat="server" />
                                                    </asp:Panel>
                                                    <p>
                                                    </p>
                                                    <p class="pLabel">
                                                        <asp:Label ID="lblFechaJust" runat="server" CssClass="pLabel" Enabled="False" 
                                                            Text="Fecha de la justifiación:">
                                                         </asp:Label>
                                                    </p>
                                                    <p class="pTextBox">
                                                        <asp:TextBox ID="txtbxFechaJust" runat="server" AutoPostBack="True" 
                                                            CssClass="textEntry" MaxLength="10" ValidationGroup="NuevoDia"></asp:TextBox>
                                                        <asp:ImageButton ID="ibFechaJust" runat="server" CssClass="textEntry2" 
                                                            ImageUrl="~/Imagenes/ico_calendar.png" />
                                                        <asp:CompareValidator ID="txtbxFechaJust_CV" runat="server" 
                                                            ControlToValidate="txtbxFechaJust" Display="Dynamic" 
                                                            ErrorMessage="La fecha de la justificación es incorrecta." 
                                                            Operator="DataTypeCheck" ToolTip="La fecha de la justificación es incorrecta." 
                                                            Type="Date" ValidationGroup="NuevoDia">*</asp:CompareValidator>
                                                    </p>
                                                    <p class="pLabel">
                                                        &nbsp;<asp:Panel ID="pnlFechaJust" runat="server" Visible="false">
                                                            <uc2:wucCalendario ID="wucCalendarFechJust" runat="server" />
                                                        </asp:Panel>
                                                        <p>
                                                        </p>
                                                        <p class="pLabel">
                                                            <asp:Label ID="lblTipoJustPorJefe" runat="server" CssClass="pLabel" 
                                                                Enabled="False" Text="Tipo de justificación:">
                                                          </asp:Label>
                                                        </p>
                                                        <p class="pTextBox">
                                                            <asp:DropDownList ID="ddlTipoJustPorJefe" runat="server" CssClass="textEntry">
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="ddlTipoJustPorJefe_RFV" runat="server" ControlToValidate="ddlTipoJustPorJefe"
                                                                Display="Dynamic" ErrorMessage="*" ToolTip="Seleccionar el tipo de justificación es obligatorio."
                                                                InitialValue="1" ValidationGroup="NuevoDia">
                                                            </asp:RequiredFieldValidator>
                                                        </p>
                                                        <p>
                                                        </p>
                                                        <p>
                                                        </p>
                                                        <p>
                                                        </p>
                                                        <p>
                                                        </p>
                                                        <p>
                                                        </p>
                                                        <p>
                                                        </p>
                                                        <p>
                                                        </p>
                                                        <p>
                                                        </p>
                                                        <p>
                                                        </p>
                                                        <p>
                                                        </p>
                                                        <p>
                                                        </p>
                                                        <p>
                                                        </p>
                                                        <p>
                                                        </p>
                                                        <p>
                                                        </p>
                                                        <p>
                                                        </p>
                                                        <p>
                                                        </p>
                                                        <p>
                                                        </p>
                                                        <p>
                                                        </p>
                                                        <p>
                                                        </p>
                                                        <p>
                                                        </p>
                                                        <p>
                                                        </p>
                                                        <p>
                                                        </p>
                                                        <p>
                                                        </p>
                                                        <p>
                                                        </p>
                                                        <p>
                                                        </p>
                                                        <p>
                                                        </p>
                                                        <p>
                                                        </p>
                                                        <p>
                                                        </p>
                                                        <p>
                                                        </p>
                                                        <p>
                                                        </p>
                                                        <p>
                                                        </p>
                                                        <p>
                                                        </p>
                                                        <p>
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
               