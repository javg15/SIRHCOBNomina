<%@ Page Language="VB" MasterPageFile="~/MasterPageSesionIniciada.master" AutoEventWireup="false" 
CodeFile="DocsParaExpedientes.aspx.vb" Inherits="Consultas_Catalogos_DocsParaExpedientes" 
title="COBAEV - Nómina - Catálogo de documentos para expedientes digitales" StylesheetTheme="SkinFile" %>
<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress" TagPrefix="TP_wucUpdateProgress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
    <table style="width:100%; height:300px;" align="center">
        <tr>
            <td style="vertical-align: top; text-align: right">
                <h2>
                    Sistema de nómina: Catálogos (Documentos para expedientes electrónicos)
                </h2>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top; text-align: left">
                <br />
                <asp:GridView ID="gvDocs" runat="server" AutoGenerateColumns="False" SkinID="SkinGridViewEmpty">
                    <Columns>
                        <asp:TemplateField Visible="False">
                            <ItemTemplate>
                                <asp:Label ID="lblIdDocumento" runat="server" Text='<%# Bind("IdDocumento") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="DescripcionDocumento" HeaderText="Tipo de documento" />
                        <asp:TemplateField HeaderText="Empleados vigentes sin documento">
                            <ItemTemplate>
                                <asp:ImageButton ID="ibVigSinDocExcel" runat="server" ImageUrl="~/Imagenes/PrintExcel.png"
                                    ToolTip="Ver reporte en formato de Excel" />&nbsp;<asp:ImageButton ID="ibVigSinDocPDF"
                                        runat="server" ImageUrl="~/Imagenes/PrintPDF.jpg" ToolTip="Ver reporte en formato PDF" />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Empleados no vigentes sin documento">
                            <ItemTemplate>
                                <asp:ImageButton ID="ibNoVigSinDocExcel" runat="server" ImageUrl="~/Imagenes/PrintExcel.png"
                                    ToolTip="Ver reporte en formato de Excel" />&nbsp;<asp:ImageButton ID="ibNoVigSinDocPDF"
                                        runat="server" ImageUrl="~/Imagenes/PrintPDF.jpg" ToolTip="Ver reporte en formato PDF" />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: middle; text-align: left" colspan="" rowspan="">
                <asp:Label ID="Label1" runat="server" SkinID="SkinLblMsjExito" Text="Empleados vigentes sin expediente digital"></asp:Label>&nbsp;<asp:ImageButton
                    ID="ibVigSinDocExcel" runat="server" ImageUrl="~/Imagenes/PrintExcel.png" ToolTip="Ver reporte en formato de Excel" />&nbsp;<asp:ImageButton
                        ID="ibVigSinDocPDF" runat="server" ImageUrl="~/Imagenes/PrintPDF.jpg" ToolTip="Ver reporte en formato PDF" /></td>
        </tr>
        <tr>
            <td style="vertical-align: middle; text-align: left">
                <asp:Label ID="Label2" runat="server" SkinID="SkinLblMsjExito" Text="Empleados no vigentes sin expediente digital"></asp:Label>&nbsp;<asp:ImageButton
                    ID="ibNoVigSinDocExcel" runat="server" ImageUrl="~/Imagenes/PrintExcel.png" ToolTip="Ver reporte en formato de Excel" />&nbsp;<asp:ImageButton
                        ID="ibNoVigSinDocPDF" runat="server" ImageUrl="~/Imagenes/PrintPDF.jpg" ToolTip="Ver reporte en formato PDF" /></td>
        </tr>
    </table>
</asp:Content>

