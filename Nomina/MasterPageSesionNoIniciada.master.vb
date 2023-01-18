
Partial Class MasterPageSesionNoIniciada
    Inherits System.Web.UI.MasterPage

    Protected Sub form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles form1.Load
        Me.LblFecha.Text = Date.Today.ToLongDateString.ToUpperInvariant
    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Try
            Page.Title = ConfigurationManager.AppSettings("NombreCortoEmpresa") + " " + Page.Title.Substring(Page.Title.IndexOf("-"))
        Catch
            Page.Title = ConfigurationManager.AppSettings("NombreCortoEmpresa")
        End Try
        If Not IsPostBack Then
        End If
    End Sub
End Class

