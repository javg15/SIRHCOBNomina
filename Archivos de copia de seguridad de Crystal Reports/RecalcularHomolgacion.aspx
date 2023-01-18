<%@ Page Language="VB" EnableEventValidation="false" MasterPageFile="~/MasterPageSesionIniciada.master"
    AutoEventWireup="false" CodeFile="RecalcularHomolgacion.aspx.vb" Inherits="Consultas_Nomina_RecalcularHomologacion"
    Title="COBAEV - Nómina - Autorizaciones de recálculo de homologación" StylesheetTheme="SkinFile" %>

<%@ Register Src="~/WebControls/wucBuscaEmpleados.ascx" TagName="wucBuscaEmpleados"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 10%; height: 300px">
        <tr>
            <td style="vertical-align: top; width: 100%; height: 100%; text-align: left">
                <table style="width: 100%">
                    <tr>
                        <td style="width: 100%">
                            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                <ContentTemplate>
                                    <asp:Panel ID="pnlOpcionesDeConsulta" runat="server" Font-Size="X-Small" Font-Names="Verdana"
                                        DefaultButton="btnConsultarQna" GroupingText="Consulta de autorizaciones para homologación">
                                        <br />
                                        <asp:Label ID="Label3" runat="server" SkinID="SkinLblNormal" Text="Seleccione quincena"></asp:Label>&nbsp;<asp:DropDownList
                                            ID="ddlQnas" runat="server" SkinID="SkinDropDownList">
                                        </asp:DropDownList>
                                        <asp:Button ID="btnConsultarQna" OnClick="btnConsultarQna_Click" runat="server" SkinID="SkinBoton"
                                            Text="Consultar"></asp:Button>
                                        <br />
                                        <br />
                                    </asp:Panel>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                                <ProgressTemplate>
                                    <asp:Image ID="Image4" runat="server" ImageUrl="~/Imagenes/spinner.gif"></asp:Image>
                                    <asp:Label ID="lblUpdateProgress" runat="server" Text="Actualizando..." SkinID="SkinLblDatos"></asp:Label>
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100%">
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                    <ajaxToolkit:CollapsiblePanelExtender ID="CPERecalculosHomologacion" runat="Server"
                                        TextLabelID="Label1" TargetControlID="ContentPanelRecalculosHomologacion" SuppressPostBack="true"
                                        ImageControlID="Image1" ExpandedText="(Ocultar detalles...)" ExpandedImage="~/Imagenes/collapse_blue.jpg"
                                        ExpandControlID="TitlePanelRecalculosHomologacion" CollapsedText="(Mostrar detalles...)"
                                        CollapsedImage="~/Imagenes/expand_blue.jpg" Collapsed="False" CollapseControlID="TitlePanelRecalculosHomologacion">
                                    </ajaxToolkit:CollapsiblePanelExtender>
                                    <table style="width: 100%" cellspacing="0" cellpadding="0">
                                        <tbody>
                                            <tr>
                                                <td colspan="2" style="vertical-align: top; width: 100%; text-align: left">
                                                    <br />
                                                    <asp:LinkButton ID="lbAgregarNuevaAut" runat="server" SkinID="SkinLinkButton" OnClick="lbAgregarNuevaAut_Click">Agregar nueva autorización</asp:LinkButton>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="vertical-align: top; width: 100%; text-align: left" colspan="2">
                                                    <asp:Panel ID="TitlePanelRecalculosHomologacion" runat="server" Width="100%" BorderWidth="1px"
                                                        BorderStyle="Solid" BorderColor="White" CssClass="collapsePanelHeader">
                                                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/expand_blue.jpg"></asp:Image>
                                                        Autorizaciones para recálculos de homologación
                                                        <asp:Label ID="Label1" runat="server">
        (Mostrar detalles...)</asp:Label>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="vertical-align: top; width: 100%; text-align: left" colspan="2">
                                                    <asp:Panel ID="ContentPanelRecalculosHomologacion" runat="server" Width="100%" CssClass="collapsePanel">
                                                        <asp:GridView ID="gvRecalculosHomologacion" runat="server" Width="100%" SkinID="SkinGridView"
                                                            EmptyDataText="No existen autorizaciones" AutoGenerateColumns="False">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="IdQuincena" Visible="False">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblIdQuincena" runat="server" Text='<%# Bind("IdQuincena") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="Quincena" HeaderText="Quincena">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:BoundField>
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
                                                                <asp:TemplateField HeaderText="Eliminar">
                                                                    <ItemTemplate>
                                                                        <asp:ImageButton ID="ibEliminar" runat="server" CommandName="CmdEliminar" ImageUrl="~/Imagenes/Eliminar.png" />
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Modificar">
                                                                    <ItemTemplate>
                                                                        <asp:ImageButton ID="ibModificar" runat="server" ImageUrl="~/Imagenes/Modificar.png"
                                                                            CommandName="CmdModificar" />
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <EmptyDataRowStyle Font-Italic="True" />
                                                        </asp:GridView>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="vertical-align: top; width: 100%; text-align: left" colspan="2">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="vertical-align: top; width: 100%; text-align: left" colspan="2">
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="btnConsultarQna" EventName="Click"></asp:AsyncPostBackTrigger>
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
