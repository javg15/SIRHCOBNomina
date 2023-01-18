<%@ Page Language="VB" EnableEventValidation="false" MasterPageFile="~/MasterPageSesionIniciada.master"
    AutoEventWireup="false" CodeFile="PercsDeducsParaCalcDePerc.aspx.vb" Inherits="PercsDeducsParaCalcDePerc"
    Title="COBAEV - N�mina - Percepciones/Deducciones para c�lculo de Percepci�n"
    StylesheetTheme="SkinFile" %>

<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress"
    TagPrefix="TP_wucUpdateProgress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        self.focus();
    </script>
    <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table style="width: 100%" align="center">
                <tr>
                    <td style="vertical-align: top; text-align: right" colspan="2">
                        <h2>
                            Sistema de n�mina: Percepciones/Deducciones para c�lculo de Percepci�n
                        </h2>
                    </td>
                </tr>
                <tr>
                    <td style="vertical-align: top; text-align: left" colspan="2">
                        <asp:Label ID="Label1" runat="server" SkinID="SkinLblNormal" 
                            Text="Seleccione percepci�n"></asp:Label>
                        <br />
                        <asp:DropDownList ID="ddlConcepto" runat="server" 
                            SkinID="SkinDropDownList">
                        </asp:DropDownList>
                        &nbsp;<asp:Button ID="btnConsultar" runat="server" SkinID="SkinBoton" 
                            Text="Consultar" />
                    </td>
                </tr>
            </table>
            <table style="width: 100%" align="center">
                <tr>
                    <td style="width: 100%; text-align: center;" colspan="2">
                        <br />
                        <asp:Label ID="lblMsjPrincipal" runat="server" SkinID="SkinLblMsjExito"></asp:Label>
                        <asp:HiddenField ID="hfidConcepto" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 50%; text-align: left; vertical-align: bottom;">
                        <asp:Label ID="lblPercsSi" runat="server" SkinID="SkinLblNormal">Percepciones inclu�das</asp:Label>
                    </td>
                    <td style="width: 50%; text-align: left; vertical-align: bottom;">
                        <asp:Label ID="lblDeducsSi" runat="server" SkinID="SkinLblNormal">Deducciones inclu�das</asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width: 50%; text-align: left; vertical-align: top;">
                        <asp:GridView ID="gvPercsSi" runat="server" CellPadding="1" EmptyDataText="Sin informaci�n de percepciones."
                            SkinID="SkinGridView" Width="100%">
                            <Columns>
                                <asp:CommandField ButtonType="Image" SelectImageUrl="~/Imagenes/Select.png" ShowSelectButton="True">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:CommandField>
                                <asp:TemplateField HeaderText="IdPercepcion" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIdPercepcion" runat="server" Text='<%# Bind("IdPercepcion") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="ClavePercepcion" HeaderText="Clave">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="NombrePercepcion" HeaderText="Nombre">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ibQuitarPerc" runat="server" ImageUrl="~/Imagenes/Eliminar.png"
                                            OnClick="ibQuitarPerc_Click" ToolTip="Quitar percepci�n para que no participe en el c�lculo de la percepci�n seleccionada." />
                                        <ajaxToolkit:ConfirmButtonExtender ID="ibQuitarPerc_CBE" runat="server" 
                                            ConfirmText="La operaci�n solicitada realizar� cambios en la Base de Datos, �Continuar?" 
                                            Enabled="True" TargetControlID="ibQuitarPerc">
                                        </ajaxToolkit:ConfirmButtonExtender>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Wrap="True" />
                                    <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                    <td style="width: 50%; text-align: left; vertical-align: top;">
                        <asp:GridView ID="gvDeducsSi" runat="server" CellPadding="1" 
                            EmptyDataText="Sin informaci�n de deducciones." SkinID="SkinGridView" 
                            Width="100%">
                            <Columns>
                                <asp:CommandField ButtonType="Image" SelectImageUrl="~/Imagenes/Select.png" 
                                    ShowSelectButton="True">
                                <ItemStyle HorizontalAlign="Center" />
                                </asp:CommandField>
                                <asp:TemplateField HeaderText="IdDeduccion" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIdDeduccion" runat="server" 
                                            Text='<%# Bind("IdDeduccion") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="ClaveDeduccion" HeaderText="Clave">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="NombreDeduccion" HeaderText="Nombre">
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ibQuitarDeduc" runat="server" 
                                            ImageUrl="~/Imagenes/Eliminar.png" OnClick="ibQuitarDeduc_Click" 
                                            ToolTip="Quitar deducci�n para que no participe en el c�lculo de la percepci�n seleccionada." />
                                        <ajaxToolkit:ConfirmButtonExtender ID="ibQuitarDeduc_CBE" runat="server" 
                                            ConfirmText="La operaci�n solicitada realizar� cambios en la Base de Datos, �Continuar?" 
                                            Enabled="True" TargetControlID="ibQuitarDeduc">
                                        </ajaxToolkit:ConfirmButtonExtender>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Wrap="True" />
                                    <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td style="width: 50%; text-align: left;">
                        &nbsp;</td>
                    <td style="width: 50%; text-align: left;">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 50%; text-align: left; vertical-align: bottom;">
                        <asp:Label ID="lblPercsNo" runat="server" SkinID="SkinLblNormal">Percepciones no inclu�das</asp:Label>
                    </td>
                    <td style="width: 50%; text-align: left; vertical-align: bottom;">
                        <asp:Label ID="lblDeducsNo" runat="server" SkinID="SkinLblNormal">Deducciones no inclu�das</asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width: 50%; text-align: left; vertical-align: top;">
                        <asp:GridView ID="gvPercsNo" runat="server" CellPadding="1" 
                            EmptyDataText="Sin informaci�n de percepciones." SkinID="SkinGridView" 
                            Width="100%">
                            <Columns>
                                <asp:CommandField ButtonType="Image" SelectImageUrl="~/Imagenes/Select.png" 
                                    ShowSelectButton="True">
                                <ItemStyle HorizontalAlign="Center" />
                                </asp:CommandField>
                                <asp:TemplateField HeaderText="IdPercepcion" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIdPercepcion" runat="server" 
                                            Text='<%# Bind("IdPercepcion") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="ClavePercepcion" HeaderText="Clave">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="NombrePercepcion" HeaderText="Nombre">
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ibAddPerc" runat="server" ImageUrl="~/Imagenes/Add2.png" 
                                            OnClick="ibAddPerc_Click" 
                                            ToolTip="Agregar percepci�n para que participe en el c�lculo de la percepci�n seleccionada." />
                                        <ajaxToolkit:ConfirmButtonExtender ID="ibAddPerc_CBE" runat="server" 
                                            ConfirmText="La operaci�n solicitada realizar� cambios en la Base de Datos, �Continuar?" 
                                            Enabled="True" TargetControlID="ibAddPerc">
                                        </ajaxToolkit:ConfirmButtonExtender>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Wrap="True" />
                                    <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                    <td style="width: 50%; text-align: left; vertical-align: top;">
                        <asp:GridView ID="gvDeducsNo" runat="server" CellPadding="1" EmptyDataText="Sin informaci�n de deducciones."
                            SkinID="SkinGridView" Width="100%">
                            <Columns>
                                <asp:CommandField ButtonType="Image" SelectImageUrl="~/Imagenes/Select.png" ShowSelectButton="True">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:CommandField>
                                <asp:TemplateField HeaderText="IdDeduccion" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIdDeduccion" runat="server" Text='<%# Bind("IdDeduccion") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="ClaveDeduccion" HeaderText="Clave">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="NombreDeduccion" HeaderText="Nombre">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ibAddDeduc" runat="server" ImageUrl="~/Imagenes/Add2.png"
                                            OnClick="ibAddDeduc_Click" ToolTip="Agregar deducci�n para que participe en el c�lculo de la percepci�n seleccionada." />
                                        <ajaxToolkit:ConfirmButtonExtender ID="ibAddDeduc_CBE" runat="server" 
                                            ConfirmText="La operaci�n solicitada realizar� cambios en la Base de Datos, �Continuar?" 
                                            Enabled="True" TargetControlID="ibAddDeduc">
                                        </ajaxToolkit:ConfirmButtonExtender>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Wrap="True" />
                                    <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
