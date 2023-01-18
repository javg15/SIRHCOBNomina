Imports DataAccessLayer.COBAEV.Administracion
Partial Class Account_Login
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RegisterHyperLink.NavigateUrl = "Register.aspx?ReturnUrl=" + HttpUtility.UrlEncode(Request.QueryString("ReturnUrl"))
    End Sub

    Protected Sub LoginUser_Authenticate(sender As Object, e As System.Web.UI.WebControls.AuthenticateEventArgs) Handles LoginUser.Authenticate
        Try
            Dim oUsr As New Usuario

            oUsr.Login = LoginUser.UserName.Trim.ToUpper
            oUsr.Password = LoginUser.Password.Trim
            If oUsr.EsValido() Then
                e.Authenticated = True
                Session.Add("Login", LoginUser.UserName.Trim.ToUpper)
                Response.Redirect("../About.aspx", True)
            Else
                e.Authenticated = False
            End If
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
    End Sub
End Class