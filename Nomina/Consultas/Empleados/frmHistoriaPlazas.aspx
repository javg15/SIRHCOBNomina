<%@ Page Language="VB" MasterPageFile="~/MasterPageSesionIniciada.master" AutoEventWireup="false"
    CodeFile="frmHistoriaPlazas.aspx.vb" Inherits="frmHistoriaPlazas" Title="COBAEV - Nómina - Empleados (Historia ocupación de plazas)"
    StylesheetTheme="SkinFile" %>
<%@ Register Src="~/WebControls/wucSearchEmps.ascx" TagName="wucBuscaEmpleados" TagPrefix="uc1" %>
<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress" TagPrefix="TP_wucUpdateProgress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
    <table style="width: 100%; height: 300px" align="center">
        <tr>
            <td style="vertical-align: top; text-align: right">
                <h2>
                    Sistema de nómina: Empleados (Historia ocupación de plazas)
                </h2>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top; width: 100%; height: 100%; text-align: left">
                <table style="width: 100%">
                    <tr>
                        <td style="vertical-align: top; text-align: left">
                            <table style="width: 100%">
                                <tr>
                                    <td>
                                        <uc1:wucBuscaEmpleados ID="WucBuscaEmpleados1" runat="server" EnableViewState="true" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top; text-align: left">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                <asp:Panel ID="pnl1" runat="server">
                                    <ajaxToolkit:CollapsiblePanelExtender ID="CPEPlazasBase" runat="Server" CollapseControlID="TitlePanelPlazasBase"
                                        Collapsed="False" CollapsedImage="~/Imagenes/expand_blue.jpg" CollapsedText="(Mostrar detalles...)"
                                        ExpandControlID="TitlePanelPlazasBase" ExpandedImage="~/Imagenes/collapse_blue.jpg"
                                        ExpandedText="(Ocultar detalles...)" ImageControlID="img1PlazasBase" SuppressPostBack="true"
                                        TargetControlID="ContentPanelPlazasBase" TextLabelID="lbl1PlazasBase">
                                    </ajaxToolkit:CollapsiblePanelExtender>
                                    <ajaxToolkit:CollapsiblePanelExtender ID="CPEPlazasVigentes" runat="Server" CollapseControlID="TitlePanelPlazasVigentes"
                                        Collapsed="False" CollapsedImage="~/Imagenes/expand_blue.jpg" CollapsedText="(Mostrar detalles...)"
                                        ExpandControlID="TitlePanelPlazasVigentes" ExpandedImage="~/Imagenes/collapse_blue.jpg"
                                        ExpandedText="(Ocultar detalles...)" ImageControlID="Image1" SuppressPostBack="true"
                                        TargetControlID="ContentPanelPlazasVigentes" TextLabelID="Label1">
                                    </ajaxToolkit:CollapsiblePanelExtender>
                                    <ajaxToolkit:CollapsiblePanelExtender ID="CPEHistoriaPlazas" runat="Server" CollapseControlID="TitlePanelHistoriaPlazas"
                                        Collapsed="False" CollapsedImage="~/Imagenes/expand_blue.jpg" CollapsedText="(Mostrar detalles...)"
                                        ExpandControlID="TitlePanelHistoriaPlazas" ExpandedImage="~/Imagenes/collapse_blue.jpg"
                                        ExpandedText="(Ocultar detalles...)" ImageControlID="Image3" SuppressPostBack="true"
                                        TargetControlID="ContentPanelHistoriaPlazas" TextLabelID="Label3">
                                    </ajaxToolkit:CollapsiblePanelExtender>
                                    <table cellpadding="0" cellspacing="0" style="width: 100%">
                                        <tbody>
                                            <tr>
                                                <td colspan="2" style="vertical-align: top; text-align: left">
                                                    <asp:Label ID="lblEmpInf" runat="server" Font-Strikeout="False" Font-Underline="True"
                                                        SkinID="SkinLblDatos"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="vertical-align: top; width: 100%; text-align: left">
                                                    <asp:Panel ID="TitlePanelPlazasBase" runat="server" BorderColor="White" BorderStyle="Solid"
                                                        BorderWidth="1px" CssClass="collapsePanelHeader" Width="100%">
                                                        <asp:Image ID="img1PlazasBase" runat="server" ImageUrl="~/Imagenes/expand_blue.jpg" />
                                                        &nbsp;Plazas base del empleado
                                                        <asp:Label ID="lbl1PlazasBase" runat="server">(Mostrar detalles...)</asp:Label>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                           <tr>
                                                <td style="vertical-align: top; width: 100%; text-align: left">
                                                    <asp:Panel ID="ContentPanelPlazasBase" runat="server" CssClass="collapsePanel"
                                                        Width="100%">
                                                        <asp:GridView ID="gvPlazasBase" runat="server" EmptyDataText="El empleado no tiene registradas plazas base"
                                                            Height="100%" ShowFooter="True" SkinID="SkinGridViewEmpty" Width="100%" 
                                                            AutoGenerateColumns="False">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Plazas Base">
                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblCvePlazaTipo" runat="server" Text='<%# Bind("CvePlazaTipo") %>' ToolTip='<%# Bind("ToolTipPlazaTipo") %>'></asp:Label>                                                                        
                                                                        <asp:Label ID="lblGuion1" runat="server" Text="-"></asp:Label>
                                                                        <asp:Label ID="lblZonaEco" runat="server" Text='<%# Bind("ZonaEco") %>' ToolTip='<%# Bind("ToolTipZonaEco") %>'></asp:Label>                                                                        
                                                                        <asp:Label ID="lblGuion2" runat="server" Text="-"></asp:Label>
                                                                        <asp:Label ID="lblCvePlazaDiferenciador" runat="server" Text='<%# Bind("CvePlazaDiferenciador") %>' ToolTip='<%# Bind("ToolTipPlazaDiferenciador") %>'></asp:Label>
                                                                        <asp:Label ID="lblGuion3" runat="server" Text="-"></asp:Label>
                                                                        <asp:Label ID="lblCveCategoCOBACH" runat="server" Text='<%# Bind("CveCategoCOBACH") %>' ToolTip='<%# Bind("ToolTipCatego") %>'></asp:Label>
                                                                        <asp:Label ID="lblGuion4" runat="server" Text="-"></asp:Label>
                                                                        <asp:Label ID="lblstrHrsJornada" runat="server" Text='<%# Bind("strHrsJornada") %>' ToolTip="Horas asociadas a la plaza"></asp:Label>
                                                                        <asp:Label ID="lblGuion5" runat="server" Text="-"></asp:Label>
                                                                        <asp:Label ID="lblConsecutivo" runat="server" Text='<%# Bind("Consecutivo") %>' ToolTip="Consecutivo de la plaza"></asp:Label>
                                                                        <asp:Label ID="lblSeparador" runat="server" Text="==>"></asp:Label>
                                                                        <asp:Label ID="lblDescCatego" runat="server" Text='<%# Bind("DescCatego") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="RFC (Ocupante)">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="lnkbtnrfc" runat="server" CommandName="CmdRFC" Text='<%# databinder.eval(container, "dataitem.RFCEmpOcup") %>' ToolTip="Click en el RFC para seleccionar al empleado para aplicarle operaciones."></asp:LinkButton>
                                                                        <ajaxToolkit:ConfirmButtonExtender ID="CBEEmpSel" runat="server" ConfirmText="¿Seleccionar empleado para consultas posteriores?"
                                                                            TargetControlID="lnkbtnrfc">
                                                                        </ajaxToolkit:ConfirmButtonExtender>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="CURP (Ocupante)" Visible="false">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblCURP" runat="server" Text='<%# Bind("CURPEmpOcup") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Apellido paterno (Ocupante)" Visible="false">
                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblApePat" runat="server" Text='<%# Bind("ApePatEmpOcup") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Apellido materno (Ocupante)" Visible="false">
                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblApeMat" runat="server" Text='<%# Bind("ApeMatEmpOcup") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Nombre (Ocupante)" Visible="false">
                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblNombre" runat="server" Text='<%# Bind("NomEmpOcup") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Núm. Emp (Ocupante)" Visible="false">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblNumEmp" runat="server" Text='<%# Bind("NumEmpOcup") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Nombre (Ocupante)">
                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblNombreCompleto" runat="server" Text='<%# Bind("OcupanteActual") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Tipo ocupación">
                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblDescEstatusPlaza" runat="server" Text='<%# Bind("DescEstatusPlaza") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Plantel">
                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblPlantel" runat="server" Text='<%# Bind("Plantel") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <EmptyDataRowStyle Font-Bold="True" Font-Italic="True" />
                                                        </asp:GridView>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="vertical-align: top; width: 100%; text-align: left">
                                                    <asp:Panel ID="TitlePanelPlazasVigentes" runat="server" BorderColor="White" BorderStyle="Solid"
                                                        BorderWidth="1px" CssClass="collapsePanelHeader" Width="100%">
                                                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/expand_blue.jpg" />
                                                        &nbsp;Plazas con las que cobra actualmente
                                                        <asp:Label ID="Label1" runat="server">(Mostrar detalles...)</asp:Label>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="vertical-align: top; width: 100%; text-align: left">
                                                    <asp:Panel ID="ContentPanelPlazasVigentes" runat="server" CssClass="collapsePanel"
                                                        Width="100%">
                                                        <asp:GridView ID="gvPlazasVigentes" runat="server" EmptyDataText="Sin plazas vigentes"
                                                            Height="100%" ShowFooter="True" SkinID="SkinGridViewEmpty" Width="100%" OnRowDataBound="gvPlazasVigentes_RowDataBound">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="IdPlaza" Visible="False">
                                                                    <EditItemTemplate>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblIdPlaza" runat="server" Text='<%# Bind("IdPlaza") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Plaza(s)">
                                                                    <FooterTemplate>
                                                                        <asp:Panel ID="PnlCrearPlazas" runat="server">
                                                                            <asp:LinkButton ID="lbAsignarPlaza" runat="server" Font-Bold="False" OnClick="lbAsignarPlaza_Click"
                                                                                SkinID="SkinLinkButton" ToolTip="Asignar nueva plaza">Asignar plaza</asp:LinkButton>
                                                                            <asp:LinkButton ID="lbAsignarPlazaCopia" runat="server" Font-Bold="False" SkinID="SkinLinkButton"
                                                                                OnClick="lbAsignarPlazaCopia_Click" Visible="false" ToolTip="Asignar nueva plaza a partir de la última vigente">Asignar nueva plaza (Copia)</asp:LinkButton>
                                                                        </asp:Panel>
                                                                    </FooterTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblPlazas" runat="server" Text='<%# Bind("Plazas") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <ItemStyle Wrap="false" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Ocup.">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblOcupacion" runat="server" Text='<%# Bind("AbrevTipoEmp") %>' ToolTip='<%# Bind("DescTipoEmp") %>'></asp:Label>
                                                                        <asp:Image ID="imgInfTitular" runat="server" 
                                                                            ImageUrl="~/Imagenes/UserInfo.jpg" />
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Plantel (Adscrip. real)">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblClavePlantelAdscripReal" runat="server" 
                                                                            Text='<%# Bind("ClavePlantelAdscripReal") %>' ToolTip='<%# Bind("DescPlantelAdscripReal") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Esquema de pago">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblEsquemaPago" runat="server" 
                                                                            Text='<%# Bind("AbrevEsquemaPago") %>' ToolTip='<%# Bind("DescEsquemaPago") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Sind.">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblSindicato" runat="server" Text='<%# Bind("SiglasSindicato") %>'
                                                                            ToolTip='<%# Bind("NombreSindicato") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Funci&#243;n primaria">
                                                                    <EditItemTemplate>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblNombreFuncionPri" runat="server" SkinID="SkinLblNormal" Text=""></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Funci&#243;n secundaria">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblNombreFuncionSec" runat="server" SkinID="SkinLblNormal" Text=""></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="IdTipoSemestre" HeaderText="IdTipoSemestre" Visible="False" />
                                                                <asp:BoundField DataField="TipoSemestre" HeaderText="Vig. en sem.">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" Width="30px" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="Inicio" HeaderText="Inicio">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="T&#233;rmino" HeaderText="Fin">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                                <asp:TemplateField HeaderText="Motivo de baja">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblMotGralBaja" runat="server" SkinID="SkinLblNormal"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="FechaFin" DataFormatString="{0:d}" 
                                                                    HeaderText="Fecha Fin">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                                <asp:TemplateField Visible="False">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="lbHistoriaPlaza" runat="server" SkinID="SkinLinkButton" ToolTip="Consultar información dehistórica de la plaza">Historia</asp:LinkButton>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <ItemTemplate>
                                                                        <asp:ImageButton ID="ibDetalles" runat="server" ImageUrl="~/Imagenes/Detalles.png"
                                                                            ToolTip="Consultar detalles de la estructura de la plaza." />
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <ItemTemplate>
                                                                        <asp:ImageButton ID="ibModificar" runat="server" ImageUrl="~/Imagenes/Modificar.png"
                                                                            ToolTip="Modificar datos de la estructura de la plaza." />
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <ItemTemplate>
                                                                        <asp:ImageButton ID="ibBaja" runat="server" ImageUrl="~/Imagenes/HandDown.png" ToolTip="Dar de baja la plaza." />
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <ItemTemplate>
                                                                        <asp:ImageButton ID="ibWarning" runat="server" ImageUrl="~/Imagenes/Warning1.png"
                                                                            ToolTip="Haga click para visualizar un listado de observaciones sobre la plaza." />
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <ItemTemplate>
                                                                        <asp:ImageButton ID="ibEliminar" runat="server" 
                                                                            ImageUrl="~/Imagenes/TrashEnabled.png" ToolTip="Eliminar registro." 
                                                                            onclick="ibEliminar_Click" />
                                                                        <ajaxToolkit:ConfirmButtonExtender ID="ibEliminar_CBE" runat="server" 
                                                                            ConfirmText="Esta operación eliminará este registro de nuestra base de datos. ¿Continuar?" 
                                                                            Enabled="True" TargetControlID="ibEliminar">
                                                                        </ajaxToolkit:ConfirmButtonExtender>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <EmptyDataTemplate>
                                                                <asp:LinkButton ID="lbAsignarPlaza" runat="server" OnClick="lbAsignarPlaza_Click"
                                                                    SkinID="SkinLinkButton">Capturar movimiento de personal</asp:LinkButton>
                                                                <asp:LinkButton ID="lbAsignarPlazaCopia" runat="server" Font-Bold="False" OnClick="lbAsignarPlazaCopia_Click"
                                                                    SkinID="SkinLinkButton" ToolTip="Asignar nueva plaza a partir de la última vigente"
                                                                    Visible="false">
                                                                Asignar nueva plaza (Copia)</asp:LinkButton>
                                                            </EmptyDataTemplate>
                                                        </asp:GridView>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="vertical-align: top; width: 100%; text-align: left">
                                                    <asp:Panel ID="TitlePanelHistoriaPlazas" runat="server" BorderColor="White" BorderStyle="Solid"
                                                        BorderWidth="1px" CssClass="collapsePanelHeader" Width="100%">
                                                        <asp:Image ID="Image3" runat="server" ImageUrl="~/Imagenes/expand_blue.jpg" />
                                                        &nbsp;Ocupación histórica de plazas
                                                        <asp:Label ID="Label3" runat="server">(Mostrar detalles...)</asp:Label>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="vertical-align: top; width: 100%; text-align: left">
                                                    <asp:Panel ID="ContentPanelHistoriaPlazas" runat="server" CssClass="collapsePanel"
                                                        Width="100%">
                                                        <asp:GridView ID="gvPlazasHistoria" runat="server" EmptyDataText="Sin historia de plazas"
                                                            Height="100%" ShowFooter="True" SkinID="SkinGridViewEmpty" Width="100%" OnRowDataBound="gvPlazasHistoria_RowDataBound">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="IdPlaza" Visible="False">
                                                                    <EditItemTemplate>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblIdPlaza" runat="server" Text='<%# Bind("IdPlaza") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Plaza(s)">
                                                                    <FooterTemplate>
                                                                    </FooterTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblPlazas" runat="server" Text='<%# Bind("Plazas") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <ItemStyle Wrap="false" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Ocup.">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblOcupacion" runat="server" Text='<%# Bind("AbrevTipoEmp") %>' ToolTip='<%# Bind("DescTipoEmp") %>'></asp:Label>
                                                                        <asp:Image ID="imgInfTitular" runat="server" 
                                                                            ImageUrl="~/Imagenes/UserInfo.jpg" />
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Plantel (Adscrip. real)">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblClavePlantelAdscripReal" runat="server" 
                                                                            Text='<%# Bind("ClavePlantelAdscripReal") %>' ToolTip='<%# Bind("DescPlantelAdscripReal") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Esquema de pago">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblEsquemaPago" runat="server" 
                                                                            Text='<%# Bind("AbrevEsquemaPago") %>' ToolTip='<%# Bind("DescEsquemaPago") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Sind.">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblSindicato" runat="server" Text='<%# Bind("SiglasSindicato") %>'
                                                                            ToolTip='<%# Bind("NombreSindicato") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Funci&#243;n primaria">
                                                                    <EditItemTemplate>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblNombreFuncionPri" runat="server" SkinID="SkinLblNormal" Text=""></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Funci&#243;n secundaria">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblNombreFuncionSec" runat="server" SkinID="SkinLblNormal" Text=""></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="IdTipoSemestre" HeaderText="IdTipoSemestre" Visible="False" />
                                                                <asp:BoundField DataField="TipoSemestre" HeaderText="Vig. en sem.">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" Width="30px" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="Inicio" HeaderText="Inicio">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="T&#233;rmino" HeaderText="Fin">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                                <asp:TemplateField HeaderText="Motivo de baja">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblMotGralBaja" runat="server" SkinID="SkinLblNormal"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="FechaFin" DataFormatString="{0:d}" 
                                                                    HeaderText="Fecha Fin">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                                <asp:TemplateField Visible="False">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="lbHistoriaPlaza" runat="server" SkinID="SkinLinkButton" ToolTip="Consultar información dehistórica de la plaza">Historia</asp:LinkButton>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <ItemTemplate>
                                                                        <asp:ImageButton ID="ibDetalles" runat="server" ImageUrl="~/Imagenes/Detalles.png"
                                                                            ToolTip="Ver definición de la clave presupuestal" />
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <ItemTemplate>
                                                                        <asp:ImageButton ID="ibWarning" runat="server" ImageUrl="~/Imagenes/Warning1.png"
                                                                            ToolTip="Haga click para visualizar un listado de observaciones sobre la plaza." />
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <EmptyDataTemplate>
                                                            </EmptyDataTemplate>
                                                        </asp:GridView>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                    </asp:Panel>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="WucBuscaEmpleados1" EventName="PreRender" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                <asp:Panel ID="pnl2" runat="server">
                                    <asp:Label ID="lblHelpInfTitular1" runat="server" SkinID="SkinLblNormal" Text="Cuando la ocupación de la plaza sea &quot;I&quot; coloque el apuntador sobre "></asp:Label>
                                    <asp:Image ID="imgHelpInfTitular" runat="server" ImageUrl="~/Imagenes/UserInfo.jpg" />
                                    &nbsp;<asp:Label ID="lblHelpInfTitular2" runat="server" SkinID="SkinLblNormal" Text="para ver información del titular de la plaza."></asp:Label>
                                </asp:Panel>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="WucBuscaEmpleados1" EventName="PreRender" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
