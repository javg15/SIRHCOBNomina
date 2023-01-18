<%@ page language="VB" enableeventvalidation="false" masterpagefile="~/MasterPageBlanca.master" autoeventwireup="false" inherits="Administracion_Categorias_Percepciones, App_Web_exsb2btg" title="COBAEV - Nómina - Administración de percepciones por categoría" stylesheettheme="SkinFile" maintainScrollPositionOnPostBack="true" %>
<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress" TagPrefix="TP_wucUpdateProgress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
    <table style="width: 70%; vertical-align: top; text-align: center;">
        <tr>
            <td style="vertical-align: top; text-align: right">
                <h2>
                    Sistema de nómina: Categorías (Percepciones relacionadas)
                </h2>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top; text-align: left">
                <asp:Label ID="LblCategoria" runat="server" Font-Strikeout="False" Font-Underline="False"
                    SkinID="SkinLblMsjExito">Categoría</asp:Label><asp:GridView ID="gvCategoria" runat="server"
                        SkinID="SkinGridView">
                        <Columns>
                            <asp:TemplateField HeaderText="Clave">
                                <FooterTemplate>
                                    <br />
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbClaveCategoria" runat="server" CommandName="ClaveCategoria"
                                        Text='<%# Bind("ClaveCategoria") %>' ToolTip="Ver historia de ésta categoría"></asp:LinkButton>
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
                        <asp:Label ID="LblPercepcionesHistoria" runat="server" Font-Strikeout="False" Font-Underline="False"
                            SkinID="SkinLblMsjExito">Percepciones asociadas</asp:Label><br />
                        <asp:GridView ID="gvPercepciones" runat="server" CellPadding="1" SkinID="SkinGridView"
                            Width="100%">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chckbxPercepcion" runat="server" Checked='<%# Bind("PercepcionIncluida") %>'
                                            Enabled="False" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="IdCategoria" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIdPercepcion" runat="server" Text='<%# Bind("IdPercepcion") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="ClavePercepcion" HeaderText="Clave">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="NombrePercepcion" HeaderText="Percepci&#243;n">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                            </Columns>
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
            </td>
        </tr>
    </table>
</asp:Content>
