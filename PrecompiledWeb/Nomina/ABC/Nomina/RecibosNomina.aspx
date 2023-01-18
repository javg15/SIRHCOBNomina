<%@ page language="VB" enableeventvalidation="false" masterpagefile="~/MasterPageSesionIniciada.master" autoeventwireup="false" inherits="ABC_Nomina_RecibosNomina, App_Web_sogedhgo" title="COBAEV - Nómina - Recibos de nómina" stylesheettheme="SkinFile" maintainScrollPositionOnPostBack="true" %>

<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress" TagPrefix="TP_wucUpdateProgress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table style="width: 100%; vertical-align: top;" align="center">
                <tr>
                    <td style="vertical-align: top; text-align: right">
                        <h2>
                            Sistema de nómina: Envío de comprobantes de pago por correo electrónico
                        </h2>
                    </td>
                </tr>
            </table>
            <asp:MultiView ID="mv_EnvioComprobantes" runat="server">
                <asp:View ID="view_Qnas" runat="server">
                    <asp:Panel ID="pnl1" runat="server"  Visible="true">
                        <table style="width: 100%; vertical-align: top;" align="center">
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
                                            <asp:TemplateField HeaderText="IdQuincena" Visible="False"><ItemTemplate><asp:Label ID="lblIdQuincena" runat="server" Text='<%# Bind("IdQuincena") %>'></asp:Label></ItemTemplate></asp:TemplateField>
                                            <asp:TemplateField HeaderText="Quincena"><ItemTemplate><asp:Label ID="lblQuincena" runat="server" Text='<%# Bind("Quincena") %>'></asp:Label></ItemTemplate><HeaderStyle HorizontalAlign="Left" Wrap="False" /><ItemStyle HorizontalAlign="Left" Wrap="False" /></asp:TemplateField>
                                            <asp:BoundField DataField="Observaciones" HeaderText="Observaciones"><ItemStyle Wrap="False" /></asp:BoundField>
                                            <asp:BoundField DataField="FechaDePago" DataFormatString="{0:d}" HeaderText="Fecha de pago"><HeaderStyle HorizontalAlign="Center" /><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                                            <asp:CommandField ShowSelectButton="True"><ItemStyle HorizontalAlign="Center" /></asp:CommandField>
                                        </Columns>
                                    </asp:GridView>
                                    <br />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="pnl3" runat="server"  Visible="true">
                        <table>
                            <tr>
                                <td style="text-align: center">
                                    <asp:ImageButton ID="ibGeneraPDF" runat="server" ImageUrl="~/Imagenes/GeneraReciboPDF.jpg"
                                        ToolTip="Generar recibos en PDF" Visible="true" />
<ajaxToolkit:ConfirmButtonExtender
                            ID="ibGeneraPDF_CBE" runat="server" ConfirmText="Esta operación durará varios minutos, ¿Desea continuar?"
                            Enabled="True" TargetControlID="ibGeneraPDF">
                        </ajaxToolkit:ConfirmButtonExtender>
                                    <asp:ImageButton ID="ibEnviarEmail" runat="server" ImageUrl="~/Imagenes/EnviarReciboEmail.jpg"
                                        ToolTip="Enviar recibos por correo electrónico" Visible="true" />
                                    <ajaxToolkit:ConfirmButtonExtender ID="ibEnviarEmail_CBE" runat="server" 
                                        ConfirmText="Esta operación durará varios minutos, ¿Desea continuar?"
                                        Enabled="True" TargetControlID="ibEnviarEmail"></ajaxToolkit:ConfirmButtonExtender>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>                    
                </asp:View>
            </asp:MultiView>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
