<%@ Page Language="VB" MasterPageFile="~/MasterPageBlanca.master"
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
            
                     <ajaxToolkit:CollapsiblePanelExtender ID="CPEPlazasEstructura" runat="Server" SuppressPostBack="true"
                        CollapsedImage="~/Imagenes/expand_blue.jpg" ExpandedImage="~/Imagenes/collapse_blue.jpg"
                        ImageControlID="Image2" CollapsedText="(Mostrar detalles...)" ExpandedText="(Ocultar detalles...)"
                        TextLabelID="Label2" Collapsed="False" CollapseControlID="TitlePanelPlazasEstructura"
                        ExpandControlID="TitlePanelPlazasEstructura" TargetControlID="ContentPanelPlazasEstructura">
                    </ajaxToolkit:CollapsiblePanelExtender>

                        <asp:Panel ID="ContentPanelPlazasEstructura" runat="server" Width="100%" CssClass="collapsePanel">
                            <asp:Panel ID="pnlDatos" runat="server" Width="100%" GroupingText="Plazas"
                                >
                                <asp:GridView ID="gvDatos" runat="server" EmptyDataText="El empleado no tiene registradas plazas base"
                                        Height="100%" ShowFooter="True" SkinID="SkinGridViewEmpty" Width="100%" 
                                        AutoGenerateColumns="False" EnableViewState="true">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Plazas Base">
                                                <HeaderStyle HorizontalAlign="Left" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>

                                                    <asp:Label ID="lblCvePlazaTipo" runat="server" Text='<%# Bind("CvePlazaTipo") %>' ToolTip='<%# Bind("ToolTipPlazaTipo") %>'></asp:Label>                                                                        
                                                    <asp:Label ID="lblGuion1" runat="server" Text="-"></asp:Label>
                                                    <asp:Label ID="lblstrHrsJornada" runat="server" Text='<%# Bind("ClavePlantel")%>' ToolTip='<%# Bind("DescPlantel") %>'></asp:Label>
                                                    <asp:Label ID="lblGuion2" runat="server" Text="-"></asp:Label>
                                                    <asp:Label ID="lblZonaEco" runat="server" Text='<%# Bind("ZonaEco") %>' ToolTip='<%# Bind("ToolTipZonaEco") %>'></asp:Label>                                                                        
                                                    <asp:Label ID="lblGuion3" runat="server" Text="-"></asp:Label>
                                                    <asp:Label ID="lblCvePlazaDiferenciador" runat="server" Text='<%# Bind("CvePlazaDiferenciador") %>' ToolTip='<%# Bind("ToolTipPlazaDiferenciador") %>'></asp:Label>
                                                    <asp:Label ID="lblGuion4" runat="server" Text="-"></asp:Label>
                                                    <asp:Label ID="lblCveCategoCOBACH" runat="server" Text='<%# Bind("CveCategoCOBACH") %>' ToolTip='<%# Bind("ToolTipCatego") %>'></asp:Label>
                                                                
                                                    <asp:Label ID="lblGuion5" runat="server" Text="-"></asp:Label>
                                                    <asp:Label ID="lblConsecutivo" runat="server" Text='<%# Bind("Consecutivo") %>' ToolTip="Consecutivo de la plaza"></asp:Label>
                                                    <asp:Label ID="lblSeparador" runat="server" Text="==>"></asp:Label>
                                                    <asp:Label ID="lblDescCatego" runat="server" Text='<%# Bind("DescCatego") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Empleado (Base)">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblEmpleadoBase" runat="server" Text='<%# Bind("NomCompletoEmpTit") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Estatus (Base)">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblEstatusBase" runat="server" Text='<%# Bind("DescEstatusPlazaBase") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Quincena Inicio (Base)">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblQuinIniBase" runat="server" Text='<%# Bind("QnaIniBase") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Quincena Fin (Base)">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblQuinFinBase" runat="server" Text='<%# Bind("QnaFinBase") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <EmptyDataRowStyle Font-Bold="True" Font-Italic="True" />
                                    </asp:GridView>
                            </asp:Panel>
                            <asp:Panel ID="PanelHistorial" runat="server" Width="100%" GroupingText="Historial">
                                        <asp:GridView ID="grdHistorial" runat="server" AutoGenerateColumns="False" EmptyDataText="No existe información."
                                            PageSize="20" SkinID="SkinGridView" Width="100%" >
                                            <EmptyDataTemplate>
                                                <div>
                                                    <asp:Label ID="lblSinHistorial" runat="server" Text="No existe información."></asp:Label>
                                                </div>
                                            </EmptyDataTemplate>
                                            <EmptyDataRowStyle Font-Italic="True" />
                                            <Columns>
                                            <asp:TemplateField HeaderText="IdPlaza" Visible="false">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblIdPlaza" runat="server" Text='<%# Bind("IdPlazas") %>'></asp:Label>
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
                                            <asp:TemplateField HeaderText="Tipo ocupación (Ocupante)">
                                                <HeaderStyle HorizontalAlign="Left" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDescEstatusPlaza" runat="server" Text='<%# Bind("EstatusOcup") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Plantel (Ocupante)">
                                                <HeaderStyle HorizontalAlign="Left" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPlantel" runat="server" Text='<%# Bind("PlantelOcup") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Quincena Inicio (Ocupante)">
                                                <HeaderStyle HorizontalAlign="Left" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblQuinIni" runat="server" Text='<%# Bind("QuinIniOcup") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Quincena Fin (Ocupante)">
                                                <HeaderStyle HorizontalAlign="Left" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblQuinFin" runat="server" Text='<%# Bind("QuinFinOcup") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Motivo Baja (Ocupante)">
                                                <HeaderStyle HorizontalAlign="Left" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblMotBaja" runat="server" Text='<%# Bind("MotBajaOcup") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        </asp:GridView>
                                    </asp:Panel>
                        </asp:Panel>
                    
                
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
               