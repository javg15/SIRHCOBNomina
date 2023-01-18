<%@ page language="VB" enableeventvalidation="false" masterpagefile="~/MasterPageSesionIniciada.master" autoeventwireup="false" inherits="GeneraTXTFOVISSSTE, App_Web_cngav4hv" title="COBAEV - Nómina - FOVISSSTE archivos TXT" stylesheettheme="SkinFile" maintainScrollPositionOnPostBack="true" %>

<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress" TagPrefix="TP_wucUpdateProgress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
    <table style="width: 100%; vertical-align: top;" align="center">
        <tr>
            <td style="vertical-align: top; text-align: right">
                <h2>
                    Sistema de nómina: FOVISSSTE (Archivos TXT)
                </h2>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top; text-align: left">
                <asp:Panel ID="pnlAños" runat="server" DefaultButton="btnConsultarQuincenas" Font-Names="Verdana"
                    Font-Size="X-Small" GroupingText="Seleccione año">
                    <br />
                    <asp:DropDownList ID="ddlAños" runat="server" SkinID="SkinDropDownList">
                    </asp:DropDownList>
                    <asp:Button ID="btnConsultarQuincenas" runat="server" SkinID="SkinBoton" Text="Ver quincenas"
                        ToolTip="Consultar quincenas para el año seleccionado" OnClick="btnConsultarQuincenas_Click" /><br />
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top; text-align: left">
                <asp:Panel ID="pnlTipoDesc" runat="server" Font-Names="Verdana"
                    Font-Size="X-Small" GroupingText="Seleccione tipo de descuento">
                    <br />
                    <asp:DropDownList ID="ddlTipoDesc" runat="server" SkinID="SkinDropDownList">
                        <asp:ListItem Selected="True" Value="1">434 - DESC. PRES. HIP. FOVISSSTE</asp:ListItem>
                        <asp:ListItem Value="2">543 - DESC. PRES.FOVISSSTE PARA TODOS</asp:ListItem>
                    </asp:DropDownList>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td style="text-align: left; vertical-align: top;">
                <br />
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblMsj" runat="server" SkinID="SkinLblNormal"></asp:Label><br />
                        <asp:GridView ID="gvQuincenas" runat="server" CellPadding="1" SkinID="SkinGridView"
                            Width="100%" EmptyDataText="No existen quincenas calculadas para el año especificado."
                            OnSelectedIndexChanged="gvQuincenas_SelectedIndexChanged">
                            <Columns>
                                <asp:TemplateField HeaderText="IdQuincena" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIdQuincena" runat="server" Text='<%# Bind("IdQuincena") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Quincena">
                                    <ItemTemplate>
                                        <asp:Label ID="lblQuincena" runat="server" Text='<%# Bind("Quincena") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="Observaciones" HeaderText="Observaciones">
                                    <ItemStyle Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="FechaDePago" DataFormatString="{0:d}" HeaderText="Fecha de pago">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:CommandField ShowSelectButton="True">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:CommandField>
                            </Columns>
                        </asp:GridView>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnConsultarQuincenas" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
                <br />
            </td>
        </tr>
        <tr>
            <td style="text-align: left">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <table>
                            <tr>
                                <td>
                                    <asp:ImageButton ID="ibDescargar" runat="server" ImageUrl="~/Imagenes/Download.jpg"
                                        ToolTip="Descargar archivo" />
                                </td>
                                <td>
                                    <asp:Label ID="lblMsjDescargar" runat="server" SkinID="SkinLblDatos">Descargar archivo</asp:Label>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnConsultarQuincenas" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="gvQuincenas" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="ddlA&#241;os" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="ibGenerarTXT" EventName="Click" />
                        <asp:PostBackTrigger ControlID="ibDescargar" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td style="text-align: left">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <table>
                            <tr>
                                <td>
                                    <asp:ImageButton ID="ibGenerarTXT" runat="server" ImageUrl="~/Imagenes/Save.png"
                                        ToolTip="Generar archivo TXT" Height="50px" OnClick="ibGenerarTXT_Click" Width="50px" />
                                </td>
                                <td>
                                    <asp:Label ID="lblMsj3" runat="server" SkinID="SkinLblDatos">Generar archivo TXT</asp:Label>
                                </td>
                            </tr>
                        </table>
                        <ajaxToolkit:ConfirmButtonExtender ID="CBEibGenerarTXT" runat="server" ConfirmText="¿Está seguro de continuar?"
                            TargetControlID="ibGenerarTXT">
                        </ajaxToolkit:ConfirmButtonExtender>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnConsultarQuincenas" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="gvQuincenas" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="ddlA&#241;os" EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>
