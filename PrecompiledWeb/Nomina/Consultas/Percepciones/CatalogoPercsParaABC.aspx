<%@ page language="VB" enableeventvalidation="false" masterpagefile="~/MasterPageSesionIniciada.master" autoeventwireup="false" inherits="CatalogoPercsParaABC, App_Web_nszpy5ff" title="COBAEV - Nómina - Listado de percepciones para ABC" stylesheettheme="SkinFile" maintainScrollPositionOnPostBack="true" %>

<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress" TagPrefix="TP_wucUpdateProgress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<script type="text/javascript">
    self.focus();
</script>
    <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table style="width: 100%" align="center">
                <tr>
                    <td style="vertical-align: top; text-align: right">
                        <h2>
                            Sistema de nómina: Catálogo de Percepciones para ABC
                        </h2>
                    </td>
                </tr>
                <tr>
                    <td style="vertical-align: top; text-align: left">
                        <asp:LinkButton ID="lbCrearNuevaPerc" runat="server" Text="Crear nueva percepción" SkinID="SkinLinkButton"></asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td style="width: 100%; text-align: left;">
                        <asp:GridView ID="gvPercs" runat="server" CellPadding="1" SkinID="SkinGridView"
                            Width="100%" EmptyDataText="Sin información de percepciones">
                            <Columns>
                                <asp:CommandField ButtonType="Image" SelectImageUrl="~/Imagenes/Select.png" ShowSelectButton="True">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:CommandField>
                                <asp:TemplateField HeaderText="IdPercepcion" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIdPercepcion" runat="server" Text='<%# Bind("IdPercepcion") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="ClavePercepcion" HeaderText="Clave">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="NombrePercepcion" HeaderText="Nombre">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle Wrap="False" HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ibDetalles" runat="server" ImageUrl="~/Imagenes/Detalles.gif"
                                            ToolTip="Ver detalles de la Percepción" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ibModificar" runat="server" ImageUrl="~/Imagenes/Modificar.png" ToolTip="Modificar datos de la Percepción" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Wrap="False" />
                                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ibCrearCopiaPerc" runat="server" 
                                            ImageUrl="~/Imagenes/Add2.png" 
                                            ToolTip="Crear percepción a partir de éste registro" 
                                            onclick="ibCrearCopiaPerc_Click" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Wrap="True" />
                                    <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
