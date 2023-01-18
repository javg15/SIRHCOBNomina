
Partial Class MasterPageSesionNoIniciada
    Inherits System.Web.UI.MasterPage

    Protected Sub form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles form1.Load
        Me.LblFecha.Text = Date.Today.ToLongDateString.ToUpperInvariant
    End Sub
End Class

