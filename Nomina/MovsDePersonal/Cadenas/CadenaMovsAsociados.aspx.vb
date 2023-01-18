Imports DataAccessLayer.COBAEV.Nominas
Imports System.Data
Imports DataAccessLayer.COBAEV.Administracion
Imports DataAccessLayer.COBAEV.MovsDePersonal
Partial Class CadenaMovsAsociados
    Inherits System.Web.UI.Page
    Private Sub BindgvMovs()
        Dim oCadena As New Cadenas
        Dim drEstatusCadena As DataRow

        drEstatusCadena = oCadena.EstaAbiertaParaCaptura(CInt(Request.Params("IdCadena")))

        With Me.gvCadena
            .DataSource = oCadena.ObtenPorId(CInt(Request.Params("IdCadena")))
            .DataBind()
        End With

        With Me.gvMovs
            .DataSource = oCadena.ObtenMovsAsociados(CInt(Request.Params("IdCadena")))
            .DataBind()
        End With

        Dim oUsr As New Usuario
        Dim dt As DataTable
        dt = oUsr.ObtenPermisosSobreTabla(Session("Login"), "CadenasPlazas")
        Me.gvMovs.Columns(17).Visible = CBool(dt.Rows(0).Item("Eliminacion")) And CBool(drEstatusCadena("AbiertaParaCaptura"))
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            BindgvMovs()
        End If
    End Sub
    Protected Sub gvMovs_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvMovs.RowDataBound
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
                e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
                e.Row.Attributes("OnClick") = Page.ClientScript.GetPostBackClientHyperlink(Me.gvMovs, "Select$" + e.Row.RowIndex.ToString)
        End Select
    End Sub

    Protected Sub gvCadena_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        Dim oUsr As New Usuario
        Dim drUsr As DataRow
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                Dim lblIdUsuarioCreador As Label = CType(e.Row.FindControl("lblIdUsuarioCreador"), Label)
                Dim lblIdUsuarioModifico As Label = CType(e.Row.FindControl("lblIdUsuarioModifico"), Label)
                Dim lblLoginCreador As Label = CType(e.Row.FindControl("lblLoginCreador"), Label)
                Dim lblLoginModifico As Label = CType(e.Row.FindControl("lblLoginModifico"), Label)

                oUsr.IdUsuario = CShort(lblIdUsuarioCreador.Text)
                drUsr = oUsr.ObtenerPorId()
                lblLoginCreador.Text = drUsr("Login")
                lblLoginCreador.ToolTip = drUsr("NomComUsr")

                If lblIdUsuarioModifico.Text <> String.Empty Then
                    oUsr.IdUsuario = CShort(lblIdUsuarioModifico.Text)
                    drUsr = oUsr.ObtenerPorId()
                    lblLoginModifico.Text = drUsr("Login")
                    lblLoginModifico.ToolTip = drUsr("NomComUsr")
                End If
        End Select
    End Sub

    Protected Sub ibEliminar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Dim ibEliminar As ImageButton = CType(sender, ImageButton)
        Dim Fila As GridViewRow = CType(ibEliminar.NamingContainer, GridViewRow)

        Dim lblIdCadena As Label = CType(Me.gvMovs.Rows(Fila.RowIndex).FindControl("lblIdCadena"), Label)
        Dim lblIdPlaza As Label = CType(Me.gvMovs.Rows(Fila.RowIndex).FindControl("lblIdPlaza"), Label)

        Dim oCadena As New Cadenas

        oCadena.EliminaMov(CInt(lblIdCadena.Text), CInt(lblIdPlaza.Text), CType(Session("ArregloAuditoria"), String()))

        BindgvMovs()
    End Sub
End Class
