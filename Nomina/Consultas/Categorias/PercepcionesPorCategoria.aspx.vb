Imports DataAccessLayer.COBAEV.Empleados
Imports DataAccessLayer.COBAEV.Nominas
Partial Class Consultas_PercepcionesPorCategoria
    Inherits System.Web.UI.Page
    Private Sub BindDatos()
        Dim oCatego As New Categoria
        oCatego.IdCategoria = CShort(Request.Params("IdCategoria"))
        Me.gvCategoria.DataSource = oCatego.ObtenPorId
        Me.gvCategoria.DataBind()
        Me.gvPercepciones.DataSource = oCatego.ObtenPercepcionesOrdinariasAsociadas()
        Me.gvPercepciones.DataBind()
    End Sub
    Private Sub BindgvPercepcionesHistoria()
        Dim oCatego As New Categoria
        oCatego.IdCategoria = CShort(Request.Params("IdCategoria"))
        Me.gvPercepcionesHistoria.DataSource = oCatego.ObtenPercepcionesOrdinariasAsociadas(True)
        Me.gvPercepcionesHistoria.DataBind()
        Me.LblPercepcionesHistoria.Visible = True
        Me.gvPercepcionesHistoria.Visible = True
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Response.Expires = 0
            BindDatos()
        End If
    End Sub

    Protected Sub gvPercepciones_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvPercepciones.RowDataBound
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                Dim ibModificar As ImageButton = CType(e.Row.FindControl("ibModificar"), ImageButton)
                Dim ibNuevosValores As ImageButton = CType(e.Row.FindControl("ibNuevosValores"), ImageButton)
                Dim lblIdPercepcion As Label = CType(e.Row.FindControl("lblIdPercepcion"), Label)
                Dim lblIdZonaEco As Label = CType(e.Row.FindControl("lblIdZonaEco"), Label)
                Dim lblIdQnaVigIniPerc As Label = CType(e.Row.FindControl("lblIdQnaVigIniPerc"), Label)
                If CShort(lblIdQnaVigIniPerc.Text) = 0 Then
                    ibModificar.Visible = False
                    ibNuevosValores.OnClientClick = "javascript:abreVentMedAncha('../../ABC/Categorias/AdministracionPercepcionesPorCategoria.aspx?IdCategoria=" + Request.Params("IdCategoria") + "&IdPercepcion=" + lblIdPercepcion.Text + _
                                                    "&IdZonaEco=" + lblIdZonaEco.Text + "&IdQnaVigIniPerc=" + lblIdQnaVigIniPerc.Text + "&TipoOperacion=1'); return false;"
                Else
                    ibModificar.OnClientClick = "javascript:abreVentMedAncha('../../ABC/Categorias/AdministracionPercepcionesPorCategoria.aspx?IdCategoria=" + Request.Params("IdCategoria") + "&IdPercepcion=" + lblIdPercepcion.Text + _
                                                "&IdZonaEco=" + lblIdZonaEco.Text + "&IdQnaVigIniPerc=" + lblIdQnaVigIniPerc.Text + "&TipoOperacion=0'); return false;"
                    ibNuevosValores.OnClientClick = "javascript:abreVentMedAncha('../../ABC/Categorias/AdministracionPercepcionesPorCategoria.aspx?IdCategoria=" + Request.Params("IdCategoria") + "&IdPercepcion=" + lblIdPercepcion.Text + _
                    "&IdZonaEco=" + lblIdZonaEco.Text + "&IdQnaVigIniPerc=" + lblIdQnaVigIniPerc.Text + "&TipoOperacion=1'); return false;"
                End If

                e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
                e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
                e.Row.Attributes("OnClick") = Page.ClientScript.GetPostBackClientHyperlink(Me.gvPercepciones, "Select$" + e.Row.RowIndex.ToString)
        End Select
    End Sub

    Protected Sub gvCategoria_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvCategoria.RowCommand
        Select Case e.CommandName
            Case "ClaveCategoria"
                Dim lbClaveCategoria As LinkButton = CType(Me.gvCategoria.Rows(CInt(e.CommandArgument)).FindControl("lbClaveCategoria"), LinkButton)
                Me.LblPercepcionesHistoria.Text = "Historial de percepciones sobre la categoría " + lbClaveCategoria.Text
                BindgvPercepcionesHistoria()
        End Select
    End Sub

    Protected Sub gvCategoria_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvCategoria.RowDataBound
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                Dim lbClaveCategoria As LinkButton = CType(e.Row.FindControl("lbClaveCategoria"), LinkButton)
                lbClaveCategoria.CommandArgument = e.Row.RowIndex
        End Select
    End Sub

    Protected Sub gvPercepcionesHistoria_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvPercepcionesHistoria.RowDataBound
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
                e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
                e.Row.Attributes("OnClick") = Page.ClientScript.GetPostBackClientHyperlink(Me.gvPercepcionesHistoria, "Select$" + e.Row.RowIndex.ToString)
        End Select
    End Sub

    Protected Sub gvPercepciones_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvPercepciones.RowCommand
        BindDatos()
        If Me.gvPercepcionesHistoria.Visible Then BindgvPercepcionesHistoria()
    End Sub
End Class
