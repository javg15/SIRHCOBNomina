<%@ Page Language="VB" MasterPageFile="~/MasterPageSesionIniciada.master" AutoEventWireup="false"
    CodeFile="wfAdministracionPlazas2.aspx.vb" Inherits="wfAdministracionPlazas2" Title="COBAEV - Nómina - Administrar plazas"
    StylesheetTheme="SkinFile" %>

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
    <asp:UpdatePanel ID="UPPlazas" runat="server">
        <ContentTemplate>
            <asp:MultiView ID="MultiView1" runat="server">
                <asp:View ID="viewConsultaPlaza" runat="server">
                    <asp:DetailsView ID="dvConsultaPlaza" runat="server" SkinID="SkinDetailsView" 
                        Width="100%" AutoGenerateRows="False">
                        <FieldHeaderStyle Width="300px" Wrap="True" />
                        <Fields>
                            <asp:BoundField DataField="TipoPlaza"  HeaderText="Tipo de plaza" />
                            <asp:BoundField DataField="ClaveOficialCatego" 
                                HeaderText="Categoría (Clave oficial)" />
                            <asp:BoundField DataField="ClaveInternaCatego" 
                                HeaderText="Categoría (Clave interna)" />
                            <asp:BoundField DataField="DescCategoria" 
                                HeaderText="Categoría (Nombre)" />
                            <asp:BoundField DataField="DescFondoPresup" 
                                HeaderText="Fondo presupuestal al que pertenece la plaza" />
                            <asp:BoundField DataField="DescTipoNomb" 
                                HeaderText="Nombramiento (Tipo ocupación de la plaza)" />
                            <asp:BoundField DataField="TratarComoBase" 
                                HeaderText="Tratar como plaza base" />
                            <asp:BoundField DataField="ApePatEmpTit" 
                                HeaderText="Titular de la plaza (Apellido paterno)" />
                            <asp:BoundField DataField="ApeMatEmpTit" 
                                HeaderText="Titular de la plaza (Apellido materno)" />
                            <asp:BoundField DataField="NomEmpTit" 
                                HeaderText="Titular de la plaza (Nombre)" />
                            <asp:BoundField DataField="EstatusDelEmpEnLaPlaza" 
                                HeaderText="Estatus del titular en la plaza" />
                            <asp:BoundField DataField="TipoSemestre" 
                                HeaderText="Plaza ejercida en el semestre"/>
                            <asp:BoundField DataField="ClaveOficialCT" 
                                HeaderText="Centro de trabajo (Clave oficial)" />
                            <asp:BoundField DataField="ClaveInternaCT" 
                                HeaderText="Centro de trabajo (Clave interna)" />
                            <asp:BoundField DataField="DescCT" 
                                HeaderText="Centro de trabajo (Nombre)" />
                            <asp:BoundField DataField="ClaveInternaCentroAdscrip" 
                                HeaderText="Centro de adscripción (Clave interna)" />
                            <asp:BoundField DataField="DescCentroAdscrip" 
                                HeaderText="Centro de adscripción (Nombre)" />
                            <asp:BoundField DataField="QnaIni" 
                                HeaderText="Vigencia (Quincena inicial)" />
                            <asp:BoundField DataField="QnaFin" 
                                HeaderText="Vigencia (Quincena final)" />
                            <asp:BoundField DataField="FechaAlta" DataFormatString="{0:d}"
                                HeaderText="Vigencia (Fecha inicial)" />
                            <asp:BoundField DataField="FechaBaja" 
                                HeaderText="Vigencia (Fecha final)" DataFormatString="{0:d}"/>
                            <asp:BoundField DataField="DescMotGralBaja" 
                                HeaderText="Motivo de baja de la plaza"/>
                            <asp:BoundField DataField="Sindicato"
                                HeaderText="Adhesión sindical" />
                            <asp:BoundField DataField="FuncionPrimaria" 
                                HeaderText="Funcion primaria" />
                            <asp:BoundField DataField="FuncionSecundaria" 
                                HeaderText="Funcion secundaria" />
                        </Fields>
                    </asp:DetailsView>
                </asp:View>
                <asp:View ID="viewPlazas" runat="server">
                <div class="divLeft420">
                        <p class="pTop">
                            <asp:Label ID="lblTipoPlaza" runat="server" Text="Función:"></asp:Label>
                        </p>
                        <p class="pBottom">
                            <asp:DropDownList ID="ddlEmpleadosFunciones" runat="server"  Width="100%" 
                                AutoPostBack="True">
                            </asp:DropDownList>
                        </p>
                        <p class="pTop2">
                            <asp:Label ID="lblPlanteles" runat="server" Text="Planteles:" ToolTip="Centro de trabajo donde es/será ejercida la plaza"></asp:Label>
                        </p>
                        <p class="pBottom">
                            <asp:DropDownList ID="ddlPlanteles" runat="server"  Width="100%"  
                                AutoPostBack="True">
                            </asp:DropDownList>
                        </p>
                        <p class="pTop2">
                            <asp:Label ID="lblDepto" runat="server" Text="Centro de trabajo:" ToolTip="Departamento dentro del Centro de trabajo donde es/será ejercida la plaza"></asp:Label>
                        </p>
                        <p class="pBottom">
                            <asp:DropDownList ID="ddlCentrosDeTrabajo" runat="server"  Width="100%" 
                                AutoPostBack="True">
                            </asp:DropDownList>
                        </p>
                         <p class="pTop">
                            <asp:Label ID="lblFPPlaza" runat="server" Text="Nómina:"></asp:Label>
                        </p>
                         <p class="pBottom">
                            <asp:DropDownList ID="ddlTiposDeNominas" runat="server" Width="100%"  
                                AutoPostBack="True">
                            </asp:DropDownList>
                        </p>
                        <p class="pTop2">
                            <asp:Label ID="lblCatego" runat="server" Text="Categorías:"></asp:Label>
                        </p>
                         <p class="pBottom">
                            <asp:DropDownList ID="ddlCategorias" runat="server"  Width="100%"  
                                AutoPostBack="True">
                            </asp:DropDownList>
                        </p>
                        <p class="pTop2">
                            <asp:Label ID="lblSindicato" runat="server" Text="Sindicato:"></asp:Label>
                        </p>
                         <p class="pBottom">
                            <asp:DropDownList ID="ddlSindicatos" runat="server"  Width="100%"  
                                AutoPostBack="True">
                            </asp:DropDownList>
                        </p>
                        <p class="pTop2">
                            <asp:Label ID="lblTipoOcup" runat="server" Text="Tipo ocupación:"></asp:Label>
                        </p>
                         <p class="pBottom">
                            <asp:DropDownList ID="ddlPlazasTipoOcup" runat="server"  Width="100%"  
                                AutoPostBack="True">
                            </asp:DropDownList>
                            <asp:CheckBox ID="ChckBxTratarComoBase" runat="server" SkinID="SkinCheckBox" Text="Tratar como Plaza de base" />
                            <asp:CheckBox ID="chkbxInterinoPuro" runat="server" SkinID="SkinCheckBox" Text="¿Interino puro?" />
                        </p>
                        <p class="pTop2">
                            <asp:Label ID="lblMotivoInterinato" runat="server" Text="Motivo interinato:"></asp:Label>
                        </p>
                        <p class="pBottom">
                            <asp:DropDownList ID="ddlMotivoInterinato" runat="server"  Width="100%"  AutoPostBack="True">
                            </asp:DropDownList>
                        </p>
                        <p class="pTop2">
                            <asp:Label ID="lblTitPlaza" runat="server" Text="Titular de la plaza:"></asp:Label>
                        </p>
                        <p class="pBottom" style="clear: both;">
                            <asp:Label ID="lblEmpTitPlaza" runat="server" Text="(SIN DEFINIR)"></asp:Label>
                        </p>                        
                        <p class="pTop2" style="clear:both;">
                            <asp:Label ID="lblFuncPri" runat="server" Text="Función primaria:"></asp:Label>
                        </p>
                        <p class="pBottom">
                            <asp:DropDownList ID="ddlFuncionesPri" runat="server"  Width="100%"  AutoPostBack="True">
                            </asp:DropDownList>
                        </p>
                        <p class="pTop2">
                            <asp:Label ID="lblFuncSec" runat="server" Text="Función secundaria:"></asp:Label>
                        </p>
                        <p class="pBottom">
                            <asp:DropDownList ID="ddlFuncionesSec" runat="server"  Width="100%"  AutoPostBack="True">
                            </asp:DropDownList>
                        </p>
                        <p class="pTop2" style="clear:both;">
                            <asp:Label ID="lblVigIni" runat="server" Text="Vigencia inicial:"></asp:Label>
                        </p>
                        <p class="pBottom" style="clear:both;">
                            <asp:Label ID="lblMsjQnaIni" runat="server" Text="Quincena:" Visible="True"></asp:Label>
                            <asp:DropDownList ID="ddlQuincenaInicio" runat="server" AutoPostBack="True" 
                                OnSelectedIndexChanged="ddlQuincenaInicio_SelectedIndexChanged"
                                Width="150px">
                            </asp:DropDownList>
                            <asp:Label ID="lblMsjFechaIni" runat="server" Text="Fecha alta (dd/mm/aaaa):" Visible="True"
                                ></asp:Label>
                            <asp:TextBox ID="txtbxFchAlta" runat="server" Enabled="False"
                                MaxLength="10" Width="100px" CausesValidation="true"></asp:TextBox>
                            <asp:CompareValidator ID="CV_txtbxFchAlta" runat="server" ControlToValidate="txtbxFchAlta"
                                Display="None" ErrorMessage="Fecha de alta incorrecta" Operator="DataTypeCheck"
                                ToolTip="Fecha incorrecta" Type="Date">*</asp:CompareValidator>
                            <asp:RequiredFieldValidator ID="RFV_FchAlta" runat="server" ControlToValidate="txtbxFchAlta"
                                Display="None" ErrorMessage="La fecha de alta es obligatoria."></asp:RequiredFieldValidator>
                        </p>
                        <p class="pTop2" style="clear:both;">
                            <asp:Label ID="lblVigFin" runat="server" Text="Vigencia final:"></asp:Label>
                        </p>
                         <p class="pBottom"  style="clear:both;">
                            <asp:Label ID="lblMsjQnaFin" runat="server" Text="Quincena:" Visible="True"></asp:Label>
                            <asp:DropDownList ID="ddlQuincenaTermino" runat="server"  Width="150px" 
                                AutoPostBack="True" OnSelectedIndexChanged="ddlQuincenaTermino_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:CompareValidator ID="CVVigencia" runat="server" ControlToCompare="ddlQuincenaInicio"
                                ControlToValidate="ddlQuincenaTermino" Display="None" ErrorMessage="Vigencia incorrecta (Quincenas)"
                                Operator="GreaterThanEqual"></asp:CompareValidator>
                            <asp:Label ID="lblMsjFechaFin" runat="server" Text="Fecha baja (dd/mm/aaaa):" Visible="True"
                               ></asp:Label>
                            <asp:TextBox ID="txtbxFchBaja" runat="server"  Enabled="False"
                                MaxLength="10" Width="100px" CausesValidation="true"></asp:TextBox>
                            <asp:CompareValidator ID="CV_txtbxFchBaja" runat="server" ControlToValidate="txtbxFchBaja"
                                Display="None" ErrorMessage="Fecha de baja incorrecta" Operator="DataTypeCheck"
                                ToolTip="Fecha incorrecta" Type="Date">*</asp:CompareValidator>
                            <asp:CompareValidator ID="CVVigenciaFecha" runat="server" ControlToCompare="txtbxFchAlta"
                                ControlToValidate="txtbxFchBaja" Display="None" ErrorMessage="Vigencia incorrecta (Fechas)"
                                Operator="GreaterThanEqual"></asp:CompareValidator>
                            <asp:RequiredFieldValidator ID="RFV_FchBaja" runat="server" ControlToValidate="txtbxFchBaja"
                                Display="None" ErrorMessage="La fecha de baja es obligatoria."></asp:RequiredFieldValidator>
                         </p>
                   </div>

                    <asp:DetailsView ID="dvPlaza" runat="server" AutoGenerateRows="False" SkinID="SkinDetailsView"
                        DefaultMode="Insert" Width="100%">
                        <FieldHeaderStyle Width="250px" Wrap="True" />
                        <Fields>

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
                                <HeaderStyle HorizontalAlign="Left" Wrap="False" />
                                <ItemStyle  HorizontalAlign="Left" Wrap="False" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Motivo de baja">
                                <InsertItemTemplate>
                                    <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="ddlMotivosDeBaja" runat="server" SkinID="SkinDropDownList"
                                                AutoPostBack="True" OnSelectedIndexChanged="ddlMotivosDeBaja_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="ddlQuincenaTermino" EventName="SelectedIndexChanged" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </InsertItemTemplate>
                                <HeaderStyle  HorizontalAlign="Left" Wrap="False" />
                                 <ItemStyle  HorizontalAlign="Left" Wrap="False" />
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
                                <HeaderStyle  HorizontalAlign="Left" Wrap="False" />
                                <ItemStyle  HorizontalAlign="Left" Wrap="False" />
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
                                 <HeaderStyle  HorizontalAlign="Left" Wrap="False" />
                                 <ItemStyle  HorizontalAlign="Left" Wrap="False" />
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
                                        OnClick="btnGuardar_Click" CausesValidation="true" /><ajaxToolkit:ConfirmButtonExtender
                                            ID="CBE" runat="server" TargetControlID="btnGuardar" ConfirmText="¿Está seguro de guardar los cambios realizados?">
                                        </ajaxToolkit:ConfirmButtonExtender>
                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                                        ShowSummary="False" />
                                </EditItemTemplate>
                                 <HeaderStyle HorizontalAlign="Left" Wrap="False" />
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
                                    <td>
                                        <asp:Button ID="btnContinuar" runat="server" SkinID="SkinBoton" Text="Continuar" />
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </asp:Panel>
                </asp:View>
            </asp:MultiView>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
