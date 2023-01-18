
Partial Class SiteSesionIniciada
    Inherits System.Web.UI.MasterPage

    Protected Sub HeadLoginStatus_LoggingOut(sender As Object, e As System.Web.UI.WebControls.LoginCancelEventArgs)
        Session.Remove("Login")
    End Sub
End Class

