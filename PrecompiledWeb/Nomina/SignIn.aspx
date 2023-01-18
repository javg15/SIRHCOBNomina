<%@ page language="VB" enableeventvalidation="false" masterpagefile="~/PagMaestra1.master" autoeventwireup="false" inherits="SignIn, App_Web_cyyqwboa" title="COBAEV - Nómina - Inicio de sesión" stylesheettheme="SkinFile" maintainScrollPositionOnPostBack="true" %>
<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress"
    TagPrefix="TP_wucUpdateProgress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
    <div id="divContenedor">
        <div id="divContenedorLogin">
            <div id="divImgFestejo">
                <asp:Image ID="ImgGifAnim" runat="server" ImageUrl="~/Imagenes/ComodinBlanco.gif" />            
            </div>          
            <div id="divLogin">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/imgLogin.png" Width="363px" Height="219px" />
            </div>
        </div>
        <div id="divMsjLogin">
            <asp:UpdatePanel id="UpdatePanel1" runat="server" UpdateMode="Conditional">
                <contenttemplate>
                    <asp:Label id="lblError" runat="server" EnableViewState="False" SkinID="SkinLblMsjErrores"></asp:Label>
                </contenttemplate>
                <triggers>
                    
                </triggers>
            </asp:UpdatePanel>      
        </div>
    </div>
</asp:Content>
