<%@ page language="VB" enableeventvalidation="false" masterpagefile="~/MasterPageSesionIniciada.master" autoeventwireup="false" inherits="Consultas_Nomina_CapturaPercDeducAnt, App_Web_sogedhgo" title="COBAEV - Nómina - Consulta percepciones/deducciones capturadas" stylesheettheme="SkinFile" maintainScrollPositionOnPostBack="true" %>

<%@ Register Src="~/WebControls/wucSearchEmps.ascx" TagName="wucBuscaEmpleados" TagPrefix="uc1" %>
<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress" TagPrefix="TP_wucUpdateProgress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
    <table style="width: 100%; height: 300px" align="center">
        <tr>
            <td style="vertical-align: top; text-align: right">
                <h2>
                    Sistema de nómina: Empleados (Percepciones/deducciones para aplicar quincenalmente)
                </h2>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top; width: 100%; height: 100%; text-align: left">
                <table style="width: 100%">
                    <tr>
                        <td style="width: 100%">
                            <table style="width: 100%">
                                <tr>
                                    <td style="vertical-align: top; text-align: left">
                                        <uc1:wucBuscaEmpleados ID="WucBuscaEmpleados1" runat="server" EnableViewState="true">
                                        </uc1:wucBuscaEmpleados>
                                    </td>
                                    <td style="vertical-align: top; text-align: right">
                                        <asp:ImageButton ID="ibActualizar" runat="server" ImageUrl="~/Imagenes/Refresh.jpg"
                                            ToolTip="Actualizar información" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100%">
                            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                <ContentTemplate>
                                <asp:Panel ID="pnl1" runat="server">
                                    <asp:Label ID="lblEmpInf" runat="server" SkinID="SkinLblDatos" Font-Strikeout="False"
                                        Font-Underline="True" Visible="False"></asp:Label><br />
                                    <asp:Panel ID="pnlOpcionesDeConsulta" runat="server" Font-Size="X-Small" Font-Names="Verdana"
                                        DefaultButton="btnConsultarQna" GroupingText="Consulta de deducciones/percepciones">
                                        <br />
                                        <asp:Label ID="Label3" runat="server" SkinID="SkinLblNormal" Text="Seleccione quincena"></asp:Label>&nbsp;<asp:DropDownList
                                            ID="ddlQnasAbiertasParaCaptura" runat="server" SkinID="SkinDropDownList">
                                        </asp:DropDownList>
                                        <asp:Button ID="btnConsultarQna" OnClick="btnConsultarQna_Click" runat="server" SkinID="SkinBoton"
                                            Text="Consultar" Enabled="False"></asp:Button><br />
                                        <br />
                                    </asp:Panel>
                                </asp:Panel>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ibActualizar" EventName="Click"></asp:AsyncPostBackTrigger>
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100%">
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                <asp:Panel ID="pnl2" runat="server">
                                    <ajaxToolkit:CollapsiblePanelExtender ID="CPEPercepciones" runat="Server" TextLabelID="Label2"
                                        TargetControlID="ContentPanelPercepciones" SuppressPostBack="true" ImageControlID="Image2"
                                        ExpandedText="(Ocultar detalles...)" ExpandedImage="~/Imagenes/collapse_blue.jpg"
                                        ExpandControlID="TitlePanelPercepciones" CollapsedText="(Mostrar detalles...)"
                                        CollapsedImage="~/Imagenes/expand_blue.jpg" Collapsed="False" CollapseControlID="TitlePanelPercepciones">
                                    </ajaxToolkit:CollapsiblePanelExtender>
                                    <ajaxToolkit:CollapsiblePanelExtender ID="CPEDeducciones" runat="Server" TextLabelID="Label1"
                                        TargetControlID="ContentPanelDeducciones" SuppressPostBack="true" ImageControlID="Image1"
                                        ExpandedText="(Ocultar detalles...)" ExpandedImage="~/Imagenes/collapse_blue.jpg"
                                        ExpandControlID="TitlePanelDeducciones" CollapsedText="(Mostrar detalles...)"
                                        CollapsedImage="~/Imagenes/expand_blue.jpg" Collapsed="False" CollapseControlID="TitlePanelDeducciones">
                                    </ajaxToolkit:CollapsiblePanelExtender>
                                    <table style="width: 100%" cellspacing="0" cellpadding="0">
                                        <tbody>
                                            <tr>
                                                <td style="vertical-align: top; width: 100%; text-align: left" colspan="2">
                                                    <asp:Panel ID="TitlePanelDeducciones" runat="server" Width="100%" BorderWidth="1px"
                                                        BorderStyle="Solid" BorderColor="White" CssClass="collapsePanelHeader">
                                                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/expand_blue.jpg"></asp:Image>
                                                        Deducciones
                                                        <asp:Label ID="Label1" runat="server">
        (Mostrar detalles...)</asp:Label>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="vertical-align: top; width: 100%; text-align: left" colspan="2">
                                                    <asp:Panel ID="ContentPanelDeducciones" runat="server" Width="100%" CssClass="collapsePanel">
                                                        <asp:GridView ID="gvDeducciones" runat="server" Width="100%" SkinID="SkinGridViewEmpty"
                                                            AutoGenerateColumns="False" EmptyDataText="Sin información de deducciones">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="IdDeducCapturada" Visible="False">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblIdDeducCapturada" runat="server" Text='<%# Bind("IdDeducCapturada") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="IdPlaza" Visible="False">
                                                                    <EditItemTemplate>
                                                                        &nbsp;
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblIdPlaza" runat="server" Text='<%# Bind("IdPlaza") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Plaza" Visible="False">
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Plaza") %>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("Plaza") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="IdDeduccion" Visible="False">
                                                                    <EditItemTemplate>
                                                                        &nbsp;
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblIdDeduccion" runat="server" Text='<%# Bind("IdDeduccion") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="ClaveDeduccion" HeaderText="Clave">
                                                                    <HeaderStyle HorizontalAlign="Center" Wrap="False"></HeaderStyle>
                                                                    <ItemStyle HorizontalAlign="Center" Wrap="False"></ItemStyle>
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="NombreDeduccion" HeaderText="Deducci&#243;n"></asp:BoundField>
                                                                <asp:BoundField DataField="ImpDeduc" DataFormatString="{0:c}" HeaderText="Importe">
                                                                    <HeaderStyle HorizontalAlign="Center" Wrap="False"></HeaderStyle>
                                                                    <ItemStyle HorizontalAlign="Right" Wrap="False"></ItemStyle>
                                                                </asp:BoundField>
                                                                <asp:TemplateField HeaderText="Inicio" Visible="False">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblVigIniDeduc" runat="server" Text='<%# Bind("IdQnaIni") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" Wrap="False"></HeaderStyle>
                                                                    <ItemStyle HorizontalAlign="Center" Wrap="False"></ItemStyle>
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="VigIniDeduc" HeaderText="Inicio">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="VigFinDeduc" HeaderText="T&#233;rmino">
                                                                    <HeaderStyle HorizontalAlign="Center" Wrap="False"></HeaderStyle>
                                                                    <ItemStyle HorizontalAlign="Center" Wrap="False"></ItemStyle>
                                                                </asp:BoundField>
                                                                <asp:TemplateField>
                                                                    <ItemTemplate>
                                                                        <asp:ImageButton ID="ibEliminar" runat="server" ImageUrl="~/Imagenes/Eliminar.png"
                                                                            ToolTip="Eliminar deducción" /><ajaxToolkit:ConfirmButtonExtender ID="CFEEliminarDeduc"
                                                                                runat="server" ConfirmText="¿Está seguro de eliminar la deducción?" TargetControlID="ibEliminar">
                                                                            </ajaxToolkit:ConfirmButtonExtender>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" Wrap="False"></HeaderStyle>
                                                                    <ItemStyle HorizontalAlign="Center" Wrap="False"></ItemStyle>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <ItemTemplate>
                                                                        <asp:ImageButton ID="ibModificar" runat="server" ImageUrl="~/Imagenes/Modificar.png"
                                                                            ToolTip="Modificar deducción" />
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                    <ItemStyle HorizontalAlign="Center" Wrap="True"></ItemStyle>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <EmptyDataTemplate>
                                                            </EmptyDataTemplate>
                                                        </asp:GridView>
                                                        &nbsp;<asp:LinkButton ID="lbAgregarDeduccion" runat="server" Font-Bold="False" SkinID="SkinLinkButton"
                                                            OnClick="lbAgregarDeduccion_Click" Visible="False">Agregar deducción</asp:LinkButton>
                                                        &nbsp;<asp:LinkButton ID="lbAddPrestamoISSSTE" runat="server" Font-Bold="False" OnClick="lbAgregarDeduccion_Click"
                                                            SkinID="SkinLinkButton" Visible="False">Agregar 
                                            préstamo ISSSTE</asp:LinkButton>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="vertical-align: top; width: 100%; text-align: left" colspan="2">
                                                    <asp:Panel ID="TitlePanelPercepciones" runat="server" Width="100%" BorderWidth="1px"
                                                        BorderStyle="Solid" BorderColor="White" CssClass="collapsePanelHeader">
                                                        <asp:Image ID="Image2" runat="server" ImageUrl="~/Imagenes/expand_blue.jpg"></asp:Image>
                                                        Percepciones
                                                        <asp:Label ID="Label2" runat="server">(Mostrar detalles...)</asp:Label>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="vertical-align: top; width: 100%; text-align: left" colspan="2">
                                                    <asp:Panel ID="ContentPanelPercepciones" runat="server" Width="100%" CssClass="collapsePanel">
                                                        <table style="width: 100%" cellspacing="0" cellpadding="0">
                                                            <tbody>
                                                                <tr>
                                                                    <td style="vertical-align: top; width: 50%; text-align: left">
                                                                        <asp:GridView ID="gvPercepciones" runat="server" Width="100%" SkinID="SkinGridViewEmpty"
                                                                            AutoGenerateColumns="False" EmptyDataText="Sin información de deducciones">
                                                                            <Columns>
                                                                                <asp:TemplateField HeaderText="IdPercCapturada" Visible="False">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblIdPercCapturada" runat="server" Text='<%# Bind("IdPercCapturada") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="IdPlaza" Visible="False">
                                                                                    <EditItemTemplate>
                                                                                        &nbsp;
                                                                                    </EditItemTemplate>
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblIdPlaza" runat="server" Text='<%# Bind("IdPlaza") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Plaza" Visible="False">
                                                                                    <EditItemTemplate>
                                                                                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Plaza") %>'></asp:TextBox>
                                                                                    </EditItemTemplate>
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("Plaza") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="IdPercepcion" Visible="False">
                                                                                    <EditItemTemplate>
                                                                                        &nbsp;
                                                                                    </EditItemTemplate>
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblIdPercepcion" runat="server" Text='<%# Bind("IdPercepcion") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:BoundField DataField="ClavePercepcion" HeaderText="Clave">
                                                                                    <HeaderStyle HorizontalAlign="Center" Wrap="False"></HeaderStyle>
                                                                                    <ItemStyle HorizontalAlign="Center" Wrap="False"></ItemStyle>
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="NombrePercepcion" HeaderText="Percepci&#243;n"></asp:BoundField>
                                                                                <asp:BoundField DataField="ImpPerc" DataFormatString="{0:c}" HeaderText="Importe">
                                                                                    <HeaderStyle HorizontalAlign="Center" Wrap="False"></HeaderStyle>
                                                                                    <ItemStyle HorizontalAlign="Right" Wrap="False"></ItemStyle>
                                                                                </asp:BoundField>
                                                                                <asp:TemplateField HeaderText="Inicio" Visible="False">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblVigIniPerc" runat="server" Text='<%# Bind("IdQnaIni") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                    <HeaderStyle HorizontalAlign="Center" Wrap="False"></HeaderStyle>
                                                                                    <ItemStyle HorizontalAlign="Center" Wrap="False"></ItemStyle>
                                                                                </asp:TemplateField>
                                                                                <asp:BoundField DataField="VigIniPerc" HeaderText="Inicio">
                                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="VigFinPerc" HeaderText="T&#233;rmino">
                                                                                    <HeaderStyle HorizontalAlign="Center" Wrap="False"></HeaderStyle>
                                                                                    <ItemStyle HorizontalAlign="Center" Wrap="False"></ItemStyle>
                                                                                </asp:BoundField>
                                                                                <asp:TemplateField>
                                                                                    <ItemTemplate>
                                                                                        <asp:ImageButton ID="ibEliminar" runat="server" ImageUrl="~/Imagenes/Eliminar.png"
                                                                                            ToolTip="Eliminar percepción"></asp:ImageButton>
                                                                                        <ajaxToolkit:ConfirmButtonExtender ID="CFEEliminaPerc" runat="server" TargetControlID="ibEliminar"
                                                                                            ConfirmText="¿Está seguro de eliminar la percepción?">
                                                                                        </ajaxToolkit:ConfirmButtonExtender>
                                                                                    </ItemTemplate>
                                                                                    <ItemStyle HorizontalAlign="Center" Wrap="False"></ItemStyle>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField>
                                                                                    <ItemTemplate>
                                                                                        <asp:ImageButton ID="ibModificar" runat="server" ImageUrl="~/Imagenes/Modificar.png"
                                                                                            ToolTip="Modificar percepción"></asp:ImageButton>
                                                                                    </ItemTemplate>
                                                                                    <ItemStyle HorizontalAlign="Center" Wrap="False"></ItemStyle>
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                            <EmptyDataTemplate>
                                                                            </EmptyDataTemplate>
                                                                        </asp:GridView>
                                                                        <asp:LinkButton ID="lbAgregarPercepcion" runat="server" SkinID="SkinLinkButton" Font-Bold="False"
                                                                            Visible="False">Agregar percepción</asp:LinkButton>
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                    </asp:Panel>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="btnConsultarQna" EventName="Click"></asp:AsyncPostBackTrigger>
                                    <asp:AsyncPostBackTrigger ControlID="gvPercepciones" EventName="RowCommand" />
                                    <asp:AsyncPostBackTrigger ControlID="lbAgregarPercepcion" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="WucBuscaEmpleados1" EventName="PreRender" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
