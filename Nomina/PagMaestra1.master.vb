
Partial Class PagMaestra1
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Me.LblFecha.Text = Date.Today.ToLongDateString.ToUpperInvariant
        End If
    End Sub
End Class

