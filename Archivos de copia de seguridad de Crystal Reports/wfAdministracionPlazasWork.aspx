<%@ Page Language="VB" MasterPageFile="~/MasterPageSesionIniciada.master" AutoEventWireup="false"
    CodeFile="wfAdministracionPlazasWork.aspx.vb" Inherits="wfAdministracionPlazas"
    Title="COBAEV - Nómina - Administrar plazas" StylesheetTheme="SkinFile" %>

<%@ Register Src="../../WebControls/wucSearchEmps2.ascx" TagName="wucSearchEmps2"
    TagPrefix="uc2" %>
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
            <asp:Panel ID="pnlPlazas" runat="server" HorizontalAlign="Left">
                <asp:MultiView ID="MultiView1" runat="server">
                    <asp:View ID="viewPlazas" runat="server">
                        <asp:DetailsView ID="dvPlaza" runat="server" AutoGenerateRows="False" SkinID="SkinDetailsView"
                            DefaultMode="Insert" Width="100%">
                            <FieldHeaderStyle Width="250px" Wrap="True" />
                            <Fields>
                                <asp:TemplateField HeaderText="Clave de plaza">
                                    <EditItemTemplate>
                                    </EditItemTemplate>
                                    <InsertItemTemplate>

                                        <asp:TextBox ID="TextBox1" runat="server" SkinID="skinTxtBx9pt" Width="40px"></asp:TextBox>
                                        <asp:TextBox ID="TextBox2" runat="server" SkinID="skinTxtBx9pt" Width="50px"></asp:TextBox>
                                        <asp:TextBox ID="TextBox3" runat="server" SkinID="skinTxtBx9pt" Width="50px"></asp:TextBox>

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
                                                <asp:DropDownList ID="ddlTiposDeNominasE" runat="server" SkinID="SkinDropDownList">
                                                </asp:DropDownList>
                                    </EditItemTemplate>
                                    <InsertItemTemplate>
                                                <asp:DropDownList ID="ddlTiposDeNominas" runat="server" SkinID="SkinDropDownList">
                                                </asp:DropDownList>
                                    </InsertItemTemplate>
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle Wrap="False" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Centro de trabajo">
                                    <EditItemTemplate>
                                                <asp:DropDownList ID="ddlCentrosDeTrabajoE" runat="server" SkinID="SkinDropDownList">
                                                </asp:DropDownList>
                                    </EditItemTemplate>
                                    <InsertItemTemplate>
                                                <asp:DropDownList ID="ddlCentrosDeTrabajo" runat="server" SkinID="SkinDropDownList">
                                                </asp:DropDownList>
                                    </InsertItemTemplate>
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle Wrap="False" />
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
                                                <asp:CheckBox ID="ChckBxTratarComoBase" runat="server" SkinID="SkinCheckBox" Text="Tratar como Plaza de base" />
                                                 <asp:CheckBox ID="chkbxInterinoPuro" runat="server" SkinID="SkinCheckBox" Text="¿Interino puro?" />
                                    </InsertItemTemplate>
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle Wrap="False" />
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
                                    <HeaderStyle Wrap="False" />
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
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle Wrap="False" />
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
                                                <asp:DropDownList ID="ddlQuincenaTermino" runat="server" SkinID="SkinDropDownList"
                                                    AutoPostBack="True" OnSelectedIndexChanged="ddlQuincenaTermino_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <asp:CompareValidator ID="CVVigencia" runat="server" ControlToCompare="ddlQuincenaInicio"
                                                    ControlToValidate="ddlQuincenaTermino" Display="None" ErrorMessage="Vigencia incorrecta"
                                                    Operator="GreaterThanEqual"></asp:CompareValidator>
                                    </InsertItemTemplate>
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle Wrap="False" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Motivo de baja">
                                    <InsertItemTemplate>
                                                <asp:DropDownList ID="ddlMotivosDeBaja" runat="server" SkinID="SkinDropDownList"
                                                    AutoPostBack="False">
                                                </asp:DropDownList>
                                    </InsertItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Cadena">
                                    <InsertItemTemplate>
                                                <asp:DropDownList ID="ddlCadenas" runat="server" SkinID="SkinDropDownList">
                                                </asp:DropDownList>
                                    </InsertItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Vigente en semestre(s)">
                                    <InsertItemTemplate>
                                                <asp:DropDownList ID="ddlTiposDeSemestres" runat="server" SkinID="SkinDropDownList">
                                                </asp:DropDownList>
                                    </InsertItemTemplate>
                                    <ItemStyle Wrap="False" />
                                </asp:TemplateField>
                                <asp:TemplateField ShowHeader="False">
                                    <EditItemTemplate>
                                                <asp:Button ID="btnUpdTitularPlaza" runat="server" SkinID="SkinBoton" Text="Actualizar titular"
                                                    ToolTip="Actualizar información del titular de la plaza" Visible="False" OnClick="btnUpdTitularPlaza_Click" />
                                                <ajaxToolkit:ConfirmButtonExtender ID="CBEbtnUpdTitularPlaza" runat="server" ConfirmText="¿Realmente desea actualizar la información del titular de la plaza?"
                                                    TargetControlID="btnUpdTitularPlaza">
                                                </ajaxToolkit:ConfirmButtonExtender>
                                        <asp:Button ID="btnCancelar" runat="server" SkinID="SkinBoton" Text="Cancelar" ToolTip="Cancelar operación"
                                            CausesValidation="False" />
                                        <asp:Button ID="btnGuardar" runat="server" SkinID="SkinBoton" Text="Guardar" ToolTip="Guardar cambios"
                                            OnClick="btnGuardar_Click" CausesValidation="False" /><ajaxToolkit:ConfirmButtonExtender
                                                ID="CBE" runat="server" TargetControlID="btnGuardar" ConfirmText="¿Está seguro de guardar los cambios realizados?">
                                            </ajaxToolkit:ConfirmButtonExtender>
                                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                                            ShowSummary="False" />
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
                                    <asp:Label ID="lblExito" runat="server" SkinID="SkinLblMsjExito">Operación realizada exitosamente.</asp:Label>
                                    <br />
                                    <asp:LinkButton ID="lbOtraOperacion" runat="server" SkinID="SkinLinkButton">Cambiar más datos</asp:LinkButton>
                                    &nbsp;<asp:LinkButton ID="lbOtraOperacion0" runat="server" PostBackUrl="~/Consultas/Empleados/DatosCOBAEV.aspx"
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
                    <asp:Panel ID="pnlErroresValidaciones" runat="server" Visible="False">
                        <asp:Panel ID="PnlErrores" runat="server" Visible="False">
                            <table>
                                <tr>
                                    <td style="vertical-align: middle; text-align: left">
                                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/Symbol-Stop.png" Width="100px" />
                                    </td>
                                    <td style="vertical-align: middle; text-align: left">
                                        <asp:Label ID="lblError" runat="server" SkinID="SkinLblMsjErrores"></asp:Label>
                                        <br />
                                        <asp:LinkButton ID="lbReintentarCaptura" runat="server" SkinID="SkinLinkButton">Reintentar operación</asp:LinkButton>
                                         &nbsp;<asp:LinkButton ID="lbOtraOperacion1" runat="server" PostBackUrl="~/Consultas/Empleados/DatosCOBAEV.aspx"
                                        SkinID="SkinLinkButton">Continuar con otra operación en el sistema</asp:LinkButton>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                        <asp:Panel ID="PnlErrores2" runat="server" Visible="False">
                            <table style="width: 100%">
                                <tr>
                                    <td style="text-align: left; width: 42px;">
                                        <asp:Image ID="Image4" runat="server" ImageUrl="~/Imagenes/Symbol-Stop.png" Width="100px" />
                                    </td>
                                    <td style="vertical-align: middle; text-align: left; width: 100%;">
                                        <asp:Label ID="Label2" runat="server" SkinID="SkinLblMsjErrores" Text="Errores producidos al intentar realizar la operación:"></asp:Label>
                                        <br />
                                        <asp:GridView ID="gvErroresPagina" runat="server" AutoGenerateColumns="False" SkinID="SkinGridView"
                                            Width="100%">
                                            <Columns>
                                                <asp:BoundField DataField="IdError" HeaderText="No. Error">
                                                    <HeaderStyle Wrap="False" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Descripcion" HeaderText="Descripción del error">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                    <ItemStyle Wrap="True" />
                                                </asp:BoundField>
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td style="text-align: center">
                                       <asp:Button ID="btnCancelar2" runat="server" SkinID="SkinBoton" Text="Cancelar" ToolTip="Cancelar operación"
                                            CausesValidation="False" />
                                        <asp:Button ID="btnContinuar" runat="server" SkinID="SkinBoton" Text="Reintentar operación" />
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </asp:Panel>
                </asp:View>
                </asp:MultiView>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
