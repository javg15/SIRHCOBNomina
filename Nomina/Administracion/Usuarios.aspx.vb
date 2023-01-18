Imports DataAccessLayer.COBAEV.Administracion
Partial Class Administracion_Usuarios
    Inherits System.Web.UI.Page
    Private Sub BindDatos()
        Dim oUsr As New Usuario
        Me.gvUsuarios.DataSource = oUsr.ObtenerPorAplicacion
        Me.gvUsuarios.DataBind()
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            BindDatos()
        End If
    End Sub

    Protected Sub gvUsuarios_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvUsuarios.RowDataBound
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                Dim lbDetalles As LinkButton = CType(e.Row.FindControl("lbDetalles"), LinkButton)
                Dim lbModificar As LinkButton = CType(e.Row.FindControl("lbModificar"), LinkButton)
                Dim lblIdUsuario As Label = CType(e.Row.FindControl("lblIdUsuario"), Label)
                'lbDetalles.OnClientClick = "javascript:abreVentMedAncha('Usuarios/UsuariosDetalles.aspx?IdUsuario=" + lblIdUsuario.Text + "&TipoOperacion=4'); return false;"
                lbDetalles.PostBackUrl = "Usuarios/UsuariosDetalles.aspx?IdUsuario=" + lblIdUsuario.Text + "&TipoOperacion=4"
                'lbModificar.OnClientClick = "javascript:abreVentMedAncha('Usuarios/UsuariosDetalles.aspx?IdUsuario=" + lblIdUsuario.Text + "&TipoOperacion=0'); return false;"
                lbModificar.PostBackUrl = "Usuarios/UsuariosDetalles.aspx?IdUsuario=" + lblIdUsuario.Text + "&TipoOperacion=0"
                e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
                e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
                e.Row.Attributes("OnClick") = Page.ClientScript.GetPostBackClientHyperlink(Me.gvUsuarios, "Select$" + e.Row.RowIndex.ToString)
        End Select
    End Sub

    Protected Sub ibActualizar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibActualizar.Click
        BindDatos()
    End Sub
End Class
