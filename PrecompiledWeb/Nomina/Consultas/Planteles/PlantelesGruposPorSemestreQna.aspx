<%@ page language="VB" enableeventvalidation="false" masterpagefile="~/MasterPageSesionIniciada.master" autoeventwireup="false" inherits="PlantelesGruposPorSemestreQna, App_Web_orihxo2e" title="COBAEV - Nómina - Planteles (Administración de Grupos)" stylesheettheme="SkinFile" maintainScrollPositionOnPostBack="true" %>

<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress"
    TagPrefix="TP_wucUpdateProgress" %>
<%@ Register Assembly="BusyBoxDotNet" Namespace="BusyBoxDotNet" TagPrefix="busyboxdotnet" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
    <table style="width: 100%; vertical-align: top;" align="center">
        <tr>
            <td style="vertical-align: top; text-align: right">
                <h2>
                    Sistema de nómina: Planteles (Administración de Grupos)
                </h2>
            </td>
        </tr>
    </table>
    <asp:UpdatePanel ID="UPGral" runat="server">
        <ContentTemplate>
    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
        <asp:View ID="viewConsulta" runat="server">
    <table style="width: 100%; vertical-align: top;" align="center">
        <tr>
            <td style="vertical-align: top; text-align: left">
                        <asp:Panel ID="pnlSemestres" runat="server" DefaultButton="btnConsultarQuincenas"
                            Font-Names="Verdana" Font-Size="X-Small" GroupingText="Seleccione semestre">
                            <br />
                            <asp:DropDownList ID="ddlSemestres" runat="server" SkinID="SkinDropDownList">
                            </asp:DropDownList>
                            <asp:Button ID="btnConsultarQuincenas" runat="server" SkinID="SkinBoton" Text="Consultar quincenas"
                                ToolTip="Consultar quincenas del semestre seleccionado" OnClick="btnConsultarQuincenas_Click" /><br />
                            <br />
                        </asp:Panel>
            </td>
        </tr>
        <tr>
            <td style="text-align: left; vertical-align: top;">
                        <asp:Panel ID="pnlQuincenas" runat="server" Font-Names="Verdana" Font-Size="X-Small">
                            <br />
                            <asp:DropDownList ID="ddlQuincenas" runat="server" SkinID="SkinDropDownList">
                            </asp:DropDownList>
                            <asp:Button ID="btnConsultarPlanteles" runat="server" SkinID="SkinBoton" Text="Consultar planteles"
                                ToolTip="Consultar planteles vigentes en la quincena seleccionada" />
                            <br />
                            <br />
                        </asp:Panel>
            </td>
        </tr>
        <tr>
            <td style="text-align: left">
                        <asp:Panel ID="pnlPlanteles" runat="server" Font-Names="Verdana" Font-Size="X-Small">
                            <br />
                            <asp:DropDownList ID="ddlPlanteles" runat="server" SkinID="SkinDropDownList">
                            </asp:DropDownList>
                            <asp:Button ID="btnConsultarGrupos" runat="server" SkinID="SkinBoton" Text="Consultar grupos"
                                ToolTip="Consultar grupos vigentes para el plantel seleccionado" />
                            <br />
                            <asp:RadioButtonList ID="rblOrdenPlanteles" runat="server" RepeatDirection="Horizontal"
                                RepeatLayout="Flow">
                                <asp:ListItem Value="0">Ordenar planteles por clave</asp:ListItem>
                                <asp:ListItem Selected="True" Value="1">Ordenar planteles por nombre (actual)</asp:ListItem>
                            </asp:RadioButtonList>
                            &nbsp;<asp:Button ID="btnAplicarOrden" runat="server" SkinID="SkinBoton" Text="Cambiar orden" />
                            <br />
                            <br />
                        </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>
                        <asp:Panel ID="pnlSemestres2" runat="server" Font-Names="Verdana" Font-Size="X-Small">
                            <table style="width: 100%; text-align: left; vertical-align: top;" align="center">
                                <tr style="text-align: left; vertical-align: top;">
                                    <td style="text-align: left; vertical-align: top;">
                                        <asp:GridView ID="gvPrimSem" runat="server" AutoGenerateColumns="False" 
                                            SkinID="SkinGridView">
                                            <Columns>
                                                <asp:TemplateField HeaderText="IdTblGrupo" Visible="False">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblIdTblGrupo" runat="server" Text='<%# Bind("IdTblGrupo") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="Grupo" HeaderText="1er. Semestre" ItemStyle-HorizontalAlign="Center">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:TemplateField ShowHeader="False">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="ibConsultarModificar" runat="server" CausesValidation="False"
                                                            ImageUrl="~/Imagenes/Modificar.png" ToolTip="Consultar/Modificar" 
                                                            CommandArgument="1" onclick="ibConsultarModificar_Click" />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                        <asp:LinkButton ID="lbAddGrupoPrimSem" runat="server" 
                                            SkinID="SkinLinkButton" CommandArgument="1">Crear nuevo grupo</asp:LinkButton>
                                        <asp:GridView ID="gvSegSem" runat="server" AutoGenerateColumns="False" SkinID="SkinGridView">
                                            <Columns>
                                                <asp:TemplateField HeaderText="IdTblGrupo" Visible="False">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblIdTblGrupo" runat="server" Text='<%# Bind("IdTblGrupo") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="Grupo" HeaderText="2o. Semestre" ItemStyle-HorizontalAlign="Center">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:TemplateField ShowHeader="False">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="ibConsultarModificar" runat="server" CausesValidation="False"
                                                            ImageUrl="~/Imagenes/Modificar.png" ToolTip="Consultar/Modificar" 
                                                            CommandArgument="2" onclick="ibConsultarModificar_Click" />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                        <asp:LinkButton ID="lbAddGrupoSegSem" runat="server" 
                                            SkinID="SkinLinkButton" CommandArgument="2">Crear nuevo grupo</asp:LinkButton>
                                    </td>
                                    <td style="text-align: left; vertical-align: top;">
                                        <asp:GridView ID="gvTercSem" runat="server" AutoGenerateColumns="False" SkinID="SkinGridView">
                                            <Columns>
                                                <asp:TemplateField HeaderText="IdTblGrupo" Visible="False">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblIdTblGrupo" runat="server" Text='<%# Bind("IdTblGrupo") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="Grupo" HeaderText="3er. Semestre" ItemStyle-HorizontalAlign="Center">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:TemplateField ShowHeader="False">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="ibConsultarModificar" runat="server" CausesValidation="False"
                                                            ImageUrl="~/Imagenes/Modificar.png" ToolTip="Consultar/Modificar" 
                                                            CommandArgument="3" onclick="ibConsultarModificar_Click" />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                        <asp:LinkButton ID="lbAddGrupoTercSem" runat="server" 
                                            SkinID="SkinLinkButton" CommandArgument="3">Crear nuevo grupo</asp:LinkButton>
                                        <asp:GridView ID="gvCuartoSem" runat="server" AutoGenerateColumns="False" SkinID="SkinGridView">
                                            <Columns>
                                                <asp:TemplateField HeaderText="IdTblGrupo" Visible="False">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblIdTblGrupo" runat="server" Text='<%# Bind("IdTblGrupo") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="Grupo" HeaderText="4o. Semestre" ItemStyle-HorizontalAlign="Center">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:TemplateField ShowHeader="False">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="ibConsultarModificar" runat="server" CausesValidation="False"
                                                            ImageUrl="~/Imagenes/Modificar.png" ToolTip="Consultar/Modificar" 
                                                            CommandArgument="4" onclick="ibConsultarModificar_Click" />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                        <asp:LinkButton ID="lbAddGrupoCuartoSem" runat="server" 
                                            SkinID="SkinLinkButton" CommandArgument="4">Crear nuevo grupo</asp:LinkButton>
                                    </td>
                                    <td style="text-align: left; vertical-align: top;">
                                        <asp:GridView ID="gvQuintoSem" runat="server" AutoGenerateColumns="False" SkinID="SkinGridView">
                                            <Columns>
                                                <asp:TemplateField HeaderText="IdTblGrupo" Visible="False">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblIdTblGrupo" runat="server" Text='<%# Bind("IdTblGrupo") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="Grupo" HeaderText="5o. Semestre" ItemStyle-HorizontalAlign="Center">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:TemplateField ShowHeader="False">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="ibConsultarModificar" runat="server" CausesValidation="False"
                                                            ImageUrl="~/Imagenes/Modificar.png" ToolTip="Consultar/Modificar" 
                                                            CommandArgument="5" onclick="ibConsultarModificar_Click" />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                        <asp:LinkButton ID="lbAddGrupoQuintoSem" runat="server" 
                                            SkinID="SkinLinkButton" CommandArgument="5">Crear nuevo grupo</asp:LinkButton>
                                        <asp:GridView ID="gvSextoSem" runat="server" AutoGenerateColumns="False" SkinID="SkinGridView">
                                            <Columns>
                                                <asp:TemplateField HeaderText="IdTblGrupo" Visible="False">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblIdTblGrupo" runat="server" Text='<%# Bind("IdTblGrupo") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="Grupo" HeaderText="6o. Semestre" ItemStyle-HorizontalAlign="Center">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:TemplateField ShowHeader="False">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="ibConsultarModificar" runat="server" CausesValidation="False"
                                                            ImageUrl="~/Imagenes/Modificar.png" ToolTip="Consultar/Modificar" 
                                                            CommandArgument="6" onclick="ibConsultarModificar_Click" />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                        <asp:LinkButton ID="lbAddGrupoSextoSem" runat="server" 
                                            SkinID="SkinLinkButton" CommandArgument="6">Crear nuevo grupo</asp:LinkButton>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
            </td>
        </tr>
    </table>
        </asp:View>
        <asp:View ID="viewAddGrupo" runat="server">
            <table style="width: 100%; vertical-align: top;" align="center">
                <tr>
                    <td colspan="2" style="vertical-align: top; text-align: right;">
                        <h2>Datos del nuevo grupo</h2>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: left; width: 266px; height: 22px;">
                        <asp:Label ID="Label1" runat="server" SkinID="SkinLblNormal" Text="Semestre:"></asp:Label>
                    </td>
                    <td style="text-align: left">
                        
                        <asp:Label ID="lblSemestre" runat="server" SkinID="SkinLblNormal"></asp:Label>
                        
                    </td>
                </tr>
                <tr>
                    <td style="text-align: left; width: 266px; height: 23px;">
                        <asp:Label ID="Label17" runat="server" SkinID="SkinLblNormal" 
                            Text="Clave plantel:"></asp:Label>
                    </td>
                    <td style="text-align: left">
                        <asp:Label ID="lblClavePlantel" runat="server" SkinID="SkinLblNormal"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: left; width: 266px; height: 23px;">
                        <asp:Label ID="Label2" runat="server" SkinID="SkinLblNormal" Text="Plantel:"></asp:Label>
                    </td>
                    <td style="text-align: left">
                        <asp:Label ID="lblPlantel" runat="server" SkinID="SkinLblNormal"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: left; width: 266px; height: 22px;">
                        <asp:Label ID="Label3" runat="server" SkinID="SkinLblNormal" 
                            Text="Grupo a crear:"></asp:Label>
                    </td>
                    <td style="text-align: left">
                        <asp:Label ID="lblGrupo" runat="server" SkinID="SkinLblNormal" ForeColor="Blue" Font-Bold="true"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: left; width: 266px; height: 24px;">
                        <asp:Label ID="Label4" runat="server" SkinID="SkinLblNormal" 
                            Text="Permitirá captura de horas definitivas:"></asp:Label>
                    </td>
                    <td style="text-align: left">
                        <asp:CheckBox ID="chkbxPermiteHrsDef" runat="server" SkinID="SkinCheckBox" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: left; width: 266px; height: 24px;">
                        <asp:Label ID="Label5" runat="server" SkinID="SkinLblNormal" 
                            Text="Permitirá captura de horas provisionales"></asp:Label>
                    </td>
                    <td style="text-align: left">
                        <asp:CheckBox ID="chkbxPermiteHrsProv" runat="server" SkinID="SkinCheckBox" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: left; width: 266px; height: 24px;">
                        <asp:Label ID="Label6" runat="server" SkinID="SkinLblNormal" 
                            Text="Permitirá captura de horas interinas:"></asp:Label>
                    </td>
                    <td style="text-align: left">
                        <asp:CheckBox ID="chkbxPermiteHrsInt" runat="server" SkinID="SkinCheckBox" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: left; width: 266px; height: 24px;">
                        <asp:Label ID="Label7" runat="server" SkinID="SkinLblNormal" 
                            Text="Grupo del programa UNA:"></asp:Label>
                    </td>
                    <td style="text-align: left">
                        <asp:CheckBox ID="chkbxGrupoUNA" runat="server" SkinID="SkinCheckBox" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: left; width: 266px; height: 24px;">
                        <asp:Label ID="Label8" runat="server" SkinID="SkinLblNormal" 
                            Text="Bachillerato General:"></asp:Label>
                    </td>
                    <td style="text-align: left">
                        <asp:CheckBox ID="chkbxBachGral" runat="server" SkinID="SkinCheckBox" 
                            Enabled="False" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: left; width: 266px; height: 24px;">
                        <asp:Label ID="Label9" runat="server" SkinID="SkinLblNormal" 
                            Text="Bachillerato General (Artes):"></asp:Label>
                    </td>
                    <td style="text-align: left">
                        <asp:CheckBox ID="chkbxBachGralArtes" runat="server" SkinID="SkinCheckBox" 
                            AutoPostBack="True" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: left; width: 266px; height: 24px;">
                        <asp:Label ID="Label10" runat="server" SkinID="SkinLblNormal" Text="EMSAD:"></asp:Label>
                    </td>
                    <td style="text-align: left">
                        <asp:CheckBox ID="chkbxEMSAD" runat="server" SkinID="SkinCheckBox" 
                            Enabled="False" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: left; width: 266px; height: 24px;">
                        <asp:Label ID="Label11" runat="server" SkinID="SkinLblNormal" 
                            Text="Requiere grupo disciplinario:"></asp:Label>
                    </td>
                    <td style="text-align: left">
                        <asp:CheckBox ID="chkbxReqGpoDisc" runat="server" SkinID="SkinCheckBox" 
                            Enabled="False" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: left; width: 266px; height: 24px;">
                        <asp:Label ID="Label12" runat="server" SkinID="SkinLblNormal" 
                            Text="Grupos disciplinarios:"></asp:Label>
                    </td>
                    <td style="text-align: left">
                        <asp:DropDownList ID="ddlGposDisc" runat="server" SkinID="SkinDropDownList">
                        </asp:DropDownList>
                        <asp:Label ID="lblGposDiscNoDisp" runat="server" 
                            Font-Bold="True" ForeColor="Red" SkinID="SkinLblNormal" 
                            Text="No disponible"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: left; width: 266px; height: 24px;">
                        <asp:Label ID="Label13" runat="server" SkinID="SkinLblNormal" 
                            Text="Requiere actividades paraescolares:"></asp:Label>
                    </td>
                    <td style="text-align: left">
                        <asp:CheckBox ID="chkbxReqParaEscolar" runat="server" SkinID="SkinCheckBox" 
                            Enabled="False" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: left; width: 266px; height: 24px;">
                        <asp:Label ID="Label14" runat="server" SkinID="SkinLblNormal" 
                            Text="Actividades paraescolares:"></asp:Label>
                    </td>
                    <td style="text-align: left">
                        <asp:DropDownList ID="ddlActsParaEsc" runat="server" 
                            SkinID="SkinDropDownList">
                        </asp:DropDownList>
                        <asp:Label ID="lblActsParaEscNoDisp" runat="server" 
                            Font-Bold="True" ForeColor="Red" SkinID="SkinLblNormal" 
                            Text="No disponible"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: left; width: 266px; height: 24px;">
                        <asp:Label ID="Label15" runat="server" SkinID="SkinLblNormal" 
                            Text="Requiere capacitación para el trabajo:"></asp:Label>
                    </td>
                    <td style="text-align: left">
                        <asp:CheckBox ID="chkbxReqCapTrab" runat="server" SkinID="SkinCheckBox" 
                            Enabled="False" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: left; width: 266px; height: 24px;">
                        <asp:Label ID="Label16" runat="server" SkinID="SkinLblNormal" 
                            Text="Capacitaciones para el trabajo:"></asp:Label>
                    </td>
                    <td style="text-align: left">
                        <asp:DropDownList ID="ddlCapTrab" runat="server" 
                            SkinID="SkinDropDownList">
                        </asp:DropDownList>
                        <asp:Label ID="lblCapTrabNoDisp" runat="server" 
                            Font-Bold="True" ForeColor="Red" SkinID="SkinLblNormal" 
                            Text="No disponible"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: left; width: 266px; height: 24px;">
                        <asp:Label ID="Label18" runat="server" SkinID="SkinLblNormal" 
                            Text="Grupo de nueva creación:"></asp:Label>
                    </td>
                    <td style="text-align: left">
                        <asp:CheckBox ID="chkbxGpoNuevaCreac" runat="server" AutoPostBack="True" 
                            Checked="True" SkinID="SkinCheckBox" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: left; width: 266px; height: 24px;">
                        <asp:Label ID="Label19" runat="server" SkinID="SkinLblNormal" 
                            Text="Inicio (Nueva creación):"></asp:Label>
                    </td>
                    <td style="text-align: left">
                        <asp:DropDownList ID="ddlQnaIniNueCreac" runat="server" 
                            SkinID="SkinDropDownList">
                        </asp:DropDownList>
                        <asp:Label ID="lblQnaIniNueCreacNoDisp" runat="server" Font-Bold="True" 
                            ForeColor="Red" SkinID="SkinLblNormal" Text="No disponible" Visible="False"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: left; width: 266px; height: 24px;">
                        <asp:Label ID="Label20" runat="server" SkinID="SkinLblNormal" 
                            Text="Fin (Nueva creación):"></asp:Label>
                    </td>
                    <td style="text-align: left">
                        <asp:DropDownList ID="ddlQnaFinNueCreac" runat="server" 
                            SkinID="SkinDropDownList">
                        </asp:DropDownList>
                        <asp:Label ID="lblQnaFinNueCreacNoDisp" runat="server" Font-Bold="True" 
                            ForeColor="Red" SkinID="SkinLblNormal" Text="No disponible" Visible="False"></asp:Label>
                        <asp:CompareValidator ID="CVPeriodoNuevaCreac" runat="server" 
                            ControlToCompare="ddlQnaFinNueCreac" ControlToValidate="ddlQnaIniNueCreac" 
                            Display="None" ErrorMessage="Error en el periodo" Operator="LessThanEqual"></asp:CompareValidator>
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                            ShowMessageBox="True" ShowSummary="False" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: left; width: 266px; height: 24px;">
                        &nbsp;</td>
                    <td style="text-align: left">
                        <asp:Button ID="btnGuardar" runat="server" SkinID="SkinBoton" Text="Guardar" />
                        <ajaxToolkit:ConfirmButtonExtender ID="btnGuardar_CBE" runat="server" 
                            ConfirmText="¿Está seguro de que los datos del nuevo grupo son correctos?" 
                            Enabled="True" TargetControlID="btnGuardar">
                        </ajaxToolkit:ConfirmButtonExtender>
                        &nbsp;<asp:Button ID="btnCancelar" runat="server" CausesValidation="False" 
                            SkinID="SkinBoton" Text="Cancelar" />
                    </td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="viewConsultaModificaGrupo" runat="server">
            <table align="center" style="width: 100%; vertical-align: top;">
                <tr>
                    <td colspan="2" style="vertical-align: top; text-align: right;">
                        <h2>
                            Datos del grupo para consulta/modificación</h2>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: left; width: 266px; height: 22px;">
                        <asp:Label ID="Label21" runat="server" SkinID="SkinLblNormal" Text="Semestre:"></asp:Label>
                    </td>
                    <td style="text-align: left">
                        <asp:Label ID="lblSemestre0" runat="server" SkinID="SkinLblNormal"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: left; width: 266px; height: 23px;">
                        <asp:Label ID="Label22" runat="server" SkinID="SkinLblNormal" 
                            Text="Clave plantel:"></asp:Label>
                    </td>
                    <td style="text-align: left">
                        <asp:Label ID="lblClavePlantel0" runat="server" SkinID="SkinLblNormal"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: left; width: 266px; height: 23px;">
                        <asp:Label ID="Label23" runat="server" SkinID="SkinLblNormal" Text="Plantel:"></asp:Label>
                    </td>
                    <td style="text-align: left">
                        <asp:Label ID="lblPlantel0" runat="server" SkinID="SkinLblNormal"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: left; width: 266px; height: 22px;">
                        <asp:Label ID="Label24" runat="server" SkinID="SkinLblNormal" 
                            Text="Grupo:"></asp:Label>
                    </td>
                    <td style="text-align: left">
                        <asp:Label ID="lblGrupo0" runat="server" Font-Bold="true" ForeColor="Blue" 
                            SkinID="SkinLblNormal"></asp:Label>
                        <asp:Label ID="lblIdTblGrupo0" runat="server" Font-Bold="True" ForeColor="Blue" 
                            SkinID="SkinLblNormal" Visible="False"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: left; width: 266px; height: 24px;">
                        <asp:Label ID="Label25" runat="server" SkinID="SkinLblNormal" 
                            Text="Permite captura de horas definitivas:"></asp:Label>
                    </td>
                    <td style="text-align: left">
                        <asp:CheckBox ID="chkbxPermiteHrsDef0" runat="server" SkinID="SkinCheckBox" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: left; width: 266px; height: 24px;">
                        <asp:Label ID="Label26" runat="server" SkinID="SkinLblNormal" 
                            Text="Permite captura de horas provisionales"></asp:Label>
                    </td>
                    <td style="text-align: left">
                        <asp:CheckBox ID="chkbxPermiteHrsProv0" runat="server" SkinID="SkinCheckBox" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: left; width: 266px; height: 24px;">
                        <asp:Label ID="Label27" runat="server" SkinID="SkinLblNormal" 
                            Text="Permite captura de horas interinas:"></asp:Label>
                    </td>
                    <td style="text-align: left">
                        <asp:CheckBox ID="chkbxPermiteHrsInt0" runat="server" SkinID="SkinCheckBox" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: left; width: 266px; height: 24px;">
                        <asp:Label ID="Label28" runat="server" SkinID="SkinLblNormal" 
                            Text="Grupo del programa UNA:"></asp:Label>
                    </td>
                    <td style="text-align: left">
                        <asp:CheckBox ID="chkbxGrupoUNA0" runat="server" SkinID="SkinCheckBox" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: left; width: 266px; height: 24px;">
                        <asp:Label ID="Label29" runat="server" SkinID="SkinLblNormal" 
                            Text="Bachillerato General:"></asp:Label>
                    </td>
                    <td style="text-align: left">
                        <asp:CheckBox ID="chkbxBachGral0" runat="server" Enabled="False" 
                            SkinID="SkinCheckBox" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: left; width: 266px; height: 24px;">
                        <asp:Label ID="Label30" runat="server" SkinID="SkinLblNormal" 
                            Text="Bachillerato General (Artes):"></asp:Label>
                    </td>
                    <td style="text-align: left">
                        <asp:CheckBox ID="chkbxBachGralArtes0" runat="server" AutoPostBack="True" 
                            SkinID="SkinCheckBox" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: left; width: 266px; height: 24px;">
                        <asp:Label ID="Label31" runat="server" SkinID="SkinLblNormal" Text="EMSAD:"></asp:Label>
                    </td>
                    <td style="text-align: left">
                        <asp:CheckBox ID="chkbxEMSAD0" runat="server" Enabled="False" 
                            SkinID="SkinCheckBox" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: left; width: 266px; height: 24px;">
                        <asp:Label ID="Label32" runat="server" SkinID="SkinLblNormal" 
                            Text="Requiere grupo disciplinario:"></asp:Label>
                    </td>
                    <td style="text-align: left">
                        <asp:CheckBox ID="chkbxReqGpoDisc0" runat="server" Enabled="False" 
                            SkinID="SkinCheckBox" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: left; width: 266px; height: 24px;">
                        <asp:Label ID="Label33" runat="server" SkinID="SkinLblNormal" 
                            Text="Grupos disciplinarios:"></asp:Label>
                    </td>
                    <td style="text-align: left">
                        <asp:DropDownList ID="ddlGposDisc0" runat="server" SkinID="SkinDropDownList">
                        </asp:DropDownList>
                        <asp:Label ID="lblGposDiscNoDisp0" runat="server" Font-Bold="True" 
                            ForeColor="Red" SkinID="SkinLblNormal" Text="No disponible"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: left; width: 266px; height: 24px;">
                        <asp:Label ID="Label34" runat="server" SkinID="SkinLblNormal" 
                            Text="Requiere actividades paraescolares:"></asp:Label>
                    </td>
                    <td style="text-align: left">
                        <asp:CheckBox ID="chkbxReqParaEscolar0" runat="server" Enabled="False" 
                            SkinID="SkinCheckBox" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: left; width: 266px; height: 24px;">
                        <asp:Label ID="Label35" runat="server" SkinID="SkinLblNormal" 
                            Text="Actividades paraescolares:"></asp:Label>
                    </td>
                    <td style="text-align: left">
                        <asp:DropDownList ID="ddlActsParaEsc0" runat="server" SkinID="SkinDropDownList">
                        </asp:DropDownList>
                        <asp:Label ID="lblActsParaEscNoDisp0" runat="server" Font-Bold="True" 
                            ForeColor="Red" SkinID="SkinLblNormal" Text="No disponible"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: left; width: 266px; height: 24px;">
                        <asp:Label ID="Label36" runat="server" SkinID="SkinLblNormal" 
                            Text="Requiere capacitación para el trabajo:"></asp:Label>
                    </td>
                    <td style="text-align: left">
                        <asp:CheckBox ID="chkbxReqCapTrab0" runat="server" Enabled="False" 
                            SkinID="SkinCheckBox" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: left; width: 266px; height: 24px;">
                        <asp:Label ID="Label37" runat="server" SkinID="SkinLblNormal" 
                            Text="Capacitaciones para el trabajo:"></asp:Label>
                    </td>
                    <td style="text-align: left">
                        <asp:DropDownList ID="ddlCapTrab0" runat="server" SkinID="SkinDropDownList">
                        </asp:DropDownList>
                        <asp:Label ID="lblCapTrabNoDisp0" runat="server" Font-Bold="True" 
                            ForeColor="Red" SkinID="SkinLblNormal" Text="No disponible"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: left; width: 266px; height: 24px;">
                        <asp:Label ID="Label38" runat="server" SkinID="SkinLblNormal" 
                            Text="Grupo de nueva creación:"></asp:Label>
                    </td>
                    <td style="text-align: left">
                        <asp:CheckBox ID="chkbxGpoNuevaCreac0" runat="server" AutoPostBack="True" 
                            SkinID="SkinCheckBox" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: left; width: 266px; height: 24px;">
                        <asp:Label ID="Label39" runat="server" SkinID="SkinLblNormal" 
                            Text="Inicio (Nueva creación):"></asp:Label>
                    </td>
                    <td style="text-align: left">
                        <asp:DropDownList ID="ddlQnaIniNueCreac0" runat="server" 
                            SkinID="SkinDropDownList">
                        </asp:DropDownList>
                        <asp:Label ID="lblQnaIniNueCreacNoDisp0" runat="server" Font-Bold="True" 
                            ForeColor="Red" SkinID="SkinLblNormal" Text="No disponible" Visible="False"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: left; width: 266px; height: 24px;">
                        <asp:Label ID="Label40" runat="server" SkinID="SkinLblNormal" 
                            Text="Fin (Nueva creación):"></asp:Label>
                    </td>
                    <td style="text-align: left">
                        <asp:DropDownList ID="ddlQnaFinNueCreac0" runat="server" 
                            SkinID="SkinDropDownList">
                        </asp:DropDownList>
                        <asp:Label ID="lblQnaFinNueCreacNoDisp0" runat="server" Font-Bold="True" 
                            ForeColor="Red" SkinID="SkinLblNormal" Text="No disponible" Visible="False"></asp:Label>
                        <asp:CompareValidator ID="CVPeriodoNuevaCreac0" runat="server" 
                            ControlToCompare="ddlQnaFinNueCreac" ControlToValidate="ddlQnaIniNueCreac0" 
                            Display="None" ErrorMessage="Error en el periodo" Operator="LessThanEqual"></asp:CompareValidator>
                        <asp:ValidationSummary ID="ValidationSummary2" runat="server" 
                            ShowMessageBox="True" ShowSummary="False" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: left; width: 266px; height: 24px;">
                        &nbsp;</td>
                    <td style="text-align: left">
                        <asp:Button ID="btnGuardar0" runat="server" SkinID="SkinBoton" Text="Guardar" />
                        <ajaxToolkit:ConfirmButtonExtender ID="btnGuardar0_ConfirmButtonExtender" 
                            runat="server" ConfirmText="¿Está seguro de que la información es correcta?" 
                            Enabled="True" TargetControlID="btnGuardar0">
                        </ajaxToolkit:ConfirmButtonExtender>
                        &nbsp;<asp:Button ID="btnCancelar0" runat="server" CausesValidation="False" 
                            SkinID="SkinBoton" Text="Cancelar" />
                    </td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="View4" runat="server">
        </asp:View>
    </asp:MultiView>
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
