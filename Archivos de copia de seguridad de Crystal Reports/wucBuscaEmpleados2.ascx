<%@ Control Language="VB" EnableViewState="true" AutoEventWireup="false" CodeFile="wucBuscaEmpleados2.ascx.vb" Inherits="WebControls_wucBuscaEmpleados2" %>
<table style="width: 70%;">
    <tr>
        <td style="vertical-align: top; width: 70%; height: 100%; text-align: left">
            <table style="width: 100%">
                <tr>
                    <td style="vertical-align: top; text-align: left">
        <ajaxToolkit:CollapsiblePanelExtender ID="CPEBusqueda" runat="Server" CollapseControlID="TitlePanelBusqueda"
            Collapsed="False" CollapsedImage="~/Imagenes/expand_blue.jpg" CollapsedText="(Mostrar detalles...)"
            ExpandControlID="TitlePanelBusqueda" ExpandedImage="~/Imagenes/collapse_blue.jpg"
            ExpandedText="(Ocultar detalles...)" ImageControlID="Image1" SuppressPostBack="true"
            TargetControlID="ContentPanelBusqueda" TextLabelID="Label1">
        </ajaxToolkit:CollapsiblePanelExtender>
                        <table cellpadding="0" cellspacing="0" style="width: 100%">
                            <tr>
                                <td colspan="2" style="vertical-align: top; text-align: left">
                        <asp:Panel ID="TitlePanelBusqueda" runat="server" BorderColor="White" BorderStyle="Solid"
                            BorderWidth="1px" CssClass="collapsePanelHeader" Width="100%">
                            <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/expand_blue.jpg" />
                            Búsqueda de empleados
                            <asp:Label ID="Label1" runat="server">(Mostrar detalles...)</asp:Label>
                        </asp:Panel>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" style="vertical-align: top; text-align: left">
                                    <asp:Panel ID="ContentPanelBusqueda" runat="server" CssClass="collapsePanel" Width="100%">
<table>
    <tr>
        <td>
            <asp:Label ID="Label2" runat="server" Text="RFC" SkinID="SkinLblNormal"></asp:Label></td>
        <td style="width: 3px">
            <asp:TextBox ID="txtbxRFC" runat="server" MaxLength="13" ReadOnly="True" SkinID="SkinTextBox"
                Width="100px"></asp:TextBox>
            <asp:HiddenField ID="hfRFC" runat="server" />
        </td>
        <td style="width: 3px">
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label3" runat="server" Text="Nombre" SkinID="SkinLblNormal"></asp:Label></td>
        <td style="width: 3px">
            <asp:TextBox ID="txtbxNomEmp" runat="server" MaxLength="100" ReadOnly="True" SkinID="SkinTextBox"
                Width="300px"></asp:TextBox>
            <asp:HiddenField ID="hfNomEmp" runat="server" />
        </td>
        <td style="width: 3px">
            <asp:ImageButton ID="ibBuscarEmp" runat="server" CausesValidation="False" ImageUrl="~/Imagenes/Buscar.jpg"
                ToolTip="Buscar empleado" /></td>
    </tr>
    <tr>
        <td colspan="3">
            <asp:Button ID="btnLimpiarValores" runat="server" SkinID="SkinBoton" Text="Eliminar valores" /><ajaxToolkit:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" ConfirmText="¿Realmente desea eliminar los valores actuales?"
                TargetControlID="btnLimpiarValores">
            </ajaxToolkit:ConfirmButtonExtender>
            &nbsp;
        </td>
    </tr>
</table>
                                    </asp:Panel>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
