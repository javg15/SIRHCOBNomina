Imports DataAccessLayer.COBAEV.InformacionAcademica
Imports DataAccessLayer.COBAEV.Nominas
Partial Class Consultas_Percepciones_Ordinarias
    Inherits System.Web.UI.Page
    Private Sub BindPercsOrd()
        Dim oPerc As New Percepcion
        Me.gvPercsOrd.DataSource = oPerc.ObtenOrdinarias()
        Me.gvPercsOrd.DataBind()
    End Sub
    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        If Not IsPostBack Then
            BindPercsOrd()
        End If
    End Sub
    Protected Sub gvPercProg_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvPercsOrd.RowDataBound
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
                e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
                e.Row.Attributes("OnClick") = Page.ClientScript.GetPostBackClientHyperlink(Me.gvPercsOrd, "Select$" + e.Row.RowIndex.ToString)
        End Select
    End Sub
End Class
