<%@ Page Language="VB" EnableEventValidation="false" MasterPageFile="~/MasterPageSesionIniciada.master"
    AutoEventWireup="false" CodeFile="wfPlanteles.aspx.vb" Inherits="wfPlanteles"
    Title="COBAEV - Nómina - Planteles" StylesheetTheme="SkinFile" %>

<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress"
    TagPrefix="TP_wucUpdateProgress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
    <table style="width: 100%; vertical-align: top; text-align: center;" align="center">
        <tr>
            <td style="vertical-align: top; text-align: right">
                <h2>
                    Sistema de nómina: Planteles
                </h2>
            </td>
        </tr>
        <tr>
            <td style="text-align: center; vertical-align: top;">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="gvPlanteles" runat="server" CellPadding="1" SkinID="SkinGridView"
                            Width="100%" AllowSorting="True">
                            <Columns>
                                <asp:TemplateField HeaderText="IdPlantel" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIdPlantel" runat="server" Text='<%# Bind("IdPlantel") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="ClaveOficial" HeaderText="Clave Oficial">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="ClaveCOBAEV" SortExpression="ClaveCOBAEV">
                                    <ItemTemplate>
                                        <asp:Label ID="lblClaveCOBAEV" runat="server" Text='<%# Bind("ClaveCOBAEV") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="Plantel" HeaderText="Plantel" SortExpression="Plantel">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="TipoPlantel" HeaderText="Tipo" 
                                    SortExpression="TipoPlantel">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Turno" HeaderText="Turno" SortExpression="Turno">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="EMSAD" HeaderText="EMSAD" SortExpression="EMSAD">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ZonaEco" HeaderText="Zona Económica" SortExpression="ZonaEco">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ZonaGeo" HeaderText="Zona Geográfica" SortExpression="ZonaGeo">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="IdUsuario" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIdUsuario" runat="server" Text='<%# Bind("IdUsuario") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Analista de zona">
                                    <ItemTemplate>
                                        <asp:Label ID="lblNombreAnalista" runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="Localidad" HeaderText="Localidad">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Municipio" HeaderText="Municipio">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ibModificarHorarios" runat="server" ImageUrl="~/Imagenes/ico_calendar.png"
                                            CausesValidation="false" ToolTip="Modificar la información del registro." /></ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </ContentTemplate>
                    <Triggers>
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>
