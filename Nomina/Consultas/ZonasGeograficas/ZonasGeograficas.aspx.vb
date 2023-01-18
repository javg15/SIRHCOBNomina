Imports DataAccessLayer.COBAEV
Imports System.Data
Imports DataAccessLayer.COBAEV.Administracion
Partial Class Consultas_ZonasGeograficas
    Inherits System.Web.UI.Page

    Private Sub BindDatos()
        Dim oZonageo As New Zonageografica
        Me.gvZonasGeo.DataSource = oZonageo.ObtenTodasConAnalista()
        Me.gvZonasGeo.DataBind()
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            BindDatos()
        End If
    End Sub

    Protected Sub gvZonasGeo_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvZonasGeo.RowCommand
        Select Case e.CommandName
            Case "VerPlanteles", "Select"
                Dim lblIdZonaGeografica As Label = CType(gvZonasGeo.Rows(CInt(e.CommandArgument)).FindControl("lblIdZonaGeografica"), Label)
                Dim lblNombreZonaGeografica As Label = CType(gvZonasGeo.Rows(CInt(e.CommandArgument)).FindControl("lblNombreZonaGeografica"), Label)
                Dim oZonaGeo As New Zonageografica
                oZonaGeo.IdZonageografica = CByte(lblIdZonaGeografica.Text)
                Me.gvCTs.DataSource = oZonaGeo.ObtenPlanteles()
                Me.gvCTs.DataBind()
                Me.gvCTs.Visible = True
                gvZonasGeo.SelectedIndex = CInt(e.CommandArgument)
        End Select
    End Sub

    Protected Sub gvZonasGeo_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvZonasGeo.RowDataBound
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                Dim ibPlantel As ImageButton = CType(e.Row.FindControl("ibPlantel"), ImageButton)
                Dim lblIdUsuario As Label = CType(e.Row.FindControl("lblIdUsuario"), Label)
                Dim lblNombreAnalista As Label = CType(e.Row.FindControl("lblNombreAnalista"), Label)
                Dim oUsr As New Usuario
                Dim drUsr As DataRow

                drUsr = oUsr.ObtenPorId(CShort(lblIdUsuario.Text))

                ibPlantel.CommandArgument = e.Row.RowIndex

                lblNombreAnalista.Text = drUsr("NomComUsr").ToString

                e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
                e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
                e.Row.Attributes("OnClick") = Page.ClientScript.GetPostBackClientHyperlink(Me.gvZonasGeo, "Select$" + e.Row.RowIndex.ToString)
        End Select
    End Sub


    Protected Sub gvCTs_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvCTs.RowDataBound
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                Dim ibEmpPorCT As ImageButton = CType(e.Row.FindControl("ibEmpPorCT"), ImageButton)
                Dim lblIdCT As Label = CType(e.Row.FindControl("lblIdCT"), Label)
                ibEmpPorCT.OnClientClick = "javascript:abreVentanaImpresion('../CentrosDeTrabajo/EmpleadosPorCT.aspx?IdCT=" + lblIdCT.Text + "&TipoOperacion=4', '" + lblIdCT.Text + "'); return false;"
                e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
                e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
                e.Row.Attributes("OnClick") = Page.ClientScript.GetPostBackClientHyperlink(Me.gvCTs, "Select$" + e.Row.RowIndex.ToString)
        End Select
    End Sub
End Class
