Imports DataAccessLayer.COBAEV.Empleados
Partial Class Administracion_Categorias_Percepciones
    Inherits System.Web.UI.Page
    Private Sub BindDatos()
        Dim oCatego As New Categoria
        oCatego.IdCategoria = CShort(Request.Params("IdCategoria"))
        Me.gvCategoria.DataSource = oCatego.ObtenPorId
        Me.gvCategoria.DataBind()
        Me.gvPercepciones.DataSource = oCatego.ObtenPercepcionesAsociadas
        Me.gvPercepciones.DataBind()
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            BindDatos()
        End If
    End Sub
End Class
