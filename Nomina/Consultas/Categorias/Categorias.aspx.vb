Imports DataAccessLayer.COBAEV.Empleados
Imports System.Data
Partial Class Consultas_Categorias
    Inherits System.Web.UI.Page
    Private Sub BinddvCategoDetalles(ByVal pClavePuesto As String, pCveIdentificadorPuesto As Byte, Optional pIdQuincena As Short = 0)

        Dim oCatego As New Categoria
        Dim dtCategoDetalle As DataTable

        dtCategoDetalle = oCatego.ObtenDetalles(pClavePuesto, pCveIdentificadorPuesto, pIdQuincena)

        dvCategoDetalles.DataSource = dtCategoDetalle.Rows(0).Table
        dvCategoDetalles.DataBind()

        lblEmpInfConsulta.Text = "Información detallada de la categoría "
        lblEmpInfConsulta.Visible = True

    End Sub
    Private Sub BindDatos()
        Dim oCatego As New Categoria

        Me.gvCategorias.DataSource = oCatego.ObtenFiltradas(CByte(ddlFiltroCatego.SelectedValue), _
                                                            CByte(ddlFiltroEstatus.SelectedValue), _
                                                            CByte(ddlFiltroTipoPresup.SelectedValue))
        Me.gvCategorias.DataBind()
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            BindDatos()
            MultiView1.Visible = True
            MultiView1.SetActiveView(viewCategosTodas)
        End If
    End Sub

    Protected Sub gvCategorias_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvCategorias.RowDataBound
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                Dim ibPercPorCatego As ImageButton = CType(e.Row.FindControl("ibPercPorCatego"), ImageButton)
                Dim ibEmpsPorCatego As ImageButton = CType(e.Row.FindControl("ibEmpsPorCatego"), ImageButton)
                Dim lblIdCategoria As Label = CType(e.Row.FindControl("lblIdCategoria"), Label)
                ibPercPorCatego.OnClientClick = "javascript:abreVentanaImpresion('PercepcionesPorCategoria.aspx?IdCategoria=" + lblIdCategoria.Text + "&TipoOperacion=4', '" + lblIdCategoria.Text + "'); return false;"
                ibEmpsPorCatego.OnClientClick = "javascript:abreVentanaImpresion('EmpleadosPorCategoria.aspx?IdCategoria=" + lblIdCategoria.Text + "&TipoOperacion=4', '" + lblIdCategoria.Text + "'); return false;"
                e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
                e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
                e.Row.Attributes("OnClick") = Page.ClientScript.GetPostBackClientHyperlink(Me.gvCategorias, "Select$" + e.Row.RowIndex.ToString)
        End Select
    End Sub

    Protected Sub btnConsultar_Click(sender As Object, e As System.EventArgs) Handles btnConsultar.Click
        BindDatos()
    End Sub

    Protected Sub lbCveOfi_Click(sender As Object, e As System.EventArgs)
        Dim lblIdCategoria, lblCveIdentificadorPuesto, lblCvePuestoCompuesta As Label
        Dim lbCveOfi As LinkButton
        Dim vlCveOfi As String

        Dim gvr As GridViewRow = CType(CType(sender, LinkButton).NamingContainer, GridViewRow)

        lblIdCategoria = CType(gvr.FindControl("lblIdCategoria"), Label)
        lblCveIdentificadorPuesto = CType(gvr.FindControl("lblCveIdentificadorPuesto"), Label)
        lbCveOfi = CType(gvr.FindControl("lbCveOfi"), LinkButton)
        lblCvePuestoCompuesta = CType(gvr.FindControl("lblCvePuestoCompuesta"), Label)
        vlCveOfi = Replace(lblCvePuestoCompuesta.Text, Left(lblCvePuestoCompuesta.Text, 2), String.Empty)

        MultiView1.Visible = True
        BinddvCategoDetalles(vlCveOfi, CByte(lblCveIdentificadorPuesto.Text))
        MultiView1.SetActiveView(viewCategoDetalle)

        'Response.Redirect("wfCategoriaDetalles.aspx?pIdCategoria=" + lblIdCategoria.Text + "&pCveIdentificadorPuesto=" + lblCveIdentificadorPuesto.Text + "&pCveOfi=" + lbCveOfi.Text)

    End Sub

    Protected Sub btnCancelar2_Click(sender As Object, e As System.EventArgs) Handles btnCancelar2.Click
        MultiView1.SetActiveView(viewCategosTodas)
    End Sub
End Class
