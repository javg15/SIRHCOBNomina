<%@ page language="VB" masterpagefile="~/MasterPageSesionIniciada.master" autoeventwireup="false" inherits="AdministracionPlazasAnt, App_Web_xmuq13zf" title="COBAEV - Nómina - Administrar plazas" stylesheettheme="SkinFile" maintainScrollPositionOnPostBack="true" %>

<%@ Register Src="~/WebControls/wucSearchEmps.ascx" TagName="wucBuscaEmpleados" TagPrefix="uc1" %>
<%@ Register Src="~/WebControls/wucSearchEmps2.ascx" TagName="wucSearchEmps2" TagPrefix="uc2" %>
<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress" TagPrefix="TP_wucUpdateProgress" %>
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
        <asp:Panel runat="server" ID="pnlUltPlazaVig" GroupingText="Ultima plaza vigente del empleado" HorizontalAlign="Left">

            <asp:GridView ID="gvPlazasHistoria" runat="server" Height="100%" 
                SkinID="SkinGridView"  Width="100%">
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
                            <asp:Label ID="lblIdEmpFuncion" runat="server" Text='<%# Bind("IdEmpFuncion") %>' ToolTip='<%# Bind("DescEmpFuncion") %>'></asp:Label>
                            <asp:Label ID="lblGuion1" runat="server" Text="-"></asp:Label>
                            <asp:Label ID="lblClavePlantel" runat="server"  Text='<%# Bind("ClavePlantel") %>' ToolTip='<%# Bind("DescPlantel") %>'></asp:Label>
                            <asp:Label ID="lblGuion2" runat="server" Text="-"></asp:Label>
                            <asp:Label ID="lblNumEmp" runat="server" Text='<%# Bind("NumEmp") %>'></asp:Label>
                            <asp:Label ID="lblGuion3" runat="server" Text="-"></asp:Label>
                            <asp:Label ID="lblClaveTipoNomina" runat="server"  Text='<%# Bind("ClaveTipoNomina") %>' ToolTip='<%# Bind("DescTipoNomina") %>'></asp:Label>
                            <asp:Label ID="lblGuion4" runat="server" Text="-"></asp:Label>
                            <asp:Label ID="lblClaveCT" runat="server"  Text='<%# Bind("ClaveCT") %>' ToolTip='<%# Bind("NombreCT") %>'></asp:Label>
                            <asp:Label ID="lblGuion5" runat="server" Text="-"></asp:Label>
                            <asp:Label ID="lblClaveCategoria" runat="server"  Text='<%# Bind("ClaveCategoria") %>' ToolTip='<%# Bind("DescCategoria") %>'></asp:Label>
                            <asp:Label ID="lblGuion6" runat="server" Text="-"></asp:Label>
                            <asp:Label ID="lblHoras" runat="server"  Text='<%# Bind("Horas") %>'></asp:Label>
                            <asp:Label ID="lblGuion7" runat="server" Text="-"></asp:Label>
                            <asp:Label ID="lblClaveFondoPresup" runat="server"  Text='<%# Bind("ClaveFondoPresup") %>' ToolTip='<%# Bind("DescFondoPresup") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Wrap="false" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Ocup.">
                        <ItemTemplate>
                            <asp:Label ID="lblOcupacion" runat="server" Text='<%# Bind("AbrevTipoEmp") %>' 
                                ToolTip='<%# Bind("DescTipoEmp") %>'></asp:Label>
                            <asp:Image ID="imgInfTitular" runat="server" 
                                ImageUrl="~/Imagenes/UserInfo.jpg" />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="IdPlantelAdscripReal" HeaderText="IdPlantelAdscripReal" Visible="False" />
                    <asp:TemplateField HeaderText="Plantel (Adscrip. real)">
                        <ItemTemplate>
                            <asp:Label ID="lblClavePlantelAdscripReal" runat="server" 
                                Text='<%# Bind("ClavePlantelAdscripReal") %>' ToolTip='<%# Bind("DescPlantelAdscripReal") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Sind.">
                        <ItemTemplate>
                            <asp:Label ID="lblSindicato" runat="server" 
                                Text='<%# Bind("SiglasSindicato") %>' ToolTip='<%# Bind("NombreSindicato") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Función primaria">
                        <EditItemTemplate>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblNombreFuncionPri" runat="server" SkinID="SkinLblNormal" 
                                Text=""></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Función secundaria">
                        <ItemTemplate>
                            <asp:Label ID="lblNombreFuncionSec" runat="server" SkinID="SkinLblNormal" 
                                Text=""></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="IdTipoSemestre" HeaderText="IdTipoSemestre" 
                        Visible="False" />
                    <asp:BoundField DataField="TipoSemestre" HeaderText="Vig. en sem.">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" Width="30px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Inicio" HeaderText="Inicio">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Término" HeaderText="Fin">
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
                            <asp:LinkButton ID="lbHistoriaPlaza" runat="server" SkinID="SkinLinkButton" 
                                ToolTip="Consultar información histórica de la plaza">Historia</asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField Visible="false">
                        <ItemTemplate>
                            <asp:ImageButton ID="ibDetalles" runat="server" 
                                ImageUrl="~/Imagenes/Detalles.png" 
                                ToolTip="Ver definición de la clave presupuestal" />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField Visible="false">
                        <ItemTemplate>
                            <asp:ImageButton ID="ibWarning" runat="server" 
                                ImageUrl="~/Imagenes/Warning1.png" 
                                ToolTip="Haga click para visualizar un listado de observaciones sobre la plaza." />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                </Columns>
                <EmptyDataRowStyle HorizontalAlign="Left" />
                <EmptyDataTemplate>
                    <asp:Label ID="Label1" runat="server" Text="El empleado nunca ha tenido plaza."></asp:Label>                   
                </EmptyDataTemplate>
            </asp:GridView>

        </asp:Panel>
        <asp:Panel ID="pnlInfPlaza" runat="server" GroupingText="Información de la plaza asignada o por asignar">
            <asp:DetailsView ID="dvPlaza" runat="server" AutoGenerateRows="False" SkinID="SkinDetailsView"
                DefaultMode="Insert" Width="100%">
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
                        <HeaderStyle HorizontalAlign="Left" Wrap="False" />
                        <ItemStyle HorizontalAlign="Left" Wrap="False" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Centro de Adscripción<br />(Ubicación física del empleado)">
                        <EditItemTemplate>
                            <asp:DropDownList ID="ddlPlantelesE" runat="server" AutoPostBack="True" SkinID="SkinDropDownList"
                                OnSelectedIndexChanged="ddlPlanteles_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:Label ID="lblZECentroAdscripFisicaE" runat="server" 
                                SkinID="SkinLblDatos9pt" Text="Label"></asp:Label>
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            <asp:DropDownList ID="ddlPlanteles" runat="server" SkinID="SkinDropDownList" AutoPostBack="True"
                                OnSelectedIndexChanged="ddlPlanteles_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:Label ID="lblZECentroAdscripFisica" runat="server" 
                                SkinID="SkinLblDatos9pt" Text="Label"></asp:Label>
                        </InsertItemTemplate>
                        <HeaderStyle HorizontalAlign="Left" Wrap="False" />
                        <ItemStyle HorizontalAlign="Left" Wrap="False" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Departamento del Centro de Adscripción<br />(Ubicación física del empleado)">
                        <EditItemTemplate>
                                    <asp:DropDownList ID="ddlCentrosDeTrabajoE" runat="server" SkinID="SkinDropDownList">
                                    </asp:DropDownList>
                        </EditItemTemplate>
                        <InsertItemTemplate>
                                    <asp:DropDownList ID="ddlCentrosDeTrabajo" runat="server" SkinID="SkinDropDownList">
                                    </asp:DropDownList>
                        </InsertItemTemplate>
                        <HeaderStyle HorizontalAlign="Left" Wrap="False" />
                        <ItemStyle HorizontalAlign="Left" Wrap="False" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Centro de Adscripción al que pertenece la Plaza<br />(Utilizado para pago)">
                        <EditItemTemplate>
                            <asp:DropDownList ID="ddlCTAdscipRealE" runat="server" SkinID="SkinDropDownList">
                            </asp:DropDownList>
                            <asp:Label ID="lblZEPlantelAdscripRealE" runat="server" 
                                SkinID="SkinLblDatos9pt" Text="Label"></asp:Label>
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            <asp:DropDownList ID="ddlCTAdscipReal" runat="server" SkinID="SkinDropDownList" 
                                AutoPostBack="True" 
                                onselectedindexchanged="ddlCTAdscipReal_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:Label ID="lblZEPlantelAdscripReal" runat="server" SkinID="SkinLblDatos9pt" 
                                Text="Label"></asp:Label>
                        </InsertItemTemplate>
                        <HeaderStyle HorizontalAlign="Left" Wrap="False" />
                        <ItemStyle HorizontalAlign="Left" Wrap="False" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="N&#243;mina">
                        <EditItemTemplate>
                                    <asp:DropDownList ID="ddlTiposDeNominasE" runat="server" SkinID="SkinDropDownList">
                                    </asp:DropDownList>
                        </EditItemTemplate>
                        <InsertItemTemplate>
                                    <asp:DropDownList ID="ddlTiposDeNominas" runat="server" SkinID="SkinDropDownList">
                                    </asp:DropDownList>
                        </InsertItemTemplate>
                        <HeaderStyle HorizontalAlign="Left" Wrap="False" />
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
                        <HeaderStyle  HorizontalAlign="Left" Wrap="False" />
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
                        <HeaderStyle HorizontalAlign="Left" Wrap="False" />
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
                                    <asp:CheckBox ID="ChckBxTratarComoBase" runat="server" SkinID="SkinCheckBox" Text="Tratar como BASE plaza y carga horaria" />
                                    <asp:CheckBox ID="chkbxInterinoPuro" runat="server" SkinID="SkinCheckBox" Text="¿Interino puro?" />
                        </InsertItemTemplate>
                        <HeaderStyle HorizontalAlign="Left" Wrap="False" />
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
                        <HeaderStyle HorizontalAlign="Left" Wrap="False" />
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
                        <HeaderStyle HorizontalAlign="Left" Wrap="False" />
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
                        <HeaderStyle HorizontalAlign="Left" Wrap="False" />
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
                        <HeaderStyle HorizontalAlign="Left" Wrap="False" />
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
                        <HeaderStyle HorizontalAlign="Left" Wrap="False" />
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
                                        Operator="GreaterThanEqual" ToolTip="Vigencia incorrecta." 
                                        ValidationGroup="gpoGuarda">*</asp:CompareValidator>
                        </InsertItemTemplate>
                        <HeaderStyle HorizontalAlign="Left" Wrap="False" />
                        <ItemStyle HorizontalAlign="Left" Wrap="False" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Motivo de baja">
                        <InsertItemTemplate>
                                    <asp:DropDownList ID="ddlMotivosDeBaja" runat="server" SkinID="SkinDropDownList"
                                        AutoPostBack="True" 
                                        onselectedindexchanged="ddlMotivosDeBaja_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <br />
                                    <asp:Label ID="lblFechaBajaISSSTE" runat="server" SkinID="SkinLbl9pt" 
                                        Text="Fecha de baja ante ISSSTE:" Visible="False"></asp:Label>
                                    <asp:TextBox ID="txtbxFechaBajaISSSTE" runat="server" SkinID="SkinTextBox" 
                                         Visible="False" Width="100px" ValidationGroup="gpoGuarda" MaxLength="10"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="txtbxFechaBajaISSSTE_CE" runat="server" 
                                        Enabled="True" TargetControlID="txtbxFechaBajaISSSTE">
                                    </ajaxToolkit:CalendarExtender>
                                    <asp:CompareValidator ID="txtbxFechaBajaISSSTE_CV" runat="server" 
                                        ControlToValidate="txtbxFechaBajaISSSTE" Display="Dynamic" Enabled="False" 
                                        ErrorMessage="Fecha de baja incorrecta." Operator="DataTypeCheck" 
                                        ToolTip="Fecha incorrecta." Type="Date" ValidationGroup="gpoGuarda">*</asp:CompareValidator>
                        </InsertItemTemplate>
                        <HeaderStyle HorizontalAlign="Left" Wrap="False" />
                        <ItemStyle HorizontalAlign="Left" Wrap="False" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Cadena">
                        <InsertItemTemplate>
                                    <asp:DropDownList ID="ddlCadenas" runat="server" SkinID="SkinDropDownList">
                                    </asp:DropDownList>
                        </InsertItemTemplate>
                        <HeaderStyle HorizontalAlign="Left" Wrap="False" />
                        <ItemStyle HorizontalAlign="Left" Wrap="False" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Vigente en semestre(s)">
                        <InsertItemTemplate>
                                    <asp:DropDownList ID="ddlTiposDeSemestres" runat="server" SkinID="SkinDropDownList">
                                    </asp:DropDownList>
                        </InsertItemTemplate>
                        <HeaderStyle HorizontalAlign="Left" Wrap="False" />
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
                            <asp:Button ID="btnCancelar" runat="server" SkinID="SkinBoton" Text="Cancelar" CausesValidation="false"/>
                            <asp:Button ID="btnGuardar" runat="server" SkinID="SkinBoton" Text="Guardar" ToolTip="Guardar cambios"
                                OnClick="btnGuardar_Click" ValidationGroup="gpoGuarda" /><ajaxToolkit:ConfirmButtonExtender ID="CBE" runat="server"
                                    TargetControlID="btnGuardar" ConfirmText="¿Está seguro de guardar los cambios realizados?">
                                </ajaxToolkit:ConfirmButtonExtender>
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                                ShowSummary="False" ValidationGroup="gpoGuarda" />
                        </EditItemTemplate>
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:TemplateField>
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
        </asp:View>
    </asp:MultiView>
    </ContentTemplate>
</asp:UpdatePanel>
</asp:Content>
