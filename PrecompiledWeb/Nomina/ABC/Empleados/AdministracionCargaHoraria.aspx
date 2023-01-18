<%@ page language="VB" masterpagefile="~/MasterPageSesionIniciada.master" autoeventwireup="false" inherits="AdministracionCargaHoraria, App_Web_afkwdrmm" title="COBAEV - Nómina - Administrar carga horaria" stylesheettheme="SkinFile" maintainscrollpositiononpostback="true" %>

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
                    Sistema de nómina: Administrar carga horaria
                </h2>
            </td>
        </tr>
    </table>
    <asp:UpdatePanel ID="UPMain" runat="server">
        <ContentTemplate>
            <uc1:wucBuscaEmpleados ID="WucBuscaEmpleados1" runat="server" EnableViewState="true" />
            <asp:MultiView ID="MultiView1" runat="server">
                <asp:View ID="viewHoras" runat="server">
                    <asp:DetailsView ID="dvCargaHoraria" runat="server" AutoGenerateRows="False" SkinID="SkinDetailsView"
                        DefaultMode="Edit" Width="100%">
                        <Fields>
                            <asp:TemplateField HeaderText="Plazas" Visible="false">
                                <EditItemTemplate>
                                    <asp:DropDownList ID="ddlPlazas" runat="server" SkinID="SkinDropDownList" Enabled="False">
                                    </asp:DropDownList>
                                </EditItemTemplate>
                                <InsertItemTemplate>
                                    <asp:DropDownList ID="ddlPlazas" runat="server" SkinID="SkinDropDownList" Enabled="False">
                                    </asp:DropDownList>
                                </InsertItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Plantel">
                                <EditItemTemplate>
                                    <asp:DropDownList ID="ddlPlanteles" runat="server" OnSelectedIndexChanged="ddlMaterias_SelectedIndexChanged"
                                        SkinID="SkinDropDownList">
                                    </asp:DropDownList>
                                </EditItemTemplate>
                                <InsertItemTemplate>
                                    <asp:DropDownList ID="ddlPlantelesI" runat="server" OnSelectedIndexChanged="ddlMaterias_SelectedIndexChanged"
                                        SkinID="SkinDropDownList">
                                    </asp:DropDownList>
                                </InsertItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Materia">
                                <EditItemTemplate>
                                    <asp:DropDownList ID="ddlMaterias" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlMaterias_SelectedIndexChanged"
                                        SkinID="SkinDropDownList" Width="100%">
                                    </asp:DropDownList>
                                </EditItemTemplate>
                                <InsertItemTemplate>
                                    <asp:DropDownList ID="ddlMateriasI" runat="server" OnSelectedIndexChanged="ddlMaterias_SelectedIndexChanged"
                                        SkinID="SkinDropDownList" AutoPostBack="True" Width="100%">
                                    </asp:DropDownList>
                                </InsertItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Horas">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtbxCantidad" runat="server" SkinID="SkinTextBox" Width="50px"
                                        Text='<%# Bind("Cantidad") %>' ReadOnly="True" MaxLength="2"></asp:TextBox>
                                        <asp:RequiredFieldValidator
                                            ID="rfvCantidad" runat="server" ControlToValidate="txtbxCantidad" Display="Dynamic"
                                            ErrorMessage="*" ToolTip="Campo requerido: Cantidad de horas de la materia."
                                             ValidationGroup="GpoValidaciones1"
                                            ></asp:RequiredFieldValidator>
                                            <asp:RangeValidator ID="rvCantidad"
                                                runat="server" ControlToValidate="txtbxCantidad" ErrorMessage="*"
                                                ToolTip="Escriba un valor entre 1 y 40" 
                                                MaximumValue="40" MinimumValue="1" Display="Dynamic" Type="Integer"
                                                ValidationGroup="GpoValidaciones1">
                                                </asp:RangeValidator>
                                                <ajaxToolkit:FilteredTextBoxExtender
                                                    ID="FTBECantidad" runat="server" FilterType="Numbers" TargetControlID="txtbxCantidad">
                                                </ajaxToolkit:FilteredTextBoxExtender>
                                    <asp:HiddenField ID="hfCantidad" runat="server" Value='<%# Bind("Cantidad") %>'>
                                    </asp:HiddenField>
                                </EditItemTemplate>
                                <InsertItemTemplate>
                                    <asp:TextBox ID="txtbxCantidadIns" runat="server" SkinID="SkinTextBox" Width="50px"
                                        ReadOnly="True" MaxLength="2">
                                        </asp:TextBox><asp:RequiredFieldValidator ID="rfvCantidadI"
                                            runat="server" ControlToValidate="txtbxCantidadIns" Display="Dynamic" ErrorMessage="*"
                                             ToolTip="Campo requerido: Cantidad de horas de la materia." ValidationGroup="GpoValidaciones1">
                                         </asp:RequiredFieldValidator><asp:RangeValidator
                                                ID="rvCantidadI" runat="server" ControlToValidate="txtbxCantidadIns" 
                                                ErrorMessage="*" ToolTip="Escriba un valor entre 1 y 40" 
                                                MaximumValue="40" MinimumValue="1" Display="Dynamic" Type="Integer" ValidationGroup="GpoValidaciones1">
                                                </asp:RangeValidator>
                                                <ajaxToolkit:FilteredTextBoxExtender
                                                    ID="FTBECantidadI" runat="server" FilterType="Numbers" TargetControlID="txtbxCantidadIns">
                                                </ajaxToolkit:FilteredTextBoxExtender>
                                    <asp:HiddenField ID="hfCantidadIns" runat="server"></asp:HiddenField>
                                </InsertItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Estatus hora">
                                <EditItemTemplate>
                                    <asp:DropDownList ID="ddlEstatus" runat="server" SkinID="SkinDropDownList">
                                    </asp:DropDownList>
                                </EditItemTemplate>
                                <InsertItemTemplate>
                                    <asp:DropDownList ID="ddlEstatus" runat="server" SkinID="SkinDropDownList">
                                    </asp:DropDownList>
                                </InsertItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Categoría">
                                <EditItemTemplate>
                                    <asp:DropDownList ID="ddlTipoHoraE" runat="server" SkinID="SkinDropDownList">
                                    </asp:DropDownList>
                                </EditItemTemplate>
                                <InsertItemTemplate>
                                    <asp:DropDownList ID="ddlTipoHoraI" runat="server" SkinID="SkinDropDownList">
                                    </asp:DropDownList>
                                </InsertItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Nombramiento">
                                <EditItemTemplate>
                                    <asp:DropDownList ID="ddlNombramientoE" runat="server" SkinID="SkinDropDownList"
                                        AutoPostBack="True" OnSelectedIndexChanged="ddlNombramientoE_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </EditItemTemplate>
                                <InsertItemTemplate>
                                    <asp:DropDownList ID="ddlNombramientoI" runat="server" SkinID="SkinDropDownList"
                                        AutoPostBack="True" OnSelectedIndexChanged="ddlNombramientoE_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </InsertItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
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
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Titular de las horas">
                                <EditItemTemplate>
                                    <uc2:wucSearchEmps2 ID="WucBuscaEmpleados2_E" runat="server" Visible="false" />
                                    <asp:Label ID="LblEmpTitularSDE" runat="server" SkinID="SkinLblNormal" Text="(SIN DEFINIR)"></asp:Label></EditItemTemplate>
                                <InsertItemTemplate>
                                    <uc2:wucSearchEmps2 ID="WucBuscaEmpleados2_I" runat="server" Visible="false" />
                                    &nbsp;<asp:Label ID="LblEmpTitularSDI" runat="server" SkinID="SkinLblNormal" Text="(SIN DEFINIR)"></asp:Label></InsertItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" Wrap="False" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Grupo">
                                <EditItemTemplate>
                                    <asp:DropDownList ID="ddlGrupos" runat="server" SkinID="SkinDropDownList">
                                    </asp:DropDownList>
                                </EditItemTemplate>
                                <InsertItemTemplate>
                                    <asp:DropDownList ID="ddlGruposI" runat="server" SkinID="SkinDropDownList">
                                    </asp:DropDownList>
                                </InsertItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Semestre de inicio">
                                <EditItemTemplate>
                                    <asp:DropDownList ID="ddlSemestres" runat="server" SkinID="SkinDropDownList">
                                    </asp:DropDownList>
                                </EditItemTemplate>
                                <InsertItemTemplate>
                                    <asp:DropDownList ID="ddlSemestres" runat="server" SkinID="SkinDropDownList">
                                    </asp:DropDownList>
                                </InsertItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Quincena inicial">
                                <EditItemTemplate>
                                    <asp:DropDownList ID="ddlQnaIni_E" runat="server" SkinID="SkinDropDownList" AutoPostBack="True"
                                        OnSelectedIndexChanged="ddlQnaIni_E_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </EditItemTemplate>
                                <InsertItemTemplate>
                                    <asp:DropDownList ID="ddlQnaIni_I" runat="server" SkinID="SkinDropDownList" AutoPostBack="True"
                                        OnSelectedIndexChanged="ddlQnaIni_I_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </InsertItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Fecha inicio" Visible="false">
                                <EditItemTemplate>
                                    <asp:DropDownList ID="ddlFchIni_E" runat="server" SkinID="SkinDropDownList" Enabled="False">
                                    </asp:DropDownList>
                                </EditItemTemplate>
                                <InsertItemTemplate>
                                    <asp:DropDownList ID="ddlFchIni_I" runat="server" SkinID="SkinDropDownList" Enabled="False">
                                    </asp:DropDownList>
                                </InsertItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Qincena final">
                                <EditItemTemplate>
                                    <asp:DropDownList ID="ddlQnaFin_E" runat="server" SkinID="SkinDropDownList" AutoPostBack="True"
                                        OnSelectedIndexChanged="ddlQnaFin_E_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:CheckBox ID="chbLimitarASemAntMismoTipo_E" runat="server" AutoPostBack="True"
                                        OnCheckedChanged="chbLimitarASemAntMismoTipo_E_CheckedChanged" SkinID="SkinCheckBox"
                                        Text="Limitar automáticamente" /></EditItemTemplate>
                                <InsertItemTemplate>
                                    <asp:DropDownList ID="ddlQnaFin_I" runat="server" SkinID="SkinDropDownList" AutoPostBack="True"
                                        OnSelectedIndexChanged="ddlQnaFin_I_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:CheckBox ID="chbLimitarASemAntMismoTipo_I" runat="server" AutoPostBack="True"
                                        SkinID="SkinCheckBox" Text="Limitar automáticamente" Visible="False" /></InsertItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Fecha fin" Visible="false">
                                <EditItemTemplate>
                                    <asp:DropDownList ID="ddlFchFin_E" runat="server" SkinID="SkinDropDownList" Enabled="False">
                                    </asp:DropDownList>
                                </EditItemTemplate>
                                <InsertItemTemplate>
                                    <asp:DropDownList ID="ddlFchFin_I" runat="server" SkinID="SkinDropDownList" Enabled="False">
                                    </asp:DropDownList>
                                </InsertItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Tipo de hora">
                                <EditItemTemplate>
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:DropDownList ID="ddlNominas" runat="server" SkinID="SkinDropDownList" AutoPostBack="True"
                                                    OnSelectedIndexChanged="ddlNominas_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="chkbxFrenteGrupo" runat="server" AutoPostBack="True" Text="Frente a grupo"
                                                    OnCheckedChanged="chkbxFrenteGrupo_CheckedChanged" />
                                            </td>
                                        </tr>
                                    </table>
                                </EditItemTemplate>
                                <InsertItemTemplate>
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:DropDownList ID="ddlNominasI" runat="server" SkinID="SkinDropDownList" AutoPostBack="True"
                                                    OnSelectedIndexChanged="ddlNominas_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="chkbxFrenteGrupoI" runat="server" AutoPostBack="True" Text="Frente a grupo"
                                                    OnCheckedChanged="chkbxFrenteGrupo_CheckedChanged" />
                                            </td>
                                        </tr>
                                    </table>
                                </InsertItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" Wrap="True" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:TemplateField ShowHeader="False">
                                <EditItemTemplate>
                                    <ajaxToolkit:ConfirmButtonExtender ID="CBE" runat="server" TargetControlID="btnGuardar"
                                        ConfirmText="¿Está seguro de guardar los cambios realizados?">
                                    </ajaxToolkit:ConfirmButtonExtender>
                                    <asp:Button ID="btnCancelar" runat="server" SkinID="SkinBoton" Text="Cancelar"
                                    CausesValidation="false" />
                                    &nbsp;<asp:Button ID="btnGuardar" runat="server" OnClick="btnGuardar_Click" SkinID="SkinBoton"
                                        Text="Guardar" ToolTip="Guardar cambios" ValidationGroup="GpoValidaciones1" CausesValidation="true" />
                                </EditItemTemplate>
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:TemplateField>
                        </Fields>
                    </asp:DetailsView>
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                        ValidationGroup="GpoValidaciones1" ShowSummary="False" />
                </asp:View>
                <asp:View ID="viewExito" runat="server">
                    <table>
                        <tr>
                            <td style="vertical-align: middle; text-align: left">
                                <asp:Image ID="Image2" runat="server" ImageUrl="~/Imagenes/Symbol-Check.png" Width="100px" />
                            </td>
                            <td style="vertical-align: middle; text-align: left">
                                <asp:Label ID="lblExito" runat="server" SkinID="SkinLblMsjExito" Text="Nueva carga horaria creada exitosamente."></asp:Label>
                                <br />
                                <asp:LinkButton ID="lbOtraOperacion" runat="server" SkinID="SkinLinkButton">Cambiar más datos</asp:LinkButton>
                                &nbsp;<asp:LinkButton ID="lbOtraOperacion0" runat="server" PostBackUrl="~/Consultas/Empleados/CargaHoraria.aspx"
                                    SkinID="SkinLinkButton">Continuar con otra operación en el sistema</asp:LinkButton>
                            </td>
                        </tr>
                    </table>
                </asp:View>
                <asp:View ID="viewErrorValidaciones" runat="server">
                    <uc3:wucMuestraErrores ID="wucMuestraErrores1" runat="server" />
                    <div id="divBotonesErrores">
                        <p class="submitButton">
                            &nbsp;<asp:LinkButton ID="lbOtraOperacion2" runat="server" SkinID="SkinLinkButton">Cambiar más datos</asp:LinkButton>
                            &nbsp;<asp:LinkButton ID="lbOtraOperacion1" runat="server" 
                                PostBackUrl="~/Consultas/Empleados/CargaHoraria.aspx" 
                                SkinID="SkinLinkButton">Continuar con otra operación en el sistema</asp:LinkButton>
                        </p>
                    </div>
                </asp:View>
                <asp:View ID="viewErrorInesperado" runat="server">
                    <table>
                        <tr>
                            <td style="vertical-align: middle; text-align: left">
                                <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/Symbol-Stop.png" Width="100px" />
                            </td>
                            <td style="vertical-align: middle; text-align: left">
                                <asp:Label ID="lblError" runat="server" Text="El empleado ya tiene una carga horaria asignada para el semestre actual. Favor de verificar."
                                    SkinID="SkinLblMsjErrores"></asp:Label>
                                <br />
                                <asp:LinkButton ID="lbOtraOperacion4" runat="server" SkinID="SkinLinkButton">Cambiar más datos</asp:LinkButton>
                                &nbsp;<asp:LinkButton ID="lbOtraOperacion3" runat="server" 
                                    PostBackUrl="~/Consultas/Empleados/CargaHoraria.aspx" 
                                    SkinID="SkinLinkButton">Continuar con otra operación en el sistema</asp:LinkButton>
                            </td>
                        </tr>
                   </table>
                </asp:View>
            </asp:MultiView>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
