<%@ Page Language="VB" EnableEventValidation="false" MasterPageFile="~/MasterPageSesionIniciada.master"
    AutoEventWireup="false" CodeFile="PercepcionesProgramadas.aspx.vb" Inherits="Consultas_Percepciones_Programadas"
    Title="COBAEV - Nómina - Percepciones programadas" StylesheetTheme="SkinFile" %>

<%@ Register Src="~/WebControls/wucBuscaEmpleados.ascx" TagName="wucBuscaEmpleados" TagPrefix="uc1" %>
<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress" TagPrefix="TP_wucUpdateProgress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
    <table style="width: 100%" align="center">
        <tr>
            <td style="vertical-align: top; text-align: right">
                <h2>
                    Sistema de nómina: Percepciones programadas para pago quincenal
                </h2>
            </td>
        </tr>
        <tr>
            <td style="text-align: left;">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <br />
                        <asp:Panel ID="pnlSemestres" runat="server" DefaultButton="btnConsulta" Font-Names="Verdana"
                            Font-Size="X-Small" GroupingText="Seleccione semestre">
                            <br />
                            <asp:DropDownList ID="ddlSemestres" runat="server" SkinID="SkinDropDownList">
                            </asp:DropDownList>
                            <asp:Button ID="btnConsulta" runat="server" SkinID="SkinBoton" Text="Consultar" ToolTip="Consultar percepciones programadas para el semestre seleccionado"
                                OnClick="btnConsulta_Click" /><br />
                            <br />
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td style="width: 100%; text-align: left;">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <ajaxToolkit:CollapsiblePanelExtender ID="CPEPercProg" runat="Server" CollapseControlID="TitlePanelPercProg"
                            Collapsed="False" CollapsedImage="~/Imagenes/expand_blue.jpg" CollapsedText="(Mostrar detalles...)"
                            ExpandControlID="TitlePanelPercProg" ExpandedImage="~/Imagenes/collapse_blue.jpg"
                            ExpandedText="(Ocultar detalles...)" ImageControlID="Image1" SuppressPostBack="true"
                            TargetControlID="ContentPanelPercProg" TextLabelID="Label1">
                        </ajaxToolkit:CollapsiblePanelExtender>
                        <table cellpadding="0" cellspacing="0" style="width: 100%">
                            <tbody>
                                <tr>
                                    <td colspan="2" style="vertical-align: top; width: 100%; text-align: left">
                                        <asp:Panel ID="TitlePanelPercProg" runat="server" BorderColor="White" BorderStyle="Solid"
                                            BorderWidth="1px" CssClass="collapsePanelHeader" Width="100%">
                                            <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/expand_blue.jpg" />
                                            Percepciones programadas por semestre &nbsp;<asp:Label ID="Label1" runat="server">(Mostrar detalles...)</asp:Label>
                                        </asp:Panel>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="vertical-align: top; width: 100%; text-align: left">
                                        <asp:Panel ID="ContentPanelPercProg" runat="server" CssClass="collapsePanel" Width="100%">
                                            <asp:GridView ID="gvPercProg" runat="server" CellPadding="1" SkinID="SkinGridView"
                                                Width="100%" EmptyDataText="No existe detalle de pago para el semestre seleccionado.">
                                                <Columns>
                                                    <asp:BoundField DataField="Semestre" HeaderText="Semestre">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:TemplateField HeaderText="IdPercepcion" Visible="False">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblIdPercepcion" runat="server" Text='<%# Bind("IdPercepcion") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="ClavePercepcion" HeaderText="Clave percepci&#243;n">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="NombrePercepcion" HeaderText="Percepci&#243;n">
                                                        <ItemStyle Wrap="False" />
                                                    </asp:BoundField>
                                                    <asp:TemplateField HeaderText="Parte">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblNumParte" runat="server" Text='<%# Bind("NumParte") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="IdQnaPago" Visible="False">
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("IdQnaPago") %>'></asp:TextBox>
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblIdQnaPago" runat="server" Text='<%# Bind("IdQnaPago") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Quincena de pago">
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("QnaPago") %>'></asp:TextBox>
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblQnaPago" runat="server" Text='<%# Bind("QnaPago") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Percepciones/Deducciones">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="ibPercDeduc" runat="server" ImageUrl="~/Imagenes/Money.gif"
                                                                ToolTip="Ver Percepciones/Deducciones relacionadas con la percepción" />
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Modificar">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="ibModificar" runat="server" ImageUrl="~/Imagenes/Modificar.png" />
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
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnConsulta" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>
