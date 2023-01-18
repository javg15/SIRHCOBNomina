<%@ Page Language="VB" enableEventValidation="false" MasterPageFile="~/MasterPageSesionIniciada.master" AutoEventWireup="false" 
CodeFile="ABCDeducsPorPagoFijo.aspx.vb" Inherits="ABCDeducsPorPagoFijo" title="COBAEV - Nómina - ABC Deducciones por monto fijo" 
StylesheetTheme="SkinFile" %>
<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress" TagPrefix="TP_wucUpdateProgress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 100%; vertical-align: top; text-align: center; height: 100%;" align="center">
        <tr>
            <td style="vertical-align: top; text-align: right">
                <h2>
                    Sistema de nómina: ABC Deducciones por monto fijo</h2>
            </td>
        </tr>
        <tr>
            <td style="text-align: left; vertical-align: top;">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <br />
                        <asp:Label ID="lblValoresVig" runat="server" Font-Strikeout="False" Font-Underline="False"
                            SkinID="SkinLblMsjExito">Deducciones y valores vigentes para su cálculo</asp:Label><br />
                        <asp:GridView ID="gvConceptos" runat="server" AutoGenerateColumns="False" CaptionAlign="Left"
                            EmptyDataText="No existe la información solicitada" Font-Names="Verdana" Font-Size="X-Small"
                            PageSize="20" SkinID="SkinGridView" Width="100%">
                            <Columns>
                                <asp:CommandField ButtonType="Image" SelectImageUrl="~/Imagenes/Select.png" ShowSelectButton="True">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:CommandField>
                                <asp:TemplateField HeaderText="IdConcepto" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIdConcepto" runat="server" Text='<%# Bind("IdConcepto") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Deducción">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDescConceptoParaDDL" runat="server" Text='<%# Bind("DescConceptoParaDDL") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Importe">
                                    <ItemTemplate>
                                        <asp:Label ID="lblImporte" runat="server" Text='<%# Bind("Importe", "{0:c}") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="IdQnaIni" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIdQnaIni" runat="server" Text='<%# Bind("IdQnaIni") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="QnaIni" HeaderText="Inicio">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="IdQnaFin" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIdQnaFin" runat="server" Text='<%# Bind("IdQnaFin") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="QnaFin" HeaderText="Fin">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Modificar">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ibEditar" runat="server" CausesValidation="False"
                                            ImageUrl="~/Imagenes/Modificar.png" ToolTip="Modificar valores" 
                                            onclick="ibEditar_Click" />
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" Wrap="false" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Nuevo valores">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ibNuevosValores" runat="server" ImageUrl="~/Imagenes/Add2.png"
                                            ToolTip="Capturar nuevos valores" onclick="ibNuevosValores_Click" 
                                            CausesValidation="False" />
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                            </Columns>
                            <HeaderStyle CssClass="dgheader" />
                        </asp:GridView>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnGuardar" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
                <ajaxToolkit:ModalPopupExtender ID="ibNuevosValores_MPE" runat="server" 
                    DynamicServicePath="" Enabled="True" 
                    PopupControlID="pnlNuevosValores" DropShadow="true" 
                    TargetControlID="btnOpenModalPopUp1" BackgroundCssClass="modalBackground" CancelControlID="btnCloseModalPopUp1" >
                </ajaxToolkit:ModalPopupExtender>
                <asp:Button ID="btnCloseModalPopUp1" runat="server" Text="Cerrar" style="display:none"/>
                <asp:Button ID="btnOpenModalPopUp1" runat="server" Text="Cerrar" style="display:none"/>
                <asp:Panel ID="pnlNuevosValores" runat="server" CssClass="modalPopup" align="center" >
                    <asp:UpdatePanel ID="UPModalPopUp1" runat="server">
                    <ContentTemplate>
                        <table style="width:100%">
                            <tr>
                                <td colspan="2" style="text-align: left">
                                    <asp:Label ID="lblBarraTitulo" runat="server" SkinID="SkinLblHeader" 
                                        Text="Capture los nuevos valores" Width="100%"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: left">
                                    <asp:Label ID="lblImporteAnual" runat="server" SkinID="SkinLblNormal" 
                                        Text="Importe"></asp:Label>
                                </td>
                                <td style="text-align: left">
                                    <asp:TextBox ID="txtbxImporte" runat="server" MaxLength="10" 
                                        SkinID="SkinTextBox"></asp:TextBox>
                                    <asp:CompareValidator ID="CvImporteAnual" runat="server" 
                                        ControlToValidate="txtbxImporte" Display="None" 
                                        ErrorMessage="Error en el importe." Operator="DataTypeCheck" 
                                        Type="Currency"></asp:CompareValidator>
                                    <asp:RequiredFieldValidator ID="RFVImporteAnual" runat="server" 
                                        ControlToValidate="txtbxImporte" Display="None" 
                                        ErrorMessage="Omitió escribir el importe."></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: left">
                                    <asp:Label ID="Label3" runat="server" SkinID="SkinLblNormal" 
                                        Text="Quincena inicial"></asp:Label>
                                </td>
                                <td style="text-align: left">
                                    <asp:DropDownList ID="ddlInicio" runat="server" SkinID="SkinDropDownList">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: left">
                                    <asp:Label ID="lblFin" runat="server" SkinID="SkinLblNormal" 
                                        Text="Quincena final"></asp:Label>
                                </td>
                                <td style="text-align: left">
                                    <asp:DropDownList ID="ddlFin" runat="server" SkinID="SkinDropDownList">
                                    </asp:DropDownList>
                                    <asp:CompareValidator ID="CvRangoQnas" runat="server" 
                                        ControlToCompare="ddlInicio" ControlToValidate="ddlFin" Display="None" 
                                        ErrorMessage="Error en la vigencia." Operator="GreaterThanEqual" Type="Integer"></asp:CompareValidator>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" style="text-align: center">
                                    <asp:Button ID="btnCerrar" runat="server" OnClick="btnCerrar_Click" 
                                        SkinID="SkinBoton" Text="Cancelar" CausesValidation="False" />
                                    &nbsp;<asp:Button ID="btnGuardar" runat="server" 
                                        SkinID="SkinBoton" Text="Guardar" />
                                    <ajaxToolkit:ConfirmButtonExtender ID="btnGuardar_CBE" runat="server" 
                                        ConfirmText="La operación solicitada guardará las modificaciones realizadas en la Base de datos, ¿Continuar?" 
                                        Enabled="True" TargetControlID="btnGuardar">
                                    </ajaxToolkit:ConfirmButtonExtender>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" style="text-align: center">
                                    <asp:ValidationSummary ID="VSNuevosValores" runat="server" 
                                        ShowMessageBox="True" ShowSummary="False" />
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                    </asp:UpdatePanel>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td style="text-align: left">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <br />
                        <asp:Label ID="lblValoresHistoricos" runat="server" Font-Strikeout="False" Font-Underline="False"
                            SkinID="SkinLblMsjExito" Visible="False">Valores históricos</asp:Label>
                        <asp:GridView ID="gvConceptosHist" runat="server" AutoGenerateColumns="False" 
                            CaptionAlign="Left" EmptyDataText="No existe la información solicitada" 
                            Font-Names="Verdana" Font-Size="X-Small" PageSize="20" SkinID="SkinGridView" 
                            Width="100%" Visible="False">
                            <Columns>
                                <asp:CommandField ButtonType="Image" SelectImageUrl="~/Imagenes/Select.png" ShowSelectButton="True">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:CommandField>
                                <asp:TemplateField HeaderText="IdConcepto" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIdConcepto" runat="server" Text='<%# Bind("IdConcepto") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Deducción">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDescConceptoParaDDL" runat="server" Text='<%# Bind("DescConceptoParaDDL") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Importe">
                                    <ItemTemplate>
                                        <asp:Label ID="lblImporte" runat="server" Text='<%# Bind("Importe", "{0:c}") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="IdQnaIni" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIdQnaIni" runat="server" Text='<%# Bind("IdQnaIni") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="QnaIni" HeaderText="Inicio">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="IdQnaFin" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIdQnaFin" runat="server" Text='<%# Bind("IdQnaFin") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="QnaFin" HeaderText="Fin">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                            </Columns>
                            <HeaderStyle CssClass="dgheader" />
                        </asp:GridView>
                        <br />
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnGuardar" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>

