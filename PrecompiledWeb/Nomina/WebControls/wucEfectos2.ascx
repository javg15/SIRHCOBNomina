<%@ control language="VB" autoeventwireup="false" inherits="wucEfectos2, App_Web_vfc141dy" %>
<table>
    <tr>
        <td>
            <asp:Label ID="Label1" runat="server" Text="Inicio"></asp:Label></td>
    </tr>
    <tr>
        <td>
            <asp:DropDownList ID="ddlQnaInicio" runat="server" AutoPostBack="True">
            </asp:DropDownList></td>
    </tr>
    <tr>
        <td style="vertical-align: top">
            <asp:Label ID="lblTermino" runat="server" Text="Término"></asp:Label></td>
    </tr>
    <tr>
        <td style="vertical-align: top">
            <asp:DropDownList ID="ddlQnaFin" runat="server">
            </asp:DropDownList><asp:HiddenField ID="hfQnaFin" runat="server" />
                        </td>
    </tr>
    <tr>
        <td style="vertical-align: top">
            <asp:CheckBox ID="chbxEspecificarNumQuincenas" runat="server" 
                AutoPostBack="True" Text="Especificar número de quincenas" /></td>
    </tr>
    <tr>
        <td style="vertical-align: top">
            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                <ContentTemplate>
                    <asp:TextBox ID="txtbxNumQnas" runat="server" MaxLength="3" Enabled="False"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RFVNumQnas" runat="server" 
                        ErrorMessage="Especificar el número de quincenas es obligatorio." 
                        ControlToValidate="txtbxNumQnas" Display="Dynamic" 
                        ToolTip="Especificar el número de quincenas es obligatorio." 
                        Enabled="False">*</asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CVNumQnas" runat="server" ControlToValidate="txtbxNumQnas"
                        Display="Dynamic" ErrorMessage="Valor debe ser mayor de cero." 
                        Operator="GreaterThanEqual" Type="Integer" ValueToCompare="1" 
                        ToolTip="Valor debe ser mayor de cero." Enabled="False">*</asp:CompareValidator>
                        <ajaxToolkit:FilteredTextBoxExtender ID="FTBENumQnas" runat="server" FilterType="Numbers"
                        TargetControlID="txtbxNumQnas">
                    </ajaxToolkit:FilteredTextBoxExtender>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="chbxEspecificarNumQuincenas" EventName="CheckedChanged" />
                </Triggers>
            </asp:UpdatePanel>
        </td>
    </tr>
    </table>
