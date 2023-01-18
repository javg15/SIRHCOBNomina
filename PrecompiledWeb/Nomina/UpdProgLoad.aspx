<%@ page language="VB" autoeventwireup="false" inherits="UpdProgLoad, App_Web_1ioibzdf" maintainScrollPositionOnPostBack="true" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html>
  <head>
        
  </head>
  <body>

      <form id="form1" runat="server">
      <asp:Label ID="Label1" runat="server" Text="Para:"></asp:Label>
      <asp:TextBox ID="txtPara" runat="server"></asp:TextBox>
      <br />
      <asp:Label ID="Label2" runat="server" Text="Asunto:"></asp:Label>
      <asp:TextBox ID="txtAsunto" runat="server"></asp:TextBox>
      <br />
      <asp:Label ID="Label3" runat="server" Text="Mensaje:"></asp:Label>
      <br />
      <brc />
      <asp:TextBox ID="txtMensaje" runat="server" TextMode="MultiLine" Height="229px" 
          Width="501px"></asp:TextBox>
      <br />
      <br />
      <asp:Button ID="btnEnviarEmail" runat="server" Text="Enviar" />
      <br />

      </form>

  </body>
</html>