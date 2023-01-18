
Partial Class SinPermiso
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            lbContinuar.Visible = (Request.Params("Home") = "SI")
            lbContinuar.Visible = False
            If Session("URLAnt") Is Nothing = False Then
                lbContinuar.PostBackUrl = "~/" + Session("URLAnt")
                lbContinuar.Visible = True
            End If
        End If
    End Sub
End Class
