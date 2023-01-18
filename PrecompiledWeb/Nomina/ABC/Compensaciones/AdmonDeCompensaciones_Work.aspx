<%@ page language="VB" enableeventvalidation="false" masterpagefile="~/MasterPageSesionIniciada.master" autoeventwireup="false" inherits="ABC_Compensaciones_AdmonDeCompensacionesWork, App_Web_ns2nwdvl" title="COBAEV - Nómina - Administración de compensaciones" stylesheettheme="SkinFile" maintainScrollPositionOnPostBack="true" %>

<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress"
    TagPrefix="TP_wucUpdateProgress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
   <table style="width: 100%; vertical-align: top;" align="center">
        <tr>
            <td style="vertical-align: top; text-align: right">
                <h2>
                    Sistema de nómina: Compensaciones mensuales
                </h2>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top; text-align: left;">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="pnlAños" runat="server" DefaultButton="btnConsultar" Font-Names="Verdana"
                            Font-Size="X-Small" GroupingText="Seleccione año">
                            <br />
                            <asp:DropDownList ID="ddlAños" runat="server" SkinID="SkinDropDownList" AutoPostBack="True">
                            </asp:DropDownList>
                        </asp:Panel>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="lbCrearNuevoListado" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top; text-align: left">
                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="pnlMeses" runat="server" Font-Size="X-Small" Font-Names="Verdana"
                            GroupingText="Meses pagados durante el año">
                            <br />
                            <asp:ListBox ID="lbMeses" runat="server" Font-Names="Verdana"
                                AutoPostBack="True" SelectionMode="Multiple" Rows="5" >
                            </asp:ListBox>
                        </asp:Panel>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlA&#241;os" EventName="SelectedIndexChanged">
                        </asp:AsyncPostBackTrigger>
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top; text-align: left">
                <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                    <ContentTemplate>
                        <asp:Button ID="btnConsultar" runat="server" SkinID="SkinBoton" Text="Consultar"
                            ToolTip="Consultar información relacionada con el año y mes seleccionados" />
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="lbMeses" EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top; text-align: left">
                <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                    <ContentTemplate>
                        <table>
                            <tbody>
                                <tr>
                                    <td>
                                        <asp:LinkButton ID="lbCrearNuevoListado" runat="server" Visible="False" SkinID="SkinLinkButton">Crear nuevo listado de compensaciones</asp:LinkButton>
                                    </td>
                                    <td>
                                        <asp:LinkButton ID="lbNuevaCompensacion" OnClick="lbNuevaCompensacion_Click" runat="server"
                                            Visible="False" SkinID="SkinLinkButton">Nueva compensación</asp:LinkButton>
                                    </td>
                                    <td>
                                        <asp:LinkButton ID="lbNuevaCompensacionE" OnClick="lbNuevaCompensacion_Click" runat="server"
                                            Visible="False" SkinID="SkinLinkButton">Nueva compensación (Extraordinaria)</asp:LinkButton>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <ajaxToolkit:ConfirmButtonExtender ID="CBENuevoListado" runat="server" TargetControlID="lbCrearNuevoListado"
                                            ConfirmText="¿Está seguro de continuar con la operación solicitada?">
                                        </ajaxToolkit:ConfirmButtonExtender>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="lbCrearNuevoListado" EventName="Click"></asp:AsyncPostBackTrigger>
                        <asp:AsyncPostBackTrigger ControlID="btnConsultar" EventName="Click"></asp:AsyncPostBackTrigger>
                        <asp:AsyncPostBackTrigger ControlID="lbMeses" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td style="text-align: left; vertical-align: top;">
                <ajaxToolkit:CollapsiblePanelExtender ID="CPEListadoCompe" runat="Server" CollapseControlID="TitlePanelListadoCompe"
                    Collapsed="False" CollapsedImage="~/Imagenes/expand_blue.jpg" CollapsedText="(Mostrar detalles...)"
                    ExpandControlID="TitlePanelListadoCompe" ExpandedImage="~/Imagenes/collapse_blue.jpg"
                    ExpandedText="(Ocultar detalles...)" ImageControlID="Image1" SuppressPostBack="true"
                    TargetControlID="ContentPanelListadoCompe" TextLabelID="Label1">
                </ajaxToolkit:CollapsiblePanelExtender>
                <asp:Panel ID="TitlePanelListadoCompe" runat="server" BorderColor="White" BorderStyle="Solid"
                    BorderWidth="1px" CssClass="collapsePanelHeader" Width="100%">
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/expand_blue.jpg" />
                    Listado de empleados
                    <asp:Label ID="Label1" runat="server">(Mostrar detalles...)</asp:Label>
                </asp:Panel>
                <asp:Panel ID="ContentPanelListadoCompe" runat="server" CssClass="collapsePanel"
                    Width="100%">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:Label ID="lblMsj" runat="server" SkinID="SkinLblDatos"></asp:Label><br />
                            <asp:GridView ID="gvCompensaciones" runat="server" Width="100%" SkinID="SkinGridView"
                                OnSelectedIndexChanged="gvCompensaciones_SelectedIndexChanged" EmptyDataText="Sin información de empleados con compensación."
                                CellPadding="1">
                                <Columns>
                                    <asp:TemplateField HeaderText="IdEmp" Visible="False">
                                        <ItemTemplate>
                                            <asp:Label ID="lblIdEmp" runat="server" Text='<%# Bind("IdEmp") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Nombre">
                                        <EditItemTemplate>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblNombre" runat="server" Text='<%# Bind("Nombre") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Origen" Visible="False">
                                        <ItemTemplate>
                                            <asp:Label ID="lblOrigen" runat="server" Text='<%# Bind("Origen") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Importe" DataFormatString="{0:c}" HeaderText="Importe">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="FormaDePago" HeaderText="Forma de pago">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ClaveCobro" HeaderText="Clave de cobro">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="NombreCortoBanco" HeaderText="Banco">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="CuentaBancaria" HeaderText="Cuenta bancaria">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="MesesQueAmparaPago" HeaderText="Meses amparados con el pago">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="NumMeses" HeaderText="Meses cobrados durante el a&#241;o">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Acumulado anual">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ibVerAcum" runat="server" ImageUrl="~/Imagenes/Detalles.png"
                                                 ToolTip="Ver histórico de las compensaciones recibidas por el empleado durante el año."
                                                />
                                            <asp:LinkButton ID="lbAcumuladoAnual" runat="server" ToolTip="Ver acumulado anual" Visible="false">Ver</asp:LinkButton>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:CommandField ShowSelectButton="True" Visible="false">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:CommandField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ibModificar" runat="server" ImageUrl="~/Imagenes/Modificar.png"
                                                 ToolTip="Modificar información al empleado sobre la compensación que recibe."
                                                />
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ibEliminar" runat="server" ImageUrl="~/Imagenes/Eliminar.png"
                                                 ToolTip="Eliminar al empleado de la nómina de compensaciones."
                                                />
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Label ID="lblTieneObserv" runat="server" Text='<%# Bind("TieneObservacion") %>'
                                                ToolTip='<%# Bind("Observaciones") %>' SkinID="SkinLblMsjErrores"></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="btnConsultar" EventName="Click"></asp:AsyncPostBackTrigger>
                            <asp:AsyncPostBackTrigger ControlID="ibModificar" EventName="Click"></asp:AsyncPostBackTrigger>
                            <asp:AsyncPostBackTrigger ControlID="ibEliminar" EventName="Click"></asp:AsyncPostBackTrigger>
                            <asp:AsyncPostBackTrigger ControlID="lbCrearNuevoListado" EventName="Click"></asp:AsyncPostBackTrigger>
                            <asp:AsyncPostBackTrigger ControlID="lbNuevaCompensacion" EventName="Click"></asp:AsyncPostBackTrigger>
                            <asp:AsyncPostBackTrigger ControlID="lbMeses" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
                        </Triggers>
                    </asp:UpdatePanel>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top; text-align: left">
                <ajaxToolkit:CollapsiblePanelExtender ID="CPEResumenCompe" runat="server" CollapseControlID="TitlePanelResumenCompe"
                    Collapsed="False" CollapsedImage="~/Imagenes/expand_blue.jpg" CollapsedText="(Mostrar detalles...)"
                    ExpandControlID="TitlePanelResumenCompe" ExpandedImage="~/Imagenes/collapse_blue.jpg"
                    ExpandedText="(Ocultar detalles...)" ImageControlID="Image2" SuppressPostBack="true"
                    TargetControlID="ContentPanelResumenCompe" TextLabelID="Label3">
                </ajaxToolkit:CollapsiblePanelExtender>
                <asp:Panel ID="TitlePanelResumenCompe" runat="server" BorderColor="White" BorderStyle="Solid"
                    BorderWidth="1px" CssClass="collapsePanelHeader" Width="100%">
                    <asp:Image ID="Image2" runat="server" ImageUrl="~/Imagenes/expand_blue.jpg" />
                    Resúmen
                    <asp:Label ID="Label3" runat="server">(Mostrar detalles...)</asp:Label>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top; text-align: left">
                <asp:Panel ID="ContentPanelResumenCompe" runat="server" CssClass="collapsePanel"
                    Width="100%">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <asp:Label ID="lblMsj2" runat="server" SkinID="SkinLblDatos"></asp:Label><br />
                            <asp:GridView ID="gvResumen" runat="server" Width="100%" SkinID="SkinGridView" EmptyDataText="Sin resúmen."
                                CellPadding="1" ShowFooter="True">
                                <Columns>
                                    <asp:BoundField DataField="FormaDePago" HeaderText="Forma de pago" FooterText="Totales">
                                        <FooterStyle HorizontalAlign="Center"></FooterStyle>
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Importe">
                                        <FooterTemplate>
                                            <asp:Label ID="lblImporteTotal" runat="server" Text='<%# Bind("Importe", "{0:c}") %>'></asp:Label>
                                        </FooterTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblImporte" runat="server" Text='<%# Bind("Importe", "{0:c}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterStyle HorizontalAlign="Right"></FooterStyle>
                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Total empleados">
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalEmpsTotal" runat="server" Text='<%# Bind("TotalEmps") %>'></asp:Label>
                                        </FooterTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblTotalEmps" runat="server" Text='<%# Bind("TotalEmps") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterStyle HorizontalAlign="Center"></FooterStyle>
                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <br />
                            <asp:Label ID="lblMsj4" runat="server" SkinID="SkinLblDatos"></asp:Label>
                            <asp:GridView ID="gvResumen2" runat="server" CellPadding="1" 
                                EmptyDataText="Sin resúmen." ShowFooter="True" SkinID="SkinGridView" 
                                Width="100%">
                                <Columns>
                                    <asp:BoundField DataField="TipoEmp" FooterText="Totales" 
                                        HeaderText="Tipo empleado">
                                    <FooterStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Importe">
                                        <FooterTemplate>
                                            <asp:Label ID="lblImporteTotal" runat="server" 
                                                Text='<%# Bind("Importe", "{0:c}") %>'></asp:Label>
                                        </FooterTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblImporte" runat="server" 
                                                Text='<%# Bind("Importe", "{0:c}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterStyle HorizontalAlign="Right" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Total empleados">
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalEmpsTotal" runat="server" 
                                                Text='<%# Bind("TotalEmps") %>'></asp:Label>
                                        </FooterTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblTotalEmps" runat="server" Text='<%# Bind("TotalEmps") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterStyle HorizontalAlign="Center" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="btnConsultar" EventName="Click"></asp:AsyncPostBackTrigger>
                            <asp:AsyncPostBackTrigger ControlID="gvCompensaciones" EventName="RowCommand"></asp:AsyncPostBackTrigger>
                            <asp:AsyncPostBackTrigger ControlID="lbMeses" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
                        </Triggers>
                    </asp:UpdatePanel>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top; text-align: left">
                <ajaxToolkit:CollapsiblePanelExtender ID="CPEOperacionesComunes" runat="server" CollapseControlID="TitlePanelOperComunes"
                    Collapsed="False" CollapsedImage="~/Imagenes/expand_blue.jpg" CollapsedText="(Mostrar detalles...)"
                    ExpandControlID="TitlePanelOperComunes" ExpandedImage="~/Imagenes/collapse_blue.jpg"
                    ExpandedText="(Ocultar detalles...)" ImageControlID="Img1OperComunes" SuppressPostBack="true"
                    TargetControlID="ContentPanelOperComunes" TextLabelID="lbl1OperComunes">
                </ajaxToolkit:CollapsiblePanelExtender>
                <asp:Panel ID="TitlePanelOperComunes" runat="server" BorderColor="White" BorderStyle="Solid"
                    BorderWidth="1px" CssClass="collapsePanelHeader" Width="100%" Visible="false">
                    <asp:Image ID="Img1OperComunes" runat="server" ImageUrl="~/Imagenes/expand_blue.jpg" />
                    Operaciones comúnes al empleado seleccionado
                    <asp:Label ID="lbl1OperComunes" runat="server">(Mostrar detalles...)</asp:Label>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top; text-align: left">
                <asp:Panel ID="ContentPanelOperComunes" runat="server" CssClass="collapsePanel" Width="100%" Visible="false">
                    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                        <ContentTemplate>
                            <asp:Label ID="lblEmpSel" runat="server" SkinID="SkinLblNormal" Text="Empleado seleccionado:"></asp:Label>
                            <asp:Label ID="lblNomEmpSel" runat="server" SkinID="SkinLblDatos">NINGUNO</asp:Label><br />
                            <table>
                                <tr>
                                    <td>
                                        <asp:ImageButton ID="ibEliminar" runat="server" ImageUrl="~/Imagenes/Eliminar.png"
                                            OnClick="ibEliminar_Click" ToolTip="Eliminar compensación al empleado seleccionado"
                                            Enabled="False" />
                                    </td>
                                    <td>
                                        <asp:ImageButton ID="ibModificar" runat="server" ImageUrl="~/Imagenes/Modificar.png"
                                            ToolTip="Modificar información al empleado seleccionado" Enabled="False" OnClick="ibModificar_Click" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <ajaxToolkit:ConfirmButtonExtender ID="CBEEliminar" runat="server" ConfirmText="Esta operación eliminará el registro de la Base de datos, ¿Continuar?"
                                            TargetControlID="ibEliminar">
                                        </ajaxToolkit:ConfirmButtonExtender>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="gvCompensaciones" EventName="SelectedIndexChanged" />
                            <asp:AsyncPostBackTrigger ControlID="btnConsultar" EventName="Click" />
                            <asp:AsyncPostBackTrigger ControlID="lbMeses" EventName="SelectedIndexChanged" />
                        </Triggers>
                    </asp:UpdatePanel>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td style="text-align: left">
                <ajaxToolkit:CollapsiblePanelExtender ID="CPETxts" runat="server" CollapseControlID="TitlePanelTxts"
                    Collapsed="False" CollapsedImage="~/Imagenes/expand_blue.jpg" CollapsedText="(Mostrar detalles...)"
                    ExpandControlID="TitlePanelTxts" ExpandedImage="~/Imagenes/collapse_blue.jpg"
                    ExpandedText="(Ocultar detalles...)" ImageControlID="Image3" SuppressPostBack="true"
                    TargetControlID="ContentPanelTxts" TextLabelID="Label4">
                </ajaxToolkit:CollapsiblePanelExtender>
                <asp:Panel ID="TitlePanelTxts" runat="server" BorderColor="White" BorderStyle="Solid"
                    BorderWidth="1px" CssClass="collapsePanelHeader" Width="100%">
                    <asp:Image ID="Image3" runat="server" ImageUrl="~/Imagenes/expand_blue.jpg" />
                    Archivos TXT
                    <asp:Label ID="Label4" runat="server">(Mostrar detalles...)</asp:Label>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td style="text-align: left">
                <asp:Panel ID="ContentPanelTxts" runat="server" CssClass="collapsePanel" Width="100%">
                    <table>
                        <tr>
                            <td style="vertical-align: top">
                                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                    <ContentTemplate>
                                        <asp:Panel ID="pnlOpcDeImpresion" runat="server" Font-Names="Verdana" Font-Size="X-Small"
                                            GroupingText="Seleccione banco">
                                            <br />
                                            <asp:DropDownList ID="ddlBancos" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlBancos_SelectedIndexChanged"
                                                SkinID="SkinDropDownList">
                                            </asp:DropDownList>
                                            <br />
                                        </asp:Panel>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="btnConsultar" EventName="Click" />
                                        <asp:AsyncPostBackTrigger ControlID="lbMeses" EventName="SelectedIndexChanged" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                            <td style="vertical-align: top">
                                <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                    <ContentTemplate>
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:ImageButton ID="ibGenerarTXT" runat="server" Height="50px" ImageUrl="~/Imagenes/Save.png"
                                                        ToolTip="Generar archivo TXT" Width="50px" OnClick="ibGenerarTXT_Click" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblMsj3" runat="server" SkinID="SkinLblDatos">Generar archivo TXT</asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                        <ajaxToolkit:ConfirmButtonExtender ID="CBEGenerarTXT" runat="server" ConfirmText="¿Está seguro de querer generar el archivo?"
                                            TargetControlID="ibGenerarTXT">
                                        </ajaxToolkit:ConfirmButtonExtender>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="btnConsultar" EventName="Click" />
                                        <asp:AsyncPostBackTrigger ControlID="lbMeses" EventName="SelectedIndexChanged" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                            <td style="vertical-align: top">
                                <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                    <ContentTemplate>
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:ImageButton ID="ibDescargar" runat="server" ImageUrl="~/Imagenes/Download.jpg"
                                                        ToolTip="Descargar archivo" OnClick="ibDescargar_Click" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblMsjDescargar" runat="server" SkinID="SkinLblDatos">Descargar archivo</asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                        <ajaxToolkit:ConfirmButtonExtender ID="CBEDescargarTXT" runat="server" ConfirmText="¿Está seguro de querer descargar el archivo?"
                                            TargetControlID="ibDescargar">
                                        </ajaxToolkit:ConfirmButtonExtender>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="btnConsultar" EventName="Click" />
                                        <asp:AsyncPostBackTrigger ControlID="ibGenerarTXT" EventName="Click" />
                                        <asp:PostBackTrigger ControlID="ibDescargar" />
                                        <asp:AsyncPostBackTrigger ControlID="gvCompensaciones" EventName="RowCommand" />
                                        <asp:AsyncPostBackTrigger ControlID="lbMeses" EventName="SelectedIndexChanged" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td style="text-align: left;">
                <ajaxToolkit:CollapsiblePanelExtender ID="CPEReportes" runat="server" CollapseControlID="TitlePanelReportes"
                    Collapsed="False" CollapsedImage="~/Imagenes/expand_blue.jpg" CollapsedText="(Mostrar detalles...)"
                    ExpandControlID="TitlePanelReportes" ExpandedImage="~/Imagenes/collapse_blue.jpg"
                    ExpandedText="(Ocultar detalles...)" ImageControlID="Img1PnlRep" SuppressPostBack="true"
                    TargetControlID="ContentPanelReportes" TextLabelID="Lbl1PnlRep">
                </ajaxToolkit:CollapsiblePanelExtender>
                <asp:Panel ID="TitlePanelReportes" runat="server" BorderColor="White" BorderStyle="Solid"
                    BorderWidth="1px" CssClass="collapsePanelHeader" Width="100%">
                    <asp:Image ID="Img1PnlRep" runat="server" ImageUrl="~/Imagenes/expand_blue.jpg" />
                    Reportes
                    <asp:Label ID="Lbl1PnlRep" runat="server">(Mostrar detalles...)</asp:Label>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td style="text-align: left">
                <asp:Panel ID="ContentPanelReportes" runat="server" CssClass="collapsePanel" Width="100%">
                    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                        <ContentTemplate>
                            <table>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label2" runat="server" SkinID="SkinLblNormal">Seleccione reporte</asp:Label>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:GridView ID="gvReportes" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gvReportes_SelectedIndexChanged"
                                            SkinID="SkinGridViewEmpty">
                                            <Columns>
                                                <asp:TemplateField HeaderText="IdReporte" Visible="False">
                                                    <EditItemTemplate>
                                                        &nbsp;
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblIdReporte" runat="server" Text='<%# Bind("IdReporte") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="ImplicaMeses" Visible="False">
                                                    <EditItemTemplate>
                                                        &nbsp;
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblImplicaMeses" runat="server" Text='<%# Bind("ImplicaMeses") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="ExportarAExcel" Visible="False">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblExportarAExcel" runat="server" Text='<%# Bind("ExportarAExcel") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="ImplicaFondoPresup" Visible="False">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblImplicaFondoPresup" runat="server" Text='<%# Bind("ImplicaFondoPresup") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="ImplicaQuincenas" Visible="False">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblImplicaQuincenas" runat="server" Text='<%# Bind("ImplicaQuincenas") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="ImplicaPlantel" Visible="False">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblImplicaPlantel" runat="server" Text='<%# Bind("ImplicaPlantel") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="DescParaUsuario" HeaderText="Reporte" />
                                                <asp:CommandField ShowSelectButton="True" />
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:ImageButton ID="ibImprimir" runat="server" ImageUrl="~/Imagenes/PDFExport.jpg"
                                            ToolTip="Mostrar reporteen PDF" />
                                        <asp:ImageButton ID="ibExportarExcel" runat="server" ImageUrl="~/Imagenes/ExcelExport.jpg"
                                            ToolTip="Mostrar reporte en Excel" />
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Panel ID="pnlFchImpRpt" runat="server" Visible="False">
                                            <asp:Label ID="Label5" runat="server" SkinID="SkinLblNormal" 
                                                Text="Fecha de impresión"></asp:Label>
                                            <br />
                                            <asp:TextBox ID="txtbxFchImpRpt" runat="server" AutoPostBack="True" 
                                                MaxLength="10" SkinID="SkinTextBox"></asp:TextBox>
                                        </asp:Panel>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                            </table>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="btnConsultar" EventName="Click" />
                            <asp:AsyncPostBackTrigger ControlID="gvReportes" EventName="SelectedIndexChanged" />
                            <asp:AsyncPostBackTrigger ControlID="lbMeses" EventName="SelectedIndexChanged" />
                        </Triggers>
                    </asp:UpdatePanel>
                </asp:Panel>
            </td>
        </tr>
    </table>
</asp:Content>
