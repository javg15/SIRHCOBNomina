<%@ Page Language="VB" MasterPageFile="~/MasterPageBlanca.master" AutoEventWireup="false"
    CodeFile="AdmonPercCapturadasAnt.aspx.vb" Inherits="AdmonPercCapturadasAnt" Title="COBAEV - Nómina - Administrar percepciones capturadas"
    StylesheetTheme="SkinFile" %>

<%@ Register Src="../../WebControls/wucEfectos.ascx" TagName="wucEfectos" TagPrefix="uc1" %>
<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress" TagPrefix="TP_wucUpdateProgress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <tp_wucupdateprogress:wucupdateprogress ID="wucUpdateProgress1" runat="server" 
        EnableViewState="true" />    
    <table style="width: 100%; height: 100%">
        <tr>
            <td style="vertical-align: top; text-align: right">
                <h2>
                    Administrar percepciones capturadas
                </h2>
            </td>
        </tr>
        <tr>
            <td>
                <asp:MultiView ID="MultiView1" runat="server">
                    <asp:View ID="viewPercepciones" runat="server">
                        <table>
                            <tr>
                                <td style="vertical-align: bottom">
                                    <asp:Label ID="Label1" runat="server" SkinID="SkinLblNormal" Text="Seleccione percepción"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="vertical-align: top">
                                    <asp:DropDownList ID="ddlPercepciones" runat="server" AutoPostBack="True" SkinID="SkinDropDownList">
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
                                                            <asp:Label ID="Label2" runat="server" Text="Seleccione plaza" SkinID="SkinLblNormal"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:DropDownList ID="ddlPlazas" runat="server" SkinID="SkinDropDownList" AutoPostBack="True"
                                                                OnSelectedIndexChanged="ddlPlazas_SelectedIndexChanged">
                                                            </asp:DropDownList>
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
                                                                                <td style="width: 139px">
                                                                                    <asp:Label ID="lblImportePercepcion" runat="server" Text="Importe $" SkinID="SkinLblNormal"></asp:Label>
                                                                                </td>
                                                                                <td style="width: 139px">
                                                                                    <asp:Label ID="lblDiasAPagar" runat="server" SkinID="SkinLblNormal" Text="Días a pagar"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 139px; vertical-align: top;">
                                                                                    <asp:TextBox ID="txtbxImportePercepcion" runat="server" SkinID="SkinTextBox"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator
                                                                                        ID="RFVImportePercepcion" runat="server" Display="Dynamic" ErrorMessage="*" ControlToValidate="txtbxImportePercepcion"></asp:RequiredFieldValidator>&nbsp;<asp:CompareValidator
                                                                                            ID="CVImportePercepcion" runat="server" Display="Dynamic" ErrorMessage="Importe incorrecto"
                                                                                            ControlToValidate="txtbxImportePercepcion" Type="Currency" Operator="DataTypeCheck"></asp:CompareValidator>
                                                                                </td>
                                                                                <td style="vertical-align: top; width: 139px">
                                                                                    <asp:TextBox ID="tbDiasAPagar" runat="server" MaxLength="2" SkinID="SkinTextBox"></asp:TextBox>
                                                                                    <asp:RequiredFieldValidator ID="rfvNumDias" runat="server" ControlToValidate="tbDiasAPagar"
                                                                                        Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                                                                        FilterType="Numbers" TargetControlID="tbDiasAPagar">
                                                                                    </ajaxToolkit:FilteredTextBoxExtender>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 139px">
                                                                                </td>
                                                                                <td style="width: 139px">
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
                                            <asp:AsyncPostBackTrigger ControlID="ddlPercepciones" EventName="SelectedIndexChanged">
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
