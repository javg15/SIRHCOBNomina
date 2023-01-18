<%@ page language="VB" masterpagefile="~/MasterPageSesionIniciada.master" autoeventwireup="false" inherits="AdmonDatosPagomatico, App_Web_afkwdrmm" title="COBAEV - N�mina - Administrar datos de pagom�tico" stylesheettheme="SkinFile" maintainScrollPositionOnPostBack="true" %>

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
                        Sistema de n�mina: <br />
                        Empleados (Administrar informaci�n de pagom�tico)
                    </h2>
                </td>
            </tr>
            <tr>
                <td>
                <asp:UpdatePanel ID="UpdPnlMain" runat="server">
                <ContentTemplate>
                    <uc1:wucBuscaEmpleados ID="WucBuscaEmpleados1" runat="server" EnableViewState="true" />
                    <asp:MultiView ID="MultiView1" runat="server">
                        <asp:View ID="viewEdit" runat="server">
                            <asp:DetailsView ID="dvDatosLab" runat="server" AutoGenerateRows="False" CellPadding="1"
                                DefaultMode="Edit" EmptyDataText="Sin informaci�n de pagom�tico" HeaderText="Modificando datos de pagom�tico"
                                SkinID="SkinDetailsView" RowStyle-Wrap="false">
                                <Fields>
                                    <asp:TemplateField HeaderText="IdEmp" Visible="False">
                                        <HeaderStyle Wrap="False" />
                                        <EditItemTemplate>
                                            <asp:Label ID="lblIdEmp" runat="server" Text='<%# Bind("IdEmp") %>'></asp:Label>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Banco para pagom&#225;tico">
                                        <EditItemTemplate>
                                            <asp:Label ID="lblIdBanco" runat="server" Text='<%# Bind("IdBanco") %>' Visible="False"></asp:Label><asp:DropDownList
                                                ID="ddlBancos" runat="server" SkinID="SkinDropDownList">
                                            </asp:DropDownList>
                                        </EditItemTemplate>
                                        <HeaderStyle Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Cuenta bancaria">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="tbCuentaBancaria" runat="server" Columns="25" MaxLength="16" SkinID="SkinTextBox"
                                                Text='<%# Bind("CuentaBancaria") %>'></asp:TextBox><ajaxToolkit:FilteredTextBoxExtender
                                                    ID="FTBECuentaBancaria" runat="server" FilterType="Numbers" TargetControlID="tbCuentaBancaria">
                                                </ajaxToolkit:FilteredTextBoxExtender>
                                        </EditItemTemplate>
                                        <HeaderStyle Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Incluir en pagom&#225;tico">
                                        <EditItemTemplate>
                                            <asp:CheckBox ID="chbIncluirEnPagomatico" runat="server" Checked='<%# Bind("IncluirEnPagomatico") %>'
                                                SkinID="SkinCheckBox" />
                                        </EditItemTemplate>
                                        <HeaderStyle Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField ShowHeader="False">
                                        <EditItemTemplate>
                                            <asp:Button ID="btnCancelar" runat="server" SkinID="SkinBoton" Text="Cancelar" />
                                            <asp:Button ID="btnGurdar" runat="server" SkinID="SkinBoton" Text="Guardar" OnClick="btnGurdar_Click" /><ajaxToolkit:ConfirmButtonExtender
                                                ID="CBEbtnGuardar" runat="server" ConfirmText="�Est� seguro de guardar los cambios realizados?"
                                                TargetControlID="btnGurdar">
                                            </ajaxToolkit:ConfirmButtonExtender>
                                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                                                ShowSummary="False" />
                                        </EditItemTemplate>
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:TemplateField>
                                </Fields>
                                <HeaderStyle Font-Names="Verdana" Font-Size="Small" HorizontalAlign="Center" />
                                <RowStyle Wrap="False" />
                            </asp:DetailsView>
                        </asp:View>
                        <asp:View ID="viewExito" runat="server">
                            <table>
                                <tr>
                                    <td style="vertical-align: middle; text-align: left">
                                        <asp:Image ID="Image2" runat="server" ImageUrl="~/Imagenes/Symbol-Check.png" Width="100px" />
                                    </td>
                                    <td style="vertical-align: middle; text-align: left">
                                        <asp:Label ID="lblExito" runat="server" SkinID="SkinLblMsjExito" Text="Operaci�n realizada exitosamente."></asp:Label>
                                        <br />
                                        <asp:LinkButton ID="lbOtraOperacion" runat="server" SkinID="SkinLinkButton">Cambiar m�s datos</asp:LinkButton>
                                        &nbsp;<asp:LinkButton ID="lbOtraOperacion0" runat="server" 
                                            PostBackUrl="~/Consultas/Empleados/DatosCOBAEV.aspx" SkinID="SkinLinkButton">Continuar con otra operaci�n en el sistema</asp:LinkButton>
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
                                        <asp:LinkButton ID="lbReintentarCaptura" runat="server" SkinID="SkinLinkButton">Reintentar operaci�n</asp:LinkButton>
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
