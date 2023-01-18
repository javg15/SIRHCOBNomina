<%@ page language="VB" masterpagefile="~/MasterPageSesionIniciada.master" autoeventwireup="false" inherits="CopyAdministracionPlazasDel, App_Web_xmuq13zf" title="COBAEV - Nómina - Administrar plazas" stylesheettheme="SkinFile" maintainScrollPositionOnPostBack="true" %>

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
    <uc1:wucBuscaEmpleados ID="WucBuscaEmpleados1" runat="server" EnableViewState="true" />
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="viewPlazas" runat="server">

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
    </ContentTemplate>
</asp:UpdatePanel>
</asp:Content>
