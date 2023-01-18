<%@ page language="VB" enableeventvalidation="false" masterpagefile="~/MasterPageSesionIniciada.master" autoeventwireup="false" inherits="PagomaticoTXT, App_Web_sogedhgo" title="COBAEV - Nómina - Pagomático archivos TXT" stylesheettheme="SkinFile" maintainScrollPositionOnPostBack="true" %>
<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress" TagPrefix="TP_wucUpdateProgress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
                <asp:UpdatePanel ID="UPMain" runat="server">
                    <ContentTemplate>
    <table style="width: 100%; vertical-align: top; text-align: center;">
        <tr>
            <td style="vertical-align: top; text-align: right">
                <h2>
                    Sistema de nómina: Archivos de texto para transferencia electrónica bancaria
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
            <td style="text-align: left; vertical-align: top;">
                <br />
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
                <br />
            </td>
        </tr>
        <tr>
            <td style="text-align: left">
                        <asp:Panel ID="pnlOpcDeImpresion" runat="server" Font-Names="Verdana" Font-Size="X-Small"
                            GroupingText="Seleccione banco">
                            <br />
                            <asp:DropDownList ID="ddlBancos" runat="server" SkinID="SkinDropDownList" AutoPostBack="True"
                                >
                            </asp:DropDownList>
                            <br />
                        </asp:Panel>
                        <asp:Panel ID="pnlDatosComp" runat="server" Font-Names="Verdana" Font-Size="X-Small"
                            GroupingText="Datos complementarios para generar el archivo" HorizontalAlign="Left">
                            <table>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblCons" runat="server" Text="Consecutivo:" SkinID="SkinLbl9pt"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlCons" runat="server" SkinID="SkinDropDownList">
                                           
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblFecha" runat="server" Text="Fecha de pago:" 
                                            SkinID="SkinLbl9pt"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtbxFecha" runat="server" SkinID="skinTxtBx9pt"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender ID="txtbxFecha_CE" runat="server" Enabled="True" 
                                            TargetControlID="txtbxFecha">
                                        </ajaxToolkit:CalendarExtender>
                                        <asp:CompareValidator ID="txtbxFechaCV" runat="server" 
                                            ControlToValidate="txtbxFecha" Display="Dynamic" 
                                            ErrorMessage="Fecha no válida." Operator="DataTypeCheck" Type="Date">Fecha no válida.</asp:CompareValidator>
                                    </td>
                                </tr>
                            </table>

                        </asp:Panel>
            </td>
        </tr>
        <tr>
            <td style="text-align: left">
                        <table>
                            <tr>
                                <td>
                                    <asp:ImageButton ID="ibDescargar" runat="server" ImageUrl="~/Imagenes/Download.jpg"
                                        ToolTip="Descargar archivo" Visible="False" />
                                </td>
                                <td>
                                    <asp:Label ID="lblMsjDescargar" runat="server" SkinID="SkinLblDatos" 
                                        Visible="False">Descargar archivo</asp:Label>
                                </td>
                            </tr>
                        </table>
            </td>
        </tr>
        <tr>
            <td style="text-align: left">
                        <table>
                            <tr>
                                <td>
                                    <asp:ImageButton ID="ibGenerarTXT" runat="server" ImageUrl="~/Imagenes/GenerateAndDonwnload.png"
                                        ToolTip="Generar archivo y Descargar" Height="50px" Width="50px" />
                                </td>
                                <td>
                                    <asp:Label ID="lblMsj3" runat="server" SkinID="SkinLblDatos">Generar archivo y Descargar</asp:Label>
                                </td>
                            </tr>
                        </table>
                        <ajaxToolkit:ConfirmButtonExtender ID="CBEibGenerarTXT" runat="server" ConfirmText="¿Está seguro de continuar?"
                            TargetControlID="ibGenerarTXT">
                        </ajaxToolkit:ConfirmButtonExtender>
            </td>
        </tr>
    </table>
    </ContentTemplate>
    <Triggers>
        <asp:PostBackTrigger ControlID="ibGenerarTXT" />
    </Triggers>
    </asp:UpdatePanel>
</asp:Content>
