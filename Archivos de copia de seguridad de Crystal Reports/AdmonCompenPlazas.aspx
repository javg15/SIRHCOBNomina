<%@ Page Language="VB" MasterPageFile="~/MasterPageBlanca.master" AutoEventWireup="false" CodeFile="AdmonCompenPlazas.aspx.vb" Inherits="AdmonCompenPlazas" title="COBAEV - Nómina - Compensaciones, Administrar nombramientos" StylesheetTheme="SkinFile" %>
<%@ Register Src="../../WebControls/wucBuscaEmpleados2.ascx" TagName="wucBuscaEmpleados2"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script type="text/JavaScript" language="JavaScript">
    function pageLoad() {
        var manager = Sys.WebForms.PageRequestManager.getInstance();
        manager.add_endRequest(endRequest);
        manager.add_beginRequest(OnBeginRequest);
    }

    function OnBeginRequest(sender, args) {
        $get('ParentDiv').className = 'modalBackground2';
    }

    function endRequest(sender, args) {
        $get('ParentDiv').className = '';
    }

    function CancelPostBack() {
        var objMan = Sys.WebForms.PageRequestManager.getInstance();
        if (objMan.get_isInAsyncPostBack())
            objMan.abortPostBack();
    }
</script>
<asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="500" DynamicLayout="true">
    <ProgressTemplate>
        <div id="ParentDiv">
        </div>
        <div id="div1" runat="server" align="center" valign="middle" style="width: 100%; height: 200%; position: absolute;left: 0;top: 0;visibility:visible;vertical-align:middle;background-color:White;z-index:10; filter: alpha(opacity=40);">
        </div>
        <div id="div2" runat="server" align="center" valign="middle" style="width: 250px; height: 100px; position: absolute;left: 40%;top: 40%;visibility:visible;vertical-align:middle;border-style:inset;border-color:black;background-color:White;z-index:20">
            <br />
            <table align="center">
                <tr>
                    <td style="vertical-align: middle; text-align:center;">
                        <asp:Image runat="server" id="img1" ImageUrl="~/Imagenes/Spinner2.gif" />
                    </td>
                    <td style="vertical-align: middle; text-align:center;">
                        <asp:Label runat="server" id="lblMsjEspera" Text="Por favor espere..." SkinID="SkinLblMsjExito" ></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="vertical-align: middle; text-align:center;">
                        <asp:Button runat="server" id="btnCancelar" OnClientClick="javascript:CancelPostBack(); return false;" SkinID="SkinBoton" Text="Cancelar" />
                    </td>
                </tr>
            </table>
            <br />
        </div>
    </ProgressTemplate>
</asp:UpdateProgress>     
                    <asp:UpdatePanel ID="UPPlazasCompen" runat="server">
                        <ContentTemplate>
        <asp:MultiView ID="MultiView1" runat="server">
            <asp:View ID="viewPlazas" runat="server">

                            <asp:DetailsView ID="dvPlaza" runat="server" AutoGenerateRows="False" 
                                DefaultMode="Insert" SkinID="SkinDetailsView">
                                <Fields>
                                    <asp:TemplateField HeaderText="Función">
                                        <InsertItemTemplate>
                                            <asp:DropDownList ID="ddlEmpleadosFunciones" runat="server" AutoPostBack="True" 
                                                OnSelectedIndexChanged="ddlEmpleadosFunciones_SelectedIndexChanged" 
                                                SkinID="SkinDropDownList">
                                            </asp:DropDownList>
                                        </InsertItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" Wrap="False" />
                                        <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Plantel">
                                        <EditItemTemplate>
                                            <asp:DropDownList ID="ddlPlantelesE" runat="server" AutoPostBack="True" 
                                                OnSelectedIndexChanged="ddlPlanteles_SelectedIndexChanged" 
                                                SkinID="SkinDropDownList">
                                            </asp:DropDownList>
                                        </EditItemTemplate>
                                        <InsertItemTemplate>
                                            <asp:DropDownList ID="ddlPlanteles" runat="server" AutoPostBack="True" 
                                                OnSelectedIndexChanged="ddlPlanteles_SelectedIndexChanged" 
                                                SkinID="SkinDropDownList">
                                            </asp:DropDownList>
                                        </InsertItemTemplate>
                                        <HeaderStyle Wrap="False" />
                                        <ItemStyle Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Centro de trabajo">
                                        <EditItemTemplate>
                                            <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="ddlCentrosDeTrabajoE" runat="server" 
                                                        SkinID="SkinDropDownList">
                                                    </asp:DropDownList>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="ddlPlantelesE" 
                                                        EventName="SelectedIndexChanged" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </EditItemTemplate>
                                        <InsertItemTemplate>
                                            <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="ddlCentrosDeTrabajo" runat="server" AutoPostBack="True" 
                                                        onselectedindexchanged="ddlCentrosDeTrabajo_SelectedIndexChanged" 
                                                        SkinID="SkinDropDownList">
                                                    </asp:DropDownList>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="ddlPlanteles" 
                                                        EventName="SelectedIndexChanged" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </InsertItemTemplate>
                                        <HeaderStyle Wrap="False" />
                                        <ItemStyle Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Centro de trabajo (Secundario)">
                                        <EditItemTemplate>
                                            <asp:UpdatePanel ID="UPCTSecE" runat="server">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="ddlCTSecE" runat="server" SkinID="SkinDropDownList">
                                                    </asp:DropDownList>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="ddlPlantelesE" 
                                                        EventName="SelectedIndexChanged" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </EditItemTemplate>
                                        <InsertItemTemplate>
                                            <asp:UpdatePanel ID="UPCTSecI" runat="server">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="ddlCTSec" runat="server" SkinID="SkinDropDownList">
                                                    </asp:DropDownList>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="ddlPlanteles" 
                                                        EventName="SelectedIndexChanged" />
                                                    <asp:AsyncPostBackTrigger ControlID="ddlCentrosDeTrabajo" 
                                                        EventName="SelectedIndexChanged" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </InsertItemTemplate>
                                        <HeaderStyle Wrap="False" />
                                        <ItemStyle Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Categoría">
                                        <EditItemTemplate>
                                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="ddlCategoriasE" runat="server" SkinID="SkinDropDownList">
                                                    </asp:DropDownList>
                                                </ContentTemplate>
                                                <Triggers>
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </EditItemTemplate>
                                        <InsertItemTemplate>
                                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="ddlCategorias" runat="server" AutoPostBack="True" 
                                                        SkinID="SkinDropDownList">
                                                    </asp:DropDownList>
                                                </ContentTemplate>
                                                <Triggers>
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </InsertItemTemplate>
                                        <HeaderStyle Wrap="False" />
                                        <ItemStyle Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Función primaria">
                                        <EditItemTemplate>
                                            <asp:UpdatePanel ID="UpdatePanel19" runat="server">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="ddlFuncionesPriE" runat="server" 
                                                        SkinID="SkinDropDownList">
                                                    </asp:DropDownList>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="ddlCategoriasE" 
                                                        EventName="SelectedIndexChanged" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </EditItemTemplate>
                                        <InsertItemTemplate>
                                            <asp:UpdatePanel ID="UpdatePanel20" runat="server">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="ddlFuncionesPri" runat="server" AutoPostBack="False" 
                                                        SkinID="SkinDropDownList">
                                                    </asp:DropDownList>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="ddlCategorias" 
                                                        EventName="SelectedIndexChanged" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </InsertItemTemplate>
                                        <HeaderStyle Wrap="False" />
                                        <ItemStyle Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Función secundaria">
                                        <EditItemTemplate>
                                            <asp:DropDownList ID="ddlFuncionesSecE" runat="server" 
                                                SkinID="SkinDropDownList">
                                            </asp:DropDownList>
                                        </EditItemTemplate>
                                        <InsertItemTemplate>
                                            <asp:DropDownList ID="ddlFuncionesSec" runat="server" AutoPostBack="False" 
                                                SkinID="SkinDropDownList">
                                            </asp:DropDownList>
                                        </InsertItemTemplate>
                                        <HeaderStyle Wrap="False" />
                                        <ItemStyle Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Inicio">
                                        <EditItemTemplate>
                                            <asp:DropDownList ID="ddlQuincenaInicio" runat="server" 
                                                SkinID="SkinDropDownList">
                                            </asp:DropDownList>
                                        </EditItemTemplate>
                                        <InsertItemTemplate>
                                            <asp:DropDownList ID="ddlQuincenaInicio" runat="server" AutoPostBack="True" 
                                                OnSelectedIndexChanged="ddlQuincenaInicio_SelectedIndexChanged" 
                                                SkinID="SkinDropDownList">
                                            </asp:DropDownList>
                                        </InsertItemTemplate>
                                        <HeaderStyle Wrap="False" />
                                        <ItemStyle Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Término">
                                        <EditItemTemplate>
                                            <asp:DropDownList ID="ddlQuincenaTermino" runat="server" 
                                                SkinID="SkinDropDownList">
                                            </asp:DropDownList>
                                        </EditItemTemplate>
                                        <InsertItemTemplate>
                                            <asp:UpdatePanel ID="UPQnaFin" runat="server">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="ddlQuincenaTermino" runat="server" AutoPostBack="True" 
                                                        OnSelectedIndexChanged="ddlQuincenaTermino_SelectedIndexChanged" 
                                                        SkinID="SkinDropDownList">
                                                    </asp:DropDownList>
                                                    <asp:CompareValidator ID="CVVigencia" runat="server" 
                                                        ControlToCompare="ddlQuincenaInicio" ControlToValidate="ddlQuincenaTermino" 
                                                        Display="None" ErrorMessage="Vigencia incorrecta" Operator="GreaterThanEqual"></asp:CompareValidator>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="ddlQuincenaInicio" 
                                                        EventName="SelectedIndexChanged" />
                                                    <asp:AsyncPostBackTrigger ControlID="ddlMotivosDeBaja" 
                                                        EventName="SelectedIndexChanged" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </InsertItemTemplate>
                                        <HeaderStyle Wrap="False" />
                                        <ItemStyle Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Motivo de baja">
                                        <InsertItemTemplate>
                                            <asp:UpdatePanel ID="UPMotivoBaja" runat="server">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="ddlMotivosDeBaja" runat="server" AutoPostBack="True" 
                                                        onselectedindexchanged="ddlMotivosDeBaja_SelectedIndexChanged" 
                                                        SkinID="SkinDropDownList">
                                                    </asp:DropDownList>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="ddlQuincenaTermino" 
                                                        EventName="SelectedIndexChanged" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </InsertItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="¿Está físicamente?">
                                        <InsertItemTemplate>
                                            <asp:CheckBox ID="chbkEstaFisic" runat="server" SkinID="SkinCheckBox" />
                                        </InsertItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="¿Dar prioridad a nombramiento de Compensación?">
                                        <InsertItemTemplate>
                                            <asp:CheckBox ID="chbkPrioridadNombComp" runat="server" SkinID="SkinCheckBox" />
                                        </InsertItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ShowHeader="False">
                                        <EditItemTemplate>
                                            <asp:Button ID="btnGuardar" runat="server" OnClick="btnGuardar_Click" 
                                                SkinID="SkinBoton" Text="Guardar" ToolTip="Guardar cambios" />
                                            <ajaxToolkit:ConfirmButtonExtender ID="CBE" runat="server" 
                                                ConfirmText="¿Está seguro de guardar los cambios realizados?" 
                                                TargetControlID="btnGuardar">
                                            </ajaxToolkit:ConfirmButtonExtender>
                                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                                                ShowMessageBox="True" ShowSummary="False" />
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
                            <asp:Image ID="Image2" runat="server" ImageUrl="~/Imagenes/Symbol-Check.png" Width="100px" /></td>
                        <td style="vertical-align: middle; text-align: left">
                <asp:Label ID="lblExito" runat="server" SkinID="SkinLblMsjExito"></asp:Label></td>
                    </tr>
                </table>
            </asp:View>
            <asp:View ID="viewError" runat="server">
                <table>
                    <tr>
                        <td style="vertical-align: middle; text-align: left">
                            <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/Symbol-Stop.png" Width="100px" /></td>
                        <td style="vertical-align: middle; text-align: left">
                <asp:Label ID="lblError" runat="server" SkinID="SkinLblMsjErrores"></asp:Label></td>
                    </tr>
                </table>
            </asp:View>
        </asp:MultiView>
                        </ContentTemplate>
                    </asp:UpdatePanel>
</asp:Content>
