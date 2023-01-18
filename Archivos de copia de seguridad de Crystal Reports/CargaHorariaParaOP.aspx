<%@ Page EnableEventValidation="false" Language="VB" MasterPageFile="~/MasterPageSesionIniciada.master"
    AutoEventWireup="false" CodeFile="CargaHorariaParaOP.aspx.vb" Inherits="Consultas_Empleados_CargaHorariaOP"
    Title="COBAEV - Nómina - Ordenes de presentación para cargas horarias" StylesheetTheme="SkinFile" %>

<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress"
    TagPrefix="TP_wucUpdateProgress" %>
<%@ Register Src="~/WebControls/wucSearchEmps.ascx" TagName="wucBuscaEmpleados" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
    <table style="width: 100%; vertical-align: top; text-align: center;" align="center">
        <tr>
            <td style="vertical-align: top; text-align: right">
                <h2>
                    Sistema de nómina: Ordenes de presentación para cargas horarias
                </h2>
            </td>
        </tr>
    </table>
    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
        <ContentTemplate>
            <table style="width: 100%; height: 300px;" align="center">
                <tr>
                    <td style="vertical-align: top; width: 100%; height: 100%; text-align: left">
                        <table style="width: 100%">
                            <tr>
                                <td style="width: 100%">
                                    <table style="width: 100%;">
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
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 100%">
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                            <asp:Panel ID="pnl1" runat="server">
                                            <asp:Label ID="lblEmpInf" runat="server" SkinID="SkinLblDatos" Visible="False" Font-Strikeout="False"
                                                Font-Underline="True"></asp:Label><br />
                                            <asp:Panel ID="pnlSemestres" runat="server" Font-Size="X-Small" Font-Names="Verdana"
                                                DefaultButton="btnConsultarCargaHoraria" GroupingText="Seleccione semestre">
                                                &nbsp;<table>
                                                    <tr>
                                                        <td>
                                                            <asp:DropDownList ID="ddlSemestres" runat="server" SkinID="SkinDropDownList">
                                                            </asp:DropDownList>
                                                            &nbsp;<asp:Button ID="btnConsultarCargaHoraria" runat="server" ToolTip="Consultar carga horaria para el semestre seleccionado"
                                                                SkinID="SkinBoton" Text="Carga horaria" OnClick="btnConsultarCargaHoraria_Click">
                                                            </asp:Button>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:CheckBox ID="chkbxCargaHorariaConHistoria" runat="server" Enabled="False" SkinID="SkinCheckBox"
                                                                Text="Incluir historia completa durante el semestre" Checked="True" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            </asp:Panel>
                                        </ContentTemplate>
                                        <Triggers>
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
                                                        <td style="vertical-align: top; width: 100%; text-align: left" colspan="2">
                                                            <asp:Panel ID="TitlePanelCargaHoraria" runat="server" Width="100%" BorderWidth="1px"
                                                                BorderStyle="Solid" BorderColor="White" CssClass="collapsePanelHeader">
                                                                <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/expand_blue.jpg"></asp:Image>&nbsp;Carga
                                                                horaria&nbsp;<asp:Label ID="Label1" runat="server">(Mostrar detalles...)</asp:Label>
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="vertical-align: top; width: 100%; text-align: left" colspan="2">
                                                            <asp:Panel ID="ContentPanelCargaHoraria" runat="server" Width="100%" CssClass="collapsePanel">
                                                                <asp:GridView ID="gvCargaHoraria" runat="server" Width="100%" SkinID="SkinGridViewEmpty"
                                                                    AutoGenerateColumns="False" EmptyDataText="El empleado no tiene carga horaria interina o provisional."
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
                                                                                    Text='<%# Bind("ClavePlantel") %>'></asp:Label>
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
                                                                        <asp:TemplateField HeaderText="Tipo">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblTipoHora" runat="server" Text='<%# Bind("TipoHora") %>' ToolTip='<%# Bind("DescCategoria") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Estatus">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblEstatusHora" runat="server" ToolTip='<%# Bind("DescEstatus") %>'
                                                                                    Text='<%# Bind("AbrevEstatus") %>'></asp:Label>
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
                                                                        <asp:TemplateField HeaderText="Nombramiento">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblNombramiento" runat="server" Text='<%# Bind("AbrevNombramiento") %>'
                                                                                    ToolTip='<%# Bind("DescNombramiento") %>'></asp:Label>
                                                                                    <asp:Image ID="imgInfTitular" runat="server" ImageUrl="~/Imagenes/UserInfo.jpg" />
                                                                            </ItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="N&#243;mina">
                                                                            <ItemTemplate>
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
                                                                        <asp:TemplateField HeaderText="Ord. Pres.">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblIdOP" runat="server" Text='<%# Bind("IdOrdenDePres") %>' Visible="False"></asp:Label><asp:LinkButton
                                                                                    ID="lbOP" runat="server" Text='<%# Bind("NumOrdPres") %>' ToolTip="Visualizar órden de presentación en formato PDF."></asp:LinkButton>
                                                                            </ItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField Visible="False">
                                                                            <ItemTemplate>
                                                                                <asp:ImageButton ID="ibAddHoras" runat="server" ImageUrl="~/Imagenes/Copiar.png"
                                                                                    ToolTip="Asignar nuevas horas a partir de este registro" CommandName="Copiar" />
                                                                            </ItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Center" Wrap="True"></ItemStyle>
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField>
                                                                            <ItemTemplate>
                                                                                <asp:ImageButton ID="ibVerDetalles" runat="server" ImageUrl="~/Imagenes/Detalles.png"
                                                                                    ToolTip="Consultar información de este registro" 
                                                                                    CommandName="VerDetalles" />
                                                                            </ItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Center" Wrap="False"></ItemStyle>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField Visible="False">
                                                                            <ItemTemplate>
                                                                                <asp:ImageButton ID="ibRemplazar" runat="server" ImageUrl="~/Imagenes/Replace.png"
                                                                                    ToolTip="Reemplazar horas interinamente" />
                                                                            </ItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField>
                                                                            <ItemTemplate>
                                                                                <asp:CheckBox ID="ChckBxSel" runat="server" AutoPostBack="True" OnCheckedChanged="ChckBxSel_CheckedChanged" />
                                                                            </ItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="IdEstatusOP" Visible="true">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblIdEstatusOP" runat="server" Text='<%# Bind("IdEstatusOP") %>' Visible="False"></asp:Label>
                                                                            </ItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                    <EmptyDataTemplate>
                                                                    </EmptyDataTemplate>
                                                                </asp:GridView>
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" style="vertical-align: top; width: 100%; text-align: right">
                                                            <asp:Button ID="btnOP" runat="server" Enabled="False" OnClick="btnOP_Click" SkinID="SkinBoton"
                                                                Text="Asignar orden de presentación" ToolTip="Asignar número de orden de presentación" /><ajaxToolkit:ConfirmButtonExtender
                                                                    ID="cbebtnOP" runat="server" ConfirmText="¿Está seguro de continuar?" TargetControlID="btnOP">
                                                                </ajaxToolkit:ConfirmButtonExtender>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                            </asp:Panel>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="btnConsultarCargaHoraria" EventName="Click" />
                                            <asp:AsyncPostBackTrigger ControlID="WucBuscaEmpleados1" EventName="PreRender" />
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
