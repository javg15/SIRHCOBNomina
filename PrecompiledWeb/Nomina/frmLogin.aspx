<%@ page language="VB" autoeventwireup="false" inherits="frmLogin, App_Web_1ioibzdf" title="COBAEV SIRH - Inicio de sesión" maintainScrollPositionOnPostBack="true" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>COBAEV SIRH - Inicio de sesión</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="css/csscobaevsirh.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <h2>
        COBAEV SIRH - Inicio de sesión</h2>
    <%--
<button onclick="document.getElementById('id01').style.display='block'" style="width:auto;">Iniciar sesión</button>
    --%>
    <div id="id01" class="modal">
        <form id="frmLogin" runat="server" class="modal-content">
        <div class="imgcontainer">
            <%--      <span onclick="document.getElementById('id01').style.display='none'" class="close" title="Close Modal">&times;</span>--%>
            <img src="Imagenes/AvatarSexenio2018_2024.png" alt="Avatar" class="avatar" />
        </div>
        <div class="container">
            <label for="uname"><b>Usuario</b></label>
            <%--      <input type="text" placeholder="Escriba su número de empleado" name="uname" required>
            --%>
            <asp:TextBox runat="server" ID="uname" placeholder="Escriba su número de empleado"
                required></asp:TextBox>
            <label for="psw"><b>Contraseña</b></label> <%--            <input type="password" placeholder="Escriba su contraseña" name="psw" required>--%>
            <asp:TextBox runat="server" ID="psw" placeholder="Escriba su contraseña"
                required Enabled="false" TextMode="Password"></asp:TextBox>
            <%--            <button type="submit">
                Iniciar sesión</button>--%>
<%--            <asp:Button runat="server" ID="btnContinuar" Text="Iniciar sesión" CssClass="aspxbutton" />--%>            <%--      <label>
        <input type="checkbox" checked="checked" name="remember"> Remember me
      </label>--%>
            <asp:Button ID="btnContinuar" runat="server" CssClass="botonaspx" 
                Text="Continuar" />
        </div>
        <%--    <div class="container" style="background-color:#f1f1f1">
      <button type="button" onclick="document.getElementById('id01').style.display='none'" class="cancelbtn">Cancel</button>
      <span class="psw">Forgot <a href="#">password?</a></span>
    </div>--%>
        </form>
    </div>
    <%--<script>
    // Get the modal
    var modal = document.getElementById('id01');

    // When the user clicks anywhere outside of the modal, close it
    window.onclick = function (event) {
        if (event.target == modal) {
            modal.style.display = "none";
        }
    }
</script>--%>
</body>
</html>
