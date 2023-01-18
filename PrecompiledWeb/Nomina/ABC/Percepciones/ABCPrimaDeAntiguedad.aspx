<%@ page language="VB" enableeventvalidation="false" masterpagefile="~/MasterPageSesionIniciada.master" autoeventwireup="false" inherits="ABCPrimaDeAntiguedad, App_Web_ou3vf2bz" title="COBAEV - Nómina - ABC Prima de Antigüedad" stylesheettheme="SkinFile" maintainScrollPositionOnPostBack="true" %>
<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress" TagPrefix="TP_wucUpdateProgress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<style type="text/css">
    .modalBackground
    {
        background-color:Silver;
        filter: alpha(opacity=60);
        opacity: 0.5;
    }
    .modalPopup
    {
        background-color: #FFFFFF;
        border-width: 3px;
        border-style: solid;
        border-color: maroon;
        padding-top: 5px;
        padding-left: 5px;
        padding-right:5px;
        width: 400px;
        height: 240px;
    }
 </style>
<TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
    <table style="width: 100%; vertical-align: top; text-align: center; height: 100%;" align="center">
        <tr>
            <td style="vertical-align: top; text-align: right">
                <h2>
                    Sistema de nómina: ABC Prima de Antigüedad</h2>
            </td>
        </tr>
        <tr>
            <td style="text-align: left; vertical-align: top;">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <br />
                        <asp:Label ID="lblValoresVig" runat="server" Font-Strikeout="False" Font-Underline="False"
                            SkinID="SkinLblMsjExito">Valores vigentes para su cálculo</asp:Label><br />
                        <asp:GridView ID="gvPercepciones" runat="server" AutoGenerateColumns="False" CaptionAlign="Left"
                            EmptyDataText="No existe la información solicitada." Font-Names="Verdana" Font-Size="X-Small"
                            PageSize="20" SkinID="SkinGridView" Width="100%">
                            <Columns>
                                <asp:CommandField ButtonType="Image" SelectImageUrl="~/Imagenes/Select.png" ShowSelectButton="True">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:CommandField>
                                <asp:TemplateField HeaderText="IdEmpFuncion" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIdEmpFuncion" runat="server" Text='<%# Bind("IdEmpFuncion") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Función del empleado">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDescEmpFuncion" runat="server" Text='<%# Bind("DescEmpFuncion") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Años (Límite inferior)">
                                    <ItemTemplate>
                                        <asp:Label ID="lblstrLimiteInf" runat="server" Text='<%# Bind("strAniosLimiteInf") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Años (Límite inferior)" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblLimiteInf" runat="server" Text='<%# Bind("AniosLimiteInf") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Años (Límite superior)">
                                    <ItemTemplate>
                                        <asp:Label ID="lblAniosLimiteSup" runat="server" Text='<%# Bind("strAniosLimiteSup") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Años (Límite superior)" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblLimiteSup" runat="server" Text='<%# Bind("AniosLimiteSup") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Porcentaje">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPorcentaje" runat="server" Text='<%# Bind("Porcentaje", "{0:F2}%") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
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
                                            ImageUrl="~/Imagenes/Modificar.png" ToolTip="Modificar valores para éste rango de años" 
                                            onclick="ibEditar_Click" />
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" Wrap="false" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Nuevo valores">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ibNuevosValores" runat="server" ImageUrl="~/Imagenes/Add2.png"
                                            ToolTip="Capturar nuevos valores para éste rango de años" onclick="ibNuevosValores_Click" 
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
                                    <asp:Label ID="Label1" runat="server" SkinID="SkinLblNormal" 
                                        Text="Años (Límite inferior)"></asp:Label>
                                </td>
                                <td style="text-align: left">
                                    <asp:DropDownList ID="ddlLimInf" runat="server" SkinID="SkinDropDownList">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: left">
                                    <asp:Label ID="Label2" runat="server" SkinID="SkinLblNormal" 
                                        Text="Años (Límite superior)"></asp:Label>
                                </td>
                                <td style="text-align: left">
                                    <asp:DropDownList ID="ddlLimSup" runat="server" SkinID="SkinDropDownList">
                                    </asp:DropDownList>
                                    <asp:CompareValidator ID="CvRangoAnios" runat="server" 
                                        ControlToCompare="ddlLimInf" ControlToValidate="ddlLimSup" Display="None" 
                                        ErrorMessage="Error en el rango de años." Operator="GreaterThanEqual" 
                                        Type="Integer"></asp:CompareValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: left">
                                    <asp:Label ID="lblPorcentaje" runat="server" SkinID="SkinLblNormal" 
                                        Text="Porcentaje"></asp:Label>
                                </td>
                                <td style="text-align: left">
                                    <asp:TextBox ID="txtbxPorcentaje" runat="server" SkinID="SkinTextBox" MaxLength="5"></asp:TextBox>
                                    <asp:CompareValidator ID="CVPorcentaje" runat="server" 
                                        ControlToValidate="txtbxPorcentaje" Display="None" 
                                        ErrorMessage="Error en el porcentaje." Operator="DataTypeCheck" Type="Currency"></asp:CompareValidator>
                                    <asp:RequiredFieldValidator ID="RFVPorcentaje" runat="server" 
                                        ControlToValidate="txtbxPorcentaje" Display="None" 
                                        ErrorMessage="Omitió escribir el porcentaje."></asp:RequiredFieldValidator>
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
                                    <asp:CompareValidator ID="CVRangoQnas" runat="server" 
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
                            SkinID="SkinLblMsjExito" Visible="false">Valores históricos</asp:Label>
                        <asp:GridView ID="gvPercsHist" runat="server" AutoGenerateColumns="False" 
                            CaptionAlign="Left" EmptyDataText="No existe la información solicitada." 
                            Font-Names="Verdana" Font-Size="X-Small" PageSize="20" SkinID="SkinGridView" 
                            Width="100%">
                            <Columns>
                                <asp:CommandField ButtonType="Image" SelectImageUrl="~/Imagenes/Select.png" ShowSelectButton="True">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:CommandField>
                                <asp:TemplateField HeaderText="IdEmpFuncion" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIdEmpFuncion" runat="server" Text='<%# Bind("IdEmpFuncion") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Función del empleado">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDescEmpFuncion" runat="server" Text='<%# Bind("DescEmpFuncion") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Años (Límite inferior)">
                                    <ItemTemplate>
                                        <asp:Label ID="lblstrAniosLimiteInf" runat="server" Text='<%# Bind("strAniosLimiteInf") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Años (Límite superior)">
                                    <ItemTemplate>
                                        <asp:Label ID="lblstrAniosLimiteSup" runat="server" Text='<%# Bind("strAniosLimiteSup") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Porcentaje">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPorcentaje" runat="server" Text='<%# Bind("Porcentaje", "{0:F2}%") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
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

