<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Calendario.aspx.vb" Inherits="Calendario" StylesheetTheme="SkinFile" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Calendario</title>
    <script type="text/javascript" language="javascript">
    function seleccionaFecha() {
        var Fecha = document.getElementById("hfFecha").value;
        var MyArgs = new Array(Fecha);
        window.returnValue = MyArgs;
        window.close();
    }
    </script>
    <base target="_self" />
</head>
<body leftmargin="0" topmargin="0">
    <form id="form1" runat="server">
    <div style="text-align: center">
        <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </ajaxToolkit:ToolkitScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table align="center">
                    <tr>
                        <td style="width: 100px; text-align: center;">
                            <asp:LinkButton ID="lbAnioAnt" runat="server" OnClick="lbAnioAnt_Click" SkinID="SkinLinkButton"><</asp:LinkButton></td>
                        <td style="width: 100px">
                            <asp:Label ID="lblAnio" runat="server" SkinID="SkinLblMsjExito"></asp:Label></td>
                        <td style="width: 100px; text-align: center;">
                            <asp:LinkButton ID="lbAnioSig" runat="server" SkinID="SkinLinkButton" OnClick="lbAnioSig_Click">></asp:LinkButton></td>
                    </tr>
                    <tr>
                        <td colspan="3">
        <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="White" 
                                Font-Names="Verdana" Font-Size="9pt"
            ForeColor="Black" Height="190px" Width="350px" BorderWidth="1px" 
                                NextPrevFormat="FullMonth">
            <SelectedDayStyle BackColor="#333399" ForeColor="White" />
            <TodayDayStyle BackColor="#CCCCCC" />
            <OtherMonthDayStyle ForeColor="#999999" />
            <NextPrevStyle Font-Size="8pt" ForeColor="#333333" Font-Bold="True" 
                VerticalAlign="Bottom" />
            <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
            <TitleStyle BackColor="White" Font-Bold="True" Font-Size="12pt" 
                ForeColor="#333399" BorderColor="Black" BorderWidth="4px" />
        </asp:Calendar>
                        </td>
                    </tr>
                </table>
        <asp:HiddenField ID="hfFecha" runat="server" />
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:LinkButton ID="lbCerrar" runat="server" SkinID="SkinLinkButton">Cerrar</asp:LinkButton></div>
    </form>
</body>
</html>
