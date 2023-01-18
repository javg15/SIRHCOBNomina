<%@ Page Language="VB" MasterPageFile="~/MasterPageBlanca.master" MaintainScrollPositionOnPostback="true" AutoEventWireup="false" 
    CodeFile="VentanaArchivosExcelTimbrado.aspx.vb" Inherits="VentanaArchivosExcelTimbrado" Title="Generando archivo..." %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:Timer ID="Timer1" runat="server" Enabled="False" Interval="2000">
    </asp:Timer>
    <asp:Label ID="Label1" runat="server" 
        Text="Generando archivo, por favor espere..." Font-Bold="True"
        Font-Names="Verdana" Font-Size="11pt" ForeColor="#0066FF" ></asp:Label>
    <br />
    <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/gears_anim.gif" />


</asp:Content>