<%@ Page Language="VB" EnableEventValidation="false" MasterPageFile="~/MasterPageSesionIniciada.master"
    AutoEventWireup="false" CodeFile="PlantelesHistoriaPorCategoria.aspx.vb" Inherits="PlantelesHistoriaPorCategoria"
    Title="COBAEV - Nómina - Histórico Planteles/Categorías" StylesheetTheme="SkinFile" %>
<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress" TagPrefix="TP_wucUpdateProgress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
    <table style="width: 100%; vertical-align: top; text-align: center;" align="center">
        <tr>
            <td style="vertical-align: top; text-align: right">
                <h2>
                    Sistema de nómina: Ocupación histórica de categorías directivas por plantel
                </h2>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top; text-align: left">
                <table style="width: 100%">
                    <tr>
                        <td style="vertical-align: middle">
                            <asp:Label ID="Label2" runat="server" SkinID="SkinLblDatos" Text="Seleccione un plantel"></asp:Label>
                            <br />
                            <asp:DropDownList ID="ddlPlanteles" runat="server" AutoPostBack="True" SkinID="SkinDropDownList">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: middle">
                            <asp:UpdatePanel ID="UPCT" runat="server">
                                <ContentTemplate>
                                    <asp:Label ID="Label3" runat="server" SkinID="SkinLblDatos" Text="Seleccione un centro de responsabilidad"></asp:Label>
                                    <br />
                                    <asp:DropDownList ID="ddlCT" runat="server" AutoPostBack="True" SkinID="SkinDropDownList">
                                    </asp:DropDownList>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddlPlanteles" EventName="SelectedIndexChanged" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: middle">
                            <asp:UpdatePanel ID="UPCategos" runat="server">
                                <ContentTemplate>
                                    <asp:Label ID="Label4" runat="server" SkinID="SkinLblDatos" Text="Seleccione una categoría"></asp:Label>
                                    <br />
                                    <asp:DropDownList ID="ddlCategos" runat="server" AutoPostBack="True" SkinID="SkinDropDownList">
                                    </asp:DropDownList>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddlCT" EventName="SelectedIndexChanged" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="text-align: left; vertical-align: top;">
                <asp:UpdatePanel ID="UPHistorico" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="gvHistorico" runat="server" AutoGenerateColumns="False" CaptionAlign="Left"
                            EmptyDataText="No existen empleados vigentes para la categoría o no tiene permisos para visualizarlos"
                            Font-Names="Verdana" Font-Size="X-Small" PageSize="20" SkinID="SkinGridView"
                            Width="100%">
                            <Columns>
                                <asp:TemplateField HeaderText="RFC">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkbtnrfc" runat="server" CommandName="CmdRFC" Text='<%# databinder.eval(container, "dataitem.rfcemp") %>'
                                            ToolTip="Seleccionar el empleado para consultas" Visible="False"></asp:LinkButton>
                                        <ajaxToolkit:ConfirmButtonExtender ID="CBEEmpSel" runat="server" ConfirmText="¿Seleccionar empleado para consultas posteriores?"
                                            TargetControlID="lnkbtnrfc">
                                        </ajaxToolkit:ConfirmButtonExtender>
                                        <asp:Label ID="lblRFC" runat="server" Text='<%# Bind("RFCEmp") %>'></asp:Label>
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
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Apellido materno">
                                    <ItemTemplate>
                                        <asp:Label ID="lblApeMat" runat="server" Text='<%# Bind("ApeMatEmp") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Nombre">
                                    <ItemTemplate>
                                        <asp:Label ID="lblNombre" runat="server" Text='<%# Bind("NomEmp") %>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterStyle HorizontalAlign="Left" />
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Número de empleado">
                                    <ItemTemplate>
                                        <asp:Label ID="lblNumEmp" runat="server" Text='<%# Bind("numemp") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="NombreFuncionPri" HeaderText="Función primaria">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Inicio" HeaderText="Inicio">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Fin" HeaderText="Fin">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                            </Columns>
                            <HeaderStyle CssClass="dgheader" />
                        </asp:GridView>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlCategos" EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
            </td>
        </tr>
    </table>
</asp:Content>
