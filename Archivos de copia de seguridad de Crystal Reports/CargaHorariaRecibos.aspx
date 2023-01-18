<%@ Page EnableEventValidation="false" Language="VB" MasterPageFile="~/MasterPageSesionIniciada.master"  AutoEventWireup="false" CodeFile="CargaHorariaRecibos.aspx.vb" Inherits="Consultas_Empleados_CargaHorariaRecibos" title="COBAEV - Nómina - Carga horaria recibos" StylesheetTheme="SkinFile" %>
<%@ Register Src="~/WebControls/wucBuscaEmpleados.ascx" TagName="wucBuscaEmpleados" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <div>
        <script type="text/javascript" src="../../jsUpdateProgress.js"></script>	
       <script type="text/javascript" language="javascript">
		var ModalProgress = '<%= ModalProgress.ClientID %>';         
    </script>	
		<asp:Panel ID="panelUpdateProgress" runat="server" CssClass="updateProgress" Width="400px" style="left: 0px; top: 0px">
			<asp:UpdateProgress ID="UpdateProg1" DisplayAfter="0" runat="server">
				<ProgressTemplate>
					<div style="position: relative; top: 30%; text-align: center;">
						<img src="../../Imagenes/Spinner2.gif" style="vertical-align: middle" alt="Processing" />
                        <asp:Label ID="lblUpdProg" runat="server" SkinID="SkinLblMsjExito" Text="Actualizando datos, por favor espere..."></asp:Label></div>
				</ProgressTemplate>
			</asp:UpdateProgress>
		</asp:Panel>
		<ajaxToolkit:ModalPopupExtender ID="ModalProgress" runat="server" TargetControlID="panelUpdateProgress"
			BackgroundCssClass="modalBackground" PopupControlID="panelUpdateProgress" />
    </div>

    <table style="width: 100%; height: 300px;">
        <tr>
            <td style="vertical-align: top; width: 100%; height: 100%; text-align: left">
                <table style="width: 100%">
                    <tr>
                        <td style="width: 100%">
                <table style="width: 100%;">
                    <tr>
                        <td style="vertical-align: top; text-align: left;">
                            <uc1:wucbuscaempleados id="WucBuscaEmpleados1" runat="server" enableviewstate="true"></uc1:wucbuscaempleados>
                        </td>
                        <td style="vertical-align: top; text-align: right;">
                            <asp:ImageButton ID="ibActualizar" runat="server" ImageUrl="~/Imagenes/Refresh.jpg"
                                ToolTip="Actualizar información" /></td>
                    </tr>
                </table>
                            <asp:UpdateProgress id="UpdateProgress1" runat="server" Visible="False">
                                <progresstemplate>
<asp:Image id="Image4" runat="server" ImageUrl="~/Imagenes/spinner.gif"></asp:Image>&nbsp;<asp:Label id="Label4" runat="server" Text="Actualizando..." SkinID="SkinLblDatos"></asp:Label>
</progresstemplate>
                            </asp:UpdateProgress>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100%">
                            <asp:UpdatePanel id="UpdatePanel1" runat="server">
                                <contenttemplate>
<asp:Label id="lblEmpInf" runat="server" SkinID="SkinLblDatos" Visible="False" Font-Strikeout="False" Font-Underline="True"></asp:Label><BR /><asp:Panel id="pnlSemestres" runat="server" Font-Size="X-Small" Font-Names="Verdana" DefaultButton="btnConsultarCargaHoraria" GroupingText="Seleccione semestre">
    &nbsp;<table>
        <tr>
            <td>
                <asp:DropDownList id="ddlSemestres" runat="server" SkinID="SkinDropDownList" AutoPostBack="True" OnSelectedIndexChanged="ddlSemestres_SelectedIndexChanged"></asp:DropDownList>&nbsp;<asp:Button id="btnConsultarCargaHoraria" runat="server" ToolTip="Consultar carga horaria para el semestre seleccionado" SkinID="SkinBoton" Text="Carga horaria" OnClick="btnConsultarCargaHoraria_Click"></asp:Button></td>
        </tr>
        <tr>
            <td>
                <asp:CheckBox ID="chkbxCargaHorariaConHistoria" runat="server" Enabled="False" SkinID="SkinCheckBox"
                    Text="Incluir historia completa durante el semestre" /></td>
        </tr>
    </table>
</asp:Panel> 
</contenttemplate>
                                <triggers>
<asp:AsyncPostBackTrigger ControlID="ibActualizar" EventName="Click"></asp:AsyncPostBackTrigger>
                                    <asp:AsyncPostBackTrigger ControlID="ddlSemestres" EventName="SelectedIndexChanged" />
</triggers>
                            </asp:UpdatePanel></td>
                    </tr>
                    <tr>
                        <td style="width: 100%">
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
<ajaxToolkit:CollapsiblePanelExtender id="CPECargaHoraria" runat="Server" CollapseControlID="TitlePanelCargaHoraria" Collapsed="False" CollapsedImage="~/Imagenes/expand_blue.jpg" CollapsedText="(Mostrar detalles...)" ExpandControlID="TitlePanelCargaHoraria" ExpandedImage="~/Imagenes/collapse_blue.jpg" ExpandedText="(Ocultar detalles...)" ImageControlID="Image1" SuppressPostBack="true" TargetControlID="ContentPanelCargaHoraria" TextLabelID="Label1">
                                    </ajaxToolkit:CollapsiblePanelExtender> 
                                    <TABLE style="WIDTH: 100%" cellSpacing=0 cellPadding=0>
                                    <TBODY><TR>
                                    <TD style="VERTICAL-ALIGN: top; WIDTH: 100%; TEXT-ALIGN: left" colSpan=2><asp:Panel id="TitlePanelCargaHoraria" runat="server" Width="100%" BorderWidth="1px" BorderStyle="Solid" BorderColor="White" CssClass="collapsePanelHeader"><asp:Image id="Image1" runat="server" ImageUrl="~/Imagenes/expand_blue.jpg">
                                    </asp:Image>&nbsp;Carga horaria&nbsp;<asp:Label id="Label1" runat="server">(Mostrar detalles...)</asp:Label> </asp:Panel> </TD></TR><TR><TD style="VERTICAL-ALIGN: top; WIDTH: 100%; TEXT-ALIGN: left" colSpan=2>
                                    <asp:Panel id="ContentPanelCargaHoraria" runat="server" Width="100%" CssClass="collapsePanel">
            <asp:GridView id="gvCargaHoraria" runat="server" Width="100%" SkinID="SkinGridViewEmpty" AutoGenerateColumns="False" EmptyDataText="No existe carga horaria para el semestre seleccionado" Height="100%"><Columns>
<asp:TemplateField HeaderText="IdHora"><EditItemTemplate> 
</EditItemTemplate>
<ItemTemplate>
<asp:Label id="lblIdHora" runat="server" Text='<%# Bind("IdHora") %>'></asp:Label> 
</ItemTemplate>
    <HeaderStyle HorizontalAlign="Center" />
    <ItemStyle HorizontalAlign="Center" />
</asp:TemplateField>
<asp:TemplateField HeaderText="Plantel"><ItemTemplate>
<asp:Label id="lblPlantel" runat="server" ToolTip='<%# Bind("NombrePlantel") %>' Text='<%# Bind("ClavePlantel") %>'></asp:Label> 
</ItemTemplate>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
</asp:TemplateField>
<asp:BoundField DataField="NombreMateria" HeaderText="Materia">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Horas" HeaderText="Horas">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Grupo" HeaderText="Grupo">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
</asp:BoundField>
<asp:TemplateField HeaderText="Tipo"><ItemTemplate>
                    <asp:Label ID="lblTipoHora" runat="server" Text='<%# Bind("TipoHora") %>' ToolTip='<%# Bind("DescCategoria") %>'></asp:Label>
                
</ItemTemplate>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Estatus"><ItemTemplate>
<asp:Label id="lblEstatusHora" runat="server" ToolTip='<%# Bind("DescEstatus") %>' Text='<%# Bind("AbrevEstatus") %>'></asp:Label>
</ItemTemplate>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
</asp:TemplateField>
<asp:BoundField DataField="ClaveCategoria" HeaderText="Clave categor&#237;a" Visible="False">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="DescCategoria" HeaderText="Categor&#237;a" Visible="False">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:TemplateField HeaderText="Nombramiento"><ItemTemplate>
                    <asp:Label ID="lblNombramiento" runat="server" Text='<%# Bind("AbrevNombramiento") %>'
                        ToolTip='<%# Bind("DescNombramiento") %>'></asp:Label>
                
</ItemTemplate>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="N&#243;mina"><ItemTemplate>
                    <asp:Label ID="lblTipoNomina" runat="server" Text='<%# Bind("AbrevTipoNomina") %>'
                        ToolTip='<%# Bind("DescTipoNomina") %>'></asp:Label>
                
</ItemTemplate>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
</asp:TemplateField>
<asp:BoundField DataField="Semestre" HeaderText="Semestre">
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
                            ToolTip="Eliminar registro de ésta hora" CommandName="Eliminar" /><ajaxToolkit:ConfirmButtonExtender ID="CFEEliminaPerc"
                                runat="server" ConfirmText="¿Está seguro de eliminar la hora?" TargetControlID="ibEliminar">
                            </ajaxToolkit:ConfirmButtonExtender>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
<asp:TemplateField><ItemTemplate>
    <asp:ImageButton ID="ibAddHoras" runat="server" ImageUrl="~/Imagenes/Copiar.png" ToolTip="Asignar nuevas horas a partir de este registro" />
    
</ItemTemplate>

<ItemStyle HorizontalAlign="Center" Wrap="True"></ItemStyle>
    <HeaderStyle HorizontalAlign="Center" />
</asp:TemplateField>
<asp:TemplateField><ItemTemplate>
    <asp:ImageButton ID="ibModificar" runat="server" ImageUrl="~/Imagenes/Modificar.png"
        ToolTip="Modificar información de este registro" />
</ItemTemplate>

<ItemStyle HorizontalAlign="Center" Wrap="False"></ItemStyle>
</asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="ibRemplazar" runat="server" ImageUrl="~/Imagenes/Replace.png"
        ToolTip="Reemplazar horas interinamente" />
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
</Columns>
<EmptyDataTemplate>
<asp:LinkButton id="lbNuevaCargaHoraria" runat="server" ToolTip="Crear nueva carga horaria" SkinID="SkinLinkButton">Nueva carga horaria</asp:LinkButton> 
</EmptyDataTemplate>
</asp:GridView>
            </asp:Panel> </TD></TR><TR><TD style="VERTICAL-ALIGN: top; WIDTH: 100%; TEXT-ALIGN: left" colSpan=2><asp:LinkButton id="lbNuevaCargaHoraria" runat="server" ToolTip="Crear nueva carga horaria basada en la mostrada actualmente" SkinID="SkinLinkButton" Visible="False">Nueva carga horaria</asp:LinkButton> <ajaxToolkit:ConfirmButtonExtender id="ConfirmButtonExtender1" runat="server" TargetControlID="lbNuevaCargaHoraria" ConfirmText="¿Está seguro de crear la nueva carga horaria?"></ajaxToolkit:ConfirmButtonExtender></TD></TR>
                                        <tr>
                                            <td colspan="2" style="vertical-align: top; width: 100%; height: 19px; text-align: left">
                                                <asp:GridView ID="gvResumen1" runat="server" AutoGenerateColumns="False" Caption="Resumen"
                                                    SkinID="SkinGridView">
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
                                    </TBODY></TABLE>
</ContentTemplate>
                                <Triggers>
<asp:AsyncPostBackTrigger ControlID="btnConsultarCargaHoraria" EventName="Click"></asp:AsyncPostBackTrigger>
                                    <asp:AsyncPostBackTrigger ControlID="gvCargaHoraria" EventName="RowCommand" />
</Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100%"><asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>
                                <ajaxToolkit:CollapsiblePanelExtender id="CPECargaHorariaAnexa" runat="Server" CollapseControlID="TitlePanelCargaHorariaAnexa" Collapsed="False" CollapsedImage="~/Imagenes/expand_blue.jpg" CollapsedText="(Mostrar detalles...)" ExpandControlID="TitlePanelCargaHorariaAnexa" ExpandedImage="~/Imagenes/collapse_blue.jpg" ExpandedText="(Ocultar detalles...)" ImageControlID="Image2" SuppressPostBack="true" TargetControlID="ContentPanelCargaHorariaAnexa" TextLabelID="Label3">
                                </ajaxToolkit:CollapsiblePanelExtender>
                                <TABLE style="WIDTH: 100%" cellSpacing=0 cellPadding=0>
                                    <TBODY>
                                        <TR>
                                            <TD style="VERTICAL-ALIGN: top; WIDTH: 100%; TEXT-ALIGN: left" colSpan=2>
                                                <asp:Panel id="TitlePanelCargaHorariaAnexa" runat="server" Width="100%" BorderWidth="1px" BorderStyle="Solid" BorderColor="White" CssClass="collapsePanelHeader">
                                                    <asp:Image ID="Image2" runat="server" ImageUrl="~/Imagenes/expand_blue.jpg" />
                                                    Carga horaria cubierta con horas de definitivas de Descarga, CISCO, DIES, EMSAD<asp:Label ID="Label3" runat="server">(Mostrar detalles...)</asp:Label>
                                                </asp:Panel>
                                            </td>
                                        </tr>
                                        <TR>
                                            <TD style="VERTICAL-ALIGN: top; WIDTH: 100%; TEXT-ALIGN: left" colSpan=2>
                                                <asp:Panel id="ContentPanelCargaHorariaAnexa" runat="server" Width="100%" CssClass="collapsePanel">
                                                    <asp:GridView id="gvCargaHorariaAnexa" runat="server" Width="100%" SkinID="SkinGridViewEmpty" AutoGenerateColumns="False" EmptyDataText="No existe carga horaria anexa." Height="100%" OnRowCommand="gvCargaHorariaAnexa_RowCommand" OnRowDataBound="gvCargaHorariaAnexa_RowDataBound">
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
                                                                    <asp:Label ID="lblPlantel" runat="server" Text='<%# Bind("ClavePlantel") %>' ToolTip='<%# Bind("NombrePlantel") %>'></asp:Label>
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
                                                            <asp:BoundField DataField="Semestre" HeaderText="Semestre">
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
                            ToolTip="Eliminar registro de ésta hora" CommandName="Eliminar" /><ajaxToolkit:ConfirmButtonExtender ID="CFEEliminaPerc"
                                runat="server" ConfirmText="¿Está seguro de eliminar la hora?" TargetControlID="ibEliminar">
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
                                                </asp:Panel>
                                            </td>
                                        </tr>
                                        <TR>
                                            <TD style="VERTICAL-ALIGN: top; WIDTH: 100%; TEXT-ALIGN: left" colSpan=2>
                                                <asp:GridView ID="gvResumen2" runat="server" AutoGenerateColumns="False" Caption="Resumen"
                                                    SkinID="SkinGridView">
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
                                    </tbody>
                                </table>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="btnConsultarCargaHoraria" EventName="Click" />
                                <asp:AsyncPostBackTrigger ControlID="gvCargaHorariaAnexa" EventName="RowCommand" />
                            </Triggers>
                        </asp:UpdatePanel>
                            </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

