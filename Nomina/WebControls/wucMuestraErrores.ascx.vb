Imports System.Data
Partial Class wucMuestraErrores
    Inherits System.Web.UI.UserControl
    Public Sub ActualizaContenido()
        gvErroresPagina.DataSource = CType(Session("dsValida"), DataSet)
        gvErroresPagina.DataBind()
        Session.Remove("dsValida")
    End Sub
    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Session("dsValida") Is Nothing = False Then
            ActualizaContenido()
        End If
    End Sub
End Class
