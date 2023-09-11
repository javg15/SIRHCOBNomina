<%@ Page EnableEventValidation="false" Language="VB" MasterPageFile="~/MasterPageSesionIniciada.master"
    AutoEventWireup="false" CodeFile="ABCPlazasBaseAsignacion.aspx.vb" Inherits="ABCPlazasBaseAsignacion"
    Title="COBAEV - Nómina - Empleados, control de incidencias" StylesheetTheme="SkinFile" %>

<%@ Register Src="~/WebControls/wucSearchEmps.ascx" TagName="wucBuscaEmpleados" TagPrefix="uc1" %>
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
<asp:UpdatePanel ID="UpdPnlMain" runat="server">
    <ContentTemplate>
        <asp:Panel ID="pnl1" runat="server">
            <asp:MultiView ID="MultiView1" runat="server">
                <asp:View ID="viewPlazas" runat="server">
                    <asp:Panel ID="pnlDatos" runat="server" Width="100%" GroupingText="Plazas BASE">
                                    <asp:GridView ID="gvDatos" runat="server" AutoGenerateColumns="False" EmptyDataText="No existe información."
                                            PageSize="20" SkinID="SkinGridView" Width="100%" OnSelectedIndexChanging="gvDatos_SelectedIndexChanging">
                                            <EmptyDataTemplate>
                                                <div>
                                                    <asp:Label ID="lblMsjSinPermisosEco" runat="server" Text="No existe información."></asp:Label>
                                                </div>
                                            </EmptyDataTemplate>
                                            <EmptyDataRowStyle Font-Italic="True" />
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="lnSelectPlaza" runat="server" ImageUrl="~/Imagenes/Select.png"
                                                            CausesValidation="false" ToolTip="Seleccionar registro" CommandName="Select" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Id"><ItemTemplate><asp:Label ID="lblIdPlazas" runat="server" Text='<%# Bind("IdPlazas") %>'></asp:Label></ItemTemplate><HeaderStyle HorizontalAlign="Center" /><ItemStyle HorizontalAlign="Center" /></asp:TemplateField>
                                                <asp:TemplateField HeaderText="Clave">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                    <ItemStyle HorizontalAlign="Left" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCvePlazaTipo" runat="server" Text='<%# Bind("CvePlazaTipo") %>' ToolTip='<%# Bind("ToolTipPlazaTipo") %>'></asp:Label>                                                                        
                                                        <asp:Label ID="lblGuion1" runat="server" Text="-"></asp:Label>
                                                        <asp:Label ID="lblClavePlantel" runat="server" Text='<%# Bind("ClavePlantel")%>' ToolTip='<%# Bind("DescPlantel") %>'></asp:Label>
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
                                            </Columns>
                                        </asp:GridView>
                                        
                                        <asp:TextBox  ID="hidIdPlazas" runat="server" BackColor="White" BorderColor="White" BorderWidth="0px" ForeColor="White" Width="1px" />
                                        <asp:TextBox  ID="hidIdTitular" runat="server" BackColor="White" BorderColor="White" BorderWidth="0px" ForeColor="White" Width="1px" text="0"/>
                                        <asp:RequiredFieldValidator ID="CVIdPlazas" runat="server"
                                                ControlToValidate="hidIdPlazas" Display="Dynamic" ErrorMessage="Seleccione la plaza a asignar como titular"
                                                ToolTip="Seleccione la plaza a asignar como titular" Type="Text"
                                                ValidationGroup="gpoGuarda" >*</asp:RequiredFieldValidator>
                                        <asp:CompareValidator ID="CVIdTitular" runat="server"
                                                ControlToValidate="hidIdTitular" Display="Dynamic" ErrorMessage="La plaza ya tiene titular"
                                                ToolTip="La plaza ya tiene titular" 
                                                ValidationGroup="gpoGuarda" ValueToCompare="0">*</asp:CompareValidator>
                                    </asp:Panel>
                <asp:Panel ID="pnlInfPlaza" runat="server" GroupingText="Información de la plaza asignada o por asignar">
                    <asp:DetailsView ID="dvPlaza" runat="server" AutoGenerateRows="False" SkinID="SkinDetailsView"
                        DefaultMode="Insert" Width="100%">
                        <FieldHeaderStyle Width="250px" Wrap="True" />
                        <Fields>
                            <asp:TemplateField HeaderText="Estatus de la plaza BASE"><InsertItemTemplate>
                                <asp:DropDownList ID="ddlPlazasEstatusBase" runat="server" SkinID="SkinDropDownList" AutoPostBack="True">
                                    <asp:ListItem Value="" Text="-"/>
                                    <asp:ListItem Value="A" Text="Activa"/>
                                    <asp:ListItem Value="D" Text="Deshabilitada"/>
                                    <asp:ListItem Value="C" Text="Cancelada"/>
                                </asp:DropDownList>
                                <asp:CompareValidator ID="CVPlazasEstatusBase" runat="server"
                                                ControlToValidate="ddlPlazasEstatusBase" Display="Dynamic" ErrorMessage="Seleccione el estatus"
                                                Operator="NotEqual" ToolTip="Seleccione el estatus de la plaza base" Type="String"
                                                ValidationGroup="gpoGuarda" ValueToCompare="">*</asp:CompareValidator></InsertItemTemplate><HeaderStyle  HorizontalAlign="Left" Wrap="False" /><ItemStyle HorizontalAlign="Left" Wrap="False" />
                            </asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="Sindicato"><InsertItemTemplate><asp:DropDownList ID="ddlSindicato" runat="server" SkinID="SkinDropDownList" AutoPostBack="True"
                                                ></asp:DropDownList></InsertItemTemplate><HeaderStyle  HorizontalAlign="Left" Wrap="False" /><ItemStyle HorizontalAlign="Left" Wrap="False" /></asp:TemplateField>
                            <asp:TemplateField HeaderText="Categor&#237;a"><InsertItemTemplate><asp:DropDownList ID="ddlCategorias" runat="server" SkinID="SkinDropDownList" AutoPostBack="True"
                                                ></asp:DropDownList><asp:CompareValidator ID="CVCategorias" runat="server"
                                                ControlToValidate="ddlCategorias" Display="Dynamic" ErrorMessage="Seleccione la categoría"
                                                Operator="NotEqual" ToolTip="Seleccione la categoría" Type="Integer"
                                                ValidationGroup="gpoGuarda" ValueToCompare="0">*</asp:CompareValidator></InsertItemTemplate><HeaderStyle  HorizontalAlign="Left" Wrap="False" /><ItemStyle HorizontalAlign="Left" Wrap="False" /></asp:TemplateField>

                            <asp:TemplateField HeaderText="Centro de Adscripción al que pertenece la Plaza<br />(Utilizado para pago)"><InsertItemTemplate><asp:DropDownList ID="ddlPlantelesPlaza" runat="server" SkinID="SkinDropDownList" AutoPostBack="True" 
                                        ></asp:DropDownList><asp:CompareValidator ID="CVPlantelesPlaza" runat="server"
                                                ControlToValidate="ddlPlantelesPlaza" Display="Dynamic" ErrorMessage="Seleccione el centro de adscripción de la plaza"
                                                Operator="NotEqual" ToolTip="Seleccione el centro de adscripción de la plaza" Type="Integer"
                                                ValidationGroup="gpoGuarda" ValueToCompare="0">*</asp:CompareValidator></InsertItemTemplate><HeaderStyle HorizontalAlign="Left" Wrap="False" /><ItemStyle HorizontalAlign="Left" Wrap="False" /></asp:TemplateField>
                            <asp:TemplateField HeaderText=""><InsertItemTemplate></InsertItemTemplate><HeaderStyle HorizontalAlign="Left" Wrap="False" /><ItemStyle HorizontalAlign="Left" Wrap="False" /></asp:TemplateField>

                            <asp:TemplateField HeaderText="Empleado"><InsertItemTemplate><asp:Label ID="lblNombreEmpleado" runat="server" SkinID="SkinLblNormal" Text=""></asp:Label><asp:HiddenField  ID="hidIdEmpleado" runat="server" /></InsertItemTemplate><HeaderStyle HorizontalAlign="Left" Wrap="False" /><ItemStyle HorizontalAlign="Left" Wrap="False" /></asp:TemplateField>
                            <asp:TemplateField HeaderText="Centro de Adscripción<br />(Ubicación física del empleado)"><InsertItemTemplate><asp:DropDownList ID="ddlPlantelesEmpleado" runat="server" SkinID="SkinDropDownList" AutoPostBack="True"
                                        ></asp:DropDownList><asp:CompareValidator ID="CVPlantelesEmpleado" runat="server"
                                                ControlToValidate="ddlPlantelesEmpleado" Display="Dynamic" ErrorMessage="Seleccione el centro de adscripción del empleado"
                                                Operator="NotEqual" ToolTip="Seleccione el centro de adscripción del empleado" Type="Integer"
                                                ValidationGroup="gpoGuarda" ValueToCompare="0">*</asp:CompareValidator></InsertItemTemplate><HeaderStyle HorizontalAlign="Left" Wrap="False" /><ItemStyle HorizontalAlign="Left" Wrap="False" /></asp:TemplateField>                    
                            

                            <asp:TemplateField HeaderText="Estatus del nombramiento"><InsertItemTemplate>
                                <asp:DropDownList ID="ddlPlazasEstatus" runat="server" SkinID="SkinDropDownList" AutoPostBack="True"
                                                ></asp:DropDownList>
                                <asp:CompareValidator ID="CVPlazasEstatus" runat="server"
                                                ControlToValidate="ddlPlazasEstatus" Display="Dynamic" ErrorMessage="Seleccione el estatus"
                                                Operator="NotEqual" ToolTip="Seleccione el estatus" Type="Integer"
                                                ValidationGroup="gpoGuarda" ValueToCompare="0">*</asp:CompareValidator></InsertItemTemplate><HeaderStyle  HorizontalAlign="Left" Wrap="False" /><ItemStyle HorizontalAlign="Left" Wrap="False" />
                            </asp:TemplateField>
                            
                    
                            <asp:TemplateField HeaderText="Inicio"><InsertItemTemplate><asp:DropDownList ID="ddlQuincenaInicio" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlQuincenaInicio_SelectedIndexChanged"
                                        SkinID="SkinDropDownList"></asp:DropDownList><asp:CompareValidator ID="CVInicio" runat="server"
                                                ControlToValidate="ddlQuincenaInicio" Display="Dynamic" ErrorMessage="Seleccione la quincena de inicio"
                                                Operator="NotEqual" ToolTip="Seleccione la quincena de inicio" Type="Integer"
                                                ValidationGroup="gpoGuarda" ValueToCompare="0">*</asp:CompareValidator></InsertItemTemplate><HeaderStyle HorizontalAlign="Left" Wrap="False" /><ItemStyle HorizontalAlign="Left" Wrap="False" /></asp:TemplateField>
                            <asp:TemplateField HeaderText="T&#233;rmino"><InsertItemTemplate>
                                <asp:DropDownList ID="ddlQuincenaTermino" runat="server" SkinID="SkinDropDownList"
                                                AutoPostBack="True" ></asp:DropDownList>
                                <asp:CheckBox ID="chkLiberarPlaza" runat="server" Text="Liberar plaza" Font-Size="10" OnCheckedChanged="chkLiberarPlaza_CheckedChanged" AutoPostBack="True" />
                                <asp:CompareValidator ID="CVVigencia" runat="server" ControlToCompare="ddlQuincenaInicio"
                                                ControlToValidate="ddlQuincenaTermino" Display="Dynamic" ErrorMessage="Vigencia incorrecta."
                                                Operator="GreaterThanEqual" ToolTip="Vigencia incorrecta." Type="Integer"
                                                ValidationGroup="gpoGuarda">*</asp:CompareValidator></InsertItemTemplate><HeaderStyle HorizontalAlign="Left" Wrap="False" /><ItemStyle HorizontalAlign="Left" Wrap="False" /></asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="Observaciones"><InsertItemTemplate><asp:textbox ID="txtObservaciones" runat="server" 
                                                AutoPostBack="True" Rows="2" TextMode="MultiLine" Width="300"></asp:textbox></InsertItemTemplate>
                                                <HeaderStyle HorizontalAlign="Left" Wrap="False" /><ItemStyle HorizontalAlign="Left" Wrap="False" /></asp:TemplateField>
                       </Fields>
                </asp:DetailsView>
                    
                 <asp:DetailsView ID="dvBotones" runat="server" AutoGenerateRows="False" SkinID="SkinDetailsView"
                        DefaultMode="Insert" Width="100%">
                        <FieldHeaderStyle Width="250px" Wrap="True" />
                        <Fields>       
                            <asp:TemplateField ShowHeader="False"><EditItemTemplate><asp:Button ID="btnUpdTitularPlaza" runat="server" SkinID="SkinBoton" Text="Actualizar titular"
                                                ToolTip="Actualizar información " Visible="False" OnClick="btnUpdTitularPlaza_Click" /><ajaxToolkit:ConfirmButtonExtender ID="CBEbtnUpdTitularPlaza" runat="server" ConfirmText="¿Realmente desea actualizar la información del titular de la plaza?"
                                                TargetControlID="btnUpdTitularPlaza"></ajaxToolkit:ConfirmButtonExtender><br /><asp:Button ID="btnCancelar" runat="server" SkinID="SkinBoton" Text="Cancelar" CausesValidation="false"/>
                                <asp:Button ID="btnGuardar" runat="server" SkinID="SkinBoton" Text="Guardar" ToolTip="Guardar cambios"
                                        OnClick="btnGuardar_Click" ValidationGroup="gpoGuarda" /><ajaxToolkit:ConfirmButtonExtender ID="CBE" runat="server"
                                            TargetControlID="btnGuardar" ConfirmText="¿Está seguro de guardar los cambios realizados?"></ajaxToolkit:ConfirmButtonExtender><asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                                        ShowSummary="False" ValidationGroup="gpoGuarda" /></EditItemTemplate><ItemStyle HorizontalAlign="Right" /></asp:TemplateField>
                        </Fields>
                    </asp:DetailsView>
                </asp:Panel>
                </asp:View>
                <asp:View ID="viewExito" runat="server">
                    <table>
                        <tr>
                            <td style="vertical-align: middle; text-align: left">
                                <asp:Image ID="Image2" runat="server" ImageUrl="~/Imagenes/Symbol-Check.png" Width="100px" />
                            </td>
                            <td style="vertical-align: middle; text-align: left">
                                <asp:Label ID="lblExito" runat="server" SkinID="SkinLblMsjExito"></asp:Label>
                                <br />
                                <asp:LinkButton ID="lbOtraOperacion" runat="server" SkinID="SkinLinkButton">Cambiar más datos</asp:LinkButton>
                                &nbsp;<asp:LinkButton ID="lbOtraOperacion0" runat="server" 
                                    PostBackUrl="~/Consultas/Empleados/Historia.aspx?TipoOperacion=4" 
                                    SkinID="SkinLinkButton">Continuar con otra operación en el sistema</asp:LinkButton>
                            </td>
                        </tr>
                    </table>
                    <asp:GridView ID="gvObservsPlaza" runat="server" AutoGenerateColumns="False" 
                        Caption="Observaciones" SkinID="SkinGridView" Width="100%">
                        <Columns>
                            <asp:BoundField DataField="Observacion" HeaderText="Observaciones" />
                        </Columns>
                    </asp:GridView>
                    <asp:Button ID="btnPrint" runat="server" SkinID="SkinBoton" Text="Imprimir" 
                        ToolTip="Imprimir observaciones" />
                    <br />
                </asp:View>
                <asp:View ID="viewError" runat="server">
                    <uc3:wucMuestraErrores ID="wucMuestraErrores1" runat="server" />
                    <div id="divBotonesErrores">
                        <p class="submitButton">
                            <asp:Button ID="btnReintentarOp" runat="server" Text="Reintentar operación" ToolTip=""
                                />
                            <asp:Button ID="btnCancelarOp" runat="server" Text="Continuar con otra operación en el sistema" 
                                ToolTip="" 
                                PostBackUrl="~/Consultas/Empleados/Historia.aspx?TipoOperacion=4" />
                        </p>
                    </div>
                    <!--
                    <table>
                        <tr>
                            <td style="vertical-align: middle; text-align: left">
                                <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/Symbol-Stop.png" Width="100px" />
                            </td>
                            <td style="vertical-align: middle; text-align: left">
                                <asp:Label ID="lblError" runat="server" SkinID="SkinLblMsjErrores"></asp:Label>
                                <br />
                                <asp:LinkButton ID="lbReintentarCaptura" runat="server" SkinID="SkinLinkButton">Reintentar operación</asp:LinkButton>
                            </td>
                        </tr>
                    </table>
                    -->
                </asp:View>
            </asp:MultiView>
        </asp:Panel>
    
    </ContentTemplate>
    <Triggers>
        
    </Triggers>
</asp:UpdatePanel>
                            </td>
                    </tr>
                </table>
            </td>
        </tr>
   </table>
</asp:Content>
               