Imports System.Data
Partial Class ErroresPagina
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Me.gvErroresPagina.DataSource = CType(Session("dsValida"), DataSet)
            Me.gvErroresPagina.DataBind()
            Session.Remove("dsValida")
        End If
    End Sub
End Class
