<%@ Page EnableEventValidation="false" Language="VB" MasterPageFile="~/MasterPageSesionIniciada.master"
    AutoEventWireup="false" CodeFile="DiasExentosPorAnioPercepcion.aspx.vb" Inherits="DiasExentosPorAnioPercepcion"
    Title="COBAEV - N�mina - Empleados, d�as exentos por a�o/percepci�n" StylesheetTheme="SkinFile" %>

<%@ Register Src="~/WebControls/wucSearchEmps.ascx" TagName="wucBuscaEmpleados" TagPrefix="uc1" %>
<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress" TagPrefix="TP_wucUpdateProgress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
    <table style="width: 100%; height: 300px" align="center">
        <tr>
            <td style="vertical-align: top; text-align: right">
                <h2>
                    Sistema de n�mina: Empleados, d�as exentos por a�o/percepci�n
                </h2>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top; width: 100%; height: 100%; text-align: left">
                <table style="width: 100%">
                    <tr>
                        <td style="vertical-align: top; text-align: left; width: 976px;">
                            <table style="width: 100%">
                                <tr>
                                    <td>
                                        <uc1:wucBuscaEmpleados ID="WucBuscaEmpleados1" runat="server" EnableViewState="true" />
                                    </td>
                                    <td align="right" valign="top">
                                        <asp:ImageButton ID="ibActualizar" runat="server" ImageUrl="~/Imagenes/Refresh.jpg"
                                            ToolTip="Actualizar informaci�n" Visible="False" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top; text-align: left; width: 976px;">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                <asp:Panel ID="pnl1" runat="server">
                                    <ajaxToolkit:CollapsiblePanelExtender ID="CPEEmpsDiasAPagar" runat="Server" SuppressPostBack="true"
                                        CollapsedImage="~/Imagenes/expand_blue.jpg" ExpandedImage="~/Imagenes/collapse_blue.jpg"
                                        ImageControlID="Image2" CollapsedText="(Mostrar detalles...)" ExpandedText="(Ocultar detalles...)"
                                        TextLabelID="Label2" Collapsed="False" CollapseControlID="TitlePanelEmpsDiasAPagar"
                                        ExpandControlID="TitlePanelEmpsDiasAPagar" TargetControlID="ContentPanelEmpsDiasAPagar">
                                    </ajaxToolkit:CollapsiblePanelExtender>
                                    <table style="width: 100%" cellspacing="0" cellpadding="0">
                                        <tbody>
                                            <tr>
                                                <td style="vertical-align: top; text-align: left" colspan="2">
                                                    <asp:Label ID="lblEmpInf" runat="server" SkinID="SkinLblDatos" Font-Underline="True"
                                                        Font-Strikeout="False"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="vertical-align: top; text-align: left">
                                                    <asp:Panel ID="pnlA�os" runat="server" DefaultButton="btnConsultarDiasExentos" Font-Names="Verdana"
                                                        Font-Size="X-Small" GroupingText="Seleccione a�o/percepci�n">
                                                        <asp:Label ID="Label3" runat="server" SkinID="SkinLblNormal" Text="A�o:"></asp:Label>
                                                        <br />
                                                        <asp:DropDownList ID="ddlA�os" runat="server" SkinID="SkinDropDownList">
                                                        </asp:DropDownList>
                                                        <br />
                                                        <br />
                                                        <asp:Label ID="Label4" runat="server" SkinID="SkinLblNormal" Text="Percepci�n:"></asp:Label>
                                                        <br />
                                                        <asp:DropDownList ID="ddlPercepciones" runat="server" SkinID="SkinDropDownList">
                                                            <asp:ListItem Value="9">128-Aguinaldo</asp:ListItem>
                                                            <asp:ListItem Value="10">129-Prima Vacacional</asp:ListItem>
                                                        </asp:DropDownList>
                                                        <br />
                                                        <br />
                                                        <asp:Button ID="btnConsultarDiasExentos" runat="server" OnClick="btnConsultarQuincenas_Click"
                                                            SkinID="SkinBoton" Text="Consultar d�as exentos" 
                                                            ToolTip="Consultar d�as exentos para el a�o/percepci�n seleccionados." /><br />
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="vertical-align: top; width: 100%; text-align: left">
                                                    <asp:Panel ID="TitlePanelEmpsDiasAPagar" runat="server" Width="100%" BorderWidth="1px"
                                                        BorderStyle="Solid" BorderColor="White" CssClass="collapsePanelHeader">
                                                        <asp:Image ID="Image2" runat="server" ImageUrl="~/Imagenes/expand_blue.jpg"></asp:Image>
                                                        &nbsp;D�as exentos por a�o/percepci�n
                                                        <asp:Label ID="Label2" runat="server">(Mostrar detalles...)</asp:Label>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="vertical-align: top; width: 100%; text-align: left">
                                                    <asp:Panel ID="ContentPanelEmpsDiasAPagar" runat="server" Width="100%" CssClass="collapsePanel">
                                                        <asp:GridView ID="gvDiasExentosPorPerc" runat="server" 
                                                            AutoGenerateColumns="False" EmptyDataText="No existe informaci�n de d�as exentos para el empleado."
                                                            OnSelectedIndexChanged="gvEmps_SelectedIndexChanged" PageSize="20" SkinID="SkinGridView"
                                                            Width="100%">
                                                            <PagerSettings Mode="NumericFirstLast" Position="TopAndBottom" />
                                                            <EmptyDataRowStyle Font-Italic="True" />
                                                            <Columns>
                                                                <asp:CommandField ButtonType="Image" SelectImageUrl="~/Imagenes/Select.png" ShowSelectButton="True">
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:CommandField>
                                                                <asp:BoundField DataField="Quincena" HeaderText="Quincena" ReadOnly="True">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="strQuincena" HeaderText="Comentarios" ReadOnly="True">
                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="FechaDePago" DataFormatString="{0:d}" 
                                                                    HeaderText="Fecha de pago">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="Percepcion" HeaderText="Percepci�n" ReadOnly="True">
                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="Origen" HeaderText="Origen" ReadOnly="True">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                                <asp:TemplateField HeaderText="D�as exentos">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblDias" runat="server" Text='<%# Bind("DiasExentos") %>' Visible="False">
                                                                        </asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblDias" runat="server" Text='<%# Bind("DiasExentos") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                    </asp:Panel>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="WucBuscaEmpleados1" EventName="PreRender" />
                                    <asp:AsyncPostBackTrigger ControlID="gvDiasExentosPorPerc" EventName="SelectedIndexChanged" />
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
