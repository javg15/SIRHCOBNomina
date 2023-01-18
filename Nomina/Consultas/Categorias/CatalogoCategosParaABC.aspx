<%@ Page Language="VB" EnableEventValidation="false" MasterPageFile="~/MasterPageSesionIniciada.master"
    AutoEventWireup="false" CodeFile="CatalogoCategosParaABC.aspx.vb" Inherits="CatalogoCategosParaABC"
    Title="COBAEV - N�mina - Listado de categor�as para ABC" StylesheetTheme="SkinFile" %>

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
                            Sistema de n�mina: Cat�logo de Categor�as para ABC
                        </h2>
                    </td>
                </tr>
                <tr>
                    <td style="vertical-align: top; text-align: left">
                        <asp:LinkButton ID="lbCrearNuevaCatego" runat="server" Text="Crear nueva categor�a" SkinID="SkinLinkButton"></asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td style="width: 100%; text-align: left;">
                        <asp:GridView ID="gvCategos" runat="server" CellPadding="1" SkinID="SkinGridView"
                            Width="100%" EmptyDataText="Sin informaci�n de categor�as" AllowSorting="true">
                            <Columns>
                                <asp:CommandField ButtonType="Image" SelectImageUrl="~/Imagenes/Select.png" ShowSelectButton="True">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:CommandField>
                                <asp:TemplateField HeaderText="IdCategoria" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIdCategoria" runat="server" Text='<%# Bind("IdCategoria") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="ClaveCategoria" HeaderText="Clave" SortExpression="ClaveCategoria">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="DescCategoria" HeaderText="Nombre" SortExpression="DescCategoria">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle Wrap="False" HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ibDetalles" runat="server" ImageUrl="~/Imagenes/Detalles.gif"
                                            ToolTip="Ver detalles de la Categoria" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ibModificar" runat="server" ImageUrl="~/Imagenes/Modificar.png" ToolTip="Modificar datos de la Categor�a" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Wrap="False" />
                                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ibCrearCopiaCatego" runat="server" 
                                            ImageUrl="~/Imagenes/Add2.png" 
                                            ToolTip="Crear categor�a a partir de �ste registro" 
                                            onclick="ibCrearCopiaCatego_Click" />
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
