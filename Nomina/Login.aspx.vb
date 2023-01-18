Imports DataAccessLayer.COBAEV.Administracion
Imports DataAccessLayer.COBAEV.Nominas
Partial Class Login
    Inherits System.Web.UI.Page

    Protected Sub Login1_Authenticate(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.AuthenticateEventArgs) Handles Login1.Authenticate
        Try
            'System.Threading.Thread.Sleep(3000)
            Dim oUsr As New Usuario
            Session.Remove("ArregloAuditoria")
            Dim ArregloAuditoria(3) As String

            oUsr.Login = Login1.UserName.Trim.ToUpper
            oUsr.Password = Login1.Password.Trim
            If oUsr.EsValido() Then
                e.Authenticated = True
                Session.Add("Login", Login1.UserName.Trim.ToUpper)

                ArregloAuditoria(0) = Request.ServerVariables("REMOTE_ADDR")
                ArregloAuditoria(1) = Session("Login")
                Session.Add("ArregloAuditoria", ArregloAuditoria)
                Dim oAuditoria As New Auditoria
                ArregloAuditoria(2) = "Login"
                oAuditoria.InsertaRegistro(ArregloAuditoria)
                'Response.Redirect("~/Administracion/Quincenas/Quincenas.aspx")
                'Server.Transfer("~/Administracion/Quincenas/Quincenas.aspx")
            Else
                e.Authenticated = False
                Me.lblError.Text = "Inicio de sesión no válido. Login o Password incorrectos."
            End If
        Catch ex As Exception
            Me.lblError.Text = ex.Message
        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        FormsAuthentication.SetAuthCookie("", True)
        If Not IsPostBack Then
            If System.IO.File.Exists(ConfigurationManager.AppSettings("RutaImagenes") + Date.Now.Month.ToString + ".gif") Then
                Me.ImgGifAnim.ImageUrl = "~/Imagenes/" + Date.Now.Month.ToString + ".gif"
                Me.ImgGifAnim.Visible = True
            Else
                Me.ImgGifAnim.ImageUrl = "~/Imagenes/ComodinBlanco.gif"
                Me.ImgGifAnim.Visible = False
            End If
            Dim LoginButton As Button = CType(Me.Login1.FindControl("LoginButton"), Button)
            LoginButton.OnClientClick = "javascript:limpiaEtiqueta('" + Me.lblError.ClientID + "');"
        End If
    End Sub
End Class
