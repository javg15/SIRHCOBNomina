<%@ Page Language="VB" MasterPageFile="~/MasterPageBlanca.master" AutoEventWireup="false"
    CodeFile="AdministracionCargaHorariaBak.aspx.vb" Inherits="AdministracionCargaHorariaBak"
    Title="COBAEV - Nómina - Administrar carga horaria" StylesheetTheme="SkinFile" %>

<%@ Register Src="~/WebControls/wucSearchEmps2.ascx" TagName="wucSearchEmps2"
    TagPrefix="uc2" %>
<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress" TagPrefix="TP_wucUpdateProgress" %>
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
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View1" runat="server">
            <asp:DetailsView ID="dvCargaHoraria" runat="server" AutoGenerateRows="False" SkinID="SkinDetailsView"
                DefaultMode="Edit">
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
                    <asp:TemplateField HeaderText="Planteles">
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
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Materias">
                        <EditItemTemplate>
                            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlMaterias" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlMaterias_SelectedIndexChanged"
                                        SkinID="SkinDropDownList">
                                    </asp:DropDownList>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddlNominas" EventName="SelectedIndexChanged" />
                                    <asp:AsyncPostBackTrigger ControlID="chkbxFrenteGrupo" EventName="CheckedChanged" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlMateriasI" runat="server" OnSelectedIndexChanged="ddlMaterias_SelectedIndexChanged"
                                        SkinID="SkinDropDownList" AutoPostBack="True">
                                    </asp:DropDownList>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddlNominasI" EventName="SelectedIndexChanged" />
                                    <asp:AsyncPostBackTrigger ControlID="chkbxFrenteGrupoI" EventName="CheckedChanged" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </InsertItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Horas">
                        <EditItemTemplate>
                            <asp:UpdatePanel ID="UPCantidad" runat="server">
                                <ContentTemplate>
                                    <asp:TextBox ID="txtbxCantidad" runat="server" SkinID="SkinTextBox" Width="50px"
                                        Text='<%# Bind("Cantidad") %>' ReadOnly="True" MaxLength="2"></asp:TextBox><asp:RequiredFieldValidator
                                            ID="rfvCantidad" runat="server" ControlToValidate="txtbxCantidad" Display="Dynamic"
                                            ErrorMessage="*"></asp:RequiredFieldValidator><asp:RangeValidator ID="rvCantidad"
                                                runat="server" ControlToValidate="txtbxCantidad" ErrorMessage="Escriba un valor entre 1 y 40"
                                                MaximumValue="40" MinimumValue="1" Display="Dynamic" Type="Integer"></asp:RangeValidator>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FTBECantidad" runat="server" FilterType="Numbers"
                                        TargetControlID="txtbxCantidad">
                                    </ajaxToolkit:FilteredTextBoxExtender>
                                    <asp:HiddenField ID="hfCantidad" runat="server" Value='<%# Bind("Cantidad") %>'>
                                    </asp:HiddenField>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddlMaterias" EventName="SelectedIndexChanged">
                                    </asp:AsyncPostBackTrigger>
                                    <asp:AsyncPostBackTrigger ControlID="ddlNominas" EventName="SelectedIndexChanged" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            <asp:UpdatePanel ID="UPCantidad" runat="server">
                                <ContentTemplate>
                                    <asp:TextBox ID="txtbxCantidadIns" runat="server" SkinID="SkinTextBox" Width="50px"
                                        ReadOnly="True" MaxLength="2"></asp:TextBox><asp:RequiredFieldValidator ID="rfvCantidadI"
                                            runat="server" ControlToValidate="txtbxCantidadIns" Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator><asp:RangeValidator
                                                ID="rvCantidadI" runat="server" ControlToValidate="txtbxCantidadIns" ErrorMessage="Escriba un valor entre 1 y 40"
                                                MaximumValue="40" MinimumValue="1" Display="Dynamic" Type="Integer"></asp:RangeValidator>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FTBECantidadI" runat="server" FilterType="Numbers"
                                        TargetControlID="txtbxCantidadIns">
                                    </ajaxToolkit:FilteredTextBoxExtender>
                                    <asp:HiddenField ID="hfCantidadIns" runat="server"></asp:HiddenField>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddlMateriasI" EventName="SelectedIndexChanged">
                                    </asp:AsyncPostBackTrigger>
                                    <asp:AsyncPostBackTrigger ControlID="ddlNominasI" EventName="SelectedIndexChanged" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </InsertItemTemplate>
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
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Tipo hora">
                        <EditItemTemplate>
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlTipoHoraE" runat="server" SkinID="SkinDropDownList">
                                    </asp:DropDownList>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddlMaterias" EventName="SelectedIndexChanged" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlTipoHoraI" runat="server" SkinID="SkinDropDownList">
                                    </asp:DropDownList>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddlMateriasI" EventName="SelectedIndexChanged" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </InsertItemTemplate>
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
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Motivo interinato">
                        <EditItemTemplate>
                            <asp:UpdatePanel ID="UpdatePanel15" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlMotivoInterinatoE" runat="server" SkinID="SkinDropDownList">
                                    </asp:DropDownList>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddlNombramientoE" EventName="SelectedIndexChanged" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            <asp:UpdatePanel ID="UpdatePanel16" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlMotivoInterinatoI" runat="server" SkinID="SkinDropDownList">
                                    </asp:DropDownList>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddlNombramientoI" EventName="SelectedIndexChanged" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </InsertItemTemplate>
                        <HeaderStyle Wrap="False" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Titular de las horas">
                        <EditItemTemplate>
                            <asp:UpdatePanel ID="UpdatePanel17" runat="server">
                                <ContentTemplate>
                                    <uc2:wucSearchEmps2 ID="WucBuscaEmpleados2_E" runat="server" Visible="false" />
                                    <asp:Label ID="LblEmpTitularSDE" runat="server" SkinID="SkinLblNormal" Text="(SIN DEFINIR)"></asp:Label>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            <asp:UpdatePanel ID="UpdatePanel18" runat="server">
                                <ContentTemplate>
                                    <uc2:wucSearchEmps2 ID="WucBuscaEmpleados2_I" runat="server" Visible="false" />
                                    &nbsp;<asp:Label ID="LblEmpTitularSDI" runat="server" SkinID="SkinLblNormal" Text="(SIN DEFINIR)"></asp:Label>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </InsertItemTemplate>
                        <HeaderStyle Wrap="False" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Grupos">
                        <EditItemTemplate>
                            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlGrupos" runat="server" SkinID="SkinDropDownList">
                                    </asp:DropDownList>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddlNominas" EventName="SelectedIndexChanged" />
                                    <asp:AsyncPostBackTrigger ControlID="ddlMaterias" EventName="SelectedIndexChanged" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlGruposI" runat="server" SkinID="SkinDropDownList">
                                    </asp:DropDownList>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddlNominasI" EventName="SelectedIndexChanged" />
                                    <asp:AsyncPostBackTrigger ControlID="ddlMateriasI" EventName="SelectedIndexChanged" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </InsertItemTemplate>
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
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Inicio">
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
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Fin">
                        <EditItemTemplate>
                            <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlQnaFin_E" runat="server" SkinID="SkinDropDownList" AutoPostBack="True"
                                        OnSelectedIndexChanged="ddlQnaFin_E_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:CheckBox ID="chbLimitarASemAntMismoTipo_E" runat="server" AutoPostBack="True"
                                        OnCheckedChanged="chbLimitarASemAntMismoTipo_E_CheckedChanged" SkinID="SkinCheckBox"
                                        Text="Limitar automáticamente" />
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddlQnaIni_E" EventName="SelectedIndexChanged" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlQnaFin_I" runat="server" SkinID="SkinDropDownList" AutoPostBack="True"
                                        OnSelectedIndexChanged="ddlQnaFin_I_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:CheckBox ID="chbLimitarASemAntMismoTipo_I" runat="server" AutoPostBack="True"
                                        SkinID="SkinCheckBox" Text="Limitar automáticamente" Visible="False" />
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddlQnaIni_I" EventName="SelectedIndexChanged" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </InsertItemTemplate>
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
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="N&#243;mina">
                        <EditItemTemplate>
                            <table>
                                <tr>
                                    <td>
                                        <asp:DropDownList ID="ddlNominas" runat="server" SkinID="SkinDropDownList" AutoPostBack="True"
                                            OnSelectedIndexChanged="ddlNominas_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                                            <ContentTemplate>
                                                <asp:CheckBox ID="chkbxFrenteGrupo" runat="server" AutoPostBack="True" Text="Frente a grupo"
                                                    OnCheckedChanged="chkbxFrenteGrupo_CheckedChanged" />
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="ddlNominas" EventName="SelectedIndexChanged" />
                                            </Triggers>
                                        </asp:UpdatePanel>
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
                                        <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                                            <ContentTemplate>
                                                <asp:CheckBox ID="chkbxFrenteGrupoI" runat="server" AutoPostBack="True" Text="Frente a grupo"
                                                    OnCheckedChanged="chkbxFrenteGrupo_CheckedChanged" />
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="ddlNominasI" EventName="SelectedIndexChanged" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                            </table>
                        </InsertItemTemplate>
                        <ItemStyle Wrap="True" />
                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="False">
                        <EditItemTemplate>
                            <ajaxToolkit:ConfirmButtonExtender ID="CBE" runat="server" TargetControlID="btnGuardar"
                                ConfirmText="¿Está seguro de guardar los cambios realizados?">
                            </ajaxToolkit:ConfirmButtonExtender>
                            <asp:Button ID="btnGuardar" runat="server" OnClick="btnGuardar_Click" SkinID="SkinBoton"
                                Text="Guardar" ToolTip="Guardar cambios" />
                        </EditItemTemplate>
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:TemplateField>
                </Fields>
            </asp:DetailsView>
        </asp:View>
        <asp:View ID="View2" runat="server">
            <table>
                <tr>
                    <td style="vertical-align: middle; text-align: left">
                        <asp:Image ID="Image2" runat="server" ImageUrl="~/Imagenes/Symbol-Check.png" Width="100px" />
                    </td>
                    <td style="vertical-align: middle; text-align: left">
                        <asp:Label ID="lblExito" runat="server" SkinID="SkinLblMsjExito" Text="Nueva carga horaria creada exitosamente."></asp:Label>
                    </td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="View3" runat="server">
            <table>
                <tr>
                    <td style="vertical-align: middle; text-align: left">
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/Symbol-Stop.png" Width="100px" />
                    </td>
                    <td style="vertical-align: middle; text-align: left">
                        <asp:Label ID="lblError" runat="server" Text="El empleado ya tiene una carga horaria asignada para el semestre actual. Favor de verificar."
                            SkinID="SkinLblMsjErrores"></asp:Label>
                    </td>
                </tr>
            </table>
        </asp:View>
    </asp:MultiView>
</asp:Content>
