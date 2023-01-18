<%@ page language="VB" enableeventvalidation="false" masterpagefile="~/MasterPageSesionIniciada.master" autoeventwireup="false" inherits="ConsultasGuarderia, App_Web_xh1ifbg5" title="COBAEV - Nómina - Consulta de empleados con percepción de guardería" stylesheettheme="SkinFile" maintainScrollPositionOnPostBack="true" %>

<%@ Register Src="~/WebControls/wucSearchEmps.ascx" TagName="wucBuscaEmpleados" TagPrefix="uc1" %>
<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress" TagPrefix="TP_wucUpdateProgress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<asp:UpdatePanel ID="UPMain" runat="server">
    <ContentTemplate>
    <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
    <table style="width: 100%; height: 300px" align="center">
        <tr>
            <td style="vertical-align: top; text-align: right">
                <h2>
                    Sistema de nómina: Empleados (Información sobre hijos)
                </h2>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top; width: 100%; height: 100%; text-align: left">
                <table style="width: 100%">
                    <tr>
                        <td style="width: 100%">
                            <table style="width: 100%">
                                <tr>
                                    <td style="vertical-align: top; text-align: left">
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
                        <td style="width: 100%">
                                    <asp:Panel ID="pnlGral1" runat="server">
                                        <asp:Label ID="lblEmpInf" runat="server" Font-Strikeout="False" Font-Underline="True"
                                            SkinID="SkinLblDatos" Visible="False"></asp:Label><br />
                                        <br />
                                        <asp:LinkButton ID="lbAgregarNuevo" runat="server" Font-Bold="False" Font-Italic="False"
                                            SkinID="SkinLinkButton" ToolTip="Agregar nuevo hijo para el empleado seleccionado"
                                            Visible="False">Agregar nuevo hijo</asp:LinkButton>
                                    </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100%">
                                    <asp:Panel ID="pnlGral2" runat="server">
                                        <ajaxToolkit:CollapsiblePanelExtender ID="CPEHijos" runat="Server" CollapseControlID="TitlePanelHijos"
                                            Collapsed="False" CollapsedImage="~/Imagenes/expand_blue.jpg" CollapsedText="(Mostrar detalles...)"
                                            ExpandControlID="TitlePanelHijos" ExpandedImage="~/Imagenes/collapse_blue.jpg"
                                            ExpandedText="(Ocultar detalles...)" ImageControlID="Image1" SuppressPostBack="true"
                                            TargetControlID="ContentPanelHijos" TextLabelID="Label1">
                                        </ajaxToolkit:CollapsiblePanelExtender>
                                        <table cellpadding="0" cellspacing="0" style="width: 100%">
                                            <tbody>
                                                <tr>
                                                    <td colspan="2" style="vertical-align: top; width: 100%; text-align: left">
                                                        <asp:Panel ID="TitlePanelHijos" runat="server" BorderColor="White" BorderStyle="Solid"
                                                            BorderWidth="1px" CssClass="collapsePanelHeader" Width="100%">
                                                            <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/expand_blue.jpg" />
                                                            Hijos por empleado
                                                            <asp:Label ID="Label1" runat="server">(Mostrar detalles...)</asp:Label>
                                                        </asp:Panel>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" style="vertical-align: top; width: 100%; text-align: left">
                                                        <asp:Panel ID="ContentPanelHijos" runat="server" CssClass="collapsePanel" Width="100%">
                                                            <asp:GridView ID="gvHijos" runat="server" EmptyDataText="Sin información de hijos"
                                                                SkinID="SkinGridView" Width="100%">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="IdEmpHijo" Visible="False">
                                                                        <EditItemTemplate>
                                                                        </EditItemTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblIdEmpHijo" runat="server" Text='<%# Bind("IdEmpHijo") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="RFC" HeaderText="RFC" >
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="ApePat" HeaderText="Apellido paterno">
                                                                        <HeaderStyle HorizontalAlign="Left" />
                                                                        <ItemStyle HorizontalAlign="Left" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="ApeMat" HeaderText="Apellido materno" >
                                                                        <HeaderStyle HorizontalAlign="Left" />
                                                                        <ItemStyle HorizontalAlign="Left" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="Nombre" HeaderText="Nombre">
                                                                        <HeaderStyle HorizontalAlign="Left" />
                                                                        <ItemStyle HorizontalAlign="Left" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="FechaNacHijo" HeaderText="Fecha de nacimiento" DataFormatString="{0:d}">
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="IncluirParaCalculo" HeaderText="Incluir para c&#225;lculo (Guardería)">
                                                                        <HeaderStyle HorizontalAlign="Center"  />
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                    </asp:BoundField>
                                                                    <asp:TemplateField>
                                                                        <ItemTemplate>
                                                                            <asp:ImageButton ID="ibModificar" runat="server" ImageUrl="~/Imagenes/Modificar.png"
                                                                                ToolTip="Modificar la información del hijo" OnClick="ibModificar_Click" />
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </asp:Panel>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </asp:Panel>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>
