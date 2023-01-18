<%@ page language="VB" enableeventvalidation="false" masterpagefile="~/MasterPageSesionIniciada.master" autoeventwireup="false" inherits="Consultas_Percepciones_Retroactivas, App_Web_nszpy5ff" title="COBAEV - Nómina - Percepciones retroactivas" stylesheettheme="SkinFile" maintainScrollPositionOnPostBack="true" %>
<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress" TagPrefix="TP_wucUpdateProgress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
    <table style="width: 100%; height: 300px" align="center">
        <tr>
            <td style="vertical-align: top; text-align: right">
                <h2>
                    Sistema de nómina: Percepciones para pago de retroactividad por quincena
                </h2>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top; width: 100%; height: 100%; text-align: left">
                <table style="width: 100%">
                    <tr>
                        <td style="width: 100%">
                            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                <ContentTemplate>
                                    <table style="width: 100%">
                                        <tr>
                                            <td style="width: 100%">
                                                <asp:Panel ID="pnlOpcionesDeConsulta" runat="server" Font-Size="X-Small" Font-Names="Verdana"
                                                    DefaultButton="btnConsultarQna" GroupingText="Consulta de retroactivos">
                                                    <br />
                                                    <asp:Label ID="Label3" runat="server" SkinID="SkinLblNormal" Text="Seleccione quincena"></asp:Label>&nbsp;<asp:DropDownList
                                                        ID="ddlQnas" runat="server" SkinID="SkinDropDownList">
                                                    </asp:DropDownList>
                                                    <asp:Button ID="btnConsultarQna" OnClick="btnConsultarQna_Click" runat="server" SkinID="SkinBoton"
                                                        Text="Consultar"></asp:Button><br />
                                                </asp:Panel>
                                            </td>
                                            <td style="width: 100px">
                                                <asp:ImageButton ID="ibRefresh" runat="server" ImageUrl="~/Imagenes/Refresh.jpg"
                                                    OnClick="ibRefresh_Click" ToolTip="Actualizar información" />
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ibRefresh" EventName="Click" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100%">
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                    <ajaxToolkit:CollapsiblePanelExtender ID="CPERetroactivos" runat="Server" TextLabelID="Label1"
                                        TargetControlID="ContentPanelRetroactivos" SuppressPostBack="true" ImageControlID="Image1"
                                        ExpandedText="(Ocultar detalles...)" ExpandedImage="~/Imagenes/collapse_blue.jpg"
                                        ExpandControlID="TitlePanelRetroactivos" CollapsedText="(Mostrar detalles...)"
                                        CollapsedImage="~/Imagenes/expand_blue.jpg" Collapsed="False" CollapseControlID="TitlePanelRetroactivos">
                                    </ajaxToolkit:CollapsiblePanelExtender>
                                    <table style="width: 100%" cellspacing="0" cellpadding="0">
                                        <tbody>
                                            <tr>
                                                <td style="vertical-align: top; width: 100%; text-align: left" colspan="2">
                                                    <asp:Panel ID="TitlePanelRetroactivos" runat="server" Width="100%" BorderWidth="1px"
                                                        BorderStyle="Solid" BorderColor="White" CssClass="collapsePanelHeader">
                                                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/expand_blue.jpg"></asp:Image>
                                                        Percepciones pagadas de manera retroactiva
                                                        <asp:Label ID="Label1" runat="server">
        (Mostrar detalles...)</asp:Label>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="vertical-align: top; width: 100%; text-align: left" colspan="2">
                                                    <asp:Panel ID="ContentPanelRetroactivos" runat="server" Width="100%" CssClass="collapsePanel">
                                                        <asp:GridView ID="gvPercRetro" runat="server" CellPadding="1" EmptyDataText="No existen percepciones pagadas de manera retroactiva."
                                                            SkinID="SkinGridView" Width="100%">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="IdPercRetro" Visible="False">
                                                                    <EditItemTemplate>
                                                                        &nbsp;
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblIdPercRetro" runat="server" Text='<%# Bind("IdPercRetro") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="ClavePercepcion" HeaderText="Cve. perc.">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="NombrePercepcion" HeaderText="Percepci&#243;n">
                                                                    <ItemStyle Wrap="False" />
                                                                </asp:BoundField>
                                                                <asp:TemplateField HeaderText="Z.E." SortExpression="ClaveZonaEco">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblClaveZonaEco" runat="server" Text='<%# Bind("ClaveZonaEco") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="DescEmpFuncion" HeaderText="Funci&#243;n del empleado">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="CalificadorEmpFuncion" HeaderText="Clasif. docente">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="PorcInc" HeaderText="Porc. inc. (%)">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                                <asp:TemplateField HeaderText="Retro. Por Dif.">
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="chckbxRetroPorDiferencia" runat="server" Checked='<%# Bind("RetroPorDiferencia") %>'
                                                                            Enabled="False" />
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="ImporteDiferencia" HeaderText="Importe Dif.">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                                <asp:TemplateField HeaderText="Incluir en el pago">
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="chckbxIncluirEnPago" runat="server" Checked='<%# Bind("IncluirEnPago") %>'
                                                                            Enabled="False" />
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="QnaAplicacion" HeaderText="Qna. aplic.">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="QnaRetroactiva" HeaderText="Qna. retro.">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                                <asp:TemplateField HeaderText="Modificar">
                                                                    <ItemTemplate>
                                                                        <asp:ImageButton ID="ibModificar" runat="server" ImageUrl="~/Imagenes/Modificar.png"
                                                                            CommandName="CmdModificar" />
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="vertical-align: top; width: 100%; text-align: left" colspan="2">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="vertical-align: top; width: 100%; text-align: left" colspan="2">
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="btnConsultarQna" EventName="Click"></asp:AsyncPostBackTrigger>
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
