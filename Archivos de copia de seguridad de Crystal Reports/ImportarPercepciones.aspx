<%@ Page EnableEventValidation="false" Language="VB" MasterPageFile="~/MasterPageSesionIniciada.master"
    AutoEventWireup="false" CodeFile="ImportarPercepciones.aspx.vb" Inherits="ImportarPercepciones"
    Title="COBAEV - Nómina - Importar percepciones" StylesheetTheme="SkinFile" %>

<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress"
    TagPrefix="TP_wucUpdateProgress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
    <table style="width: 100%; height: 100%" align="center">
        <tr>
            <td style="vertical-align: top; text-align: right">
                <h2>
                    Sistema de nómina: Importar percepciones para incluir en cálculos quincenales
                </h2>
            </td>
        </tr>
    </table>
    <asp:UpdatePanel ID="UPMain" runat="server">
        <ContentTemplate>
            <table style="width: 100%; height: 100%" align="center">
                <tr>
                    <td style="text-align: left">
                        <asp:MultiView ID="MultiView1" runat="server">
                            <asp:View ID="viewPercepciones" runat="server">
                                <div class="accountInfo">
                                    <div class="panelIzquierda">                                    
                                        <p class="pLabel">
                                            <asp:Label ID="lblSelQna" runat="server"  Text="Seleccione quincena" CssClass="pLabel"></asp:Label>
                                        </p>
                                        <p class="pTextBox">
                                            <asp:DropDownList ID="ddlQnasAbiertasParaCaptura" runat="server" AutoPostBack="true" CssClass="textEntry">
                                            </asp:DropDownList>
                                        </p>
                                         <p class="pLabel">
                                            <asp:Label ID="Label1" runat="server" Text="Seleccione percepción"  CssClass="pLabel"></asp:Label>
                                         </p>
                                         <p class="pTextBox">
                                            <asp:DropDownList ID="ddlPercepciones" runat="server" AutoPostBack="true" CssClass="textEntry">
                                            </asp:DropDownList>
                                         </p>
                                    </div>
                                </div>
                                <div id="divBotones" style="clear:both; float:left;"">
                                    <p class="submitButton">
                                        <asp:Button ID="btnImportar" runat="server" Text="Importar" />
                                        <asp:Button ID="btnEliminar" runat="server" OnClick="btnEliminar_Click"
                                            Text="Eliminar" ToolTip="Eliminar percepciones importadas masivamente" /><ajaxToolkit:ConfirmButtonExtender
                                                ID="CBEbtnEliminar" runat="server" ConfirmText="La operación seleccionada eliminará información de la Base de Datos, ¿Está seguro de continuar?"
                                                TargetControlID="btnEliminar">
                                            </ajaxToolkit:ConfirmButtonExtender>
                                        <ajaxToolkit:ConfirmButtonExtender ID="CBEBtnImportar" runat="server" ConfirmText="¿Información correcta?"
                                            TargetControlID="btnImportar">
                                        </ajaxToolkit:ConfirmButtonExtender>
                                        <asp:Button ID="btnGuardar" runat="server" Text="Guardar"
                                            ToolTip="Guardar información en base de datos" /><ajaxToolkit:ConfirmButtonExtender
                                                ID="CBEbtnGuardar" runat="server" ConfirmText="¿Información correcta?" TargetControlID="btnGuardar">
                                            </ajaxToolkit:ConfirmButtonExtender>
                                    </p>
                                </div>
                                <div style="clear:both; float:left;">
                                <table>
                                    <tr>
                                        <td style="vertical-align: bottom; text-align: left; width: 50%;">
                                            <ajaxToolkit:CollapsiblePanelExtender ID="CPECoincidencias" runat="Server" CollapseControlID="TitlePanelCoincidencias"
                                                Collapsed="False" CollapsedImage="~/Imagenes/expand_blue.jpg" CollapsedText="(Mostrar detalles...)"
                                                ExpandControlID="TitlePanelCoincidencias" ExpandedImage="~/Imagenes/collapse_blue.jpg"
                                                ExpandedText="(Ocultar detalles...)" ImageControlID="Image3" SuppressPostBack="true"
                                                TargetControlID="ContentPanelCoincidencias" TextLabelID="Label3">
                                            </ajaxToolkit:CollapsiblePanelExtender>
                                        </td>
                                        <td style="vertical-align: bottom; text-align: left; width: 50%;">
                                            <ajaxToolkit:CollapsiblePanelExtender ID="CPEInconsistencias" runat="server" CollapseControlID="TitlePanelInconsistencias"
                                                Collapsed="False" CollapsedImage="~/Imagenes/expand_blue.jpg" CollapsedText="(Mostrar detalles...)"
                                                ExpandControlID="TitlePanelInconsistencias" ExpandedImage="~/Imagenes/collapse_blue.jpg"
                                                ExpandedText="(Ocultar detalles...)" ImageControlID="Image5" SuppressPostBack="true"
                                                TargetControlID="ContentPanelInconsistencias" TextLabelID="Label5">
                                            </ajaxToolkit:CollapsiblePanelExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="vertical-align: bottom; text-align: left; width: 50%;">
                                            <asp:Panel ID="TitlePanelCoincidencias" runat="server" BorderColor="White" BorderStyle="Solid"
                                                BorderWidth="1px" CssClass="collapsePanelHeader" Width="100%">
                                                <asp:Image ID="Image3" runat="server" ImageUrl="~/Imagenes/expand_blue.jpg" />
                                                Coincidencias
                                                <asp:Label ID="Label3" runat="server">(Mostrar detalles...)</asp:Label>
                                            </asp:Panel>
                                        </td>
                                        <td style="vertical-align: bottom; text-align: left; width: 50%;">
                                            <asp:Panel ID="TitlePanelInconsistencias" runat="server" BorderColor="White" BorderStyle="Solid"
                                                BorderWidth="1px" CssClass="collapsePanelHeader" Width="100%">
                                                <asp:Image ID="Image5" runat="server" ImageUrl="~/Imagenes/expand_blue.jpg" />
                                                Inconsistencias &nbsp;<asp:Label ID="Label5" runat="server">(Mostrar detalles...)</asp:Label>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="vertical-align: top; text-align: left; width: 50%;">
                                            <asp:Panel ID="ContentPanelCoincidencias" runat="server" CssClass="collapsePanel"
                                                Width="100%">
                                                <asp:Label ID="lblIdPercepcion" runat="server" SkinID="SkinLblNormal" Visible="False"></asp:Label><asp:Label
                                                    ID="lblPercepcion" runat="server" SkinID="SkinLblNormal" Visible="False"></asp:Label><br />
                                                <asp:GridView ID="gvPercMasivas" runat="server" SkinID="SkinGridView" EmptyDataText="No hubo coincidencias"
                                                    Width="100%" Visible="False" AutoGenerateColumns="False">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="N&#250;m. empleado">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblNumEmp" runat="server" Text='<%# Bind("NumEmp") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Empleado">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblEmpleado" runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Importe">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblImportePercepcion" runat="server" Text='<%# Bind("ImportePercepcion", "{0:c}") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Right" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="N&#250;m. qnas.">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblNumQnas" runat="server" Text='<%# Bind("NumQnas") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="IdQnaIni" Visible="False">
                                                            <EditItemTemplate>
                                                                &nbsp;
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblIdQnaIni" runat="server" Text='<%# Bind("IdQnaIni") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="Inicio" HeaderText="Inicio">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:TemplateField HeaderText="IdQnaFin" Visible="False">
                                                            <EditItemTemplate>
                                                                &nbsp;
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblIdQnaFin" runat="server" Text='<%# Bind("IdQnaFin") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="Fin" HeaderText="Fin">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                    </Columns>
                                                </asp:GridView>
                                            </asp:Panel>
                                        </td>
                                        <td style="vertical-align: top; width: 50%; text-align: left">
                                            <asp:Panel ID="ContentPanelInconsistencias" runat="server" CssClass="collapsePanel"
                                                Width="100%">
                                                <asp:Label ID="lblIdPercepcion2" runat="server" SkinID="SkinLblNormal" Visible="False"></asp:Label><asp:Label
                                                    ID="lblPercepcion2" runat="server" SkinID="SkinLblNormal" Visible="False"></asp:Label><asp:GridView
                                                        ID="gvInconsistencias" runat="server" SkinID="SkinGridView" EmptyDataText="No hay inconsistencias"
                                                        Width="100%" Visible="False">
                                                        <Columns>
                                                            <asp:BoundField DataField="NumEmp" HeaderText="N&#250;m. empleado">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:TemplateField HeaderText="Empleado">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblEmpleado" runat="server"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="ImportePercepcion" DataFormatString="{0:c}" HeaderText="Importe">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Right" />
                                                            </asp:BoundField>
                                                            <asp:TemplateField HeaderText="N&#250;m. qnas.">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblNumQnas" runat="server" Text='<%# Bind("NumQnas") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Observaciones">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblObservaciones" runat="server" Text='<%# Bind("Observaciones") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                <br />
                                                &nbsp;</asp:Panel>
                                        </td>
                                    </tr>
                                </table>
                                </div>
                            </asp:View>
                            <asp:View ID="viewExito" runat="server">
                                <table>
                                    <tr>
                                        <td style="vertical-align: middle; text-align: left">
                                            <asp:Image ID="Image2" runat="server" ImageUrl="~/Imagenes/Symbol-Check.png" Width="100px" />
                                        </td>
                                        <td style="vertical-align: middle; text-align: left">
                                            <asp:Label ID="lblExito" runat="server" SkinID="SkinLblMsjExito"></asp:Label><br />
                                            <asp:LinkButton ID="lbExito" runat="server" OnClick="lbExito_Click" SkinID="SkinLinkButton">Continuar</asp:LinkButton>
                                        </td>
                                    </tr>
                                </table>
                            </asp:View>
                        </asp:MultiView>
                        <asp:MultiView ID="MultiView2" runat="server" Visible="False">
                            <asp:View ID="viewError" runat="server">
                                <table>
                                    <tr>
                                        <td style="vertical-align: middle; text-align: left">
                                            <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/Symbol-Stop.png" Width="100px" />
                                        </td>
                                        <td style="vertical-align: middle; text-align: left">
                                            <asp:Label ID="lblError" runat="server" SkinID="SkinLblMsjErrores"></asp:Label><br />
                                            <asp:LinkButton ID="lbError" runat="server" SkinID="SkinLinkButton">Continuar</asp:LinkButton>
                                        </td>
                                    </tr>
                                </table>
                            </asp:View>
                        </asp:MultiView>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
