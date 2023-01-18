Imports DataAccessLayer.COBAEV.Empleados
Partial Class Administracion_Categorias
    Inherits System.Web.UI.Page
    Private Sub BindDatos()
        Dim oCatego As New Categoria
        Me.gvCategorias.DataSource = oCatego.ObtenTodas
        Me.gvCategorias.DataBind()
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            BindDatos()
        End If
    End Sub

    Protected Sub gvCategorias_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvCategorias.RowDataBound
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                Dim ibPercPorCatego As ImageButton = CType(e.Row.FindControl("ibPercPorCatego"), ImageButton)
                Dim lblIdCategoria As Label = CType(e.Row.FindControl("lblIdCategoria"), Label)
                ibPercPorCatego.OnClientClick = "javascript:abreVentanaImpresion('AdministracionCategoriasPercepciones.aspx?IdCategoria=" + lblIdCategoria.Text + "&TipoOperacion=4', '" + lblIdCategoria.Text + "'); return false;"
                e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
                e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
                e.Row.Attributes("OnClick") = Page.ClientScript.GetPostBackClientHyperlink(Me.gvCategorias, "Select$" + e.Row.RowIndex.ToString)
        End Select
    End Sub

End Class
