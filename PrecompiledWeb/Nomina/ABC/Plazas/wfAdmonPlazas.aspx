<%@ page language="VB" masterpagefile="~/MasterPageSesionIniciada.master" autoeventwireup="false" inherits="wfAdmonPlazas, App_Web_xmuq13zf" title="COBAEV - Nómina - Administrar plazas" stylesheettheme="SkinFile" maintainScrollPositionOnPostBack="true" %>

<%@ Register Src="~/WebControls/wucSearchEmps.ascx" TagName="wucBuscaEmpleados" TagPrefix="uc1" %>
<%@ Register Src="~/WebControls/wucSearchEmps2.ascx" TagName="wucSearchEmps2" TagPrefix="uc2" %>
<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress"
    TagPrefix="TP_wucUpdateProgress" %>
<%@ Register Src="../../WebControls/wucMuestraErrores.ascx" TagName="wucMuestraErrores"
    TagPrefix="uc3" %>
<%@ Register Src="~/WebControls/wucCalendario.ascx" TagName="wucCalendario" TagPrefix="uc2" %>
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
                    <asp:Panel runat="server" ID="pnlRegresar" HorizontalAlign="Left">
                        <asp:ImageButton ID="ibRegresar" runat="server" Height="40px" ImageUrl="~/Imagenes/btnRegresar.jpg"
                            ToolTip="Regresar" Width="40px" CausesValidation="False" />
                    </asp:Panel>
                    <asp:Panel runat="server" ID="pnlUltPlazaVig" GroupingText="Ultima plaza ocupada por el empleado"
                        HorizontalAlign="Left">
                        <asp:GridView ID="gvPlazasHistoria" runat="server" Height="100%" SkinID="SkinGridView"
                            Width="100%">
                            <Columns>
                                <asp:TemplateField HeaderText="IdPlaza" Visible="False">
                                    <EditItemTemplate>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblIdPlaza" runat="server" Text='<%# Bind("IdPlaza") %>'></asp:Label></ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Plaza(s)">
                                    <FooterTemplate>
                                    </FooterTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblIdEmpFuncion" runat="server" Text='<%# Bind("IdEmpFuncion") %>'
                                            ToolTip='<%# Bind("DescEmpFuncion") %>'></asp:Label><asp:Label ID="lblGuion1" runat="server"
                                                Text="-"></asp:Label><asp:Label ID="lblClavePlantel" runat="server" Text='<%# Bind("ClavePlantel") %>'
                                                    ToolTip='<%# Bind("DescPlantel") %>'></asp:Label><asp:Label ID="lblGuion2" runat="server"
                                                        Text="-"></asp:Label><asp:Label ID="lblNumEmp" runat="server" Text='<%# Bind("NumEmp") %>'></asp:Label><asp:Label
                                                            ID="lblGuion3" runat="server" Text="-"></asp:Label><asp:Label ID="lblClaveTipoNomina"
                                                                runat="server" Text='<%# Bind("ClaveTipoNomina") %>' ToolTip='<%# Bind("DescTipoNomina") %>'></asp:Label><asp:Label
                                                                    ID="lblGuion4" runat="server" Text="-"></asp:Label><asp:Label ID="lblClaveCT" runat="server"
                                                                        Text='<%# Bind("ClaveCT") %>' ToolTip='<%# Bind("NombreCT") %>'></asp:Label><asp:Label
                                                                            ID="lblGuion5" runat="server" Text="-"></asp:Label><asp:Label ID="lblClaveCategoria"
                                                                                runat="server" Text='<%# Bind("ClaveCategoria") %>' ToolTip='<%# Bind("DescCategoria") %>'></asp:Label><asp:Label
                                                                                    ID="lblGuion6" runat="server" Text="-"></asp:Label><asp:Label ID="lblHoras" runat="server"
                                                                                        Text='<%# Bind("Horas") %>'></asp:Label><asp:Label ID="lblGuion7" runat="server"
                                                                                            Text="-"></asp:Label><asp:Label ID="lblClaveFondoPresup" runat="server" Text='<%# Bind("ClaveFondoPresup") %>'
                                                                                                ToolTip='<%# Bind("DescFondoPresup") %>'></asp:Label></ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Ocup.">
                                    <ItemTemplate>
                                        <asp:Label ID="lblOcupacion" runat="server" Text='<%# Bind("AbrevTipoEmp") %>' ToolTip='<%# Bind("DescTipoEmp") %>'></asp:Label><asp:Image
                                            ID="imgInfTitular" runat="server" ImageUrl="~/Imagenes/UserInfo.jpg" /></ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="IdPlantelAdscripReal" HeaderText="IdPlantelAdscripReal"
                                    Visible="False" />
                                <asp:TemplateField HeaderText="Plantel (Adscrip. real)">
                                    <ItemTemplate>
                                        <asp:Label ID="lblClavePlantelAdscripReal" runat="server" Text='<%# Bind("ClavePlantelAdscripReal") %>'
                                            ToolTip='<%# Bind("DescPlantelAdscripReal") %>'></asp:Label></ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Esquema de pago">
                                    <ItemTemplate>
                                        <asp:Label ID="lblEsquemaPago" runat="server" Text='<%# Bind("AbrevEsquemaPago") %>'
                                            ToolTip='<%# Bind("DescEsquemaPago") %>'></asp:Label></ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Sind.">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSindicato" runat="server" Text='<%# Bind("SiglasSindicato") %>'
                                            ToolTip='<%# Bind("NombreSindicato") %>'></asp:Label></ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Función primaria">
                                    <EditItemTemplate>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblNombreFuncionPri" runat="server" SkinID="SkinLblNormal" Text=""></asp:Label></ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Función secundaria">
                                    <ItemTemplate>
                                        <asp:Label ID="lblNombreFuncionSec" runat="server" SkinID="SkinLblNormal" Text=""></asp:Label></ItemTemplate>
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
                                <asp:BoundField DataField="Término" HeaderText="Fin">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Motivo de baja">
                                    <ItemTemplate>
                                        <asp:Label ID="lblMotGralBaja" runat="server" SkinID="SkinLblNormal"></asp:Label></ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="FechaFin" DataFormatString="{0:d}" HeaderText="Fecha Fin">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:TemplateField Visible="False">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lbHistoriaPlaza" runat="server" SkinID="SkinLinkButton" ToolTip="Consultar información histórica de la plaza">Historia</asp:LinkButton></ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ibCopiarRegistro" runat="server" ImageUrl="~/Imagenes/CopiarRegistroEnabled.png"
                                            ToolTip="Utilizar registro para llenar datos de la nueva plaza." CausesValidation="False"
                                            OnClick="ibCopiarRegistro_Click" /></ItemTemplate>
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
                                <asp:TemplateField HeaderText="Clave de plaza">
                                    <EditItemTemplate>
                                        <asp:Panel ID="pnlCvePlazaE" runat="server" HorizontalAlign="Left" Visible="true">
                                            <asp:Label ID="lblCvePlazaTipoE" runat="server" SkinID="SkinLblNormal" />
                                            <asp:Label ID="lblGuion1E" runat="server" SkinID="SkinLblNormal" />
                                            <asp:Label ID="lblZonaEcoE" runat="server" SkinID="SkinLblNormal" />
                                            <asp:Label ID="lblGuion2E" runat="server" SkinID="SkinLblNormal" />
                                            <asp:Label ID="lblCvePlazaDiferenciadorE" runat="server" SkinID="SkinLblNormal" />
                                            <asp:Label ID="lblGuion3E" runat="server" />
                                            <asp:Label ID="lblCveCategoCOBACHE" runat="server" SkinID="SkinLblNormal" />
                                            <asp:Label ID="lblGuion4E" runat="server" SkinID="SkinLblNormal" />
                                            <asp:Label ID="lblHorasPlazaE" runat="server" SkinID="SkinLblNormal" />
                                            <asp:Label ID="lblGuion5E" runat="server" SkinID="SkinLblNormal" />
                                            <asp:TextBox ID="txtbxConsPlazaE" runat="server" Text="" SkinID="SkinTextBox" Columns="5"
                                                MaxLength="5" ValidationGroup="gpoGuarda"></asp:TextBox>
                                            <ajaxToolkit:FilteredTextBoxExtender ID="txtbxConsPlazaE_FTBE" runat="server" 
                                                Enabled="True" FilterType="Numbers" TargetControlID="txtbxConsPlazaE">
                                            </ajaxToolkit:FilteredTextBoxExtender>
                                            <asp:Image ID="imgPlazaCorrectaE" runat="server" ImageUrl="~/Imagenes/check.png"
                                                Visible="False" ToolTip="Plaza correcta." />
                                            <asp:Image ID="imgPlazaIncorrectaE" runat="server" ImageUrl="~/Imagenes/nocheck.png"
                                                Visible="False" ToolTip="Plaza incorrecta o inexistente." />
                                            <asp:RequiredFieldValidator ID="RFVtxtbxConsPlazaE" runat="server" ControlToValidate="txtbxConsPlazaE"
                                                Display="Dynamic" ErrorMessage="*" ToolTip="El consecutivo de la plaza es obligatorio."
                                                ValidationGroup="gpoGuarda"></asp:RequiredFieldValidator>
                                        </asp:Panel>
                                        <asp:Panel ID="pnlCvePlazaEError" runat="server" HorizontalAlign="Left" Visible="false">
                                            <asp:Image ID="imgPlazaIncorrectaEError" runat="server" ImageUrl="~/Imagenes/nocheck.png"
                                                ToolTip="Plaza incorrecta o inexistente." />
                                            <asp:Label ID="lblErrorE" runat="server" Text="Plaza incorrecta o inexistente." SkinID="SkinLblMsjErrores" />
                                        </asp:Panel>
                                    </EditItemTemplate>
                                    <InsertItemTemplate>
                                        <asp:Panel ID="pnlCvePlaza" runat="server" HorizontalAlign="Left" Visible="true">
                                            <asp:Label ID="lblCvePlazaTipo" runat="server" SkinID="SkinLblNormal" />
                                            <asp:Label ID="lblGuion1" runat="server" SkinID="SkinLblNormal" />
                                            <asp:Label ID="lblZonaEco" runat="server" SkinID="SkinLblNormal" />
                                            <asp:Label ID="lblGuion2" runat="server" SkinID="SkinLblNormal" />
                                            <asp:Label ID="lblCvePlazaDiferenciador" runat="server" SkinID="SkinLblNormal" />
                                            <asp:Label ID="lblGuion3" runat="server" SkinID="SkinLblNormal" />
                                            <asp:Label ID="lblCveCategoCOBACH" runat="server" SkinID="SkinLblNormal" />
                                            <asp:Label ID="lblGuion4" runat="server" SkinID="SkinLblNormal" />
                                            <asp:Label ID="lblHorasPlaza" runat="server" SkinID="SkinLblNormal" />
                                            <asp:Label ID="lblGuion5" runat="server" SkinID="SkinLblNormal" />
                                            <asp:TextBox ID="txtbxConsPlaza" runat="server" Text="" SkinID="SkinTextBox" Columns="5"
                                                MaxLength="5" ValidationGroup="gpoGuarda" AutoPostBack="True" 
                                                ontextchanged="txtbxConsPlaza_TextChanged"></asp:TextBox>
                                            <ajaxToolkit:FilteredTextBoxExtender ID="txtbxConsPlaza_FTBE" runat="server" 
                                                Enabled="True" FilterType="Numbers" TargetControlID="txtbxConsPlaza">
                                            </ajaxToolkit:FilteredTextBoxExtender>
                                            <asp:Image ID="imgPlazaCorrecta" runat="server" ImageUrl="~/Imagenes/check.png" Visible="False"
                                                ToolTip="Plaza correcta." />
                                            <asp:Image ID="imgPlazaIncorrecta" runat="server" ImageUrl="~/Imagenes/nocheck.png"
                                                Visible="False" ToolTip="Plaza incorrecta o inexistente." />
                                            <asp:RequiredFieldValidator ID="RFVtxtbxConsPlaza" runat="server" ControlToValidate="txtbxConsPlaza"
                                                Display="Dynamic" ErrorMessage="*" ToolTip="El consecutivo de la plaza es obligatorio."
                                                ValidationGroup="gpoGuarda"></asp:RequiredFieldValidator>
                                        </asp:Panel>
                                        <asp:Panel ID="pnlCvePlazaError" runat="server" HorizontalAlign="Left" Visible="false">
                                            <asp:Image ID="imgPlazaIncorrectaError" runat="server" ImageUrl="~/Imagenes/nocheck.png"
                                                ToolTip="Plaza incorrecta o inexistente." />
                                            <asp:Label ID="lblError" runat="server" Text="Plaza incorrecta o inexistente." SkinID="SkinLblMsjErrores" />
                                        </asp:Panel>
                                    </InsertItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:TemplateField>
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
                                        <asp:Label ID="lblZECentroAdscripFisicaE" runat="server" SkinID="SkinLblDatos9pt"
                                            Text="Label"></asp:Label></EditItemTemplate>
                                    <InsertItemTemplate>
                                        <asp:DropDownList ID="ddlPlanteles" runat="server" SkinID="SkinDropDownList" AutoPostBack="True"
                                            OnSelectedIndexChanged="ddlPlanteles_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <asp:Label ID="lblZECentroAdscripFisica" runat="server" SkinID="SkinLblDatos9pt"
                                            Text="Label"></asp:Label></InsertItemTemplate>
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
                                        <asp:Label ID="lblZEPlantelAdscripRealE" runat="server" SkinID="SkinLblDatos9pt"
                                            Text="Label"></asp:Label></EditItemTemplate>
                                    <InsertItemTemplate>
                                        <asp:DropDownList ID="ddlCTAdscipReal" runat="server" SkinID="SkinDropDownList" AutoPostBack="True"
                                            OnSelectedIndexChanged="ddlCTAdscipReal_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <asp:Label ID="lblZEPlantelAdscripReal" runat="server" SkinID="SkinLblDatos9pt" Text="Label"></asp:Label></InsertItemTemplate>
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
                                    <HeaderStyle HorizontalAlign="Left" Wrap="False" />
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
                                        <asp:Label ID="LblEmpTitularSDE" runat="server" SkinID="SkinLblNormal" Text="(SIN DEFINIR)"></asp:Label></EditItemTemplate>
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
                                        <asp:DropDownList ID="ddlQuincenaInicio" runat="server" SkinID="SkinDropDownList"
                                            Enabled="false">
                                        </asp:DropDownList>
                                    </EditItemTemplate>
                                    <InsertItemTemplate>
                                        <asp:DropDownList ID="ddlQuincenaInicio" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlQuincenaInicio_SelectedIndexChanged"
                                            ValidationGroup="gpoGuarda" SkinID="SkinDropDownList" Enabled="false">
                                        </asp:DropDownList>
                                        <asp:TextBox ID="txtbxFechaIni" runat="server" MaxLength="10" SkinID="SkinTextBox"
                                            ValidationGroup="gpoGuarda" Enabled="False"></asp:TextBox>
                                        <asp:ImageButton ID="ibFechaIni" runat="server" ImageUrl="~/Imagenes/ico_calendar.png"
                                            CausesValidation="False" ValidationGroup="gpoGuarda" ImageAlign="AbsMiddle" OnClick="ibFechaIni_Click" />
                                        <asp:RequiredFieldValidator ID="txtbxFechaIni_RFV" runat="server" ControlToValidate="txtbxFechaIni"
                                            Display="Dynamic" ErrorMessage="La fecha inicial del movimiento de personal es obligatoria."
                                            ValidationGroup="gpoGuarda" ToolTip="La fecha inicial del movimiento de personal es obligatoria.">*</asp:RequiredFieldValidator>
                                        <asp:CompareValidator ID="txtbxFechaIni_CV" runat="server" ControlToValidate="txtbxFechaIni"
                                            Display="Dynamic" ErrorMessage="La fecha inicial del movimiento de personal es incorrecta."
                                            Operator="DataTypeCheck" Type="Date" ValidationGroup="gpoGuarda" ToolTip="La fecha inicial del movimiento de personal es incorrecta.">*</asp:CompareValidator>
                                        <asp:Panel ID="pnlFechIni" runat="server" Visible="false">
                                            <uc2:wucCalendario ID="wucCalendarFechIni" runat="server" />
                                        </asp:Panel>
                                    </InsertItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" Wrap="False" VerticalAlign="Middle" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="T&#233;rmino">
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="ddlQuincenaTermino" runat="server" SkinID="SkinDropDownList"
                                            Enabled="false">
                                        </asp:DropDownList>
                                    </EditItemTemplate>
                                    <InsertItemTemplate>
                                        <asp:DropDownList ID="ddlQuincenaTermino" runat="server" SkinID="SkinDropDownList"
                                            AutoPostBack="True" OnSelectedIndexChanged="ddlQuincenaTermino_SelectedIndexChanged"
                                            ValidationGroup="gpoGuarda" Enabled="false">
                                        </asp:DropDownList>
                                        <asp:CompareValidator ID="CVVigencia" runat="server" ControlToCompare="ddlQuincenaInicio"
                                            ControlToValidate="ddlQuincenaTermino" Display="Dynamic" ErrorMessage="*" Operator="GreaterThanEqual"
                                            ToolTip="Vigencia incorrecta." ValidationGroup="gpoGuarda">*</asp:CompareValidator>
                                        <asp:TextBox ID="txtbxFechaFin" runat="server" SkinID="SkinTextBox" MaxLength="10"
                                            ValidationGroup="gpoGuarda" Enabled="False"></asp:TextBox>
                                        <asp:ImageButton ID="ibFechaFin" runat="server" ImageUrl="~/Imagenes/ico_calendar.png"
                                            CausesValidation="False" ValidationGroup="gpoGuarda" ImageAlign="AbsMiddle" OnClick="ibFechaFin_Click" />
                                        <asp:RequiredFieldValidator ID="txtbxFechaFin_RFV" runat="server" ControlToValidate="txtbxFechaFin"
                                            Display="Dynamic" ErrorMessage="La fecha final del movimiento de personal es obligatoria."
                                            ToolTip="La fecha final del movimiento de personal es obligatoria." ValidationGroup="GrupoGuarda">*</asp:RequiredFieldValidator>
                                        <asp:CompareValidator ID="txtbxFechaFin_CV" runat="server" ControlToValidate="txtbxFechaFin"
                                            Display="Dynamic" ErrorMessage="La fecha final del movimiento de personal es incorrecta."
                                            Operator="DataTypeCheck" ToolTip="La fecha final del movimiento de personal es incorrecta."
                                            Type="Date" ValidationGroup="gpoGuarda">*</asp:CompareValidator>
                                        <asp:CompareValidator ID="txtbxFechaFin_CV2" runat="server" ControlToCompare="txtbxFechaIni"
                                            ControlToValidate="txtbxFechaFin" Display="Dynamic" ErrorMessage="La fecha final del movimiento de personal debe ser mayor o igual que la fecha inicial."
                                            Operator="GreaterThanEqual" ToolTip="La fecha final del movimiento de personal debe ser mayor o igual que la fecha inicial."
                                            Type="Date" ValidationGroup="gpoGuarda">*</asp:CompareValidator>
                                        <asp:Panel ID="pnlFechFin" runat="server" Visible="false">
                                            <uc2:wucCalendario ID="wucCalendarFechFin" runat="server" />
                                        </asp:Panel>
                                        <asp:CheckBox ID="chkbxVigFinAbierta" runat="server" SkinID="SkinCheckBox" Text="Vigencia final abierta"
                                            AutoPostBack="True" OnCheckedChanged="chkbxVigFinAbierta_CheckedChanged" />
                                    </InsertItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Motivo de baja">
                                    <InsertItemTemplate>
                                        <asp:DropDownList ID="ddlMotivosDeBaja" runat="server" SkinID="SkinDropDownList"
                                            AutoPostBack="True" OnSelectedIndexChanged="ddlMotivosDeBaja_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <br />
                                        <asp:Label ID="lblFechaBajaISSSTE" runat="server" SkinID="SkinLbl9pt" Text="Fecha de baja ante ISSSTE:"
                                            Visible="False"></asp:Label><asp:TextBox ID="txtbxFechaBajaISSSTE" runat="server"
                                                SkinID="SkinTextBox" Visible="False" Width="100px" ValidationGroup="gpoGuarda"
                                                MaxLength="10"></asp:TextBox><ajaxToolkit:CalendarExtender ID="txtbxFechaBajaISSSTE_CE"
                                                    runat="server" Enabled="True" TargetControlID="txtbxFechaBajaISSSTE">
                                                </ajaxToolkit:CalendarExtender>
                                        <asp:CompareValidator ID="txtbxFechaBajaISSSTE_CV" runat="server" ControlToValidate="txtbxFechaBajaISSSTE"
                                            Display="Dynamic" Enabled="False" ErrorMessage="*" Operator="DataTypeCheck" ToolTip="Fecha incorrecta."
                                            Type="Date" ValidationGroup="gpoGuarda">*</asp:CompareValidator></InsertItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Cadena">
                                    <InsertItemTemplate>
                                        <asp:DropDownList ID="ddlCadenas" runat="server" SkinID="SkinDropDownList" Enabled="false">
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
                                <asp:TemplateField HeaderText="Esquema de pago">
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="ddlEsquemaPagoE" runat="server" SkinID="SkinDropDownList">
                                        </asp:DropDownList>
                                    </EditItemTemplate>
                                    <InsertItemTemplate>
                                        <asp:DropDownList ID="ddlEsquemaPago" runat="server" SkinID="SkinDropDownList">
                                        </asp:DropDownList>
                                    </InsertItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Trámite:">
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="ddlTramitesE" runat="server" SkinID="SkinDropDownList" Enabled="false">
                                        </asp:DropDownList>
                                    </EditItemTemplate>
                                    <InsertItemTemplate>
                                        <asp:DropDownList ID="ddlTramites" runat="server" SkinID="SkinDropDownList" AutoPostBack="True"
                                            OnSelectedIndexChanged="ddlTramites_SelectedIndexChanged" Enabled="false">
                                        </asp:DropDownList>
                                    </InsertItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Motivo que da origen al trámite:">
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="ddlMotivosE" runat="server" SkinID="SkinDropDownList" Enabled="false">
                                        </asp:DropDownList>
                                    </EditItemTemplate>
                                    <InsertItemTemplate>
                                        <asp:DropDownList ID="ddlMotivos" runat="server" SkinID="SkinDropDownList" Enabled="false">
                                        </asp:DropDownList>
                                    </InsertItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:TemplateField>
                            </Fields>
                        </asp:DetailsView>
                        <asp:DetailsView ID="dvBotones" runat="server" AutoGenerateRows="False" SkinID="SkinDetailsView"
                            DefaultMode="Insert" Width="100%">
                            <FieldHeaderStyle Width="250px" Wrap="True" />
                            <Fields>
                                <asp:TemplateField ShowHeader="False" Visible="False">
                                    <EditItemTemplate>
                                        <asp:Button ID="btnUpdTitularPlaza" runat="server" SkinID="SkinBoton" Text="Actualizar titular"
                                            ToolTip="Actualizar información del titular de la plaza" 
                                            OnClick="btnUpdTitularPlaza_Click" /><ajaxToolkit:ConfirmButtonExtender
                                                ID="CBEbtnUpdTitularPlaza" runat="server" ConfirmText="¿Realmente desea actualizar la información del titular de la plaza?"
                                                TargetControlID="btnUpdTitularPlaza">
                                            </ajaxToolkit:ConfirmButtonExtender>
                                    </EditItemTemplate>
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField ShowHeader="False">
                                    <EditItemTemplate>
                                        <asp:Button ID="btnCancelar" runat="server" SkinID="SkinBoton" Text="Cancelar" CausesValidation="false" />
                                        <asp:Button ID="btnGuardar" runat="server" SkinID="SkinBoton" Text="Guardar" ToolTip="Guardar cambios"
                                            OnClick="btnGuardar_Click" ValidationGroup="gpoGuarda" CssClass="btnOnlyMarginLeft"
                                            Visible="false" />
                                        <ajaxToolkit:ConfirmButtonExtender ID="CBE" runat="server" TargetControlID="btnGuardar"
                                            ConfirmText="¿Está seguro de guardar los cambios realizados?">
                                        </ajaxToolkit:ConfirmButtonExtender>
                                        <asp:Button ID="btnModificar" runat="server" SkinID="SkinBoton" 
                                            Text="Modificar" ToolTip="Modificar datos del movimiento de personal"
                                            ValidationGroup="gpoGuarda" CssClass="btnOnlyMarginLeft" Visible="false" 
                                            CausesValidation="false" OnClick="btnModificar_Click" />
                                        <asp:Button ID="btnValidar" runat="server" SkinID="SkinBoton" Text="Validar" ToolTip="Validar datos del movimiento de personal"
                                            ValidationGroup="gpoGuarda" CssClass="btnOnlyMarginLeft" OnClick="btnValidar_Click" />
                                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowSummary="False"
                                            ValidationGroup="gpoGuarda" />
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
                                &nbsp;<asp:LinkButton ID="lbOtraOperacion0" runat="server" PostBackUrl="~/Consultas/Empleados/frmHistoriaPlazas.aspx?TipoOperacion=4"
                                    SkinID="SkinLinkButton">Continuar con otra operación en el sistema</asp:LinkButton>
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
                    <uc3:wucMuestraErrores ID="wucMuestraErrores1" runat="server" />
                    <div id="divBotonesErrores">
                        <p class="submitButton">
                            <asp:Button ID="btnReintentarOp" runat="server" Text="Reintentar operación" ToolTip="" />
                            <asp:Button ID="btnCancelarOp" runat="server" Text="Continuar con otra operación en el sistema"
                                ToolTip="" PostBackUrl="~/Consultas/Empleados/frmHistoriaPlazas.aspx?TipoOperacion=4" />
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
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
