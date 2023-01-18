<%@ Page Language="VB" EnableEventValidation="false" MasterPageFile="~/MasterPageSesionIniciada.master"
    AutoEventWireup="false" CodeFile="ImpuestosSubsidio.aspx.vb" Inherits="Consultas_Tablas_ImpuestosSubsidio"
    Title="COBAEV - Nómina - Tablas para cálculo de impuestos y subsidio para el empleo"
    StylesheetTheme="SkinFile" %>

<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress" TagPrefix="TP_wucUpdateProgress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
    <table style="width: 100%; height: 300px" align="center">
        <tr>
            <td style="vertical-align: top; text-align: right">
                <h2>
                    Sistema de nómina: Tablas para cálculo de impuestos y subsidio para el empleo
                </h2>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top; width: 100%; height: 100%; text-align: left">
                <table style="width: 100%">
                    <tr>
                        <td style="width: 100%">
                            <table style="width: 100%">
                                <tbody>
                                    <tr>
                                        <td style="width: 100%">
                                            <asp:Panel ID="pnlOpcionesDeConsulta" runat="server" Font-Size="X-Small" Font-Names="Verdana"
                                                GroupingText="Consulta de tablas de impuestos y subsidio para el empleo" DefaultButton="btnConsultarTabla">
                                                <br />
                                                <table>
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label2" runat="server" Text="Seleccione año" SkinID="SkinLblNormal"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:DropDownList ID="ddlAnios" runat="server" SkinID="SkinDropDownList">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label4" runat="server" Text="Seleccione tabla a consultar" SkinID="SkinLblNormal"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:DropDownList ID="ddlTabla" runat="server" SkinID="SkinDropDownList">
                                                                    <asp:ListItem Value="TQI">Tabla quincenal (Impuestos)</asp:ListItem>
                                                                    <asp:ListItem Value="TMI">Tabla mensual (Impuestos)</asp:ListItem>
                                                                    <asp:ListItem Value="TQS">Tabla quincenal (Subsidio para el empleo)</asp:ListItem>
                                                                    <asp:ListItem Value="TMS">Tabla mensual (Subsidio para el empleo)</asp:ListItem>
                                                                    <asp:ListItem Value="TAI">Tabla anual (Impuestos)</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td>
                                                                <asp:Button ID="btnConsultarTabla" runat="server" Text="Consultar" SkinID="SkinBoton">
                                                                </asp:Button>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                                <br />
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100%">
                            <asp:UpdatePanel ID="UPTabla" runat="server">
                                <ContentTemplate>
                                    <ajaxToolkit:CollapsiblePanelExtender ID="CPERecibos" runat="Server" TextLabelID="Label1"
                                        TargetControlID="ContentPaneRecibos" SuppressPostBack="true" ImageControlID="Image1"
                                        ExpandedText="(Ocultar detalles...)" ExpandedImage="~/Imagenes/collapse_blue.jpg"
                                        ExpandControlID="TitlePanelRecibos" CollapsedText="(Mostrar detalles...)" CollapsedImage="~/Imagenes/expand_blue.jpg"
                                        Collapsed="False" CollapseControlID="TitlePanelRecibos">
                                    </ajaxToolkit:CollapsiblePanelExtender>
                                    <table style="width: 100%" cellspacing="0" cellpadding="0">
                                        <tbody>
                                            <tr>
                                                <td style="vertical-align: top; width: 100%; text-align: left">
                                                    <asp:Panel ID="TitlePanelRecibos" runat="server" Width="100%" BorderWidth="1px" BorderStyle="Solid"
                                                        BorderColor="White" CssClass="collapsePanelHeader">
                                                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/expand_blue.jpg"></asp:Image>
                                                        &nbsp;Información sobre la tabla seleccionada
                                                        <asp:Label ID="Label1" runat="server">(Mostrar detalles...)</asp:Label>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="vertical-align: top; width: 100%; text-align: left">
                                                    <asp:Panel ID="ContentPaneRecibos" runat="server" Width="100%" CssClass="collapsePanel">
                                                        <br />
                                                        <asp:Label ID="lblInfTipoTabla" runat="server" SkinID="SkinLblNormal"></asp:Label><br />
                                                        <asp:GridView ID="gvTablaImpuesto" runat="server" AutoGenerateColumns="False" SkinID="SkinGridView"
                                                            Width="100%">
                                                            <Columns>
                                                                <asp:BoundField DataField="LimInf" HeaderText="Límite inferior" DataFormatString="{0:c}">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="LimSup" HeaderText="Límite superior" DataFormatString="{0:c}"
                                                                    NullDisplayText="En adelante">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="CuotaFija" HeaderText="Cuota fija" DataFormatString="{0:c}">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="Porc" HeaderText="Porcentaje" DataFormatString="{0:F2}%">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="Inicio" HeaderText="Inicio">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="Fin" HeaderText="Fin">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                            </Columns>
                                                            <EmptyDataRowStyle Font-Italic="True" />
                                                        </asp:GridView>
                                                        <asp:GridView ID="gvTablaSubsidio" runat="server" AutoGenerateColumns="False" SkinID="SkinGridView"
                                                            Width="100%">
                                                            <Columns>
                                                                <asp:BoundField DataField="LimInf" HeaderText="Límite inferior" DataFormatString="{0:c}">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="LimSup" HeaderText="Límite superior" DataFormatString="{0:c}"
                                                                    NullDisplayText="En adelante">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="Subsidio" HeaderText="Subsidio" DataFormatString="{0:c}">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="Inicio" HeaderText="Inicio">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="Fin" HeaderText="Fin">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                            </Columns>
                                                            <EmptyDataRowStyle Font-Italic="True" />
                                                        </asp:GridView>
                                                        <asp:GridView ID="gvTablaImpuestoAnual" runat="server" AutoGenerateColumns="False"
                                                            SkinID="SkinGridView" Width="100%">
                                                            <Columns>
                                                                <asp:BoundField DataField="LimInf" HeaderText="Límite inferior" DataFormatString="{0:c}">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="LimSup" HeaderText="Límite superior" DataFormatString="{0:c}"
                                                                    NullDisplayText="En adelante">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="CuotaFija" HeaderText="Cuota fija" DataFormatString="{0:c}">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="Porc" HeaderText="Porcentaje" DataFormatString="{0:F2}%">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                </asp:BoundField>
                                                            </Columns>
                                                            <EmptyDataRowStyle Font-Italic="True" />
                                                        </asp:GridView>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="btnConsultarTabla" EventName="Click"></asp:AsyncPostBackTrigger>
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
