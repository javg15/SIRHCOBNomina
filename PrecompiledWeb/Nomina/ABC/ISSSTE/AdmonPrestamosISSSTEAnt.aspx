<%@ page language="VB" masterpagefile="~/MasterPageBlanca.master" autoeventwireup="false" inherits="AdmonPrestamosISSSTEAnt, App_Web_gwndibrm" title="COBAEV - Nómina - Administrar préstamos ISSSTE" stylesheettheme="SkinFile" maintainScrollPositionOnPostBack="true" %>

<%@ Register Src="../../WebControls/wucEfectos.ascx" TagName="wucEfectos" TagPrefix="uc1" %>
<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress" TagPrefix="TP_wucUpdateProgress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
    <table style="width: 100%; height: 100%" align="center">
        <tr>
            <td style="vertical-align: top; text-align: right">
                <h2>
                    Sistema de nómina: Administración préstamos ISSSTE
                </h2>
            </td>
        </tr>
        <tr>
            <td>
                <asp:MultiView ID="MultiView1" runat="server">
                    <asp:View ID="viewDeducciones" runat="server">
                        <table>
                            <tr>
                                <td style="vertical-align: bottom">
                                    <asp:Label ID="Label1" runat="server" SkinID="SkinLblNormal" Text="Seleccione deducción"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="vertical-align: top">
                                    <asp:DropDownList ID="ddlDeducciones" runat="server" AutoPostBack="True" SkinID="SkinDropDownList">
                                        <asp:ListItem Value="31">[431] - DESC. PRESTAMO ISSSTE</asp:ListItem>
                                        <asp:ListItem Value="136">[534] - CREDITOS ADICIONALES ISSSTE</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td style="vertical-align: bottom;">
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                            <table>
                                                <tbody>
                                                    <tr>
                                                        <td style="vertical-align: bottom; height: 25px">
                                                            <hr style="color: #004040" />
                                                            <asp:Label ID="Label2" runat="server" SkinID="SkinLblNormal" Text="Seleccione plaza"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:DropDownList ID="ddlPlazas" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPlazas_SelectedIndexChanged"
                                                                SkinID="SkinDropDownList">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="vertical-align: bottom; height: 25px">
                                                            <hr style="color: #004040" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="Label4" runat="server" SkinID="SkinLblNormal" Text="Número de préstamo ISSSTE:"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:TextBox ID="txtNumPrestamoISSSTE" runat="server" SkinID="SkinTextBox" 
                                                                MaxLength="11" Width="200px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="vertical-align: bottom; height: 25px">
                                                            <hr style="color: #004040" />
                                                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                                <ContentTemplate>
                                                                    <table>
                                                                        <tbody>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:Label ID="lblImporteDeduccion" runat="server" SkinID="SkinLblNormal" Text="Importe $"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:TextBox ID="txtbxImporteDeduccion" runat="server" SkinID="SkinTextBox"></asp:TextBox>&#160;<asp:RequiredFieldValidator
                                                                                        ID="RFVImporteDeduccion" runat="server" ControlToValidate="txtbxImporteDeduccion"
                                                                                        Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator>&#160;<asp:CompareValidator
                                                                                            ID="CVImporteDeduccion" runat="server" ControlToValidate="txtbxImporteDeduccion"
                                                                                            Display="Dynamic" ErrorMessage="Importe incorrecto" Operator="DataTypeCheck"
                                                                                            Type="Currency"></asp:CompareValidator>
                                                                                </td>
                                                                            </tr>
                                                                        </tbody>
                                                                    </table>
                                                                </ContentTemplate>
                                                                <Triggers>
                                                                    <asp:AsyncPostBackTrigger ControlID="ddlPlazas" EventName="SelectedIndexChanged">
                                                                    </asp:AsyncPostBackTrigger>
                                                                </Triggers>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="vertical-align: bottom; height: 25px">
                                                            <hr style="color: #004040" />
                                                            <uc1:wucEfectos ID="WucEfectos1" runat="server" Visible="true"></uc1:wucEfectos>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="ddlDeducciones" EventName="SelectedIndexChanged">
                                            </asp:AsyncPostBackTrigger>
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: center">
                                    <asp:Button ID="btnGuardar" runat="server" SkinID="SkinBoton" Text="Guardar" />
                                    <ajaxToolkit:ConfirmButtonExtender ID="CBEBtnGuardar" runat="server" ConfirmText="¿Información correcta?"
                                        TargetControlID="btnGuardar">
                                    </ajaxToolkit:ConfirmButtonExtender>
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                    <asp:View ID="viewExito" runat="server">
                        <table>
                            <tr>
                                <td style="vertical-align: middle; text-align: left">
                                    <asp:Image ID="Image2" runat="server" ImageUrl="~/Imagenes/Symbol-Check.png" Width="100px" />
                                </td>
                                <td style="vertical-align: middle; text-align: left">
                                    <asp:Label ID="lblExito" runat="server" SkinID="SkinLblMsjExito"></asp:Label>
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
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                </asp:MultiView>
            </td>
        </tr>
    </table>
</asp:Content>
