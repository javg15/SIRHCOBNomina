<%@ Page Language="VB" EnableEventValidation="false" MasterPageFile="~/MasterPageSesionIniciada.master"
    AutoEventWireup="false" CodeFile="GeneraTXTISSSTE2.aspx.vb" Inherits="GeneraTXTsISSSTE2"
    Title="COBAEV - N�mina - ISSSTE archivos TXT" StylesheetTheme="SkinFile" %>

<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress" TagPrefix="TP_wucUpdateProgress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
    <table style="width: 100%; vertical-align: top;" align="center">
        <tr>
            <td style="vertical-align: top; text-align: right">
                <h2>
                    Sistema de n�mina: ISSSTE (Archivos TXT, para Transferencia de Informaci�n AL 
                    SISTEMA SERICA-N�MINAS)</h2>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top; text-align: left">
                <asp:Panel ID="pnlA�os" runat="server" DefaultButton="btnConsultarQuincenas" Font-Names="Verdana"
                    Font-Size="X-Small" GroupingText="Seleccione a�o">
                    <br />
                    <asp:DropDownList ID="ddlA�os" runat="server" SkinID="SkinDropDownList">
                    </asp:DropDownList>
                    <asp:Button ID="btnConsultarQuincenas" runat="server" SkinID="SkinBoton" Text="Ver quincenas"
                        ToolTip="Consultar quincenas para el a�o seleccionado" OnClick="btnConsultarQuincenas_Click" /><br />
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
                            Width="100%" EmptyDataText="No existen quincenas calculadas para el a�o especificado."
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
                                <asp:TemplateField HeaderText="Retroactividad">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkbxPagoDeRetro" runat="server" Enabled="false"
                                            Checked='<%# Bind("PagoDeRetroactividad") %>' />
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
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
                        <asp:Panel ID="pnlTipoDeArchivo" runat="server" Font-Names="Verdana" Font-Size="X-Small"
                            GroupingText="Seleccione tipo de archivo">
                            <br />
                            <asp:DropDownList ID="ddlTipoArchivo" runat="server" SkinID="SkinDropDownList" AutoPostBack="True"
                                OnSelectedIndexChanged="ddlBancos_SelectedIndexChanged">
                                <asp:ListItem Value="0">N�mina y Recibos</asp:ListItem>
                                <asp:ListItem Value="1">N�mina y Recibos (RP)</asp:ListItem>
                                <asp:ListItem Value="2">Recibos</asp:ListItem>
                                <asp:ListItem Value="3">Recibos (RP)</asp:ListItem>
                                <asp:ListItem Value="4">Devoluciones n�mina</asp:ListItem>
                                <asp:ListItem Value="5">Devoluciones n�mina(RP)</asp:ListItem>
                                <asp:ListItem Value="6">Devoluciones recibos</asp:ListItem>
                                <asp:ListItem Value="7">Devoluciones recibos (RP)</asp:ListItem>
                                <asp:ListItem Value="8">N�mina extraordinaria</asp:ListItem>
                                <asp:ListItem Value="9">N�mina extraordinaria (RP)</asp:ListItem>
                                <asp:ListItem Value="10">N�mina incremento salarial</asp:ListItem>
                                <asp:ListItem Value="11">N�mina incremento salarial (RP)</asp:ListItem>
                                <asp:ListItem Value="12">N�mina primeros pagos</asp:ListItem>
                                <asp:ListItem Value="13">N�mina primeros pagos (RP)</asp:ListItem>
                                <asp:ListItem Value="14">Devoluciones n�mina extraordinaria</asp:ListItem>
                                <asp:ListItem Value="15">Devoluciones n�mina extraordinaria (RP)</asp:ListItem>
                                <asp:ListItem Value="16">Nomina Estatal</asp:ListItem>
                                <asp:ListItem Value="17">N�mina incremento salarial (Estatal)</asp:ListItem>
                            </asp:DropDownList>
                            <br />
                            <br />
                            <br />
                            <asp:CheckBox ID="chkPrestamo" runat="server" Text="S�lo pr�stamos" />
                        </asp:Panel>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlTipoArchivo" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="gvQuincenas" 
                            EventName="SelectedIndexChanged" />
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
                                        ToolTip="Generar archivo TXT" Height="50px" OnClick="ibGenerarTXT_Click" Width="50px" />
                                </td>
                                <td>
                                    <asp:Label ID="lblMsj3" runat="server" SkinID="SkinLblDatos">Generar archivo TXT</asp:Label>
                                </td>
                            </tr>
                        </table>
                        <ajaxToolkit:ConfirmButtonExtender ID="CBEibGenerarTXT" runat="server" ConfirmText="�Est� seguro de continuar?"
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
