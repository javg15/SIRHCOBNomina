<%@ Page EnableEventValidation="false" Language="VB" MasterPageFile="~/MasterPageSesionIniciada.master"
    AutoEventWireup="false" CodeFile="PlazasBase.aspx.vb" Inherits="PlazasBase"
    Title="COBAEV - Nómina - Empleados, control de incidencias" StylesheetTheme="SkinFile" %>

<%@ Register Src="~/WebControls/wucSearchEmps.ascx" TagName="wucBuscaEmpleados" TagPrefix="uc1" %>
<%@ Register Src="~/WebControls/wucSearchEmps2.ascx" TagName="wucSearchEmps2" TagPrefix="uc2" %>
<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress" TagPrefix="TP_wucUpdateProgress" %>
<%@ Register src="../../WebControls/wucMuestraErrores.ascx" tagname="wucMuestraErrores" tagprefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
    <table style="width: 100%;" align="center">
        <tr>
            <td style="vertical-align: top; text-align: right">
                <h2>
                    Sistema de nómina: Administración de plazas
                </h2>
            </td>
        </tr>
    </table>
<asp:UpdatePanel ID="UpdPnlMain" runat="server">
    <ContentTemplate>
        <asp:Panel ID="pnl1" runat="server">
            <asp:MultiView ID="MultiView1" runat="server">
                <asp:View ID="viewPlazas" runat="server">
                <asp:Panel ID="pnlInfPlaza" runat="server" GroupingText="Paráametros de consulta">
                    <asp:DetailsView ID="dvPlaza" runat="server" AutoGenerateRows="False" SkinID="SkinDetailsView"
                        DefaultMode="Insert" Width="100%">
                        <FieldHeaderStyle Width="250px" Wrap="True" />
                        <Fields>
                            <asp:TemplateField HeaderText="Zona Económica"><InsertItemTemplate><asp:DropDownList ID="ddlZonaEconomica" runat="server" SkinID="SkinDropDownList" AutoPostBack="True"
                                        OnSelectedIndexChanged="ddlZonaEconomica_SelectedIndexChanged"></asp:DropDownList></InsertItemTemplate><HeaderStyle HorizontalAlign="Left" Wrap="False" /><ItemStyle HorizontalAlign="Left" Wrap="False" /></asp:TemplateField>
                            <asp:TemplateField HeaderText="Zona Geográfica"><InsertItemTemplate><asp:DropDownList ID="ddlZonaGeografica" runat="server" SkinID="SkinDropDownList" AutoPostBack="True"
                                        OnSelectedIndexChanged="ddlZonaGeografica_SelectedIndexChanged"></asp:DropDownList></InsertItemTemplate><HeaderStyle HorizontalAlign="Left" Wrap="False" /><ItemStyle HorizontalAlign="Left" Wrap="False" /></asp:TemplateField>
                            <asp:TemplateField HeaderText="Centro de Adscripción<br />(Ubicación física del empleado)"><InsertItemTemplate>
                                <asp:DropDownList ID="ddlPlantelesEmpleado" runat="server" SkinID="SkinDropDownList" AutoPostBack="True" OnSelectedIndexChanged="ddlPlantelesEmpleado_SelectedIndexChanged"></asp:DropDownList></InsertItemTemplate><HeaderStyle HorizontalAlign="Left" Wrap="False" /><ItemStyle HorizontalAlign="Left" Wrap="False" /></asp:TemplateField>
                    
                            <asp:TemplateField HeaderText="Centro de Adscripción al que pertenece la Plaza<br />(Utilizado para pago)"><InsertItemTemplate><asp:DropDownList ID="ddlPlantelesPlaza" runat="server" SkinID="SkinDropDownList" AutoPostBack="True" 
                                        ></asp:DropDownList></InsertItemTemplate><HeaderStyle HorizontalAlign="Left" Wrap="False" /><ItemStyle HorizontalAlign="Left" Wrap="False" /></asp:TemplateField>
                    
                            <asp:TemplateField HeaderText="Categor&#237;a"><InsertItemTemplate><asp:DropDownList ID="ddlCategorias" runat="server" SkinID="SkinDropDownList" AutoPostBack="True"
                                                ></asp:DropDownList></InsertItemTemplate><HeaderStyle  HorizontalAlign="Left" Wrap="False" /><ItemStyle HorizontalAlign="Left" Wrap="False" /></asp:TemplateField>

                            <asp:TemplateField HeaderText="Estatus"><InsertItemTemplate><asp:DropDownList ID="ddlPlazasEstatus" runat="server" SkinID="SkinDropDownList" ></asp:DropDownList></InsertItemTemplate><HeaderStyle  HorizontalAlign="Left" Wrap="False" /><ItemStyle HorizontalAlign="Left" Wrap="False" /></asp:TemplateField>
                            <asp:TemplateField HeaderText="Quincena de término (Vigencia)"><InsertItemTemplate><asp:DropDownList ID="ddlQuincenaTermino" runat="server" SkinID="SkinDropDownList"></asp:DropDownList></InsertItemTemplate><HeaderStyle  HorizontalAlign="Left" Wrap="False" /><ItemStyle HorizontalAlign="Left" Wrap="False" /></asp:TemplateField>
                            <asp:TemplateField HeaderText="Sindicato"><InsertItemTemplate><asp:DropDownList ID="ddlSindicato" runat="server" SkinID="SkinDropDownList"></asp:DropDownList></InsertItemTemplate><HeaderStyle  HorizontalAlign="Left" Wrap="False" /><ItemStyle HorizontalAlign="Left" Wrap="False" /></asp:TemplateField>
                            <asp:TemplateField HeaderText=""><InsertItemTemplate><asp:Button ID="btnConsultar" runat="server" Text="Consultar" SkinID="SkinBoton"  OnClick="btnConsultar_Click"/></InsertItemTemplate>
                                                <HeaderStyle HorizontalAlign="Left" Wrap="False" /><ItemStyle HorizontalAlign="Left" Wrap="False" /></asp:TemplateField>
                       </Fields>
                </asp:DetailsView>
                    <asp:Panel ID="pnlDatos" runat="server" Width="100%" GroupingText="Plazas">
                        <table>
                            
                            <tr>
                                <td align="left">
                                    <asp:LinkButton ID="lbAsignarPlaza" runat="server" OnClick="lbAsignarPlaza_Click"
                                        SkinID="SkinLinkButton" PostBackUrl="~/ABC/Plazas/ABCPlazasBase.aspx?TipoOperacion=1">Crear plaza</asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblTotalRegistros" runat="server" Text="..."></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:GridView ID="gvDatos" runat="server" AutoGenerateColumns="False" EmptyDataText="No existe información."
                                            PageSize="20" SkinID="SkinGridView" Width="100%" OnSelectedIndexChanging="gvDatos_SelectedIndexChanging">
                                            <EmptyDataTemplate>
                                                <div>
                                                    <asp:Label ID="lblMsjSinPermisosEco" runat="server" Text="No existe información."></asp:Label>
                                                </div>
                                            </EmptyDataTemplate>
                                            <EmptyDataRowStyle Font-Italic="True" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="Id"><ItemTemplate><asp:Label ID="lblIdPlazas" runat="server" Text='<%# Bind("IdPlazas") %>'></asp:Label></ItemTemplate><HeaderStyle HorizontalAlign="Center" /><ItemStyle HorizontalAlign="Center" /></asp:TemplateField>
                                                <asp:TemplateField HeaderText="Clave">
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
                                                        <asp:Label ID="lblDescCatego" runat="server" Text='<%# Bind("DescCategoria") %>'></asp:Label>
                                                        <asp:hiddenfield ID="hidCuentaAsignaciones" runat="server" value='<%# Bind("CuentaAsignaciones") %>'></asp:hiddenfield>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Estatus (Base)"><ItemTemplate><asp:Label ID="lblEstatusBase" runat="server" Text='<%# Bind("Estatus") %>'></asp:Label></ItemTemplate><HeaderStyle HorizontalAlign="Center" /><ItemStyle HorizontalAlign="Center" /></asp:TemplateField>
                                                <asp:TemplateField HeaderText="Inicio (Base)"><ItemTemplate><asp:Label ID="lblQuinInicio" runat="server" Text='<%# Bind("QuinInicio") %>'></asp:Label></ItemTemplate><HeaderStyle HorizontalAlign="Center" /><ItemStyle HorizontalAlign="Center" /></asp:TemplateField>
                                                <asp:TemplateField HeaderText="Termino (Base)"><ItemTemplate><asp:Label ID="lblQuinTermino" runat="server" Text='<%# Bind("QuinTermino") %>'></asp:Label></ItemTemplate><HeaderStyle HorizontalAlign="Center" /><ItemStyle HorizontalAlign="Center" /></asp:TemplateField>
                                                <asp:TemplateField HeaderText="Empleado Titular"><ItemTemplate><asp:Label ID="lblTitular" runat="server" Text='<%# Bind("NombT") %>'></asp:Label></ItemTemplate><HeaderStyle HorizontalAlign="Center" /><ItemStyle HorizontalAlign="Center" /></asp:TemplateField>
                                                <asp:TemplateField HeaderText="Ult. Mot. Baja del Titular"><ItemTemplate><asp:Label ID="lblUltDescMotGralBaja" runat="server" Text='<%# Bind("UltDescMotGralBaja") %>'></asp:Label></ItemTemplate><HeaderStyle HorizontalAlign="Center" /><ItemStyle HorizontalAlign="Center" /></asp:TemplateField>
                                                <asp:TemplateField HeaderText="Observaciones"><ItemTemplate><asp:Label ID="lblObservaciones" runat="server" Text='<%# Bind("Observaciones") %>'></asp:Label></ItemTemplate><HeaderStyle HorizontalAlign="Center" /><ItemStyle HorizontalAlign="Center" /></asp:TemplateField>
                                                <asp:TemplateField HeaderText="Ocupante"><ItemTemplate><asp:Label ID="lblOcupante" runat="server" Text='<%# Bind("NombO") %>'></asp:Label></ItemTemplate><HeaderStyle HorizontalAlign="Center" /><ItemStyle HorizontalAlign="Center" /></asp:TemplateField>
                                                <asp:TemplateField HeaderText="Estatus (Ocupante)"><ItemTemplate><asp:Label ID="lblOcupanteEstatus" runat="server" Text='<%# Bind("EstatusO") %>'></asp:Label></ItemTemplate><HeaderStyle HorizontalAlign="Center" /><ItemStyle HorizontalAlign="Center" /></asp:TemplateField>
                                                <asp:TemplateField HeaderText="Inicio (Ocupante)"><ItemTemplate><asp:Label ID="lblOcupanteInicio" runat="server" Text='<%# Bind("QuinIniO") %>'></asp:Label></ItemTemplate><HeaderStyle HorizontalAlign="Center" /><ItemStyle HorizontalAlign="Center" /></asp:TemplateField>
                                                <asp:TemplateField HeaderText="Termino (Ocupante)"><ItemTemplate><asp:Label ID="lblOcupanteFin" runat="server" Text='<%# Bind("QuinFinO") %>'></asp:Label></ItemTemplate><HeaderStyle HorizontalAlign="Center" /><ItemStyle HorizontalAlign="Center" /></asp:TemplateField>
                                                <asp:TemplateField HeaderText="Plantel (Ocupante)"><ItemTemplate><asp:Label ID="lblOcupantePlantel" runat="server" Text='<%# Bind("PlantelO") %>'></asp:Label></ItemTemplate><HeaderStyle HorizontalAlign="Center" /><ItemStyle HorizontalAlign="Center" /></asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sindicato (Ocupante)"><ItemTemplate><asp:Label ID="lblOcupanteSindicato" runat="server" Text='<%# Bind("SindicatoO") %>'></asp:Label></ItemTemplate><HeaderStyle HorizontalAlign="Center" /><ItemStyle HorizontalAlign="Center" /></asp:TemplateField>
                                                <asp:TemplateField HeaderText="Ids" Visible="false"><ItemTemplate>
                                                    <asp:Label ID="lblIdEstatusPlazaBase" runat="server" Text='<%# Bind("IdEstatusPlazaBase") %>'></asp:Label>
                                                    <asp:Label ID="lblIdQnaVigIni" runat="server" Text='<%# Bind("IdQnaVigIni") %>'></asp:Label>
                                                    <asp:Label ID="lblIdQnaVigFin" runat="server" Text='<%# Bind("IdQnaVigFin") %>'></asp:Label>
                                                    </ItemTemplate><HeaderStyle HorizontalAlign="Center" /><ItemStyle HorizontalAlign="Center" /></asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="ibEditar" runat="server" ImageUrl="~/Imagenes/Modificar.png" ToolTip="Editar" CommandName="EditarPlaza" CommandArgument='<%# Container.DataItemIndex%>'  />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="ibNombramiento" runat="server" ImageUrl="~/Imagenes/Categorias.jpg" ToolTip="Asignar" CommandName="NombrarPlaza" CommandArgument='<%# Container.DataItemIndex%>'  />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="ibHistorial" runat="server" ImageUrl="~/Imagenes/detalles.gif" ToolTip="Ver historial." CommandName="HistorialPlaza" CommandArgument='<%# Container.DataItemIndex%>' />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                </td>
                            </tr>
                            
                        </table>
                                        
                    <asp:TextBox  ID="hidIdPlazas" runat="server" BackColor="White" BorderColor="White" BorderWidth="0px" ForeColor="White" Width="1px" />
                </asp:Panel>
                    
                 <asp:DetailsView ID="dvBotones" runat="server" AutoGenerateRows="False" SkinID="SkinDetailsView"
                        DefaultMode="Insert" Width="100%">
                        <FieldHeaderStyle Width="250px" Wrap="True" />
                        <Fields>       
                            <asp:TemplateField ShowHeader="False">
                                <EditItemTemplate>
                                    <asp:Button ID="btnCancelar" runat="server" SkinID="SkinBoton" Text="Cerrar" CausesValidation="false"/>
                                </EditItemTemplate><ItemStyle HorizontalAlign="Right" /></asp:TemplateField>
                        </Fields>
                    </asp:DetailsView>
                </asp:Panel>
                </asp:View>
            </asp:MultiView>
        </asp:Panel>
    
    </ContentTemplate>
</asp:UpdatePanel>
</asp:Content>
               