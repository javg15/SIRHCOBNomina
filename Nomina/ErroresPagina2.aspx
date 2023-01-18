<%@ Page Language="VB" MasterPageFile="~/MasterPageBlanca.master" AutoEventWireup="false" CodeFile="ErroresPagina2.aspx.vb" Inherits="ErroresPagina2" title="COBAEV - Nómina - Errores" StylesheetTheme="SkinFile"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 100%">
        <tr>
            <td style="vertical-align: top; text-align: left; width: 100%;">
    <table style="width: 100%">
        <tr>
            <td style="text-align: left; width: 42px;">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/Symbol-Stop.png" Width="100px" /></td>
            <td style="vertical-align: middle; text-align: left; width: 100%;">
                <asp:Label ID="Label1" runat="server" SkinID="SkinLblMsjErrores"
                    Text="Errores producidos al intentar realizar la operación:"></asp:Label><br />
                <br />
                <asp:GridView ID="gvErroresPagina" runat="server" SkinID="SkinGridView" AutoGenerateColumns="False" Width="100%">
                    <Columns>
                        <asp:BoundField DataField="IdError" HeaderText="No. Error" >
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Descripcion" HeaderText="Descripci&#243;n del error" >
                            <ItemStyle Wrap="True" />
                        </asp:BoundField>
                    </Columns>
                </asp:GridView>
                </td>
        </tr>
    </table>
            </td>
        </tr>
    </table>
</asp:Content>

