<%@ page language="VB" enableeventvalidation="false" masterpagefile="~/MasterPageSesionIniciada.master" autoeventwireup="false" inherits="OrdenesDePresPorPlaza, App_Web_erzns4be" title="COBAEV - Nómina - Ordenes de presentación por plaza" stylesheettheme="SkinFile" maintainScrollPositionOnPostBack="true" %>

<%@ Register Src="~/WebControls/wucSearchEmps.ascx" TagName="wucBuscaEmpleados" TagPrefix="uc1" %>
<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress"
    TagPrefix="TP_wucUpdateProgress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
    <table style="width: 100%; height: 300px" align="center">
        <tr>
            <td style="vertical-align: top; text-align: right">
                <h2>
                    Sistema de nómina: Ordenes de presentación por plaza
                </h2>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top; width: 100%; height: 100%; text-align: left">
                <table style="width: 100%">
                    <tr>
                        <td style="vertical-align: top; text-align: left">
                            <table style="width: 100%">
                                <tr>
                                    <td>
                                        <uc1:wucBuscaEmpleados ID="WucBuscaEmpleados1" runat="server" EnableViewState="true" />
                                    </td>
                                    <td style="vertical-align: top; text-align: right">
                                        &nbsp;<asp:ImageButton ID="ibActualizar" runat="server" ImageUrl="~/Imagenes/Refresh.jpg"
                                            ToolTip="Actualizar información" /><br />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top; text-align: left">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <ajaxToolkit:CollapsiblePanelExtender ID="CPEPlazasVigentes" runat="Server" CollapseControlID="TitlePanelPlazasVigentes"
                                        Collapsed="False" CollapsedImage="~/Imagenes/expand_blue.jpg" CollapsedText="(Mostrar detalles...)"
                                        ExpandControlID="TitlePanelPlazasVigentes" ExpandedImage="~/Imagenes/collapse_blue.jpg"
                                        ExpandedText="(Ocultar detalles...)" ImageControlID="Image1" SuppressPostBack="true"
                                        TargetControlID="ContentPanelPlazasVigentes" TextLabelID="Label1">
                                    </ajaxToolkit:CollapsiblePanelExtender>
                                    <ajaxToolkit:CollapsiblePanelExtender ID="CPEHistoriaPlazas" runat="Server" CollapseControlID="TitlePanelHistoriaPlazas"
                                        Collapsed="False" CollapsedImage="~/Imagenes/expand_blue.jpg" CollapsedText="(Mostrar detalles...)"
                                        ExpandControlID="TitlePanelHistoriaPlazas" ExpandedImage="~/Imagenes/collapse_blue.jpg"
                                        ExpandedText="(Ocultar detalles...)" ImageControlID="Image3" SuppressPostBack="true"
                                        TargetControlID="ContentPanelHistoriaPlazas" TextLabelID="Label3">
                                    </ajaxToolkit:CollapsiblePanelExtender>
                                    <table cellpadding="0" cellspacing="0" style="width: 100%">
                                        <tbody>
                                            <tr>
                                                <td colspan="2" style="vertical-align: top; text-align: left">
                                                    <asp:Panel ID="pnl1" runat="server">
                                                        <asp:Label ID="lblEmpInf" runat="server" Font-Strikeout="False" Font-Underline="True"
                                                            SkinID="SkinLblDatos"></asp:Label>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="vertical-align: top; width: 100%; text-align: left">
                                                    <asp:Panel ID="TitlePanelPlazasVigentes" runat="server" BorderColor="White" BorderStyle="Solid"
                                                        BorderWidth="1px" CssClass="collapsePanelHeader" Width="100%">
                                                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/expand_blue.jpg" />
                                                        Plazas vigentes
                                                        <asp:Label ID="Label1" runat="server">(Mostrar detalles...)</asp:Label>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="vertical-align: top; width: 100%; text-align: left">
                                                    <asp:Panel ID="ContentPanelPlazasVigentes" runat="server" CssClass="collapsePanel"
                                                        Width="100%">
                                                        <asp:GridView ID="gvPlazasVigentes" runat="server" EmptyDataText="Sin plazas vigentes"
                                                            Height="100%" ShowFooter="True" SkinID="SkinGridViewEmpty" Width="100%" OnRowDataBound="gvPlazasVigentes_RowDataBound">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="IdPlaza" Visible="False">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblIdPlaza" runat="server" Text='<%# Bind("IdPlaza") %>'></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblIdPlaza" runat="server" Text='<%# Bind("IdPlaza") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Plaza(s)">
                                                                    <FooterTemplate>
                                                                    </FooterTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblPlazas" runat="server" Text='<%# Bind("Plazas") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblPlazas" runat="server" Text='<%# Bind("Plazas") %>'></asp:Label>
                                                                    </EditItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Ocupaci&#243;n">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblOcupacion" runat="server" Text='<%# Bind("AbrevTipoEmp") %>' ToolTip='<%# Bind("DescTipoEmp") %>'></asp:Label>
                                                                        <asp:Image ID="imgInfTitular" runat="server" ImageUrl="~/Imagenes/UserInfo.jpg" />
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblOcupacion" runat="server" Text='<%# Bind("AbrevTipoEmp") %>' ToolTip='<%# Bind("DescTipoEmp") %>'></asp:Label>
                                                                        <asp:Image ID="imgInfTitular" runat="server" ImageUrl="~/Imagenes/UserInfo.jpg" />
                                                                    </EditItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Sindicato">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblSindicato" runat="server" Text='<%# Bind("SiglasSindicato") %>'
                                                                            ToolTip='<%# Bind("NombreSindicato") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Funci&#243;n primaria" Visible="False">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblNombreFuncionPri" runat="server" SkinID="SkinLblNormal" Text=""></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblNombreFuncionPri" runat="server" SkinID="SkinLblNormal" Text=""></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Funci&#243;n secundaria" Visible="False">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblNombreFuncionSec" runat="server" SkinID="SkinLblNormal" Text=""></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblNombreFuncionSec" runat="server" SkinID="SkinLblNormal" Text=""></asp:Label>
                                                                    </EditItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="Inicio" HeaderText="Inicio" ReadOnly="True">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="T&#233;rmino" HeaderText="T&#233;rmino" ReadOnly="True">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                                <asp:TemplateField HeaderText="Motivo de baja">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblMotGralBaja" runat="server" SkinID="SkinLblNormal"></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblMotGralBaja" runat="server" SkinID="SkinLblNormal"></asp:Label>
                                                                    </EditItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Cadena">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblIdCadena" runat="server" Visible="False"></asp:Label>
                                                                        <asp:LinkButton ID="lbNumCadena" runat="server" SkinID="SkinLinkButton"></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblIdCadena" runat="server" Visible="False"></asp:Label>
                                                                        <asp:LinkButton ID="lbNumCadena" runat="server" SkinID="SkinLinkButton"></asp:LinkButton>
                                                                    </EditItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Tipo Mov.">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblTipoMov" runat="server"></asp:Label>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblTipoMov" runat="server"></asp:Label><asp:DropDownList ID="ddlTipoMov"
                                                                            runat="server" SkinID="SkinDropDownList" Visible="False">
                                                                            <asp:ListItem Value="A">Alta</asp:ListItem>
                                                                            <asp:ListItem Value="B">Baja</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </EditItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Orden de presentaci&#243;n">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblIdOrdenDePres" runat="server" Visible="False"></asp:Label><asp:LinkButton
                                                                            ID="lbNumOrdPres" runat="server" SkinID="SkinLinkButton"></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblIdOrdenDePres" runat="server" Visible="False"></asp:Label><asp:DropDownList
                                                                            ID="ddlOPs" runat="server" SkinID="SkinDropDownList">
                                                                        </asp:DropDownList>
                                                                    </EditItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <ItemTemplate>
                                                                        <asp:ImageButton ID="ibDetalles" runat="server" ImageUrl="~/Imagenes/Detalles.png"
                                                                            ToolTip="Ver definición de la clave presupuestal" />
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField ShowHeader="False">
                                                                    <EditItemTemplate>
                                                                        <asp:ImageButton ID="ibGuardar" runat="server" CausesValidation="True" ImageUrl="~/Imagenes/CDROM.png"
                                                                            ToolTip="Guardar" OnClick="ibGuardar_Click" />&nbsp;<asp:ImageButton ID="ibCancelar"
                                                                                runat="server" CausesValidation="False" ImageUrl="~/Imagenes/Eliminar.png" ToolTip="Cancelar"
                                                                                OnClick="ibCancelar_Click" />
                                                                        <ajaxToolkit:ConfirmButtonExtender ID="CBECancelar" runat="server" ConfirmText="La operación solicitada guardará las modificaciones realizadas en la Base de datos, ¿Continuar?"
                                                                            TargetControlID="ibGuardar">
                                                                        </ajaxToolkit:ConfirmButtonExtender>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:ImageButton ID="ibEditar" runat="server" CausesValidation="False" ImageUrl="~/Imagenes/AsigarNumOrdPres.gif"
                                                                            ToolTip="Asignar número de orden de presentación al movimiento." OnClick="ibEditar_Click" />
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <EmptyDataTemplate>
                                                            </EmptyDataTemplate>
                                                        </asp:GridView>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="vertical-align: top; width: 100%; text-align: left">
                                                    <asp:Panel ID="TitlePanelHistoriaPlazas" runat="server" BorderColor="White" BorderStyle="Solid"
                                                        BorderWidth="1px" CssClass="collapsePanelHeader" Width="100%">
                                                        <asp:Image ID="Image3" runat="server" ImageUrl="~/Imagenes/expand_blue.jpg" />
                                                        Histórico de plazas
                                                        <asp:Label ID="Label3" runat="server">(Mostrar detalles...)</asp:Label>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="vertical-align: top; width: 100%; text-align: left">
                                                    <asp:Panel ID="ContentPanelHistoriaPlazas" runat="server" CssClass="collapsePanel"
                                                        Width="100%">
                                                        <asp:GridView ID="gvPlazasHistoria" runat="server" EmptyDataText="Sin historia de plazas"
                                                            Height="100%" ShowFooter="True" SkinID="SkinGridViewEmpty" Width="100%" OnRowDataBound="gvPlazasHistoria_RowDataBound">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="IdPlaza" Visible="False">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblIdPlaza" runat="server" Text='<%# Bind("IdPlaza") %>'></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblIdPlaza" runat="server" Text='<%# Bind("IdPlaza") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Plaza(s)">
                                                                    <FooterTemplate>
                                                                    </FooterTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblPlazas" runat="server" Text='<%# Bind("Plazas") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblPlazas" runat="server" Text='<%# Bind("Plazas") %>'></asp:Label>
                                                                    </EditItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Ocupaci&#243;n">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblOcupacion" runat="server" Text='<%# Bind("AbrevTipoEmp") %>' ToolTip='<%# Bind("DescTipoEmp") %>'></asp:Label>
                                                                        <asp:Image ID="imgInfTitular" runat="server" ImageUrl="~/Imagenes/UserInfo.jpg" />
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblOcupacion" runat="server" Text='<%# Bind("AbrevTipoEmp") %>' ToolTip='<%# Bind("DescTipoEmp") %>'></asp:Label>
                                                                        <asp:Image ID="imgInfTitular" runat="server" ImageUrl="~/Imagenes/UserInfo.jpg" />
                                                                    </EditItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Sindicato">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblSindicato" runat="server" Text='<%# Bind("SiglasSindicato") %>'
                                                                            ToolTip='<%# Bind("NombreSindicato") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblSindicato" runat="server" Text='<%# Bind("SiglasSindicato") %>'
                                                                            ToolTip='<%# Bind("NombreSindicato") %>'></asp:Label>
                                                                    </EditItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Funci&#243;n primaria" Visible="False">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblNombreFuncionPri" runat="server" SkinID="SkinLblNormal" Text=""></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblNombreFuncionPri" runat="server" SkinID="SkinLblNormal" Text=""></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Funci&#243;n secundaria" Visible="False">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblNombreFuncionSec" runat="server" SkinID="SkinLblNormal" Text=""></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblNombreFuncionSec" runat="server" SkinID="SkinLblNormal" Text=""></asp:Label>
                                                                    </EditItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="Inicio" HeaderText="Inicio" ReadOnly="True">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="T&#233;rmino" HeaderText="T&#233;rmino" ReadOnly="True">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                                <asp:TemplateField HeaderText="Motivo de baja">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblMotGralBaja" runat="server" SkinID="SkinLblNormal"></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblMotGralBaja" runat="server" SkinID="SkinLblNormal"></asp:Label>
                                                                    </EditItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Cadena">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblIdCadena" runat="server" Visible="False"></asp:Label><asp:LinkButton
                                                                            ID="lbNumCadena" runat="server" SkinID="SkinLinkButton"></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblIdCadena" runat="server" Visible="False"></asp:Label><asp:LinkButton
                                                                            ID="lbNumCadena" runat="server" SkinID="SkinLinkButton"></asp:LinkButton>
                                                                    </EditItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Tipo Mov.">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblTipoMov" runat="server"></asp:Label>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblTipoMov" runat="server"></asp:Label><asp:DropDownList ID="ddlTipoMov"
                                                                            runat="server" SkinID="SkinDropDownList" Visible="False">
                                                                            <asp:ListItem Value="A">Alta</asp:ListItem>
                                                                            <asp:ListItem Value="B">Baja</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </EditItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Orden de presentaci&#243;n">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblIdOrdenDePres" runat="server" Visible="False"></asp:Label><asp:LinkButton
                                                                            ID="lbNumOrdPres" runat="server" SkinID="SkinLinkButton"></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblIdOrdenDePres" runat="server" Visible="False"></asp:Label><asp:DropDownList
                                                                            ID="ddlOPs" runat="server" SkinID="SkinDropDownList">
                                                                        </asp:DropDownList>
                                                                    </EditItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <ItemTemplate>
                                                                        <asp:ImageButton ID="ibDetalles" runat="server" ImageUrl="~/Imagenes/Detalles.png"
                                                                            ToolTip="Ver definición de la clave presupuestal" />
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField ShowHeader="False">
                                                                    <EditItemTemplate>
                                                                        <asp:ImageButton ID="ibGuardar" runat="server" CausesValidation="True" ImageUrl="~/Imagenes/CDROM.png"
                                                                            ToolTip="Guardar" OnClick="ibGuardar_Click1" />&nbsp;<asp:ImageButton ID="ibCancelar"
                                                                                runat="server" CausesValidation="False" ImageUrl="~/Imagenes/Eliminar.png" ToolTip="Cancelar"
                                                                                OnClick="ibCancelar_Click1" />
                                                                        <ajaxToolkit:ConfirmButtonExtender ID="CBECancelar" runat="server" ConfirmText="La operación solicitada guardará las modificaciones realizadas en la Base de datos, ¿Continuar?"
                                                                            TargetControlID="ibGuardar">
                                                                        </ajaxToolkit:ConfirmButtonExtender>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:ImageButton ID="ibEditar" runat="server" CausesValidation="False" ImageUrl="~/Imagenes/AsigarNumOrdPres.gif"
                                                                            ToolTip="Asignar número de orden de presentación al movimiento." OnClick="ibEditar_Click1" />
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <EmptyDataTemplate>
                                                            </EmptyDataTemplate>
                                                        </asp:GridView>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ibActualizar" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="WucBuscaEmpleados1" EventName="PreRender" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
