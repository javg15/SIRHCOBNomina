<%@ page enableeventvalidation="false" language="VB" masterpagefile="~/MasterPageSesionIniciada.master" autoeventwireup="false" inherits="Consultas_Conceptos_Historia, App_Web_00vntztu" title="COBAEV - Nómina - Historia conceptos por empleado" stylesheettheme="SkinFile" maintainScrollPositionOnPostBack="true" %>

<%@ Register Src="~/WebControls/wucSearchEmps.ascx" TagName="wucBuscaEmpleados" TagPrefix="uc1" %>
<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress" TagPrefix="TP_wucUpdateProgress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
    <table style="width: 100%; height: 300px" align="center">
        <tr>
            <td style="vertical-align: top; text-align: right">
                <h2>
                    Sistema de nómina: Empleados (Historia anual de conceptos)
                </h2>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top; width: 100%; height: 100%; text-align: left">
                <table style="width: 100%">
                    <tr>
                        <td style="vertical-align: top; text-align: left">
                            <table style="width: 100%">
                                <tr>
                                    <td>
                                        <uc1:wucBuscaEmpleados ID="WucBuscaEmpleados1" runat="server" EnableViewState="true" />
                                    </td>
                                    <td style="vertical-align: top; text-align: right">
                                        &nbsp;<asp:ImageButton ID="ibActualizar" runat="server" ImageUrl="~/Imagenes/Refresh.jpg"
                                            ToolTip="Actualizar información" /><br />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top; text-align: left">
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                <asp:Panel ID="pnl1" runat="server">
                                    <asp:Panel ID="pnlAños" runat="server" DefaultButton="btnConsultar" Font-Names="Verdana"
                                        Font-Size="X-Small" GroupingText="Seleccione ejercicio">
                                        <br />
                                        <asp:DropDownList ID="ddlAños" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlAños_SelectedIndexChanged"
                                            SkinID="SkinDropDownList">
                                        </asp:DropDownList>
                                        <asp:Button ID="btnConsultar" runat="server" SkinID="SkinBoton" Text="Consultar"
                                            ToolTip="Consultar el acumulado anual de subsidio para el empleo del empleado seleccionado"
                                            Visible="False" /><br />
                                    </asp:Panel>
                                   </asp:Panel>
                                    <br />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top; text-align: left">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                <asp:Panel ID="pnl2" runat="server">
                                    <ajaxToolkit:CollapsiblePanelExtender ID="CPEPercsVigs" runat="Server" CollapseControlID="TitlePnlPercsVigs"
                                        Collapsed="False" CollapsedImage="~/Imagenes/expand_blue.jpg" CollapsedText="(Mostrar detalles...)"
                                        ExpandControlID="TitlePnlPercsVigs" ExpandedImage="~/Imagenes/collapse_blue.jpg"
                                        ExpandedText="(Ocultar detalles...)" ImageControlID="imgPercsVigs" SuppressPostBack="true"
                                        TargetControlID="ContentPnlPercsVigs" TextLabelID="lblPercsVigs">
                                    </ajaxToolkit:CollapsiblePanelExtender>
                                    <ajaxToolkit:CollapsiblePanelExtender ID="CPEDeduccionesVigentes" runat="Server"
                                        CollapseControlID="TitlePanelDeduccionesVigentes" Collapsed="False" CollapsedImage="~/Imagenes/expand_blue.jpg"
                                        CollapsedText="(Mostrar detalles...)" ExpandControlID="TitlePanelDeduccionesVigentes"
                                        ExpandedImage="~/Imagenes/collapse_blue.jpg" ExpandedText="(Ocultar detalles...)"
                                        ImageControlID="Image1" SuppressPostBack="true" TargetControlID="ContentPanelDeduccionesVigentes"
                                        TextLabelID="Label1">
                                    </ajaxToolkit:CollapsiblePanelExtender>
                                    <ajaxToolkit:CollapsiblePanelExtender ID="CPEHistoriaDeducciones" runat="Server"
                                        CollapseControlID="TitlePanelHistoriaDeducciones" Collapsed="False" CollapsedImage="~/Imagenes/expand_blue.jpg"
                                        CollapsedText="(Mostrar detalles...)" ExpandControlID="TitlePanelHistoriaDeducciones"
                                        ExpandedImage="~/Imagenes/collapse_blue.jpg" ExpandedText="(Ocultar detalles...)"
                                        ImageControlID="Image3" SuppressPostBack="true" TargetControlID="ContentPanelHistoriaDeducciones"
                                        TextLabelID="Label3">
                                    </ajaxToolkit:CollapsiblePanelExtender>
                                    <table cellpadding="0" cellspacing="0" style="width: 100%">
                                        <tbody>
                                            <tr>
                                                <td colspan="2" style="vertical-align: top; text-align: left">
                                                    <asp:Label ID="lblEmpInf" runat="server" Font-Strikeout="False" Font-Underline="True"
                                                        SkinID="SkinLblDatos"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="vertical-align: top; width: 100%; text-align: left">
                                                    <asp:Panel ID="TitlePnlPercsVigs" runat="server" BorderColor="White" BorderStyle="Solid"
                                                        BorderWidth="1px" CssClass="collapsePanelHeader" Width="100%">
                                                        <asp:Image ID="imgPercsVigs" runat="server" ImageUrl="~/Imagenes/expand_blue.jpg" />
                                                        Percepciones vigentes
                                                        <asp:Label ID="lblPercsVigs" runat="server">(Mostrar detalles...)</asp:Label>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="vertical-align: top; width: 100%; text-align: left">
                                                    <asp:Panel ID="ContentPnlPercsVigs" runat="server" CssClass="collapsePanel" Width="100%">
                                                        <asp:GridView ID="gvPercsVigs" runat="server" EmptyDataText="Sin percepciones vigentes"
                                                            Height="100%" ShowFooter="True" SkinID="SkinGridViewEmpty" Width="100%">
                                                            <Columns>
                                                                <asp:BoundField DataField="IdPercepcion" HeaderText="IdPercepcion" Visible="False" />
                                                                <asp:BoundField DataField="ClavePercepcion" HeaderText="Clave">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="NombrePercepcion" HeaderText="Percepci&#243;n" />
                                                                <asp:BoundField DataField="ImpPerc" DataFormatString="{0:c}" HeaderText="Importe">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="VigIniPerc" HeaderText="Inicio">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="VigFinPerc" HeaderText="T&#233;rmino">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                            </Columns>
                                                            <EmptyDataTemplate>
                                                            </EmptyDataTemplate>
                                                        </asp:GridView>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="vertical-align: top; width: 100%; text-align: left">
                                                    <asp:Panel ID="TitlePanelDeduccionesVigentes" runat="server" BorderColor="White"
                                                        BorderStyle="Solid" BorderWidth="1px" CssClass="collapsePanelHeader" Width="100%">
                                                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/expand_blue.jpg" />
                                                        Deducciones vigentes
                                                        <asp:Label ID="Label1" runat="server">(Mostrar detalles...)</asp:Label>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="vertical-align: top; width: 100%; text-align: left">
                                                    <asp:Panel ID="ContentPanelDeduccionesVigentes" runat="server" CssClass="collapsePanel"
                                                        Width="100%">
                                                        <asp:GridView ID="gvDeduccionesVigentes" runat="server" EmptyDataText="Sin deducciones vigentes"
                                                            Height="100%" ShowFooter="True" SkinID="SkinGridViewEmpty" Width="100%">
                                                            <Columns>
                                                                <asp:BoundField DataField="IdDeduccion" HeaderText="IdDeduccion" Visible="False" />
                                                                <asp:BoundField DataField="ClaveDeduccion" HeaderText="Clave">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="NombreDeduccion" HeaderText="Deducci&#243;n" />
                                                                <asp:BoundField DataField="ImpDeduc" DataFormatString="{0:c}" HeaderText="Importe">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="VigIniDeduc" HeaderText="Inicio">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="VigFinDeduc" HeaderText="T&#233;rmino">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="NumPrestamoISSSTE" HeaderText="Núm. préstamo ISSSTE">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                            </Columns>
                                                            <EmptyDataTemplate>
                                                            </EmptyDataTemplate>
                                                        </asp:GridView>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="vertical-align: top; width: 100%; text-align: left">
                                                    <asp:Panel ID="TitlePanelHistoriaDeducciones" runat="server" BorderColor="White"
                                                        BorderStyle="Solid" BorderWidth="1px" CssClass="collapsePanelHeader" Width="100%">
                                                        <asp:Image ID="Image3" runat="server" ImageUrl="~/Imagenes/expand_blue.jpg" />
                                                        Histórico de conceptos del ejercicio seleccionado
                                                        <asp:Label ID="Label3" runat="server">(Mostrar detalles...)</asp:Label>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="vertical-align: top; width: 100%; text-align: left">
                                                    <asp:Panel ID="ContentPanelHistoriaDeducciones" runat="server" CssClass="collapsePanel"
                                                        Width="100%">
                                                        <asp:GridView ID="gvHistoricoConceptos" runat="server" EmptyDataText="Sin histórico de conceptos"
                                                            Height="100%" ShowFooter="True" SkinID="SkinGridViewEmpty" Width="100%" OnRowDataBound="gvHistoricoConceptos_RowDataBound">
                                                            <Columns>
                                                                <asp:BoundField DataField="ClaveConcepto" HeaderText="Clave">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="NombreConcepto" HeaderText="Concepto" />
                                                                <asp:TemplateField>
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="lbDetallePorConcepto" runat="server" OnClientClick='<%# Bind("Link") %>'>Ver detalle</asp:LinkButton>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <EmptyDataTemplate>
                                                                &nbsp;
                                                            </EmptyDataTemplate>
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
                                    <asp:AsyncPostBackTrigger ControlID="ddlA&#241;os" EventName="SelectedIndexChanged" />
                                    <asp:AsyncPostBackTrigger ControlID="WucBuscaEmpleados1" EventName="PreRender" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
