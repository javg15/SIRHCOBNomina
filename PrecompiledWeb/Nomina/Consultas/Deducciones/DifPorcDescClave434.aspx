<%@ page language="VB" enableeventvalidation="false" masterpagefile="~/MasterPageSesionIniciada.master" autoeventwireup="false" inherits="DifPorcDescClave434, App_Web_ekwo5m5f" title="COBAEV - Nómina - Porcentajes usados para Préstamo hipotecario FOVISSSTE" stylesheettheme="SkinFile" maintainScrollPositionOnPostBack="true" %>
<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress" TagPrefix="TP_wucUpdateProgress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
    <table style="width: 100%; height: 300px" align="center">
        <tr>
            <td style="vertical-align: top; text-align: right">
                <h2>
                    Sistema de nómina: Reportes (Porcentajes aplicados de préstamo hipotecario FOVISSSTE)
                </h2>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top; width: 100%; height: 100%; text-align: left">
                <table style="width: 100%">
                    <tr>
                        <td style="width: 100%">
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                    <table cellpadding="0" cellspacing="0" style="width: 100%">
                                        <tbody>
                                            <tr>
                                                <td style="vertical-align: top; width: 100%; text-align: left">
                                                    <asp:Panel ID="ContentPanelEmpsConClave434" runat="server" 
                                                        CssClass="collapsePanel" Height="100%" Width="100%">
                                                        <asp:GridView ID="gvHistoriaPorcDescClave434" runat="server" 
                                                            EmptyDataText="Sin información de porcentajes de préstamos hipotecarios FOVISSSTE." 
                                                            SkinID="SkinGridView">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Porcentaje">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblPorcDesc" runat="server" 
                                                                            Text='<%# Bind("PorcDesc", "{0:f2}%") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <ItemTemplate>
                                                                        <asp:ImageButton ID="ibHistPorcDescPDF" runat="server" CommandName="HistPorcDescPDF" 
                                                                            ImageUrl="~/Imagenes/PrintPDF.png" 
                                                                            ToolTip="Reporte en PDF de empleados a quienes se les aplica/aplicó el porcentaje." />
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <ItemTemplate>
                                                                        <asp:ImageButton ID="ibHistPorcDescExcel" runat="server" CommandName="HistPorcDescExcel" 
                                                                            ImageUrl="~/Imagenes/PrintExcel.png" 
                                                                            ToolTip="Reporte en EXCEL de empleados a quienes se les aplica/aplicó el porcentaje." />
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
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

