<%@ Page Language="VB" EnableEventValidation="false"  MasterPageFile="~/MasterPageSesionIniciada.master" AutoEventWireup="false" CodeFile="NoUsada_EstimuloDocente.aspx.vb" Inherits="Consultas_Percepciones_EstimuloDocente" title="COBAEV - Nómina - Estímulos al desempeño docente" StylesheetTheme="SkinFile" %>
<%@ Register Src="~/WebControls/wucBuscaEmpleados.ascx" TagName="wucBuscaEmpleados" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 100%; height: 300px" align="center">
        <tr>
            <td style="vertical-align: top; width: 100%; height: 100%; text-align: left">
                <table style="width: 100%">
                    <tr>
                        <td style="width: 100%">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:Panel ID="pnlAnios" runat="server" DefaultButton="btnConsultar"
                                        Font-Names="Verdana" Font-Size="X-Small" GroupingText="Seleccione año">
                                        <br />
                                        <asp:DropDownList ID="ddlAnios" runat="server" SkinID="SkinDropDownList">
                                        </asp:DropDownList>
                                        <asp:Button ID="btnConsultar" runat="server" 
                                            SkinID="SkinBoton" Text="Ver empleados" ToolTip="Consultar empleados con derecho a estímulo al desempeño docente en el año seleccionado" /><br />
                                        <br />
                                    </asp:Panel>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                                <ProgressTemplate>
<asp:Image id="Image4" runat="server" ImageUrl="~/Imagenes/spinner.gif"></asp:Image> 
<asp:Label id="lblUpdateProgress" runat="server" Text="Actualizando..." SkinID="SkinLblDatos"></asp:Label>
</ProgressTemplate>
                            </asp:UpdateProgress>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100%">
                            <asp:UpdatePanel id="UpdatePanel2" runat="server">
                                <contenttemplate>
<ajaxToolkit:CollapsiblePanelExtender id="CPEEstDoc" runat="Server" TextLabelID="Label1" TargetControlID="ContentPanelEstDoc" SuppressPostBack="true" ImageControlID="Image1" ExpandedText="(Ocultar detalles...)" ExpandedImage="~/Imagenes/collapse_blue.jpg" ExpandControlID="TitlePanelEstDoc" CollapsedText="(Mostrar detalles...)" CollapsedImage="~/Imagenes/expand_blue.jpg" Collapsed="False" CollapseControlID="TitlePanelEstDoc">
</ajaxToolkit:CollapsiblePanelExtender> <TABLE style="WIDTH: 100%" cellSpacing=0 cellPadding=0><TBODY>
    <tr>
        <td colspan="2" style="vertical-align: top; width: 100%; text-align: left">
            <br />
            <asp:LinkButton ID="lbAgregarNuevoEmp" runat="server" SkinID="SkinLinkButton" OnClick="lbAgregarNuevoEmp_Click">Agregar nuevo empleado</asp:LinkButton></td>
    </tr>
    <TR><TD style="VERTICAL-ALIGN: top; WIDTH: 100%; TEXT-ALIGN: left" colSpan=2>
<asp:Panel id="TitlePanelEstDoc" runat="server" Width="100%" BorderWidth="1px" BorderStyle="Solid" BorderColor="White" CssClass="collapsePanelHeader"><asp:Image id="Image1" runat="server" ImageUrl="~/Imagenes/expand_blue.jpg"></asp:Image>
    Estímulos al desempeño docente
    <asp:Label id="Label1" runat="server">
        (Mostrar detalles...)</asp:Label> </asp:Panel> </TD></TR><TR><TD style="VERTICAL-ALIGN: top; WIDTH: 100%; TEXT-ALIGN: left" colSpan=2>
        <asp:Panel id="ContentPanelEstDoc" runat="server" Width="100%" CssClass="collapsePanel">
        <asp:GridView id="gvEstimulosDocentes" runat="server" Width="100%" SkinID="SkinGridView" EmptyDataText="No existen estímulos al desempeño docente." AutoGenerateColumns="False">
            <Columns>
                <asp:TemplateField HeaderText="A&#241;o">
                    <ItemTemplate>
                        <asp:Label ID="lblAnio" runat="server" Text='<%# Bind("Anio") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="RFC">
                    <ItemTemplate>
                        <asp:LinkButton ID="lbRFC" runat="server" CommandName="CmdRFC" Text='<%# Bind("RFCemp") %>'></asp:LinkButton>
                        <ajaxToolkit:ConfirmButtonExtender ID="CBEEmpSel" runat="server" ConfirmText="¿Seleccionar empleado para consultas posteriores?"
                            TargetControlID="lbRFC">
                        </ajaxToolkit:ConfirmButtonExtender>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="CURP">
                    <ItemTemplate>
                        <asp:Label ID="lblCURP" runat="server" Text='<%# Bind("CURPEmp") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Apellido paterno">
                    <ItemTemplate>
                        <asp:Label ID="lblApePat" runat="server" Text='<%# Bind("ApePatEmp") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Apellido materno">
                    <ItemTemplate>
                        <asp:Label ID="lblApeMat" runat="server" Text='<%# Bind("ApeMatEmp") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Nombre">
                    <ItemTemplate>
                        <asp:Label ID="lblNombre" runat="server" Text='<%# Bind("NomEmp") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="N&#250;mero de empleado">
                    <ItemTemplate>
                        <asp:Label ID="lblNumEmp" runat="server" Text='<%# Bind("NumEmp") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:BoundField DataField="DescPlantel" HeaderText="Plantel" />
                <asp:TemplateField HeaderText="Importe">
                    <ItemTemplate>
                        <asp:Label ID="lblImporte" runat="server" Text='<%# Bind("Importe", "{0:c}") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Right" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Eliminar">
                    <ItemTemplate>
                        <asp:ImageButton ID="ibEliminar" runat="server" CommandName="CmdEliminar" ImageUrl="~/Imagenes/Eliminar.png" />
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Modificar">
                    <ItemTemplate>
                        <asp:ImageButton ID="ibModificar" runat="server" CommandName="CmdModificar" ImageUrl="~/Imagenes/Modificar.png" />
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
            </Columns>
            <EmptyDataRowStyle Font-Italic="True" />
</asp:GridView>
        </asp:Panel> </TD></TR><TR><TD style="VERTICAL-ALIGN: top; WIDTH: 100%; TEXT-ALIGN: left" colSpan=2>
    </TD></TR><TR><TD style="VERTICAL-ALIGN: top; WIDTH: 100%; TEXT-ALIGN: left" colSpan=2>
    </TD></TR></TBODY></TABLE>
</contenttemplate>
                                <triggers>
<asp:AsyncPostBackTrigger ControlID="btnConsultar" EventName="Click"></asp:AsyncPostBackTrigger>
</triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

