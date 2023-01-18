<%@ page language="VB" masterpagefile="~/MasterPageBlanca.master" autoeventwireup="false" inherits="AdministracionPlazasAntDel, App_Web_xmuq13zf" title="COBAEV - Nómina - Administrar plazas" stylesheettheme="SkinFile" maintainScrollPositionOnPostBack="true" %>

<%@ Register Src="../../WebControls/wucSearchEmps2.ascx" TagName="wucSearchEmps2"
    TagPrefix="uc2" %>
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
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="viewPlazas" runat="server">
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
                    <asp:TemplateField HeaderText="Plantel">
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
                        <HeaderStyle Wrap="False" />
                        <ItemStyle Wrap="False" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="N&#243;mina">
                        <EditItemTemplate>
                            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlTiposDeNominasE" runat="server" SkinID="SkinDropDownList">
                                    </asp:DropDownList>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddlCategoriasE" EventName="SelectedIndexChanged" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlTiposDeNominas" runat="server" SkinID="SkinDropDownList">
                                    </asp:DropDownList>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddlCategorias" EventName="SelectedIndexChanged" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </InsertItemTemplate>
                        <HeaderStyle Wrap="False" />
                        <ItemStyle Wrap="False" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Centro de trabajo">
                        <EditItemTemplate>
                            <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlCentrosDeTrabajoE" runat="server" SkinID="SkinDropDownList">
                                    </asp:DropDownList>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddlPlantelesE" EventName="SelectedIndexChanged" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlCentrosDeTrabajo" runat="server" SkinID="SkinDropDownList">
                                    </asp:DropDownList>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddlPlanteles" EventName="SelectedIndexChanged" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </InsertItemTemplate>
                        <HeaderStyle Wrap="False" />
                        <ItemStyle Wrap="False" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Categor&#237;a">
                        <EditItemTemplate>
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlCategoriasE" runat="server" SkinID="SkinDropDownList">
                                    </asp:DropDownList>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddlEmpleadosFuncionesE" EventName="SelectedIndexChanged" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlCategorias" runat="server" SkinID="SkinDropDownList" AutoPostBack="True"
                                        OnSelectedIndexChanged="ddlCategorias_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddlEmpleadosFunciones" EventName="SelectedIndexChanged" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </InsertItemTemplate>
                        <HeaderStyle Wrap="False" />
                        <ItemStyle Wrap="False" />
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
                        <HeaderStyle Wrap="False" />
                        <ItemStyle Wrap="False" />
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
                            <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                                <ContentTemplate>
                                    <asp:CheckBox ID="ChckBxTratarComoBase" runat="server" SkinID="SkinCheckBox" Text="Tratar como Plaza de base" />
                                    <br />
                                    <asp:CheckBox ID="chkbxInterinoPuro" runat="server" SkinID="SkinCheckBox" Text="¿Interino puro?" />
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddlPlazasTipoOcup" EventName="SelectedIndexChanged" />
                                    <asp:AsyncPostBackTrigger ControlID="ddlCategorias" EventName="SelectedIndexChanged" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </InsertItemTemplate>
                        <HeaderStyle Wrap="False" />
                        <ItemStyle Wrap="False" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Motivo interinato">
                        <EditItemTemplate>
                            <asp:UpdatePanel ID="UpdatePanel15" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlMotivoInterinatoE" runat="server" SkinID="SkinDropDownList">
                                    </asp:DropDownList>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddlPlazasTipoOcup" EventName="SelectedIndexChanged" />
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
                                    <asp:AsyncPostBackTrigger ControlID="ddlPlazasTipoOcup" EventName="SelectedIndexChanged" />
                                    <asp:AsyncPostBackTrigger ControlID="ddlEmpleadosFunciones" EventName="SelectedIndexChanged" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </InsertItemTemplate>
                        <HeaderStyle Wrap="False" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Titular de la plaza">
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
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </InsertItemTemplate>
                        <HeaderStyle Wrap="False" />
                        <ItemStyle Wrap="False" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Funci&#243;n primaria">
                        <EditItemTemplate>
                            <asp:UpdatePanel ID="UpdatePanel19" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlFuncionesPriE" runat="server" SkinID="SkinDropDownList">
                                    </asp:DropDownList>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddlCategoriasE" EventName="SelectedIndexChanged" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            <asp:UpdatePanel ID="UpdatePanel20" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlFuncionesPri" runat="server" SkinID="SkinDropDownList" AutoPostBack="False">
                                    </asp:DropDownList>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddlCategorias" EventName="SelectedIndexChanged" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </InsertItemTemplate>
                        <HeaderStyle Wrap="False" />
                        <ItemStyle Wrap="False" />
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
                        <HeaderStyle Wrap="False" />
                        <ItemStyle Wrap="False" />
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
                        <HeaderStyle Wrap="False" />
                        <ItemStyle Wrap="False" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="T&#233;rmino">
                        <EditItemTemplate>
                            <asp:DropDownList ID="ddlQuincenaTermino" runat="server" SkinID="SkinDropDownList">
                            </asp:DropDownList>
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlQuincenaTermino" runat="server" SkinID="SkinDropDownList"
                                        AutoPostBack="True" OnSelectedIndexChanged="ddlQuincenaTermino_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:CompareValidator ID="CVVigencia" runat="server" ControlToCompare="ddlQuincenaInicio"
                                        ControlToValidate="ddlQuincenaTermino" Display="Dynamic" ErrorMessage="Vigencia incorrecta."
                                        Operator="GreaterThanEqual" ToolTip="Vigencia incorrecta." 
                                        ValidationGroup="gpoGuarda">*</asp:CompareValidator>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddlQuincenaInicio" EventName="SelectedIndexChanged" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </InsertItemTemplate>
                        <HeaderStyle Wrap="False" />
                        <ItemStyle Wrap="False" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Motivo de baja">
                        <InsertItemTemplate>
                            <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                <ContentTemplate>
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
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddlQuincenaTermino" EventName="SelectedIndexChanged" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </InsertItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Cadena">
                        <InsertItemTemplate>
                            <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlCadenas" runat="server" SkinID="SkinDropDownList">
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </InsertItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Vigente en semestre(s)">
                        <InsertItemTemplate>
                            <asp:UpdatePanel ID="UPVigEnSem" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlTiposDeSemestres" runat="server" SkinID="SkinDropDownList">
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </InsertItemTemplate>
                        <ItemStyle Wrap="False" />
                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="False">
                        <EditItemTemplate>
                            <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                <ContentTemplate>
                                    <asp:Button ID="btnUpdTitularPlaza" runat="server" SkinID="SkinBoton" Text="Actualizar titular"
                                        ToolTip="Actualizar información del titular de la plaza" Visible="False" OnClick="btnUpdTitularPlaza_Click" />
                                    <ajaxToolkit:ConfirmButtonExtender ID="CBEbtnUpdTitularPlaza" runat="server" ConfirmText="¿Realmente desea actualizar la información del titular de la plaza?"
                                        TargetControlID="btnUpdTitularPlaza">
                                    </ajaxToolkit:ConfirmButtonExtender>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddlPlazasTipoOcup" EventName="SelectedIndexChanged" />
                                    <asp:PostBackTrigger ControlID="btnUpdTitularPlaza" />
                                </Triggers>
                            </asp:UpdatePanel>
                            <br />
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
                    </td>
                </tr>
            </table>
        </asp:View>
    </asp:MultiView>
</asp:Content>
