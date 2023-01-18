<%@ Page Language="VB" EnableEventValidation="false" MasterPageFile="~/MasterPageSesionIniciada.master"
    AutoEventWireup="false" CodeFile="NivelesSalarialesHistoria.aspx.vb" Inherits="MovsDePersonal_NivelesSalariales"
    Title="COBAEV - Nómina - Niveles salariales" StylesheetTheme="SkinFile" %>

<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress" TagPrefix="TP_wucUpdateProgress" %>
<%@ Register src="../../WebControls/wucAnioQnas.ascx" tagname="wucAnioQnas" tagprefix="TP_wucAnioQnas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server"> 
    <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
    <table style="width: 100%; vertical-align: top; text-align: center;" align="center">
        <tr>
            <td style="vertical-align: top; text-align: right">
                <h2>
                    Sistema de nómina: Niveles salariales</h2>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top; text-align: left">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <TP_wucAnioQnas:wucAnioQnas ID="wucAnioQnas1" runat="server" 
                            EnableViewState="true" />
                        <asp:Label ID="Label2" runat="server" SkinID="SkinLblNormal" 
                            Text="Nivel salarial"></asp:Label>
                        &nbsp;<asp:DropDownList ID="ddlNivelesSalariales" runat="server" 
                            SkinID="SkinDropDownList">
                        </asp:DropDownList>
                        <br />
                        <asp:Button ID="btnConsultar" runat="server" SkinID="SkinBoton" 
                            Text="Consultar" 
                            ToolTip="Consultar información del nivel salarial en base a los valores seleccionados" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td style="text-align: left; vertical-align: top;">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="Label1" runat="server" SkinID="SkinLblNormal"></asp:Label>
                            <asp:GridView ID="gvNivelesSalariales" runat="server" CellPadding="1" 
                                EmptyDataText="Información no disponible." SkinID="SkinGridView" 
                                Width="100%">
                                <Columns>
                                    <asp:CommandField ButtonType="Image" SelectImageUrl="~/Imagenes/Select.png" ShowSelectButton="True">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:CommandField>
                                    <asp:BoundField DataField="NivelSalarial" HeaderText="Nivel salarial">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ImporteSalarialZona02" HeaderText="Zona 02" 
                                        DataFormatString="{0:c}">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ImporteSalarialZona03" HeaderText="Zona 03" 
                                        DataFormatString="{0:c}">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="IdQnaIni" HeaderText="IdQnaIni" Visible="false">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Inicio" HeaderText="Inicio">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="IdQnaFin" HeaderText="IdQnaFin" Visible="false">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Fin" HeaderText="Fin">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Seleccionar" Visible="False">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="ChkBxSeleccionar" runat="server" Checked='<%# Bind("Seleccionar") %>'></asp:CheckBox>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlNivelesSalariales" 
                            EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="btnConsultar" EventName="Click" />
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
