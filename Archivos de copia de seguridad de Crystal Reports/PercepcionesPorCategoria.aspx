<%@ Page Language="VB" enableEventValidation="false" MasterPageFile="~/MasterPageBlanca.master" AutoEventWireup="false" CodeFile="PercepcionesPorCategoria.aspx.vb" Inherits="Consultas_PercepcionesPorCategoria" title="COBAEV - Nómina - Percepciones ordinarias por categoría" StylesheetTheme="SkinFile" %>
<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress" TagPrefix="TP_wucUpdateProgress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
    <table style="width: 100%; vertical-align: top; text-align: center; height: 100%;">
        <tr>
            <td style="vertical-align: top; text-align: right">
                <h2>
                    Sistema de nómina: Categoría (Percepciones ordinarias asociadas)</h2>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top; text-align: left">
                <asp:Label ID="LblCategoria" runat="server" Font-Strikeout="False" Font-Underline="False"
                    SkinID="SkinLblMsjExito">Categoría</asp:Label><br />
                <asp:GridView ID="gvCategoria" runat="server" SkinID="SkinGridView">
                    <Columns>
                        <asp:TemplateField HeaderText="Clave">
                            <FooterTemplate>
                                <br />
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:LinkButton ID="lbClaveCategoria" runat="server" Text='<%# Bind("ClaveCategoria") %>'
                                    ToolTip="Ver historia de ésta categoría" CommandName="ClaveCategoria"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="DescCategoria" HeaderText="Categor&#237;a" />
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td style="text-align: left; vertical-align: top;">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <br />
                        <asp:Label ID="LblPercepciones" runat="server" Font-Strikeout="False" Font-Underline="False"
                            SkinID="SkinLblMsjExito">Percepciones ordinarias asociadas</asp:Label><br />
                        <asp:GridView ID="gvPercepciones" runat="server" AutoGenerateColumns="False" CaptionAlign="Left"
                            EmptyDataText="No existen percepciones asociadas a la categoría" Font-Names="Verdana" Font-Size="X-Small"
                            PageSize="20" SkinID="SkinGridView" Width="100%" OnRowCommand="gvPercepciones_RowCommand">
                            <Columns>
                                <asp:TemplateField HeaderText="IdPercepcion" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIdPercepcion" runat="server" Text='<%# Bind("IdPercepcion") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Clave">
                                    <ItemTemplate>
                                        <asp:Label ID="lblClavePercepcion" runat="server" Text='<%# Bind("ClavePercepcion") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="NombrePercepcion" HeaderText="Percepci&#243;n" />
                                <asp:TemplateField HeaderText="IdZonaEco" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIdZonaEco" runat="server" Text='<%# Bind("IdZonaEco") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="ClaveZonaEco" HeaderText="ZE">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="IdQnaVigIniPerc" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIdQnaVigIniPerc" runat="server" Text='<%# Bind("IdQnaVigIniPerc") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="VigIniPerc" HeaderText="Inicio">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="IdQnaVigFinPerc" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIdQnaVigFinPerc" runat="server" Text='<%# Bind("IdQnaVigFinPerc") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="VigFinPerc" HeaderText="Fin">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ImpMenPerc" DataFormatString="{0:c}" HeaderText="Importe">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Modificar">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ibModificar" runat="server" ImageUrl="~/Imagenes/Modificar.png" CommandName="Modificar" ToolTip="Modificar los valores actuales" />
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Nuevo valores">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ibNuevosValores" runat="server" ImageUrl="~/Imagenes/Add2.png"
                                            ToolTip="Capturara nuevo importe" />
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                            </Columns>
                            <HeaderStyle CssClass="dgheader" />
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td style="text-align: left">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <br />
                        <asp:Label ID="LblPercepcionesHistoria" runat="server" Font-Strikeout="False" Font-Underline="False"
                            SkinID="SkinLblMsjExito"></asp:Label><br />
                        <asp:GridView ID="gvPercepcionesHistoria" runat="server" AutoGenerateColumns="False" CaptionAlign="Left"
                            EmptyDataText="No existe historia" Font-Names="Verdana" Font-Size="X-Small"
                            PageSize="20" SkinID="SkinGridView" Width="100%" Visible="False" OnRowDataBound="gvPercepcionesHistoria_RowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="IdPercepcion" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIdPercepcion" runat="server" Text='<%# Bind("IdPercepcion") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Clave">
                                    <ItemTemplate>
                                        <asp:Label ID="lblClavePerc" runat="server" Text='<%# Bind("ClavePercepcion") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="NombrePercepcion" HeaderText="Percepci&#243;n" />
                                <asp:TemplateField HeaderText="IdZonaEco" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIdZonaEco" runat="server" Text='<%# Bind("IdZonaEco") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="ClaveZonaEco" HeaderText="ZE">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="IdQnaVigIniPerc" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIdQnaVigIniPerc" runat="server" Text='<%# Bind("IdQnaVigIniPerc") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="VigIniPerc" HeaderText="Inicio">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="IdQnaVigFinPerc" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIdQnaVigFinPerc" runat="server" Text='<%# Bind("IdQnaVigFinPerc") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="VigFinPerc" HeaderText="Fin">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ImpMenPerc" DataFormatString="{0:c}" HeaderText="Importe">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                            </Columns>
                            <HeaderStyle CssClass="dgheader" />
                        </asp:GridView>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="gvCategoria" EventName="RowCommand" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>

