<%@ Page Language="VB" MasterPageFile="~/MasterPageSesionIniciada.master"  AutoEventWireup="false"
    CodeFile="AdmonDatosSegSoc.aspx.vb" Inherits="AdmonDatosSegSoc" Title="COBAEV - Nómina - Administrar datos de seguridad social"
    StylesheetTheme="SkinFile" %>

<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress"
    TagPrefix="TP_wucUpdateProgress" %>
<%@ Register Src="~/WebControls/wucSearchEmps.ascx" TagName="wucBuscaEmpleados" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
    <div>
        <table style="width: 100%; height: 100%">
            <tr>
                <td style="vertical-align: top; text-align: right">
                    <h2>
                        Sistema de nómina: <br />
                        Empleados (Administrar información de seguridad social)
                    </h2>
                </td>
            </tr>
            <tr>
                <td style="text-align:left;">
                <asp:UpdatePanel ID="UpdPnlMain" runat="server">
                <ContentTemplate>
                    <uc1:wucBuscaEmpleados ID="WucBuscaEmpleados1" runat="server" EnableViewState="true" />
                    <asp:MultiView ID="MultiView1" runat="server">
                        <asp:View ID="viewDatosLab" runat="server">
                            <asp:DetailsView ID="dvDatosLab" runat="server" AutoGenerateRows="False" CellPadding="1"
                                DefaultMode="Edit" EmptyDataText="Sin información de seguridad social" HeaderText="Modificando datos de seguridad social"
                                SkinID="SkinDetailsView" RowStyle-Wrap="false">
                                <Fields>
                                    <asp:TemplateField HeaderText="IdEmp" Visible="False">
                                        <HeaderStyle Wrap="False" />
                                        <EditItemTemplate>
                                            <asp:Label ID="lblIdEmp" runat="server" Text='<%# Bind("IdEmp") %>'></asp:Label>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="N&#250;mero de seguridad social">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="tbNSS" runat="server" Columns="15" MaxLength="11" SkinID="SkinTextBox"
                                                Text='<%# Bind("NSS") %>'></asp:TextBox><asp:RegularExpressionValidator ID="REVNSS"
                                                    runat="server" ControlToValidate="tbNSS" Display="None" ErrorMessage="Error en la longitud del NSS"
                                                    ValidationExpression="\d{11}"></asp:RegularExpressionValidator><ajaxToolkit:FilteredTextBoxExtender
                                                        ID="FTBENSS" runat="server" FilterType="Numbers" TargetControlID="tbNSS">
                                                    </ajaxToolkit:FilteredTextBoxExtender>
                                        </EditItemTemplate>
                                        <HeaderStyle Wrap="False" />
                                        <ItemStyle Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="R&#233;gimen pensionario">
                                        <EditItemTemplate>
                                            <asp:Label ID="lblIdRegimenISSSTE" runat="server" Text='<%# Bind("IdRegimenISSSTE") %>'
                                                Visible="False"></asp:Label><asp:DropDownList ID="ddlRegimenISSSTE" runat="server"
                                                    SkinID="SkinDropDownList">
                                                </asp:DropDownList>
                                        </EditItemTemplate>
                                        <HeaderStyle Wrap="False" />
                                        <ItemStyle Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField ShowHeader="False">
                                        <EditItemTemplate>
                                            <asp:Button ID="btnCancelar" runat="server" SkinID="SkinBoton" Text="Cancelar" />
                                            <asp:Button ID="btnGurdar" runat="server" SkinID="SkinBoton" Text="Guardar" OnClick="btnGurdar_Click" /><ajaxToolkit:ConfirmButtonExtender
                                                ID="CBEbtnGuardar" runat="server" ConfirmText="¿Está seguro de guardar los cambios realizados?"
                                                TargetControlID="btnGurdar">
                                            </ajaxToolkit:ConfirmButtonExtender>
                                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                                                ShowSummary="False" />
                                        </EditItemTemplate>
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:TemplateField>
                                </Fields>
                                <HeaderStyle Font-Names="Verdana" Font-Size="Small" HorizontalAlign="Center" />
                            </asp:DetailsView>
                        </asp:View>
                        <asp:View ID="viewExito" runat="server">
                            <table>
                                <tr>
                                    <td style="vertical-align: middle; text-align: left">
                                        <asp:Image ID="Image2" runat="server" ImageUrl="~/Imagenes/Symbol-Check.png" Width="100px" />
                                    </td>
                                    <td style="vertical-align: middle; text-align: left">
                                        <asp:Label ID="lblExito" runat="server" SkinID="SkinLblMsjExito" Text="Operación realizada exitosamente."></asp:Label>
                                        <br />
                                        <asp:LinkButton ID="lbOtraOperacion" runat="server" SkinID="SkinLinkButton">Cambiar más datos</asp:LinkButton>
                                        &nbsp;<asp:LinkButton ID="lbOtraOperacion0" runat="server" 
                                            PostBackUrl="~/Consultas/Empleados/DatosCOBAEV.aspx" SkinID="SkinLinkButton">Continuar con otra operación en el sistema</asp:LinkButton>
                                    </td>
                                </tr>
                            </table>
                        </asp:View>
                        <asp:View ID="viewError" runat="server">
                            <table>
                                <tr>
                                    <td style="vertical-align: middle; text-align: left">
                                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/Symbol-Stop.png" Width="100px" />
                                    </td>
                                    <td style="vertical-align: middle; text-align: left">
                                        <asp:Label ID="lblError" runat="server" SkinID="SkinLblMsjErrores"></asp:Label>
                                        <br />
                                        <asp:LinkButton ID="lbReintentarCaptura" runat="server" SkinID="SkinLinkButton">Reintentar operación</asp:LinkButton>
                                    </td>
                                </tr>
                            </table>
                        </asp:View>
                    </asp:MultiView>
            </ContentTemplate>
        </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
