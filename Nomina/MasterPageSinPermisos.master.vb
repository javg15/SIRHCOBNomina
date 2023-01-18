
Partial Class MasterPageSinPermisos
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        If Session("Login") Is Nothing Then Response.Redirect("~/Login.aspx")
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Page.Title = ConfigurationManager.AppSettings("NombreCortoEmpresa") + " " + Page.Title.Substring(Page.Title.IndexOf("-"))
        Catch
            Page.Title = ConfigurationManager.AppSettings("NombreCortoEmpresa")
        End Try
        If Not IsPostBack Then
            Me.LoginStatus1.Visible = (Request.Params("Home") = "SI")
            Me.LoginStatus1.LogoutText = "Cerra sesión de: " + Session("Login").ToString.ToUpper
        End If
    End Sub

    Protected Sub LoginStatus1_LoggingOut(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.LoginCancelEventArgs) Handles LoginStatus1.LoggingOut
        Me.Session.RemoveAll()
    End Sub
End Class
