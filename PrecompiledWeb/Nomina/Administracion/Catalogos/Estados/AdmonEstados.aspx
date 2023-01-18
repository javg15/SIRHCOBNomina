<%@ page language="VB" masterpagefile="~/MasterPageSesionIniciada.master" autoeventwireup="false" inherits="Administracion_Catalogos_Estados_AdmonEstados, App_Web_helwzuzr" stylesheettheme="SkinFile" maintainScrollPositionOnPostBack="true" %>
<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress" TagPrefix="TP_wucUpdateProgress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
        ShowSummary="False" />
    <table style="width: 100%;" align="center">
        <tr>
            <td style="vertical-align: top; text-align: right">
                <h2>
                    Sistema de nómina: Municipios, localidades, colonias y códigos postales por estado
                    (Administración)
                </h2>
            </td>
        </tr>
        <tr>
            <td style="text-align: left; vertical-align: bottom; height: 30px;">
                <asp:Label ID="Label1" runat="server" Text="Estados" SkinID="SkinLblNormal"></asp:Label>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td style="text-align: left;">
                <table>
                    <tr>
                        <td style="vertical-align: top; text-align: left">
                            <asp:UpdatePanel ID="UpdPnlEdos" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlEdos" runat="server" SkinID="SkinDropDownList" AutoPostBack="True">
                                    </asp:DropDownList>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="imgAddMun" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="imgModifMun" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="imgCancelMun" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="imgAddLoc" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="imgModifLoc" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="imgCancelLoc" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="imgAddCol" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="imgCancelCol" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="imgModifCol" EventName="Click" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                        <td style="vertical-align: top; text-align: left">
                            &nbsp;</td>
                    </tr>
                </table>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: bottom; height: 30px; text-align: left;">
                <asp:Label ID="Label2" runat="server" SkinID="SkinLblNormal" Text="Municipios del estado seleccionado"></asp:Label>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td style="text-align: left;">
                <table>
                    <tr>
                        <td style="vertical-align: top; text-align: left">
                            <asp:UpdatePanel ID="UpdPnlMuns" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlMuns" runat="server" SkinID="SkinDropDownList" AutoPostBack="True"
                                        OnSelectedIndexChanged="ddlMuns_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddlEdos" EventName="SelectedIndexChanged" />
                                    <asp:AsyncPostBackTrigger ControlID="imgModifMun" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="imgAddMun" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="imgCancelMun" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="imgAddLoc" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="imgModifLoc" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="imgCancelLoc" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="imgAddCol" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="imgCancelCol" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="imgModifCol" EventName="Click" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                        <td style="vertical-align: top; text-align: left">
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top; text-align: left">
                            <asp:UpdatePanel ID="UpdPnlOpcsMun" runat="server">
                                <ContentTemplate>
                                    <asp:ImageButton ID="imgModifMun" runat="server" ImageUrl="~/Imagenes/Modificar.png"
                                        OnClick="imgModifMun_Click" ToolTip="Modificar el nombre del municipio seleccionado" /><asp:ImageButton
                                            ID="imgAddMun" runat="server" ImageUrl="~/Imagenes/Add2.png" ToolTip="Agregar un municipio al estado seleccionado"
                                            OnClick="imgAddMun_Click" /><asp:UpdatePanel ID="UpdPnltxtbxMun" runat="server">
                                                <ContentTemplate>
                                                    <table>
                                                        <tr>
                                                            <td style="vertical-align: top; text-align: left">
                                                                <asp:Label ID="lblModAddMun" runat="server" SkinID="SkinLblNormal" Visible="False"></asp:Label>
                                                            </td>
                                                            <td style="vertical-align: top; text-align: left">
                                                            </td>
                                                            <td style="vertical-align: top; text-align: left">
                                                            </td>
                                                            <td style="vertical-align: top; text-align: left">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="vertical-align: top; text-align: left">
                                                                <asp:TextBox ID="txtbxMun" runat="server" SkinID="SkinTextBox" Visible="False" Width="400px"></asp:TextBox>
                                                            </td>
                                                            <td style="vertical-align: top; text-align: center">
                                                                <asp:ImageButton ID="imgGuardarMunModif" runat="server" ImageUrl="~/Imagenes/CDROM.png"
                                                                    ToolTip="Guardar nombre del municipio modificado" Visible="False" OnClick="imgGuardarMunModif_Click" />
                                                            </td>
                                                            <td style="vertical-align: top; text-align: center">
                                                                <asp:ImageButton ID="imgGuardarNuevoMun" runat="server" ImageUrl="~/Imagenes/CDROM.png"
                                                                    ToolTip="Guardar nuevo municipio" Visible="False" OnClick="imgGuardarNuevoMun_Click" />
                                                            </td>
                                                            <td style="vertical-align: top; text-align: center">
                                                                <asp:ImageButton ID="imgCancelMun" runat="server" ImageUrl="~/Imagenes/Eliminar.png"
                                                                    OnClick="imgCancelMun_Click" ToolTip="Cancelar" Visible="False" CausesValidation="False" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="vertical-align: top; text-align: left">
                                                                <ajaxToolkit:ConfirmButtonExtender ID="CBEGuardarMunModif" runat="server" ConfirmText="¿Está seguro de guardar la modificación realizada?"
                                                                    TargetControlID="imgGuardarMunModif">
                                                                </ajaxToolkit:ConfirmButtonExtender>
                                                                <ajaxToolkit:ConfirmButtonExtender ID="CBEGuardarNuevoMun" runat="server" ConfirmText="¿Está seguro de guardar el nuevo municipio?"
                                                                    TargetControlID="imgGuardarNuevoMun" Enabled="True">
                                                                </ajaxToolkit:ConfirmButtonExtender>
                                                                <asp:RequiredFieldValidator ID="RFVtxtbxMun" runat="server" ControlToValidate="txtbxMun"
                                                                    Display="None" ErrorMessage="Se requiere el nombre del municipio." SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                            </td>
                                                            <td style="vertical-align: top; text-align: center">
                                                            </td>
                                                            <td style="vertical-align: top; text-align: center">
                                                            </td>
                                                            <td style="vertical-align: top; text-align: center">
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="imgModifMun" EventName="Click" />
                                                    <asp:AsyncPostBackTrigger ControlID="imgCancelMun" EventName="Click" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="imgCancelMun" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="imgCancelLoc" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="imgCancelCol" EventName="Click" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                        <td style="vertical-align: top; text-align: left">
                        </td>
                    </tr>
                </table>
            </td>
            <td style="vertical-align: top; text-align: left;">
            </td>
        </tr>
        <tr>
            <td style="vertical-align: bottom; height: 30px; text-align: left">
                <asp:Label ID="Label3" runat="server" SkinID="SkinLblNormal" Text="Localidades del municipio seleccionado"></asp:Label>
            </td>
            <td style="text-align: left;">
            </td>
        </tr>
        <tr>
            <td style="text-align: left">
                <table>
                    <tr>
                        <td style="vertical-align: top; text-align: left">
                            <asp:UpdatePanel ID="UpdPnlLocs" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlLocs" runat="server" SkinID="SkinDropDownList" AutoPostBack="True"
                                        OnSelectedIndexChanged="ddlLocs_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddlMuns" EventName="SelectedIndexChanged" />
                                    <asp:AsyncPostBackTrigger ControlID="imgAddMun" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="imgModifMun" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="imgCancelMun" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="imgAddLoc" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="imgModifLoc" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="imgCancelLoc" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="imgAddCol" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="imgCancelCol" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="imgModifCol" EventName="Click" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                        <td style="vertical-align: top; text-align: left">
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top; text-align: left">
                            <asp:UpdatePanel ID="UpdPnlOpcsLocs" runat="server">
                                <ContentTemplate>
                                    <asp:ImageButton ID="imgModifLoc" runat="server" ImageUrl="~/Imagenes/Modificar.png"
                                        OnClick="imgModifLoc_Click" ToolTip="Modificar el nombre de la localidad seleccionada" />
                                    <asp:ImageButton ID="imgAddLoc" runat="server" ImageUrl="~/Imagenes/Add2.png" ToolTip="Agregar una localidad al municipio seleccionado"
                                        OnClick="imgAddLoc_Click" /><asp:UpdatePanel ID="UpdPnltxtbxLoc" runat="server">
                                            <ContentTemplate>
                                                <table>
                                                    <tr>
                                                        <td style="vertical-align: top; text-align: left">
                                                            <asp:Label ID="lblModAddLoc" runat="server" SkinID="SkinLblNormal" Visible="False"></asp:Label>
                                                        </td>
                                                        <td style="vertical-align: top; text-align: left">
                                                        </td>
                                                        <td style="vertical-align: top; text-align: left">
                                                        </td>
                                                        <td style="vertical-align: top; text-align: left">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="vertical-align: top; text-align: left">
                                                            <asp:TextBox ID="txtbxLoc" runat="server" SkinID="SkinTextBox" Visible="False" Width="400px"
                                                                MaxLength="85"></asp:TextBox>
                                                        </td>
                                                        <td style="vertical-align: top; text-align: center">
                                                            <asp:ImageButton ID="imgGuardarLocModif" runat="server" ImageUrl="~/Imagenes/CDROM.png"
                                                                OnClick="imgGuardarLocModif_Click" ToolTip="Guardar nombre de la localidad modificada"
                                                                Visible="False" />
                                                        </td>
                                                        <td style="vertical-align: top; text-align: center">
                                                            <asp:ImageButton ID="imgGuardarNuevaLoc" runat="server" ImageUrl="~/Imagenes/CDROM.png"
                                                                OnClick="imgGuardarNuevaLoc_Click" ToolTip="Guardar nueva localidad" Visible="False" />
                                                        </td>
                                                        <td style="vertical-align: top; text-align: center">
                                                            <asp:ImageButton ID="imgCancelLoc" runat="server" ImageUrl="~/Imagenes/Eliminar.png"
                                                                OnClick="imgCancelLoc_Click" ToolTip="Cancelar" Visible="False" CausesValidation="False" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="vertical-align: top; text-align: left">
                                                            <ajaxToolkit:ConfirmButtonExtender ID="CBEGuardarLocModif" runat="server" ConfirmText="¿Está seguro de guardar la modificación realizada?"
                                                                TargetControlID="imgGuardarLocModif">
                                                            </ajaxToolkit:ConfirmButtonExtender>
                                                            <ajaxToolkit:ConfirmButtonExtender ID="CBEGuardarNuevaLoc" runat="server" ConfirmText="¿Está seguro de guardar la nueva localidad?"
                                                                TargetControlID="imgGuardarNuevaLoc">
                                                            </ajaxToolkit:ConfirmButtonExtender>
                                                            <asp:RequiredFieldValidator ID="RFVtxtbxLoc" runat="server" ControlToValidate="txtbxLoc"
                                                                Display="None" ErrorMessage="Se requiere el nombre de la localidad." SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                        </td>
                                                        <td style="vertical-align: top; text-align: center">
                                                        </td>
                                                        <td style="vertical-align: top; text-align: center">
                                                        </td>
                                                        <td style="vertical-align: top; text-align: center">
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="imgModifLoc" EventName="Click" />
                                                <asp:AsyncPostBackTrigger ControlID="imgCancelLoc" EventName="Click" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="imgCancelLoc" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="imgCancelMun" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="imgCancelCol" EventName="Click" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                        <td style="vertical-align: top; text-align: left">
                        </td>
                    </tr>
                </table>
            </td>
            <td style="text-align: left;">
            </td>
        </tr>
        <tr>
            <td style="vertical-align: bottom; height: 30px; text-align: left">
                <asp:Label ID="Label4" runat="server" SkinID="SkinLblNormal" Text="Colonias de la localidad seleccionada"></asp:Label>
            </td>
            <td style="vertical-align: bottom; text-align: left">
            </td>
        </tr>
        <tr>
            <td style="text-align: left">
                <table>
                    <tr>
                        <td style="vertical-align: top; text-align: left">
                            <asp:UpdatePanel ID="UpdPnlCols" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlCols" runat="server" SkinID="SkinDropDownList" AutoPostBack="True"
                                        OnSelectedIndexChanged="ddlCols_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddlLocs" EventName="SelectedIndexChanged" />
                                    <asp:AsyncPostBackTrigger ControlID="imgAddMun" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="imgModifMun" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="imgCancelMun" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="imgAddLoc" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="imgCancelLoc" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="imgModifLoc" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="imgAddCol" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="imgCancelCol" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="imgModifCol" EventName="Click" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                        <td style="vertical-align: top; text-align: left">
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top; text-align: left">
                            <asp:UpdatePanel ID="UpdPnlOpcsCols" runat="server">
                                <ContentTemplate>
                                    <asp:ImageButton ID="imgModifCol" runat="server" ImageUrl="~/Imagenes/Modificar.png"
                                        OnClick="imgModifCol_Click" ToolTip="Modificar el nombre de la colonia seleccionada" />
                                    <asp:ImageButton ID="imgAddCol" runat="server" ImageUrl="~/Imagenes/Add2.png" ToolTip="Agregar una colonia a la localidad seleccionada"
                                        OnClick="imgAddCol_Click" /><asp:UpdatePanel ID="UpdPnltxtbxCol" runat="server">
                                            <ContentTemplate>
                                                <table>
                                                    <tr>
                                                        <td style="vertical-align: top; text-align: left">
                                                            <asp:Label ID="lblModAddCol" runat="server" SkinID="SkinLblNormal" Visible="False"></asp:Label>
                                                        </td>
                                                        <td style="vertical-align: top; text-align: left">
                                                        </td>
                                                        <td style="vertical-align: top; text-align: left">
                                                        </td>
                                                        <td style="vertical-align: top; text-align: left">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="vertical-align: top; text-align: left">
                                                            <asp:TextBox ID="txtbxCol" runat="server" SkinID="SkinTextBox" Visible="False" Width="400px"
                                                                MaxLength="60"></asp:TextBox>
                                                        </td>
                                                        <td style="vertical-align: top; text-align: center">
                                                            <asp:ImageButton ID="imgGuardarColModif" runat="server" ImageUrl="~/Imagenes/CDROM.png"
                                                                OnClick="imgGuardarColModif_Click" ToolTip="Guardar nombre de la colonia modificada"
                                                                Visible="False" />
                                                        </td>
                                                        <td style="vertical-align: top; text-align: center">
                                                            <asp:ImageButton ID="imgGuardarNuevaCol" runat="server" ImageUrl="~/Imagenes/CDROM.png"
                                                                OnClick="imgGuardarNuevaCol_Click" ToolTip="Guardar nueva colonia" Visible="False" />
                                                        </td>
                                                        <td style="vertical-align: top; text-align: center">
                                                            <asp:ImageButton ID="imgCancelCol" runat="server" ImageUrl="~/Imagenes/Eliminar.png"
                                                                OnClick="imgCancelCol_Click" ToolTip="Cancelar" Visible="False" CausesValidation="False" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="vertical-align: top; text-align: left">
                                                            <ajaxToolkit:ConfirmButtonExtender ID="CBEGuardarColModif" runat="server" ConfirmText="¿Está seguro de guardar la modificación realizada?"
                                                                TargetControlID="imgGuardarColModif">
                                                            </ajaxToolkit:ConfirmButtonExtender>
                                                            <ajaxToolkit:ConfirmButtonExtender ID="CBEGuardarNuevaCol" runat="server" ConfirmText="¿Está seguro de guardar la nueva colonia?"
                                                                TargetControlID="imgGuardarNuevaCol">
                                                            </ajaxToolkit:ConfirmButtonExtender>
                                                            <asp:RequiredFieldValidator ID="RFVtxtbxCol" runat="server" ControlToValidate="txtbxCol"
                                                                Display="None" ErrorMessage="Se requiere el nombre de la colonia." SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                        </td>
                                                        <td style="vertical-align: top; text-align: center">
                                                        </td>
                                                        <td style="vertical-align: top; text-align: center">
                                                        </td>
                                                        <td style="vertical-align: top; text-align: center">
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="imgModifCol" EventName="Click" />
                                                <asp:AsyncPostBackTrigger ControlID="imgCancelCol" EventName="Click" />
                                                <asp:AsyncPostBackTrigger ControlID="imgCancelCol" EventName="Click" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="imgCancelLoc" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="imgCancelMun" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="imgCancelCol" EventName="Click" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                        <td style="vertical-align: top; text-align: left">
                        </td>
                    </tr>
                </table>
            </td>
            <td style="text-align: left;">
            </td>
        </tr>
        <tr>
            <td style="text-align: left">
                <asp:Label ID="Label5" runat="server" SkinID="SkinLblNormal" Text="Código postal asociado a la colonia seleccionada"></asp:Label>
            </td>
            <td style="text-align: left;">
            </td>
        </tr>
        <tr>
            <td style="text-align: left">
                <asp:UpdatePanel ID="UpdPnlCP" runat="server">
                    <ContentTemplate>
                        <table>
                            <tr>
                                <td style="vertical-align: top; text-align: left">
                                    <asp:TextBox ID="txtbxCP" runat="server" SkinID="SkinTextBox" MaxLength="5" Enabled="False"></asp:TextBox><asp:RegularExpressionValidator
                                        ID="REVtxtbxCP" runat="server" ControlToValidate="txtbxCP" Display="None" ErrorMessage="El código postal debe ser de 5 dígitos."
                                        ValidationExpression="\d{5}" SetFocusOnError="True"></asp:RegularExpressionValidator>
                                </td>
                                <td style="vertical-align: top; text-align: left">
                                    <asp:Label ID="lblCP" runat="server" SkinID="SkinLblMsjExito" Text="Asociado a la localidad"
                                        Visible="False"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:ImageButton ID="imgModifCP" runat="server" ImageUrl="~/Imagenes/Modificar.png"
                                        OnClick="imgModifCP_Click" ToolTip="Modificar código postal de la colonia o localidad"
                                        CausesValidation="False" />
                                    <asp:ImageButton ID="imgGuardarCPModif" runat="server" ImageUrl="~/Imagenes/CDROM.png"
                                        OnClick="imgGuardarCPModif_Click" ToolTip="Guardar código postal modificado de la colonia o localidad"
                                        Visible="False" />
                                    <asp:ImageButton ID="imgCancelCP" runat="server" ImageUrl="~/Imagenes/Eliminar.png"
                                        OnClick="imgCancelCP_Click" ToolTip="Cancelar" Visible="False" CausesValidation="False" />
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <ajaxToolkit:ConfirmButtonExtender ID="CBEGuardarCPModif" runat="server" ConfirmText="¿Está seguro de guardar la modificación realizada?"
                                        TargetControlID="imgGuardarCPModif">
                                    </ajaxToolkit:ConfirmButtonExtender>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FTBEtxtbxCP" runat="server" FilterType="Numbers"
                                        TargetControlID="txtbxCP">
                                    </ajaxToolkit:FilteredTextBoxExtender>
                                </td>
                                <td>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlCols" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="imgAddMun" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="imgCancelMun" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="imgAddMun" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="imgAddLoc" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="imgCancelLoc" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="imgModifLoc" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="imgAddCol" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="imgCancelCol" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="imgModifCol" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="imgModifCP" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="imgCancelCP" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
            <td style="text-align: left;">
            </td>
        </tr>
    </table>
</asp:Content>
