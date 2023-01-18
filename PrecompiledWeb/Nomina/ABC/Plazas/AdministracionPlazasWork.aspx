<%@ page language="VB" masterpagefile="~/MasterPageSesionIniciada.master" autoeventwireup="false" inherits="AdministracionPlazasWork, App_Web_xmuq13zf" title="COBAEV - Nómina - Administrar plazas" stylesheettheme="SkinFile" maintainScrollPositionOnPostBack="true" %>

<%@ Register Src="../../WebControls/wucSearchEmps2.ascx" TagName="wucSearchEmps2"
    TagPrefix="uc2" %>
<%@ Register Src="~/WebControls/wucSearchEmps.ascx" TagName="wucBuscaEmpleados" TagPrefix="uc1" %>
<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress"
    TagPrefix="TP_wucUpdateProgress" %>
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
            <uc1:wucBuscaEmpleados ID="WucBuscaEmpleados1" runat="server" EnableViewState="true" />
            <asp:MultiView ID="MultiView1" runat="server">
                <asp:View ID="viewPlazas" runat="server">
                             <asp:Panel ID="pnlDetallesPlaza" runat="server" Visible="true" GroupingText="Información sobre plaza(s) base del empleado">

                                 <asp:GridView ID="gvPlazasBaseEmp" runat="server" AutoGenerateColumns="False" 
                                     EmptyDataText="Empleado sin plaza(s) base." SkinID="SkinGridView">
                                 <Columns>
                                             <asp:TemplateField HeaderText="Plaza(s)" ItemStyle-Wrap="false" >
                                             <ItemTemplate>
                                                 <asp:Label ID="lblZonaEco" runat="server" Text='<%# Bind("ZonaEco") %>' ToolTip='<%# Bind("ToolTipZonaEco") %>'></asp:Label>
                                                 <asp:Label ID="lblGuion1" runat="server" Text="-"></asp:Label>
                                                 <asp:Label ID="lblCvePlazaTipo" runat="server" Text='<%# Bind("CvePlazaTipo") %>' ToolTip='<%# Bind("ToolTipPlazaTipo") %>'></asp:Label>
                                                 <asp:Label ID="lblGuion2" runat="server" Text="-"></asp:Label>
                                                 <asp:Label ID="lblCvePlazaDiferenciador" runat="server" Text='<%# Bind("CvePlazaDiferenciador") %>' ToolTip='<%# Bind("ToolTipPlazaDiferenciador") %>'></asp:Label>
                                                 <asp:Label ID="lblGuion3" runat="server" Text="-"></asp:Label>
                                                 <asp:Label ID="lblCveCategoCOBACH" runat="server" Text='<%# Bind("CveCategoCOBACH") %>' ToolTip='<%# Bind("ToolTipCatego") %>'></asp:Label>
                                                 <asp:Label ID="lblGuion4" runat="server" Text="-"></asp:Label>
                                                 <asp:Label ID="lblstrHrsJornada" runat="server" Text='<%# Bind("strHrsJornada") %>' ToolTip="Horas relacionadas con la categoría de la plaza."></asp:Label>
                                                 <asp:Label ID="lblGuion5" runat="server" Text="-"></asp:Label>
                                                 <asp:Label ID="lblConsecutivo" runat="server" Text='<%# Bind("Consecutivo") %>' ToolTip="Consecutivo. Número que hace única a la plaza."></asp:Label>
                                             </ItemTemplate>                                             
                                                 <HeaderStyle HorizontalAlign="Left" />
                                                 <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                         </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Estatus actual">
                                                 <ItemTemplate>
                                                     <asp:Label ID="Label1" runat="server" Text='<%# Bind("IdEstatusPlaza") %>' ToolTip='<%# Bind("DescEstatusPlaza") %>'></asp:Label>
                                                 </ItemTemplate>
                                                 <HeaderStyle HorizontalAlign="Center" />
                                                  <ItemStyle HorizontalAlign="Center" Wrap="False" />
                                             </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Adscrita a">
                                                 <ItemTemplate>
                                                     <asp:Label ID="Label2" runat="server" Text='<%# Bind("ClavePlantel") %>' ToolTip='<%# Bind("Adscripcion") %>'></asp:Label>
                                                 </ItemTemplate>
                                                 <HeaderStyle HorizontalAlign="Center" />
                                                 <ItemStyle HorizontalAlign="Center" />
                                             </asp:TemplateField>
                                         <asp:BoundField DataField="OcupanteActual" HeaderText="Ocupante actual"  >                                         
                                             <HeaderStyle HorizontalAlign="Left" />
                                             <ItemStyle HorizontalAlign="Left" />
                                             </asp:BoundField>
                                 </Columns>
                                 </asp:GridView>

                             </asp:Panel>

                <div class="accountInfo">
                    <fieldset id="fsCaptura">
                        <legend>
                            <asp:Label ID="lblEmpInf2" Text="Información específica de la plaza a asignar" runat="server" Font-Strikeout="False" Font-Underline="True"></asp:Label>
                        </legend>
                        <div class="panelIzquierda">
                            <p class="pLabel">
                                <asp:Label ID="lblPlaza" runat="server" CssClass="pLabel" 
                                    Text="Clave de la plaza:" />
                            </p>
                            <p class="pTextBox">
                                    <asp:TextBox ID="txtbxZonaEcoPlaza" runat="server" ReadOnly="true"  CssClass="textEntry"
                                        Width="30px" ValidationGroup="gpoGuarda" MaxLength="2" ToolTip="Zona económica de la plaza"></asp:TextBox>
                                    <asp:TextBox ID="txtbxCvePlazaTipo" runat="server" ReadOnly="true"  CssClass="textEntry"
                                        Width="60px" ValidationGroup="gpoGuarda" MaxLength="3" ToolTip="Tipo plaza"></asp:TextBox>
                                    <asp:TextBox ID="txtbxCvePlazaDiferenciador" runat="server" ReadOnly="true"  CssClass="textEntry"
                                        Width="30px" ValidationGroup="gpoGuarda" MaxLength="2" ToolTip="Diferenciador de plaza"></asp:TextBox>
                                    <asp:TextBox ID="txtbxCveCategoPlaza" runat="server" ReadOnly="true"  CssClass="textEntry"
                                        Width="60px" ValidationGroup="gpoGuarda" MaxLength="3" ToolTip="Clave de la categoría de la plaza"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="txtbxCveCategoPlaza_RFV" runat="server" 
                                        ControlToValidate="txtbxCveCategoPlaza" Display="Dynamic" 
                                        ErrorMessage="Indicar la categoría de la plaza es obligatorio." 
                                        ToolTip="Indicar la categoría de la plaza es obligatorio."
                                        ValidationGroup="gpoGuarda">*</asp:RequiredFieldValidator>
                                    <asp:TextBox ID="txtbxHorasPlaza" runat="server" ReadOnly="true"  CssClass="textEntry"
                                        Width="30px" ValidationGroup="gpoGuarda" MaxLength="2" ToolTip="Horas asociadas a la plaza"></asp:TextBox>
                                    <asp:TextBox ID="txtbxConsPlaza" runat="server"  CssClass="textEntry"
                                        Width="65px" ValidationGroup="gpoGuarda" MaxLength="5" ToolTip="Consecutivo de la plaza"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="txtbxConsPlaza_RFV" runat="server" 
                                        ControlToValidate="txtbxConsPlaza" Display="Dynamic" 
                                        ErrorMessage="Indicar el consecutivo de la plaza es obligatorio." 
                                        ToolTip="Indicar el consecutivo de la plaza es obligatorio." 
                                        ValidationGroup="gpoGuarda">*</asp:RequiredFieldValidator>
                            </p>
                            <asp:Panel ID="pnlValoresPlaza" runat="server" Visible="true">
                            <p class="pLabel">
                                <asp:Label ID="lblZonaEcoPlaza" runat="server" CssClass="pLabel" 
                                    Text="Zona económica de la plaza:" />
                            </p>
                            <p class="pTextBox">
                                <asp:DropDownList ID="ddlZonasEco" runat="server" CssClass="textEntry" 
                                   AutoPostBack="True">
                                </asp:DropDownList>
                            </p>
                            <p class="pLabel">
                                <asp:Label ID="lblTipoPlaza" runat="server" CssClass="pLabel"
                                    Text="Tipo de plaza:" />
                            </p>
                            <p class="pTextBox">
                                <asp:DropDownList ID="ddlTiposDePlaza" runat="server" CssClass="textEntry" 
                                    AutoPostBack="True">
                                </asp:DropDownList>
                            </p>
                            <p class="pLabel">
                                <asp:Label ID="lblPlazaClasif" runat="server" CssClass="pLabel"
                                    Text="Clasificación de la plaza:" />
                            </p>
                            <p class="pTextBox">
                                <asp:DropDownList ID="ddlPlazasClasif" runat="server" CssClass="textEntry" 
                                    AutoPostBack="True">
                                </asp:DropDownList>
                            </p>
                            <p class="pLabel">
                                <asp:Label ID="lblCategosPlaza" runat="server" CssClass="pLabel"
                                    Text="Categoría de la plaza:" />
                            </p>
                            <p class="pTextBox">
                                <asp:DropDownList ID="ddlCategosPlaza" runat="server" CssClass="textEntry" 
                                    AutoPostBack="True">
                                </asp:DropDownList>
                            </p>
                            </asp:Panel>
                        </div>
                        <div class="pnlDerecha">
                        </div>                        
                    </fieldset>
                </div>
                <asp:Panel ID="pnldivBotones" runat="server" Visible="true">
                    <div id="divBotones">
                        <p class="submitButton">

                            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" 
                                ToolTip="Cancelar operación actual" />
                            <asp:Button ID="btnContinuar" runat="server" Text="Continuar" 
                                ValidationGroup="gpoGuarda"
                                ToolTip="Continuar con el proceso de asignación de plaza" 
                            />

                        </p>
                    </div>
                    </asp:Panel>
                <asp:Panel ID="pnldvPlaza" runat="server" GroupingText="Información complementaria del movimiento" Visible="false">
                <div class="accountInfo">
                    <fieldset id="fsCaptura2">
                        <div class="panelIzquierda">
                            <p class="pLabel">
                                <asp:Label ID="Label4" runat="server" CssClass="pLabel" 
                                    Text="Función: (Conservado por compatibilidad)" />
                            </p>
                            <p class="pTextBox">
                                <asp:DropDownList ID="ddlEmpsFuncs" runat="server" Enabled="False">
                                </asp:DropDownList>                            
                            </p>
                            <p class="pLabel">
                                <asp:Label ID="Label3" runat="server" CssClass="pLabel" 
                                    Text="Centro de Adscripción de la plaza:" />
                            </p>
                            <p class="pTextBox"> 
                                <asp:DropDownList ID="ddlAdscrips" runat="server" AutoPostBack="True" 
                                    Enabled="False" >
                                </asp:DropDownList>
                            </p>
                            <p class="pLabel">
                                <asp:Label ID="Label7" runat="server" CssClass="pLabel" 
                                    Text="Adhesión sindical de la plaza:" />
                            </p>
                            <p class="pTextBox">
                                    <asp:DropDownList ID="ddlSindic" runat="server" Enabled="False">
                                    </asp:DropDownList>
                            </p>
                            <p class="pLabel">
                                <asp:Label ID="Label9" runat="server" CssClass="pLabel" 
                                    Text="Nombramiento en plaza:" />
                            </p>
                            <p class="pTextBox">
                                <asp:DropDownList ID="ddlNombramientos" runat="server">
                                </asp:DropDownList>
                            </p>
                        </div>
                        <div class="pnlDerecha">
                            <p class="pLabel">
                                <asp:Label ID="Label6" runat="server" CssClass="pLabel" 
                                    Text="Nómina: (Conservado por compatibilidad)" />
                            </p>
                            <p class="pTextBox">
                                <asp:DropDownList ID="ddlTiposNoms" runat="server"  Enabled="False">
                                </asp:DropDownList>
                            </p>
                            <p class="pLabel">
                                <asp:Label ID="Label5" runat="server" CssClass="pLabel" 
                                    Text="Departamento dentro del Centro de Adscripción:" />
                            </p>
                            <p class="pTextBox">
                                <asp:DropDownList ID="ddlDeptos" runat="server" >
                                </asp:DropDownList>
                            </p>
                            <p class="pLabel">
                                <asp:Label ID="Label8" runat="server" CssClass="pLabel" 
                                    Text="Categoría de la plaza:" />
                            </p>
                            <p class="pTextBox">
                                    <asp:DropDownList ID="ddlCategos" runat="server" Enabled="False">
                                    </asp:DropDownList>
                            </p>
                        </div>
                    </fieldset>
                </div>
                     <asp:DetailsView ID="dvPlaza" runat="server" AutoGenerateRows="False" SkinID="SkinDetailsView"
                        DefaultMode="Insert" Width="100%" Visible="false">
                        <FieldHeaderStyle Width="250px" Wrap="True" />
                        <Fields>
                            <asp:TemplateField HeaderText="Funci&#243;n">
                                <EditItemTemplate>
                                    <asp:DropDownList ID="ddlEmpleadosFuncionesE" runat="server" SkinID="SkinDropDownList"
                                        AutoPostBack="True">
                                    </asp:DropDownList>
                                </EditItemTemplate>
                                <InsertItemTemplate>
                                    <asp:DropDownList ID="ddlEmpleadosFunciones" runat="server" SkinID="SkinDropDownList"
                                        AutoPostBack="True" OnSelectedIndexChanged="ddlEmpleadosFunciones_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </InsertItemTemplate>
                                <HeaderStyle HorizontalAlign="Right" Wrap="False" />
                                <ItemStyle HorizontalAlign="Left" Wrap="False" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Centro de trabajo">
                                <EditItemTemplate>
                                    <asp:DropDownList ID="ddlPlantelesE" runat="server" AutoPostBack="True" SkinID="SkinDropDownList"
                                        OnSelectedIndexChanged="ddlPlanteles_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </EditItemTemplate>
                                <InsertItemTemplate>
                                    <asp:DropDownList ID="ddlPlanteles" runat="server" SkinID="SkinDropDownList" AutoPostBack="True"
                                        OnSelectedIndexChanged="ddlPlanteles_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </InsertItemTemplate>
                                <HeaderStyle HorizontalAlign="Right" Wrap="False" />
                                <ItemStyle HorizontalAlign="Left" Wrap="False" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="N&#243;mina" Visible="false">
                                <EditItemTemplate>
                                    <asp:DropDownList ID="ddlTiposDeNominasE" runat="server" SkinID="SkinDropDownList">
                                    </asp:DropDownList>
                                </EditItemTemplate>
                                <InsertItemTemplate>
                                    <asp:DropDownList ID="ddlTiposDeNominas" runat="server" SkinID="SkinDropDownList">
                                    </asp:DropDownList>
                                </InsertItemTemplate>
                                <HeaderStyle HorizontalAlign="Right" Wrap="False" />
                                <ItemStyle HorizontalAlign="Left" Wrap="False" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Departamento">
                                <EditItemTemplate>
                                    <asp:DropDownList ID="ddlCentrosDeTrabajoE" runat="server" SkinID="SkinDropDownList">
                                    </asp:DropDownList>
                                </EditItemTemplate>
                                <InsertItemTemplate>
                                    <asp:DropDownList ID="ddlCentrosDeTrabajo" runat="server" SkinID="SkinDropDownList">
                                    </asp:DropDownList>
                                </InsertItemTemplate>
                                <HeaderStyle HorizontalAlign="Right" Wrap="False" />
                                <ItemStyle HorizontalAlign="Left" Wrap="False" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Categor&#237;a">
                                <EditItemTemplate>
                                    <asp:DropDownList ID="ddlCategoriasE" runat="server" SkinID="SkinDropDownList">
                                    </asp:DropDownList>
                                </EditItemTemplate>
                                <InsertItemTemplate>
                                    <asp:DropDownList ID="ddlCategorias" runat="server" SkinID="SkinDropDownList" AutoPostBack="True"
                                        OnSelectedIndexChanged="ddlCategorias_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </InsertItemTemplate>
                                <HeaderStyle HorizontalAlign="Right" Wrap="False" />
                                <ItemStyle HorizontalAlign="Left" Wrap="False" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Sindicato">
                                <EditItemTemplate>
                                    <asp:DropDownList ID="ddlSindicatos" runat="server" SkinID="SkinDropDownList">
                                    </asp:DropDownList>
                                </EditItemTemplate>
                                <InsertItemTemplate>
                                    <asp:DropDownList ID="ddlSindicatos" runat="server" SkinID="SkinDropDownList">
                                    </asp:DropDownList>
                                </InsertItemTemplate>
                                <HeaderStyle HorizontalAlign="Right" Wrap="False" />
                                <ItemStyle HorizontalAlign="Left" Wrap="False" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Tipo ocupaci&#243;n">
                                <EditItemTemplate>
                                    <asp:DropDownList ID="ddlPlazasTipoOcup" runat="server" SkinID="SkinDropDownList">
                                    </asp:DropDownList>
                                </EditItemTemplate>
                                <InsertItemTemplate>
                                    <asp:DropDownList ID="ddlPlazasTipoOcup" runat="server" SkinID="SkinDropDownList"
                                        AutoPostBack="True" OnSelectedIndexChanged="ddlPlazasTipoOcup_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <br />
                                    <asp:CheckBox ID="ChckBxTratarComoBase" runat="server" SkinID="SkinCheckBox" Text="Tratar como Plaza de base" />
                                    <asp:CheckBox ID="chkbxInterinoPuro" runat="server" SkinID="SkinCheckBox" Text="¿Interino puro?" />
                                </InsertItemTemplate>
                                <HeaderStyle HorizontalAlign="Right" Wrap="False" />
                                <ItemStyle HorizontalAlign="Left" Wrap="False" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Motivo interinato">
                                <EditItemTemplate>
                                    <asp:DropDownList ID="ddlMotivoInterinatoE" runat="server" SkinID="SkinDropDownList">
                                    </asp:DropDownList>
                                </EditItemTemplate>
                                <InsertItemTemplate>
                                    <asp:DropDownList ID="ddlMotivoInterinatoI" runat="server" SkinID="SkinDropDownList">
                                    </asp:DropDownList>
                                </InsertItemTemplate>
                                <HeaderStyle HorizontalAlign="Right" Wrap="False" />
                                <ItemStyle HorizontalAlign="Left" Wrap="False" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Titular de la plaza">
                                <EditItemTemplate>
                                    <uc2:wucSearchEmps2 ID="WucBuscaEmpleados2_E" runat="server" Visible="false" />
                                    <asp:Label ID="LblEmpTitularSDE" runat="server" SkinID="SkinLblNormal" Text="(SIN DEFINIR)"></asp:Label>
                                </EditItemTemplate>
                                <InsertItemTemplate>
                                    <table>
                                        <tr>
                                            <td>
                                                <uc2:wucSearchEmps2 ID="WucBuscaEmpleados2_I" runat="server" Visible="false" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="LblEmpTitularSDI" runat="server" SkinID="SkinLblNormal" Text="(SIN DEFINIR)"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: right">
                                            </td>
                                        </tr>
                                    </table>
                                </InsertItemTemplate>
                                <HeaderStyle HorizontalAlign="Right" Wrap="False" />
                                <ItemStyle HorizontalAlign="Left" Wrap="False" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Funci&#243;n primaria">
                                <EditItemTemplate>
                                    <asp:DropDownList ID="ddlFuncionesPriE" runat="server" SkinID="SkinDropDownList">
                                    </asp:DropDownList>
                                </EditItemTemplate>
                                <InsertItemTemplate>
                                    <asp:DropDownList ID="ddlFuncionesPri" runat="server" SkinID="SkinDropDownList" AutoPostBack="False">
                                    </asp:DropDownList>
                                </InsertItemTemplate>
                                <HeaderStyle HorizontalAlign="Right" Wrap="False" />
                                <ItemStyle HorizontalAlign="Left" Wrap="False" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Funci&#243;n secundaria">
                                <EditItemTemplate>
                                    <asp:DropDownList ID="ddlFuncionesSecE" runat="server" SkinID="SkinDropDownList">
                                    </asp:DropDownList>
                                </EditItemTemplate>
                                <InsertItemTemplate>
                                    <asp:DropDownList ID="ddlFuncionesSec" runat="server" SkinID="SkinDropDownList" AutoPostBack="False">
                                    </asp:DropDownList>
                                </InsertItemTemplate>
                                <HeaderStyle HorizontalAlign="Right" Wrap="False" />
                                <ItemStyle HorizontalAlign="Left" Wrap="False" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Inicio">
                                <EditItemTemplate>
                                    <asp:DropDownList ID="ddlQuincenaInicio" runat="server" SkinID="SkinDropDownList">
                                    </asp:DropDownList>
                                </EditItemTemplate>
                                <InsertItemTemplate>
                                    <asp:DropDownList ID="ddlQuincenaInicio" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlQuincenaInicio_SelectedIndexChanged"
                                        SkinID="SkinDropDownList">
                                    </asp:DropDownList>
                                </InsertItemTemplate>
                                <HeaderStyle HorizontalAlign="Right" Wrap="False" />
                                <ItemStyle HorizontalAlign="Left" Wrap="False" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="T&#233;rmino">
                                <EditItemTemplate>
                                    <asp:DropDownList ID="ddlQuincenaTermino" runat="server" SkinID="SkinDropDownList">
                                    </asp:DropDownList>
                                </EditItemTemplate>
                                <InsertItemTemplate>
                                    <asp:DropDownList ID="ddlQuincenaTermino" runat="server" SkinID="SkinDropDownList"
                                        AutoPostBack="True" OnSelectedIndexChanged="ddlQuincenaTermino_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:CompareValidator ID="CVVigencia" runat="server" ControlToCompare="ddlQuincenaInicio"
                                        ControlToValidate="ddlQuincenaTermino" Display="Dynamic" ErrorMessage="Vigencia incorrecta."
                                        Operator="GreaterThanEqual" ToolTip="Vigencia incorrecta." ValidationGroup="gpoGuarda">*</asp:CompareValidator>
                                </InsertItemTemplate>
                                <HeaderStyle HorizontalAlign="Right" Wrap="False" />
                                <ItemStyle HorizontalAlign="Left" Wrap="False" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Motivo de baja">
                                <InsertItemTemplate>
                                    <asp:DropDownList ID="ddlMotivosDeBaja" runat="server" SkinID="SkinDropDownList"
                                        AutoPostBack="True" OnSelectedIndexChanged="ddlMotivosDeBaja_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <br />
                                    <asp:Label ID="lblFechaBajaISSSTE" runat="server" SkinID="SkinLbl9pt" Text="Fecha de baja ante ISSSTE:"
                                        Visible="False"></asp:Label>
                                    <asp:TextBox ID="txtbxFechaBajaISSSTE" runat="server" SkinID="SkinTextBox" Visible="False"
                                        Width="100px" ValidationGroup="gpoGuarda" MaxLength="10"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="txtbxFechaBajaISSSTE_CE" runat="server" Enabled="True"
                                        TargetControlID="txtbxFechaBajaISSSTE">
                                    </ajaxToolkit:CalendarExtender>
                                    <asp:CompareValidator ID="txtbxFechaBajaISSSTE_CV" runat="server" ControlToValidate="txtbxFechaBajaISSSTE"
                                        Display="Dynamic" Enabled="False" ErrorMessage="Fecha de baja incorrecta." Operator="DataTypeCheck"
                                        ToolTip="Fecha incorrecta." Type="Date" ValidationGroup="gpoGuarda">*</asp:CompareValidator>
                                </InsertItemTemplate>
                                <HeaderStyle HorizontalAlign="Right" Wrap="False" />
                                <ItemStyle HorizontalAlign="Left" Wrap="False" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Cadena">
                                <InsertItemTemplate>
                                    <asp:DropDownList ID="ddlCadenas" runat="server" SkinID="SkinDropDownList">
                                    </asp:DropDownList>
                                </InsertItemTemplate>
                                <HeaderStyle HorizontalAlign="Right" Wrap="False" />
                                <ItemStyle HorizontalAlign="Left" Wrap="False" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Vigente en semestre(s)">
                                <InsertItemTemplate>
                                    <asp:DropDownList ID="ddlTiposDeSemestres" runat="server" SkinID="SkinDropDownList">
                                    </asp:DropDownList>
                                </InsertItemTemplate>
                                <HeaderStyle HorizontalAlign="Right" Wrap="False" />
                                <ItemStyle HorizontalAlign="Left" Wrap="False" />
                            </asp:TemplateField>
                            <asp:TemplateField ShowHeader="False">
                                <EditItemTemplate>
                                    <asp:Button ID="btnUpdTitularPlaza" runat="server" SkinID="SkinBoton" Text="Actualizar titular"
                                        ToolTip="Actualizar información del titular de la plaza" Visible="False" OnClick="btnUpdTitularPlaza_Click" />
                                    <ajaxToolkit:ConfirmButtonExtender ID="CBEbtnUpdTitularPlaza" runat="server" ConfirmText="¿Realmente desea actualizar la información del titular de la plaza?"
                                        TargetControlID="btnUpdTitularPlaza">
                                    </ajaxToolkit:ConfirmButtonExtender>
                                    <br />
                                    <asp:Button ID="btnGuardar" runat="server" SkinID="SkinBoton" Text="Guardar" ToolTip="Guardar cambios"
                                        OnClick="btnGuardar_Click" ValidationGroup="gpoGuarda" /><ajaxToolkit:ConfirmButtonExtender
                                            ID="CBE" runat="server" TargetControlID="btnGuardar" ConfirmText="¿Está seguro de guardar los cambios realizados?">
                                        </ajaxToolkit:ConfirmButtonExtender>
                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                                        ShowSummary="False" ValidationGroup="gpoGuarda" />
                                </EditItemTemplate>
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:TemplateField>
                        </Fields>
                    </asp:DetailsView>
                <asp:Panel ID="pnldivBotones2" runat="server" >
                    <div id="divBotones2">
                        <p class="submitButton">

                            <asp:Button ID="btnCancelar0" runat="server" Text="Cancelar" 
                                ToolTip="Cancelar operación actual" />

                            <asp:Button ID="btnModificarPlaza" runat="server" Text="Modificar plaza" 
                                ToolTip="Regresar para modificar la clave de plaza" />
                            <asp:Button ID="btnContinuar2" runat="server" Text="Continuar"                                
                                ToolTip="Continuar con el proceso de asignación de plaza" 
                            />

                        </p>
                    </div>
                    </asp:Panel>
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
                            </td>
                        </tr>
                    </table>
                    <asp:GridView ID="gvObservsPlaza" runat="server" AutoGenerateColumns="False" Caption="Observaciones"
                        SkinID="SkinGridView" Width="100%">
                        <Columns>
                            <asp:BoundField DataField="Observacion" HeaderText="Observaciones" />
                        </Columns>
                    </asp:GridView>
                    <asp:Button ID="btnPrint" runat="server" SkinID="SkinBoton" Text="Imprimir" ToolTip="Imprimir observaciones" />
                    <br />
                </asp:View>
                <asp:View ID="viewError" runat="server">
                    <table>
                        <tr>
                            <td style="vertical-align: middle; text-align: left">
                                <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/Symbol-Stop.png" Width="100px" />
                            </td>
                            <td style="vertical-align: middle; text-align: left">
                                <asp:Label ID="lblError" runat="server" SkinID="SkinLblMsjErrores"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </asp:View>
            </asp:MultiView>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
