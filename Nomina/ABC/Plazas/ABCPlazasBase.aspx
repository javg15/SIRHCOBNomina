<%@ Page EnableEventValidation="false" Language="VB" MasterPageFile="~/MasterPageSesionIniciada.master"
    AutoEventWireup="false" CodeFile="ABCPlazasBase.aspx.vb" Inherits="ABCPlazasBase"
    Title="COBAEV - Nómina - Empleados, control de incidencias" StylesheetTheme="SkinFile" %>

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
        <asp:Panel ID="pnl1" runat="server">
            <ajaxToolkit:CollapsiblePanelExtender ID="CPEPlazasBase" runat="Server" CollapseControlID="TitlePanelHistorial"
                Collapsed="false" CollapsedImage="~/Imagenes/expand_blue.jpg" CollapsedText="(Mostrar detalles...)"
                ExpandControlID="TitlePanelHistorial" ExpandedImage="~/Imagenes/collapse_blue.jpg"
                ExpandedText="(Ocultar detalles...)" ImageControlID="img1PlazasBase" SuppressPostBack="true"
                TargetControlID="PanelHistorial" TextLabelID="lbl1PlazasBase">
            </ajaxToolkit:CollapsiblePanelExtender>
            <asp:MultiView ID="MultiView1" runat="server">
                <asp:View ID="viewPlazas" runat="server">
                <asp:Panel ID="pnlInfPlaza" runat="server" GroupingText="Información de la plaza asignada o por asignar">
                    <asp:DetailsView ID="dvPlaza" runat="server" AutoGenerateRows="False" SkinID="SkinDetailsView"
                        DefaultMode="Insert" Width="100%">
                        <FieldHeaderStyle Width="250px" Wrap="True" />
                        <Fields>
                            <asp:TemplateField HeaderText="Empleado"><InsertItemTemplate><asp:Label ID="lblNombreEmpleado" runat="server" SkinID="SkinLblNormal" Text=""></asp:Label><asp:HiddenField  ID="hidIdEmpleado" runat="server" /></InsertItemTemplate><HeaderStyle HorizontalAlign="Left" Wrap="False" /><ItemStyle HorizontalAlign="Left" Wrap="False" /></asp:TemplateField>
                            <asp:TemplateField HeaderText="Centro de Adscripción<br />(Ubicación física del empleado)"><InsertItemTemplate><asp:DropDownList ID="ddlPlantelesEmpleado" runat="server" SkinID="SkinDropDownList" AutoPostBack="True"
                                        OnSelectedIndexChanged="ddlPlantelesEmpleado_SelectedIndexChanged"></asp:DropDownList><asp:CompareValidator ID="CVPlantelesEmpleado" runat="server"
                                                ControlToValidate="ddlPlantelesEmpleado" Display="Dynamic" ErrorMessage="Seleccione el centro de adscripción del empleado"
                                                Operator="NotEqual" ToolTip="Seleccione el centro de adscripción del empleado" Type="Integer"
                                                ValidationGroup="gpoGuarda" ValueToCompare="0">*</asp:CompareValidator></InsertItemTemplate><HeaderStyle HorizontalAlign="Left" Wrap="False" /><ItemStyle HorizontalAlign="Left" Wrap="False" /></asp:TemplateField>
                    
                            <asp:TemplateField HeaderText="Centro de Adscripción al que pertenece la Plaza<br />(Utilizado para pago)"><InsertItemTemplate><asp:DropDownList ID="ddlPlantelesPlaza" runat="server" SkinID="SkinDropDownList" AutoPostBack="True" 
                                        OnSelectedIndexChanged="ddlPlantelesPlaza_SelectedIndexChanged"></asp:DropDownList><asp:CompareValidator ID="CVPlantelesPlaza" runat="server"
                                                ControlToValidate="ddlPlantelesPlaza" Display="Dynamic" ErrorMessage="Seleccione el centro de adscripción de la plaza"
                                                Operator="NotEqual" ToolTip="Seleccione el centro de adscripción de la plaza" Type="Integer"
                                                ValidationGroup="gpoGuarda" ValueToCompare="0">*</asp:CompareValidator></InsertItemTemplate><HeaderStyle HorizontalAlign="Left" Wrap="False" /><ItemStyle HorizontalAlign="Left" Wrap="False" /></asp:TemplateField>
                    
                            <asp:TemplateField HeaderText="Categor&#237;a"><InsertItemTemplate><asp:DropDownList ID="ddlCategorias" runat="server" SkinID="SkinDropDownList" AutoPostBack="True"
                                                OnSelectedIndexChanged="ddlCategorias_SelectedIndexChanged"></asp:DropDownList><asp:CompareValidator ID="CVCategorias" runat="server"
                                                ControlToValidate="ddlCategorias" Display="Dynamic" ErrorMessage="Seleccione la categoría"
                                                Operator="NotEqual" ToolTip="Seleccione la categoría" Type="Integer"
                                                ValidationGroup="gpoGuarda" ValueToCompare="0">*</asp:CompareValidator></InsertItemTemplate><HeaderStyle  HorizontalAlign="Left" Wrap="False" /><ItemStyle HorizontalAlign="Left" Wrap="False" /></asp:TemplateField>

                            <asp:TemplateField HeaderText="Estatus"><InsertItemTemplate>
                            <asp:DropDownList ID="ddlPlazasEstatus" runat="server" SkinID="SkinDropDownList" AutoPostBack="True"
                                            OnSelectedIndexChanged="ddlPlazasEstatus_SelectedIndexChanged"></asp:DropDownList>
                            <asp:CompareValidator ID="CVPlazasEstatus" runat="server"
                                            ControlToValidate="ddlPlazasEstatus" Display="Dynamic" ErrorMessage="Seleccione el estatus"
                                            Operator="NotEqual" ToolTip="Seleccione el estatus" Type="Integer"
                                            ValidationGroup="gpoGuarda" ValueToCompare="0">*</asp:CompareValidator></InsertItemTemplate><HeaderStyle  HorizontalAlign="Left" Wrap="False" /><ItemStyle HorizontalAlign="Left" Wrap="False" /></asp:TemplateField>
                    
                            <asp:TemplateField HeaderText="Inicio"><InsertItemTemplate><asp:DropDownList ID="ddlQuincenaInicio" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlQuincenaInicio_SelectedIndexChanged"
                                        SkinID="SkinDropDownList"></asp:DropDownList><asp:CompareValidator ID="CVInicio" runat="server"
                                                ControlToValidate="ddlQuincenaInicio" Display="Dynamic" ErrorMessage="Seleccione la quincena de inicio"
                                                Operator="NotEqual" ToolTip="Seleccione la quincena de inicio" Type="Integer"
                                                ValidationGroup="gpoGuarda" ValueToCompare="0">*</asp:CompareValidator></InsertItemTemplate><HeaderStyle HorizontalAlign="Left" Wrap="False" /><ItemStyle HorizontalAlign="Left" Wrap="False" /></asp:TemplateField>
                            <asp:TemplateField HeaderText="T&#233;rmino"><InsertItemTemplate><asp:DropDownList ID="ddlQuincenaTermino" runat="server" SkinID="SkinDropDownList"
                                                AutoPostBack="True" OnSelectedIndexChanged="ddlQuincenaTermino_SelectedIndexChanged"></asp:DropDownList><asp:CompareValidator ID="CVVigencia" runat="server" ControlToCompare="ddlQuincenaInicio"
                                                ControlToValidate="ddlQuincenaTermino" Display="Dynamic" ErrorMessage="Vigencia incorrecta."
                                                Operator="GreaterThanEqual" ToolTip="Vigencia incorrecta." Type="Integer"
                                                ValidationGroup="gpoGuarda">*</asp:CompareValidator></InsertItemTemplate><HeaderStyle HorizontalAlign="Left" Wrap="False" /><ItemStyle HorizontalAlign="Left" Wrap="False" /></asp:TemplateField>
                            <asp:TemplateField HeaderText="Observaciones"><InsertItemTemplate><asp:textbox ID="txtObservaciones" runat="server" 
                                                AutoPostBack="True" Rows="2" TextMode="MultiLine" Width="300"></asp:textbox></InsertItemTemplate>
                                                <HeaderStyle HorizontalAlign="Left" Wrap="False" /><ItemStyle HorizontalAlign="Left" Wrap="False" /></asp:TemplateField>
                            <asp:TemplateField HeaderText="">
                                <InsertItemTemplate><asp:CheckBox ID="chkPermitirReasignacion" runat="server" Text="Permitir reasignación de titular" Font-Size="10" AutoPostBack="True"
                                        OnCheckedChanged="chkPermitirReasignacion_CheckedChanged"
                                        /></InsertItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" Wrap="False" />
                                <ItemStyle HorizontalAlign="Left" Wrap="False" />
                            </asp:TemplateField>
                       </Fields>
                </asp:DetailsView>
                    <asp:Panel ID="pnlDatos" runat="server" Width="100%" GroupingText="Plazas">
                                        <asp:GridView ID="gvDatos" runat="server" AutoGenerateColumns="False" EmptyDataText="No existe información."
                                            PageSize="20" SkinID="SkinGridView" Width="100%" OnSelectedIndexChanging="gvDatos_SelectedIndexChanging">
                                            <EmptyDataTemplate>
                                                <div>
                                                    <asp:Label ID="lblMsjSinPermisosEco" runat="server" Text="No existe información."></asp:Label>
                                                </div>
                                            </EmptyDataTemplate>
                                            <EmptyDataRowStyle Font-Italic="True" />
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="lnSelectPlaza" runat="server" ImageUrl="~/Imagenes/Select.png"
                                                            CausesValidation="false" ToolTip="Seleccionar registro" CommandName="Select" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Id"><ItemTemplate><asp:Label ID="lblIdPlazas" runat="server" Text='<%# Bind("IdPlazas") %>'></asp:Label></ItemTemplate><HeaderStyle HorizontalAlign="Center" /><ItemStyle HorizontalAlign="Center" /></asp:TemplateField>
                                                <asp:TemplateField HeaderText="Centro de Adscripción (Ubicación física del empleado)"><ItemTemplate><asp:Label ID="lbl2" runat="server" Text='<%# Bind("DescPlantelEmpleado") %>'></asp:Label></ItemTemplate><HeaderStyle HorizontalAlign="Center" /><ItemStyle HorizontalAlign="Center" /></asp:TemplateField>
                                                <asp:TemplateField HeaderText="Centro de Adscripción al que pertenece la Plaza (Utilizado para pago)"><ItemTemplate><asp:Label ID="lblPlazaEmp" runat="server" Text='<%# Bind("DescPlantelPlaza") %>'></asp:Label></ItemTemplate><HeaderStyle HorizontalAlign="Center" /><ItemStyle HorizontalAlign="Center" /></asp:TemplateField>
                                                <asp:TemplateField HeaderText="Categoría"><ItemTemplate><asp:Label ID="lbl3" runat="server" Text='<%# Bind("DescCategoria") %>'></asp:Label></ItemTemplate><HeaderStyle HorizontalAlign="Center" /><ItemStyle HorizontalAlign="Center" /></asp:TemplateField>
                                                <asp:TemplateField HeaderText="Estatus"><ItemTemplate><asp:Label ID="lbl4" runat="server" Text='<%# Bind("Estatus") %>'></asp:Label></ItemTemplate><HeaderStyle HorizontalAlign="Center" /><ItemStyle HorizontalAlign="Center" /></asp:TemplateField>
                                                <asp:TemplateField HeaderText="Quincena Inicio"><ItemTemplate><asp:Label ID="lblQuinInicio" runat="server" Text='<%# Bind("QuinInicio") %>'></asp:Label></ItemTemplate><HeaderStyle HorizontalAlign="Center" /><ItemStyle HorizontalAlign="Center" /></asp:TemplateField>
                                                <asp:TemplateField HeaderText="Quincena Termino"><ItemTemplate><asp:Label ID="lblQuinTermino" runat="server" Text='<%# Bind("QuinTermino") %>'></asp:Label></ItemTemplate><HeaderStyle HorizontalAlign="Center" /><ItemStyle HorizontalAlign="Center" /></asp:TemplateField>
                                                <asp:TemplateField HeaderText="Empleado Titular"><ItemTemplate><asp:Label ID="lblTitular" runat="server" Text='<%# Bind("NombT") %>'></asp:Label></ItemTemplate><HeaderStyle HorizontalAlign="Center" /><ItemStyle HorizontalAlign="Center" /></asp:TemplateField>
                                                <asp:TemplateField HeaderText="Observaciones"><ItemTemplate><asp:Label ID="lblObservaciones" runat="server" Text='<%# Bind("Observaciones") %>'></asp:Label></ItemTemplate><HeaderStyle HorizontalAlign="Center" /><ItemStyle HorizontalAlign="Center" /></asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="ibHistorial" runat="server" ImageUrl="~/Imagenes/detalles.gif" ToolTip="Ver historial." CommandName="HistorialPlaza" CommandArgument='<%# Container.DataItemIndex%>' />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                        <asp:TextBox  ID="hidIdPlazas" runat="server" BackColor="White" BorderColor="White" BorderWidth="0px" ForeColor="White" Width="1px" />
                                        <asp:TextBox  ID="hidIdTitular" runat="server" BackColor="White" BorderColor="White" BorderWidth="0px" ForeColor="White" Width="1px" text="0"/>
                                        <asp:RequiredFieldValidator ID="CVIdPlazas" runat="server"
                                                ControlToValidate="hidIdPlazas" Display="Dynamic" ErrorMessage="Seleccione la plaza a asignar como titular"
                                                ToolTip="Seleccione la plaza a asignar como titular" Type="Text"
                                                ValidationGroup="gpoGuarda" >*</asp:RequiredFieldValidator>
                                        <asp:CompareValidator ID="CVIdTitular" runat="server"
                                                ControlToValidate="hidIdTitular" Display="Dynamic" ErrorMessage="La plaza ya tiene titular"
                                                ToolTip="La plaza ya tiene titular" 
                                                ValidationGroup="gpoGuarda" ValueToCompare="0">*</asp:CompareValidator>
                                    </asp:Panel>
                                    <asp:Panel ID="TitlePanelHistorial" runat="server" BorderColor="White" BorderStyle="Solid"
                                                                BorderWidth="1px" CssClass="collapsePanelHeader" Width="100%" Visible="False">
                                                                <asp:Image ID="img1PlazasBase" runat="server" ImageUrl="~/Imagenes/expand_blue.jpg" />
                                                                &nbsp;Historial de Plazas base 
                                                                <asp:Label ID="lbl1PlazasBase" runat="server">(Mostrar detalles...)</asp:Label>
                                                            </asp:Panel>
                    <asp:Panel ID="PanelHistorial" runat="server" Width="100%" GroupingText="Historial">
                                        <asp:GridView ID="grdHistorial" runat="server" AutoGenerateColumns="False" EmptyDataText="No existe información."
                                            PageSize="20" SkinID="SkinGridView" Width="100%" >
                                            <EmptyDataTemplate>
                                                <div>
                                                    <asp:Label ID="lblSinHistorial" runat="server" Text="No existe información."></asp:Label>
                                                </div>
                                            </EmptyDataTemplate>
                                            <EmptyDataRowStyle Font-Italic="True" />
                                            <Columns>
                                                <asp:CommandField ButtonType="Image" SelectImageUrl="~/Imagenes/Select.png" ShowSelectButton="True"><ItemStyle HorizontalAlign="Center" /></asp:CommandField>
                                                <asp:TemplateField HeaderText="Id"><ItemTemplate><asp:Label ID="lblIdPlazas" runat="server" Text='<%# Bind("IdPlazas") %>'></asp:Label></ItemTemplate><HeaderStyle HorizontalAlign="Center" /><ItemStyle HorizontalAlign="Center" /></asp:TemplateField>
                                                <asp:TemplateField HeaderText="Centro de Adscripción (Ubicación física del empleado)"><ItemTemplate><asp:Label ID="lbl2" runat="server" Text='<%# Bind("DescPlantelEmpleado") %>'></asp:Label></ItemTemplate><HeaderStyle HorizontalAlign="Center" /><ItemStyle HorizontalAlign="Center" /></asp:TemplateField>
                                                <asp:TemplateField HeaderText="Centro de Adscripción al que pertenece la Plaza (Utilizado para pago)"><ItemTemplate><asp:Label ID="lblPlazaEmp" runat="server" Text='<%# Bind("DescPlantelPlaza") %>'></asp:Label></ItemTemplate><HeaderStyle HorizontalAlign="Center" /><ItemStyle HorizontalAlign="Center" /></asp:TemplateField>
                                                <asp:TemplateField HeaderText="Categoría"><ItemTemplate><asp:Label ID="lbl3" runat="server" Text='<%# Bind("DescCategoria") %>'></asp:Label></ItemTemplate><HeaderStyle HorizontalAlign="Center" /><ItemStyle HorizontalAlign="Center" /></asp:TemplateField>
                                                <asp:TemplateField HeaderText="Quincena Inicio"><ItemTemplate><asp:Label ID="lblQuinInicio" runat="server" Text='<%# Bind("QuinInicio") %>'></asp:Label></ItemTemplate><HeaderStyle HorizontalAlign="Center" /><ItemStyle HorizontalAlign="Center" /></asp:TemplateField>
                                                <asp:TemplateField HeaderText="Quincena Termino"><ItemTemplate><asp:Label ID="lblQuinTermino" runat="server" Text='<%# Bind("QuinTermino") %>'></asp:Label></ItemTemplate><HeaderStyle HorizontalAlign="Center" /><ItemStyle HorizontalAlign="Center" /></asp:TemplateField>
                                                <asp:TemplateField HeaderText="Observaciones"><ItemTemplate><asp:Label ID="lblObservaciones" runat="server" Text='<%# Bind("Observaciones") %>'></asp:Label></ItemTemplate><HeaderStyle HorizontalAlign="Center" /><ItemStyle HorizontalAlign="Center" /></asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="ibBaja" runat="server" ImageUrl="~/Imagenes/Eliminar.png" ToolTip="Quitar registro." CommandName="EliminarPlaza" CommandArgument='<%# Container.DataItemIndex%>' />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </asp:Panel>
                 <asp:DetailsView ID="dvBotones" runat="server" AutoGenerateRows="False" SkinID="SkinDetailsView"
                        DefaultMode="Insert" Width="100%">
                        <FieldHeaderStyle Width="250px" Wrap="True" />
                        <Fields>       
                            <asp:TemplateField ShowHeader="False"><EditItemTemplate><asp:Button ID="btnUpdTitularPlaza" runat="server" SkinID="SkinBoton" Text="Actualizar titular"
                                                ToolTip="Actualizar información " Visible="False" OnClick="btnUpdTitularPlaza_Click" /><ajaxToolkit:ConfirmButtonExtender ID="CBEbtnUpdTitularPlaza" runat="server" ConfirmText="¿Realmente desea actualizar la información del titular de la plaza?"
                                                TargetControlID="btnUpdTitularPlaza"></ajaxToolkit:ConfirmButtonExtender><br /><asp:Button ID="btnCancelar" runat="server" SkinID="SkinBoton" Text="Cancelar" CausesValidation="false"/><asp:Button ID="btnGuardar" runat="server" SkinID="SkinBoton" Text="Guardar" ToolTip="Guardar cambios"
                                        OnClick="btnGuardar_Click" ValidationGroup="gpoGuarda" /><ajaxToolkit:ConfirmButtonExtender ID="CBE" runat="server"
                                            TargetControlID="btnGuardar" ConfirmText="¿Está seguro de guardar los cambios realizados?"></ajaxToolkit:ConfirmButtonExtender><asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                                        ShowSummary="False" ValidationGroup="gpoGuarda" /></EditItemTemplate><ItemStyle HorizontalAlign="Right" /></asp:TemplateField>
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
        </asp:Panel>
    
    </ContentTemplate>
</asp:UpdatePanel>
</asp:Content>
               