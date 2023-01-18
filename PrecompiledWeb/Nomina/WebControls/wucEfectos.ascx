<%@ control language="VB" autoeventwireup="false" inherits="WebControls_wucEfectos, App_Web_vfc141dy" %>
<table>
    <tr>
        <td style="vertical-align: bottom">
            <asp:Label ID="Label1" runat="server" SkinID="SkinLblNormal" Text="Inicio"></asp:Label></td>
        <td style="vertical-align: bottom">
            <asp:Label ID="lblTermino" runat="server" SkinID="SkinLblNormal" Text="Término"></asp:Label></td>
    </tr>
    <tr>
        <td style="vertical-align: top">
            <asp:DropDownList ID="ddlQnaInicio" runat="server" SkinID="SkinDropDownList" AutoPostBack="True">
            </asp:DropDownList></td>
        <td style="vertical-align: top">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
            <asp:DropDownList ID="ddlQnaFin" runat="server" SkinID="SkinDropDownList">
            </asp:DropDownList><asp:HiddenField ID="hfQnaFin" runat="server" />
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="ddlQnaInicio" EventName="SelectedIndexChanged" />
                        </Triggers>
                    </asp:UpdatePanel>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="chbxEspecificarNumQuincenas" EventName="CheckedChanged" />
                </Triggers>
            </asp:UpdatePanel>
        </td>
    </tr>
    <tr>
        <td colspan="2" style="vertical-align: top">
            <asp:CheckBox ID="chbxEspecificarNumQuincenas" runat="server" AutoPostBack="True"
                SkinID="SkinCheckBox" Text="Especificar número de quincenas" /></td>
    </tr>
    <tr>
        <td colspan="2" style="vertical-align: top">
            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                <ContentTemplate>
                    <asp:TextBox ID="txtbxNumQnas" runat="server" MaxLength="3" 
                        SkinID="SkinTextBox" Enabled="False"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RFVNumQnas" runat="server" ErrorMessage="*" ControlToValidate="txtbxNumQnas" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CVNumQnas" runat="server" ControlToValidate="txtbxNumQnas"
                        Display="Dynamic" ErrorMessage="Valor debe ser mayor de cero" Operator="GreaterThanEqual" Type="Integer" ValueToCompare="1"></asp:CompareValidator><ajaxToolkit:FilteredTextBoxExtender ID="FTBENumQnas" runat="server" FilterType="Numbers"
                        TargetControlID="txtbxNumQnas">
                    </ajaxToolkit:FilteredTextBoxExtender>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="chbxEspecificarNumQuincenas" EventName="CheckedChanged" />
                </Triggers>
            </asp:UpdatePanel>
        </td>
    </tr>
    <tr>
        <td style="vertical-align: top">
        </td>
        <td style="vertical-align: top">
        </td>
    </tr>
</table>
