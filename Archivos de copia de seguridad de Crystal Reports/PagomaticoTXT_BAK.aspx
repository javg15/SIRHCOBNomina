<%@ Page Language="VB" EnableEventValidation="false" MasterPageFile="~/MasterPageSesionIniciada.master"
    AutoEventWireup="false" CodeFile="PagomaticoTXT_BAK.aspx.vb" Inherits="PagomaticoTXTBAK"
    Title="COBAEV - N?mina - Pagom?tico archivos TXT" StylesheetTheme="SkinFile" %>
<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress" TagPrefix="TP_wucUpdateProgress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
    <table style="width: 100%; vertical-align: top; text-align: center;">
        <tr>
            <td style="vertical-align: top; text-align: right">
                <h2>
                    Sistema de n?mina: Archivos de texto para transferencia electr?nica bancaria
                </h2>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top; text-align: left">
                <asp:Panel ID="pnlA?os" runat="server" DefaultButton="btnConsultarQuincenas" Font-Names="Verdana"
                    Font-Size="X-Small" GroupingText="Seleccione a?o">
                    <br />
                    <asp:DropDownList ID="ddlA?os" runat="server" SkinID="SkinDropDownList">
                    </asp:DropDownList>
                    <asp:Button ID="btnConsultarQuincenas" runat="server" SkinID="SkinBoton" Text="Ver quincenas"
                        ToolTip="Consultar quincenas para el a?o seleccionado" OnClick="btnConsultarQuincenas_Click" /><br />
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
                            Width="100%" EmptyDataText="No existen quincenas calculadas para el a?o especificado."
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
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="pnlOpcDeImpresion" runat="server" Font-Names="Verdana" Font-Size="X-Small"
                            GroupingText="Seleccione banco">
                            <br />
                            <asp:DropDownList ID="ddlBancos" runat="server" SkinID="SkinDropDownList" AutoPostBack="True"
                                OnSelectedIndexChanged="ddlBancos_SelectedIndexChanged">
                            </asp:DropDownList>
                            <br />
                        </asp:Panel>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlBancos" EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
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
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <table>
                            <tr>
                                <td>
                                    <asp:ImageButton ID="ibGenerarTXT" runat="server" ImageUrl="~/Imagenes/Save.png"
                                        ToolTip="Generar archivo TXT" Height="50px" Width="50px" />
                                </td>
                                <td>
                                    <asp:Label ID="lblMsj3" runat="server" SkinID="SkinLblDatos">Generar archivo TXT</asp:Label>
                                </td>
                            </tr>
                        </table>
                        <ajaxToolkit:ConfirmButtonExtender ID="CBEibGenerarTXT" runat="server" ConfirmText="?Est? seguro de continuar?"
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
