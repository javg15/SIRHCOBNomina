<%@ page enableeventvalidation="false" language="VB" masterpagefile="~/MasterPageSesionIniciada.master" autoeventwireup="false" inherits="Consultas_Empleados_CargaHoraria, App_Web_00vntztu" title="COBAEV - Nómina - Carga horaria" stylesheettheme="SkinFile" maintainScrollPositionOnPostBack="true" %>
<%@ Register Src="~/WebControls/wucSearchEmps.ascx" TagName="wucBuscaEmpleados" TagPrefix="uc1" %>
<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress" TagPrefix="TP_wucUpdateProgress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
    <table style="width: 100%; vertical-align: top; text-align: center;" align="center">
        <tr>
            <td style="vertical-align: top; text-align: right">
                <h2>
                    Sistema de nómina: Empleados (Carga horaria semestral)
                </h2>
            </td>
        </tr>
    </table>
    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
        <ContentTemplate>
            <table style="width: 100%;" align="center">
                <tr>
                    <td style="vertical-align: top; text-align: left;">
                        <uc1:wucBuscaEmpleados ID="WucBuscaEmpleados1" runat="server" EnableViewState="true">
                        </uc1:wucBuscaEmpleados>
                    </td>
                    <td style="vertical-align: top; text-align: right;">
                        <asp:ImageButton ID="ibActualizar" runat="server" ImageUrl="~/Imagenes/Refresh.jpg"
                            ToolTip="Actualizar información" />
                    </td>
                </tr>
            </table>
            <table style="width: 100%; height: 300px;" align="center">
                <tr>
                    <td style="vertical-align: top; width: 100%; height: 100%; text-align: left">
                        <table style="width: 100%">
                            <tr>
                                <td style="width: 100%">
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                        <asp:Panel ID="pnl1" runat="server">
                                            <asp:Label ID="lblEmpInf" runat="server" SkinID="SkinLblDatos" Visible="False" Font-Strikeout="False"
                                                Font-Underline="True"></asp:Label>&nbsp;<asp:ImageButton ID="ibWarning" runat="server"
                                                    ImageUrl="~/Imagenes/Warning1.png" ToolTip="Haga click para visualizar un listado de observaciones sobre la carga horaria."
                                                    Visible="False" />
                                            <br />
                                            <asp:Panel ID="pnlSemestres" runat="server" Font-Size="X-Small" Font-Names="Verdana"
                                                DefaultButton="btnConsultarCargaHoraria" 
                                                GroupingText="Seleccione Semestre y/o Quincena">
                                                &nbsp;<table>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="Label5" runat="server" SkinID="SkinLblNormal" Text="Semestres"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlSemestres" runat="server" AutoPostBack="True" 
                                                                OnSelectedIndexChanged="ddlSemestres_SelectedIndexChanged" 
                                                                SkinID="SkinDropDownList">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td rowspan="3" style="vertical-align: bottom">
                                                            <asp:Button ID="btnConsultarCargaHoraria" runat="server" 
                                                                OnClick="btnConsultarCargaHoraria_Click" SkinID="SkinBoton" 
                                                                Text="Consultar carga horaria" 
                                                                ToolTip="Consultar carga horaria para el semestre y/o quincena seleccionado" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="Label6" runat="server" SkinID="SkinLblNormal" Text="Quincenas"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlQuincenas" runat="server" AutoPostBack="True" 
                                                                SkinID="SkinDropDownList" Enabled="False">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" style="text-align: left; vertical-align: bottom;">
                                                            <asp:CheckBox ID="chkbxCargaHorariaConHistoria" runat="server" SkinID="SkinCheckBox"
                                                                Text="Incluir historia completa durante el semestre" AutoPostBack="True" 
                                                                Checked="True" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                        </asp:Panel>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="ddlSemestres" EventName="SelectedIndexChanged" />
                                            <asp:AsyncPostBackTrigger ControlID="WucBuscaEmpleados1" EventName="PreRender" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                    <tr>
                        <td style="vertical-align: top; text-align: left">
                            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                <ContentTemplate>
                                <asp:Panel ID="PnlPlazas" runat="server">
                                    <ajaxToolkit:CollapsiblePanelExtender ID="CPEPlazasVigentes" runat="Server" CollapseControlID="TitlePanelPlazasVigentes"
                                        Collapsed="False" CollapsedImage="~/Imagenes/expand_blue.jpg" CollapsedText="(Mostrar detalles...)"
                                        ExpandControlID="TitlePanelPlazasVigentes" ExpandedImage="~/Imagenes/collapse_blue.jpg"
                                        ExpandedText="(Ocultar detalles...)" ImageControlID="Image1" SuppressPostBack="true"
                                        TargetControlID="ContentPanelPlazasVigentes" TextLabelID="Label1">
                                    </ajaxToolkit:CollapsiblePanelExtender>
                                    <table cellpadding="0" cellspacing="0" style="width: 100%">
                                        <tbody>
                                            <tr>
                                                <td style="vertical-align: top; width: 100%; text-align: left">
                                                    <asp:Panel ID="TitlePanelPlazasVigentes" runat="server" BorderColor="White" BorderStyle="Solid"
                                                        BorderWidth="1px" CssClass="collapsePanelHeader" Width="100%">
                                                        <asp:Image ID="Image3" runat="server" ImageUrl="~/Imagenes/expand_blue.jpg" />
                                                        Plazas vigentes durante el semestre
                                                        <asp:Label ID="Label4" runat="server">(Mostrar detalles...)</asp:Label>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="vertical-align: top; width: 100%; text-align: left">
                                                    <asp:Panel ID="ContentPanelPlazasVigentes" runat="server" CssClass="collapsePanel"
                                                        Width="100%">
                                                        <asp:GridView ID="gvPlazasVigentes" runat="server" EmptyDataText="Sin plazas vigentes durante el semestre seleccionado"
                                                            Height="100%" SkinID="SkinGridView" Width="100%">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="IdPlaza" Visible="False">
                                                                    <EditItemTemplate>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblIdPlaza" runat="server" Text='<%# Bind("IdPlaza") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Plaza(s)">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblPlazas" runat="server" Text='<%# Bind("Plazas") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <ItemStyle Wrap="false" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Ocup.">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblOcupacion" runat="server" Text='<%# Bind("AbrevTipoEmp") %>' ToolTip='<%# Bind("DescTipoEmp") %>'></asp:Label>
                                                                        <asp:Image ID="imgInfTitular" runat="server" 
                                                                            ImageUrl="~/Imagenes/UserInfo.jpg" />
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Sind.">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblSindicato" runat="server" Text='<%# Bind("SiglasSindicato") %>'
                                                                            ToolTip='<%# Bind("NombreSindicato") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Funci&#243;n primaria">
                                                                    <EditItemTemplate>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblNombreFuncionPri" runat="server" SkinID="SkinLblNormal" Text=""></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Funci&#243;n secundaria">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblNombreFuncionSec" runat="server" SkinID="SkinLblNormal" Text=""></asp:Label>
                                                                    </ItemTemplate>
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
                                                                <asp:BoundField DataField="Termino" HeaderText="Fin">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                                <asp:TemplateField HeaderText="Motivo de baja">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblMotGralBaja" runat="server" SkinID="SkinLblNormal"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField Visible="False">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="lbHistoriaPlaza" runat="server" SkinID="SkinLinkButton" ToolTip="Consultar información dehistórica de la plaza">Historia</asp:LinkButton>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <ItemTemplate>
                                                                        <asp:ImageButton ID="ibDetalles" runat="server" ImageUrl="~/Imagenes/Detalles.png"
                                                                            ToolTip="Consultar detalles de la estructura de la plaza." />
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField Visible="False">
                                                                    <ItemTemplate>
                                                                        <asp:ImageButton ID="ibModificar" runat="server" ImageUrl="~/Imagenes/Modificar.png"
                                                                            ToolTip="Modificar datos de la estructura de la plaza." />
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField Visible="False">
                                                                    <ItemTemplate>
                                                                        <asp:ImageButton ID="ibBaja" runat="server" ImageUrl="~/Imagenes/HandDown.png" ToolTip="Dar de baja la plaza." />
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <ItemTemplate>
                                                                        <asp:ImageButton ID="ibWarning" runat="server" ImageUrl="~/Imagenes/Warning1.png"
                                                                            ToolTip="Haga click para visualizar un listado de observaciones sobre la plaza." />
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                    </asp:Panel>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ibActualizar" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="WucBuscaEmpleados1" EventName="PreRender" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                            <tr>
                                <td style="width: 100%">
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                        <ContentTemplate>
                                        <asp:Panel ID="pnl2" runat="server">
                                            <ajaxToolkit:CollapsiblePanelExtender ID="CPECargaHoraria" runat="Server" CollapseControlID="TitlePanelCargaHoraria"
                                                Collapsed="False" CollapsedImage="~/Imagenes/expand_blue.jpg" CollapsedText="(Mostrar detalles...)"
                                                ExpandControlID="TitlePanelCargaHoraria" ExpandedImage="~/Imagenes/collapse_blue.jpg"
                                                ExpandedText="(Ocultar detalles...)" ImageControlID="Image1" SuppressPostBack="true"
                                                TargetControlID="ContentPanelCargaHoraria" TextLabelID="Label1">
                                            </ajaxToolkit:CollapsiblePanelExtender>
                                            <table style="width: 100%" cellspacing="0" cellpadding="0">
                                                <tbody>
                                                    <tr>
                                                        <td style="vertical-align: top; width: 100%; text-align: left">
                                                            <asp:Panel ID="TitlePanelCargaHoraria" runat="server" Width="100%" BorderWidth="1px"
                                                                BorderStyle="Solid" BorderColor="White" CssClass="collapsePanelHeader">
                                                                <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/expand_blue.jpg"></asp:Image>
                                                                &nbsp;Carga horaria asociada&nbsp;<asp:Label ID="Label1" runat="server">(Mostrar detalles...)</asp:Label>
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="vertical-align: top; width: 100%; text-align: left">
                                                            <asp:Panel ID="ContentPanelCargaHoraria" runat="server" Width="100%" CssClass="collapsePanel">
                                                                <table style="width: 100%" cellspacing="0" cellpadding="0">
                                                                    <tr>
                                                                        <td style="vertical-align: top; width: 100%; text-align: left">
                                                                            <asp:GridView ID="gvCargaHoraria" runat="server" Width="100%" SkinID="SkinGridViewEmpty"
                                                                                AutoGenerateColumns="False" EmptyDataText="No existe carga horaria para el semestre seleccionado"
                                                                                Height="100%">
                                                                                <Columns>
                                                                                    <asp:TemplateField HeaderText="IdHora">
                                                                                        <EditItemTemplate>
                                                                                        </EditItemTemplate>
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblIdHora" runat="server" Text='<%# Bind("IdHora") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Plantel">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblPlantel" runat="server" ToolTip='<%# Bind("NombrePlantel") %>'
                                                                                                Text='<%# Bind("ClavePlantel") %>' Visible="false"></asp:Label>
                                                                                            <asp:LinkButton ID="lbCvePlantel" runat="server" 
                                                                                                Text='<%# Bind("ClavePlantel") %>' 
                                                                                                ToolTip="Ver materias que se imparten en el plantel (Tomando como base el semestre seleccionado)"></asp:LinkButton>                                                                                            
                                                                                        </ItemTemplate>
                                                                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Materia">
                                                                                        <ItemTemplate>
                                                                                            <asp:LinkButton ID="lbNombreMateria" runat="server" 
                                                                                                Text='<%# Bind("NombreMateria") %>' 
                                                                                               ToolTip="Ver empleados que imparten la materia en el plantel (Tomando como base el semestre seleccionado)"></asp:LinkButton> 
                                                                                            <asp:Label ID="lblNombreMateria" runat="server" Text='<%# Bind("NombreMateria") %>' Visible="false"></asp:Label>
                                                                                        </ItemTemplate>
                                                                                        <HeaderStyle HorizontalAlign="Left" />
                                                                                        <ItemStyle HorizontalAlign="Left" />
                                                                                    </asp:TemplateField>
                                                                                    <asp:BoundField DataField="Horas" HeaderText="Horas">
                                                                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                                    </asp:BoundField>
                                                                                    <asp:TemplateField HeaderText="Grupo">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblGrupo" runat="server" Text='<%# Bind("Grupo") %>' Visible="false"></asp:Label>
                                                                                            <asp:LinkButton ID="lbGrupo" runat="server" 
                                                                                                Text='<%# Bind("Grupo") %>' 
                                                                                                ToolTip="Ver materias que se imparten en el plantel/grupo (Tomando como base el semestre seleccionado)"></asp:LinkButton>
                                                                                        </ItemTemplate>
                                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Tipo">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblTipoHora" runat="server" Text='<%# Bind("TipoHora") %>' ToolTip='<%# Bind("DescCategoria") %>' Visible="false"></asp:Label>
                                                                                            <asp:LinkButton ID="lbTipoHora" runat="server" 
                                                                                                Text='<%# Bind("TipoHora") %>'
                                                                                                ToolTip='<%# "Ver empleados con horas tipo " + Eval("DescCategoria") + " en el plantel (Tomando como base el semestre seleccionado)" %>'></asp:LinkButton>
                                                                                        </ItemTemplate>
                                                                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Estatus">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblEstatusHora" runat="server" ToolTip='<%# Bind("DescEstatus") %>'
                                                                                                Text='<%# Bind("AbrevEstatus") %>' Visible="false"></asp:Label>
                                                                                            <asp:LinkButton ID="lbEstatusHora" runat="server" 
                                                                                                Text='<%# Bind("AbrevEstatus") %>'
                                                                                                ToolTip='<%# "Ver empleados con horas en estatus de " + Eval("DescEstatus") + " en el plantel (Tomando como base el semestre seleccionado)" %>'></asp:LinkButton>
                                                                                        </ItemTemplate>
                                                                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                                    </asp:TemplateField>
                                                                                    <asp:BoundField DataField="ClaveCategoria" HeaderText="Clave categoría" 
                                                                                        Visible="False">
                                                                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField DataField="DescCategoria" HeaderText="Categoría" 
                                                                                        Visible="False">
                                                                                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                                        <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                                                    </asp:BoundField>
                                                                                    <asp:TemplateField HeaderText="Nombramiento">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblNombramiento" runat="server" Text='<%# Bind("AbrevNombramiento") %>'
                                                                                                ToolTip='<%# Bind("DescNombramiento") %>' Visible="false"></asp:Label>
                                                                                                <asp:LinkButton ID="lbNombramiento" runat="server" 
                                                                                                Text='<%# Bind("AbrevNombramiento") %>'
                                                                                                ToolTip='<%# "Ver empleados con horas con nombramiento " + Eval("DescNombramiento") + " en el plantel (Tomando como base el semestre seleccionado)" %>'></asp:LinkButton>
                                                                                            <asp:Image ID="imgInfTitular" runat="server" ImageUrl="~/Imagenes/UserInfo.jpg" />
                                                                                        </ItemTemplate>
                                                                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="N&#243;mina">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblTipoNomina" runat="server" Text='<%# Bind("AbrevTipoNomina") %>'
                                                                                                ToolTip='<%# Bind("DescTipoNomina") %>' Visible="false"></asp:Label>
                                                                                                <asp:LinkButton ID="lbTipoNomina" runat="server" 
                                                                                                Text='<%# Bind("AbrevTipoNomina") %>'
                                                                                                ToolTip='<%# "Ver empleados con horas y tipo de nómina " + Eval("DescTipoNomina") + " en el plantel (Tomando como base el semestre seleccionado)" %>'></asp:LinkButton>
                                                                                        </ItemTemplate>
                                                                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                                    </asp:TemplateField>
                                                                                    <asp:BoundField DataField="Semestre" HeaderText="Semestre" Visible="False">
                                                                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField DataField="QnaIni" HeaderText="Inicio">
                                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField DataField="QnaFin" HeaderText="Fin">
                                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                                    </asp:BoundField>
                                                                                    <asp:TemplateField>
                                                                                        <ItemTemplate>
                                                                                            <asp:ImageButton ID="ibEliminar" runat="server" ImageUrl="~/Imagenes/Eliminar.png"
                                                                                                ToolTip="Eliminar registro de ésta hora" CommandName="Eliminar" OnClick="ibEliminar_Click" /><ajaxToolkit:ConfirmButtonExtender
                                                                                                    ID="CFEEliminaPerc" runat="server" ConfirmText="¿Está seguro de eliminar la hora?"
                                                                                                    TargetControlID="ibEliminar">
                                                                                                </ajaxToolkit:ConfirmButtonExtender>
                                                                                        </ItemTemplate>
                                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField>
                                                                                        <ItemTemplate>
                                                                                            <asp:ImageButton ID="ibAddHoras" runat="server" ImageUrl="~/Imagenes/Copiar.png"
                                                                                                ToolTip="Asignar nuevas horas a partir de este registro" CommandName="Copiar" />
                                                                                        </ItemTemplate>
                                                                                        <ItemStyle HorizontalAlign="Center" Wrap="True"></ItemStyle>
                                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField>
                                                                                        <ItemTemplate>
                                                                                            <asp:ImageButton ID="ibModificar" runat="server" ImageUrl="~/Imagenes/Modificar.png"
                                                                                                ToolTip="Modificar información de este registro" CommandName="Modificar" />
                                                                                        </ItemTemplate>
                                                                                        <ItemStyle HorizontalAlign="Center" Wrap="False"></ItemStyle>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField>
                                                                                        <ItemTemplate>
                                                                                            <asp:ImageButton ID="ibRemplazar" runat="server" ImageUrl="~/Imagenes/Replace.png"
                                                                                                ToolTip="Reemplazar horas interinamente" CommandName="Reemplazar" />
                                                                                        </ItemTemplate>
                                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="IdGrupo" Visible="false">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblIdGrupo" runat="server" Text='<%# Bind("IdGrupo") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="IdPlantel" Visible="false">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblIdPlantel" runat="server" Text='<%# Bind("IdPlantel") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="IdMateria" Visible="false">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblIdMateria" runat="server" Text='<%# Bind("IdMateria") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Mapa Curricular" Visible="false">
                                                                                        <ItemTemplate>
                                                                                            <asp:CheckBox Enabled="false" ID="chkbxMapaCurricular" runat="server"  Checked='<%# Bind("MapaCurricular") %>'></asp:CheckBox>
                                                                                        </ItemTemplate>
                                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField>
                                                                                        <ItemTemplate>
                                                                                            <asp:ImageButton ID="ibDetalles" runat="server" ImageUrl="~/Imagenes/Detalles.png"
                                                                                                ToolTip="Consultar información detallada de éste registro." />
                                                                                        </ItemTemplate>
                                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                                    </asp:TemplateField>
                                                                                </Columns>
                                                                                <EmptyDataTemplate>
                                                                                    <asp:LinkButton ID="lbNuevaCargaHoraria" runat="server" ToolTip="Crear nueva carga horaria"
                                                                                        SkinID="SkinLinkButton">Nueva carga horaria</asp:LinkButton>
                                                                                    <asp:Label ID="lblMsjgvVacio" runat="server" Font-Italic="True" SkinID="SkinLblMsjErrores"
                                                                                        Text="Label" Visible="False"></asp:Label>
                                                                                </EmptyDataTemplate>
                                                                            </asp:GridView>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="vertical-align: top; width: 100%; text-align: left">
                                                                            <asp:LinkButton ID="lbNuevaCargaHoraria" runat="server" ToolTip="Crear nueva carga horaria basada en la mostrada actualmente"
                                                                                SkinID="SkinLinkButton" Visible="False">Nueva carga horaria</asp:LinkButton>
                                                                            &nbsp;<ajaxToolkit:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server"
                                                                                TargetControlID="lbNuevaCargaHoraria" ConfirmText="¿Está seguro de crear la nueva carga horaria?">
                                                                            </ajaxToolkit:ConfirmButtonExtender>
                                                                        </td>
                                                                    </tr>
                                                                    <tr style="text-align: left;">
                                                                        <td style="vertical-align: top; width: 100%; height: 19px; text-align: left;">
                                                                            <asp:GridView ID="gvResumen1" runat="server" AutoGenerateColumns="False" Caption="Resumen" CaptionAlign="Left"
                                                                                SkinID="SkinGridView" EmptyDataText="Resumen no disponible.">
                                                                                <Columns>
                                                                                    <asp:BoundField DataField="TotalHoras" HeaderText="Total horas">
                                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                                    </asp:BoundField>
                                                                                    <asp:TemplateField HeaderText="Nombramiento">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblNombramiento" runat="server" Text='<%# Bind("AbrevNombramiento") %>'
                                                                                                ToolTip='<%# Bind("DescNombramiento") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                                    </asp:TemplateField>
                                                                                    <asp:BoundField DataField="QnaFin" HeaderText="Quincena de referencia">
                                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                                    </asp:BoundField>
                                                                                </Columns>
                                                                            </asp:GridView>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="vertical-align: top; width: 100%; height: 19px; text-align: left">
                                                                            <asp:GridView ID="gvCargaHorariaInterina" runat="server" AutoGenerateColumns="False"
                                                                                Caption="Carga horaria interina del semestre anterior del mismo tipo" CaptionAlign="Left"
                                                                                EmptyDataText="No se encontraron registros."
                                                                                Height="100%" SkinID="SkinGridView" Width="100%">
                                                                                <Columns>
                                                                                    <asp:TemplateField HeaderText="IdHora">
                                                                                        <EditItemTemplate>
                                                                                        </EditItemTemplate>
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblIdHora" runat="server" Text='<%# Bind("IdHora") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Plantel">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblPlantel0" runat="server" Text='<%# Bind("ClavePlantel") %>' ToolTip='<%# Bind("NombrePlantel") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                                    </asp:TemplateField>
                                                                                    <asp:BoundField DataField="NombreMateria" HeaderText="Materia">
                                                                                        <HeaderStyle HorizontalAlign="Left" />
                                                                                        <ItemStyle HorizontalAlign="Left" />
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField DataField="Horas" HeaderText="Horas">
                                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField DataField="Grupo" HeaderText="Grupo">
                                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                                    </asp:BoundField>
                                                                                    <asp:TemplateField HeaderText="Tipo">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblTipoHora0" runat="server" Text='<%# Bind("TipoHora") %>' ToolTip='<%# Bind("DescCategoria") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Estatus">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblEstatusHora0" runat="server" Text='<%# Bind("AbrevEstatus") %>'
                                                                                                ToolTip='<%# Bind("DescEstatus") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                                    </asp:TemplateField>
                                                                                    <asp:BoundField DataField="ClaveCategoria" HeaderText="Clave categoría" Visible="False">
                                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField DataField="DescCategoria" HeaderText="Categoría" Visible="False">
                                                                                        <HeaderStyle HorizontalAlign="Left" />
                                                                                        <ItemStyle HorizontalAlign="Left" />
                                                                                    </asp:BoundField>
                                                                                    <asp:TemplateField HeaderText="Nombramiento">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblNombramientoI" runat="server" Text='<%# Bind("AbrevNombramiento") %>'
                                                                                                ToolTip='<%# Bind("DescNombramiento") %>'></asp:Label>
                                                                                                <asp:Image ID="imgInfTitularI" runat="server" ImageUrl="~/Imagenes/UserInfo.jpg" />
                                                                                        </ItemTemplate>
                                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Nómina">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblTipoNomina0" runat="server" Text='<%# Bind("AbrevTipoNomina") %>'
                                                                                                ToolTip='<%# Bind("DescTipoNomina") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                                    </asp:TemplateField>
                                                                                    <asp:BoundField DataField="Semestre" HeaderText="Semestre" Visible="False">
                                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField DataField="QnaIni" HeaderText="Inicio">
                                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField DataField="QnaFin" HeaderText="Fin">
                                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                                    </asp:BoundField>
                                                                                    <asp:TemplateField>
                                                                                        <ItemTemplate>
                                                                                            <asp:ImageButton ID="ibAddHora" runat="server" CommandName="Copiar" ImageUrl="~/Imagenes/Add2.png"
                                                                                                ToolTip="Agregar registro a carga horaria del semestre." 
                                                                                                style="width: 16px" />
                                                                                            <ajaxToolkit:ConfirmButtonExtender ID="ibAddHora_ConfirmButtonExtender" runat="server"
                                                                                                ConfirmText="¿Realmente desea agregar el registro a la carga horaria del empleado?"
                                                                                                Enabled="True" TargetControlID="ibAddHora">
                                                                                            </ajaxToolkit:ConfirmButtonExtender>
                                                                                        </ItemTemplate>
                                                                                        <ItemStyle HorizontalAlign="Center" Wrap="True" />
                                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                                    </asp:TemplateField>
                                                                                </Columns>
                                                                            </asp:GridView>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                            </asp:Panel>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="btnConsultarCargaHoraria" EventName="Click" />
                                            <asp:AsyncPostBackTrigger ControlID="gvCargaHoraria" EventName="RowDataBound" />
                                            <asp:AsyncPostBackTrigger ControlID="WucBuscaEmpleados1" EventName="PreRender" />
                                            <asp:AsyncPostBackTrigger ControlID="ddlSemestres" EventName="SelectedIndexChanged" />
                                            <asp:AsyncPostBackTrigger ControlID="gvCargaHorariaInterina" EventName="RowDataBound" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 100%">
                                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                        <ContentTemplate>
                                        <asp:Panel ID="pnl3" runat="server">
                                            <ajaxToolkit:CollapsiblePanelExtender ID="CPECargaHorariaAnexa" runat="Server" CollapseControlID="TitlePanelCargaHorariaAnexa"
                                                Collapsed="False" CollapsedImage="~/Imagenes/expand_blue.jpg" CollapsedText="(Mostrar detalles...)"
                                                ExpandControlID="TitlePanelCargaHorariaAnexa" ExpandedImage="~/Imagenes/collapse_blue.jpg"
                                                ExpandedText="(Ocultar detalles...)" ImageControlID="Image2" SuppressPostBack="true"
                                                TargetControlID="ContentPanelCargaHorariaAnexa" TextLabelID="Label3">
                                            </ajaxToolkit:CollapsiblePanelExtender>
                                            <table style="width: 100%" cellspacing="0" cellpadding="0">
                                                <tbody>
                                                    <tr>
                                                        <td style="vertical-align: top; width: 100%; text-align: left">
                                                            <table style="width: 100%" cellspacing="0" cellpadding="0">
                                                                <tr>
                                                                    <td style="vertical-align: top; width: 100%; text-align: left" colspan="2">
                                                                        <asp:Panel ID="TitlePanelCargaHorariaAnexa" runat="server" Width="100%" BorderWidth="1px"
                                                                            BorderStyle="Solid" BorderColor="White" CssClass="collapsePanelHeader">
                                                                            <asp:Image ID="Image2" runat="server" ImageUrl="~/Imagenes/expand_blue.jpg" />
                                                                            Carga horaria cubierta con horas de definitivas de Descarga, CISCO, DIES, EMSAD<asp:Label
                                                                                ID="Label3" runat="server">(Mostrar detalles...)</asp:Label>
                                                                        </asp:Panel>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="vertical-align: top; width: 100%; text-align: left" colspan="2">
                                                                        <asp:Panel ID="ContentPanelCargaHorariaAnexa" runat="server" Width="100%" CssClass="collapsePanel">
                                                                            <table style="width: 100%" cellspacing="0" cellpadding="0">
                                                                                <tr>
                                                                                    <td style="vertical-align: top; width: 100%; text-align: left" colspan="2">
                                                                                        <asp:GridView ID="gvCargaHorariaAnexa" runat="server" Width="100%" SkinID="SkinGridView"
                                                                                            AutoGenerateColumns="False" EmptyDataText="No existe carga horaria anexa." Height="100%"
                                                                                            OnRowDataBound="gvCargaHorariaAnexa_RowDataBound">
                                                                                            <Columns>
                                                                                                <asp:TemplateField HeaderText="IdHora">
                                                                                                    <EditItemTemplate>
                                                                                                    </EditItemTemplate>
                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="lblIdHora" runat="server" Text='<%# Bind("IdHora") %>'></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="Plantel">
                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="lblPlantel" runat="server" Text='<%# Bind("ClavePlantel") %>' 
                                                                                                            ToolTip='<%# Bind("NombrePlantel") %>' Visible="True"></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                                                </asp:TemplateField>
                                                                                                <asp:BoundField DataField="NombreMateria" HeaderText="Materia">
                                                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                                                </asp:BoundField>
                                                                                                <asp:BoundField DataField="Horas" HeaderText="Horas">
                                                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                                                </asp:BoundField>
                                                                                                <asp:BoundField DataField="Grupo" HeaderText="Grupo">
                                                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                                                </asp:BoundField>
                                                                                                <asp:TemplateField HeaderText="Tipo">
                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="lblTipoHora" runat="server" Text='<%# Bind("TipoHora") %>' ToolTip='<%# Bind("DescCategoria") %>'></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="Estatus">
                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="lblEstatusHora" runat="server" Text='<%# Bind("AbrevEstatus") %>'
                                                                                                            ToolTip='<%# Bind("DescEstatus") %>'></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                                                </asp:TemplateField>
                                                                                                <asp:BoundField DataField="ClaveCategoria" HeaderText="Clave categor&#237;a" Visible="False">
                                                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                                                </asp:BoundField>
                                                                                                <asp:BoundField DataField="DescCategoria" HeaderText="Categor&#237;a" Visible="False">
                                                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                                                </asp:BoundField>
                                                                                                <asp:TemplateField HeaderText="Nombramiento">
                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="lblNombramiento" runat="server" Text='<%# Bind("AbrevNombramiento") %>'
                                                                                                            ToolTip='<%# Bind("DescNombramiento") %>'></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="N&#243;mina">
                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="lblTipoNomina" runat="server" Text='<%# Bind("AbrevTipoNomina") %>'
                                                                                                            ToolTip='<%# Bind("DescTipoNomina") %>'></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                                                </asp:TemplateField>
                                                                                                <asp:BoundField DataField="Semestre" HeaderText="Semestre" Visible="False">
                                                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                                                </asp:BoundField>
                                                                                                <asp:BoundField DataField="QnaIni" HeaderText="Inicio">
                                                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                                                </asp:BoundField>
                                                                                                <asp:BoundField DataField="QnaFin" HeaderText="Fin">
                                                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                                                </asp:BoundField>
                                                                                                <asp:TemplateField HeaderText="IdHora Asociada">
                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="lblIdHoraAsoc" runat="server" Text='<%# Bind("IdHoraAsoc") %>'></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField>
                                                                                                    <ItemTemplate>
                                                                                                        <asp:ImageButton ID="ibEliminar" runat="server" ImageUrl="~/Imagenes/Eliminar.png"
                                                                                                            ToolTip="Eliminar registro de ésta hora" CommandName="Eliminar" OnClick="ibEliminar_Click1" /><ajaxToolkit:ConfirmButtonExtender
                                                                                                                ID="CFEEliminaPerc" runat="server" ConfirmText="¿Está seguro de eliminar la hora?"
                                                                                                                TargetControlID="ibEliminar">
                                                                                                            </ajaxToolkit:ConfirmButtonExtender>
                                                                                                    </ItemTemplate>
                                                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField>
                                                                                                    <ItemTemplate>
                                                                                                        <asp:ImageButton ID="ibModificar" runat="server" ImageUrl="~/Imagenes/Modificar.png"
                                                                                                            ToolTip="Modificar información de este registro" />
                                                                                                    </ItemTemplate>
                                                                                                    <ItemStyle HorizontalAlign="Center" Wrap="False" />
                                                                                                </asp:TemplateField>
                                                                                            </Columns>
                                                                                            <EmptyDataTemplate>
                                                                                                &nbsp;
                                                                                            </EmptyDataTemplate>
                                                                                        </asp:GridView>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="vertical-align: top; width: 100%; text-align: left" colspan="2">
                                                                                        <asp:GridView ID="gvResumen2" runat="server" AutoGenerateColumns="False" Caption="Resumen"
                                                                                            SkinID="SkinGridView" EmptyDataText="Resumen de carga horaria anexa no disponible.">
                                                                                            <Columns>
                                                                                                <asp:BoundField DataField="TotalHoras" HeaderText="Total horas">
                                                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                                                </asp:BoundField>
                                                                                                <asp:TemplateField HeaderText="Nombramiento">
                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="lblNombramiento" runat="server" Text='<%# Bind("AbrevNombramiento") %>'
                                                                                                            ToolTip='<%# Bind("DescNombramiento") %>'></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                                                </asp:TemplateField>
                                                                                            </Columns>
                                                                                        </asp:GridView>
                                                                                    </td>
                                                                                </tr>
                                                                        </asp:Panel>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                            </asp:Panel>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="btnConsultarCargaHoraria" EventName="Click" />
                                            <asp:AsyncPostBackTrigger ControlID="gvCargaHorariaAnexa" EventName="RowDataBound" />
                                            <asp:AsyncPostBackTrigger ControlID="WucBuscaEmpleados1" EventName="PreRender" />
                                            <asp:AsyncPostBackTrigger ControlID="ddlSemestres" EventName="SelectedIndexChanged" />
                                            <asp:AsyncPostBackTrigger ControlID="gvCargaHorariaInterina" EventName="RowDataBound" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="ibActualizar" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
    <br />
</asp:Content>
