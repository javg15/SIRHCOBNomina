<%@ Page Language="VB" EnableEventValidation="false" MasterPageFile="~/MasterPageSesionIniciada.master"
    AutoEventWireup="false" CodeFile="EmpleadosHistoriaClaves.aspx.vb" Inherits="EmpleadosHistoriaClaves"
    Title="COBAEV - Nómina - Historia claves por empleado" StylesheetTheme="SkinFile" %>

<%@ Register Src="~/WebControls/wucSearchEmps.ascx" TagName="wucBuscaEmpleados" TagPrefix="uc1" %>
<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress"
    TagPrefix="TP_wucUpdateProgress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
    <table style="width: 100%; vertical-align: top; text-align: center;">
        <tr>
            <td style="vertical-align: top; text-align: right">
                <h2>
                    Sistema de nómina: Empleados (Historia claves)
                </h2>
            </td>
        </tr>
        <tr>
            <td style="text-align: left; vertical-align: top;">
                <table style="width: 100%">
                    <tr>
                        <td>
                            <uc1:wucBuscaEmpleados ID="WucBuscaEmpleados1" runat="server" EnableViewState="true">
                            </uc1:wucBuscaEmpleados>
                        </td>
                        <td style="vertical-align: top; text-align: right">
                            <asp:ImageButton ID="ibActualizar" runat="server" ImageUrl="~/Imagenes/Refresh.jpg"
                                ToolTip="Actualizar información" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="text-align: left">
                <asp:Panel ID="pnlTipoClave" runat="server" Font-Names="Verdana" Font-Size="X-Small"
                    GroupingText="Seleccione tipo de clave">
                    <br />
                    <asp:DropDownList ID="ddlTipoClave" runat="server" AutoPostBack="True" SkinID="SkinDropDownList">
                        <asp:ListItem Value="D">Deducci&#243;n</asp:ListItem>
                        <asp:ListItem Value="P">Percepci&#243;n</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    <br />
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td style="text-align: left">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="pnlClaves" runat="server" Font-Names="Verdana" Font-Size="X-Small"
                            GroupingText="Seleccione deducción">
                            <br />
                            <asp:DropDownList ID="ddlClaves" runat="server" SkinID="SkinDropDownList">
                            </asp:DropDownList>
                            <br />
                            <br />
                        </asp:Panel>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlTipoClave" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="ibActualizar" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td style="text-align: left">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:Button ID="btnConsultar" runat="server" SkinID="SkinBoton" Text="Consultar" />
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ibActualizar" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td style="text-align: left">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Label ID="lblMsj1" runat="server" Font-Strikeout="False" Font-Underline="True"
                            SkinID="SkinLblDatos"></asp:Label><br />
                        <asp:Label ID="lblEmpInf" runat="server" Font-Strikeout="False" Font-Underline="True"
                            SkinID="SkinLblDatos"></asp:Label><br />
                        <br />
                        <asp:GridView ID="gvHistoriaClave" runat="server" AutoGenerateColumns="False" SkinID="SkinGridView">
                            <Columns>
                                <asp:BoundField DataField="QuincenaAplicacion" HeaderText="Quincena">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Importe" DataFormatString="{0:c}" HeaderText="Importe">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="IdPlaza" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIdPlaza" runat="server" Text='<%# Bind("IdPlaza") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Plaza" HeaderText="Plaza" />
                            </Columns>
                        </asp:GridView>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnConsultar" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="ibActualizar" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>
