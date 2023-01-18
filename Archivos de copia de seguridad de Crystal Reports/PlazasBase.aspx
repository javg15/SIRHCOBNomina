<%@ Page Language="VB" EnableEventValidation="false" MasterPageFile="~/MasterPageBlanca.master"
    AutoEventWireup="false" CodeFile="PlazasBase.aspx.vb" Inherits="AdmonPlazasBase"
    Title="COBAEV - Nómina - Administración de plazas base" StylesheetTheme="SkinFile" %>

<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress"
    TagPrefix="TP_wucUpdateProgress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <table style="width: 100%;" align="center">
                <tr>
                    <td style="vertical-align: top; text-align: right">
                        <h2>
                            Sistema de nómina: Empleados (Información de plazas base)
                        </h2>
                    </td>
                </tr>
            </table>
            <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                <asp:View ID="vistaConsulta" runat="server">
                    <table style="width: 100%; vertical-align: top; text-align: center;">
                        <tr>
                            <td style="text-align: left; vertical-align: top;">
                                <asp:GridView ID="gvPlazasBase" runat="server" SkinID="SkinGridView" Width="100%">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Tipo Semestre">
                                            <ItemTemplate>
                                                <asp:Label ID="lblTipoSemestre" runat="server" Text='<%# Bind("TipoSemestre") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" Width="100px" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Categoría">
                                            <ItemTemplate>
                                                <asp:Label ID="lblIdCategoria" runat="server" Text='<%# Bind("IdCategoria") %>' Visible="False"></asp:Label>
                                                <asp:Label ID="lblCategoria" runat="server" Text='<%# Bind("Categoria") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Horas">
                                            <ItemTemplate>
                                                <asp:Label ID="lblHoras" runat="server" Text='<%# Bind("Horas") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" Width="100px" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Inicio" Visible="True">
                                            <ItemTemplate>
                                                <asp:Label ID="lblIdQnaIni" runat="server" Text='<%# Bind("IdQnaIni") %>' Visible="False"></asp:Label>
                                                <asp:Label ID="lblQnaIni" runat="server" Text='<%# Bind("QnaIni") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" Width="100px" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Fin" Visible="True">
                                            <ItemTemplate>
                                                <asp:Label ID="lblIdQnaFin" runat="server" Text='<%# Bind("IdQnaFin") %>' Visible="False"></asp:Label>
                                                <asp:Label ID="lblQnaFin" runat="server" Text='<%# Bind("QnaFin") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" Width="100px" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ibModify" runat="server" ImageUrl="~/Imagenes/Modificar.png"
                                                    OnClick="ibModify_Click" ToolTip="Modificar registro." />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ibEliminar" runat="server" ImageUrl="~/Imagenes/Eliminar.png"
                                                    OnClick="ibEliminar_Click" ToolTip="Eliminar registro definitivamente." />
                                                <ajaxToolkit:ConfirmButtonExtender ID="ibEliminar_CBE" runat="server" ConfirmText="¿Está seguro de eliminar el registro?"
                                                    Enabled="True" TargetControlID="ibEliminar">
                                                </ajaxToolkit:ConfirmButtonExtender>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left">
                                <asp:LinkButton ID="lbAddPlazaBase" runat="server" SkinID="SkinLinkButton" Visible="False">Agregar plaza base</asp:LinkButton>
                                &nbsp;<asp:LinkButton ID="lbVerHistoria" runat="server" CommandName="VerHistoria"
                                    SkinID="SkinLinkButton" Visible="False">Ver histórico de plazas base</asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left">
                                <br />
                                <asp:Label ID="lblMsjTitulo1" runat="server" SkinID="SkinLblHeader" Text="Histórico de plazas base"
                                    Visible="False"></asp:Label>
                                <asp:GridView ID="gvPlazasBaseHistoria" runat="server" SkinID="SkinGridView" Visible="False"
                                    Width="100%">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Tipo Semestre">
                                            <ItemTemplate>
                                                <asp:Label ID="lblTipoSemestre0" runat="server" Text='<%# Bind("TipoSemestre") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" Width="100px" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Categoría">
                                            <ItemTemplate>
                                                <asp:Label ID="lblIdCategoria0" runat="server" Text='<%# Bind("IdCategoria") %>'
                                                    Visible="False"></asp:Label>
                                                <asp:Label ID="lblCategoria0" runat="server" Text='<%# Bind("Categoria") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Horas">
                                            <ItemTemplate>
                                                <asp:Label ID="lblHoras0" runat="server" Text='<%# Bind("Horas") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" Width="100px" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Inicio">
                                            <ItemTemplate>
                                                <asp:Label ID="lblIdQnaIni0" runat="server" Text='<%# Bind("IdQnaIni") %>' Visible="False"></asp:Label>
                                                <asp:Label ID="lblQnaIni0" runat="server" Text='<%# Bind("QnaIni") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" Width="100px" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Fin">
                                            <ItemTemplate>
                                                <asp:Label ID="lblIdQnaFin0" runat="server" Text='<%# Bind("IdQnaFin") %>' Visible="False"></asp:Label>
                                                <asp:Label ID="lblQnaFin0" runat="server" Text='<%# Bind("QnaFin") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" Width="100px" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </asp:View>
                <asp:View ID="vistaAddPlazaBase" runat="server">
                    <asp:Label ID="lblMsjTitulo" runat="server" SkinID="SkinLblHeader" Text="Capture la información"></asp:Label>
                    <br />
                    <table>
                        <tr>
                            <td>
                                <asp:Label ID="Label2" runat="server" SkinID="SkinLblNormal" Text="Tipo Semestre"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlTipoSemestre" runat="server" SkinID="SkinDropDownList">
                                    <asp:ListItem>A</asp:ListItem>
                                    <asp:ListItem>B</asp:ListItem>
                                    <asp:ListItem>A,B</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label3" runat="server" SkinID="SkinLblNormal" Text="Categoría"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlCategorias" runat="server" AutoPostBack="True" SkinID="SkinDropDownList">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label4" runat="server" SkinID="SkinLblNormal" Text="Horas"></asp:Label>
                            </td>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="tbHoras" runat="server" Columns="8" MaxLength="2" SkinID="SkinTextBox"></asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="tbHoras_FilteredTextBoxExtender" runat="server"
                                            Enabled="True" TargetControlID="tbHoras" ValidChars="0123456789">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                        <asp:CompareValidator ID="CVHoras" runat="server" ControlToValidate="tbHoras" Display="Dynamic"
                                            ErrorMessage="Valor incorrecto." Font-Size="Small" Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="ddlCategorias" EventName="SelectedIndexChanged" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblQnaIni" runat="server" SkinID="SkinLblNormal" Text="Inicio"></asp:Label>
                            </td>
                            <td colspan="1">
                                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlAniosIni" runat="server" AutoPostBack="True" SkinID="SkinDropDownList">
                                        </asp:DropDownList>
                                        <asp:DropDownList ID="ddlQnasIni" runat="server" AutoPostBack="True" SkinID="SkinDropDownList">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblQnaFin" runat="server" SkinID="SkinLblNormal" Text="Fin"></asp:Label>
                            </td>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlAniosFin" runat="server" AutoPostBack="True" SkinID="SkinDropDownList">
                                        </asp:DropDownList>
                                        <asp:DropDownList ID="ddlQnasFin" runat="server" SkinID="SkinDropDownList">
                                        </asp:DropDownList>
                                        <asp:CheckBox ID="chbEfectosAbiertos" runat="server" AutoPostBack="True" SkinID="SkinCheckBox"
                                            Text="Efectos abiertos (999999)" />
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="ddlAniosIni" EventName="SelectedIndexChanged" />
                                        <asp:AsyncPostBackTrigger ControlID="ddlQnasIni" EventName="SelectedIndexChanged" />
                                        <asp:AsyncPostBackTrigger ControlID="chbEfectosAbiertos" EventName="CheckedChanged" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="text-align: center">
                                <asp:Button ID="btnGuardar" runat="server" SkinID="SkinBoton" Text="Guardar" Width="109px" />
                                <ajaxToolkit:ConfirmButtonExtender ID="btnGuardar_CBE" runat="server" ConfirmText="¿Los datos son correctos?"
                                    Enabled="True" TargetControlID="btnGuardar">
                                </ajaxToolkit:ConfirmButtonExtender>
                                &nbsp;<asp:Button ID="btnCancelar" runat="server" SkinID="SkinBoton" Text="Cancelar"
                                    Width="109px" />
                                <ajaxToolkit:ConfirmButtonExtender ID="btnCancelar_ConfirmButtonExtender" runat="server"
                                    ConfirmText="¿Está seguro de cancelar la operación?" Enabled="True" TargetControlID="btnCancelar">
                                </ajaxToolkit:ConfirmButtonExtender>
                            </td>
                        </tr>
                    </table>
                    <br />
                </asp:View>
                <asp:View ID="vistaErrores" runat="server">
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
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="lbAddPlazaBase" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnCancelar" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnGuardar" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
