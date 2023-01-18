<%@ Control Language="VB" EnableViewState="true" AutoEventWireup="false" CodeFile="wucMuestraErrores.ascx.vb"
    Inherits="wucMuestraErrores" %>
<div>
    <table style="width: 100%">
        <tr>
            <td style="text-align: left; width: 42px;">
                <asp:Image ID="Image4" runat="server" ImageUrl="~/Imagenes/Symbol-Stop.png" 
                    Width="100px" />
            </td>
            <td style="vertical-align: middle; text-align: left; width: 100%;">
                <asp:Label ID="Label2" runat="server" SkinID="SkinLblMsjErrores" 
                    Text="Errores producidos al intentar realizar la operación solicitada:"></asp:Label>
                <br />
                <asp:GridView ID="gvErroresPagina" runat="server" AutoGenerateColumns="False" 
                    SkinID="SkinGridView" Width="100%">
                    <Columns>
                        <asp:BoundField DataField="IdError" HeaderText="No. Error">
                        <HeaderStyle Wrap="False" />
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Descripcion" HeaderText="Descripción del error">
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle Wrap="True" />
                        </asp:BoundField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
</div>
