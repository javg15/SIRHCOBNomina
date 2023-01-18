<%@ page language="VB" enableeventvalidation="false" masterpagefile="~/MasterPageSesionIniciada.master" autoeventwireup="false" inherits="Consultas_Nomina_Pagos2, App_Web_xh1ifbg5" title="COBAEV - Nómina - Consulta de pagos de los empleados" stylesheettheme="SkinFile" maintainScrollPositionOnPostBack="true" %>

<%@ Register Src="~/WebControls/wucSearchEmps.ascx" TagName="wucBuscaEmpleados" TagPrefix="uc1" %>
<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress" TagPrefix="TP_wucUpdateProgress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server" >
    <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
    <table style="width: 100%; height: 300px;" align="center">
        <tr>
            <td style="vertical-align: top; text-align: right">
                <h2>
                    Sistema de nómina: Empleados (Consulta de pagos quincenales)
                </h2>
            </td>
        </tr>
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
                                    <asp:Label ID="lblRFCEmp" runat="server" Visible="False" SkinID="SkinLblDatos" Font-Underline="True"
                                        Font-Strikeout="False"></asp:Label>
                                    <asp:Label ID="lblEmpInf" runat="server" Font-Strikeout="False" Font-Underline="True"
                                        SkinID="SkinLblDatos" Visible="False"></asp:Label>
                                    <br />
                                    <asp:Panel ID="pnlQuincenas" runat="server" Font-Size="X-Small" Font-Names="Verdana"
                                        GroupingText="Consulta de pagos por año-quincena" DefaultButton="btnConsultarPago">
                                        <br />
                                        <asp:Label ID="Label7" runat="server" SkinID="SkinLblNormal" Text="Seleccione año"></asp:Label>&nbsp;<asp:DropDownList
                                            ID="ddlAños" runat="server" SkinID="SkinDropDownList" AutoPostBack="True" OnSelectedIndexChanged="ddlAños_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <br />
                                        <br />
                                        <asp:Label ID="Label3" runat="server" SkinID="SkinLblNormal" Text="Seleccione quincena"></asp:Label>&nbsp;<asp:DropDownList
                                            ID="ddlQnasPagadas" runat="server" SkinID="SkinDropDownList">
                                        </asp:DropDownList>
                                        <asp:Button ID="btnConsultarPago" OnClick="btnConsultarPago_Click" runat="server"
                                            SkinID="SkinBoton" Text="Consultar pago"></asp:Button><br />
                                        <br />
                                    </asp:Panel>
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
                                    <ajaxToolkit:CollapsiblePanelExtender ID="CPEPlazas" runat="Server" CollapseControlID="TitlePanelPlazas"
                                        Collapsed="False" CollapsedImage="~/Imagenes/expand_blue.jpg" CollapsedText="(Mostrar detalles...)"
                                        ExpandControlID="TitlePanelPlazas" ExpandedImage="~/Imagenes/collapse_blue.jpg"
                                        ExpandedText="(Ocultar detalles...)" ImageControlID="Image1" SuppressPostBack="true"
                                        TargetControlID="ContentPanelPlazas" TextLabelID="Label1">
                                    </ajaxToolkit:CollapsiblePanelExtender>
                                    <ajaxToolkit:CollapsiblePanelExtender ID="CPEPercDeduc" runat="Server" CollapseControlID="TitlePanelPercDeduc"
                                        Collapsed="False" CollapsedImage="~/Imagenes/expand_blue.jpg" CollapsedText="(Mostrar detalles...)"
                                        ExpandControlID="TitlePanelPercDeduc" ExpandedImage="~/Imagenes/collapse_blue.jpg"
                                        ExpandedText="(Ocultar detalles...)" ImageControlID="Image2" SuppressPostBack="true"
                                        TargetControlID="ContentPanelPercDeduc" TextLabelID="Label2">
                                    </ajaxToolkit:CollapsiblePanelExtender>
                                    <ajaxToolkit:CollapsiblePanelExtender ID="CPETotales" runat="Server" CollapseControlID="TitlePanelTotales"
                                        Collapsed="False" CollapsedImage="~/Imagenes/expand_blue.jpg" CollapsedText="(Mostrar detalles...)"
                                        ExpandControlID="TitlePanelTotales" ExpandedImage="~/Imagenes/collapse_blue.jpg"
                                        ExpandedText="(Ocultar detalles...)" ImageControlID="Image3" SuppressPostBack="true"
                                        TargetControlID="ContentPanelTotales" TextLabelID="Label4">
                                    </ajaxToolkit:CollapsiblePanelExtender>
                                    <ajaxToolkit:CollapsiblePanelExtender ID="CPEAdeudos" runat="server" CollapseControlID="TitlePanelAdeudos"
                                        Collapsed="False" CollapsedImage="~/Imagenes/expand_blue.jpg" CollapsedText="(Mostrar detalles...)"
                                        ExpandControlID="TitlePanelAdeudos" ExpandedImage="~/Imagenes/collapse_blue.jpg"
                                        ExpandedText="(Ocultar detalles...)" ImageControlID="Image5" SuppressPostBack="true"
                                        TargetControlID="ContentPanelAdeudos" TextLabelID="Label5">
                                    </ajaxToolkit:CollapsiblePanelExtender>
                                    <ajaxToolkit:CollapsiblePanelExtender ID="CPEDevoluciones" runat="server" CollapseControlID="TitlePanelDevoluciones"
                                        Collapsed="False" CollapsedImage="~/Imagenes/expand_blue.jpg" CollapsedText="(Mostrar detalles...)"
                                        ExpandControlID="TitlePanelDevoluciones" ExpandedImage="~/Imagenes/collapse_blue.jpg"
                                        ExpandedText="(Ocultar detalles...)" ImageControlID="Image6" SuppressPostBack="true"
                                        TargetControlID="ContentPanelDevoluciones" TextLabelID="Label6">
                                    </ajaxToolkit:CollapsiblePanelExtender>
                                    <table style="width: 100%" cellspacing="0" cellpadding="0">
                                        <tbody>
                                            <tr>
                                                <td colspan="2" style="vertical-align: top; width: 100%; text-align: left">
                                                    <asp:Label ID="LblInfDeQna" runat="server" Font-Strikeout="False" Font-Underline="True"
                                                        SkinID="SkinLblDatos" Visible="False"></asp:Label><asp:Label ID="LblMsjSobreQna"
                                                            runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="X-Small" Font-Strikeout="False"
                                                            Font-Underline="False" ForeColor="Red" Visible="False"></asp:Label><asp:Label ID="LblMsjSobreQna2"
                                                                runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="X-Small" Font-Strikeout="False"
                                                                Font-Underline="False" ForeColor="Red" Visible="False"></asp:Label>
                                                    <asp:Label ID="LblMsjSobreQna3" runat="server" Font-Bold="True" Font-Names="Verdana"
                                                        Font-Size="X-Small" Font-Strikeout="False" Font-Underline="False" ForeColor="Red"
                                                        Visible="False"></asp:Label>
                                                    <asp:LinkButton ID="lbVerRecibo" runat="server" SkinID="SkinLinkButton" Visible="False">Ver recibo</asp:LinkButton>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right">
                                                    <asp:Button ID="btnImprimirReciboPago" runat="server" OnClick="btnConsultarPago_Click"
                                                        SkinID="SkinBoton" Text="Imprimir" 
                                                        ToolTip="Ver recibo de nómina listo para imprimir" Visible="False" />
                                                    &nbsp;<asp:Button ID="btnPrintReciboPagoConImg" runat="server" 
                                                        OnClick="btnConsultarPago_Click" SkinID="SkinBoton" 
                                                        Text="Imprimir (Con formato)" 
                                                        ToolTip="Ver recibo de nómina listo para imprimir" Visible="False" />
                                                    &nbsp;<asp:Button ID="btnSendEmail" runat="server" SkinID="SkinBoton" 
                                                        Text="Enviar por email" 
                                                        ToolTip="Enviar recibo de nómina por correo electrónico." Width="133px" 
                                                        Visible="False" />
                                                    <ajaxToolkit:ConfirmButtonExtender ID="btnSendEmail_CBE" runat="server" 
                                                        ConfirmText="¿La información a enviar por email es correcta?" Enabled="True" 
                                                        TargetControlID="btnSendEmail">
                                                    </ajaxToolkit:ConfirmButtonExtender>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="vertical-align: top; width: 100%; text-align: left" colspan="2">
                                                    <asp:Panel ID="TitlePanelPlazas" runat="server" Width="100%" BorderWidth="1px" BorderStyle="Solid"
                                                        BorderColor="White" CssClass="collapsePanelHeader">
                                                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/expand_blue.jpg" />
                                                        Plazas
                                                        <asp:Label ID="Label1" runat="server">(Mostrar detalles...)</asp:Label>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="vertical-align: top; width: 100%; text-align: left" colspan="2">
                                                    <asp:Panel ID="ContentPanelPlazas" runat="server" Width="100%" CssClass="collapsePanel">
                                                        <asp:GridView ID="gvPlazas" runat="server" Width="100%" SkinID="SkinGridView" AutoGenerateColumns="False"
                                                            EmptyDataText="Sin información de plazas">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="IdPlaza" Visible="False">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblIdPlaza" runat="server" Text='<%# Bind("IdPlaza") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="Plaza" HeaderText="Plaza(s)"></asp:BoundField>
                                                                <asp:TemplateField>
                                                                    <ItemTemplate>
                                                                        <asp:ImageButton ID="ibDetalles" runat="server" ImageUrl="~/Imagenes/Detalles.gif"
                                                                            ToolTip="Ver definición de la clave presupuestal" />
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
                                            <tr>
                                                <td style="vertical-align: top; width: 100%; text-align: left" colspan="2">
                                                    <asp:Panel ID="TitlePanelPercDeduc" runat="server" Width="100%" BorderWidth="1px"
                                                        BorderStyle="Solid" BorderColor="White" CssClass="collapsePanelHeader">
                                                        <asp:Image ID="Image2" runat="server" ImageUrl="~/Imagenes/expand_blue.jpg" />
                                                        Percepciones - Deducciones
                                                        <asp:Label ID="Label2" runat="server">(Mostrar detalles...)</asp:Label>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="vertical-align: top; width: 100%; text-align: left" colspan="2">
                                                    <asp:Panel ID="ContentPanelPercDeduc" runat="server" Width="100%" CssClass="collapsePanel">
                                                        <table style="width: 100%" cellspacing="0" cellpadding="0">
                                                            <tbody>
                                                                <tr>
                                                                    <td style="vertical-align: top; width: 50%; text-align: left">
                                                                        <asp:GridView ID="gvPercepciones" runat="server" Width="100%" SkinID="SkinGridView"
                                                                            AutoGenerateColumns="False" EmptyDataText="Sin información de percepciones">
                                                                            <Columns>
                                                                                <asp:BoundField DataField="ClavePercDeduc" HeaderText="Clave"></asp:BoundField>
                                                                                <asp:BoundField DataField="NombrePercDeduc" HeaderText="Percepciones"></asp:BoundField>
                                                                                <asp:BoundField DataField="Importe" DataFormatString="{0:c}" HeaderText="Importe">
                                                                                    <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                                                                </asp:BoundField>
                                                                            </Columns>
                                                                        </asp:GridView>
                                                                    </td>
                                                                    <td style="vertical-align: top; width: 50%; text-align: left">
                                                                        <asp:GridView ID="gvDeducciones" runat="server" Width="100%" SkinID="SkinGridView"
                                                                            AutoGenerateColumns="False" EmptyDataText="Sin información de deducciones">
                                                                            <Columns>
                                                                                <asp:BoundField DataField="ClavePercDeduc" HeaderText="Clave"></asp:BoundField>
                                                                                <asp:BoundField DataField="NombrePercDeduc" HeaderText="Deducciones"></asp:BoundField>
                                                                                <asp:BoundField DataField="Importe" DataFormatString="{0:c}" HeaderText="Importe">
                                                                                    <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                                                                </asp:BoundField>
                                                                            </Columns>
                                                                        </asp:GridView>
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="vertical-align: top; width: 100%; text-align: left" colspan="2">
                                                    <asp:Panel ID="TitlePanelTotales" runat="server" Width="100%" BorderWidth="1px" BorderStyle="Solid"
                                                        BorderColor="White" CssClass="collapsePanelHeader">
                                                        <asp:Image ID="Image3" runat="server" ImageUrl="~/Imagenes/expand_blue.jpg" />
                                                        Totales
                                                        <asp:Label ID="Label4" runat="server">(Mostrar detalles...)</asp:Label>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="vertical-align: top; width: 100%; text-align: left" colspan="2">
                                                    <asp:Panel ID="ContentPanelTotales" runat="server" Width="100%" CssClass="collapsePanel">
                                                        <table style="width: 100%" cellspacing="0" cellpadding="0">
                                                            <tbody>
                                                                <tr>
                                                                    <td style="vertical-align: top; width: 50%; text-align: left">
                                                                        <asp:DetailsView ID="dvTotalPerc" runat="server" Width="100%" SkinID="SkinDetailsView"
                                                                            EmptyDataText="No existen percepciones a sumar" AutoGenerateRows="False" Height="100%">
                                                                            <Fields>
                                                                                <asp:BoundField DataField="TotalPercepciones" DataFormatString="{0:c}" HeaderText="Total percepciones">
                                                                                    <HeaderStyle Width="50%"></HeaderStyle>
                                                                                    <ItemStyle HorizontalAlign="Right" Width="50%"></ItemStyle>
                                                                                </asp:BoundField>
                                                                            </Fields>
                                                                        </asp:DetailsView>
                                                                    </td>
                                                                    <td style="vertical-align: top; width: 50%; text-align: left">
                                                                        <asp:DetailsView ID="dvTotalDeduc" runat="server" Width="100%" SkinID="SkinDetailsView"
                                                                            EmptyDataText="No existen deducciones a sumar" AutoGenerateRows="False" Height="100%">
                                                                            <Fields>
                                                                                <asp:BoundField DataField="TotalDeducciones" DataFormatString="{0:c}" HeaderText="Total deducciones">
                                                                                    <HeaderStyle Width="50%"></HeaderStyle>
                                                                                    <ItemStyle HorizontalAlign="Right" Width="50%"></ItemStyle>
                                                                                </asp:BoundField>
                                                                            </Fields>
                                                                        </asp:DetailsView>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="vertical-align: top; width: 50%; height: 37px; text-align: center">
                                                                        <asp:LinkButton ID="lbDetallePago" runat="server" Font-Size="X-Small" Font-Names="Verdana"
                                                                            ToolTip="Ver detalle del pago" Visible="False" Text="Detalle" SkinID="SkinLinkButton"></asp:LinkButton>
                                                                    </td>
                                                                    <td style="vertical-align: top; width: 50%; height: 37px; text-align: left">
                                                                        <asp:DetailsView ID="dvNetoPagar" runat="server" Width="100%" SkinID="SkinDetailsView"
                                                                            EmptyDataText="Sin información de pago" AutoGenerateRows="False" Height="100%">
                                                                            <Fields>
                                                                                <asp:BoundField DataField="ImporteACobrar" DataFormatString="{0:c}" HeaderText="Neto a pagar">
                                                                                    <HeaderStyle Width="50%"></HeaderStyle>
                                                                                    <ItemStyle HorizontalAlign="Right" Width="50%"></ItemStyle>
                                                                                </asp:BoundField>
                                                                            </Fields>
                                                                        </asp:DetailsView>
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="vertical-align: top; width: 100%; text-align: left" colspan="2">
                                                    <br />
                                                    <asp:Panel ID="TitlePanelAdeudos" runat="server" Width="100%" BorderWidth="1px" BorderStyle="Solid"
                                                        BorderColor="White" CssClass="collapsePanelHeader">
                                                        <asp:Image ID="Image5" runat="server" ImageUrl="~/Imagenes/expand_blue.jpg" />
                                                        Adeudos relacionados
                                                        <asp:Label ID="Label5" runat="server">(Mostrar detalles...)</asp:Label>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="vertical-align: top; width: 100%; text-align: left">
                                                    <asp:Panel ID="ContentPanelAdeudos" runat="server" Width="100%" CssClass="collapsePanel">
                                                        <table style="width: 100%" cellspacing="0" cellpadding="0">
                                                            <tbody>
                                                                <tr>
                                                                    <td style="vertical-align: top; text-align: left; height: 19px;" colspan="2">
                                                                        <asp:GridView ID="gvQuincenasAdeudo" runat="server" EmptyDataText="No hay quincenas adeudadas relacionadas"
                                                                            SkinID="SkinGridView" OnRowDataBound="gvQuincenasAdeudo_RowDataBound">
                                                                            <Columns>
                                                                                <asp:TemplateField HeaderText="IdQuincena" Visible="False">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblIdQuincena" runat="server" Text='<%# Bind("IdQuincena") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:BoundField DataField="Quincena" HeaderText="Quincena">
                                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                                </asp:BoundField>
                                                                                <asp:TemplateField>
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="lbDetallePagoAdeudo" runat="server" ToolTip="Ver detalle de pago (Adeudo)">Detalle</asp:LinkButton>
                                                                                    </ItemTemplate>
                                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                        </asp:GridView>
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="vertical-align: top; width: 100%; text-align: left" colspan="2">
                                                    <br />
                                                    <asp:Panel ID="TitlePanelDevoluciones" runat="server" Width="100%" BorderWidth="1px"
                                                        BorderStyle="Solid" BorderColor="White" CssClass="collapsePanelHeader">
                                                        <asp:Image ID="Image6" runat="server" ImageUrl="~/Imagenes/expand_blue.jpg" />
                                                        Devoluciones relacionadas
                                                        <asp:Label ID="Label6" runat="server">(Mostrar detalles...)</asp:Label>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="vertical-align: top; width: 100%; text-align: left">
                                                    <asp:Panel ID="ContentPanelDevoluciones" runat="server" Width="100%" CssClass="collapsePanel">
                                                        <table style="width: 100%" cellspacing="0" cellpadding="0">
                                                            <tbody>
                                                                <tr>
                                                                    <td style="vertical-align: top; text-align: left; height: 19px;" colspan="2">
                                                                        <asp:GridView ID="gvQuincenasDevoluciones" runat="server" EmptyDataText="No hay quincenas asociadas a devoluciones."
                                                                            SkinID="SkinGridView" OnRowDataBound="gvQuincenasDevoluciones_RowDataBound">
                                                                            <Columns>
                                                                                <asp:TemplateField HeaderText="IdQuincena" Visible="False">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblIdQuincena" runat="server" Text='<%# Bind("IdQuincena") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:BoundField DataField="Quincena" HeaderText="Quincena">
                                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                                </asp:BoundField>
                                                                                <asp:TemplateField>
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="lbDetallePagoDevolucion" runat="server" ToolTip="Ver detalle de pago (Devolución)">Detalle</asp:LinkButton>
                                                                                    </ItemTemplate>
                                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                        </asp:GridView>
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
                                    <asp:AsyncPostBackTrigger ControlID="btnConsultarPago" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="WucBuscaEmpleados1" EventName="PreRender" />
                                    <asp:AsyncPostBackTrigger ControlID="ibActualizar" EventName="Click" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
