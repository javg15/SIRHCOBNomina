<%@ Page Language="VB" MasterPageFile="~/MasterPageBlanca.master" AutoEventWireup="false" CodeFile="CompeAcumuladaPorAnio.aspx.vb" Inherits="ABC_Compensaciones_CompeAcumuladaPorAnio" title="COBAEV - Nómina - Compensaciones acumuladas anualmente por empleado" Theme="SkinFile" StylesheetTheme="SkinFile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 100%; height: 100%" align="center" >
        <tr>
            <td style="text-align: center">
                <table>
                    <tr>
                        <td style="vertical-align: top; text-align: left">
                            <asp:Label ID="lblAño" runat="server" SkinID="SkinLblMsjExito"></asp:Label></td>
                        <td style="vertical-align: top; text-align: left">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="text-align: center; vertical-align: top;">
                            <asp:GridView ID="gvHistoriaCompe" runat="server" AutoGenerateColumns="False" EmptyDataText="No existen compensaciones para el año indicado."
                                SkinID="SkinGridView" ShowFooter="True">
                                <Columns>
                                    <asp:BoundField DataField="TipoCompensacion" HeaderText="Compensaci&#243;n">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="NombreMes" HeaderText="Mes">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Tipo de pago">
                                        <FooterTemplate>
                                            Total<br />
                                        </FooterTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("Comentarios") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterStyle HorizontalAlign="Center" />
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="FormaDePago" HeaderText="Forma de pago">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Banco" HeaderText="Banco">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="CuentaBancaria" HeaderText="Cuenta bancaria">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Importe">
                                        <FooterTemplate>
                                            <asp:Label ID="lblImporteTotal" runat="server" Text='<%# Bind("Importe", "{0:c}") %>'></asp:Label>
                                        </FooterTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblImporte" runat="server" Text='<%# Bind("Importe", "{0:c}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                        <ItemStyle HorizontalAlign="Right" Wrap="False" />
                                        <FooterStyle Wrap="False" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                        <td style="text-align: center; vertical-align: bottom;">
                                        <asp:ImageButton ID="ibImprimirEnPDF" runat="server" ImageUrl="~/Imagenes/PDFExport.jpg"
                                            ToolTip="Mostrar reporteen PDF" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="text-align: center">
    <asp:LinkButton ID="lbCerrar" runat="server" SkinID="SkinLinkButton">Cerrar ventana</asp:LinkButton></td>
        </tr>
    </table>
</asp:Content>

